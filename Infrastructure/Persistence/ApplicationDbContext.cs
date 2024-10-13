using Examen.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Examen.Core.Domain.Entity;

namespace Examen.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Chofer> Choferes { get; set; }
        public DbSet<Taxi> Taxis { get; set; }

        public DbSet<Accesorio> Accesorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<Menu>().HasQueryFilter(e => !e.IsDeleted);*/
            base.OnModelCreating(modelBuilder);
        }
    }
}
