using System;
using AutoMapper;
using ErcasCollect.Commands.Dto.PosDto;
using ErcasCollect.Domain.Models;
using ErcasCollect.Queries.Dto;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class PosProfile : Profile
    {
        public PosProfile()
        {
            CreateMap<ReadPosDto, Pos>().ReverseMap();
        }
    }
}
