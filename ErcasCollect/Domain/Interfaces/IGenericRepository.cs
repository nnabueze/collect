
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Interfaces
{
    public interface IGenericRepository<T> where T :  class, new()
    {
         
        Task<IEnumerable<T>> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAll();
        Task<int> Count();
        Task<T> GetSingle(Expression<Func<T, bool>> predicate);
        Task<T> GetLastAsync(Expression<Func<T, bool>> predicate);
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        public IEnumerable<T> FindAllEnumerable();
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> FindAllInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> FindSingleInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task<List<T>> Add(List<T> entity);
        void Update(T entity);
        T FindFirst(Expression<Func<T, bool>> predicate);
        void UndoAdd(T entity);
        Task UndoAdd(List<T> entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        Task CommitAsync();
    

}

    public interface IGenericTransactionRepository<T> where T : TransactionBaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T entity);
        void Update(T entity);
        void Delete(int id);

    }
}