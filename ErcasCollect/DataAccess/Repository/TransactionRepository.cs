using System;

using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.DataAccess.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {

        public TransactionRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
