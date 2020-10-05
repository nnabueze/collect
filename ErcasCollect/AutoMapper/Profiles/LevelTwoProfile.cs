using System;
using AutoMapper;
using ErcasCollect.Commands.Dto.LevelTwoDto;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {

            CreateMap<CreateLevelTwoDto, LevelTwo>().ReverseMap();
        }
    }
}
