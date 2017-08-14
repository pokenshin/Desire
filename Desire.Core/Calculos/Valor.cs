using Desire.Core.Geradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace Desire.Core.Calculos
{
    public class Valor
    {
        public List<Energia> CriaListaEnergiasSer(Ser ser)
        {
            //TODO: Juntar energias da espécie, perícias, dons, itens e rei
            List<Energia> energias = new List<Energia>();

            return energias;
        }

        public List<Pericia> CriaListaPericiasSer(Ser ser)
        {
            //TODO:  Juntar pericias da Classe, da Espécie, Dom, Itens, Rei
            List<Pericia> pericias = new List<Pericia>();

            return pericias;
        }

        public List<Deslocamento> CriaListaDeslocamentosSer(Ser ser)
        {
            //TODO: Calcular lista de deslocamentos e valores baseado na espécie do ser
            List<Deslocamento> deslocamentos = new List<Deslocamento>();

            return deslocamentos;
        }

        public int CalculaEspecial(Ser ser)
        {
            //TODO: Pegar todos os especiais da espécie do ser e pegar o maior número de especial
            int especial = 0;

            return especial;
        }

        //Calcula subatributos BASE de um ser sem modificadores
        public Ser CalculaSubatributos(Ser ser)
        {
            Gerador gerador = new Gerador();
            //Iniciativa = Destreza.Iniciativa
            ser.Iniciativa = ser.Destreza.Iniciativa;

            //Destria = Pontos Destreza / 10 (até o maximo da espécie)
            if (ser.Destreza.Pontos / 10 > ser.Especies[0].DestriaMax)
                ser.Destria = ser.Especies[0].DestriaMax;
            else if (ser.Destreza.Pontos / 10 < ser.Especies[0].DestriaMin)
                ser.Destria = ser.Especies[0].DestriaMin;
            else
                ser.Destria = ser.Destreza.Pontos / 10;

            //Acao = valor minimo da especie dominante + 20% da maior especie
            ser.Acao = ser.Especies[0].AcaoMin + (int)CalculaPorcentagem(20, (long)(from e in ser.Especies select e.AcaoMin).Max());
            //Turno = valor minimo da especie dominante + 20% da maior especie
            ser.Turno = ser.Especies[0].TurnoMin + (int)CalculaPorcentagem(20, (long)(from e in ser.Especies select e.TurnoMin).Max());
            //ser.Turno.Valor = (from e in ser.Especies select e.TurnoMin).Max();

            //Caracteristicas Fisicas
            ser.Altura = gerador.GeraValorMag(ser.Especies[0].AlturaMin, ser.Especies[0].AlturaMax);

            //Comprimento = Pontos em matéria
            ser.Comprimento = new ValorMag(Convert.ToString(ser.Materia.Pontos));

            //TODO: Verificar a possibilidade de retirar espaço e deixar só volume
            //Volume = (Comprimento * Altura)
            //Espaço = (Comprimento * Altura)
            //ser.Volume = new ValorMag(ser.Largura.ValorReal * ser.Comprimento.ValorReal * ser.Altura.ValorReal);
            ser.Volume = MultiplicaValorMag(ser.Largura, ser.Comprimento);
            ser.Volume = MultiplicaValorMag(ser.Volume, ser.Altura);
            ser.Espaco = ser.Volume;

            //Largura = Aleatorio entre largura min e largura max da especie dominante
            ser.Largura = gerador.GeraValorMag(ser.Especies[0].LarguraMin, ser.Especies[0].LarguraMax);

            //Massa = Volume * Densidade da Especie
            ser.Massa = MultiplicaValorMag(ser.Volume, ser.Especies[0].Densidade);

            //Instinto = (Ideia + Destreza) / 2
            ser.Instinto = SomaValorMag(ser.Ideia.Porcentagem, ser.Destreza.Porcentagem);
            ser.Instinto = DivideValorMag(ser.Instinto, 2);

            //Raciocinio = (Intelecto + Criatividade) / 2
            ser.Raciocinio = SomaValorMag(ser.Intelecto.Porcentagem, ser.Criatividade.Porcentagem);
            ser.Raciocinio = DivideValorMag(ser.Raciocinio, 2);

            //Subconsciencia = (Existencia + Ideia) / 2
            ser.Subconsciencia = SomaValorMag(ser.Existencia.Porcentagem, ser.Ideia.Porcentagem);
            ser.Subconsciencia = DivideValorMag(ser.Subconsciencia, 2);

            //Autocontrole = (Intelecto + Existencia) / 2
            ser.Autocontrole = SomaValorMag(ser.Intelecto.Porcentagem, ser.Existencia.Porcentagem);
            ser.Autocontrole = DivideValorMag(ser.Subconsciencia, 2);

            //Trabalho = PA onde r = (Pts Força + Pts Destreza + Pts Vitalidade) / 3 , n = nivel
            //Formula PA: An = A1 + (n - 1) * r
            int trabalhoRazao = (ser.Forca.Pontos + ser.Destreza.Pontos + ser.Materia.Pontos) / 3;
            int trabalhoN = ser.Nivel;
            decimal trabalhoA1 = ser.Especies[0].TrabalhoMin;
            ser.Trabalho = Math.Floor(CalculaPA(trabalhoA1, trabalhoN, trabalhoRazao));

            //Anatomia = (Materia + Força + Destreza) /3
            ser.Anatomia = SomaValorMag(ser.Materia.Porcentagem, ser.Forca.Porcentagem);
            ser.Anatomia = SomaValorMag(ser.Anatomia, ser.Destreza.Porcentagem);
            ser.Anatomia = DivideValorMag(ser.Anatomia, 3);

            //Animo = (Criatividade + Existencia)/2
            ser.Animo = SomaValorMag(ser.Criatividade.Porcentagem, ser.Existencia.Porcentagem);
            ser.Animo = DivideValorMag(ser.Animo, 2);

            //Movimento = (Destreza + Forca*2) /3
            ser.Movimento = MultiplicaValorMag(ser.Forca.Porcentagem, 2);
            ser.Movimento = SomaValorMag(ser.Movimento, ser.Destreza.Porcentagem);
            ser.Movimento = DivideValorMag(ser.Movimento, 3);

            //Precisao = (Forca*2 + Destreza) / 3
            ser.Movimento = MultiplicaValorMag(ser.Destreza.Porcentagem, 2);
            ser.Movimento = SomaValorMag(ser.Movimento, ser.Forca.Porcentagem);
            ser.Movimento = DivideValorMag(ser.Movimento, 3);

            //Essencia = todos os atributos / 7
            ser.Essencia = SomaValorMag(ser.Forca.Porcentagem, ser.Destreza.Porcentagem);
            ser.Essencia = SomaValorMag(ser.Essencia, ser.Materia.Porcentagem);
            ser.Essencia = SomaValorMag(ser.Essencia, ser.Intelecto.Porcentagem);
            ser.Essencia = SomaValorMag(ser.Essencia, ser.Criatividade.Porcentagem);
            ser.Essencia = SomaValorMag(ser.Essencia, ser.Ideia.Porcentagem);
            ser.Essencia = SomaValorMag(ser.Essencia, ser.Existencia.Porcentagem);
            ser.Essencia = DivideValorMag(ser.Essencia, 7);

            return ser;
        }

        private decimal CalculaPA(decimal a1, int n, int r)
        {
            decimal resultado = 0;

            resultado = a1 + ((n - 1) * r);

            return resultado;
        }

        public ValorMag MultiplicaValorMag(ValorMag valorMag1, ValorMag valorMag2)
        {
            if (valorMag1.ValorReal == "1")
                return valorMag2;
            else if (valorMag2.ValorReal == "1")
                return valorMag1;
            else if (valorMag1.ValorReal == "0" || valorMag2.ValorReal == "1")
                return new ValorMag(0, 1);
            else
            {
                int magFinal = (valorMag1.Magnitude + valorMag2.Magnitude) - 4;

                int valorFinal = (valorMag1.Valor * valorMag2.Valor);
                while (valorFinal > 99)
                {
                    valorFinal = valorFinal / 10;
                    magFinal = magFinal + 1;
                }

                magFinal = magFinal + 2;

                return new ValorMag(valorFinal, magFinal);
            }
        }

        public ValorMag DivideValorMag(ValorMag valorMag1, ValorMag valorMag2)
        {
            if (valorMag1.ValorReal == "0")
                return new ValorMag("0");
            else if(valorMag2.ValorReal == "0")
                return new ValorMag("0");
            else if(valorMag2.ValorReal == "1")
                return valorMag1;
            else
            {
                int valorFinal = (int)Math.Floor((Decimal)valorMag1.Valor / (Decimal)valorMag2.Valor) / 10;
                int magFinal = (valorMag1.Magnitude - valorMag2.Magnitude);
                return new ValorMag(valorFinal, magFinal);
            }
        }

        public ValorMag DivideValorMag(ValorMag valorMag1, int divisor)
        {
            if (divisor == 0)
                return new ValorMag("0");
            if (divisor == 1)
                return valorMag1;
            else
            {
                return DivideValorMag(valorMag1, new ValorMag(Convert.ToString(divisor)));
            }
        }

        public ValorMag MultiplicaValorMag(ValorMag valorMag1, int multiplicador)
        {
            return null;
        }

        //Retorna a porcentagem de um determinado valor arredondado para baixo
        public long CalculaPorcentagem(int porcentagem, long valor)
        {
            double pct = (double)porcentagem / 100;
            double resultado = (double)valor * pct;
            return (int)Math.Floor(resultado);
        }

        public double CalculaPorcentagemDeTotal(long valor, long total )
        {
            return valor / total;
        }

        //Calcula uma faixa de altura para um determinado ser baseado nas especies dominantes e recessivas
        //Faixa de Altura Minima = Média ponderada de todas as raças
        //Faixa de Altura Maxima = Média ponderada de todas as raças * FatorMaturidade
        //public List<ValorMag> CalculaFaixaAltura(Ser ser)
        //{
        //    List<ValorMag> faixa = new List<ValorMag>();
        //    ValorMag somaAlturaMax = new ValorMag();
        //    ValorMag somaAlturaMin = new ValorMag();
            

        //    foreach (Especie especie in ser.Especies)
        //    {
        //        BigInteger alturaMin = especie.AlturaMin.ValorReal * especie.Porcentagem;
        //        somaAlturaMin = somaAlturaMin + alturaMin;
        //        BigInteger alturaMax = especie.AlturaMax.ValorReal * especie.Porcentagem;
        //        somaAlturaMax = somaAlturaMax + alturaMax;
        //    }

        //    BigInteger valor = somaAlturaMax / 100;
        //    valor = valor * (Decimal)CalculaFatorMaturidade(ser.Tempo, ser.Especies[0]);
        //    ValorMag faixaAlturaMin = new ValorMag(somaAlturaMin / 100);
        //    ValorMag faixaAlturaMax = new ValorMag(Math.Floor((somaAlturaMax / 100) * ));
        //    faixaAlturaMax = new ValorMag(faixaAlturaMax 

        //    faixa.Add(faixaAlturaMin);
        //    faixa.Add(faixaAlturaMax);

        //    return faixa;
        //}

        //Calcula o fator idade de um ser baseado nos limites da espécie.
        //Fator maturidade é a porcentagem de maturidade que o ser está para a espécie
        //Utilzado para somar em alguns subatributos onde a maturidade do ser é relevante
        public double CalculaFatorMaturidade(int tempo, Especie especie)
        {
            double fator = 0.0;
            double idade = (double)tempo;
            double maturidadeInicio = (double)especie.MaturidadeMin;
            double maturidadeFim = (double)especie.MaturidadeMax;

            if (idade < maturidadeInicio)
                fator = idade / maturidadeInicio;
            else if (idade > maturidadeFim)
                fator = (especie.TempoMax - tempo) / (especie.TempoMax - maturidadeFim);
            else
                fator = 1;

            return fator;
        }

        //Soma dois ValorMag
        public ValorMag SomaValorMag(ValorMag valorMag1, ValorMag valorMag2)
        {
            int valorFinal = 0;
            int magnitudeFinal = 0;
            int valor1 = valorMag1.Valor;
            int valor2 = valorMag2.Valor;
            int mag1 = valorMag1.Magnitude;
            int mag2 = valorMag2.Magnitude;

            if (mag1 == mag2)
            {
                magnitudeFinal = mag1;
                valorFinal = valor1 + valor2;

                if (valorFinal > 99)
                {
                    valorFinal = valorFinal - 100;
                    magnitudeFinal = magnitudeFinal + 1;
                }
            }
            else if (mag1 - mag2 == 1 || mag1 - mag2 == -1)
            {
                magnitudeFinal = Math.Max(mag1, mag2);

                if (magnitudeFinal == mag1)
                    valorFinal = valor1 + (valor2/10);
                else
                    valorFinal = valor2 + (valor1/10);
            }
            else
            {
                magnitudeFinal = Math.Max(mag1, mag2);
                if (magnitudeFinal == mag1)
                    valorFinal = valor1;
                else
                    valorFinal = valor2;
            }

            ValorMag resultado = new ValorMag(valorFinal, magnitudeFinal);
            return resultado;
        }
    }
}
