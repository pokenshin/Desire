using System;
using System.Collections.Generic;
using System.Text;

namespace Desire.Core.Util.Geradores
{
    public class GeradorOrigem : IGerador<Origem>
    {
        public Origem Gerar(Random rnd)
        {
            GeradorString rsg = new GeradorString();
            //TODO: pegar uma origem aleatoria do banco de dados.
            Realidade realidade = new Realidade(rsg.GerarTamanhoEspecifico(2, 8, rnd));
            Plano plano = new Plano(rsg.GerarTamanhoEspecifico(2, 8, rnd), realidade);
            Origem origem = new Origem(rsg.GerarTamanhoEspecifico(4, 10, rnd), plano);

            return origem;
        }

        public List<Origem> GerarLista(int quantidade, Random rnd)
        {
            List<Origem> lista = new List<Origem>();
            for (int i = 0; i < quantidade-1; i++)
            {
                lista.Add(Gerar(rnd));
            }
            return lista;
        }
    }
}