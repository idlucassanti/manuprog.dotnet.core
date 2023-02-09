using Microsoft.EntityFrameworkCore;
using MP.Core.Domain.Entities;

namespace MP.Core.Infra.Data.Context
{
    public class MpDbContext : DbContext
    {
        public MpDbContext(DbContextOptions<MpDbContext> options)
            :base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MpDbContext).Assembly);
        }
    }
}
