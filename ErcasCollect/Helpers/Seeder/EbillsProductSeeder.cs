using ErcasCollect.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Helpers.Seeder
{
    public static class EbillsProductSeeder
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<EbillsProduct>().HasData(
                
                    new EbillsProduct() { Id = 1, ProductName = "Remittance" },

                    new EbillsProduct() { Id = 2, ProductName = "Tax" },

                    new EbillsProduct() { Id = 3, ProductName = "Non-Tax" },

                    new EbillsProduct() { Id = 4, ProductName = "Invoice" }
                );
        }
    }
}