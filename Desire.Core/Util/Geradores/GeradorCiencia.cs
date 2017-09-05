using System;
using System.Collections.Generic;
using Desire.Core.Ciencias;

namespace Desire.Core.Util.Geradores
{
    public class GeradorCiencia : IGerador<Ciencia>
    {
        public Ciencia Gerar()
        {
            GeradorString rsg = new GeradorString();
            GeradorEsfera genEsfera = new GeradorEsfera();
            Ciencia resultado = new Ciencia()
            {
                Nome = rsg.GerarTamanhoEspecifico(3, 8),
                Esfera = genEsfera.Gerar()
            };
            return resultado;
        }

        public List<Ciencia> GerarLista(int quantidade)
        {
            List<Ciencia> resultado = new List<Ciencia>();

            for (int i = 0; i < quantidade-1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}