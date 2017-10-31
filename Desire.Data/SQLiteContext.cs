using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desire.Core;
using Desire.Core.Identidade;
using Desire.Data.Configuradores;

namespace Desire.Data
{
    public class SQLiteContext: DbContext
    {
        public SQLiteContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Forca> TabelaForca { get; set; }
        public DbSet<Materia> TabelaMateria { get; set; }
        public DbSet<Destreza> TabelaDestreza { get; set; }
        public DbSet<Intelecto> TabelaIntelecto { get; set; }
        public DbSet<Criatividade> TabelaCriatividade { get; set; }
        public DbSet<Existencia> TabelaExistencia { get; set; }
        public DbSet<Ideia> TabelaIdeia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfiguradorForca());
            modelBuilder.ApplyConfiguration(new ConfiguradorMateria());
            modelBuilder.ApplyConfiguration(new ConfiguradorDestreza());
            modelBuilder.ApplyConfiguration(new ConfiguradorIntelecto());
            modelBuilder.ApplyConfiguration(new ConfiguradorCriatividade());
            modelBuilder.ApplyConfiguration(new ConfiguradorExistencia());
            modelBuilder.ApplyConfiguration(new ConfiguradorIdeia());

        }
    }
}
