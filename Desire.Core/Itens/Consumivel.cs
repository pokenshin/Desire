using System;
using System.Collections.Generic;
using System.Text;
using Desire.Core.Efeitos;

namespace Desire.Core.Itens
{
    public class Consumivel : Item
    {
        public List<IEfeito> Efeitos { get; set; }
    }
}
