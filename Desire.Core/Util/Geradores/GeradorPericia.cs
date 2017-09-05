using System;
using System.Collections.Generic;
using Desire.Core.Ciencias;

namespace Desire.Core.Util.Geradores
{
    public class GeradorPericia : IGerador<Pericia>
    {
        GeradorInteiro rng = new GeradorInteiro();
        public Pericia Gerar()
        {
            GeradorModificador genModificador = new GeradorModificador();
            GeradorString genString = new GeradorString();
            Pericia pericia = new Pericia()
            {
                Nome = genString.GerarTamanhoEspecifico(3, 8),
                Id = rng.GerarEntre(0, 1000),
            };

            pericia.Modificadores = genModificador.GerarListaComOrigem("Pericia", pericia.Id, '+');
            pericia.Caracteristicas = "Perícia em " + pericia.Nome + ". Modificadores: ";

            foreach (Modificador mod in pericia.Modificadores)
            {
                pericia.Caracteristicas = pericia.Caracteristicas + mod.Nome + " ";
            }

            return pericia;
        }

        public List<Pericia> GerarLista(int quantidade)
        {
            //TODO: Pegar lista a partir do banco de dados de Pericias
            //TODO: Criar um limite lógico no nivel das pericias adquiridas
            //TODO: Fazer com que as pericias escolhidas sigam a regra de progressão das pericias

            List<Pericia> resultado = new List<Pericia>();
            if (quantidade == 0)
                quantidade = rng.GerarEntre(1, 10);

            for (int i = 0; i < quantidade; i++)
            {
                Pericia pericia = Gerar();
                resultado.Add(pericia);
            }

            return resultado;
        }
    }
}