using System.Collections.Generic;
using Desire.Core.Modificadores;

namespace Desire.Core.Identidade
{
    public class Rei
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Magnitude { get; set; }
        public List<Modificador> Modificadores { get; set; }
        public string Origem { get; set; }
        public string Cor { get; set; }
    }
}