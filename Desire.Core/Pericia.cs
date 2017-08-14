using System.Collections.Generic;

namespace Desire.Core
{
    public class Pericia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Modificador> Modificadores { get; set; }
        public string Efeitos { get; set; }
    }
}