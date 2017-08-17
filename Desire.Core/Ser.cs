using System;
using System.Collections.Generic;
using System.Text;
using Desire.Core.Itens;

namespace Desire.Core
{
    public class Ser
    {
        //Identidade
        public string Nome { get; set; }
        public Origem Origem { get; set; }
        public int Tempo { get; set; }
        public List<Especie> Especies { get; set; }
        public List<Classe> Classes { get; set; }
        public Indole Indole { get; set; }
        public int Magnitude { get; set; }
        public List<Rei> Reis { get; set; }
        public int Ki { get; set; }
        public int Nivel { get; set; }

        //Atributos
        public Forca Forca { get; set; }
        public Materia Materia { get; set; }
        public Destreza Destreza { get; set; }
        public Intelecto Intelecto { get; set; }
        public Criatividade Criatividade { get; set; }
        public Existencia Existencia { get; set; }
        public Ideia Ideia { get; set; }

        //Energias
        public List<Energia> Energias { get; set; }

        //Destino - Special - Carisma
        public Destino Destino { get; set; }
        public int Especial { get; set; }
        public Carisma Carisma { get; set; }

        //Deslocamentos
        public List<Deslocamento> Deslocamentos { get; set; }

        //Subatributos
        public ValorMag Iniciativa { get; set; }
        public int Destria { get; set; }
        public int Acao { get; set; }
        public int Turno { get; set; }
        public ValorMag Espaco { get; set; }
        public ValorMag Instinto { get; set; }
        public ValorMag Raciocinio { get; set; }
        public ValorMag Subconsciencia { get; set; }
        public ValorMag Autocontrole { get; set; }
        public Decimal Trabalho { get; set; }
        public ValorMag Altura { get; set; }
        public ValorMag Largura { get; set; }
        public ValorMag Comprimento { get; set; }
        public ValorMag Volume { get; set; }
        public ValorMag Anatomia { get; set; }
        public ValorMag Animo { get; set;}
        public ValorMag Movimento { get; set; }
        public ValorMag Precisao { get; set; }
        public ValorMag Essencia { get; set; }
        public ValorMag Massa { get; set; }

        //Pericias
        public List<Pericia> Pericias { get; set; }

        //Habilidades
        public List<Habilidade> Habilidades { get; set; }

        //Evolução
        public Evolucao EvolucaoForca { get; set; }

        //Reação
        public Reacao Reacao { get; set; }

        //Força de Vontade / Ira / Poder Maximo
        public ValorMag ForcaVontade { get; set; }
        public ValorMag Ira { get; set; }
        public ValorMag PoderMaximo { get; set; }

        //Origem do Poder / Virtudes / Dons
        public string OrigemPoder { get; set; }
        public List<Modificador> Virtudes { get; set; }
        public List<Modificador> Dons { get; set; }
        public List<Modificador> Vantagens { get; set; }
        public List<Modificador> Defeitos { get; set; }

        //Resistencias / Fraquesas
        public List<Modificador> Resistencias { get; set; }
        public List<Modificador> Fraquezas { get; set; }

        //Experiencia
        public double PontosGraduacao { get; set; }
        public double PontosEvolucao { get; set; }
        public double ExperienciaAtual { get; set; }

        //Equipamento
        public List<Item> ItensEquipados { get; set; }
        public List<Item> ItensGuardados { get; set; }

        //Cansaço / Natureza / Fé / Karma
        public int Cansaco { get; set; }
        public Natureza Natureza { get; set; }
        public int Genese { get; set; }
        public int Geracao { get; set; }
        public int Fe { get; set; }
        public int Karma { get; set; }

        public Ser()
        {
            //Cria um ser com atributos aleatorios
        }

    }
}
