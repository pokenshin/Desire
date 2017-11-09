using Desire.Core.Ciencias;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desire.Core.Modificadores
{
    public abstract class ModPericia : Modificador
    {
        public Pericia Alvo { get; set; }

        public abstract override string ToString();
    }

    public class ModAdicionaPericia : ModPericia
    {
        public override string ToString()
        {
            return "Adiciona a perícia: " + this.Alvo.Nome + " (" + this.Origem + ")";
        }
    }

    public class ModRemovePericia : ModPericia
    {
        public override string ToString()
        {
            return "Remove a perícia: " + this.Alvo.Nome + " (" + this.Origem + ")";
        }
    }
}
