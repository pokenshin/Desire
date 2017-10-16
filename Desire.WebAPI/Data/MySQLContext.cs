using Microsoft.EntityFrameworkCore;
using Desire.WebAPI.Models.Atributos;
using Desire.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desire.WebAPI.Data
{
    public class MySQLContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;userid=root;database=db_desire;SslMode=none");
        }

        public DbSet<ForcaModel> t_atr_forca { get; set; }
        //public DbSet<Materia> t_atr_materia { get; set; }
        //public DbSet<Destreza> t_atr_destreza { get; set; }
        //public DbSet<Intelecto> t_atr_intelecto { get; set; }
        //public DbSet<Criatividade> t_atr_criatividade { get; set; }
        //public DbSet<Existencia> t_atr_existencia { get; set; }
        //public DbSet<Ideia> t_atr_ideia { get; set; }

    }
}
