namespace Desire.Core
{
    public class Ideia : Atributo
    {
        public decimal Ki { get; set; }
        public int Base { get; set; }
        public ValorMag Misterio { get; set; }
        public ValorMag Irrealidade { get; set; }
        public ValorMag Nexo { get; set; }
        public ValorMag BonusMP { get; internal set; }

        public Ideia()
        {
            this.Pontos = 1;
            this.Ki = 0;
            this.Base = 0;
            this.Misterio = new ValorMag();
            this.Irrealidade = new ValorMag();
            this.Nexo = new ValorMag();
            this.BonusMP = new ValorMag();
        }
    }


}