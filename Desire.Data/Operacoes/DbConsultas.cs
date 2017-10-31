using System.Collections.Generic;
using Desire.Core;
using System.Linq;

namespace Desire.Data.Operacoes
{
    public class DbConsultas
    {
        public List<Forca> RetornaListaForca()
        {
            SQLiteManager dbManager = new SQLiteManager();
            List<Forca> resultado = new List<Forca>();
            string[] args = { };
            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaForca.ToList();
            }

            return resultado;
        }
        

    }
}
