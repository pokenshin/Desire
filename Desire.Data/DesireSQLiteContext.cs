using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desire.Core;
using Desire.Core.Identidade;

namespace Desire.Data
{
    public class SQLiteContext: DbContext
    {
        public SQLiteContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Forca> TabelaForca { get; set; }
        public DbSet<Evolucao> TabelaEvolucao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new TypeConfigurator(modelBuilder.Entity<Forca>());

            ConfiguraForca(modelBuilder);
            ConfiguraEvolucao(modelBuilder);
        }

        private void ConfiguraEvolucao(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evolucao>()
                .HasKey(e => e.EvolucaoId);
        }

        private void ConfiguraForca(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Forca>()
                .HasKey(e => e.Pontos);
        }
    }
}
