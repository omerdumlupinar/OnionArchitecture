using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Context
{
    public class OnionArchitecture_Context:DbContext
    {
        public const string DEFAULT_SHEMA = "dbo";

        public OnionArchitecture_Context()
        {
                
        }

        public OnionArchitecture_Context(DbContextOptions options):base(options)
        {
                
        }

        public DbSet<Category> MyProperty { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connstr = "";
                optionsBuilder.UseSqlServer(connstr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            }
        }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }


        private void OnBeforeSave()
        {
            var entities = ChangeTracker.Entries()
                                       .Where(i => i.State == EntityState.Added || i.State == EntityState.Modified)
                                       .Select(i => (BaseEntity)i.Entity);

            if (entities.Any())
            {
                PrepareEntities(entities);
            }
        }

        private void PrepareEntities(IEnumerable<BaseEntity> baseEntities)
        {
            foreach (var entity in baseEntities)
            {
                if (entity.CreateDate == DateTime.MinValue)
                {
                    entity.CreateDate = DateTime.UtcNow;
                    entity.UpdateDate = DateTime.UtcNow;
                }

                if (entity.UpdateDate < entity.CreateDate)
                {
                    entity.UpdateDate = DateTime.UtcNow;
                }
            }
        }
    }
}
