using System;
using AutoMapper;
using ErcasCollect.Commands.Dto.UserDto;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<CreateUserDto, User>().ReverseMap();
        }
    }
}
