using System;
using AutoMapper;
using ErcasCollect.Commands.Dto.LevelThreeDto;
using ErcasCollect.Domain.Models;
using ErcasCollect.Queries.Dto;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {

            //CreateMap<CreateLevelThreeDto, LevelThree>().ReverseMap();
            //CreateMap<ReadLevelThreeDto, LevelThree>().ReverseMap();

        }
    }
}


