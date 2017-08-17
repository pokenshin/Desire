using Desire.Core.Geradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace Desire.Core.Calculadores
{
    public class CalculadorSer
    {
        public Ser CalculaSer(Ser ser)
        {
            //Carisma e Destino - A partir da Índole escolhida
            ser.Carisma = ser.Indole.Carisma;
            ser.Destino = ser.Indole.Destino;
            //Especial - O maior especial das raças do ser
            ser.Especial = CalculaEspecial(ser.Especies);
            //Deslocamentos
            ser.Deslocamentos = CriaListaDeslocamentosSer(ser);
            //Pericias
            ser.Pericias = CriaListaPericiasSer(ser);
            //Energias
            ser.Energias = CriaListaEnergias(ser);
            //Subatributos
            ser = CalculaSubatributos(ser);
            //Habilidades
            ser.Habilidades = CriaListaHabilidades(ser);
            //Reação
            ser.Reacao = CalculaReacao(ser);
            //Experiência
            ser = CalculaExperiencia(ser);
            //Cansaço
            ser.Cansaco = CalculaCansaco(ser);
            //Natureza
            ser.Natureza = CalculaNatureza(ser);
            //Fé e Karma
            ser.Fe = CalculaFe(ser);
            ser.Karma = CalculaKarma(ser);
            //Subatributos
            ser = CalculaSubatributos(ser);
            //Modificadores
            ser = CalculaModificadores(ser);
            //Magnitude
            ser.Magnitude = CalculaMagnitude(ser);

            return ser;
        }

        public int CalculaMagnitude(Ser ser)
        {
            throw new NotImplementedException();
        }

        public Ser CalculaModificadores(Ser ser)
        {
            //TODO: Aplicar modificadores vindos de:
            //Pericias
            //Itens / Equips
            //Dons
            //Vantagens
            //Defeitos
            //Resistências
            //Fraquezas
            //Reis
            throw new NotImplementedException();
        }

        public Natureza CalculaNatureza(Ser ser)
        {
            //Definido a partir da especie
            Natureza resultado = new Natureza();
            
            resultado.Apresentacao = (int)(from e in ser.Especies select e.Natureza.Apresentacao).Max();
            resultado.Concepcao = (int)(from e in ser.Especies select e.Natureza.Concepcao).Max();
            resultado.Honra = (int)(from e in ser.Especies select e.Natureza.Honra).Max();
            resultado.Moral = (int)(from e in ser.Especies select e.Natureza.Moral).Max();
            resultado.Percepcao = (int)(from e in ser.Especies select e.Natureza.Percepcao).Max();
            resultado.Personalidade = (int)(from e in ser.Especies select e.Natureza.Personalidade).Max();

            return resultado;
        }

        public int CalculaKarma(Ser ser)
        {
            //Definido a partir da especie
            return (int)(from e in ser.Especies select e.KarmaMin).Max();
        }

        public int CalculaFe(Ser ser)
        {
            //Definido a partir da espécie
            return (int)(from e in ser.Especies select e.FeMin).Max();
        }

        public int CalculaCansaco(Ser ser)
        {
            //Definido a partir da especie
            return (int)(from e in ser.Especies select e.CansacoMax).Max();
        }

        public Ser CalculaExperiencia(Ser ser)
        {
            //Pontos de Graduação (G) = 10^Magnitude do Personagem
            //Pontos de Evolução (En) = Nivel * G
            //Experiência Total (XPn) = (G*(nivel^2 - nivel)) / 2
            ser.PontosGraduacao = Math.Floor(Math.Pow(10, ser.Magnitude));
            ser.PontosEvolucao = Math.Floor(ser.Nivel * ser.PontosGraduacao);
            ser.ExperienciaAtual = Math.Floor((ser.PontosGraduacao * (Math.Pow(ser.Nivel, 2) - ser.Nivel)) / 2);

            return ser;
        }

        public Reacao CalculaReacao(Ser ser)
        {
            CalculadorNumero calculador = new CalculadorNumero();

            Reacao reacao = new Reacao()
            {
                Bravura = calculador.RetornaMaiorValorMag((List<ValorMag>)(from e in ser.Especies select e.ReacaoMin.Bravura)),
                Coragem = calculador.RetornaMaiorValorMag((List<ValorMag>)(from e in ser.Especies select e.ReacaoMin.Coragem)),
                Desespero = calculador.RetornaMaiorValorMag((List<ValorMag>)(from e in ser.Especies select e.ReacaoMin.Desespero)),
                Heroismo = calculador.RetornaMaiorValorMag((List<ValorMag>)(from e in ser.Especies select e.ReacaoMin.Heroismo)),
                Indiferenca = calculador.RetornaMaiorValorMag((List<ValorMag>)(from e in ser.Especies select e.ReacaoMin.Indiferenca)),
                Medo = calculador.RetornaMaiorValorMag((List<ValorMag>)(from e in ser.Especies select e.ReacaoMin.Medo)),
                Panico = calculador.RetornaMaiorValorMag((List<ValorMag>)(from e in ser.Especies select e.ReacaoMin.Panico)),
            };

            return reacao;
        }

        public List<Habilidade> CriaListaHabilidades(Ser ser)
        {
            List<Habilidade> resultado = new List<Habilidade>();

            foreach (Especie especie in ser.Especies)
            {
                foreach (Habilidade habilidade in especie.HabilidadesEspecie)
                {
                    //Só adiciona a habilidade se ela não for repetida (verificada pelo Id)
                    List<int> ids = (List<int>)(from h in resultado select h.Id);
                    if (!ids.Contains(habilidade.Id))
                        resultado.Add(habilidade);
                }
            }

            return resultado;
        }

        public List<Energia> CriaListaEnergias(Ser ser)
        {
            List<Energia> resultado = new List<Energia>();
            List<string> siglas = new List<string>();

            foreach (Especie especie in ser.Especies)
            {
                foreach (Energia energia in especie.Energias)
                {
                    //Só adiciona a energia se ela não for repetida (verificada pela sigla)
                    siglas = (List<string>)(from e in resultado select e.Sigla);
                    if (!siglas.Contains(energia.Sigla))
                    { 
                        resultado.Add(energia);
                    }
                }
            }

            ser = CalculaValorBaseEnergias(ser);

            return resultado;
        }

        public Ser CalculaValorBaseEnergias(Ser ser)
        {
            //Energias: "AP", "CP", "EP", "HP", "MP", "QP", "SP", "PE", "PA", "WP";


            throw new NotImplementedException();
        }

        public List<Pericia> CriaListaPericiasSer(Ser ser)
        {
            //TODO:  Juntar pericias da Classe, da Espécie
            List<Pericia> pericias = new List<Pericia>();

            return pericias;
        }

        public List<Deslocamento> CriaListaDeslocamentosSer(Ser ser)
        {
            //TODO: Calcular lista de deslocamentos e valores baseado na espécie do ser
            List<Deslocamento> deslocamentos = new List<Deslocamento>();

            return deslocamentos;
        }

        public int CalculaEspecial(List<Especie> especies)
        {
            //Pega o maior Especial de todas as raças do ser
            return (int)(from e in especies select e.Especial).Max();
        }

        //Calcula subatributos BASE de um ser sem modificadores
        public Ser CalculaSubatributos(Ser ser)
        {
            Gerador gerador = new Gerador();
            CalculadorNumero calculador = new CalculadorNumero();
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
            ser.Acao = ser.Especies[0].AcaoMin + (int)calculador.CalculaPorcentagem(20, (long)(from e in ser.Especies select e.AcaoMin).Max());
            //Turno = valor minimo da especie dominante + 20% da maior especie
            ser.Turno = ser.Especies[0].TurnoMin + (int)calculador.CalculaPorcentagem(20, (long)(from e in ser.Especies select e.TurnoMin).Max());
            //ser.Turno.Valor = (from e in ser.Especies select e.TurnoMin).Max();

            //Caracteristicas Fisicas
            ser.Altura = gerador.GeraValorMag(ser.Especies[0].AlturaMin, ser.Especies[0].AlturaMax);

            //Comprimento = Pontos em matéria
            ser.Comprimento = new ValorMag(Convert.ToString(ser.Materia.Pontos));

            //Largura = Aleatorio entre largura min e largura max da especie dominante
            ser.Largura = gerador.GeraValorMag(ser.Especies[0].LarguraMin, ser.Especies[0].LarguraMax);

            //TODO: Verificar a possibilidade de retirar espaço e deixar só volume
            //Volume = (Comprimento * Altura)
            //Espaço = (Comprimento * Altura)
            //ser.Volume = new ValorMag(ser.Largura.ValorReal * ser.Comprimento.ValorReal * ser.Altura.ValorReal);
            ser.Volume = calculador.MultiplicaValorMag(ser.Largura, ser.Comprimento);
            ser.Volume = calculador.MultiplicaValorMag(ser.Volume, ser.Altura);
            ser.Espaco = ser.Volume;

            //Massa = Volume * Densidade da Especie
            ser.Massa = calculador.MultiplicaValorMag(ser.Volume, ser.Especies[0].Densidade);

            //Instinto = (Ideia + Destreza) / 2
            ser.Instinto = calculador.SomaValorMag(ser.Ideia.Porcentagem, ser.Destreza.Porcentagem);
            ser.Instinto = calculador.DivideValorMag(ser.Instinto, 2);

            //Raciocinio = (Intelecto + Criatividade) / 2
            ser.Raciocinio = calculador.SomaValorMag(ser.Intelecto.Porcentagem, ser.Criatividade.Porcentagem);
            ser.Raciocinio = calculador.DivideValorMag(ser.Raciocinio, 2);

            //Subconsciencia = (Existencia + Ideia) / 2
            ser.Subconsciencia = calculador.SomaValorMag(ser.Existencia.Porcentagem, ser.Ideia.Porcentagem);
            ser.Subconsciencia = calculador.DivideValorMag(ser.Subconsciencia, 2);

            //Autocontrole = (Intelecto + Existencia) / 2
            ser.Autocontrole = calculador.SomaValorMag(ser.Intelecto.Porcentagem, ser.Existencia.Porcentagem);
            ser.Autocontrole = calculador.DivideValorMag(ser.Subconsciencia, 2);

            //Trabalho = PA onde r = (Pts Força + Pts Destreza + Pts Vitalidade) / 3 , n = nivel
            //Formula PA: An = A1 + (n - 1) * r
            int trabalhoRazao = (ser.Forca.Pontos + ser.Destreza.Pontos + ser.Materia.Pontos) / 3;
            int trabalhoN = ser.Nivel;
            decimal trabalhoA1 = ser.Especies[0].TrabalhoMin;
            ser.Trabalho = Math.Floor(calculador.CalculaPA(trabalhoA1, trabalhoN, trabalhoRazao));

            //Anatomia = (Materia + Força + Destreza) /3
            ser.Anatomia = calculador.SomaValorMag(ser.Materia.Porcentagem, ser.Forca.Porcentagem);
            ser.Anatomia = calculador.SomaValorMag(ser.Anatomia, ser.Destreza.Porcentagem);
            ser.Anatomia = calculador.DivideValorMag(ser.Anatomia, 3);

            //Animo = (Criatividade + Existencia)/2
            ser.Animo = calculador.SomaValorMag(ser.Criatividade.Porcentagem, ser.Existencia.Porcentagem);
            ser.Animo = calculador.DivideValorMag(ser.Animo, 2);

            //Movimento = (Destreza + Forca*2) /3
            ser.Movimento = calculador.MultiplicaValorMag(ser.Forca.Porcentagem, 2);
            ser.Movimento = calculador.SomaValorMag(ser.Movimento, ser.Destreza.Porcentagem);
            ser.Movimento = calculador.DivideValorMag(ser.Movimento, 3);

            //Precisao = (Forca*2 + Destreza) / 3
            ser.Precisao = calculador.MultiplicaValorMag(ser.Forca.Porcentagem, 2);
            ser.Precisao = calculador.SomaValorMag(ser.Movimento, ser.Destreza.Porcentagem);
            ser.Precisao = calculador.DivideValorMag(ser.Movimento, 3);

            //Essencia = todos os atributos / 7
            ser.Essencia = calculador.SomaValorMag(ser.Forca.Porcentagem, ser.Destreza.Porcentagem);
            ser.Essencia = calculador.SomaValorMag(ser.Essencia, ser.Materia.Porcentagem);
            ser.Essencia = calculador.SomaValorMag(ser.Essencia, ser.Intelecto.Porcentagem);
            ser.Essencia = calculador.SomaValorMag(ser.Essencia, ser.Criatividade.Porcentagem);
            ser.Essencia = calculador.SomaValorMag(ser.Essencia, ser.Ideia.Porcentagem);
            ser.Essencia = calculador.SomaValorMag(ser.Essencia, ser.Existencia.Porcentagem);
            ser.Essencia = calculador.DivideValorMag(ser.Essencia, 7);

            return ser;
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

    }
}
