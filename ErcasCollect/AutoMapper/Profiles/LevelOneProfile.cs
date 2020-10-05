



using System;
using AutoMapper;
using ErcasCollect.Commands.Dto.LevelOneDto;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class BranchProfile:Profile
    {
        public BranchProfile()
        {

            CreateMap<CreateLevelOneDto, LevelOne>().ReverseMap();
        }
    }
}
