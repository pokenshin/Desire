namespace Desire.Core
{
    public class Forca: Atributo
    {
        public ValorMag Potencia { get; set; }
        public decimal Golpe { get; set; }
        public decimal Dureza { get; set; }
        public ValorMag Vigor { get; set; }
        public ValorMag Sustentacao { get; set; }
        public decimal BonusCP { get; set; }

        public Forca()
        {
            this.Pontos = 1;
            this.Potencia = new ValorMag();
            this.Golpe = 0;
            this.Dureza = 0;
            this.Vigor = new ValorMag();
            this.Sustentacao = new ValorMag();
            this.BonusCP = 0;
        }
    }
}