using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Desire.Core.Modificadores
{
    public abstract class ModNumero : Modificador
    {
        public decimal Valor { get; set; }
        public abstract char Operador { get; }
        public string Alvo { get; set; }

        public override string ToString()
        {
            return this.Alvo + this.Operador + this.Valor.ToString() + " (" + this.Origem + ")";
        }
    }

    public class ModSomaNumero : ModNumero
    {
        public override char Operador => '+';
    }

    public class ModSubtraiNumero : ModNumero
    {
        public override char Operador => '-';
    }

    public class ModMultiplicaNumero : ModNumero
    {
        public override char Operador => '*';
    }

    public class ModDivideNumero : ModNumero
    {
        public override char Operador => '/';
    }

    public class ModZeraNumero : ModNumero
    {
        public override char Operador => '0';
        public decimal ValorAnterior;
    }

}

