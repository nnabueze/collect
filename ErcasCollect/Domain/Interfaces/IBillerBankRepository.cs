using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Domain.Interfaces
{
    public interface IBillerBankRepository
    {
        Task<IEnumerable<BillerBankDetail>> GetAll();
        Task<BillerBankDetail> GetById(string id);
        Task Insert(BillerBankDetail entity);
        void Update(BillerBankDetail entity);
        void Delete(string id);

    }

}
