using ErcasCollect.Domain.Interfaces;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.DataAccess.Repository
{
    public class PosRepository : GenericRepository<Pos>, IPosRepository
    {
        public PosRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
