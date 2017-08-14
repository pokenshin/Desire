namespace Desire.Core
{
    public class Evolucao
    {
        public int PontosAtuais { get; set; }
        public int PontosMax { get; set; }
        public bool ChakraAberto { get; set; }

        public Evolucao(int pontos, int max, bool chakraAberto)
        {
            if (pontos > max)
                this.PontosAtuais = max;
            else
                this.PontosAtuais = pontos;
            this.PontosMax = max;
            this.ChakraAberto = chakraAberto;
        }

        public Evolucao()
        {
            this.PontosAtuais = 0;
            this.PontosMax = 16;
            this.ChakraAberto = false;
        }

        public Evolucao(int pontos, bool chakraAberto)
        {
            this.PontosMax = 16;
            if (pontos > PontosMax)
                this.PontosAtuais = PontosMax;
            else
                this.PontosAtuais = pontos;
            this.ChakraAberto = chakraAberto;
        }

        public Evolucao(int pontos)
        {
            this.PontosMax = 16;
            if (pontos > PontosMax)
                this.PontosAtuais = PontosMax;
            else
                this.PontosAtuais = pontos;
            this.ChakraAberto = false;
        }
    }
}