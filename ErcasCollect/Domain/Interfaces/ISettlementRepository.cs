using System;
using ErcasCollect.DataAccess.Repository;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Domain.Interfaces
{
    public interface ISettlementRepository: IGenericTransactionRepository<Settlement>
    {

    }
}
