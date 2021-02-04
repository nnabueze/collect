using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using System.Net.Http.Formatting;
using ErcasCollect.Commands.Dto.UserDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;
using Newtonsoft.Json;
using ErcasCollect.Helpers;
using Microsoft.Extensions.Options;
using ErcasCollect.Responses;

namespace ErcasCollect.Commands.UserCommand
{
    public class CreateUserCommand : IRequest<SuccessfulResponse>
    {
        public CreateUserDto createUserDto { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, SuccessfulResponse>
        {
            private readonly IGenericRepository<User> _userRepository;

            private readonly NameConstant _nameConstant;

            private readonly ResponseCode _responseCode;

            private readonly IWebCallService _webCallService;

            public CreateUserCommandHandler(IGenericRepository<User> userRepository, IOptions<NameConstant> nameConstant, IOptions<ResponseCode> responseCode, IWebCallService webCallService)
            {
                _userRepository = userRepository;

                _nameConstant = nameConstant.Value;

                _responseCode = responseCode.Value;

                _webCallService = webCallService;
            }

            public Task<SuccessfulResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                return null;
            }

            //private async Task<User> SsoUserLogin(PosLoginCommand request)
            //{
            //    var userRequest = new
            //    {
            //        username = request.posLoginDto.Email,

            //        password = request.posLoginDto.Password
            //    };

            //    var userRequestJson = JsonConvert.SerializeObject(userRequest);

            //    var ssoResponseString = await _webCallService.PostDataCall(_webEndpoint.SsoUserLogin, userRequestJson);

            //    var ssoUserDetails = JsonXmlObjectConverter.Deserialize<SsoLoginDto>(ssoResponseString);

            //    var userDetail = await _userRepository.FindSingleInclude(x => x.SsoId == ssoUserDetails.id, x => x.Role);

            //    return userDetail;
            //}
        }
    }
}
