using System;
using System.Collections.Generic;
using Desire.Core.Ciencias;

namespace Desire.Util.Geradores
{
    public class GeradorCiencia : IGerador<Ciencia>
    {
        public Ciencia Gerar(Random rnd)
        {
            GeradorString rsg = new GeradorString();
            GeradorEsfera genEsfera = new GeradorEsfera();
            Ciencia resultado = new Ciencia()
            {
                Nome = rsg.GerarTamanhoEspecifico(3, 8, rnd),
                Esfera = genEsfera.Gerar(rnd)
            };
            return resultado;
        }

        public List<Ciencia> GerarLista(int quantidade, Random rnd)
        {
            List<Ciencia> resultado = new List<Ciencia>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}