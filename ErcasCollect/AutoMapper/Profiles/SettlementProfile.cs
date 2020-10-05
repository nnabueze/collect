using System;
using AutoMapper;
using ErcasCollect.Commands.Dto.SettlementDto;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class SettlementProfile : Profile
    {
        public SettlementProfile()
        {

            CreateMap<CreateSettlementDto, Settlement>().ReverseMap();
        }
    }
}
