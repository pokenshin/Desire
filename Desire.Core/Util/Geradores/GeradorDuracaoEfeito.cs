using System;
using System.Collections.Generic;
using Desire.Core.Efeitos;

namespace Desire.Core.Util.Geradores
{
    public class GeradorDuracaoEfeito : IGerador<DuracaoEfeito>
    {
        public DuracaoEfeito Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            

            List<string> tiposDuracao = new List<String>()
            {
                "Limitado",
                "Canal",
                "Marca",
                "Postura",
                "Permanente",
                "Instantâneo"
            };

            List<string> unidadesDuracao = new List<string>()
            {
                "Turnos",
                "Segundos",
                "Minutos",
                "Horas",
                "Dias",
                "Meses",
                "Anos",
                "Séculos",
                "Milênios",
                "Gêneses"
            };

            DuracaoEfeito resultado = new DuracaoEfeito()
            {
                TipoDuracao = tiposDuracao[rng.GerarEntre(0, tiposDuracao.Count - 1, rnd)],

            };
            if (resultado.TipoDuracao == "Limitado")
            {
                GeradorValorMag genValorMag = new GeradorValorMag();
                resultado.UnidadeDuracao = unidadesDuracao[rng.GerarEntre(0, unidadesDuracao.Count - 1, rnd)];
                resultado.ValorDuracao = genValorMag.Gerar(rnd);
            }
            return resultado;
        }

        public List<DuracaoEfeito> GerarLista(int quantidade, Random rnd)
        {
            List<DuracaoEfeito> resultado = new List<DuracaoEfeito>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }
            return resultado;
        }
    }
}