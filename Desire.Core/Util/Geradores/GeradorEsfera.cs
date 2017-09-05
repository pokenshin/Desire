using System;
using System.Collections.Generic;
using Desire.Core.Ciencias;

namespace Desire.Core.Util.Geradores
{
    public class GeradorEsfera : IGerador<Esfera>
    {
        public Esfera Gerar()
        {
            GeradorString rsg = new GeradorString();
            //TODO: Pegar esfera do banco de dados de esferas
            Esfera resultado = new Esfera()
            {
                Nome = rsg.GerarTamanhoEspecifico(3, 8)
            };
            return resultado;
        }

        public List<Esfera> GerarLista(int quantidade)
        {
            List<Esfera> resultado = new List<Esfera>();

            for (int i = 0; i < quantidade-1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}