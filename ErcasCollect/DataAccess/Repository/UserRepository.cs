using System;
using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.DataAccess.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {


        public UserRepository(ApplicationDbContext context)
            : base(context)
        {

        }

    }
}
