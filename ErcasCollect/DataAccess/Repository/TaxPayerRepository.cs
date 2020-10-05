using System;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.DataAccess.Repository
{
    public class TaxPayerRepository : GenericRepository<TaxPayer>, ITaxPayerRepository
    {


        public TaxPayerRepository(ApplicationDbContext context)
            : base(context)
        {

        }

    }
}
