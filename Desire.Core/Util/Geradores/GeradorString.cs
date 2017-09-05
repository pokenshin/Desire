using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desire.Core;
using System.Reflection;
using Desire.Core.Itens;
using Desire.Core.Identidade;

namespace Desire.Core.Util.Geradores
{
    ///<summary>
    ///Classe para geração de strings aleatórias.
    ///</summary>
    public class GeradorString : IGerador<string>
    {
        Random rnd = new Random();
        GeradorInteiro rng = new GeradorInteiro();
        static string consoantes = "bcdfghjklmnpqrstvwxyz";
        static string vogais = "aeiou";

        public string Gerar()
        {
            int min = rng.GerarEntre(1, 10);
            int max = min + rng.GerarEntre(1, 10);

            return GerarTamanhoEspecifico(min, max);
        }

        ///<summary>
        ///Gera uma string de um tamanho especifico.
        ///</summary>
        /// <param name="min">Tamanho mínimo da string</param>
        /// <param name="max">Tamanho máximo da string</param>
        public string GerarTamanhoEspecifico(int min, int max)
        {
            GeradorBoolean geradorBoolean = new GeradorBoolean();
            string nome = "";
            int tamanhoNome = rng.GerarEntre(min, max);

            while (nome.Length < tamanhoNome)
            {
                if (nome.Length == 0)
                {
                    if (geradorBoolean.GeraComChance(50))
                        nome = Convert.ToString(consoantes[rnd.Next(0, consoantes.Length)]).ToUpper();
                    else
                        nome = Convert.ToString(vogais[rnd.Next(0, vogais.Length)]).ToUpper();
                }
                else
                {
                    char ultimaLetra = nome[nome.Length - 1]; //Pega última letra
                    int chanceVogal = 50; //Inicializa chance da proxima letra ser vogal

                    //Caso a ultima letra seja consoante
                    if (consoantes.Contains(ultimaLetra))
                    {
                        if (nome.Length > 1) //Caso o nome tenha mais de 1 letra
                        {
                            if (nome.Length > 2) //Caso o nome tenha mais de 2 letras
                            {
                                if (consoantes.Contains(nome[nome.Length - 3]))
                                    chanceVogal = 100; //Evita com que nomes tenham mais de 3 consoantes seguidas
                            }
                            else if (consoantes.Contains(nome[nome.Length - 2]))
                                chanceVogal = 90;
                        }
                        else
                            chanceVogal = 70;
                    }
                    //Caso a última letra seja vogal
                    else
                    {
                        if (nome.Length > 1)
                        {
                            if (vogais.Contains(nome[nome.Length - 2]))
                                chanceVogal = 1;
                            else
                                chanceVogal = 10;
                        }
                        else
                            chanceVogal = 30;
                    }

                    if (geradorBoolean.GeraComChance(chanceVogal))
                        nome = nome + Convert.ToString(vogais[rnd.Next(0, vogais.Length)]);
                    else
                        nome = nome + Convert.ToString(consoantes[rnd.Next(0, consoantes.Length)]);
                }
            }

            return nome;
        }

        public List<string> GerarLista(int quantidade)
        {
            List<string> resultado = new List<string>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}