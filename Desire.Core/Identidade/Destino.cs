namespace Desire.Core.Identidade
{
    public class Destino
    {
        public int Desgraca { get; set; }
        public int Azar { get; set; }
        public int Acaso { get; set; }
        public int Sorte { get; set; }
        public int Milagre { get; set; }

        public Destino()
        {
            this.Desgraca = 0;
            this.Azar = 0;
            this.Acaso = 0;
            this.Sorte = 0;
            this.Milagre = 0;
        }
    }
}