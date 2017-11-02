using System.Collections.Generic;
using Desire.Core;
using System.Linq;

namespace Desire.Data.Operacoes
{
    public class DbConsultas
    {
        string[] args = { };

        public Forca RetornaForca(int nrPontos)
        {
            SQLiteManager dbManager = new SQLiteManager();
            Forca resultado = new Forca();
            
            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaForca.Single(x => x.Pontos == nrPontos);
            }

            return resultado;
        }

        public Materia RetornaMateria(int nrPontos)
        {
            SQLiteManager dbManager = new SQLiteManager();
            Materia resultado = new Materia();

            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaMateria.Single(x => x.Pontos == nrPontos);
            }

            return resultado;
        }

        public Destreza RetornaDestreza(int nrPontos)
        {
            SQLiteManager dbManager = new SQLiteManager();
            Destreza resultado = new Destreza();

            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaDestreza.Single(x => x.Pontos == nrPontos);
            }

            return resultado;
        }

        public Intelecto RetornaIntelecto (int nrPontos)
        {
            SQLiteManager dbManager = new SQLiteManager();
            Intelecto resultado = new Intelecto();

            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaIntelecto.Single(x => x.Pontos == nrPontos);
            }

            return resultado;
        }

        public Criatividade RetornaCriatividade(int nrPontos)
        {
            SQLiteManager dbManager = new SQLiteManager();
            Criatividade resultado = new Criatividade();

            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaCriatividade.Single(x => x.Pontos == nrPontos);
            }

            return resultado;
        }

        public Existencia RetornaExistencia(int nrPontos)
        {
            SQLiteManager dbManager = new SQLiteManager();
            Existencia resultado = new Existencia();

            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaExistencia.Single(x => x.Pontos == nrPontos);
            }

            return resultado;
        }

        public Ideia RetornaIdeia(int nrPontos)
        {
            SQLiteManager dbManager = new SQLiteManager();
            Ideia resultado = new Ideia();

            using (var db = dbManager.CreateDbContext(args))
            {
                resultado = db.TabelaIdeia.Single(x => x.Pontos == nrPontos);
            }

            return resultado;
        }

        public List<Forca> RetornaTabelaForca()
        {
            SQLiteManager dbManager = new SQLiteManager();
            List<Forca> resultado = new List<Forca>();

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