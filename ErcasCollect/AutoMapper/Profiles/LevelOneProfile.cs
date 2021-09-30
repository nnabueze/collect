



using System;
using AutoMapper;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Commands.Dto.LevelOneDto;
using ErcasCollect.Domain.Models;
using ErcasCollect.Queries.Dto;
using static ErcasCollect.Commands.Dto.CategoryOneDto.CategoryOneResponseDto;
using static ErcasCollect.Commands.Dto.CategoryTwoDto.CategoryTwoResponseDto;
using static ErcasCollect.Commands.Dto.LevelOneDto.LevelOneResponseDto;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class BranchProfile:Profile
    {
        public BranchProfile()
        {

            CreateMap<CreateLevelOneDto, LevelOne>().ReverseMap();

            CreateMap<ReadLevelOneDto, LevelOne>().ReverseMap();

            CreateMap<LevelOne, PosLoginResponseDto.LevelOneParameter>();

            CreateMap<LevelOne, LevelOneItem>();

            CreateMap<CategoryOneService, CategoryOneItem>();

            CreateMap<CategoryTwoService, CategoryTwoItem>();

        }
    }
}
