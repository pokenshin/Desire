namespace Desire.Core
{
    public class Destreza : Atributo
    {
        public ValorMag Reflexo { get; set; }
        public ValorMag Esquiva { get; set; }
        public ValorMag Ataque { get; set; }
        public decimal Dinamica { get; set; }
        public int Iniciativa { get; set; }
        public decimal BonusCP { get; set; }

        public Destreza()
        {
            this.Pontos = 1;
            this.Reflexo = new ValorMag();
            this.Esquiva = new ValorMag();
            this.Ataque = new ValorMag();
            this.Dinamica = 0;
            this.Iniciativa = 0;
            this.BonusCP = 0;
        }
    }
}