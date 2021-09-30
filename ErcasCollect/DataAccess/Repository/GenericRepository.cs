using ErcasCollect.DataAccess;
using ErcasCollect.Domain.BaseEntities;
using ErcasCollect.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ErcasCollect.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            return entity;
        }

        public IEnumerable<T> FindAllEnumerable()
        {
            return _context.Set<T>();
        }

        public T FirstOrDefault()
        {
            return _context.Set<T>().FirstOrDefault();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual async Task<List<T>> Add(List<T> entity)
        {
            foreach (var item in entity)
            {
                await _context.Set<T>().AddAsync(item);
            }

            return entity;
        }

        public virtual async Task<IEnumerable<T>> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            return await FindAllIncluding(includeProperties).ToListAsync();
        }

        public virtual IQueryable<T> FindAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return (IQueryable<T>)query.AsEnumerable();
        }

        public virtual async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual void UndoAdd(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
            //await _context.Remove();
        }

        public virtual async Task UndoAdd(List<T> entity)
        {
            foreach (var item in entity)
            {
                EntityEntry dbEntityEntry = _context.Entry<T>(item);
                dbEntityEntry.State = EntityState.Deleted;
            }
        }

        public virtual async Task<int> Count()
        {
            return await _context.Set<T>().CountAsync();
        }

        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

        public virtual async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await FindAllWhere(predicate).ToListAsync();
        }

        public virtual IQueryable<T> FindAllWhere(Expression<Func<T, bool>> predicate)
        {
            return (IQueryable<T>)_context.Set<T>().Where(predicate);
        }

        public virtual async Task<T> GetLastAsync(Expression<Func<T, bool>> predicate)
        {
            //return await FindLast(predicate).SingleAsync();
            return _context.Set<T>().Where(predicate).AsEnumerable().LastOrDefault();
            //return await FindLast(predicate).LastOrDefaultAsync();
        }

        public virtual IQueryable<T> FindLast(Expression<Func<T, bool>> predicate)
        {
            return (IQueryable<T>)_context.Set<T>().Where(predicate).AsEnumerable().LastOrDefault();
            //return (IQueryable<T>)_context.Set<T>().Where(predicate).AsAsyncEnumerable();
            //return await _context.Set<T>().Where(predicate).LastOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await FindAll().ToListAsync();
        }

        public virtual IQueryable<T> FindAll()
        {
            return (IQueryable<T>)_context.Set<T>().AsEnumerable();
        }

        public virtual Task<T> GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<T>> FindAllInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {

            return await GetAllInclude(predicate, includeProperties).ToListAsync();
        }

        public virtual IQueryable<T> GetAllInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return (IQueryable<T>)query.Where(predicate);
        }

        public virtual async Task<T> FindSingleInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(predicate).FirstOrDefaultAsync();
            //return await GetAllInclude(predicate, includeProperties).AnyAsync();
        }

        public virtual async Task<T> GetSingleIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(predicate).FirstAsync();
        }

        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual T FindFirst(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
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
        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {

            return await entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
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