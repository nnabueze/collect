using System;
using AutoMapper;
using ErcasCollect.Commands.Dto.UserDto;
using ErcasCollect.Domain.Models;
using ErcasCollect.Queries.Dto;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<ReadUserDto, User>().ReverseMap();
            CreateMap<ReadUserDto, Role>().ReverseMap();
        }
    }
}
