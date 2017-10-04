using System.Reflection;
using Desire.Core.Ciencias;
using Desire.Core.Energias;

namespace Desire.Core
{
    public class Modificador
    {
        //Tipos possiveis:
        //"*" = Multiplicação
        //"+" = Adição
        //"-" = Subtração
        //"/" = Divisão
        //"A" = Adiciona Perícia / Habilidade / Energia
        //"R" = Remove Pericia / Habilidade / Energia

        public string Nome { get; set; }
        public string Alvo { get; set; }
        public ValorMag Valor { get; set; }
        public char Tipo { get; set; }
        public string Origem { get; set; } //Pericia, Rei, Dom, Item, etc
        public int OrigemId { get; set; } // Id da origem
        public Pericia PericiaAfetada { get; set; } // Id da Pericia / Habilidade / Energia adicionada
        public Habilidade HabilidadeAfetada { get; set; } // Id da Pericia / Habilidade / Energia adicionada
        public Energia EnergiaAfetada { get; set; } // Id da Pericia / Habilidade / Energia adicionada

        public override string ToString()
        {
            return this.Alvo + this.Tipo + Valor.ToString();
        }
    }
}