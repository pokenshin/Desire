using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    public class GeradorEnergia : IGerador<Energia>
    {
        public Energia Gerar()
        {
            //TODO: pegar uma energia a partir do banco de dados
            List<String> tiposEnergia = new List<string> { "AP", "CP", "EP", "HP", "MP", "QP", "SP", "PE", "PA", "WP" };
            GeradorInteiro rng = new GeradorInteiro();
            
            Energia energia = new Energia()
            {
                Sigla = tiposEnergia[rng.GerarEntre(0, tiposEnergia.Count - 1)],
                Quantidade = rng.GerarEntre(1, 1000000)
            };
            return energia;
        }

        public List<Energia> GerarLista(int quantidade)
        {
            List<Energia> resultado = new List<Energia>();

            for (int i = 0; i < quantidade-1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}