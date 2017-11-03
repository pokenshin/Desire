using System;
using System.Collections.Generic;
using System.Text;

namespace Desire.Core.Util.Geradores
{
    public class GeradorSer : IGerador<Ser>
    {
        public Ser Gerar(Random rnd)
        {
            //TODO: Pegar valores aleatórios do banco de dados ao invés de gera-los aleatoriamente
            //TODO: Restringir o tempo baseado nas restrições de tempo da espécie selecionada
            GeradorString genString = new GeradorString();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorInteiro rng = new GeradorInteiro();
            GeradorCriatividade genCriatividade = new GeradorCriatividade();
            GeradorDestreza genDestreza = new GeradorDestreza();
            GeradorExistencia genExistencia = new GeradorExistencia();
            GeradorForca genForca = new GeradorForca();
            GeradorIdeia genIdeia = new GeradorIdeia();
            GeradorIntelecto genIntelecto = new GeradorIntelecto();
            GeradorMateria genMateria = new GeradorMateria();
            GeradorOrigem genOrigem = new GeradorOrigem();
            GeradorEspecie genEspecie = new GeradorEspecie();
            GeradorClasse genClasse = new GeradorClasse();
            GeradorIndole genIndole = new GeradorIndole();
            GeradorRei genRei = new GeradorRei();
            GeradorPericia genPericia = new GeradorPericia();
            GeradorItem genItem = new GeradorItem();
            GeradorModificador genModificador = new GeradorModificador();
            GeradorResistencia genResistencia = new GeradorResistencia();
            GeradorEquipamento genEquipamento = new GeradorEquipamento();
            GeradorHabilidade genHabilidade = new GeradorHabilidade();
            GeradorEvolucao genEvolucao = new GeradorEvolucao();
            CalculadorSer calculador = new CalculadorSer();


            string primeiroNome = genString.GerarTamanhoEspecifico(2, 6, rnd);
            string segundoNome = genString.GerarTamanhoEspecifico(0, 9, rnd);

            Ser ser = new Ser()
            {
                Origem = genOrigem.Gerar(rnd),
                Tempo = rng.GerarEntre(1, 1000, rnd),
                Especies = genEspecie.GerarLista(rng.GerarEntre(1, 3, rnd), rnd),
                Classes = genClasse.GerarLista(rng.GerarEntre(1, 3, rnd), rnd),
                Indole = genIndole.Gerar(rnd),
                Reis = genRei.GerarLista(rng.GerarEntre(0, 5, rnd), rnd),
                Ki = rng.GerarEntre(0, 1000, rnd),
                Nivel = rng.GerarEntre(0, 1000, rnd),
                //Atributos
                Forca = genForca.Gerar(rnd),
                Materia = genMateria.Gerar(rnd),
                Destreza = genDestreza.Gerar(rnd),
                Intelecto = genIntelecto.Gerar(rnd),
                Criatividade = genCriatividade.Gerar(rnd),
                Existencia = genExistencia.Gerar(rnd),
                Ideia = genIdeia.Gerar(rnd),
                //Evolução
                EvolucaoCriatividade = genEvolucao.Gerar(rnd),
                EvolucaoDestreza = genEvolucao.Gerar(rnd),
                EvolucaoExistencia = genEvolucao.Gerar(rnd),
                EvolucaoForca = genEvolucao.Gerar(rnd),
                EvolucaoIdeia = genEvolucao.Gerar(rnd),
                EvolucaoIntelecto = genEvolucao.Gerar(rnd),
                EvolucaoMateria = genEvolucao.Gerar(rnd),
                //Perícias
                Pericias = genPericia.GerarLista(rng.GerarEntre(1, 20, rnd), rnd),
                //Itens e Equips
                Posses = genItem.GerarLista(rng.GerarEntre(1, 20, rnd), rnd),
                //Virtudes
                Virtudes = genModificador.GerarListaComOrigem("Virtudes", 3, rng.GerarEntre(1, 5, rnd), rnd, '+'),
                //Defeitos
                Defeitos = genModificador.GerarListaComOrigem("Defeitos", 6, rng.GerarEntre(1, 5, rnd), rnd, '-'),
                //Resistências
                Resistencias = genResistencia.GerarLista(rng.GerarEntre(0, 10, rnd), rnd),
                //Gênese
                Genese = rng.GerarEntre(1, 5, rnd),
                //Geração
                Geracao = rng.GerarEntre(1, 10, rnd),
                //Trajetória
                Trajetoria = "Trajetória Gerada Aleatóriamente",
                //Elo Divino
                EloDivino = "Elo Divino Gerado Aleatóriamente",
                //Idumentária
                Idumentaria = "Idumentária gerada aleatoriamente",
                //Subatributo Subatributos Extra
                SubatributoExtraNome1 = genString.GerarTamanhoEspecifico(3, 10, rnd),
                SubatributoExtraValor1 = genValorMag.Gerar(rnd),
                SubatributoExtraNome2 = genString.GerarTamanhoEspecifico(3, 10, rnd),
                SubatributoExtraValor2 = genValorMag.Gerar(rnd),
                //Habilidades
                Habilidades = genHabilidade.GerarLista(rng.GerarEntre(2, 10, rnd), rnd)
            };
            //Itens Equipados
            ser.Equipamentos = genEquipamento.GerarLista(ser.Especies[0].MaxItensEquipados, rnd);

            //Geradores
            //Identidade
            if (segundoNome.Length == 0)
                ser.Nome = primeiroNome;
            else
                ser.Nome = primeiroNome + " " + segundoNome;

            //Calcula outros valores
            ser = calculador.CalculaSer(ser);

            return ser;
        }

        public List<Ser> GerarLista(int quantidade, Random rnd)
        {
            List<Ser> resultado = new List<Ser>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}
