using System;
using AutoMapper;
using ErcasCollect.Commands.Dto.BillerDto;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class BillerProfile:Profile
    {
        public BillerProfile()
        {
            CreateMap<CreateBillerDto, Biller>().ReverseMap();
            CreateMap<ReadBillerDto, Biller>().ReverseMap();
            CreateMap<ReadBillerDto, State>().ReverseMap();
            CreateMap<AddBankDto, BankDetail>().ReverseMap();
            CreateMap<AddTinDto, BillerTINDetail>().ReverseMap();





        }
    }
}
