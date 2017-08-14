namespace Desire.Core
{
    public class Realidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Realidade(string nome)
        {
            this.Nome = nome;
        }

        public Realidade()
        {
        }
    }
}