using System.Reflection;
using Desire.Core.Ciencias;
using Desire.Core.Energias;

namespace Desire.Core.Modificadores
{
    public abstract class Modificador
    {
        //Tipos possiveis:
        //"*" = Multiplicação
        //"+" = Adição
        //"-" = Subtração
        //"/" = Divisão
        //"A" = Adiciona Perícia / Habilidade / Energia
        //"R" = Remove Pericia / Habilidade / Energia

        public string Origem { get; set; }
    }
}