using System.Collections.Generic;

namespace Desire.Core.Identidade
{
    public class Rei
    {
        public int Id { get; set; }
        public string Nome { get; internal set; }
        public int Magnitude { get; internal set; }
        public List<Modificador> Modificadores { get; internal set; }
        public string Origem { get; internal set; }
        public string Cor { get; internal set; }
    }
}