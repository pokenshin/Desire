using System;
using System.Collections.Generic;
using System.Text;
using Desire.Core.Itens;
using Desire.Core.Identidade;
using Desire.Core.Ciencias;
using Desire.Core.Energias;
using Desire.Core.Modificadores;

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
        public decimal Ki { get; set; }
        public int Nivel { get; set; }

        //Atributos
        public Forca Forca { get; set; }
        public Materia Materia { get; set; }
        public Destreza Destreza { get; set; }
        public Intelecto Intelecto { get; set; }
        public Criatividade Criatividade { get; set; }
        public Existencia Existencia { get; set; }
        public Ideia Ideia { get; set; }

        //Evolução dos Atributos
        public Evolucao EvolucaoForca { get; set; }
        public Evolucao EvolucaoMateria { get; set; }
        public Evolucao EvolucaoDestreza { get; set; }
        public Evolucao EvolucaoIntelecto { get; set; }
        public Evolucao EvolucaoCriatividade { get; set; }
        public Evolucao EvolucaoExistencia { get; set; }
        public Evolucao EvolucaoIdeia { get; set; }

        //Energias
        public List<Energia> Energias { get; set; }

        //Destino - Special - Carisma
        public int Especial { get; set; }

        //Deslocamentos
        public List<Deslocamento> Deslocamentos { get; set; }

        //Subatributos
        public ValorMag Instinto { get; set; }
        public ValorMag Raciocinio { get; set; }
        public ValorMag Subconsciencia { get; set; }
        public ValorMag Autocontrole { get; set; }
        public ValorMag Anatomia { get; set; }
        public ValorMag Animo { get; set; }
        public ValorMag Movimento { get; set; }
        public ValorMag Precisao { get; set; }
        public ValorMag BonusHP { get; set; }
        public ValorMag BonusMP { get; set; }
        public decimal BonusCP { get; set; }
        public decimal BonusSP { get; set; }

        //Cerne
        public int Iniciativa { get; set; }
        public ValorMag Acao { get; set; }
        public ValorMag Reacao { get; set; }
        public int Turno { get; set; }
        public int Destria { get; set; }
        public ValorMag Altura { get; set; }
        public ValorMag Largura { get; set; }
        public ValorMag Comprimento { get; set; }
        public ValorMag Composicao { get; set; }
        public ValorMag Massa { get; set; }

        //Subatributos Extras
        public string SubatributoExtraNome1 { get; set; }
        public ValorMag SubatributoExtraValor1 { get; set; }
        public string SubatributoExtraNome2 { get; set; }
        public ValorMag SubatributoExtraValor2 { get; set; }

        //Pericias
        public List<Pericia> Pericias { get; set; }
        
        //Fugacidade
        public List<Habilidade> Fugacidade { get; set; }

        //Habilidades
        public List<Habilidade> Habilidades { get; set; }

        //Reação
        public Resposta Resposta { get; set; }

        //Força de Vontade / Ira / Poder Maximo
        public ValorMag ForcaVontade { get; set; }
        public ValorMag Ira { get; set; }
        public ValorMag PoderMaximo { get; set; }

        //Origem do Poder / Virtudes / Dons
        public List<Modificador> Dons { get; set; }
        public List<Modificador> Defeitos { get; set; }

        //Resistencias / Fraquesas
        public List<Resistencia> Resistencias { get; set; }

        //Experiencia
        public decimal PontosGraduacao { get; set; }
        public decimal PontosEvolucao { get; set; }
        public decimal ExperienciaAtual { get; set; }

        //Equipamento
        public List<Equipamento> Equipamentos { get; set; }
        public List<Item> Posses { get; set; }

        //Cansaço / Natureza / Fé / Karma / Alma
        public int CansacoAtual { get; set; }
        public int CansacoMax { get; set; }
        public Natureza Natureza { get; set; }
        public int Genese { get; set; }
        public int Geracao { get; set; }
        public int Fe { get; set; }
        public int Karma { get; set; }
        public Destino Destino { get; set; }
        public Carisma Carisma { get; set; }
        public List<string> Alma { get; set; }

        //Elo Divino
        public string EloDivino { get; set; }

        //Trajetória
        public string Trajetoria { get; set; }

        //Idumentária
        public string Idumentaria { get; set; }

        //Modificadores Ativos
        public List<Modificador> ModificadoresAtivos { get; set; }

        public Ser()
        {
            this.Nome = "";
            this.Origem = new Origem();
            this.Tempo = 0;
            this.Especies = new List<Especie>();
            this.Classes = new List<Classe>();
            this.Indole = new Indole();
            this.Magnitude = 0;
            this.Reis = new List<Rei>();
            this.Ki = 0;
            this.Nivel = 0;
            this.Forca = new Forca();
            this.Materia = new Materia();
            this.Destreza = new Destreza();
            this.Intelecto = new Intelecto();
            this.Criatividade = new Criatividade();
            this.Existencia = new Existencia();
            this.Ideia = new Ideia();
            this.Energias = new List<Energia>();
            this.Especial = 0;
            this.Deslocamentos = new List<Deslocamento>();
            this.Instinto = new ValorMag();
            this.Raciocinio = new ValorMag();
            this.Subconsciencia = new ValorMag();
            this.Autocontrole = new ValorMag();
            this.Anatomia = new ValorMag();
            this.Animo = new ValorMag();
            this.Movimento = new ValorMag();
            this.Precisao = new ValorMag();
            this.BonusHP = new ValorMag();
            this.BonusMP = new ValorMag();
            this.BonusCP = 0;
            this.BonusSP = 0;
            this.Iniciativa = 0;
            this.Acao = new ValorMag();
            this.Reacao = new ValorMag();
            this.Turno = 0;
            this.Destria = 0;
            this.Altura = new ValorMag();
            this.Largura = new ValorMag();
            this.Comprimento = new ValorMag();
            this.Massa = new ValorMag();
            this.SubatributoExtraNome1 = "";
            this.SubatributoExtraValor1 = new ValorMag();
            this.SubatributoExtraNome2 = "";
            this.SubatributoExtraValor2 = new ValorMag();
            this.Pericias = new List<Pericia>();
            this.Fugacidade = new List<Habilidade>();
            this.Habilidades = new List<Habilidade>();
            this.Resposta = new Resposta();
            this.ForcaVontade = new ValorMag();
            this.Ira = new ValorMag();
            this.PoderMaximo = new ValorMag();
            this.Dons = new List<Modificador>();
            this.Defeitos = new List<Modificador>();
            this.Resistencias = new List<Resistencia>();
            this.PontosGraduacao = 0;
            this.PontosEvolucao = 0;
            this.ExperienciaAtual = 0;
            this.Equipamentos = new List<Equipamento>();
            this.Posses = new List<Item>();
            this.CansacoAtual = 0;
            this.CansacoMax = 0;
            this.Natureza = new Natureza();
            this.Genese = 0;
            this.Geracao = 0;
            this.Fe = 0;
            this.Karma = 0;
            this.Destino = this.Indole.Destino;
            this.Carisma = this.Indole.Carisma;
            this.EloDivino = "";
            this.Trajetoria = "";
            this.Idumentaria = "";
            this.ModificadoresAtivos = new List<Modificador>();
        }
    }
}
