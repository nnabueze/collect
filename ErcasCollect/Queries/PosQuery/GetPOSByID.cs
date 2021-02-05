using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Commands.Dto.PosDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.Dto;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetPOSByIDQuery : IRequest<SuccessfulResponse>
    {

        private string _billerId { get; set; }

        public GetPOSByIDQuery(string billerId)
        {
            _billerId = billerId;
        }

        public class GetPOSByIDHandler : IRequestHandler<GetPOSByIDQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<Pos> posRepository;

            private readonly IMapper mapper;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<LevelDisplayName> _levelDisplayName;

            private readonly IGenericRepository<User> _userRepository;

            private readonly ResponseCode _responseCode;

            private readonly NameConstant _nameConstant;

            private readonly IGenericRepository<PosLocation> _posLocationRepository;


            public GetPOSByIDHandler(IGenericRepository<Pos> posRepository, IMapper mapper, IGenericRepository<Biller> billerRepository,

                IGenericRepository<User> userRepository, IOptions<ResponseCode> responseCode, IOptions<NameConstant> nameConstant, IGenericRepository<LevelDisplayName> levelDisplayName, 
                
                IGenericRepository<PosLocation> posLocationRepository)
            {
                this.posRepository = posRepository ?? throw new ArgumentNullException(nameof(posRepository));

                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

                _billerRepository = billerRepository;

                _userRepository = userRepository;

                _responseCode = responseCode.Value;

                _nameConstant = nameConstant.Value;

                _levelDisplayName = levelDisplayName;

                _posLocationRepository = posLocationRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetPOSByIDQuery query, CancellationToken cancellationToken)
            {
                List<AllPosDto> posList = new List<AllPosDto>();

                var biller = await _billerRepository.FindSingleInclude(x => x.ReferenceKey == query._billerId, x => x.Poses, x => x.LevelTwo, x => x.LevelOne);

                if (biller == null)

                    return ResponseGenerator.Response(_nameConstant.InvalidTransactionId, _responseCode.NotFound, false);

                foreach (var item in biller.Poses)
                {
                    var location = GetPosCoordinates((int)item.BillerId, item.Id);

                    var pos = new AllPosDto()
                    {
                        BillerName = biller.Name,

                        ActivationPin = item.ActivationPin,

                        IsActive = item.IsActive.ToString(),

                        IsLogin = item.IsLogin.ToString(),

                        LevelOne = item.LevelOne.Name,

                        LevelTwo = item.LevelTwo.Name,

                        PosId = item.ReferenceKey,

                        PosImei = item.PosImei,

                        Latitude = location != null ? location.Latitude : 0,

                        Longitude = location != null ? location.Longitude : 0

                    };

                    if (item.UserId != null)

                        pos.LoginUserName = GetUserName((int)item.UserId);

                    if (item.LastUserId != null)

                        pos.LastLoginUserName = GetUserName((int)item.LastUserId);

                    posList.Add(pos);
                }

                var billerPos = new BillerPosDto()
                {
                    BillerLevelOneDisplayName = GetBillerDisplayName(biller.Id).LevelOneDisplayName,

                    BillerLevelTwoDisplayName = GetBillerDisplayName(biller.Id).LevelTwoDisplayName,

                    Poses = posList
                };

                return ResponseGenerator.Response(_nameConstant.Successful, _responseCode.OK, true, billerPos);

            }

            private PosLocation GetPosCoordinates(int billerId, int posId)
            {
                return _posLocationRepository.Find(x => x.PosId == posId && x.BillerId == billerId).OrderByDescending(x => x.CreatedDate).FirstOrDefault();
            }

            private LevelDisplayName GetBillerDisplayName(int billerId)
            {
                return _levelDisplayName.FindFirst(x => x.BillerId == billerId);
            }

            private string GetUserName(int userId)
            {
                var user = _userRepository.FindFirst(x => x.Id == userId);

                if (user != null)

                    return user.Name;

                return null;
            }


        }


    }
}

