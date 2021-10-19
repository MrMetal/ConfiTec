using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DemoConfiTec.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
    {
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Remover(int id);
        Task<TEntity> ObterPorId(int id);
        Task<List<TEntity>> ObterTodos();
        
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}