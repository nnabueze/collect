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

namespace ErcasCollect.Commands.UserCommand
{
    public class CreateUserCommand : IRequest<string>
    {
        public CreateUserDto createUserDto { get; set; }
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
        {
            private readonly IUserRepository userRepository;
            private readonly IMapper mapper;
            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                using (var client = new HttpClient())
                    {

                     client.BaseAddress = new Uri("http://155.93.117.250/");
                     client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                     client.DefaultRequestHeaders
                    .Accept
                     .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "sk_live_e1ee5fd989c97597e2f0431f09f8ccbacecbe215");



                      var result = client.PostAsync("/gateway/register", new
                     {
                          firstName= request.createUserDto.firstname,
                          lastName= request.createUserDto.lastname,
                          phone= request.createUserDto.phone,
                         email= request.createUserDto.email,
                         password= request.createUserDto.password,
                       passwordConfirmation= request.createUserDto.password

                      }, new JsonMediaTypeFormatter()).Result;

                     if (result.IsSuccessStatusCode)
                     {
                     var response = new HttpResponseMessage(HttpStatusCode.OK);
                     response.Content = new StringContent(result.Content.ReadAsStringAsync().Result, Encoding.UTF8, "application/json");
                     var content = await response.Content.ReadAsStringAsync();
                     var ItemsSet = JsonConvert.DeserializeObject<dynamic>(content);
                     if (ItemsSet["id"] != null)
                     {

                      request.createUserDto.SsoId = ItemsSet["id"];
                      request.createUserDto.Name = request.createUserDto.lastname +" "+ request.createUserDto.firstname;
                      User user = mapper.Map<User>(request.createUserDto);
                      await userRepository.Add(user);
                      await userRepository.CommitAsync();

                       return user.Id;




                  }
                  else
                 {
                   return "Ok";
                 }
                }
               else
               {
                 return "Bad";
              }

            }
        }
          
            
        }
    }
}
