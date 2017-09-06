using System;
using System.Collections.Generic;
using Desire.Core.Ciencias;

namespace Desire.Core.Util.Geradores
{
    public class GeradorClasse : IGerador<Classe>
    {
        public Classe Gerar(Random rnd)
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
                AtributoEspiritual = atributosEspirituais[rng.GerarEntre(0, atributosEspirituais.Length - 1, rnd)],
                AtributoFisico = atributosFisicos[rng.GerarEntre(0, atributosFisicos.Length - 1, rnd)],
                AtributoMental = atributosMentais[rng.GerarEntre(0, atributosMentais.Length - 1, rnd)],
                Estilo = estilos[rng.GerarEntre(0, estilos.Length - 1, rnd)],
                Funcao = funcoes[rng.GerarEntre(0, funcoes.Length - 1, rnd)],
                Nome = genString.GerarTamanhoEspecifico(4, 8, rnd),
                OrigemPoder = genString.GerarTamanhoEspecifico(4, 8, rnd),
                Ciencia = genCiencia.Gerar(rnd),
                Pericias = genPericia.GerarLista(rng.GerarEntre(1, 5, rnd), rnd)
            };
            classe.Descricao = "Classe de estilo " + classe.Estilo + ", utilizando " + classe.AtributoFisico + ", " + classe.AtributoEspiritual + " e " + classe.AtributoMental + ", com a função principal de " + classe.Funcao + " gerada aleatoriamente.";

            return classe;
        }

        public List<Classe> GerarLista(int quantidade, Random rnd)
        {
            List<Classe> resultado = new List<Classe>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}