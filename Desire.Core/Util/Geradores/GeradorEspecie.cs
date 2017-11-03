using System;
using System.Collections.Generic;
using System.Text;
using Desire.Core.Identidade;
using System.Linq;

namespace Desire.Core.Util.Geradores
{
    public class GeradorEspecie : IGerador<Especie>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorString rsg = new GeradorString();

        public Especie Gerar(Random rnd)
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
            GeradorBoolean genBool = new GeradorBoolean();
            CalculadorSer calculadorSer = new CalculadorSer();
            CalculadorNumero calculadorNum = new CalculadorNumero();
            

            Especie especie = new Especie()
            {
                ReinoTaxo = rsg.GerarTamanhoEspecifico(2, 8, rnd),
                FiloTaxo = rsg.GerarTamanhoEspecifico(2, 9, rnd),
                ClasseTaxo = rsg.GerarTamanhoEspecifico(2, 8, rnd),
                OrdemTaxo = rsg.GerarTamanhoEspecifico(2, 8, rnd),
                FamiliaTaxo = rsg.GerarTamanhoEspecifico(2, 8, rnd),
                GeneroTaxo = rsg.GerarTamanhoEspecifico(2, 8, rnd),
                NomeCientifico = rsg.GerarTamanhoEspecifico(2, 8, rnd),
                NomePopular = rsg.GerarTamanhoEspecifico(2, 8, rnd),
                OrigemEspecie = genOrigem.Gerar(rnd),
                MagnitudeMin = rng.GerarEntre(0, 5, rnd),
                MagnitudeMax = rng.GerarEntre(0, 5, rnd),
                ReiMin = rng.GerarEntre(0, 3, rnd),
                ReiMax = rng.GerarEntre(1, 10, rnd),
                KiMin = rng.GerarEntre(0, 50, rnd),
                KiMax = rng.GerarEntre(1, 1000, rnd),
                NivelMin = rng.GerarEntre(0, 10000, rnd),
                NivelMax = rng.GerarEntre(1, 100000, rnd),
                TempoMax = rng.GerarEntre(1, 10000, rnd),
                Energias = genEnergia.GerarLista(rng.GerarEntre(1, 5, rnd), rnd),
                ForcaMin = genForca.Gerar(rnd),
                ForcaMax = genForca.Gerar(rnd),
                MateriaMin = genMateria.Gerar(rnd),
                MateriaMax = genMateria.Gerar(rnd),
                DestrezaMin = genDestreza.Gerar(rnd),
                DestrezaMax = genDestreza.Gerar(rnd),
                IntelectoMin = genIntelecto.Gerar(rnd),
                IntelectoMax = genIntelecto.Gerar(rnd),
                CriatividadeMin = genCriatividade.Gerar(rnd),
                CriatividadeMax = genCriatividade.Gerar(rnd),
                ExistenciaMin = genExistencia.Gerar(rnd),
                ExistenciaMax = genExistencia.Gerar(rnd),
                IdeiaMin = genIdeia.Gerar(rnd),
                IdeiaMax = genIdeia.Gerar(rnd),
                PericiasEspecie = genPericia.GerarLista(rng.GerarEntre(1,10, rnd), rnd),
                HabilidadesEspecie = genHabilidade.GerarLista(rng.GerarEntre(1, 3, rnd), rnd),
                OrigemPoder = rsg.GerarTamanhoEspecifico(4, 10, rnd),
                VirtudesEspecie = genModificador.GerarListaComOrigem("Virtudes", 0, rng.GerarEntre(1, 10, rnd), rnd, '+'),
                DefeitosEspecie = genModificador.GerarListaComOrigem("Defeitos", 0, rng.GerarEntre(1, 10, rnd), rnd, '-'),
                ForcaVontadeMin = genValorMag.GerarEntre(new ValorMag(1,0), new ValorMag(99,15), rnd),
                ForcaVontadeMax = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15), rnd),
                IraMin = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15), rnd),
                IraMax = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15), rnd),
                PoderMaximoMin = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15), rnd),
                PoderMaximoMax = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15), rnd),
                FatorProgressao = rng.GerarEntre(1, 10, rnd),
                CansacoMax = rng.GerarEntre(0, 1000, rnd),
                FeMin = rng.GerarEntre(0, 1000, rnd),
                FeMax = rng.GerarEntre(0, 1000, rnd),
                KarmaMin = rng.GerarEntre(0, 1000, rnd),
                KarmaMax = rng.GerarEntre(0, 1000, rnd),
                MaxItensEquipados = rng.GerarEntre(1, 10, rnd),
                AcaoMin = rng.GerarEntre(1, 1000, rnd),
                AcaoMax = rng.GerarEntre(0, 1000, rnd),
                AlturaMin = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 5), rnd),
                AlturaMax = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 5), rnd),
                Id = rng.GerarEntre(1, 1000, rnd),
                MaxArmasEquipadas = rng.GerarEntre(1, 10, rnd),
                //TODO: Subclassificacoes = GeraSubclassificacoes(),
                TurnoMin = rng.GerarEntre(1, 1000, rnd),
                TurnoMax = rng.GerarEntre(1, 1000, rnd),
                MaturidadeMin = 0,
                MaturidadeMax = 0,
                DestriaMax = rng.GerarEntre(1, 10, rnd),
                DestriaMin = 1,
                Porcentagem = 0,
                TrabalhoMin = rng.GerarEntre(0, 1000, rnd),
                Densidade = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15), rnd),
                LarguraMin = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 5), rnd),
                LarguraMax = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 5), rnd),
                Especial = rng.GerarEntre(1, 70, rnd),
                Natureza = genNatureza.Gerar(rnd),
                RespostaMin = genResposta.Gerar(rnd),
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
            especie.MaturidadeMin = (int)calculadorNum.CalculaPorcentagem(rng.GerarEntre(1, 30, rnd), especie.TempoMax);
            especie.MaturidadeMax = especie.MaturidadeMin + (int)calculadorNum.CalculaPorcentagem(rng.GerarEntre(60, 99, rnd), especie.TempoMax);
            especie.TrabalhoMax = especie.TrabalhoMin + rng.GerarEntre(0, 1000, rnd);
            especie.LarguraMax = calculadorNum.SomaValorMag(especie.LarguraMin, especie.LarguraMax);

            especie.DeslocamentosMedios = new List<Deslocamento>()
            { 
            };

            if (genBool.GeraComChance(90, rnd))
            {
                especie.DeslocamentosMedios.Add(new Deslocamento()
                {
                    Tipo = "Solo",
                    Valor = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15), rnd)
                });
            }

            if (genBool.GeraComChance(70, rnd))
            {
                especie.DeslocamentosMedios.Add(new Deslocamento()
                {
                    Tipo = "Mar",
                    Valor = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15), rnd)
                });
            }

            if (genBool.GeraComChance(40, rnd))
            {
                especie.DeslocamentosMedios.Add(new Deslocamento()
                {
                    Tipo = "Ar",
                    Valor = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15), rnd)
                });
            }

            if (genBool.GeraComChance(10, rnd))
            {
                Deslocamento desMar = new Deslocamento()
                {
                    Tipo = "Espaço",
                    Valor = genValorMag.GerarEntre(new ValorMag(1, 0), new ValorMag(99, 15), rnd)
                };
            }

            especie.RespostaMax = new Resposta()
            {
                Bravura = especie.RespostaMin.Bravura + rng.GerarEntre(1, 1000, rnd),
                Coragem = especie.RespostaMin.Coragem + rng.GerarEntre(1, 1000, rnd),
                Desespero = especie.RespostaMin.Desespero + rng.GerarEntre(1, 1000, rnd),
                Heroismo = especie.RespostaMin.Heroismo + rng.GerarEntre(1, 1000, rnd),
                Indiferenca = especie.RespostaMin.Indiferenca + rng.GerarEntre(1, 1000, rnd),
                Medo = especie.RespostaMin.Medo + rng.GerarEntre(1, 1000, rnd),
                Panico = especie.RespostaMin.Panico + rng.GerarEntre(1, 1000, rnd)
            };
            return especie;
        }

        public List<Especie> GerarLista(int quantidade, Random rnd)
        {
            {
                List<Especie> resultado = new List<Especie>();
                if (quantidade == 0)
                    quantidade = rng.GerarEntre(1, 5, rnd);

                int[] porcentagens = rng.GerarInteirosQueSomam(quantidade, 100, rnd);

                for (int i = 0; i < quantidade; i++)
                {
                    Especie especie = Gerar(rnd);
                    especie.Porcentagem = porcentagens[i];
                    resultado.Add(especie);
                }

                resultado = resultado.OrderByDescending(e => e.Porcentagem).ToList();

                return resultado;
            }
        }
    }
}
