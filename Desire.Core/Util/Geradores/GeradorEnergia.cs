using System;
using System.Collections.Generic;
using Desire.Core.Identidade;
using Desire.Core.Energias;

namespace Desire.Core.Util.Geradores
{
    public class GeradorEnergia : IGerador<Energia>
    {
        public Energia Gerar(Random rnd)
        {
            //TODO: pegar uma energia a partir do banco de dados
            List<String> tiposEnergia = new List<string> { "AP", "CP", "EP", "HP", "MP", "QP", "SP", "PE", "PA", "WP" };
            GeradorInteiro rng = new GeradorInteiro();
            
            Energia energia = new Energia()
            {
                Sigla = tiposEnergia[rng.GerarEntre(0, tiposEnergia.Count - 1, rnd)],
                Quantidade = rng.GerarEntre(1, 1000000, rnd)
            };
            return energia;
        }

        public List<Energia> GerarLista(int quantidade, Random rnd)
        {
            List<Energia> resultado = new List<Energia>();

            for (int i = 0; i < quantidade-1; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}