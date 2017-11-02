namespace Desire.Core
{
    public class Existencia : Atributo
    {
        public ValorMag Conhecimento { get; set; }
        public ValorMag Experiencia { get; set; }
        public ValorMag Ciencia { get; set; }
        public ValorMag Consciencia { get; set; }
        public int Plano { get; set; }
        public decimal BonusAP { get; set; }

        public Existencia()
        {
            this.BonusAP = 0;
            this.Ciencia = new ValorMag();
            this.Classe = "P";
            this.Conhecimento = new ValorMag();
            this.Consciencia = new ValorMag();
            this.Experiencia = new ValorMag();
            this.Nivel = 0;
            this.Plano = 0;
            this.Porcentagem = new ValorMag();
        }
    }
}