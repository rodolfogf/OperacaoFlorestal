using Microsoft.EntityFrameworkCore;
using OperacaoFlorestal.Models;

namespace OperacaoFlorestal.Data
{
    public class OperacaoFlorestalContext : DbContext
    {
        public OperacaoFlorestalContext(DbContextOptions<OperacaoFlorestalContext> options) : base(options)
        {
        }

        public DbSet<VooVant> VooVants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VooVant>(vooVant =>
            {
                vooVant.HasKey(e => e.Id);
                vooVant.Property(e => e.TipoVoo).IsRequired();
                vooVant.Property(e => e.IdMaquinario).IsRequired();
            });
        }
    }
}
