using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    public class GeradorRei : IGerador<Rei>
    {
        GeradorInteiro rng = new GeradorInteiro();
        public Rei Gerar()
        {
            GeradorString genString = new GeradorString();
            GeradorModificador genModificador = new GeradorModificador();
            string[] tiposCor = new string[] { "Branco", "Preto", "Vermelho", "Verde", "Azul", "Amarelo", "Violeta", "Rosa", "Cinza", "Laranja", "Marrom" };
            Rei rei = new Rei()
            {
                Nome = genString.GerarTamanhoEspecifico(3, 8),
                Magnitude = rng.GerarEntre(0, 20),
                Origem = genString.GerarTamanhoEspecifico(3, 8),
                Cor = tiposCor[rng.GerarEntre(0, tiposCor.Length - 1)]
            };

            rei.Modificadores = genModificador.GerarListaComOrigem("Rei", rei.Id, rng.GerarEntre(1, 10));

            return rei;
        }

        public Rei GerarComMagnitude(int magnitude)
        {
            Rei resultado = Gerar();
            resultado.Magnitude = magnitude;
            return resultado;
        }

        public List<Rei> GerarListaComMagnitude(int magMin, int magMax, int quantidade)
        {
            List<Rei> lista = new List<Rei>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                Rei rei = Gerar();
                rei.Magnitude = rng.GerarEntre(magMin, magMax);
                lista.Add(rei);
            }
            return lista;
        }

        public List<Rei> GerarLista(int quantidade)
        {
            List<Rei> lista = new List<Rei>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                lista.Add(Gerar());
            }
            return lista;
        }
    }
}