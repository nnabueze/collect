using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ErcasCollect.DataAccess.Repository
{
    public class BillerTinRepository :  IBillerTinRepository
    {
        protected readonly ApplicationDbContext context;
        private DbSet<BillerTINDetail> entities;
        public BillerTinRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<BillerTINDetail>();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BillerTINDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BillerTINDetail> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(BillerTINDetail entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public void Update(BillerTINDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
