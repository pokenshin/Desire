using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesireWebApp.Models;
using System.Diagnostics;
using Desire.Core;
using Desire.Core.Itens;
using Desire.Core.Geradores;
using Desire.Core.Calculadores;
using System.Collections.Generic;
using System.Linq;

namespace Desire.Test
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
            Gerador gerador = new Gerador();
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

        //Testa a função CalculaSubatributos para ver se ela está calculando corretamente cada um dos subatributos (sem modificadores)
        //Resultado esperado: variavel de acordo com cada especificação
        [TestMethod]
        public void TesteCalculaSubatributosSemMod()
        {
            calculador = new CalculadorSer();
            Gerador gerador = new Gerador();
            Ser ser = new Ser()
            {
                Destreza = (Destreza)gerador.GeraAtributo("Destreza"),
                Forca = (Forca)gerador.GeraAtributo("Força"),
                Materia = (Materia)gerador.GeraAtributo("Materia"),
                Ideia = (Ideia)gerador.GeraAtributo("Idéia"),
                Criatividade = (Criatividade)gerador.GeraAtributo("Criatividade"),
                Existencia = (Existencia)gerador.GeraAtributo("Existência"),
                Intelecto = (Intelecto)gerador.GeraAtributo("Intelecto"),
                Nivel = gerador.GeraInteiro(1, 50)
            };
            

            List<Especie> listaEspecies = new List<Especie>
            {
                new Especie()
                {
                    AcaoMin = 2,
                    TurnoMin = 1,
                    AlturaMin = new ValorMag(20, 2),
                    AlturaMax = new ValorMag(25, 3),
                    LarguraMin = new ValorMag(20, 2),
                    LarguraMax = new ValorMag(25, 3),
                    TempoMax = 100,
                    MaturidadeMin = 20,
                    MaturidadeMax = 50,
                    Porcentagem = 50,
                    DestriaMax = 4,
                    Densidade = new ValorMag(10, 2)
                },

                new Especie()
                {
                    AcaoMin = 5,
                    TurnoMin = 5,
                    AlturaMin = new ValorMag(30, 2),
                    AlturaMax = new ValorMag(30, 3),
                    LarguraMin = new ValorMag(30, 2),
                    LarguraMax = new ValorMag(30, 3),
                    TempoMax = 200,
                    MaturidadeMin = 10,
                    MaturidadeMax = 190,
                    Porcentagem = 45,
                    DestriaMax = 4,
                    Densidade = new ValorMag(80, 1)
                },

                new Especie()
                {
                    AlturaMin = new ValorMag(10, 2),
                    AlturaMax = new ValorMag(10, 3),
                    LarguraMin = new ValorMag(10, 2),
                    LarguraMax = new ValorMag(10, 3),
                    TempoMax = 300,
                    MaturidadeMin = 100,
                    MaturidadeMax = 299,
                    Porcentagem = 5,
                    DestriaMax = 2,
                    Densidade = new ValorMag(15, 2)
                }
            };
            ser.Especies = listaEspecies;
            ser.Tempo = 32;



            ser = calculador.CalculaSubatributos(ser);

            //Iniciativa = Destreza.Iniciativa
            Assert.AreEqual(ser.Destreza.Iniciativa.Valor, ser.Iniciativa.Valor);
            Assert.AreEqual(ser.Destreza.Iniciativa.Magnitude, ser.Iniciativa.Magnitude);
            //Destria = Pontos Destreza / 10
            Assert.IsTrue(ser.Destria < 5);
            //Acao = valor minimo da especie dominante + 20% da maior especie
            Assert.AreEqual(3, ser.Acao);
            //Turno = valor minimo da especie dominante + 20% da maior especie
            Assert.AreEqual(2, ser.Turno);
            //Altura
            //Largura = Minimo da Especie * % (Materia*2 + Forca) /3
        }

        //Calcula a geração de subatributos de um ser baseado em um ser gerado aleatóriamente
        //Somente para ver se todos os campos estão sendo preenchidos com valores não-nulos
        [TestMethod]
        public void TesteCalculaSubatributosAleatorio()
        {
            calculador = new CalculadorSer();
            Gerador gerador = new Gerador();
            Ser ser = gerador.GeraSerAleatorio();

            ser = calculador.CalculaSubatributos(ser);

            Assert.IsNotNull(ser.Iniciativa);
            Assert.IsNotNull(ser.Destria);
            Assert.IsNotNull(ser.Acao);
            Assert.IsNotNull(ser.Turno);
            Assert.IsNotNull(ser.Espaco);
            Assert.IsNotNull(ser.Instinto);
            Assert.IsNotNull(ser.Raciocinio);
            Assert.IsNotNull(ser.Subconsciencia);
            Assert.IsNotNull(ser.Autocontrole);
            Assert.IsNotNull(ser.Trabalho);
            Assert.IsNotNull(ser.Altura);
            Assert.IsNotNull(ser.Largura);
            Assert.IsNotNull(ser.Comprimento);
            Assert.IsNotNull(ser.Volume);
            Assert.IsNotNull(ser.Anatomia);
            Assert.IsNotNull(ser.Animo);
            Assert.IsNotNull(ser.Movimento);
            Assert.IsNotNull(ser.Precisao);
            Assert.IsNotNull(ser.Essencia);
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

            Ser ser = new Ser();

            ser.Especies = especies;

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
                        ReacaoMin = new Reacao()
                        {
                            Bravura = new ValorMag(10, 5),
                            Coragem = new ValorMag(15, 5),
                            Desespero = new ValorMag(20, 5),
                            Heroismo = new ValorMag(25, 8),
                            Indiferenca = new ValorMag(30, 5),
                            Medo = new ValorMag(35, 5),
                            Panico = new ValorMag(40, 5),
                        }
                    },

                    new Especie()
                    {
                        ReacaoMin = new Reacao()
                        {
                            Bravura = new ValorMag(10, 8),
                            Coragem = new ValorMag(15, 7),
                            Desespero = new ValorMag(20, 6),
                            Heroismo = new ValorMag(25, 5),
                            Indiferenca = new ValorMag(30, 4),
                            Medo = new ValorMag(35, 3),
                            Panico = new ValorMag(40, 2),
                        }
                    },

                    new Especie()
                    {
                        ReacaoMin = new Reacao()
                        {
                            Bravura = new ValorMag(10, 2),
                            Coragem = new ValorMag(15, 3),
                            Desespero = new ValorMag(20, 4),
                            Heroismo = new ValorMag(25, 5),
                            Indiferenca = new ValorMag(30, 6),
                            Medo = new ValorMag(35, 7),
                            Panico = new ValorMag(40, 8),
                        }
                    }
                }
            };

            ser.Reacao = calculador.CalculaReacao(ser);

            Assert.AreEqual(10, ser.Reacao.Bravura.Valor);
            Assert.AreEqual(8, ser.Reacao.Bravura.Magnitude);
            Assert.AreEqual(15, ser.Reacao.Coragem.Valor);
            Assert.AreEqual(7, ser.Reacao.Coragem.Magnitude);
            Assert.AreEqual(20, ser.Reacao.Desespero.Valor);
            Assert.AreEqual(6, ser.Reacao.Desespero.Magnitude);
            Assert.AreEqual(25, ser.Reacao.Heroismo.Valor);
            Assert.AreEqual(8, ser.Reacao.Heroismo.Magnitude);
            Assert.AreEqual(30, ser.Reacao.Indiferenca.Valor);
            Assert.AreEqual(6, ser.Reacao.Indiferenca.Magnitude);
            Assert.AreEqual(35, ser.Reacao.Medo.Valor);
            Assert.AreEqual(7, ser.Reacao.Medo.Magnitude);
            Assert.AreEqual(40, ser.Reacao.Panico.Valor);
            Assert.AreEqual(8, ser.Reacao.Panico.Magnitude);
        }

        //Testa o método CriaListaHabilidades para ver se está pegando todas as habilidades da especie do ser
        [TestMethod]
        public void TesteCriaListaHabilidades()
        {
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
                                Nome = "Habilidade 3 Especie 3"
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
                                Sigla = "HP"
                            },
                            new Energia()
                            {
                                Sigla = "MP"
                            },
                            new Energia()
                            {
                                Sigla = "AP"
                            },
                            new Energia()
                            {
                                Sigla = "SP"
                            }
                        }
                    },

                    new Especie()
                    {
                        Energias = new List<Energia>
                        {
                            new Energia()
                            {
                                Sigla = "DP"
                            },
                            new Energia()
                            {
                                Sigla = "SP"
                            }
                        }
                    },

                    new Especie()
                    {
                        Energias = new List<Energia>
                        {
                            new Energia()
                            {
                                Sigla = "MP"
                            },
                            new Energia()
                            {
                                Sigla = "SP"
                            }
                        }
                    }
                }
            };

            ser.Energias = calculador.CriaListaEnergias(ser);

            Assert.AreEqual(5, ser.Habilidades.Count);
        }

        //Testa o cálculo do HP base de um ser
        [TestMethod]
        public void TesteCalculaValorBaseEnergiasHP()
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
                                Quantidade = 1200
                            }
                        }
                    },

                    new Especie()
                    {
                        Energias = new List<Energia>
                        {
                            new Energia()
                            {
                                Sigla = "HP",
                                Quantidade = 200
                            }
                        }
                    }
                }
            };




        }
    }
}
