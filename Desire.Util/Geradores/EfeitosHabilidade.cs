using System;
using System.Collections.Generic;
using Desire.Core.Efeitos;
using Desire.Core;

namespace Desire.Util.Geradores
{
    public class GeradorEfeito : IGerador<IEfeito>
    {
        public IEfeito Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorEfeitoDano genEfeitoDano = new GeradorEfeitoDano();
            GeradorEfeitoCura genEfeitoCura = new GeradorEfeitoCura();
            GeradorEfeitoModificador genEfeitoMod = new GeradorEfeitoModificador();
            int tipo = rng.GerarEntre(1, 3, rnd);

            switch (tipo)
            {
                //Dano
                case 1:
                    return genEfeitoDano.Gerar(rnd);
                //Cura
                case 2:
                    return genEfeitoCura.Gerar(rnd);
                //Modificador
                case 3:
                    return genEfeitoMod.Gerar(rnd);
                default:
                    return null;
            }

        }

        public List<IEfeito> GerarLista(int quantidade, Random rnd)
        {
            List<IEfeito> resultado = new List<IEfeito>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            };

            return resultado;
        }
    }

    internal class GeradorEfeitoModificador : IGerador<EfeitoModificador>
    {
        public EfeitoModificador Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorDuracaoEfeito genDuracao = new GeradorDuracaoEfeito();
            GeradorModificador genModificador = new GeradorModificador();
            GeradorTipoDeAlvo genTipoDeAlvo = new GeradorTipoDeAlvo();
            EfeitoModificador resultado = new EfeitoModificador()
            {
                Duracao = genDuracao.Gerar(rnd),
                Modificador = genModificador.Gerar(rnd),
                TipoDeAlvo = genTipoDeAlvo.Gerar(rnd)
            };

            return resultado;
        }

        public List<EfeitoModificador> GerarLista(int quantidade, Random rnd)
        {
            List<EfeitoModificador> resultado = new List<EfeitoModificador>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            };

            return resultado;
        }
    }

    internal class GeradorEfeitoCura : IGerador<EfeitoCura>
    {
        public EfeitoCura Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorDuracaoEfeito genDuracao = new GeradorDuracaoEfeito();
            GeradorEnergia genEnergia = new GeradorEnergia();
            GeradorTipoDeAlvo genTipoDeAlvo = new GeradorTipoDeAlvo();
            EfeitoCura resultado = new EfeitoCura()
            {
                Duracao = genDuracao.Gerar(rnd),
                EnergiaAlvo = genEnergia.Gerar(rnd),
                TipoDeAlvo = genTipoDeAlvo.Gerar(rnd),
                Valor = genValorMag.Gerar(rnd)
            };

            return resultado;
        }

        public List<EfeitoCura> GerarLista(int quantidade, Random rnd)
        {
            List<EfeitoCura> resultado = new List<EfeitoCura>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            };

            return resultado;
        }
    }

    internal class GeradorEfeitoDano : IGerador<EfeitoDano>
    {
        public EfeitoDano Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorDuracaoEfeito genDuracao = new GeradorDuracaoEfeito();
            GeradorEnergia genEnergia = new GeradorEnergia();
            GeradorTipoDeAlvo genTipoDeAlvo = new GeradorTipoDeAlvo();
            EfeitoDano resultado = new EfeitoDano()
            {
                Duracao = genDuracao.Gerar(rnd),
                EnergiaAlvo = genEnergia.Gerar(rnd),
                TipoDeAlvo = genTipoDeAlvo.Gerar(rnd),
                Valor = genValorMag.Gerar(rnd)
            };

            return resultado;
        }

        public List<EfeitoDano> GerarLista(int quantidade, Random rnd)
        {
            List<EfeitoDano> resultado = new List<EfeitoDano>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            };

            return resultado;
        }
    }
}