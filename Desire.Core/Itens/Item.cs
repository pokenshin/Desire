﻿using System.Collections.Generic;

namespace Desire.Core.Itens
{
    public class Item
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Nivel { get; set; }
        public int Raridade { get; set; }
        public string Caracteristicas { get; set; }
        public List<Modificador> Modificadores { get; set; }
        public ValorMag Peso { get; set; }
        public ValorMag Largura { get; set; }
        public ValorMag Comprimento { get; set; }
        public int Essencia { get; set; }
        public int Energia { get; set; }
        public int Valor { get; set; }
        public int Tipo { get; set; }
        public Material MaterialBase { get; set; }
        public bool Equipavel { get; set; }
        public int Quantidade { get; set; }
    }
}