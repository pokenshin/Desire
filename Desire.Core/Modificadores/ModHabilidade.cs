using Desire.Core.Ciencias;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Desire.Core.Modificadores
{
    public abstract class ModHabilidade : Modificador
    {
        public Habilidade Alvo { get; set; }
        public abstract override string ToString();
    }

    public class ModAdicionaHabilidade : ModHabilidade
    {
        public override string ToString()
        {
            return "Adiciona a habilidade: " + this.Alvo.Nome + " (" + this.Origem + ")";
        }
    }

    public class ModRemoveHabilidade : ModHabilidade
    {
        public override string ToString()
        {
            return "Adiciona a habilidade: " + this.Alvo.Nome + " (" + this.Origem + ")";
        }
    }
}
