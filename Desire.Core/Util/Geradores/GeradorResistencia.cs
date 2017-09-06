using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    public class GeradorResistencia : IGerador<Resistencia>
    {
        public Resistencia Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorBoolean genBoolean = new GeradorBoolean();
            GeradorString genString = new GeradorString();
            CalculadorNumero calculador = new CalculadorNumero();
            Resistencia resultado = new Resistencia();
            ValorMag min = genValorMag.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 10), rnd);
            ValorMag max = calculador.SomaValorMag(min, genValorMag.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 10), rnd));

            char tipo;
            if (genBoolean.GeraComChance(50, rnd))
                    tipo = '+';
                else
                    tipo = '-';

            resultado.Nome = genString.GerarTamanhoEspecifico(3, 10, rnd);

            if (tipo == '+')
            {
                resultado.Positiva = genValorMag.GerarEntre(min, max, rnd);
                resultado.Negativa = new ValorMag();
            }
            else
            {
                resultado.Positiva = new ValorMag();
                resultado.Negativa = genValorMag.GerarEntre(min, max, rnd);
            }

            return resultado;
        }

        public List<Resistencia> GerarLista(int quantidade, Random rnd)
        {
            List<Resistencia> resultado = new List<Resistencia>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}