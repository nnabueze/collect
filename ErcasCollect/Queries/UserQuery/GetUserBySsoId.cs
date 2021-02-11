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
    public class GetUserBySsoIDQuery : IRequest<SuccessfulResponse>
    {
        public int _userId { get; set; }

        public GetUserBySsoIDQuery(int userId)
        {
            _userId = userId;
        }

        public class GetUserBySsoIDHandler : IRequestHandler<GetUserBySsoIDQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<User> _userRepository;

            private readonly IMapper mapper;

            private readonly ResponseCode responsesCode;

            public GetUserBySsoIDHandler(IGenericRepository<User> userRepository, IMapper mapper, IOptions<ResponseCode> responsesCode)
            {
                _userRepository = userRepository;

                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

                this.responsesCode = responsesCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(GetUserBySsoIDQuery query, CancellationToken cancellationToken)
            {

                var user = await _userRepository.FindSingleInclude(x => x.SsoId == query._userId, x => x.Biller, x => x.LevelOne, x => x.LevelTwo, x => x.Role);

                if (user == null)

                    ResponseGenerator.Response("No User found", responsesCode.NotFound, false);

                if(! user.IsActive && user.IsDeleted)

                    ResponseGenerator.Response("User not active", responsesCode.NotFound, false);

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

                    Role = user.Role.Name, 

                    LevelOneId = user.LevelOne.ReferenceKey,

                    LevelTwoId = user.LevelTwo.ReferenceKey,

                    BillerId = user.Biller.ReferenceKey
                };

                return ResponseGenerator.Response("Successful", responsesCode.OK, true, userDetails);

            }


        }
    }
}

