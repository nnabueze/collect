using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Domain.Interfaces
{
    public interface IBillerBankRepository
    {
        Task<IEnumerable<BankDetail>> GetAll();
        Task<BankDetail> GetById(string id);
        Task Insert(BankDetail entity);
        void Update(BankDetail entity);
        void Delete(string id);

    }

}
