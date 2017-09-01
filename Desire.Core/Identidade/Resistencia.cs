namespace Desire.Core.Identidade
{
    public class Resistencia
    {
        public string Nome { get; set; }
        public ValorMag Positiva { get; set; }
        public ValorMag Negativa { get; set; }

        public Resistencia(string nome, ValorMag positiva, ValorMag negativa)
        {
            this.Nome = nome;
            this.Positiva = positiva;
            this.Negativa = negativa;
        }

        public Resistencia()
        {
            this.Nome = "Vazio";
            this.Positiva = new ValorMag();
            this.Negativa = new ValorMag();
        }
    }
}