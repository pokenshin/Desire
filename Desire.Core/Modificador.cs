using System.Reflection;
using Desire.Core.Identidade;

namespace Desire.Core
{
    public class Modificador
    {
        public string Nome { get; set; }
        public PropertyInfo Alvo { get; set; }
        public int Valor { get; set; }
        public char Tipo { get; set; }
        public string Origem { get; set; } //Pericia, Rei, Dom, Item, etc
        public int OrigemId { get; set; } // Id da origem
        public Pericia PericiaAfetada { get; set; } // Id da Pericia / Habilidade / Energia adicionada
        public Habilidade HabilidadeAfetada { get; set; } // Id da Pericia / Habilidade / Energia adicionada
        public Energia EnergiaAfetada { get; set; } // Id da Pericia / Habilidade / Energia adicionada

        //Tipos possiveis:
        //"*" = Multiplicação
        //"+" = Adição
        //"-" = Subtração
        //"/" = Divisão
        //"A" = Adiciona Perícia / Habilidade / Energia
        //"R" = Remove Pericia / Habilidade / Energia
    }
}