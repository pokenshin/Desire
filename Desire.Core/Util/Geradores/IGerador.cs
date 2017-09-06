using System;
using System.Collections.Generic;
using System.Text;

namespace Desire.Core.Util.Geradores
{
    interface IGerador<T>
    {
        ///<summary>
        ///Gera um objeto aleatório.
        ///</summary>
        T Gerar(Random rnd);
        ///<summary>
        ///Gera uma lista de objetos aleatórios
        ///</summary>
        ///<param name="quantidade">Quantidade máxima de objetos na lista</param>
        List<T> GerarLista(int quantidade, Random rnd);
    }
}
