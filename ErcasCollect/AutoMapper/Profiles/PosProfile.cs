using System;
using AutoMapper;
using ErcasCollect.Commands.Dto.PosDto;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class PosProfile : Profile
    {
        public PosProfile()
        {

            CreateMap<CreatePosDto, Pos>().ReverseMap();
        }
    }
}
