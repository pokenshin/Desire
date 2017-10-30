using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desire.Data
{
    public class SQLiteManager
    {
        string localArquivo = "desire.db";

        public SQLiteContext GeraContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SQLiteContext>();
            optionsBuilder.UseSqlite("Data Source=" + localArquivo);
            return new SQLiteContext(optionsBuilder.Options);
        }

    }
}
