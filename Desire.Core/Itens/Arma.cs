namespace Desire.Core.Itens
{
    public abstract class Arma : Equipamento
    {
        public int DanoPenetracao { get; set; }
        public int DanoCorte { get; set; }
        public int DanoImpacto { get; set; }
    }
}