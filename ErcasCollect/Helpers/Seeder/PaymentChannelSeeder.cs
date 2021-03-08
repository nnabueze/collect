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


            builder.Entity<PaymentProcessor>().HasData(

                    new PaymentProcessor() { Id = 1, Name = "Pos" },

                    new PaymentProcessor() { Id = 2, Name = "Nibss" },

                    new PaymentProcessor() { Id = 3, Name = "Interswitch" },

                    new PaymentProcessor() { Id = 4, Name = "Remitta" },

                    new PaymentProcessor() { Id = 5, Name = "PayStack" }
                );


        }
    }
}
