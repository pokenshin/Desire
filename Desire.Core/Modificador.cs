﻿using System.Reflection;

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

        //Tipos possiveis:
        //"*" = Multiplicação
        //"+" = Adição
        //"-" = Subtração
        //"/" = Divisão
    }
}