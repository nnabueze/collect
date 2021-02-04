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
            public Task<SuccessfulResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
