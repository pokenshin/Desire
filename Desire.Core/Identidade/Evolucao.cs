namespace Desire.Core.Identidade
{
    public class Evolucao
    {
        public int PontosAtuais { get; set; }
        public int Multiplicador { get; set; }
        public bool ChakraAberto { get; set; }
        public string ChakraNome { get; set; }
        public int ChakraMag { get; set; }

        public Evolucao(int pontos, int multi, bool chakraAberto)
        {
            if (pontos > multi)
                this.PontosAtuais = multi;
            else
                this.PontosAtuais = pontos;
            this.Multiplicador = multi;
            this.ChakraAberto = chakraAberto;
        }

        public Evolucao()
        {
            this.PontosAtuais = 0;
            this.Multiplicador = 1;
            this.ChakraAberto = false;

        }

        public Evolucao(int pontos, bool chakraAberto)
        {
            this.Multiplicador = 1;
            if (pontos > Multiplicador)
                this.PontosAtuais = Multiplicador;
            else
                this.PontosAtuais = pontos;
            this.ChakraAberto = chakraAberto;
        }

        public Evolucao(int pontos)
        {
            this.Multiplicador = 1;
            if (pontos > Multiplicador)
                this.PontosAtuais = Multiplicador;
            else
                this.PontosAtuais = pontos;
            this.ChakraAberto = false;
        }
    }
}