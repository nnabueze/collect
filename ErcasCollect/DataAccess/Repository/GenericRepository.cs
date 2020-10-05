using ErcasCollect.DataAccess;
using ErcasCollect.Domain.BaseEntities;
using ErcasCollect.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext context;
        private DbSet<T> entities;
        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public void Delete(string id)
        {
            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {

            return await entities.ToListAsync();
        }

        public async Task<T> GetById(string  id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            context.SaveChanges();
        }

        private void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }
    }




    public class GenericTransactionRepository<T> : IGenericTransactionRepository<T> where T : TransactionBaseEntity
    {
        protected readonly ApplicationDbContext context;
        private DbSet<T> entities;
        public GenericTransactionRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public void Delete(string id)
        {
            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {

            return await entities.ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            context.SaveChanges();
        }

   
    }
}
