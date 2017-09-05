namespace Desire.Core.Efeitos
{
    public class DuracaoEfeito
    {
        public string TipoDuracao;
        public ValorMag ValorDuracao;
        public string UnidadeDuracao;

        public override string ToString()
        {
            if (this.ValorDuracao != null && UnidadeDuracao != null)
                return "Durante " + ValorDuracao.ToString() + " " + UnidadeDuracao;
            else
                return this.TipoDuracao;
        }
    }
}