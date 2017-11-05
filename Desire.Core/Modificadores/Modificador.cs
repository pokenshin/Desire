using System.Reflection;
using Desire.Core.Util;
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

        public abstract Ser AplicaModificador(Ser ser);
        public abstract Ser RemoveModificador(Ser ser);
    }
}