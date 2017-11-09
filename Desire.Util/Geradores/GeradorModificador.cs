using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Desire.Core.Modificadores;
using Desire.Core;

namespace Desire.Util.Geradores
{
    interface IGeradorModificador<T>
    {
        ///<summary>
        ///Gera um modificador de determinada origem com o id da origem.
        ///</summary>
        /// <param name="origem">De onde o modificador está vindo.</param>
        /// <param name="id">Qual a ID da origem do modificador.</param>
        T GerarComOrigem(string origem, int id, Random rnd, char tipo = 'R');
        ///<summary>
        ///Gera uma lista de modificadores de origem específica na quantidade especifícada.
        ///</summary>
        /// <param name="origem">De onde o modificador está vindo.</param>
        /// <param name="id">Qual a ID da origem do modificador.</param>
        /// <param name="quantidade">Número de itens da lista.</param>
        List<T> GerarListaComOrigem(string origem, int id, int quantidade, Random rnd, char tipo = 'R');
    }

    public class GeradorModificador : IGerador<Modificador>, IGeradorModificador<Modificador>
    {
        char[] tiposModificadores = new char[] { '+', '*', '-', '/' };

        public Modificador Gerar(Random rnd)
        {
            return GerarComOrigem("Gerado Aleatoriamente", 0, rnd);
        }

        public List<Modificador> GerarLista(int quantidade, Random rnd)
        {
            List<Modificador> lista = new List<Modificador>();

            for (int i = 0; i < quantidade; i++)
            {
                lista.Add(Gerar(rnd));
            }

            return lista;
        }

        public List<Modificador> GerarListaComOrigem(string origem, int id, int quantidade, Random rnd, char tipo = 'R')
        {
            List<Modificador> lista = new List<Modificador>();

            for (int i = 0; i < quantidade; i++)
            {
                lista.Add(GerarComOrigem(origem, id, rnd, tipo));
            }

            return lista;
        }

        public Modificador GerarComOrigem(string origem, int id, Random rnd, char tipo = 'R')
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag rvmg = new GeradorValorMag();
            GeradorPericia genPericia = new GeradorPericia();
            GeradorHabilidade genHabilidade = new GeradorHabilidade();
            int tipoModificador = rng.GerarEntre(1, 10, rnd);
            PropertyInfo[] propriedades = typeof(Ser).GetTypeInfo().DeclaredProperties.Where(p => p.PropertyType == typeof(int)).ToArray<PropertyInfo>();
            string alvo = propriedades[rng.GerarEntre(0, propriedades.Count() - 1, rnd)].Name;

            switch (tipoModificador)
            {
                case 1:
                    ModSomaValorMag modSomaValorMag = new ModSomaValorMag()
                    {
                        Alvo = alvo,
                        Origem = origem,
                        Valor = rvmg.GerarEntre(new ValorMag(10, 1), new ValorMag(99, 10), rnd)
                    };
                    return modSomaValorMag;

                case 2:
                    ModSubtraiValorMag modSubtraiValorMag = new ModSubtraiValorMag()
                    {
                        Alvo = alvo,
                        Origem = origem,
                        Valor = rvmg.GerarEntre(new ValorMag(10, 1), new ValorMag(99, 10), rnd)
                    };
                    return modSubtraiValorMag;

                case 3:
                    ModSomaNumero modSomaNumero = new ModSomaNumero()
                    {
                        Alvo = alvo,
                        Origem = origem,
                        Valor = rng.GerarEntre(1, 10000, rnd)
                    };
                    return modSomaNumero;

                case 4:
                    ModSubtraiNumero modSubtraiNumero = new ModSubtraiNumero()
                    {
                        Alvo = alvo,
                        Origem = origem,
                        Valor = rng.GerarEntre(1, 10000, rnd)
                    };
                    return modSubtraiNumero;

                case 5:
                    ModMultiplicaNumero modMultiplicaNumero = new ModMultiplicaNumero()
                    {
                        Alvo = alvo,
                        Origem = origem,
                        Valor = rng.GerarEntre(1, 10000, rnd)
                    };
                    return modMultiplicaNumero;

                case 6:
                    ModMultiplicaValorMag modMultiplicaValorMag = new ModMultiplicaValorMag()
                    {
                        Alvo = alvo,
                        Origem = origem,
                        Valor = rvmg.GerarEntre(new ValorMag(10, 1), new ValorMag(99, 10), rnd)
                    };
                    return modMultiplicaValorMag;

                case 7:
                    ModDivideNumero modDivideNumero = new ModDivideNumero()
                    {
                        Alvo = alvo,
                        Origem = origem,
                        Valor = rng.GerarEntre(1, 100, rnd)
                    };
                    return modDivideNumero;

                case 8:
                    ModDivideValorMag modDivideValorMag = new ModDivideValorMag()
                    {
                        Alvo = alvo,
                        Origem = origem,
                        Valor = rvmg.GerarEntre(new ValorMag(10, 1), new ValorMag(99, 5), rnd)
                    };
                    return modDivideValorMag;

                case 9:
                    ModAdicionaHabilidade modAdicionaHabilidade = new ModAdicionaHabilidade()
                    {
                        Alvo = genHabilidade.Gerar(rnd),
                        Origem = origem
                    };
                    return modAdicionaHabilidade;

                case 10:
                    ModAdicionaPericia modAdicionaPericia = new ModAdicionaPericia()
                    {
                        Alvo = genPericia.Gerar(rnd),
                        Origem = origem
                    };
                    return modAdicionaPericia;

                default:
                    return null;
            }
        }
    }
}