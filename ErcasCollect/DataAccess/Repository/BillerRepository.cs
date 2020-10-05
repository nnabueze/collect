using System;
using System.Threading.Tasks;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace ErcasCollect.DataAccess.Repository
{
    public class BillerRepository: GenericRepository<Biller>,IBillerRepository
    {


        public BillerRepository(ApplicationDbContext context)
            : base(context)
        {
          
        }

    

    }
}
