using System;
using System.Collections.Generic;

using AutoMapper;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class TransactionProfile:Profile
    {
        public TransactionProfile()
        {
            CreateMap<CreateCollectionComandDto, Transaction>().ReverseMap();
          
            CreateMap<SessionData, Transaction>().ReverseMap();
            CreateMap<SessionData, CreateCollectionComandDto>().ReverseMap();


        }
    }
}
