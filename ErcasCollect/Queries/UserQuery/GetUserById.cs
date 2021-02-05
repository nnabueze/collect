using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Commands.Dto.UserDto;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using ErcasCollect.Helpers;
using ErcasCollect.Queries.Dto;
using ErcasCollect.Responses;
using MediatR;
using Microsoft.Extensions.Options;

namespace ErcasCollect.Queries.BillerQuery
{
    public class GetUserByIDQuery : IRequest<SuccessfulResponse>
    {
        private string _userId { get; set; }

        public GetUserByIDQuery(string userId)
        {
            _userId = userId;
        }

        public class GetUserByIDHandler : IRequestHandler<GetUserByIDQuery, SuccessfulResponse>
        {
            private readonly IMapper mapper;

            private IGenericRepository<User> _userRepository;

            private ResponseCode _responseCode;

            public GetUserByIDHandler(IGenericRepository<User> taxpayerRepository, IMapper mapper, IGenericRepository<User> userRepository, IOptions<ResponseCode> responseCode)
            {
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

                _userRepository = userRepository;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(GetUserByIDQuery query, CancellationToken cancellationToken)
            {

                var user = await _userRepository.FindSingleInclude(x => x.ReferenceKey == query._userId, x => x.Biller, x => x.LevelOne, x => x.LevelTwo, x => x.Role);

                if (user == null)

                    ResponseGenerator.Response("No User found", _responseCode.NotFound, false);

                var userDetails = new UserResponseDto()
                {
                    BillerName = user.Biller.Name,

                    LevelOneName = user.LevelOne.Name,

                    LevelTwoName = user.LevelTwo.Name,

                    CollectionLimit = user.CollectionLimit.ToString(),

                    Name = user.Name,

                    IsActive = user.IsActive,

                    PhoneNumber = user.PhoneNumber,

                    ReferenceKey = user.ReferenceKey,

                    Role = user.Role.Name
                };

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, userDetails);

            }


        }
    }
}

