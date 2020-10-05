using System;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.DataAccess.Repository
{
    public class LevelThreeRepository : GenericRepository<LevelThree>, ILevelThreeRepository
    {
        public LevelThreeRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
