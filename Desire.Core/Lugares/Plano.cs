namespace Desire.Core
{
    public class Plano
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Realidade Realidade { get; set; }

        public Plano (string nome, Realidade realidade)
        {
            this.Nome = nome;
            this.Realidade = realidade;
        }

        public Plano()
        {

        }
    }
}