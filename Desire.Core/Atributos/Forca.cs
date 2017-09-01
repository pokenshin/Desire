namespace Desire.Core
{
    public class Forca: Atributo
    {
        public ValorMag Potencia { get; set; }
        public ValorMag Golpe { get; set; }
        public ValorMag Dureza { get; set; }
        public ValorMag Vigor { get; set; }
        public ValorMag Sustentacao { get; set; }
        public ValorMag BonusAP { get; internal set; }

        public Forca()
        {
            this.Potencia = new ValorMag();
            this.Golpe = new ValorMag();
            this.Dureza = new ValorMag();
            this.Vigor = new ValorMag();
            this.Sustentacao = new ValorMag();
            this.BonusAP = new ValorMag();
        }
    }
}