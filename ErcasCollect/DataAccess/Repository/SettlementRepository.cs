using System;

using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.DataAccess.Repository
{
    public class SettlementRepository : GenericTransactionRepository<Settlement>, ISettlementRepository
    {
        public SettlementRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
