using System;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.DataAccess.Repository
{
    public class LevelOneRepository:GenericRepository<LevelOne>,ILevelOneRepository
    {
        public LevelOneRepository(ApplicationDbContext context)
            : base(context)
    {

    }
}
}
