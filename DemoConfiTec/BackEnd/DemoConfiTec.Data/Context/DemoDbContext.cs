using System.Linq;
using DemoConfiTec.Data.Mapping;
using DemoConfiTec.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoConfiTec.Data.Context
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext()
        {
            
        }

        public DemoDbContext(DbContextOptions<DemoDbContext> options): base(options)
        {
            
        }

        private DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Mapeamento Fluent API

            modelBuilder.ApplyConfiguration(new UsuarioMap());

            #endregion

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
                modelBuilder.Entity(entity.Name).Property("Id").HasColumnName(entity.GetTableName() + "Id");
            
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}