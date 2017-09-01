﻿namespace Desire.Core
{
    public class Destreza : Atributo
    {
        public ValorMag Reflexo { get; set; }
        public ValorMag Esquiva { get; set; }
        public ValorMag Ataque { get; set; }
        public ValorMag Dinamica { get; set; }
        public ValorMag Iniciativa { get; set; }
        public ValorMag BonusAP { get; internal set; }

        public Destreza()
        {
            this.Reflexo = new ValorMag();
            this.Esquiva = new ValorMag();
            this.Ataque = new ValorMag();
            this.Dinamica = new ValorMag();
            this.Iniciativa = new ValorMag();
            this.BonusAP = new ValorMag();
        }
    }
}