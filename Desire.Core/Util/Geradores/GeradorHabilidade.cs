using System;
using System.Collections.Generic;
using Desire.Core.Ciencias;
namespace Desire.Core.Util.Geradores
{
    public class GeradorHabilidade : IGerador<Habilidade>
    {
        GeradorInteiro rng = new GeradorInteiro();

        public Habilidade Gerar()
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

            Habilidade habilidade = new Habilidade()
            {
                Id = rng.GerarEntre(1, 1000),
                Magnitude = rng.GerarEntre(1, 10),
                Nome = genString.GerarTamanhoEspecifico(2, 8),
                PericiaAssociada = genPericia.Gerar(),
                Energia = genEnergia.Gerar(),
                AreaCientifica = genAreaCientifica.Gerar(),
                Efeitos = genEfeito.GerarLista(rng.GerarEntre(1,3))
            };
            habilidade.Caracteristicas = "Habilidade gerada automaticamente.";

            return habilidade;
        }

        public List<Habilidade> GerarLista(int quantidade)
        {
            List<Habilidade> resultado = new List<Habilidade>();

            for (int i = 0; i < quantidade-1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}