using DemoConfiTec.Data.Context;
using DemoConfiTec.Domain.Interfaces.Repository;
using DemoConfiTec.Domain.Models;

namespace DemoConfiTec.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DemoDbContext db) : base(db)
        {
        }
    }
}