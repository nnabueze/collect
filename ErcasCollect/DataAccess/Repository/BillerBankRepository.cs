using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ErcasCollect.DataAccess.Repository
{
    public class BillerBankRepository :  IBillerBankRepository
    {


        protected readonly ApplicationDbContext context;
        private DbSet<BankDetail> entities;
        public BillerBankRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<BankDetail>();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BankDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BankDetail> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(BankDetail entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            await  entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public void Update(BankDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
