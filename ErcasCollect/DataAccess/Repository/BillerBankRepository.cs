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
        private DbSet<BillerBankDetail> entities;
        public BillerBankRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<BillerBankDetail>();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BillerBankDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BillerBankDetail> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(BillerBankDetail entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            await  entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public void Update(BillerBankDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
