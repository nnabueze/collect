using AutoMapper;
using ErcasCollect.Commands.Dto.CollectionDto;
using ErcasCollect.Domain.Models;
using System;
namespace ErcasCollect.AutoMapper.Profiles
{
    public class CollectionProfile :Profile
    {
        public CollectionProfile()
        {
            CreateMap<CategoryOneService, PosCategoryOneRespnse.CategoryOneParameter>();

            CreateMap<CategoryTwoService, PosCategoryTwoRespnse.CategoryTwoParameter>();
        }
    }
}
