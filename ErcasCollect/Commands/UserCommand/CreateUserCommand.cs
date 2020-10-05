using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.UserDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using MediatR;

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

                User user = mapper.Map<User>(request.createUserDto);
                await userRepository.Insert(user);

                return user.Id;
            }
        }
    }
}
