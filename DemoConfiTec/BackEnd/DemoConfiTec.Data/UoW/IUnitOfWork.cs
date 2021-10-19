using System;
using System.Threading.Tasks;

namespace DemoConfiTec.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}