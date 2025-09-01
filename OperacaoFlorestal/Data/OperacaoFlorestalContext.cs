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
        public DbSet<Maquinario> Maquinarios { get; set; }
        public DbSet<MaquinarioPesado> MaquinariosPesados { get; set; }
        public DbSet<MaquinarioVANT> MaquinariosVant { get; set; }
        public DbSet<DadoBrutoVant> DadosBrutosVant { get; set; }
        public DbSet<DadoBrutoMaquinario> DadosBrutosMaquinario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VooVant>(vooVant =>
            {
                vooVant.HasKey(e => e.Id);
                vooVant.Property(e => e.TipoVoo).IsRequired();
                vooVant.Property(e => e.IdMaquinario).IsRequired();

                vooVant.HasOne(e => e.Maquinario)
                       .WithMany(m => m.Voos)
                       .HasForeignKey(e => e.IdMaquinario)
                       .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Maquinario>(maquinario =>
            {
                maquinario.HasKey(m => m.Id);

                maquinario.Property(m => m.Modelo)
                    .IsRequired()
                    .HasMaxLength(100);
                
                maquinario.Property(m => m.LocalizacaoAtual)
                    .HasColumnType("geometry");
            });
        }
    }
}
