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
            CreateMap<ReadAllStatesDto, State>().ReverseMap();
            CreateMap<ReadPaymentChannelDto, PaymentChannel>().ReverseMap();
            CreateMap<ReadAllBillerTypesDto, BillerType>().ReverseMap();
            CreateMap<ReadAllTransactionTypes, TransactionType >().ReverseMap();
            CreateMap<ReadAllRolesDto, Role>().ReverseMap();
            CreateMap<ReadAllOs, OS>().ReverseMap();
            CreateMap<ReadAllMetaDataDto, MetaData>().ReverseMap();

        }
    }
}
