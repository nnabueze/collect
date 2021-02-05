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
    public class GetAllUserByBillerQuery : IRequest<SuccessfulResponse>
    {

        public string _billerId { get; set; }

        public GetAllUserByBillerQuery(string billerId)
        {
            _billerId = billerId;
        }
        public class GetAllUserByBillerHandler : IRequestHandler<GetAllUserByBillerQuery, SuccessfulResponse>
        {
            private readonly IGenericRepository<User> _userRepository;

            private readonly IMapper mapper;

            private readonly ResponseCode responsesCode;

            private readonly IGenericRepository<Biller> _billerRepository;

            private readonly IGenericRepository<LevelDisplayName> _levelDisplayNameRepository;

            private readonly IGenericRepository<Role> _roleRepository;

            public GetAllUserByBillerHandler(IGenericRepository<User> userRepository, IMapper mapper, IOptions<ResponseCode> responsesCode, IGenericRepository<Biller> billerRepository,

                IGenericRepository<LevelDisplayName> levelDisplayNameRepository, IGenericRepository<Role> roleRepository)
            {
                _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

                this.responsesCode = responsesCode.Value;

                _billerRepository = billerRepository;

                _levelDisplayNameRepository = levelDisplayNameRepository;

                _roleRepository = roleRepository;
            }

            public async Task<SuccessfulResponse> Handle(GetAllUserByBillerQuery query, CancellationToken cancellationToken)
            {
                List<UserResponseDto> userList = new List<UserResponseDto>();

                var biller = await _billerRepository.FindSingleInclude(x => x.ReferenceKey == query._billerId, x => x.Users, x => x.LevelOne, x => x.LevelTwo);

                if (biller == null)

                    return ResponseGenerator.Response("Invalid biller Id", responsesCode.NotFound, false);

                foreach (var item in biller.Users)
                {
                    if (item.IsActive)
                    {
                        var userDetails = new UserResponseDto()
                        {
                            BillerName = item.Name,

                            LevelOneName = item.LevelOne.Name,

                            LevelTwoName = item.LevelTwo.Name,

                            CollectionLimit = item.CollectionLimit.ToString(),

                            Name = item.Name,

                            IsActive = item.IsActive,

                            PhoneNumber = item.PhoneNumber,

                            ReferenceKey = item.ReferenceKey,

                            Role = GetRoleName((int)item.RoleId)
                        };

                        userList.Add(userDetails);
                    }
                }

                var users = new BillerUserResposeDto()
                {
                    LevelOneDisplayName = GetLevelDisplayName(biller.Id).LevelOneDisplayName,

                    LevelTwoDisplayName = GetLevelDisplayName(biller.Id).LevelTwoDisplayName,

                    Users = userList
                };

                return ResponseGenerator.Response("Successful", responsesCode.OK, true, users);

            }

            private string GetRoleName(int roleId)
            {
                var role = _roleRepository.FindFirst(x => x.Id == roleId);

                if (role == null)

                    return null;

                return role.Name;
            }

            private LevelDisplayName GetLevelDisplayName(int billerId)
            {
                return _levelDisplayNameRepository.FindFirst(X => X.BillerId == billerId);
            }

        }
    }
}

