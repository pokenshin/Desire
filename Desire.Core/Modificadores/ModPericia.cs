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

        public override Ser AplicaModificador(Ser ser)
        {
            if (!ser.Pericias.Contains(this.Alvo))
                ser.Pericias.Add(this.Alvo);
            return ser;
        }

        public override Ser RemoveModificador(Ser ser)
        {
            if (ser.Pericias.Contains(this.Alvo))
                ser.Pericias.Remove(this.Alvo);
            return ser;
        }
    }

    public class ModRemovePericia : ModPericia
    {
        public override Ser AplicaModificador(Ser ser)
        {
            if (ser.Pericias.Contains(this.Alvo))
                ser.Pericias.Remove(this.Alvo);
            return ser;
        }

        public override Ser RemoveModificador(Ser ser)
        {
            if (!ser.Pericias.Contains(this.Alvo))
                ser.Pericias.Add(this.Alvo);
            return ser;
        }

        public override string ToString()
        {
            return "Remove a perícia: " + this.Alvo.Nome + " (" + this.Origem + ")";
        }
    }
}
