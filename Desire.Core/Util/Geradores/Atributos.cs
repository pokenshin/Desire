﻿using System;
using System.Collections.Generic;
using System.Text;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    public class GeradorForca : IGerador<Forca>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorBoolean rbg = new GeradorBoolean();
        GeradorString rsg = new GeradorString();
        GeradorValorMag rvmg = new GeradorValorMag();

        public Forca Gerar(Random rnd)
        {
            Forca atributo = new Forca()
            {
                Sustentacao = rvmg.Gerar(rnd),
                Classe = Convert.ToChar(rsg.GerarTamanhoEspecifico(1, 1, rnd)),
                Dureza = rvmg.Gerar(rnd),
                Golpe = rvmg.Gerar(rnd),
                Nivel = rng.GerarEntre(1, 5, rnd),
                Pontos = rng.GerarEntre(1, 100, rnd),
                Porcentagem = rvmg.Gerar(rnd),
                Potencia = rvmg.Gerar(rnd),
                Vigor = rvmg.Gerar(rnd),
                Evolucao = new Evolucao(rng.GerarEntre(1, 17, rnd), 16, rbg.GeraComChance(10, rnd)),
                BonusAP = rvmg.Gerar(rnd)
            };
            return atributo;
        }

        public List<Forca> GerarLista(int quantidade, Random rnd)
        {
            List<Forca> resultado = new List<Forca>();
            for (int i = 0; i < quantidade-1; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }

    public class GeradorCriatividade : IGerador<Criatividade>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorBoolean rbg = new GeradorBoolean();
        GeradorString rsg = new GeradorString();
        GeradorValorMag rvmg = new GeradorValorMag();

        public Criatividade Gerar(Random rnd)
        {
            Criatividade atributo = new Criatividade()
            {
                Classe = Convert.ToChar(rsg.GerarTamanhoEspecifico(1, 1, rnd)),
                Invencao = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Nivel = rng.GerarEntre(1, 5, rnd),
                Pontos = rng.GerarEntre(1, 100, rnd),
                Porcentagem = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Realidade = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Singularidade = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Tutor = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Visualizacao = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Evolucao = new Evolucao(rng.GerarEntre(1, 17, rnd), 16, rbg.GeraComChance(10, rnd)),
                BonusMP = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd)
            };
            return atributo;
        }

        public List<Criatividade> GerarLista(int quantidade, Random rnd)
        {
            List<Criatividade> resultado = new List<Criatividade>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }

    public class GeradorDestreza : IGerador<Destreza>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorBoolean rbg = new GeradorBoolean();
        GeradorString rsg = new GeradorString();
        GeradorValorMag rvmg = new GeradorValorMag();

        public Destreza Gerar(Random rnd)
        {
            Destreza atributo = new Destreza()
            {
                Ataque = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Classe = Convert.ToChar(rsg.GerarTamanhoEspecifico(1, 1, rnd)),
                Esquiva = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Iniciativa = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Nivel = rng.GerarEntre(1, 5, rnd),
                Pontos = rng.GerarEntre(1, 100, rnd),
                Porcentagem = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Dinamica = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Reflexo = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Evolucao = new Evolucao(rng.GerarEntre(1, 17, rnd), 16, rbg.GeraComChance(10, rnd)),
                BonusAP = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd)
            };
            return atributo;
        }

        public List<Destreza> GerarLista(int quantidade, Random rnd)
        {
            List<Destreza> resultado = new List<Destreza>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }

    public class GeradorExistencia : IGerador<Existencia>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorBoolean rbg = new GeradorBoolean();
        GeradorString rsg = new GeradorString();
        GeradorValorMag rvmg = new GeradorValorMag();

        public Existencia Gerar(Random rnd)
        {
            Existencia atributo = new Existencia()
            {
                Ciencia = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Classe = Convert.ToChar(rsg.GerarTamanhoEspecifico(1, 1, rnd)),
                Conhecimento = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Consciencia = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Experiencia = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Nivel = rng.GerarEntre(1, 5, rnd),
                Pontos = rng.GerarEntre(1, 100, rnd),
                Plano = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Porcentagem = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Evolucao = new Evolucao(rng.GerarEntre(1, 17, rnd), 16, rbg.GeraComChance(10, rnd)),
                BonusAP = rvmg.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd)
            };
            return atributo;
        }

        public List<Existencia> GerarLista(int quantidade, Random rnd)
        {
            List<Existencia> resultado = new List<Existencia>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }

    public class GeradorIdeia : IGerador<Ideia>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorBoolean rbg = new GeradorBoolean();
        GeradorString rsg = new GeradorString();
        GeradorValorMag rvmg = new GeradorValorMag();

        public Ideia Gerar(Random rnd)
        {
            Ideia atributo = new Ideia()
            {
                Base = rvmg.Gerar(rnd),
                Nivel = rng.GerarEntre(1, 5, rnd),
                Pontos = rng.GerarEntre(1, 100, rnd),
                Porcentagem = rvmg.Gerar(rnd),
                Evolucao = new Evolucao(rng.GerarEntre(1, 17, rnd), 16, rbg.GeraComChance(10, rnd)),
                Classe = Convert.ToChar(rsg.GerarTamanhoEspecifico(1, 1, rnd)),
                Irrealidade = rvmg.Gerar(rnd),
                Ki = rvmg.Gerar(rnd),
                Misterio = rvmg.Gerar(rnd),
                Nexo = rvmg.Gerar(rnd),
                BonusMP = rvmg.Gerar(rnd)
            };
            return atributo;
        }

        public List<Ideia> GerarLista(int quantidade, Random rnd)
        {
            List<Ideia> resultado = new List<Ideia>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }

    public class GeradorIntelecto : IGerador<Intelecto>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorBoolean rbg = new GeradorBoolean();
        GeradorString rsg = new GeradorString();
        GeradorValorMag rvmg = new GeradorValorMag();

        public Intelecto Gerar(Random rnd)
        {
            Intelecto atributo = new Intelecto()
            {
                Nivel = rng.GerarEntre(1, 5, rnd),
                Pontos = rng.GerarEntre(1, 100, rnd),
                Porcentagem = rvmg.Gerar(rnd),
                Evolucao = new Evolucao(rng.GerarEntre(1, 17, rnd), 16, rbg.GeraComChance(10, rnd)),
                Classe = Convert.ToChar(rsg.GerarTamanhoEspecifico(1, 1, rnd)),
                Aprendizagem = rvmg.Gerar(rnd),
                Concentracao = rvmg.Gerar(rnd),
                Eidos = rvmg.Gerar(rnd),
                Memoria = rvmg.Gerar(rnd),
                Senso = rvmg.Gerar(rnd),
                BonusAP = rvmg.Gerar(rnd)
            };
            return atributo;
        }

        public List<Intelecto> GerarLista(int quantidade, Random rnd)
        {
            List<Intelecto> resultado = new List<Intelecto>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }

    public class GeradorMateria : IGerador<Materia>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorBoolean rbg = new GeradorBoolean();
        GeradorString rsg = new GeradorString();
        GeradorValorMag rvmg = new GeradorValorMag();

        public Materia Gerar(Random rnd)
        {
            Materia atributo = new Materia()
            {
                Nivel = rng.GerarEntre(1, 5, rnd),
                Pontos = rng.GerarEntre(1, 100, rnd),
                Porcentagem = rvmg.Gerar(rnd),
                Evolucao = new Evolucao(rng.GerarEntre(1, 17, rnd), 16, rbg.GeraComChance(10, rnd)),
                Classe = Convert.ToChar(rsg.GerarTamanhoEspecifico(1, 1, rnd)),
                Colapso = rvmg.Gerar(rnd),
                Impulso = rvmg.Gerar(rnd),
                Carga = rvmg.Gerar(rnd),
                Resistencia = rvmg.Gerar(rnd),
                Vitalidade = rvmg.Gerar(rnd),
                BonusHP = rvmg.Gerar(rnd),
                BonusAP = rvmg.Gerar(rnd)
            };
            return atributo;
        }

        public List<Materia> GerarLista(int quantidade, Random rnd)
        {
            List<Materia> resultado = new List<Materia>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}
