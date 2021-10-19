using System;
using System.Threading.Tasks;
using DemoConfiTec.Data.Context;

namespace DemoConfiTec.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DemoDbContext _context;

        public UnitOfWork(DemoDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            var result = 0;

            if (_context.Database.CurrentTransaction != null)
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    await _context.Database.CommitTransactionAsync();
                    result = 1;
                }
                catch (Exception e)
                {
                    await _context.Database.RollbackTransactionAsync();
                    Console.WriteLine(e);
                }
            }
            else
            {
                result = await _context.SaveChangesAsync();
            }

            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}