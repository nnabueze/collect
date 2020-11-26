﻿using System;
using AutoMapper;
using ErcasCollect.Commands.Dto.LevelTwoDto;
using ErcasCollect.Domain.Models;
using ErcasCollect.Queries.Dto;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {

            CreateMap<CreateLevelTwoDto, LevelTwo>().ReverseMap();
            CreateMap<ReadLevelTwoDto, LevelTwo>().ReverseMap();
        }
    }
}
