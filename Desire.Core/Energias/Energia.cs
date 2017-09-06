namespace Desire.Core.Energias
{
    public class Energia
    {
        public string Sigla { get; set; }
        public double Quantidade { get; set; }

        public Energia(string sigla, double quantidade)
        {
            this.Sigla = sigla;
            this.Quantidade = quantidade;
        }

        public Energia(string sigla)
        {
            this.Sigla = sigla;
            this.Quantidade = 0;
        }

        public Energia() { }
    }
}