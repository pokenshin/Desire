﻿using System;
using System.Collections.Generic;
using System.Text;
using Desire.Core.Ciencias;
using Desire.Core.Energias;
using Desire.Core.Modificadores;

namespace Desire.Core.Efeitos
{
    public interface IEfeito
    {
        string Tipo { get; }
        string Descricao { get; }
        DuracaoEfeito Duracao { get; set; }
        IAlvoHabilidade TipoDeAlvo { get; set; }
    }

    public class EfeitoDano : IEfeito
    {
        public string Tipo => "Dano";
        public ValorMag Valor { get; set; }
        public Energia EnergiaAlvo { get; set; }
        public string Descricao => "Danifica " + this.Valor.ToString() + " pontos de " + this.EnergiaAlvo.Sigla;
        public DuracaoEfeito Duracao { get; set; }
        public IAlvoHabilidade TipoDeAlvo { get; set; }
    }

    public class EfeitoCura : IEfeito
    {
        public string Tipo => "Cura";
        public ValorMag Valor { get; set; }
        public Energia EnergiaAlvo { get; set; }
        public string Descricao => "Cura " + this.Valor.ToString() + " pontos de " + this.EnergiaAlvo.Sigla;
        public DuracaoEfeito Duracao { get; set; }
        public IAlvoHabilidade TipoDeAlvo { get; set; }
    }

    public class EfeitoModificador:IEfeito
    {
        public string Tipo => "Modificador";
        public Modificador Modificador { get; set; }
        public string Descricao => "Aplica o modificador: " + this.Modificador.ToString() ;
        public DuracaoEfeito Duracao { get; set; }
        public IAlvoHabilidade TipoDeAlvo { get; set; }
    }
}
