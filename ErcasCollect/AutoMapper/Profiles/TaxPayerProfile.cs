using System;
using AutoMapper;
using ErcasCollect.Commands.Dto.TaxpayerDto;
using ErcasCollect.Domain.Models;
using ErcasCollect.Queries.Dto;

namespace ErcasCollect.AutoMapper.Profiles
{
    public class TaxPayerProfile:Profile
    {
        public TaxPayerProfile()
        {

            CreateMap<CreateTaxpayerDto, TaxPayer>().ReverseMap();
            CreateMap<ReadTaxPayerDto, TaxPayer>().ReverseMap();
        }
    }
}
