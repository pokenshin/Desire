using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desire.Data
{
    public class SQLiteManager: IDesignTimeDbContextFactory<SQLiteContext>
    {
        string localArquivo = @"E:\Code\DotNet\Core\Desire\Desire.Data\Database\desire_test.db";

        public SQLiteContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SQLiteContext>();
            optionsBuilder.UseSqlite("Data Source=" + localArquivo);
            return new SQLiteContext(optionsBuilder.Options);
        }

    }
}
