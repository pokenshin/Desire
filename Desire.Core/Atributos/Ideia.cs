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
    }
}