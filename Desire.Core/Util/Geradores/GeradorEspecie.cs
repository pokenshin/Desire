using System;
using System.Collections.Generic;
using System.Text;
using Desire.Core.Identidade;
using System.Linq;

namespace Desire.Core.Util.Geradores
{
    class GeradorEspecie : IGerador<Especie>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorString rsg = new GeradorString();

        public Especie Gerar()
        {
            GeradorOrigem genOrigem = new GeradorOrigem();
            GeradorCriatividade genCriatividade = new GeradorCriatividade();
            GeradorDestreza genDestreza = new GeradorDestreza();
            GeradorExistencia genExistencia = new GeradorExistencia();
            GeradorForca genForca = new GeradorForca();
            GeradorIdeia genIdeia = new GeradorIdeia();
            GeradorIntelecto genIntelecto = new GeradorIntelecto();
            GeradorMateria genMateria = new GeradorMateria();
            GeradorModificador genModificador = new GeradorModificador();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorEnergia genEnergia = new GeradorEnergia();
            GeradorPericia genPericia = new GeradorPericia();
            GeradorHabilidade genHabilidade = new GeradorHabilidade();
            GeradorNatureza genNatureza = new GeradorNatureza();
            GeradorResposta genResposta = new GeradorResposta();


            CalculadorSer calculadorSer = new CalculadorSer();
            CalculadorNumero calculadorNum = new CalculadorNumero();

            Especie especie = new Especie()
            {
                ReinoTaxo = rsg.GerarTamanhoEspecifico(2, 8),
                FiloTaxo = rsg.GerarTamanhoEspecifico(2, 9),
                ClasseTaxo = rsg.GerarTamanhoEspecifico(2, 8),
                OrdemTaxo = rsg.GerarTamanhoEspecifico(2, 8),
                FamiliaTaxo = rsg.GerarTamanhoEspecifico(2, 8),
                GeneroTaxo = rsg.GerarTamanhoEspecifico(2, 8),
                NomeCientifico = rsg.GerarTamanhoEspecifico(2, 8),
                NomePopular = rsg.GerarTamanhoEspecifico(2, 8),
                OrigemEspecie = genOrigem.Gerar(),
                MagnitudeMin = rng.GerarEntre(0, 15),
                MagnitudeMax = rng.GerarEntre(0, 15),
                ReiMin = rng.GerarEntre(0, 50),
                ReiMax = rng.GerarEntre(1, 50),
                KiMin = rng.GerarEntre(0, 1000),
                KiMax = rng.GerarEntre(1, 1000),
                NivelMin = rng.GerarEntre(0, 10000),
                TempoMax = rng.GerarEntre(1, 10000),
                Energias = genEnergia.GerarLista(rng.GerarEntre(1, 5)),
                ForcaMin = genForca.Gerar(),
                ForcaMax = genForca.Gerar(),
                MateriaMin = genMateria.Gerar(),
                MateriaMax = genMateria.Gerar(),
                DestrezaMin = genDestreza.Gerar(),
                DestrezaMax = genDestreza.Gerar(),
                NivelMax = rng.GerarEntre(1, 100000),
                IntelectoMin = genIntelecto.Gerar(),
                IntelectoMax = genIntelecto.Gerar(),
                CriatividadeMin = genCriatividade.Gerar(),
                CriatividadeMax = genCriatividade.Gerar(),
                ExistenciaMin = genExistencia.Gerar(),
                ExistenciaMax = genExistencia.Gerar(),
                IdeiaMin = genIdeia.Gerar(),
                IdeiaMax = genIdeia.Gerar(),
                PericiasEspecie = genPericia.GerarLista(rng.GerarEntre(1,10)),
                HabilidadesEspecie = genHabilidade.GerarLista(rng.GerarEntre(1, 3)),
                OrigemPoder = rsg.GerarTamanhoEspecifico(4, 10),
                VirtudesEspecie = genModificador.GerarListaComOrigem("Virtudes", 0, rng.GerarEntre(1, 10), '+'),
                DefeitosEspecie = genModificador.GerarListaComOrigem("Defeitos", 0, rng.GerarEntre(1, 10), '-'),
                ForcaVontadeMin = genValorMag.GerarEntre(new ValorMag(1,0), new ValorMag(99,15)),
                ForcaVontadeMax = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15)),
                IraMin = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15)),
                IraMax = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15)),
                PoderMaximoMin = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15)),
                PoderMaximoMax = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15)),
                FatorProgressao = rng.GerarEntre(1, 10),
                CansacoMax = rng.GerarEntre(0, 1000),
                FeMin = rng.GerarEntre(0, 1000),
                FeMax = rng.GerarEntre(0, 1000),
                KarmaMin = rng.GerarEntre(0, 1000),
                KarmaMax = rng.GerarEntre(0, 1000),
                MaxItensEquipados = rng.GerarEntre(1, 10),
                AcaoMin = rng.GerarEntre(1, 1000),
                AcaoMax = rng.GerarEntre(0, 1000),
                AlturaMin = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15)),
                AlturaMax = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15)),
                Id = rng.GerarEntre(1, 1000),
                MaxArmasEquipadas = rng.GerarEntre(1, 10),
                //TODO: Subclassificacoes = GeraSubclassificacoes(),
                TurnoMin = rng.GerarEntre(1, 1000),
                TurnoMax = rng.GerarEntre(1, 1000),
                MaturidadeMin = 0,
                MaturidadeMax = 0,
                DestriaMax = rng.GerarEntre(1, 10),
                DestriaMin = 1,
                Porcentagem = 0,
                TrabalhoMin = rng.GerarEntre(0, 1000),
                Densidade = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15)),
                LarguraMin = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15)),
                LarguraMax = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15)),
                Especial = rng.GerarEntre(1, 70),
                Natureza = genNatureza.Gerar(),
                RespostaMin = genResposta.Gerar()
            };
            especie.MagnitudeMax = especie.MagnitudeMin + especie.MagnitudeMax;
            especie.ReiMax = especie.ReiMin + especie.ReiMax;
            especie.KiMax = especie.KiMin + especie.KiMax;
            especie.ForcaVontadeMax = calculadorNum.SomaValorMag(especie.ForcaVontadeMin, especie.ForcaVontadeMax);
            especie.IraMax = calculadorNum.SomaValorMag(especie.IraMin, especie.IraMax);
            especie.PoderMaximoMax = calculadorNum.SomaValorMag(especie.PoderMaximoMin, especie.PoderMaximoMax);
            especie.FeMax = especie.FeMin + especie.FeMax;
            especie.KarmaMax = especie.KarmaMin + especie.KarmaMax;
            especie.AcaoMax = especie.AcaoMin + especie.AcaoMax;
            especie.AlturaMax = calculadorNum.SomaValorMag(especie.AlturaMin, especie.AlturaMax);
            especie.TurnoMax = especie.TurnoMin + especie.TurnoMax;
            especie.MaturidadeMin = (int)calculadorNum.CalculaPorcentagem(rng.GerarEntre(1, 30), especie.TempoMax);
            especie.MaturidadeMax = especie.MaturidadeMin + (int)calculadorNum.CalculaPorcentagem(rng.GerarEntre(60, 99), especie.TempoMax);
            especie.TrabalhoMax = especie.TrabalhoMin + rng.GerarEntre(0, 1000);
            especie.LarguraMax = calculadorNum.SomaValorMag(especie.LarguraMin, especie.LarguraMax);
            especie.RespostaMax = new Resposta()
            {
                Bravura = especie.RespostaMin.Bravura + rng.GerarEntre(1, 1000),
                Coragem = especie.RespostaMin.Coragem + rng.GerarEntre(1, 1000),
                Desespero = especie.RespostaMin.Desespero + rng.GerarEntre(1, 1000),
                Heroismo = especie.RespostaMin.Heroismo + rng.GerarEntre(1, 1000),
                Indiferenca = especie.RespostaMin.Indiferenca + rng.GerarEntre(1, 1000),
                Medo = especie.RespostaMin.Medo + rng.GerarEntre(1, 1000),
                Panico = especie.RespostaMin.Panico + rng.GerarEntre(1, 1000)
            };
            return especie;
        }

        public List<Especie> GerarLista(int quantidade)
        {
            {
                List<Especie> resultado = new List<Especie>();
                if (quantidade == 0)
                    quantidade = rng.GerarEntre(1, 5);

                int[] porcentagens = rng.GerarInteirosQueSomam(quantidade, 100);

                for (int i = 0; i < quantidade-1; i++)
                {
                    Especie especie = Gerar();
                    especie.Porcentagem = porcentagens[i];
                    resultado.Add(especie);
                }

                resultado = resultado.OrderByDescending(e => e.Porcentagem).ToList();

                return resultado;
            }
        }
    }
}
