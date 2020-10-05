using System;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.DataAccess.Repository
{
    public class LevelTwoRepository:GenericRepository<LevelTwo>,ILevelTwoRepository
    {
        public LevelTwoRepository(ApplicationDbContext context)
            : base(context)
    {

    }
}
}
