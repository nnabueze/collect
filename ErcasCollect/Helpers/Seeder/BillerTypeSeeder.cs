using ErcasCollect.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Helpers.Seeder
{
    public static class BillerTypeSeeder
    {
        public static void BillerTypeSeed(this ModelBuilder builder)
        {
            builder.Entity<BillerType>().HasData(

                    new BillerType() { Id = 1, Category = "Igr" },
                    new BillerType() { Id = 2, Category = "School" },
                    new BillerType() { Id = 3, Category = "Hospital" },
                    new BillerType() { Id = 4, Category = "Store" }
                );
        }
    }
}
