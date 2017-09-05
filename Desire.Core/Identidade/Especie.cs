using System.Collections.Generic;
using System.Numerics;
using Desire.Core.Identidade;
using Desire.Core.Ciencias;

namespace Desire.Core.Identidade
{
    public class Especie
    {
        public int Id { get; set; }
        //Taxonomia
        public string ReinoTaxo { get; set; }
        public string FiloTaxo { get; set; }
        public string ClasseTaxo { get; set; }
        public string OrdemTaxo { get; set; }
        public string FamiliaTaxo { get; set; }
        public string GeneroTaxo { get; set; }
        public string NomeCientifico { get; set; }
        public string NomePopular {get; set; }
        //Identidade
        public Origem OrigemEspecie { get; set; }
        public List<string> SubClassificacoes { get; set; }
        public int MagnitudeMin { get; set; }
        public int MagnitudeMax { get; set; }
        public int ReiMin { get; set; }
        public int ReiMax { get; set; }
        public int KiMin { get; set; }
        public int KiMax { get; set; }
        public int NivelMin { get; set; }
        public int NivelMax { get; set; }
        public int TempoMax { get; set; }
        //Lista de Energias
        public List<Energia> Energias { get; set; }
        //Minimo de Atributos
        public Forca ForcaMin { get; set; }
        public Materia MateriaMin { get; set; }
        public Destreza DestrezaMin { get; set; }
        public Intelecto IntelectoMin { get; set; }
        public Criatividade CriatividadeMin { get; set; }
        public Existencia ExistenciaMin { get; set; }
        public Ideia IdeiaMin { get; set; }
        //Maximo de Atributos
        public Forca ForcaMax { get; set; }
        public Materia MateriaMax { get; set; }
        public Destreza DestrezaMax { get; set; }
        public Intelecto IntelectoMax { get; set; }
        public Criatividade CriatividadeMax { get; set; }
        public Existencia ExistenciaMax { get; set; }
        public Ideia IdeiaMax { get; set; }
        //Pericias / Habilidades Iniciais
        public List<Pericia> PericiasEspecie { get; set; }
        public List<Habilidade> HabilidadesEspecie { get; set; }
        //Origens do Poder / Virtudes / Dons / Vantagens / Defeitos / etc
        public string OrigemPoder { get; set; }
        public List<Modificador> VirtudesEspecie { get; set; }
        public List<Modificador> DefeitosEspecie { get; set; }
        //Força de Vontade / Ira / Poder Máximo
        public ValorMag ForcaVontadeMin { get; set; }
        public ValorMag ForcaVontadeMax { get; set; }
        public ValorMag IraMin { get; set; }
        public ValorMag IraMax { get; set; }
        public ValorMag PoderMaximoMin { get; set; }
        public ValorMag PoderMaximoMax { get; set; }
        //Fator de progressão de Exp
        public int FatorProgressao { get; set; }
        //Cansaço, Fé e Karma
        public int CansacoMax { get; set; }
        public int FeMin { get; set; }
        public int FeMax { get; set; }
        public int KarmaMin { get; set; }
        public int KarmaMax { get; set; }
        //Maximo de itens de equipados
        public int MaxItensEquipados { get; set; }
        public int MaxArmasEquipadas { get; set; }
        public int AcaoMin { get; set; }
        public int AcaoMax { get; set; }
        public int TurnoMin { get; set; }
        public int TurnoMax { get; set; }
        public ValorMag AlturaMin { get; set; }
        public ValorMag AlturaMax { get; set; }
        public int MaturidadeMin { get; set; }
        public int MaturidadeMax { get; set; }
        public int Porcentagem { get; set; } //Porcentagem da raça dentro do ser, soma de todas deve dar 100%
        public int DestriaMax { get; set; }
        public int DestriaMin { get; set; }
        public decimal TrabalhoMin { get; set; }
        public decimal TrabalhoMax { get; set; }
        public ValorMag Densidade { get; set; }
        public ValorMag LarguraMin { get; set; }
        public ValorMag LarguraMax { get; set; }
        public int Especial { get; set; }
        public Natureza Natureza { get; set; }
        public Resposta RespostaMin { get; set; }
        public Resposta RespostaMax { get; set; }
        public List<Habilidade> Fugacidade { get; set; }
    }
}