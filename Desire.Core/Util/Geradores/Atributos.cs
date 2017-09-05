using System;
using System.Collections.Generic;
using System.Text;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    //TODO: Em todos os itens: fazer pegar atributo do banco de dados.
    interface IGeradorAtributo<T>
    {
        ///<summary>
        ///Escolhe um atributo aleatoriamente no intervalo de pontos definido.
        ///</summary>
        /// <param name="min">Quantidade mínima de pontos do atributo gerado.</param>
        /// <param name="max">Quantidade máxima de pontos do atributo gerado.</param>
        T GerarEntrePontos(int min, int max);
        ///<summary>
        ///Gera uma lista de atributos no intervalo de pontos definido.
        ///</summary>
        /// <param name="min">Quantidade mínima de pontos do atributo gerado.</param>
        /// <param name="max">Quantidade máxima de pontos do atributo gerado.</param>
        /// <param name="quantidade">Quantidade itens na lista</param>
        List<T> GerarListaEntrePontos(int min, int max, int quantidade);
    }

    class GeradorForca : IGerador<Forca>, IGeradorAtributo<Forca>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorBoolean rbg = new GeradorBoolean();
        GeradorString rsg = new GeradorString();
        GeradorValorMag rvmg = new GeradorValorMag();

        public Forca Gerar()
        {
            Forca atributo = new Forca()
            {
                Sustentacao = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Classe = Convert.ToChar(rsg.GerarTamanhoEspecifico(1, 1)),
                Dureza = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Golpe = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Nivel = rng.GerarEntre(1, 5),
                Pontos = rng.GerarEntre(1, 100),
                Porcentagem = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Potencia = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Vigor = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Evolucao = new Evolucao(rng.GerarEntre(1, 17), 16, rbg.GeraComChance(10)),
                BonusAP = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15))
            };
            return atributo;
        }

        public Forca GerarEntrePontos(int min, int max)
        {
            Forca atributo = Gerar();
            atributo.Pontos = rng.GerarEntre(1, 100);
            return atributo;
        }

        public List<Forca> GerarLista(int quantidade)
        {
            List<Forca> resultado = new List<Forca>();
            for (int i = 0; i < quantidade-1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }

        public List<Forca> GerarListaEntrePontos(int min, int max, int quantidade)
        {
            List<Forca> resultado = new List<Forca>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(GerarEntrePontos(min, max));
            }

            return resultado;
        }
    }

    class GeradorCriatividade : IGerador<Criatividade>, IGeradorAtributo<Criatividade>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorBoolean rbg = new GeradorBoolean();
        GeradorString rsg = new GeradorString();
        GeradorValorMag rvmg = new GeradorValorMag();

        public Criatividade Gerar()
        {
            Criatividade atributo = new Criatividade()
            {
                Classe = Convert.ToChar(rsg.GerarTamanhoEspecifico(1, 1)),
                Invencao = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Nivel = rng.GerarEntre(1, 5),
                Pontos = rng.GerarEntre(1, 100),
                Porcentagem = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Realidade = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Singularidade = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Tutor = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Visualizacao = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Evolucao = new Evolucao(rng.GerarEntre(1, 17), 16, rbg.GeraComChance(10)),
                BonusMP = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15))
            };
            return atributo;
        }

        public Criatividade GerarEntrePontos(int min, int max)
        {
            Criatividade atributo = Gerar();
            atributo.Pontos = rng.GerarEntre(1, 100);
            return atributo;
        }

        public List<Criatividade> GerarLista(int quantidade)
        {
            List<Criatividade> resultado = new List<Criatividade>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }

        public List<Criatividade> GerarListaEntrePontos(int min, int max, int quantidade)
        {
            List<Criatividade> resultado = new List<Criatividade>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(GerarEntrePontos(min, max));
            }

            return resultado;
        }
    }

    class GeradorDestreza : IGerador<Destreza>, IGeradorAtributo<Destreza>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorBoolean rbg = new GeradorBoolean();
        GeradorString rsg = new GeradorString();
        GeradorValorMag rvmg = new GeradorValorMag();

        public Destreza Gerar()
        {
            Destreza atributo = new Destreza()
            {
                Ataque = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Classe = Convert.ToChar(rsg.GerarTamanhoEspecifico(1, 1)),
                Esquiva = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Iniciativa = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Nivel = rng.GerarEntre(1, 5),
                Pontos = rng.GerarEntre(1, 100),
                Porcentagem = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Dinamica = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Reflexo = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Evolucao = new Evolucao(rng.GerarEntre(1, 17), 16, rbg.GeraComChance(10)),
                BonusAP = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15))
            };
            return atributo;
        }

        public Destreza GerarEntrePontos(int min, int max)
        {
            Destreza atributo = Gerar();
            atributo.Pontos = rng.GerarEntre(1, 100);
            return atributo;
        }

        public List<Destreza> GerarLista(int quantidade)
        {
            List<Destreza> resultado = new List<Destreza>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }

        public List<Destreza> GerarListaEntrePontos(int min, int max, int quantidade)
        {
            List<Destreza> resultado = new List<Destreza>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(GerarEntrePontos(min, max));
            }

            return resultado;
        }
    }

    class GeradorExistencia : IGerador<Existencia>, IGeradorAtributo<Existencia>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorBoolean rbg = new GeradorBoolean();
        GeradorString rsg = new GeradorString();
        GeradorValorMag rvmg = new GeradorValorMag();

        public Existencia Gerar()
        {
            Existencia atributo = new Existencia()
            {
                Ciencia = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Classe = Convert.ToChar(rsg.GerarTamanhoEspecifico(1, 1)),
                Conhecimento = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Consciencia = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Experiencia = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Nivel = rng.GerarEntre(1, 5),
                Pontos = rng.GerarEntre(1, 100),
                Plano = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Porcentagem = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Evolucao = new Evolucao(rng.GerarEntre(1, 17), 16, rbg.GeraComChance(10)),
                BonusAP = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15))
            };
            return atributo;
        }

        public Existencia GerarEntrePontos(int min, int max)
        {
            Existencia atributo = Gerar();
            atributo.Pontos = rng.GerarEntre(1, 100);
            return atributo;
        }

        public List<Existencia> GerarLista(int quantidade)
        {
            List<Existencia> resultado = new List<Existencia>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }

        public List<Existencia> GerarListaEntrePontos(int min, int max, int quantidade)
        {
            List<Existencia> resultado = new List<Existencia>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(GerarEntrePontos(min, max));
            }

            return resultado;
        }
    }

    class GeradorIdeia : IGerador<Ideia>, IGeradorAtributo<Ideia>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorBoolean rbg = new GeradorBoolean();
        GeradorString rsg = new GeradorString();
        GeradorValorMag rvmg = new GeradorValorMag();

        public Ideia Gerar()
        {
            Ideia atributo = new Ideia()
            {
                Base = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Nivel = rng.GerarEntre(1, 5),
                Pontos = rng.GerarEntre(1, 100),
                Porcentagem = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Evolucao = new Evolucao(rng.GerarEntre(1, 17), 16, rbg.GeraComChance(10)),
                Classe = Convert.ToChar(rsg.GerarTamanhoEspecifico(1, 1)),
                Irrealidade = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Ki = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Misterio = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Nexo = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                BonusMP = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15))
            };
            return atributo;
        }

        public Ideia GerarEntrePontos(int min, int max)
        {
            Ideia atributo = Gerar();
            atributo.Pontos = rng.GerarEntre(1, 100);
            return atributo;
        }

        public List<Ideia> GerarLista(int quantidade)
        {
            List<Ideia> resultado = new List<Ideia>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }

        public List<Ideia> GerarListaEntrePontos(int min, int max, int quantidade)
        {
            List<Ideia> resultado = new List<Ideia>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(GerarEntrePontos(min, max));
            }

            return resultado;
        }
    }

    class GeradorIntelecto : IGerador<Intelecto>, IGeradorAtributo<Intelecto>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorBoolean rbg = new GeradorBoolean();
        GeradorString rsg = new GeradorString();
        GeradorValorMag rvmg = new GeradorValorMag();

        public Intelecto Gerar()
        {
            Intelecto atributo = new Intelecto()
            {
                Nivel = rng.GerarEntre(1, 5),
                Pontos = rng.GerarEntre(1, 100),
                Porcentagem = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Evolucao = new Evolucao(rng.GerarEntre(1, 17), 16, rbg.GeraComChance(10)),
                Classe = Convert.ToChar(rsg.GerarTamanhoEspecifico(1, 1)),
                Aprendizagem = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Concentracao = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Eidos = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Memoria = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Senso = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                BonusAP = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15))
            };
            return atributo;
        }

        public Intelecto GerarEntrePontos(int min, int max)
        {
            Intelecto atributo = Gerar();
            atributo.Pontos = rng.GerarEntre(1, 100);
            return atributo;
        }

        public List<Intelecto> GerarLista(int quantidade)
        {
            List<Intelecto> resultado = new List<Intelecto>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }

        public List<Intelecto> GerarListaEntrePontos(int min, int max, int quantidade)
        {
            List<Intelecto> resultado = new List<Intelecto>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(GerarEntrePontos(min, max));
            }

            return resultado;
        }
    }

    class GeradorMateria : IGerador<Materia>, IGeradorAtributo<Materia>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorBoolean rbg = new GeradorBoolean();
        GeradorString rsg = new GeradorString();
        GeradorValorMag rvmg = new GeradorValorMag();

        public Materia Gerar()
        {
            Materia atributo = new Materia()
            {
                Nivel = rng.GerarEntre(1, 5),
                Pontos = rng.GerarEntre(1, 100),
                Porcentagem = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Evolucao = new Evolucao(rng.GerarEntre(1, 17), 16, rbg.GeraComChance(10)),
                Classe = Convert.ToChar(rsg.GerarTamanhoEspecifico(1, 1)),
                Colapso = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Impulso = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Carga = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Resistencia = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                Vitalidade = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                BonusHP = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15)),
                BonusAP = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15))
            };
            return atributo;
        }

        public Materia GerarEntrePontos(int min, int max)
        {
            Materia atributo = Gerar();
            atributo.Pontos = rng.GerarEntre(1, 100);
            return atributo;
        }

        public List<Materia> GerarLista(int quantidade)
        {
            List<Materia> resultado = new List<Materia>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }

        public List<Materia> GerarListaEntrePontos(int min, int max, int quantidade)
        {
            List<Materia> resultado = new List<Materia>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(GerarEntrePontos(min, max));
            }

            return resultado;
        }
    }
}
