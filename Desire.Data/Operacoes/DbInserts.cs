using System.Collections.Generic;
using Desire.Core;
using System.Linq;


namespace Desire.Data.Operacoes
{
    public class DbInserts
    {
        public void InsereForca(Forca forca)
        {
            SQLiteManager dbManager = new SQLiteManager();
            string[] args = { };
            using (var db = dbManager.CreateDbContext(args))
            {
                db.Add<Forca>(forca);
                db.SaveChanges();
            }
        }
    }
}
