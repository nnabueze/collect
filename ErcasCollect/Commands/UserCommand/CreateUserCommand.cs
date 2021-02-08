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

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<LevelOne> _levelOneRepository;

            private readonly IGenericRepository<LevelTwo> _levelTwoRepository;

            private readonly NameConstant _nameConstant;

            private readonly ResponseCode _responseCode;

            private readonly IWebCallService _webCallService;

            private readonly WebEndpoint _webEndpoint;

            public CreateUserCommandHandler(IGenericRepository<User> userRepository, IOptions<NameConstant> nameConstant, IOptions<ResponseCode> responseCode,

                IWebCallService webCallService, IOptions<WebEndpoint> webEndpoint, IGenericRepository<Biller> billerRepository, IGenericRepository<LevelOne> levelOneRepository, 
                
                IGenericRepository<LevelTwo> levelTwoRepository)
            {
                _userRepository = userRepository;

                _nameConstant = nameConstant.Value;

                _responseCode = responseCode.Value;

                _webCallService = webCallService;

                _webEndpoint = webEndpoint.Value;

                _billerRepository = billerRepository;

                _levelOneRepository = levelOneRepository;

                _levelTwoRepository = levelTwoRepository;
            }

            public async Task<SuccessfulResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var ssoUser = await SsoUserCreate(request);

                if (ssoUser == null)

                    return ResponseGenerator.Response("Failed to create user on SSO", _responseCode.NotAccepted, false);

                var user = new User()
                {
                    BillerId = GetBillerId(request.createUserDto.BillerId),

                    CollectionLimit = request.createUserDto.CollectionLimit,

                    CreatedDate = DateTime.UtcNow,

                    IsActive = true,

                    LevelOneId = GetLevelOne(request.createUserDto.LevelOneId),

                    LevelTwoId = GetLevelTwo(request.createUserDto.LevelTwoId),

                    Name = GetName(request.createUserDto.firstname, request.createUserDto.lastname),

                    PhoneNumber = request.createUserDto.phone,

                    ReferenceKey = Helpers.IdGenerator.IdGenerator.RandomInt(15),

                    RoleId = request.createUserDto.RoleId,

                    SsoId = ssoUser.Id
                };

                var saveUser = await _userRepository.Add(user);

                await _userRepository.CommitAsync();

                try
                {
                    await SendMail(request);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message.ToString());
                }

                return ResponseGenerator.Response("Created", _responseCode.Created, true, new { UserId = saveUser.ReferenceKey });
            }

            private async Task SendMail(CreateUserCommand request)
            {
                var msg = "Hi "+request.createUserDto.firstname+". \r\n You have been created as a user in Ercas collect. Kindly find below your login credentials \r\n Username: " + request.createUserDto.email + "\r\n password: "

                    + request.createUserDto.password + "\r\n Login Url: https://collect.ercas.com.ng \r\n You are requested to change your password \n\n Thanks \n Ercas Team";

                var mailToSend = new
                {
                    to = request.createUserDto.email,

                    subject = "Login credentials",

                    message = msg
                };

                var mailToSendJson = JsonConvert.SerializeObject(mailToSend);

                await _webCallService.PostDataCall(_webEndpoint.Mail, mailToSendJson);

            }

            private string GetName(string firstName, string  lastName)
            {
                return firstName + " " + lastName;
            }

            private int GetLevelOne(string levelOneId)
            {
                return _levelOneRepository.FindFirst(x => x.ReferenceKey == levelOneId).Id;
            }

            private int GetLevelTwo(string levelTwoId)
            {
                return _levelTwoRepository.FindFirst(x => x.ReferenceKey == levelTwoId).Id;
            }


            private int GetBillerId(string billerId)
            {
                return _billerRepository.FindFirst(x => x.ReferenceKey == billerId).Id;
            }



            private async Task<SsoCreateUserResponseDto> SsoUserCreate(CreateUserCommand request)
            {
                var userRequest = new
                {
                    firstName = request.createUserDto.firstname,

                    lastName = request.createUserDto.lastname,

                    phone = request.createUserDto.phone,

                    email = request.createUserDto.email,

                    password = request.createUserDto.password,

                    passwordConfirmation = request.createUserDto.password

                };

                var userRequestJson = JsonConvert.SerializeObject(userRequest);

                var ssoResponseString = await _webCallService.PostDataCall(_webEndpoint.SsoUserCreate, userRequestJson);

                var ssoUserDetails = JsonXmlObjectConverter.Deserialize<SsoCreateUserResponseDto>(ssoResponseString);

                return ssoUserDetails;
            }
        }
    }
}
