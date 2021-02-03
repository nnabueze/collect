using System;
using System.Collections.Generic;
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
    public class GetAllPOSQuery : IRequest<SuccessfulResponse>
    {


        public class GetAllPOSHandler : IRequestHandler<GetAllPOSQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<Pos> posRepository;

            private readonly IMapper mapper;

            private readonly IGenericRepository<User> _userRepository;

            private readonly ResponseCode _responseCode;

            private readonly NameConstant _nameConstant;

            public GetAllPOSHandler(IGenericRepository<Pos> posRepository, IMapper mapper, IGenericRepository<User> userRepository, 
                
                IOptions<ResponseCode> responseCode, IOptions<NameConstant> nameConstant)
            {
                this.posRepository = posRepository ?? throw new ArgumentNullException(nameof(posRepository));

                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

                _userRepository = userRepository;

                _responseCode = responseCode.Value;

                _nameConstant = nameConstant.Value;
            }

            public async Task<SuccessfulResponse> Handle(GetAllPOSQuery query, CancellationToken cancellationToken)
            {
                List<AllPosDto> posList = new List<AllPosDto>();

                var result = await posRepository.FindAllInclude(x => x.IsDeleted == false, x => x.Biller, x => x.LevelOne, x => x.LevelTwo);

                if (result == null)

                    return ResponseGenerator.Response("No result found", _responseCode.NotFound, false);

                foreach (var item in result)
                {
                    var pos = new AllPosDto()
                    {
                        BillerName = item.Biller.Name,

                        ActivationPin = item.ActivationPin,

                        IsActive = item.IsActive.ToString(),

                        IsLogin = item.IsLogin.ToString(),

                        LevelOne = item.LevelOne.Name,

                        LevelTwo = item.LevelTwo.Name,

                         PosId = item.ReferenceKey,

                         PosImei = item.PosImei
                        
                    };

                    if (item.UserId != null)

                        pos.LoginUserName = GetUserName((int)item.UserId);

                    if(item.LastUserId != null)

                        pos.LastLoginUserName = GetUserName((int)item.LastUserId);

                    posList.Add(pos);
                }

                return ResponseGenerator.Response(_nameConstant.Successful, _responseCode.OK, true, posList);

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

