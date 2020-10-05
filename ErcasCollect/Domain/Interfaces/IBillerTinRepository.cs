using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Domain.Interfaces
{
    public interface IBillerTinRepository 
    {
        Task<IEnumerable<BillerTINDetail>> GetAll();
        Task<BillerTINDetail> GetById(string id);
        Task Insert(BillerTINDetail entity);
        void Update(BillerTINDetail entity);
        void Delete(string id);
    }
}
