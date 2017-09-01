namespace Desire.Core.Identidade
{
    public class Natureza
    {
        public int Honra { get; set; }
        public int Moral { get; set; }
        public int Personalidade { get; set; }
        public int Apresentacao { get; set; }
        public int Percepcao { get; set; }
        public int Concepcao { get; set; }

        public Natureza()
        {
            this.Honra = 0;
            this.Moral = 0;
            this.Personalidade = 0;
            this.Apresentacao = 0;
            this.Percepcao = 0;
            this.Concepcao = 0;
        }
    }
}