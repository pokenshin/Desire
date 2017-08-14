using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesireWebApp.Models;
using System.Diagnostics;
using Desire.Core;
using Desire.Core.Itens;
using Desire.Core.Geradores;
using Desire.Core.Calculos;
using System.Collections.Generic;
using System.Linq;

namespace Desire.Test
{
    [TestClass]
    public class ValoresTeste
    {
        Valor valor;

        //Testa a função ExtraiValorListaEspecies para ver se ela está pegando o maior valor de uma lista de espécies
        //Resultado esperado: ela retornar o valor 90
        [TestMethod]
        public void TesteExtraiValorListaEspeciesMaiorValorKarmaMax()
        {
            valor = new Valor();
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

        //Testa a função CalculaPorcentagem para ver se ela retorna a porcentagem certa de um valor
        //Resultado esperado: dado 20% de 133, retornar 26 (arredondado de 26.6)
        [TestMethod]
        public void TesteCalculaPorcentagem()
        {
            valor = new Valor();
            long resultado = valor.CalculaPorcentagem(20, 133);

            Assert.IsTrue(resultado == 26);
        }

        //Testa a função CalculaSubatributos para ver se ela está calculando corretamente cada um dos subatributos (sem modificadores)
        //Resultado esperado: variavel de acordo com cada especificação
        [TestMethod]
        public void TesteCalculaSubatributosSemMod()
        {
            valor = new Valor();
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



            ser = valor.CalculaSubatributos(ser);

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
            valor = new Valor();
            Gerador gerador = new Gerador();
            Ser ser = gerador.GeraSerAleatorio();

            ser = valor.CalculaSubatributos(ser);

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
            valor = new Valor();
            int novo = 10;
            int maduro = 30;
            int velho = 75;

            Especie especie = new Especie()
            {
                TempoMax = 100,
                MaturidadeMin = 20,
                MaturidadeMax = 50
            };

            double resultadoNovo = valor.CalculaFatorMaturidade(novo, especie);
            double resultadoMaduro = valor.CalculaFatorMaturidade(maduro, especie);
            double resultadoVelho = valor.CalculaFatorMaturidade(velho, especie);

            Assert.IsTrue(resultadoNovo == 0.5);
            Assert.IsTrue(resultadoMaduro == 1);
            Assert.IsTrue(resultadoVelho == 0.5);
        }

        //Verifica o resultado da soma de dois ValorMag
        [TestMethod]
        public void TesteSomaValorMag()
        {
            valor = new Valor();
            ValorMag valorMagIgual1 = new ValorMag(50, 2);
            ValorMag valorMagIgual2 = new ValorMag(60, 2);
            ValorMag resultadoMagIgual = valor.SomaValorMag(valorMagIgual1, valorMagIgual2);

            Assert.IsTrue(resultadoMagIgual.Valor == 11);
            Assert.IsTrue(resultadoMagIgual.Magnitude == 3);
            Assert.IsTrue(resultadoMagIgual.ValorReal == "110");

            ValorMag valorMagPerto1 = new ValorMag(50, 4);
            ValorMag valorMagPerto2 = new ValorMag(50, 3);
            ValorMag resultadoMagPerto = valor.SomaValorMag(valorMagPerto1, valorMagPerto2);

            Assert.IsTrue(resultadoMagPerto.Valor == 55);
            Assert.IsTrue(resultadoMagPerto.Magnitude == 4);
            Assert.IsTrue(resultadoMagPerto.ValorReal == "5500");

            ValorMag valorMagLonge1 = new ValorMag(50, 3);
            ValorMag valorMagLonge2 = new ValorMag(50, 8);
            ValorMag resultadoMagLonge = valor.SomaValorMag(valorMagLonge1, valorMagLonge2);

            Assert.IsTrue(resultadoMagLonge.Valor == 50);
            Assert.IsTrue(resultadoMagLonge.Magnitude == 8);
            Assert.IsTrue(resultadoMagLonge.ValorReal == "50000000");
        }

        //Verifica o resultado da multiplicação de dois ValorMag
        [TestMethod]
        public void TesteMultiplicaValorMagPorValorMag()
        {
            valor = new Valor();
            ValorMag valorMag1 = new ValorMag(10, 3);
            ValorMag valorMag2 = new ValorMag(10, 5);
            ValorMag resultado = valor.MultiplicaValorMag(valorMag1, valorMag2);

            Assert.AreEqual(10, resultado.Valor);
            Assert.AreEqual(7, resultado.Magnitude);
            Assert.AreEqual("1000000", resultado.ValorReal);
        }

        //Verifica o resultado da divisão de dois ValorMag
        [TestMethod]
        public void TesteDivideValorMagPorValorMag()
        {
            valor = new Valor();
            ValorMag valorMag1 = new ValorMag(10, 5);
            ValorMag valorMag2 = new ValorMag(10, 3);
            ValorMag resultado = valor.DivideValorMag(valorMag1, valorMag2);

            Assert.AreEqual(10, resultado.Valor);
            Assert.AreEqual(3, resultado.Magnitude);
            Assert.AreEqual("100", resultado.ValorReal);
        }

    }
}
