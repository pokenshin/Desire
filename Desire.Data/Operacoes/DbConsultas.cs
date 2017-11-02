using System.Collections.Generic;
using Desire.Core;
using System.Linq;

namespace Desire.Data.Operacoes
{
    public class DbConsultas
    {
        public List<Forca> RetornaTabelaForca()
        {
            SQLiteManager dbManager = new SQLiteManager();
            List<Forca> resultado = new List<Forca>();
            string[] args = { };
            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaForca
                    .OrderBy(x => x.Pontos)
                    .ToList();
            }

            return resultado;
        }

        public List<Materia> RetornaTabelaMateria()
        {
            SQLiteManager dbManager = new SQLiteManager();
            List<Materia> resultado = new List<Materia>();
            string[] args = { };
            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaMateria
                    .OrderBy(x => x.Pontos)
                    .ToList();
            }

            return resultado;
        }

        public List<Destreza> RetornaTabelaDestreza()
        {
            SQLiteManager dbManager = new SQLiteManager();
            List<Destreza> resultado = new List<Destreza>();
            string[] args = { };
            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaDestreza
                    .OrderBy(x => x.Pontos)
                    .ToList();
            }

            return resultado;
        }

        public List<Intelecto> RetornaTabelaIntelecto()
        {
            SQLiteManager dbManager = new SQLiteManager();
            List<Intelecto> resultado = new List<Intelecto>();
            string[] args = { };
            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaIntelecto
                    .OrderBy(x => x.Pontos)
                    .ToList();
            }

            return resultado;
        }

        public List<Criatividade> RetornaTabelaCriatividade()
        {
            SQLiteManager dbManager = new SQLiteManager();
            List<Criatividade> resultado = new List<Criatividade>();
            string[] args = { };
            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaCriatividade
                    .OrderBy(x => x.Pontos)
                    .ToList();
            }

            return resultado;
        }

        public List<Ideia> RetornaTabelaIdeia()
        {
            SQLiteManager dbManager = new SQLiteManager();
            List<Ideia> resultado = new List<Ideia>();
            string[] args = { };
            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaIdeia
                    .OrderBy(x => x.Pontos)
                    .ToList();
            }

            return resultado;
        }

        public List<Existencia> RetornaTabelaExistencia()
        {
            SQLiteManager dbManager = new SQLiteManager();
            List<Existencia> resultado = new List<Existencia>();
            string[] args = { };
            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaExistencia
                    .OrderBy(x => x.Pontos)
                    .ToList();
            }

            return resultado;
        }

    }
}
