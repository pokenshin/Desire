namespace Desire.Core.Identidade
{
    public class Indole
    {
        public int Id { get; set; } 
        public string Nome { get; set; }

        public Carisma Carisma { get; set; }
        public Destino Destino { get; set; }

        public Indole()
        {
            this.Id = 0;
            this.Nome = "";
            this.Carisma = new Carisma();
            this.Destino = new Destino();
        }
    }
}