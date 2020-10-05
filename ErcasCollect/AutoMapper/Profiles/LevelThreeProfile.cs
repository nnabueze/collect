using System;
using AutoMapper;
using ErcasCollect.Commands.Dto.LevelThreeDto;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {

            CreateMap<CreateLevelThreeDto, LevelThree>().ReverseMap();
        }
    }
}


