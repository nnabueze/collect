using ErcasCollect.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Helpers.Seeder
{
    public static class TransactionTypeSeeder
    {
        public static void TransactionTypeSeed(this ModelBuilder builder)
        {
            builder.Entity<TransactionType>().HasData(

                    new TransactionType() { Id = 1, Name = "Collection" },
                    new TransactionType() { Id = 2, Name = "Remittance" },
                    new TransactionType() { Id = 3, Name = "Tax" },
                    new TransactionType() { Id = 4, Name = "Invoice" },
                    new TransactionType() { Id = 5, Name = "NonTax" },
                    new TransactionType() { Id = 6, Name = "Card" }
                );
        }
    }
}
