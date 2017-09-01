namespace Desire.Core
{
    public class Intelecto : Atributo
    {
        public ValorMag Concentracao { get; set; }
        public ValorMag Aprendizagem { get; set; }
        public ValorMag Memoria { get; set; }
        public ValorMag Senso { get; set; }
        public ValorMag Eidos { get; set; }
        public ValorMag BonusAP { get; internal set; }

        public Intelecto()
        {
            this.Concentracao = new ValorMag();
            this.Aprendizagem = new ValorMag();
            this.Memoria = new ValorMag();
            this.Senso = new ValorMag();
            this.Eidos = new ValorMag();
            this.BonusAP = new ValorMag();
        }
    }
}