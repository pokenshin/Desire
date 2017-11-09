namespace Desire.Core
{
    public class Materia : Atributo
    {
        public ValorMag Colapso { get; set; }
        public ValorMag Impulso { get; set; }
        public ValorMag Resistencia { get; set; }
        public ValorMag Vitalidade { get; set; }
        public decimal BonusCP { get; set; }
        public ValorMag BonusHP { get; set; }
        public ValorMag Carga { get; set; }

        public Materia()
        {
            this.Pontos = 1;
            this.Colapso = new ValorMag();
            this.Impulso = new ValorMag();
            this.Resistencia = new ValorMag();
            this.Vitalidade = new ValorMag();
            this.BonusCP = 0;
            this.BonusHP = new ValorMag();
            this.Carga = new ValorMag();
        }
    }
}