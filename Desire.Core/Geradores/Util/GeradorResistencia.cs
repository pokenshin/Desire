using System;
using System.Collections.Generic;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    internal class GeradorResistencia : IGerador<Resistencia>
    {
        public Resistencia Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorBoolean genBoolean = new GeradorBoolean();
            GeradorString genString = new GeradorString();
            CalculadorNumero calculador = new CalculadorNumero();
            Resistencia resultado = new Resistencia();
            ValorMag min = genValorMag.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 10));
            ValorMag max = calculador.SomaValorMag(min, genValorMag.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 10)));

            char tipo;
            if (genBoolean.GeraComChance(50))
                    tipo = '+';
                else
                    tipo = '-';

            resultado.Nome = genString.GerarTamanhoEspecifico(3, 10);

            if (tipo == '+')
            {
                resultado.Positiva = genValorMag.GerarEntre(min, max);
                resultado.Negativa = new ValorMag();
            }
            else
            {
                resultado.Positiva = new ValorMag();
                resultado.Negativa = genValorMag.GerarEntre(min, max);
            }

            return resultado;
        }

        public List<Resistencia> GerarLista(int quantidade)
        {
            List<Resistencia> resultado = new List<Resistencia>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}