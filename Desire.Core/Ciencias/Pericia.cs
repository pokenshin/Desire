using System.Collections.Generic;

namespace Desire.Core.Ciencias
{
    public class Pericia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Ciencia Ciencia { get; set; }
        public string Caracteristicas { get; set; }
        public List<Modificador> Modificadores { get; set; }
    }
}