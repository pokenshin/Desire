namespace Desire.Core.Energias
{
    public class Energia
    {
        public string Sigla { get; set; }
        public decimal Quantidade { get; set; }

        public Energia(string sigla, decimal quantidade)
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