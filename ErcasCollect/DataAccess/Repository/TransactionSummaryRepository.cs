using System;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.DataAccess.Repository
{
    public class TransactionSummaryRepository : GenericRepository<TransactionSummaryView>, ITransactionSummaryRepository
    {

        public TransactionSummaryRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
