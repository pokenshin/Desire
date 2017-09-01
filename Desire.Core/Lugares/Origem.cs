namespace Desire.Core
{
    public class Origem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Plano Plano { get; set; }

        public Origem (string nome, Plano plano)
        {
            this.Nome = nome;
            this.Plano = plano;
        }

        public Origem()
        {
            this.Nome = "";
            this.Plano = new Plano();
        }
    }
}