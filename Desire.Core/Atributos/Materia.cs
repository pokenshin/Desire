namespace Desire.Core
{
    public class Materia : Atributo
    {
        public ValorMag Colapso { get; set; }
        public ValorMag Impulso { get; set; }
        public ValorMag Resistencia { get; set; }
        public ValorMag Vitalidade { get; set; }
        public ValorMag Carga { get; set; }
        public decimal BonusAP { get; set; }
        public ValorMag BonusHP { get; set; }

        public Materia()
        {
            this.Colapso = new ValorMag();
            this.Impulso = new ValorMag();
            this.Resistencia = new ValorMag();
            this.Vitalidade = new ValorMag();
            this.Carga = new ValorMag();
            this.BonusAP = 0;
            this.BonusHP = new ValorMag();
        }
    }
}