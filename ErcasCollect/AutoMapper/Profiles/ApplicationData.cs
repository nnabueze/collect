using System;
using AutoMapper;
using ErcasCollect.Domain.Models;
using ErcasCollect.Queries.Dto;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class ApplicationData:Profile
    {
        public ApplicationData()
        {
            CreateMap<ReadStatusDto, Status>().ReverseMap();
            CreateMap<ReadAllBanksDto, Bank>().ReverseMap();
            CreateMap<ReadPaymentChannelDto, PaymentChannel>().ReverseMap();
            CreateMap<ReadStatusDto, Status>().ReverseMap();
            CreateMap<ReadAllTransactionTypes, TransactionType >().ReverseMap();

        }
    }
}
