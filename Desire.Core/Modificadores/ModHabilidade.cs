using Desire.Core.Ciencias;
using Desire.Core.Util;
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
        public override Ser AplicaModificador(Ser ser)
        {
            if (!ser.Habilidades.Contains(this.Alvo))
                ser.Habilidades.Add(this.Alvo);

            return ser;
        }

        public override Ser RemoveModificador(Ser ser)
        {
            if (ser.Habilidades.Contains(this.Alvo))
                ser.Habilidades.Remove(this.Alvo);

            return ser;
        }

        public override string ToString()
        {
            return "Adiciona a habilidade: " + this.Alvo.Nome + " (" + this.Origem + ")";
        }
    }

    public class ModRemoveHabilidade : ModHabilidade
    {
        public override Ser AplicaModificador(Ser ser)
        {
            if (ser.Habilidades.Contains(this.Alvo))
                ser.Habilidades.Remove(this.Alvo);

            return ser;
        }

        public override Ser RemoveModificador(Ser ser)
        {
            if (!ser.Habilidades.Contains(this.Alvo))
                ser.Habilidades.Add(this.Alvo);

            return ser;
        }

        public override string ToString()
        {
            return "Adiciona a habilidade: " + this.Alvo.Nome + " (" + this.Origem + ")";
        }
    }
}
