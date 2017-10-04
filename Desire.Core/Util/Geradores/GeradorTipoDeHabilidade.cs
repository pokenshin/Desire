using System;
using System.Collections.Generic;
using Desire.Core.Ciencias;
namespace Desire.Core.Util.Geradores
{
    public class GeradorTipoDeHabilidade : IGerador<TipoHabilidade>
    {
        public TipoHabilidade Gerar(Random rnd)
        {
            GeradorString genString = new GeradorString();
            GeradorInteiro rng = new GeradorInteiro();

            TipoHabilidade resultado = new TipoHabilidade()
            {
                Id = rng.GerarEntre(1, 100, rnd),
                Nome = genString.GerarTamanhoEspecifico(4, 10, rnd)
            };

            return resultado;
        }

        public List<TipoHabilidade> GerarLista(int quantidade, Random rnd)
        {
            List<TipoHabilidade> resultado = new List<TipoHabilidade>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}