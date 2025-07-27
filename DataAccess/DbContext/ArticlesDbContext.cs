using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContext
{
    public class ArticlesDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ArticlesDbContext(DbContextOptions<ArticlesDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(Guid) && property.IsPrimaryKey())
                    {
                        property.SetDefaultValueSql("NewID()");
                    }
                }
            }
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Articles> Articles { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<ArticlesCategories> ArticlesCategories { get; set; }
    }
}
