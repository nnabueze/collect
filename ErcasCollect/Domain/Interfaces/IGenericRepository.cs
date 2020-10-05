
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErcasCollect.Domain.BaseEntities;

namespace ErcasCollect.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task Insert(T entity);
        void Update(T entity);
        void Delete(string id);

    }

    public interface IGenericTransactionRepository<T> where T : TransactionBaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task Insert(T entity);
        void Update(T entity);
        void Delete(string id);

    }
}