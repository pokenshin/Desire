using System;
using System.Collections.Generic;
using Desire.Core.Ciencias;
namespace Desire.Core.Util.Geradores
{
    public class GeradorHabilidade : IGerador<Habilidade>
    {
        GeradorInteiro rng = new GeradorInteiro();

        public Habilidade Gerar(Random rnd)
        {
            //TODO: Pegar aleatoriamente do banco de dados de habilidades
            //TODO: Pegar Pericia Associada do banco de dados de pericias
            //TODO: Criar efeitos secundários. Ex: dano + buff, cura +  piora, etc

            //TODO: Restringir o tipo da Habilidade por uma lista do banco de dados
            GeradorInteiro rng = new GeradorInteiro();
            GeradorString genString = new GeradorString();
            GeradorPericia genPericia = new GeradorPericia();
            GeradorEnergia genEnergia = new GeradorEnergia();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorAreaCientifica genAreaCientifica = new GeradorAreaCientifica();
            GeradorTipoDeAlvo genTipoDeAlvo = new GeradorTipoDeAlvo();
            GeradorEfeito genEfeito = new GeradorEfeito();
            GeradorTipoDeHabilidade genTipoDeHabilidade = new GeradorTipoDeHabilidade();

            Habilidade habilidade = new Habilidade()
            {
                Id = rng.GerarEntre(1, 1000, rnd),
                Magnitude = rng.GerarEntre(1, 10, rnd),
                Nome = genString.GerarTamanhoEspecifico(2, 8, rnd),
                PericiaAssociada = genPericia.Gerar(rnd),
                Energia = genEnergia.Gerar(rnd),
                AreaCientifica = genAreaCientifica.Gerar(rnd),
                Efeitos = genEfeito.GerarLista(rng.GerarEntre(1, 3, rnd), rnd),
                Tipo = genTipoDeHabilidade.Gerar(rnd)
            };
            habilidade.Caracteristicas = "Habilidade gerada automaticamente.";

            return habilidade;
        }

        public List<Habilidade> GerarLista(int quantidade, Random rnd)
        {
            List<Habilidade> resultado = new List<Habilidade>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}