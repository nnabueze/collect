using ErcasCollect.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Helpers.Seeder
{
    public static class PaymentChannelSeeder
    {
        public static void PaymentChannelSeed(this ModelBuilder builder)
        {
            builder.Entity<PaymentChannel>().HasData(

                    new PaymentChannel() { Id = 1, Name = "Pos" },

                    new PaymentChannel() { Id = 2, Name = "Nibss" },

                    new PaymentChannel() { Id = 3, Name = "Flex" }
                );
        }
    }
}
