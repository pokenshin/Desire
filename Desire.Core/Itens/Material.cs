namespace Desire.Core.Itens
{
    public class Material
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Dureza { get; set; }
        public int DurezaMag { get; set; }
        public ValorMag Resistencia { get; set; }
        public int Raridade { get; set; }
        public int ValorPorGrama { get; set; }
        public ValorMag DensidadePorGrama { get; set; }
    }
}