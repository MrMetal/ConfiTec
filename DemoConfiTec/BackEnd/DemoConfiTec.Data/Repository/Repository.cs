

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DemoConfiTec.Data.Context;
using DemoConfiTec.Domain.Interfaces;
using DemoConfiTec.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoConfiTec.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly DemoDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DemoDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async void Adicionar(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual void Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Remover(int id)
        {
            DbSet.Remove(new TEntity { Id = id });
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await DbSet.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}