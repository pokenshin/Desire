using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Desire.Core.Util.Geradores
{
    interface IGeradorModificador<T>
    {
        ///<summary>
        ///Gera um modificador de determinada origem com o id da origem.
        ///</summary>
        /// <param name="origem">De onde o modificador está vindo.</param>
        /// <param name="id">Qual a ID da origem do modificador.</param>
        T GerarComOrigem(string origem, int id, char tipo = 'R');
        ///<summary>
        ///Gera uma lista de modificadores de origem específica na quantidade especifícada.
        ///</summary>
        /// <param name="origem">De onde o modificador está vindo.</param>
        /// <param name="id">Qual a ID da origem do modificador.</param>
        /// <param name="quantidade">Número de itens da lista.</param>
        List<T> GerarListaComOrigem(string origem, int id, int quantidade, char tipo = 'R');
    }

    public class GeradorModificador : IGerador<Modificador>, IGeradorModificador<Modificador>
    {
        GeradorInteiro rng = new GeradorInteiro();
        char[] tiposModificadores = new char[] { '+', '*', '-', '/' };

        public Modificador Gerar()
        {
            return GerarComOrigem("Gerado Aleatoriamente", 0);
        }

        public List<Modificador> GerarLista(int quantidade)
        {
            List<Modificador> lista = new List<Modificador>();

            for (int i = 0; i < quantidade-1; i++)
            {
                lista.Add(Gerar());
            }

            return lista;
        }

        public List<Modificador> GerarListaComOrigem(string origem, int id, int quantidade, char tipo = 'R')
        {
            List<Modificador> lista = new List<Modificador>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                lista.Add(GerarComOrigem(origem, id, tipo));
            }

            return lista;
        }

        public Modificador GerarComOrigem(string origem, int id, char tipo = 'R')
        {
            //TODO: Gerar modifiadores menos random e com mais sentido
            //TODO: Melhorar nome do modificador
            //TODO: Tratamento especial para modificadores de classe
            //TODO: Criar magnitude do modificador para limitar sua apelação e direcionar uso
            GeradorValorMag genValorMag = new GeradorValorMag();
            PropertyInfo[] propriedades = typeof(Ser).GetProperties().Where(p => p.PropertyType == typeof(int)).ToArray<PropertyInfo>();
            string nomePropriedade = propriedades[rng.GerarEntre(0, propriedades.Count() - 1)].Name;
            PropertyInfo alvo = typeof(Ser).GetProperty(nomePropriedade);
            ValorMag valor = genValorMag.Gerar();
            if (tipo == 'R')
                tipo = tiposModificadores[rng.GerarEntre(0, tiposModificadores.Count() - 1)];

            string nome = nomePropriedade + tipo + valor;

            Modificador modificador = new Modificador()
            {
                Nome = nome,
                Alvo = alvo,
                Valor = valor,
                Tipo = tipo,
                Origem = origem,
                OrigemId = id
            };
            return modificador;
        }
    }
}