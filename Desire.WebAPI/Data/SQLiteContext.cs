using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desire.Core;

namespace Desire.WebAPI.Data
{
    public class SQLiteContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=" + @"~\Data\desire.db");
        }

        public DbSet<Forca> t_forca { get; set; }
    }
}
