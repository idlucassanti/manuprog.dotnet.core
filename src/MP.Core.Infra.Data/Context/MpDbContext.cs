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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MpDbContext).Assembly);
        }
    }
}
