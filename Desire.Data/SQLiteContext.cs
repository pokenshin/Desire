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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfiguradorForca());
        }
    }
}
