using System.Collections.Generic;

namespace Desire.Core
{
    public class Classe
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estilo { get; set; }
        public string Funcao { get; set; }
        public string OrigemPoder { get; set; }
        public string AtributoFisico { get; set; }
        public string AtributoMental { get; set; }
        public string AtributoEspiritual { get; set; }
        public string Descricao { get; set; }
        public Pericia PericiaPrincipal { get; set; }
        public List<Pericia> PericiasSecundarias { get; set; }
    }
}