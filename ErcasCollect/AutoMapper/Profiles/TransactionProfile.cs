using System;
using System.Collections.Generic;

using AutoMapper;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Commands.Dto.SettlementDto;
using ErcasCollect.Domain.Models;
using ErcasCollect.Domain.Models.SqlViewModels;
using ErcasCollect.Queries.Dto;
using ErcasCollect.Queries.Dto.ReadTransactionDto;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class TransactionProfile:Profile
    {
        public TransactionProfile()
        {
            CreateMap<SettlementCollectionComandDto, Transaction>().ReverseMap();
          
            CreateMap<SessionData, Transaction>().ReverseMap();

            CreateMap<TransactionDetail, Transaction>().ReverseMap();
            CreateMap<ReadTransactionDto, Transaction>().ReverseMap();

            CreateMap<MonthlyTopPerformingBillers, MonthlyTopPerformingBillerDto>();


        }
    }
}
