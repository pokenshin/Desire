using System;
using System.Collections.Generic;
using Desire.Core.Ciencias;

namespace Desire.Core.Util.Geradores
{
    public class GeradorAreaCientifica : IGerador<AreaCientifica>
    {
        public AreaCientifica Gerar(Random rnd)
        {
            GeradorCiencia genCiencia = new GeradorCiencia();
            GeradorString genString = new GeradorString();

            AreaCientifica resultado = new AreaCientifica()
            {
                Nome = genString.GerarTamanhoEspecifico(3, 8, rnd),
                Ciencia = genCiencia.Gerar(rnd)
            };
            return resultado;
        }

        public List<AreaCientifica> GerarLista(int quantidade, Random rnd)
        {
            List<AreaCientifica> resultado = new List<AreaCientifica>();

            for (int i = 0; i < quantidade-1; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}