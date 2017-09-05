using System;
using System.Collections.Generic;
using Desire.Core.Ciencias;

namespace Desire.Core.Util.Geradores
{
    public class GeradorAreaCientifica : IGerador<AreaCientifica>
    {
        public AreaCientifica Gerar()
        {
            GeradorCiencia genCiencia = new GeradorCiencia();
            GeradorString genString = new GeradorString();

            AreaCientifica resultado = new AreaCientifica()
            {
                Nome = genString.GerarTamanhoEspecifico(3, 8),
                Ciencia = genCiencia.Gerar()
            };
            return resultado;
        }

        public List<AreaCientifica> GerarLista(int quantidade)
        {
            List<AreaCientifica> resultado = new List<AreaCientifica>();

            for (int i = 0; i < quantidade-1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}