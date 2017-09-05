using System;
using System.Collections.Generic;
using System.Text;

namespace Desire.Core.Util.Geradores
{
    class GeradorSer : IGerador<Ser>
    {
        public Ser Gerar()
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
            CalculadorSer calculador = new CalculadorSer();

            string primeiroNome = genString.GerarTamanhoEspecifico(2, 6);
            string segundoNome = genString.GerarTamanhoEspecifico(0, 9);

            Ser ser = new Ser()
            {
                Origem = genOrigem.Gerar(),
                Tempo = rng.GerarEntre(1, 1000),
                Especies = genEspecie.GerarLista(rng.GerarEntre(1, 3)),
                Classes = genClasse.GerarLista(rng.GerarEntre(1, 3)),
                Indole = genIndole.Gerar(),
                Reis = genRei.GerarLista(rng.GerarEntre(0, 5)),
                Ki = rng.GerarEntre(0, 1000),
                Nivel = rng.GerarEntre(0, 100000),
                //Atributos
                Forca = genForca.Gerar(),
                Materia = genMateria.Gerar(),
                Destreza = genDestreza.Gerar(),
                Intelecto = genIntelecto.Gerar(),
                Criatividade = genCriatividade.Gerar(),
                Existencia = genExistencia.Gerar(),
                Ideia = genIdeia.Gerar(),
                //Perícias
                Pericias = genPericia.GerarLista(rng.GerarEntre(1, 20)),
                //Itens e Equips
                Posses = genItem.GerarLista(rng.GerarEntre(1, 20)),
                //Origem do Poder
                OrigemPoder = genString.GerarTamanhoEspecifico(2, 20),
                //Virtudes
                Virtudes = genModificador.GerarListaComOrigem("Virtudes", 3, '+'),
                //Defeitos
                Defeitos = genModificador.GerarListaComOrigem("Defeitos", 6, '-'),
                //Resistências
                Resistencias = genResistencia.GerarLista(rng.GerarEntre(0, 10)),
                //Gênese
                Genese = rng.GerarEntre(1, 5),
                //Geração
                Geracao = rng.GerarEntre(1, 10),
                //Trajetória
                Trajetoria = "Trajetória Gerada Aleatóriamente",
                //Elo Divino
                EloDivino = "Elo Divino Gerado Aleatóriamente",
                //Idumentária
                Idumentaria = "Idumentária gerada aleatoriamente",
                //Subatributo Subatributos Extra
                SubatributoExtraNome1 = genString.GerarTamanhoEspecifico(3, 10),
                SubatributoExtraValor1 = genValorMag.Gerar(),
                SubatributoExtraNome2 = genString.GerarTamanhoEspecifico(3, 10),
                SubatributoExtraValor2 = genValorMag.Gerar()
            };
            //Itens Equipados
            ser.Equipamentos = genEquipamento.GerarLista(ser.Especies[0].MaxItensEquipados);

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

        public List<Ser> GerarLista(int quantidade)
        {
            List<Ser> resultado = new List<Ser>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}
