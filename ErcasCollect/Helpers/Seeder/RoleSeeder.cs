using ErcasCollect.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Helpers.Seeder
{
    public static class RoleSeeder
    {
        public static void RoleSeed(this ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(

                    new Role() { Id = 1, Name = "BillerAdmin", Description = "Biller Admin previllages" },

                    new Role() { Id = 2, Name = "LevelOne", Description = "Views all the report under Mda" },

                    new Role() { Id = 3, Name = "LevelTwo", Description = "Views all the report under station" },

                    new Role() { Id = 4, Name = "PosCollector", Description = "Pos agents that only collect" },

                    new Role() { Id = 5, Name = "PosRemitter", Description = "Pos agents that collect and remit" }
                );
        }
    }
}
