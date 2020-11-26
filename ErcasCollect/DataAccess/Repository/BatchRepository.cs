using System;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.DataAccess.Repository
{
    public class BatchRepository:GenericRepository<Batch>,IBatchRepository
    {


        public BatchRepository(ApplicationDbContext context)
            : base(context)
    {

    }
}
}
