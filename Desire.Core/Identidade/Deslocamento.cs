using System;

namespace Desire.Core.Identidade
{
    public class Deslocamento
    {
        public ValorMag Valor { get; set; }
        public string Tipo { get; set; }
        public string Unidade => "km/h";

        public override string ToString()
        {
            return Valor.ToString() + " " + Unidade;
        }

        public Deslocamento(string tipo)
        {
            this.Tipo = tipo;
            Valor = new ValorMag();
        }

        public Deslocamento() { }

    }
}