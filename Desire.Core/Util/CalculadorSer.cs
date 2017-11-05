using Desire.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using Desire.Core.Itens;
using Desire.Core.Identidade;
using Desire.Core.Ciencias;
using Desire.Core.Util.Geradores;
using Desire.Core.Energias;
using Desire.Core.Modificadores;

namespace Desire.Core.Util
{
    public class CalculadorSer
    {
        public Ser CalculaSer(Ser ser)
        {
            //TODO: Calcular experiencia
            
            //Carisma e Destino - A partir da Índole escolhida
            ser.Carisma = ser.Indole.Carisma;
            ser.Destino = ser.Indole.Destino;
            //Especial - O maior especial das raças do ser
            ser.Especial = CalculaEspecial(ser.Especies);
            //Deslocamentos
            ser.Deslocamentos = CalculaDeslocamentosBase(ser);
            //Pericias
            ser.Pericias = CriaListaPericiasSer(ser);
            //Habilidades
            ser.Habilidades = CriaListaHabilidades(ser);
            //Cansaço
            ser.CansacoMax = CalculaCansaco(ser);
            //Natureza
            ser.Natureza = CalculaNatureza(ser);
            //Fé e Karma
            ser.Fe = CalculaFe(ser);
            ser.Karma = CalculaKarma(ser);
            //Subatributos
            ser = CalculaSubatributos(ser);
            //Ira, FV, PS
            ser.Ira = (from e in ser.Especies select e.IraMin).Max();
            ser.ForcaVontade = (from e in ser.Especies select e.ForcaVontadeMin).Max();
            ser.PoderMaximo = (from e in ser.Especies select e.PoderMaximoMax).Max();
            //Resposta
            ser.Resposta = CalculaResposta(ser);
            //Fugacidade
            ser.Fugacidade = CalculaFugacidade(ser);
            //Deslocamento
            ser.Deslocamentos = CalculaDeslocamentosBase(ser);
            //Modificadores
            ser.ModificadoresAtivos = ListaModificadoresAtivos(ser);
            //Magnitude
            ser.Magnitude = CalculaMagnitude(ser);
            //Energias
            ser.Energias = CriaListaEnergias(ser);
            //Experiência
            ser = CalculaExperiencia(ser);

            //TODO: Ativar modificadores

            return ser;
        }

        private List<Deslocamento> CalculaDeslocamentosBase(Ser ser)
        {
            List<Deslocamento> resultado = new List<Deslocamento>();
            //Solo
            resultado.Add(CalculaDesolocamentoSolo(ser));
            //Ar
            resultado.Add(CalculaDesolocamentoAr(ser));
            //Mar
            resultado.Add(CalculaDesolocamentoMar(ser));
            //Espaço
            resultado.Add(CalculaDesolocamentoEspaco(ser));

            return resultado;
        }

        //(Minimo da Espécie * (FatorDex + FatorFor)) * 2
        //FatorDex e FatorFor = quantos % acima ou abaixo do minimo da especie o ser está
        private Deslocamento CalculaDesolocamentoEspaco(Ser ser)
        {
            Deslocamento resultado = new Deslocamento("Espaço");
            Deslocamento desEspEspecie = ser.Especies[0].DeslocamentosMedios.FirstOrDefault(d => d.Tipo == "Espaço");
            if (desEspEspecie != null)
            { 
                CalculadorNumero calc = new CalculadorNumero();
                int especieDexMin = ser.Especies[0].DestrezaMin.Pontos;
                int especieForMin = ser.Especies[0].ForcaMin.Pontos;
                int serDex = ser.Destreza.Pontos;
                int serFor = ser.Forca.Pontos;
                //Retorna as porcentagens a mais (ou a menos) que os atributos atuais têm sobre a espécie
                double fatorDex = 10 * serDex / especieDexMin;
                double fatorFor = 10 * serFor / especieForMin;
                //Média dos dois valores para multiplicar com o minimo da espécie
                double fatorTotal = (fatorDex + fatorFor) / 2;

                resultado.Valor = calc.MultiplicaValorMag(desEspEspecie.Valor, fatorTotal);
                resultado.Valor = calc.MultiplicaValorMag(resultado.Valor, 2);
            }

            return resultado;
        }

        //(Minimo da Espécie * (FatorDex + FatorFor)) / 3
        //FatorDex e FatorFor = quantos % acima ou abaixo do minimo da especie o ser está
        private Deslocamento CalculaDesolocamentoMar(Ser ser)
        {
            Deslocamento resultado = new Deslocamento("Mar");
            Deslocamento desMarEspecie = ser.Especies[0].DeslocamentosMedios.FirstOrDefault(d => d.Tipo == "Mar");
            if (desMarEspecie != null)
            {
                CalculadorNumero calc = new CalculadorNumero();
                int especieDexMin = ser.Especies[0].DestrezaMin.Pontos;
                int especieForMin = ser.Especies[0].ForcaMin.Pontos;
                int serDex = ser.Destreza.Pontos;
                int serFor = ser.Forca.Pontos;
                //Retorna as porcentagens a mais (ou a menos) que os atributos atuais têm sobre a espécie
                double fatorDex = 10 * serDex / especieDexMin;
                double fatorFor = 10 * serFor / especieForMin;
                //Média dos dois valores para multiplicar com o minimo da espécie
                double fatorTotal = (fatorDex + fatorFor) / 2;

                resultado.Valor = calc.MultiplicaValorMag(desMarEspecie.Valor, fatorTotal);
                resultado.Valor = calc.DivideValorMag(resultado.Valor, 3);
            }
            return resultado;
        }


        //(Minimo da Espécie * (FatorDex + FatorFor)) / 2
        //FatorDex e FatorFor = quantos % acima ou abaixo do minimo da especie o ser está
        private Deslocamento CalculaDesolocamentoAr(Ser ser)
        {
            Deslocamento resultado = new Deslocamento("Ar");
            Deslocamento desArEspecie = ser.Especies[0].DeslocamentosMedios.FirstOrDefault(d => d.Tipo == "Ar");
            if (desArEspecie != null)
            {
                CalculadorNumero calc = new CalculadorNumero();
                int especieDexMin = ser.Especies[0].DestrezaMin.Pontos;
                int especieForMin = ser.Especies[0].ForcaMin.Pontos;
                int serDex = ser.Destreza.Pontos;
                int serFor = ser.Forca.Pontos;
                //Retorna as porcentagens a mais (ou a menos) que os atributos atuais têm sobre a espécie
                double fatorDex = 10 * serDex / especieDexMin;
                double fatorFor = 10 * serFor / especieForMin;
                //Média dos dois valores para multiplicar com o minimo da espécie
                double fatorTotal = (fatorDex + fatorFor) / 2;

                resultado.Valor = calc.MultiplicaValorMag(desArEspecie.Valor, fatorTotal);
                resultado.Valor = calc.DivideValorMag(resultado.Valor, 2);
            }

            return resultado;
        }

        //Minimo da Espécie * (FatorDex + FatorFor)
        //FatorDex e FatorFor = quantos % acima ou abaixo do minimo da especie o ser está
        private Deslocamento CalculaDesolocamentoSolo(Ser ser)
        {
            Deslocamento resultado = new Deslocamento("Solo");
            Deslocamento desSoloEspecie = ser.Especies[0].DeslocamentosMedios.FirstOrDefault(d => d.Tipo == "Solo");
            if (desSoloEspecie != null)
            { 
                CalculadorNumero calc = new CalculadorNumero();
                int especieDexMin = ser.Especies[0].DestrezaMin.Pontos;
                int especieForMin = ser.Especies[0].ForcaMin.Pontos;
                int serDex = ser.Destreza.Pontos;
                int serFor = ser.Forca.Pontos;
                //Retorna as porcentagens a mais (ou a menos) que os atributos atuais têm sobre a espécie
                double fatorDex = 10 * serDex / especieDexMin;
                double fatorFor = 10 * serFor / especieForMin;
                //Média dos dois valores para multiplicar com o minimo da espécie
                double fatorTotal = (fatorDex + fatorFor) / 2;
                resultado.Valor = calc.MultiplicaValorMag(desSoloEspecie.Valor, fatorTotal);
            }

            return resultado;
        }

        private List<Habilidade> CalculaFugacidade(Ser ser)
        {
            return (from h in ser.Habilidades where h.Tipo.Nome == "Movimento" select h).ToList<Habilidade>();
        }

        //Magnitude média dos atributos
        //Pega magnitude do Rei se for maior que a média dos atributos
        public int CalculaMagnitude(Ser ser)
        {
            int magTotal = ser.Forca.Porcentagem.Magnitude + ser.Destreza.Porcentagem.Magnitude + ser.Materia.Porcentagem.Magnitude + ser.Intelecto.Porcentagem.Magnitude + ser.Criatividade.Porcentagem.Magnitude + ser.Ideia.Porcentagem.Magnitude + ser.Existencia.Porcentagem.Magnitude;
            magTotal = magTotal / 7;
            
            return magTotal;
        }

        public List<Modificador> ListaModificadoresAtivos(Ser ser)
        {
            List<Modificador> resultado = new List<Modificador>();
            //Pericias
            //Itens / Equips / Posses
            //Virtudes
            //Defeitos
            //Reis

            foreach (Pericia pericia in ser.Pericias)
            {
                if (pericia.Modificadores != null)
                    resultado.AddRange(pericia.Modificadores);
            }

            foreach (Item item in ser.Equipamentos)
            {
                if (item.Modificadores != null)
                    resultado.AddRange(item.Modificadores);
            }

            foreach (Item item in ser.Posses)
            {
                if (item.Modificadores != null)
                    resultado.AddRange(item.Modificadores);
            }

            foreach (Rei rei in ser.Reis)
            {
                if (rei.Modificadores != null)
                    resultado.AddRange(rei.Modificadores);
            }

            resultado.AddRange(ser.Virtudes);
            resultado.AddRange(ser.Defeitos);
            
            return resultado;
        }

        private Ser AplicaModificadores()
        {
            //TODO: Aplica todos os modificadores para o ser
            return new Ser();
        }

        public Natureza CalculaNatureza(Ser ser)
        {
            //Definido a partir da especie
            Natureza resultado = new Natureza()
            {
                Apresentacao = (int)(from e in ser.Especies select e.Natureza.Apresentacao).Max(),
                Concepcao = (int)(from e in ser.Especies select e.Natureza.Concepcao).Max(),
                Honra = (int)(from e in ser.Especies select e.Natureza.Honra).Max(),
                Moral = (int)(from e in ser.Especies select e.Natureza.Moral).Max(),
                Percepcao = (int)(from e in ser.Especies select e.Natureza.Percepcao).Max(),
                Personalidade = (int)(from e in ser.Especies select e.Natureza.Personalidade).Max()
            };
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
            ser.PontosGraduacao = (decimal)Math.Floor(Math.Pow(10, ser.Magnitude));
            ser.PontosEvolucao = Math.Floor(ser.Nivel * (Decimal)(ser.PontosGraduacao));
            ser.ExperienciaAtual = Math.Floor((ser.PontosGraduacao * ((decimal)Math.Pow(ser.Nivel, 2) - ser.Nivel)) / 2);

            return ser;
        }

        public Resposta CalculaResposta(Ser ser)
        {
            CalculadorNumero calculador = new CalculadorNumero();

            Resposta reacao = new Resposta()
            {
                Bravura = (int)(from e in ser.Especies select e.RespostaMin.Bravura).Max(),
                Coragem = (int)(from e in ser.Especies select e.RespostaMin.Coragem).Max(),
                Desespero = (int)(from e in ser.Especies select e.RespostaMin.Desespero).Max(),
                Heroismo = (int)(from e in ser.Especies select e.RespostaMin.Heroismo).Max(),
                Indiferenca = (int)(from e in ser.Especies select e.RespostaMin.Indiferenca).Max(),
                Medo = (int)(from e in ser.Especies select e.RespostaMin.Medo).Max(),
                Panico = (int)(from e in ser.Especies select e.RespostaMin.Panico).Max()
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
                    List<int> ids = (from h in resultado select h.Id).ToList<int>();
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
                    siglas = (from e in resultado select e.Sigla).ToList<string>(); ;
                    if (!siglas.Contains(energia.Sigla))
                    { 
                        resultado.Add(new Energia(energia.Sigla));
                    }
                }
            }

            //Energias: "AP", "CP", "EP", "HP", "MP", "QP", "SP", "PE", "PA";
            foreach (Energia energia in resultado)
            {
                foreach (Especie especie in ser.Especies)
                {
                    //Soma todas as quantidades das energias dentro de cada uma das espécies do ser
                    //Ex: pega todos os APs de todas as espécies e soma
                    energia.Quantidade = energia.Quantidade + (from e in especie.Energias where e.Sigla.Equals(energia.Sigla) select e).Sum(e => e.Quantidade);
                }
                switch (energia.Sigla)
                {
                    case "AP":
                        energia.Quantidade = energia.Quantidade + Convert.ToDecimal(ser.BonusAP);
                        break;

                    case "HP":
                        energia.Quantidade = energia.Quantidade + Convert.ToDecimal(ser.BonusHP.ValorReal);
                        break;

                    case "MP":
                        energia.Quantidade = energia.Quantidade + Convert.ToDecimal(ser.BonusMP.ValorReal);
                        break;

                    case "SP":
                        energia.Quantidade = energia.Quantidade + ser.BonusSP;
                        break;

                    default:
                        break;
                }
                energia.Quantidade = energia.Quantidade * ser.Nivel;
            }

            return resultado;
        }

        public List<Pericia> CriaListaPericiasSer(Ser ser)
        {
            //TODO:  Juntar pericias da Classe, da Espécie
            List<Pericia> pericias = new List<Pericia>();

            pericias.AddRange(ser.Pericias);

            foreach (Classe classe in ser.Classes)
            {
                pericias.AddRange(classe.Pericias);
            }

            foreach (Especie especie in ser.Especies)
            {
                pericias.AddRange(especie.PericiasEspecie);
            }

            return pericias;
        }

        public int CalculaEspecial(List<Especie> especies)
        {
            //Pega o maior Especial de todas as raças do ser
            return (int)(from e in especies select e.Especial).Max();
        }

        //Calcula subatributos BASE de um ser sem modificadores
        public Ser CalculaSubatributos(Ser ser)
        {
            GeradorValorMag genValorMag = new GeradorValorMag();
            CalculadorNumero calculador = new CalculadorNumero();
            Random rnd = new Random();
            //Iniciativa = Destreza.Iniciativa
            ser.Iniciativa = ser.Destreza.Iniciativa;

            //Destria = Pontos Destreza / 10 (até o maximo da espécie)
            if (ser.Destreza.Pontos / 10 > ser.Especies[0].DestriaMax)
                ser.Destria = ser.Especies[0].DestriaMax;
            else if (ser.Destreza.Pontos / 10 < ser.Especies[0].DestriaMin)
                ser.Destria = ser.Especies[0].DestriaMin;
            else
                ser.Destria = ser.Destreza.Pontos / 10;

            //Acao = vigor + vitalidade * dinamica
            ser.Acao = calculador.SomaValorMag(ser.Forca.Vigor, ser.Materia.Vitalidade);
            ser.Acao = calculador.MultiplicaValorMag(ser.Acao, Convert.ToDouble(ser.Destreza.Dinamica));
            //Reacao = Vitalidade * Dinamica
            ser.Reacao = calculador.MultiplicaValorMag(ser.Materia.Vitalidade, Convert.ToDouble(ser.Destreza.Dinamica));
            //Turno = valor minimo da especie dominante + 20% da maior especie
            ser.Turno = ser.Especies[0].TurnoMin + (int)calculador.CalculaPorcentagem(20, (long)(from e in ser.Especies select e.TurnoMin).Max());

            //Altura = aleatorio a partir da especie dominante
            if (ser.Altura.Valor == 0)
                ser.Altura = genValorMag.GerarEntre(ser.Especies[0].AlturaMin, ser.Especies[0].AlturaMax, rnd);

            ser.Comprimento = new ValorMag(Convert.ToString(ser.Materia.Pontos));

            //Largura = Aleatorio entre largura min e largura max da especie dominante
            if (ser.Largura.Valor == 0)
                ser.Largura = genValorMag.GerarEntre(ser.Especies[0].LarguraMin, ser.Especies[0].LarguraMax, rnd);

            //Massa = Volume * Densidade da Especie
            ValorMag volume = calculador.MultiplicaValorMag(ser.Altura, ser.Comprimento);
            volume = calculador.MultiplicaValorMag(volume, ser.Largura);
            ser.Massa = calculador.MultiplicaValorMag(volume, ser.Especies[0].Densidade);

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

            //Essencia = Dureza + Resistencia
            Conversor conver = new Conversor();
            ser.Composicao = conver.StringParaValorMag(Convert.ToString(ser.Forca.Dureza));
            ser.Composicao = calculador.SomaValorMag(ser.Composicao, ser.Materia.Resistencia);

            //HP MP AP SP
            //HP = Materia
            //AP = Força Materia Destreza Intelecto Existência
            //MP = Criatividade + Ideia
            //SP = ((15*(pontos de todos atributos-7))*7) (somar tracinhos)
            ser.BonusHP = ser.Materia.BonusHP;
            ser.BonusAP = ser.Forca.BonusAP + ser.Materia.BonusAP;
            ser.BonusAP = ser.BonusAP + ser.Destreza.BonusAP;
            ser.BonusAP = ser.BonusAP + ser.Intelecto.BonusAP;
            ser.BonusAP = ser.BonusAP + ser.Existencia.BonusAP;
            ser.BonusMP = calculador.SomaValorMag(ser.Criatividade.BonusMP, ser.Ideia.BonusMP);
            ser.BonusSP = CalculaBonusSP(ser);

            return ser;
        }

        //SP = 105*(pontos de todos atributos-7) (somar tracinhos)
        private int CalculaBonusSP(Ser ser)
        {
            int resultado = 0;

            resultado = ser.Forca.Pontos + ser.Materia.Pontos + ser.Destreza.Pontos + ser.Criatividade.Pontos + ser.Existencia.Pontos + ser.Ideia.Pontos + ser.Intelecto.Pontos;
            resultado = (resultado - 7)*105;
            resultado = resultado + ser.EvolucaoCriatividade.PontosAtuais;
            resultado = resultado + ser.EvolucaoDestreza.PontosAtuais;
            resultado = resultado + ser.EvolucaoExistencia.PontosAtuais;
            resultado = resultado + ser.EvolucaoForca.PontosAtuais;
            resultado = resultado + ser.EvolucaoIdeia.PontosAtuais;
            resultado = resultado + ser.EvolucaoIntelecto.PontosAtuais;
            resultado = resultado + ser.EvolucaoMateria.PontosAtuais;

            return resultado;
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
