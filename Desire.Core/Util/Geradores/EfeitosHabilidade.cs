using System;
using System.Collections.Generic;
using Desire.Core.Efeitos;

namespace Desire.Core.Util.Geradores
{
    public class GeradorEfeito : IGerador<IEfeito>
    {
        public IEfeito Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorEfeitoDano genEfeitoDano = new GeradorEfeitoDano();
            GeradorEfeitoCura genEfeitoCura = new GeradorEfeitoCura();
            GeradorEfeitoModificador genEfeitoMod = new GeradorEfeitoModificador();
            int tipo = rng.GerarEntre(1, 3);

            switch (tipo)
            {
                //Dano
                case 1:
                    return genEfeitoDano.Gerar();
                //Cura
                case 2:
                    return genEfeitoCura.Gerar();
                //Modificador
                case 3:
                    return genEfeitoMod.Gerar();
                default:
                    return null;
            }

        }

        public List<IEfeito> GerarLista(int quantidade)
        {
            List<IEfeito> resultado = new List<IEfeito>();

            for (int i = 0; i < quantidade-1; i++)
            {
                resultado.Add(Gerar());
            };

            return resultado;
        }
    }

    internal class GeradorEfeitoModificador : IGerador<EfeitoModificador>
    {
        public EfeitoModificador Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorDuracaoEfeito genDuracao = new GeradorDuracaoEfeito();
            GeradorModificador genModificador = new GeradorModificador();
            GeradorTipoDeAlvo genTipoDeAlvo = new GeradorTipoDeAlvo();
            EfeitoModificador resultado = new EfeitoModificador()
            {
                Duracao = genDuracao.Gerar(),
                Modificador = genModificador.Gerar(),
                TipoDeAlvo = genTipoDeAlvo.Gerar()
            };

            return resultado;
        }

        public List<EfeitoModificador> GerarLista(int quantidade)
        {
            List<EfeitoModificador> resultado = new List<EfeitoModificador>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            };

            return resultado;
        }
    }

    internal class GeradorEfeitoCura : IGerador<EfeitoCura>
    {
        public EfeitoCura Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorDuracaoEfeito genDuracao = new GeradorDuracaoEfeito();
            GeradorEnergia genEnergia = new GeradorEnergia();
            GeradorTipoDeAlvo genTipoDeAlvo = new GeradorTipoDeAlvo();
            EfeitoCura resultado = new EfeitoCura()
            {
                Duracao = genDuracao.Gerar(),
                EnergiaAlvo = genEnergia.Gerar(),
                TipoDeAlvo = genTipoDeAlvo.Gerar(),
                Valor = genValorMag.Gerar()
            };

            return resultado;
        }

        public List<EfeitoCura> GerarLista(int quantidade)
        {
            List<EfeitoCura> resultado = new List<EfeitoCura>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            };

            return resultado;
        }
    }

    internal class GeradorEfeitoDano : IGerador<EfeitoDano>
    {
        public EfeitoDano Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorDuracaoEfeito genDuracao = new GeradorDuracaoEfeito();
            GeradorEnergia genEnergia = new GeradorEnergia();
            GeradorTipoDeAlvo genTipoDeAlvo = new GeradorTipoDeAlvo();
            EfeitoDano resultado = new EfeitoDano()
            {
                Duracao = genDuracao.Gerar(),
                EnergiaAlvo = genEnergia.Gerar(),
                TipoDeAlvo = genTipoDeAlvo.Gerar(),
                Valor = genValorMag.Gerar()
            };

            return resultado;
        }

        public List<EfeitoDano> GerarLista(int quantidade)
        {
            List<EfeitoDano> resultado = new List<EfeitoDano>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            };

            return resultado;
        }
    }
}