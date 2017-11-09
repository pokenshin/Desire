namespace Desire.Core
{
    public class Criatividade : Atributo
    {
        public ValorMag Singularidade { get; set; }
        public ValorMag Tutor { get; set; }
        public ValorMag Visualizacao { get; set; }
        public ValorMag Invencao { get; set; }
        public ValorMag Realidade { get; set; }
        public ValorMag BonusMP { get; set; }

        public Criatividade()
        {
            this.Pontos = 1;
            this.Singularidade = new ValorMag();
            this.Tutor = new ValorMag();
            this.Visualizacao = new ValorMag();
            this.Invencao = new ValorMag();
            this.Realidade = new ValorMag();
            this.BonusMP = new ValorMag();
        }
    }
}