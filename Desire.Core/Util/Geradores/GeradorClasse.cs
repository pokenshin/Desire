using System;
using System.Collections.Generic;
using Desire.Core.Ciencias;

namespace Desire.Core.Util.Geradores
{
    public class GeradorClasse : IGerador<Classe>
    {
        public Classe Gerar()
        {
            string[] atributosEspirituais = new string[] { "Idéia", "Existência" };
            string[] atributosFisicos = new string[] { "Força", "Destreza", "Matéria" };
            string[] atributosMentais = new string[] { "Intelecto", "Criatividade" };
            string[] estilos = new string[] { "Melee", "Ranged", "Caster", "Comando", "Ofício" };
            string[] funcoes = new string[] { "Dano", "Cura", "Suporte", "Controle", "Crafting" };
            GeradorInteiro rng = new GeradorInteiro();
            GeradorString genString = new GeradorString();
            GeradorCiencia genCiencia = new GeradorCiencia();
            GeradorPericia genPericia = new GeradorPericia();
            Classe classe = new Classe()
            {
                AtributoEspiritual = atributosEspirituais[rng.GerarEntre(0, atributosEspirituais.Length - 1)],
                AtributoFisico = atributosFisicos[rng.GerarEntre(0, atributosFisicos.Length - 1)],
                AtributoMental = atributosMentais[rng.GerarEntre(0, atributosMentais.Length - 1)],
                Estilo = estilos[rng.GerarEntre(0, estilos.Length - 1)],
                Funcao = funcoes[rng.GerarEntre(0, funcoes.Length - 1)],
                Nome = genString.GerarTamanhoEspecifico(4, 8),
                OrigemPoder = genString.GerarTamanhoEspecifico(4, 8),
                Ciencia = genCiencia.Gerar(),
                Pericias = genPericia.GerarLista(rng.GerarEntre(1, 5))
            };
            classe.Descricao = "Classe de estilo " + classe.Estilo + ", utilizando " + classe.AtributoFisico + ", " + classe.AtributoEspiritual + " e " + classe.AtributoMental + ", com a função principal de " + classe.Funcao + " gerada aleatoriamente.";

            return classe;
        }

        public List<Classe> GerarLista(int quantidade)
        {
            List<Classe> resultado = new List<Classe>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}