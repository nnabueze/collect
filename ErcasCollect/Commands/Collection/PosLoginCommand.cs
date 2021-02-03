using AutoMapper;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ErcasCollect.Commands.Collection
{
    public class PosLoginCommand : IRequest<SuccessfulResponse>
    {
        public PosLoginDto posLoginDto { get; set; }

        public class PosLoginCommandHandler : IRequestHandler<PosLoginCommand, SuccessfulResponse>
        {

            private readonly ResponseCode _responseCode;

            private readonly IWebCallService _webCallService;

            private readonly WebEndpoint _webEndpoint;

            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<LevelDisplayName> _levelDisplayNameRepository;

            private readonly IGenericRepository<Pos> _posRespository;

            private readonly IGenericRepository<User> _userRepository;

            private readonly IMapper _mapper;

            public PosLoginCommandHandler(IOptions<ResponseCode> responseCode, IWebCallService webCallService, IOptions<WebEndpoint> webEndpoint,

                IGenericRepository<LevelOne> levelOneRepository, IGenericRepository<Biller> billerRepository,

                IGenericRepository<LevelDisplayName> levelDisplayNameRepository, IGenericRepository<Pos> posRespository, IGenericRepository<User> userRepository, IMapper mapper)
            {
                _responseCode = responseCode.Value;

                _webCallService = webCallService;

                _webEndpoint = webEndpoint.Value;

                _levelOneRepository = levelOneRepository;

                _billerRepository = billerRepository;

                _levelDisplayNameRepository = levelDisplayNameRepository;

                _posRespository = posRespository;

                _userRepository = userRepository;

                _mapper = mapper;
            }

            public async Task<SuccessfulResponse> Handle(PosLoginCommand request, CancellationToken cancellationToken)
            {
                //auto mapper

                var posDetail = _posRespository.FindFirst(x => x.ReferenceKey == request.posLoginDto.PosId);

                if (posDetail == null)
                
                    return ResponseGenerator.Response("Invalid pos Id", _responseCode.NotFound, false);
                

                if (!posDetail.IsActive)
                
                    return ResponseGenerator.Response("Pos is not activated", _responseCode.NotAccepted, false);
                

                if (posDetail.IsLogin)
                
                    return ResponseGenerator.Response("User already login on this pos", _responseCode.NotAccepted, false);
                

                User userDetail = await SsoUserLogin(request);

                if (userDetail == null)
                
                    return ResponseGenerator.Response("User not found", _responseCode.NotFound, false);
                

                if (! userDetail.IsActive)
                
                    return ResponseGenerator.Response("User not active", _responseCode.NotAccepted, false);
                

                var userLoginCheck = _posRespository.FindFirst(x => x.UserId == userDetail.Id);

                if (userLoginCheck != null)
                
                    return ResponseGenerator.Response("User already login in another pos", _responseCode.NotAccepted, false);
                

                await UpdatePos(posDetail, userDetail);

                var loginResponse = GetLoginResponse(request, userDetail);

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, loginResponse);
            }

            private PosLoginResponseDto GetLoginResponse(PosLoginCommand request, User user)
            {
                var biller = _billerRepository.FindFirst(x => x.ReferenceKey == request.posLoginDto.BillerId);

                var billerListOfLevelOne = _levelOneRepository.Find(x => x.BillerId == biller.Id).ToList().Select(_mapper.Map<LevelOne, PosLoginResponseDto.LevelOneParameter>);

                var levelOneDisplayName = _levelDisplayNameRepository.FindFirst(x => x.BillerId == biller.Id).LevelOneDisplayName;

                var loginResponse = new PosLoginResponseDto
                {
                    BillerId = request.posLoginDto.BillerId,

                    PosId = request.posLoginDto.PosId,

                    UserId = user.ReferenceKey,

                    IsPosRemitter = user.RoleId == 6,

                    LevelOneDisplayName = levelOneDisplayName,

                    LevelOne = billerListOfLevelOne
                };

                return loginResponse;
            }

            private async Task UpdatePos(Pos posDetail, User userDetail)
            {
                posDetail.IsLogin = true;

                posDetail.UserId = userDetail.Id;

                _posRespository.Update(posDetail);

                await _posRespository.CommitAsync();
            }

            private async Task<User> SsoUserLogin(PosLoginCommand request)
            {
                var userRequest = new
                {
                    username = request.posLoginDto.Email,

                    password = request.posLoginDto.Password
                };

                var userRequestJson = JsonConvert.SerializeObject(userRequest);

                var ssoResponseString = await _webCallService.PostDataCall(_webEndpoint.SsoUserLogin, userRequestJson);

                var ssoUserDetails = JsonXmlObjectConverter.Deserialize<SsoLoginDto>(ssoResponseString);

                var userDetail = await _userRepository.FindSingleInclude(x => x.SsoId == ssoUserDetails.id, x=> x.Role);

                return userDetail;
            }
        }
    }
}
