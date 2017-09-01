namespace Desire.Core.Identidade
{
    public class Resposta
    {
        public int Desespero { get; set; }
        public int Panico { get; set; }
        public int Medo { get; set; }
        public int Indiferenca { get; set; }
        public int Coragem { get; set; }
        public int Bravura { get; set; }
        public int Heroismo { get; set; }

        public Resposta()
        {
            this.Desespero = 0;
            this.Panico = 0;
            this.Medo = 0;
            this.Indiferenca = 0;
            this.Coragem = 0;
            this.Bravura = 0;
            this.Heroismo = 0;
        }
    }
}