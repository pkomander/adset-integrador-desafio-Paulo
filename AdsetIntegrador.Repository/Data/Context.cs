using AdsetIntegrador.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsetIntegrador.Repository.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> opt) : base(opt)
        {
            
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<CarroFoto> carroFotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura a chave primária para CarroFoto
            modelBuilder.Entity<CarroFoto>()
                .HasKey(cf => cf.CarroFotoId);

            //modelBuilder.Entity<CarroFoto>()
            //    .HasKey(cf => new { cf.CarroId, cf.FotoId });

            modelBuilder.Entity<CarroFoto>()
                .HasOne(cf => cf.Carro)
                .WithMany(f => f.CarroFotos)
                .HasForeignKey(cf => cf.CarroId);

            modelBuilder.Entity<CarroFoto>()
                .HasOne(cf => cf.Foto)
                .WithMany(f => f.CarroFotos)
                .HasForeignKey(co => co.FotoId);
        }
    }
}
