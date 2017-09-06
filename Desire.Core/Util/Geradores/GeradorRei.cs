using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    public class GeradorRei : IGerador<Rei>
    {
        GeradorInteiro rng = new GeradorInteiro();
        public Rei Gerar(Random rnd)
        {
            GeradorString genString = new GeradorString();
            GeradorModificador genModificador = new GeradorModificador();
            string[] tiposCor = new string[] { "Branco", "Preto", "Vermelho", "Verde", "Azul", "Amarelo", "Violeta", "Rosa", "Cinza", "Laranja", "Marrom" };
            Rei rei = new Rei()
            {
                Nome = genString.GerarTamanhoEspecifico(3, 8, rnd),
                Magnitude = rng.GerarEntre(0, 20, rnd),
                Origem = genString.GerarTamanhoEspecifico(3, 8, rnd),
                Cor = tiposCor[rng.GerarEntre(0, tiposCor.Length - 1, rnd)]
            };

            rei.Modificadores = genModificador.GerarListaComOrigem("Rei", rei.Id, rng.GerarEntre(1, 10, rnd), rnd);

            return rei;
        }

        public Rei GerarComMagnitude(int magnitude, Random rnd)
        {
            Rei resultado = Gerar(rnd);
            resultado.Magnitude = magnitude;
            return resultado;
        }

        public List<Rei> GerarListaComMagnitude(int magMin, int magMax, int quantidade, Random rnd)
        {
            List<Rei> lista = new List<Rei>();
            for (int i = 0; i < quantidade; i++)
            {
                Rei rei = Gerar(rnd);
                rei.Magnitude = rng.GerarEntre(magMin, magMax, rnd);
                lista.Add(rei);
            }
            return lista;
        }

        public List<Rei> GerarLista(int quantidade, Random rnd)
        {
            List<Rei> lista = new List<Rei>();
            for (int i = 0; i < quantidade; i++)
            {
                lista.Add(Gerar(rnd));
            }
            return lista;
        }
    }
}