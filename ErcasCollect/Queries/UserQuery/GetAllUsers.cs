using System;
using System.Collections.Generic;
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
    public class GetAllUsersQuery : IRequest<SuccessfulResponse>
    {


        public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, SuccessfulResponse>
        {

            private readonly IMapper mapper;

            private readonly IGenericRepository<User> _userRepository;

            private readonly ResponseCode _responseCode;

            public GetAllUsersHandler( IMapper mapper, IGenericRepository<User> userRepository, IOptions<ResponseCode> responseCode)
            {

                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

                _userRepository = userRepository;

                _responseCode = responseCode.Value;
            }

            public async Task<SuccessfulResponse> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {
                List<UserResponseDto> userList = new List<UserResponseDto>();

                var users = await _userRepository.GetAll();

                if (users == null)

                    return ResponseGenerator.Response("User not found", _responseCode.NotFound, false);

                foreach (var item in users)
                {
                    var user = await GetUserDetails(item.Id);

                    var userDetails = new UserResponseDto()
                    {
                        BillerName = user.Biller.Name,

                        LevelOneName = user.LevelOne.Name,

                        LevelTwoName = user.LevelTwo.Name,

                        CollectionLimit = item.CollectionLimit.ToString(),

                        Name = item.Name,

                        IsActive = item.IsActive,

                        PhoneNumber = item.PhoneNumber,

                        ReferenceKey = item.ReferenceKey,

                        Role = user.Role.Name
                    };

                    userList.Add(userDetails);
                }

                return ResponseGenerator.Response("Successful", _responseCode.OK, true, userList);

            }

            private async Task<User> GetUserDetails(int userId)
            {
                return await _userRepository.FindSingleInclude(x => x.Id == userId, x => x.Biller, x => x.LevelOne, x => x.LevelTwo, x => x.Role);
            }


        }
    }
}

