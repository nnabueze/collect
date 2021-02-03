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

                    new Role() { Id = 1, Name = "SuperAdmin", Description ="Has all the right to the system eg HQ" },

                    new Role() { Id = 2, Name = "Admin", Description = "Biller Admin previllages" },

                    new Role() { Id = 3, Name = "LevelOne", Description = "Views all the report under Mda" },

                    new Role() { Id = 4, Name = "LevelTwo", Description = "Views all the report under station" },

                    new Role() { Id = 5, Name = "PosCollector", Description = "Pos agents that only collect" },

                    new Role() { Id = 6, Name = "PosRemitter", Description = "Pos agents that collect and remit" }
                );
        }
    }
}
