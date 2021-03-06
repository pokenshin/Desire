﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Desire.Core;
using Desire.Util.Calculadores;
using System.Collections.Generic;
using System.Linq;
using Desire.Core.Identidade;
using Desire.Core.Ciencias;
using Desire.Util.Geradores;
using Desire.Core.Energias;

namespace Desire.Test.Util.Calculadores
{
    [TestClass]
    public class CalculadorSerTestes
    {
        CalculadorSer calculador;

        //Testa a função ExtraiValorListaEspecies para ver se ela está pegando o maior valor de uma lista de espécies
        //Resultado esperado: ela retornar o valor 90
        [TestMethod]
        public void TesteExtraiValorListaEspeciesMaiorValorKarmaMax()
        {
            calculador = new CalculadorSer();
            List<Especie> listaEspecies = new List<Especie>();

            for (int i = 0; i < 10; i++)
            {
                Especie especie = new Especie()
                {
                    Id = i,
                    KarmaMax = i * 10
                };
                listaEspecies.Add(especie);
            }

            int resultado = (from e in listaEspecies select e.KarmaMax).Max();

            Assert.IsTrue(resultado == 90);
        }

        //Calcula a geração de subatributos de um ser baseado em um ser gerado aleatóriamente
        //Somente para ver se todos os campos estão sendo preenchidos com valores não-nulos
        [TestMethod]
        public void TesteCalculaSubatributosAleatorio()
        {
            Random rnd = new Random();
            calculador = new CalculadorSer();
            GeradorSer gerador = new GeradorSer();
            Ser ser = gerador.Gerar(rnd);

            Assert.IsNotNull(ser.Iniciativa);
            Assert.IsNotNull(ser.Destria);
            Assert.IsNotNull(ser.Acao);
            Assert.IsNotNull(ser.Turno);
            Assert.IsNotNull(ser.Instinto);
            Assert.IsNotNull(ser.Raciocinio);
            Assert.IsNotNull(ser.Subconsciencia);
            Assert.IsNotNull(ser.Autocontrole);
            Assert.IsNotNull(ser.Altura);
            Assert.IsNotNull(ser.Largura);
            Assert.IsNotNull(ser.Comprimento);
            Assert.IsNotNull(ser.Anatomia);
            Assert.IsNotNull(ser.Animo);
            Assert.IsNotNull(ser.Movimento);
            Assert.IsNotNull(ser.Precisao);
            Assert.IsNotNull(ser.Massa);
        }


        //Testa a função CalculaFatorMaturidade para ver se ela está calculando um fator correto
        //Resultado esperado: 0.5 para 10 anos, 
        [TestMethod]
        public void TesteCalculaFatorIdadeEspecie()
        {
            calculador = new CalculadorSer();
            int novo = 10;
            int maduro = 30;
            int velho = 75;

            Especie especie = new Especie()
            {
                TempoMax = 100,
                MaturidadeMin = 20,
                MaturidadeMax = 50
            };

            double resultadoNovo = calculador.CalculaFatorMaturidade(novo, especie);
            double resultadoMaduro = calculador.CalculaFatorMaturidade(maduro, especie);
            double resultadoVelho = calculador.CalculaFatorMaturidade(velho, especie);

            Assert.IsTrue(resultadoNovo == 0.5);
            Assert.IsTrue(resultadoMaduro == 1);
            Assert.IsTrue(resultadoVelho == 0.5);
        }

        //Verifica o resultado da função CalculaKarma
        [TestMethod]
        public void TesteCalculaKarma()
        {
            calculador = new CalculadorSer();
            List<Especie> especies = new List<Especie>()
            {
                new Especie()
                {
                    KarmaMin = 1
                },
                new Especie()
                {
                    KarmaMin = 2
                },
                new Especie()
                {
                    KarmaMin = 3
                },
            };

            Ser ser = new Ser()
            {
                Especies = especies,
            };

            ser.Karma = calculador.CalculaKarma(ser);

            Assert.AreEqual(3, ser.Karma);
        }

        //Testa o calculo da experiência de um ser
        [TestMethod]
        public void TesteCalculaExperiencia()
        {
            calculador = new CalculadorSer();

            Ser ser = new Ser()
            {
                Magnitude = 2,
                Nivel = 25
            };

            ser = calculador.CalculaExperiencia(ser);

            Assert.AreEqual(100, ser.PontosGraduacao);
            Assert.AreEqual(2500, ser.PontosEvolucao);
            Assert.AreEqual(30000, ser.ExperienciaAtual);
        }

        //Testa a geração de uma reação para um determinado ser sem modificadores
        [TestMethod]
        public void TesteCalculaReacao()
        {
            calculador = new CalculadorSer();

            Ser ser = new Ser()
            {
                Especies = new List<Especie>
                {
                    new Especie()
                    {
                        RespostaMin = new Resposta()
                        {
                            Bravura = 1,
                            Coragem = 2,
                            Desespero = 3,
                            Heroismo = 4,
                            Indiferenca = 5,
                            Medo = 6,
                            Panico = 7,
                        }
                    },

                    new Especie()
                    {
                        RespostaMin = new Resposta()
                        {
                            Bravura = 8,
                            Coragem = 7,
                            Desespero = 6,
                            Heroismo = 5,
                            Indiferenca = 4,
                            Medo = 3,
                            Panico = 2,
                        }
                    },

                    new Especie()
                    {
                        RespostaMin = new Resposta()
                        {
                            Bravura = 4,
                            Coragem = 6,
                            Desespero = 2,
                            Heroismo = 1,
                            Indiferenca = 8,
                            Medo = 9,
                            Panico = 2,
                        }
                    }
                }
            };

            ser.Resposta = calculador.CalculaResposta(ser);

            Assert.AreEqual(8, ser.Resposta.Bravura);
            Assert.AreEqual(7, ser.Resposta.Coragem);
            Assert.AreEqual(6, ser.Resposta.Desespero);
            Assert.AreEqual(5, ser.Resposta.Heroismo);
            Assert.AreEqual(8, ser.Resposta.Indiferenca);
            Assert.AreEqual(9, ser.Resposta.Medo);
            Assert.AreEqual(7, ser.Resposta.Panico);
        }

        //Testa o método CriaListaHabilidades para ver se está pegando todas as habilidades da especie do ser
        [TestMethod]
        public void TesteCriaListaHabilidades()
        {
            calculador = new CalculadorSer();
            Ser ser = new Ser()
            {
                Especies = new List<Especie>
                {
                    new Especie()
                    {
                        HabilidadesEspecie = new List<Habilidade>
                        {
                            new Habilidade()
                            {
                                Id = 1,
                                Nome = "Habilidade 1 Especie 1"
                            },

                            new Habilidade()
                            {
                                Id = 2,
                                Nome = "Habilidade 2 Especie 1"
                            },

                            new Habilidade()
                            {
                                Id = 3,
                                Nome = "Habilidade 3 Especie 1"
                            }
                        }
                    },

                    new Especie()
                    {
                        HabilidadesEspecie = new List<Habilidade>
                        {
                            new Habilidade()
                            {
                                Id = 3,
                                Nome = "Habilidade 3 Especie 2"
                            },

                            new Habilidade()
                            {
                                Id = 4,
                                Nome = "Habilidade 4 Especie 2"
                            },

                            new Habilidade()
                            {
                                Id = 5,
                                Nome = "Habilidade 5 Especie 2"
                            }
                        }
                    },

                    new Especie()
                    {
                        HabilidadesEspecie = new List<Habilidade>
                        {
                            new Habilidade()
                            {
                                Id = 1,
                                Nome = "Habilidade 1 Especie 3"
                            },

                            new Habilidade()
                            {
                                Id = 2,
                                Nome = "Habilidade 2 Especie 3"
                            },

                            new Habilidade()
                            {
                                Id = 6,
                                Nome = "Habilidade 6 Especie 3"
                            }
                        }
                    }
                }
            };

            ser.Habilidades = calculador.CriaListaHabilidades(ser);

            Assert.AreEqual(6, ser.Habilidades.Count);
        }

        //Testa o método CriaListaEnergias para ver se está pegando todas as energias da especie do ser
        [TestMethod]
        public void TesteCriaListaEnergias()
        {
            calculador = new CalculadorSer();
            Ser ser = new Ser()
            {
                Especies = new List<Especie>
                {
                    new Especie()
                    {
                        Energias = new List<Energia>
                        {
                            new Energia()
                            {
                                Sigla = "HP",
                                Quantidade = 1000

                            },
                            new Energia()
                            {
                                Sigla = "MP",
                                Quantidade = 100
                            },
                            new Energia()
                            {
                                Sigla = "AP",
                                Quantidade = 10
                            },
                            new Energia()
                            {
                                Sigla = "SP",
                                Quantidade = 10000
                            }
                        }
                    },

                    new Especie()
                    {
                        Energias = new List<Energia>
                        {
                            new Energia()
                            {
                                Sigla = "DP",
                                Quantidade = 10200
                            },
                            new Energia()
                            {
                                Sigla = "SP",
                                Quantidade = 102
                            }
                        }
                    },

                    new Especie()
                    {
                        Energias = new List<Energia>
                        {
                            new Energia()
                            {
                                Sigla = "MP",
                                Quantidade = 100012
                            },
                            new Energia()
                            {
                                Sigla = "SP",
                                Quantidade = 10001
                            }
                        }
                    }
                },
                BonusCP = 300000,
                BonusHP = new ValorMag(95, 5),
                BonusMP = new ValorMag(19, 4),
                BonusSP = 10,
                Nivel = 3
            };

            ser.Energias = calculador.CriaListaEnergias(ser);

            Assert.AreEqual(5, ser.Energias.Count);
        }
    }
}
