using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desire.Core;
using System.Reflection;
using Desire.Core.Itens;
using Desire.Core.Calculos;


namespace Desire.Core.Geradores
{
    public class Gerador
    {
        Random rnd = new Random();
        string consoantes = "bcdfghjklmnpqrstvwxyz";
        string vogais = "aeiou";
        string[] tiposAtributo = new string[] { "Força", "Materia", "Destreza", "Intelecto", "Criatividade", "Idéia", "Existência" };
        string[] tiposItem = new string[] { "ArmaBranca", "ArmaDeFogo", "Equipamento", "Material", "Item" };
        string[] tiposCor = new string[] { "Branco", "Preto", "Vermelho", "Verde", "Azul", "Amarelo", "Violeta", "Rosa", "Cinza", "Laranja", "Marrom" };
        string[] tiposHabilidade = new string[] { "Melhora", "Piora", "Danifica", "Cura" };
        char[] tiposModificadores = new char[] { '+', '*', '-', '/' };

        public List<Ser> GeraSeresAleatorios(int quantidade)
        {
            List<Ser> lista = new List<Ser>();

            //Cria uns 3 seres aleatorios e coloca aqui

            return lista;
        }

        public Ser GeraSerAleatorio()
        {
            //TODO: Pegar valores aleatórios do banco de dados ao invés de gera-los aleatoriamente
            //TODO: Restringir o tempo baseado nas restrições de tempo da espécie selecionada
            Valor calculoValores = new Valor();
            string primeiroNome = GeraNomeAleatorio(2, 6);
            string segundoNome = GeraNomeAleatorio(0, 9);

            Ser ser = new Ser()
            {
                Origem = GeraOrigem(),
                Tempo = GeraInteiro(1, 1000),
                Especies = GeraListaEspecies(),
                Classes = GeraListaClasses(),
                Indole = GeraIndole(),
                Magnitude = GeraInteiro(0, 100),
                Reis = GeraListaReis(),
                Ki = GeraInteiro(0, 1000),
                Nivel = GeraInteiro(0, 100000),
                //Atributos
                Forca = (Forca)GeraAtributo("Força"),
                Materia = (Materia)GeraAtributo("Materia"),
                Destreza = (Destreza)GeraAtributo("Destreza"),
                Intelecto = (Intelecto)GeraAtributo("Intelecto"),
                Criatividade = (Criatividade)GeraAtributo("Criatividade"),
                Existencia = (Existencia)GeraAtributo("Existência"),
                Ideia = (Ideia)GeraAtributo("Idéia"),
                //Itens e Equips
                ItensGuardados = GeraListaItens(GeraInteiro(10, 30)),
                
        };
            //Carisma e Destino
            ser.Carisma = ser.Indole.Carisma;
            ser.Destino = ser.Indole.Destino;
            //Especial
            ser.Especial = calculoValores.CalculaEspecial(ser);

            //Deslocamentos
            ser.Deslocamentos = calculoValores.CriaListaDeslocamentosSer(ser);

            //Itens Equipados
            ser.ItensEquipados = GeraListaEquipamentos(ser.Especies[0].MaxItensEquipados, ser.Especies[0].MaxArmasEquipadas);
            //Pericias
            ser.Pericias = calculoValores.CriaListaPericiasSer(ser);
            ser.Pericias.Concat(GeraListaPericias(5));
            
            //Energias
            ser.Energias = calculoValores.CriaListaEnergiasSer(ser);

            //Geradores
            //Identidade
            if (segundoNome.Length == 0)
                ser.Nome = primeiroNome;
            else
                ser.Nome = primeiroNome + " " + segundoNome;

            //Calculos dos outros atributos

            //Subatributos
            ser = calculoValores.CalculaSubatributos(ser);

            //Energias
            //Especial
            //Defeitos
            //Dons
            //Habilidades
            //


            //TODO: Aplicar modificadores
            return ser;
        }

        public ValorMag GeraValorMag(ValorMag valorMag1, ValorMag valorMag2)
        {
            int valor = 1;
            int mag = GeraInteiro(valorMag1.Magnitude, valorMag2.Magnitude);

            if (mag == valorMag1.Magnitude)
            {
                if (mag == valorMag2.Magnitude)
                    valor = GeraInteiro(valorMag1.Valor, valorMag2.Valor);
                else
                    valor = GeraInteiro(valorMag1.Valor, 99);
            }
            else if (mag == valorMag2.Magnitude)
                valor = GeraInteiro(10, valorMag2.Valor);
            else
                valor = GeraInteiro(10, 99);


            ValorMag resultado = new ValorMag(valor, mag);

            return resultado;
        }

        public long GeraLong(long min, long max)
        {
            byte[] buf = new byte[8];
            rnd.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }

        public List<Rei> GeraListaReis(int v = 0)
        {
            List<Rei> lista = new List<Rei>();

            if (v == 0)
                v = GeraInteiro(1, 5);

            for (int i = 0; i < v; i++)
            {
                Rei rei = new Rei();
                rei = GeraRei();
                lista.Add(rei);
            }

            return lista;
        }

        public Rei GeraRei(int magnitude = 0)
        {
            if (magnitude == 0)
                magnitude = GeraInteiro(1, 20);

            Rei rei = new Rei()
            {
                Nome = GeraNomeAleatorio(3, 8),
                Magnitude = magnitude,
                Origem = GeraNomeAleatorio(3, 8),
                Cor = GeraCor()
            };

            rei.Modificadores = GeraListaModificadores("Rei", rei.Id);

            return rei;
        }

        public string GeraCor()
        {
            return tiposCor[GeraInteiro(0, tiposCor.Length - 1)];
        }

        public List<Item> GeraListaItens(int v = 0)
        {
            List<Item> lista = new List<Item>();

            if (v == 0)
                v = GeraInteiro(1, 10);

            for (int i = 0; i < v; i++)
            {
                Item item = GeraItem();
                lista.Add(item);
            }
            return lista;
        }

        public List<Item> GeraListaEquipamentos(int maxEquips, int maxArmas)
        {
            List<Item> lista = new List<Item>();
            int quantidadeArmas = GeraInteiro(0, maxArmas);
            int quantidadeItens = GeraInteiro(0, maxEquips);

            for (int i = 0; i < quantidadeArmas; i++)
            {
                Item item = new Item();
                if (GeraBoolean(50))
                    item = GeraItem("ArmaBranca");
                else
                    item = GeraItem("ArmaDeFogo");
                lista.Add(item); 
            }

            for (int i = 0; i < quantidadeItens; i++)
            {
                Item item = GeraItem("Equipamento");
                lista.Add(item);
            }

            return lista;
        }

        public Item GeraItem(string v = "Random")
        {
            //TODO: Fazer itens seguirem regras dos materiais base
            //TODO: Fazer ser possivel a arma branca ter mais de um tipo de dano
            //TODO: Aumentar o valor da arma de acordo com modificadores, material, etc
            //TODO: Melhorar a aleatoriedade da escolha de tipos de operação de armas de fogo para que não repita
            if (v == "Random")
            {
                v = tiposItem[GeraInteiro(0, tiposItem.Length - 1)];
            }

            switch (v)
            {
                case "ArmaBranca":
                    int tipoDanoBranca = GeraInteiro(1, 4);
                    ArmaBranca armaBranca = new ArmaBranca()
                    {
                        Id = GeraInteiro(1,100),
                        AtributoBonus = tiposAtributo[GeraInteiro(0, tiposAtributo.Length - 1)],
                        Caracteristicas = "Arma Branca gerada aleatoriamente",
                        Comprimento = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1,10)),
                        Energia = GeraInteiro(0, 100000),
                        Equipavel = true,
                        Essencia = GeraInteiro(0, 1000000),
                        Raridade = GeraInteiro(1, 100),
                        Largura = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1,10)),
                        MaterialBase = GeraMaterial(),
                        MultiplicadorCritico = GeraInteiro(1, 10),
                        Nivel = GeraInteiro(1, 100000),
                        Nome = GeraNomeAleatorio(3, 8),
                        Peso = new ValorMag(GeraInteiro(0, 100), GeraInteiro(1,10)),
                        SlotsOcupados = GeraInteiro(0, 6),
                        Tipo = GeraInteiro(1, 100),
                    };
                    armaBranca.Modificadores = GeraListaModificadores("Arma", armaBranca.Id);
                    armaBranca.Valor = armaBranca.MaterialBase.ValorPorGrama + GeraInteiro(1, 1000000);
                    
                    if (tipoDanoBranca == 1)
                        armaBranca.DanoCorte = GeraInteiro(1, 100000);
                    else if (tipoDanoBranca == 2)
                        armaBranca.DanoImpacto = GeraInteiro(1, 100000);
                    else if (tipoDanoBranca == 3)
                        armaBranca.DanoPenetracao = GeraInteiro(1, 1000000);
                    if (GeraBoolean(10))
                        armaBranca.ModificadorDano = "por ki";

                    return armaBranca;

                case "ArmaDeFogo":
                    int tipoDanoFogo = GeraInteiro(1, 4);
                    string[] tiposOperacao = new string[] { "FullAuto", "Burst", "Single", "Pump", "Charge" };
                    int operacoes = 0;
                    ArmaDeFogo armaDeFogo = new ArmaDeFogo()
                    {
                        Id = GeraInteiro(1, 1000),
                        Caracteristicas = "Arma de Fogo gerada aleatoriamente",
                        Comprimento = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1,10)),
                        DistanciaMax = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1,10)),
                        DistanciaMin = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1,10)),
                        Equipavel = true,
                        Essencia = GeraInteiro(1, 100000),
                        Energia = GeraInteiro(0, 100000),
                        Largura = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1,10)),
                        MaterialBase = GeraMaterial(),
                        Nivel = GeraInteiro(1, 100),
                        Nome = GeraNomeAleatorio(3, 8),
                        Peso = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1,10)),
                        Raridade = GeraInteiro(1, 100),
                        SlotsOcupados = GeraInteiro(1, 10),
                        Tipo = GeraInteiro(1, 100),
                        TipoCarga = GeraMunicao(),
                        TirosPorCarga = GeraInteiro(1, 100000),
                        Valor = GeraInteiro(1, 100000),
                    };

                    armaDeFogo.Modificadores = GeraListaModificadores("Arma", armaDeFogo.Id);

                    operacoes = GeraInteiro(1, tiposOperacao.Length);
                    for (int i = 0; i < operacoes; i++)
                    {
                        armaDeFogo.Operacoes = new string[tiposOperacao.Length];
                        armaDeFogo.Operacoes[i] = tiposOperacao[GeraInteiro(0, tiposOperacao.Length - 1)];
                    }

                    if (tipoDanoFogo == 1)
                        armaDeFogo.DanoCorte = GeraInteiro(1, 100000);
                    else if (tipoDanoFogo == 2)
                        armaDeFogo.DanoImpacto = GeraInteiro(1, 100000);
                    else if (tipoDanoFogo == 3)
                        armaDeFogo.DanoPenetracao = GeraInteiro(1, 1000000);
                    if (GeraBoolean(10))
                        armaDeFogo.ModificadorDano = "por ki";

                    armaDeFogo.TirosPorAcao = armaDeFogo.TirosPorCarga - GeraInteiro(1, 100000);

                    return armaDeFogo;

                case "Equipamento":
                    Equipamento equipamento = new Equipamento()
                    {
                        Id = GeraInteiro(1,100),
                        Caracteristicas = "Equipamento gerado aleatoriamente",
                        Comprimento = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                        Equipavel = true,
                        Essencia = GeraInteiro(1, 100000),
                        Energia = GeraInteiro(0, 100000),
                        Largura = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 20)),
                        MaterialBase = GeraMaterial(),
                        Nivel = GeraInteiro(1, 100),
                        Nome = GeraNomeAleatorio(3, 8),
                        Peso = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 20)),
                        Raridade = GeraInteiro(1, 100),
                        SlotsOcupados = GeraInteiro(1, 10),
                        Tipo = GeraInteiro(1, 100),
                        Valor = GeraInteiro(1, 100000),
                        ResCorte = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1,20)),
                        ResDegeneracao = new ValorMag(GeraInteiro(1,100), GeraInteiro(1,20)),
                        ResImpacto = new ValorMag(GeraInteiro(1,100), GeraInteiro(1,20)),
                        ResPenetracao = new ValorMag(GeraInteiro(1,100), GeraInteiro(1,20))
                    };
                    equipamento.Modificadores = GeraListaModificadores("Equipamento", equipamento.Id);
                    return equipamento;

                case "Material":
                    Item material = new Item()
                    {
                        Comprimento = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                        Equipavel = true,
                        Essencia = GeraInteiro(1, 100000),
                        Energia = GeraInteiro(0, 100000),
                        Largura = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 20)),
                        MaterialBase = GeraMaterial(),
                        Nivel = GeraInteiro(1, 100),
                        Nome = GeraNomeAleatorio(3, 8),
                        Peso = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1,10)),
                        Raridade = GeraInteiro(1, 100),
                        Tipo = GeraInteiro(1, 100),
                        Valor = GeraInteiro(1, 100000)
                    };

                    material.Caracteristicas = "Objeto de " + material.MaterialBase.Nome;

                    return material;

                case "Item":
                    Item item = new Item()
                    {
                        Id = GeraInteiro(1, 1000),
                        Comprimento = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                        Equipavel = true,
                        Essencia = GeraInteiro(1, 100000),
                        Energia = GeraInteiro(0, 100000),
                        Largura = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1,10)),
                        MaterialBase = GeraMaterial(),
                        Nivel = GeraInteiro(1, 100),
                        Nome = GeraNomeAleatorio(3, 8),
                        Peso = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                        Raridade = GeraInteiro(1, 100),
                        Tipo = GeraInteiro(1, 100),
                        Valor = GeraInteiro(1, 100000),
                        Caracteristicas = "Item estranho.",
                    };
                    item.Modificadores = GeraListaModificadores("Item", item.Id);
                    return item;

                default:
                    Item itemVazio = new Item();
                    return itemVazio;
            }
        }

        public Municao GeraMunicao()
        {
            Municao municao = new Municao()
            {
                Id = GeraInteiro(1, 1000),
                Caracteristicas = "Munição gerada aleatoriamente",
                Comprimento = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                Energia = GeraInteiro(0, 100000),
                Equipavel = true,
                Essencia = GeraInteiro(0, 1000000),
                Raridade = GeraInteiro(1, 100),
                Largura = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                MaterialBase = GeraMaterial(),
                Nivel = GeraInteiro(1, 100000),
                Nome = GeraNomeAleatorio(3, 8),
                Peso = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                Tipo = GeraInteiro(1, 100),
                DanoBonus = GeraInteiro(0, 10000),
                PenetracaoBonus = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                ImpactoBonus = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                CorteBonus = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
            };
            municao.Modificadores = GeraListaModificadores("Municao", municao.Id);

            return municao;
            
        }

        public Material GeraMaterial()
        {
            Material material = new Material()
            {
                Dureza = GeraInteiro(0, 100),
                DurezaMag = GeraInteiro(1, 20),
                Nome = GeraNomeAleatorio(3, 10),
                Resistencia = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                DensidadePorGrama = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                Raridade = GeraInteiro(1, 10000),
                ValorPorGrama = GeraInteiro(1, 10000)
            };
            return material;
        }

        public Indole GeraIndole()
        {
            Indole indole = new Indole()
            {
                Nome = GeraNomeAleatorio(3, 10),
                Carisma = GeraCarisma(),
                Destino = GeraDestino()
            };
            return indole;
        }

        public Carisma GeraCarisma()
        {
            Carisma carisma = new Carisma()
            {
                Negativo = GeraInteiro(0, 100),
                Neutro = GeraInteiro(0, 100),
                Positivo = GeraInteiro(0, 100)
            };
            return carisma;
        }

        public Destino GeraDestino()
        {
            Destino destino = new Destino()
            {
                Acaso = GeraInteiro(0, 100),
                Azar = GeraInteiro(0, 100),
                Desgraca = GeraInteiro(0, 100),
                Milagre = GeraInteiro(0, 100),
                Sorte = GeraInteiro(0, 100)
            };
            return destino;
        }

        public List<Classe> GeraListaClasses()
        {
            //TODO: Pegar classe do banco de dados.
            List<Classe> resultado = new List<Classe>();

            for (int i = 0; i < GeraInteiro(1, 4); i++)
            {
                Classe classe = GeraClasse();
                resultado.Add(classe);
            }

            return resultado;
        }

        public Classe GeraClasse()
        {
            string[] atributosEspirituais = new string[] { "Idéia", "Existência" };
            string[] atributosFisicos = new string[] { "Força", "Destreza", "Matéria" };
            string[] atributosMentais = new string[] { "Intelecto", "Criatividade" };
            string[] estilos = new string[] { "Melee", "Ranged", "Caster", "Liderança" };
            string[] funcoes = new string[] { "Dano", "Cura", "Suporte", "Controle", "Crafting" };
            Classe classe = new Classe()
            {
                AtributoEspiritual = atributosEspirituais[GeraInteiro(0, atributosEspirituais.Length - 1)],
                AtributoFisico = atributosFisicos[GeraInteiro(0, atributosFisicos.Length - 1)],
                AtributoMental = atributosMentais[GeraInteiro(0, atributosMentais.Length - 1)],
                Descricao = "Lorem Ipsum",
                Estilo = estilos[GeraInteiro(0, estilos.Length - 1)],
                Funcao = funcoes[GeraInteiro(0, funcoes.Length - 1)],
                Nome = GeraNomeAleatorio(4, 8),
                OrigemPoder = GeraNomeAleatorio(4, 8),
                PericiaPrincipal = GeraPericia(),
                PericiasSecundarias = GeraListaPericias()
            };
            return classe;
        }

        public List<Especie> GeraListaEspecies(int numero = 0)
        {
            List<Especie> resultado = new List<Especie>();
            if (numero == 0)
                numero = GeraInteiro(1, 5);

            int[] porcentagens = GeraInteirosQueSomam(numero, 100);

            for (int i = 0; i < numero; i++)
            {
                Especie especie = GeraEspecie();
                especie.Porcentagem = porcentagens[i];
                resultado.Add(especie);
            }

            resultado = resultado.OrderByDescending(e => e.Porcentagem).ToList();

            return resultado;
        }

        public int[] GeraInteirosQueSomam(int quantidadeNumeros, int somaTotal)
        {
            int[] resultado = new int[quantidadeNumeros];
            double soma = 0;
            int novaSoma = 0;
            int diferenca = 0;

            for (int i = 0; i < quantidadeNumeros; i++)
            {
                resultado[i] = GeraInteiro(1, 100);
                if (i > 0)
                    soma = soma + resultado[i];
                else
                    soma = resultado[i];
            }

            double k = soma / somaTotal;

            for (int i = 0; i < quantidadeNumeros; i++)
            {
                double numeroNovo = (double)resultado[i] / k;
                novaSoma = novaSoma + Convert.ToInt32(numeroNovo);
                resultado[i] = Convert.ToInt32(numeroNovo);
            }

            if (novaSoma != somaTotal)
            {
                if (novaSoma > somaTotal)
                {
                    diferenca = Convert.ToInt32(novaSoma - somaTotal);
                    resultado[resultado.Length - 1] = resultado[resultado.Length - 1] - diferenca;
                }
                else
                {
                    diferenca = Convert.ToInt32(somaTotal - novaSoma);
                    resultado[resultado.Length - 1] = resultado[resultado.Length - 1] + diferenca;
                }
            }




            return resultado;
        }

        public Especie GeraEspecie()
        {
            Valor valor = new Valor();
            Especie especie = new Especie()
            {
                ReinoTaxo = GeraNomeAleatorio(2, 8),
                FiloTaxo = GeraNomeAleatorio(2, 9),
                ClasseTaxo = GeraNomeAleatorio(2, 8),
                OrdemTaxo = GeraNomeAleatorio(2, 8),
                FamiliaTaxo = GeraNomeAleatorio(2, 8),
                GeneroTaxo = GeraNomeAleatorio(2, 8),
                NomeCientifico = GeraNomeAleatorio(2, 8),
                NomePopular = GeraNomeAleatorio(2, 8),
                OrigemEspecie = GeraOrigem(),
                MagnitudeMin = GeraInteiro(0, 1000),
                MagnitudeMax = GeraInteiro(1, 1000),
                ReiMin = GeraInteiro(0, 50),
                ReiMax = GeraInteiro(1, 50),
                KiMin = GeraInteiro(0, 1000),
                KiMax = GeraInteiro(1, 1000),
                NivelMin = GeraInteiro(0, 10000),
                TempoMax = GeraInteiro(1, 10000),
                Energias = GeraListaEnergias(),
                ForcaMin = (Forca)GeraAtributo("Força"),
                ForcaMax = (Forca)GeraAtributo("Força"),
                MateriaMin = (Materia)GeraAtributo("Materia"),
                MateriaMax = (Materia)GeraAtributo("Materia"),
                DestrezaMin = (Destreza)GeraAtributo("Destreza"),
                DestrezaMax = (Destreza)GeraAtributo("Destreza"),
                NivelMax = GeraInteiro(1, 100000),
                IntelectoMin = (Intelecto)GeraAtributo("Intelecto"),
                IntelectoMax = (Intelecto)GeraAtributo("Intelecto"),
                CriatividadeMin = (Criatividade)GeraAtributo("Criatividade"),
                CriatividadeMax = (Criatividade)GeraAtributo("Criatividade"),
                ExistenciaMin = (Existencia)GeraAtributo("Existência"),
                ExistenciaMax = (Existencia)GeraAtributo("Existência"),
                IdeiaMin = (Ideia)GeraAtributo("Ideia"),
                IdeiaMax = (Ideia)GeraAtributo("Ideia"),
                PericiasEspecie = GeraListaPericias(),
                HabilidadesEspecie = GeraListaHabilidades(1, 3),
                OrigemPoder = GeraNomeAleatorio(4, 10),
                VirtudesEspecie = new List<Modificador>(),
                DonsEspecie = new List<Modificador>(),
                VantagensEspecie = new List<Modificador>(),
                DefeitosEspecie = new List<Modificador>(),
                ForcaVontadeMin = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 4)),
                ForcaVontadeMax = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 4)),
                IraMin = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 4)),
                IraMax = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 4)),
                PoderMaximoMin = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                PoderMaximoMax = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                FatorProgressao = GeraInteiro(1, 10),
                CansacoMax = GeraInteiro(0, 1000),
                FeMin = GeraInteiro(0, 1000),
                FeMax = GeraInteiro(0, 1000),
                KarmaMin = GeraInteiro(0, 1000),
                KarmaMax = GeraInteiro(0, 1000),
                MaxItensEquipados = GeraInteiro(1, 10),
                AcaoMin = GeraInteiro(1, 1000),
                AcaoMax = GeraInteiro(0, 1000),
                AlturaMin = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                AlturaMax = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 10)),
                Id = GeraInteiro(1, 1000),
                MaxArmasEquipadas = GeraInteiro(1, 10),
                //TODO: Subclassificacoes = GeraSubclassificacoes(),
                TurnoMin = GeraInteiro(1, 1000),
                TurnoMax = GeraInteiro(1, 1000),
                MaturidadeMin = 0,
                MaturidadeMax = 0,
                DestriaMax = GeraInteiro(1, 10),
                DestriaMin = 1,
                Porcentagem = 0,
                TrabalhoMin = GeraLong(0, 1000),
                Densidade = new ValorMag(Convert.ToString(GeraLong(1, 10))),
                LarguraMin = new ValorMag(Convert.ToString(GeraLong(1, 100))),
                LarguraMax = new ValorMag()
            };
            especie.MagnitudeMax = especie.MagnitudeMin + especie.MagnitudeMax;
            especie.ReiMax = especie.ReiMin + especie.ReiMax;
            especie.KiMax = especie.KiMin + especie.KiMax;
            especie.VirtudesEspecie = GeraListaModificadores("VirtudesEspecie", especie.Id, '+');
            especie.DonsEspecie = GeraListaModificadores("Especie", especie.Id, '+');
            especie.VantagensEspecie = GeraListaModificadores("Especie", especie.Id, '+');
            especie.DefeitosEspecie = GeraListaModificadores("Especie", especie.Id, '-');
            especie.ForcaVontadeMax = valor.SomaValorMag(especie.ForcaVontadeMin, especie.ForcaVontadeMax);
            especie.IraMax = valor.SomaValorMag(especie.IraMin, especie.IraMin);
            especie.PoderMaximoMax = valor.SomaValorMag(especie.PoderMaximoMin, especie.PoderMaximoMax);
            especie.FeMax = especie.FeMin + especie.FeMax;
            especie.KarmaMax = especie.KarmaMin + especie.KarmaMax;
            especie.AcaoMax = especie.AcaoMin + especie.AcaoMax;
            especie.AlturaMax = valor.SomaValorMag(especie.AlturaMin, especie.AlturaMax);
            especie.TurnoMax = especie.TurnoMin + especie.TurnoMax;
            especie.MaturidadeMin = (int)valor.CalculaPorcentagem(GeraInteiro(1, 30), especie.TempoMax);
            especie.MaturidadeMax = especie.MaturidadeMin + (int)valor.CalculaPorcentagem(GeraInteiro(60, 99), especie.TempoMax);
            especie.TrabalhoMax = especie.TrabalhoMin + GeraLong(0, 1000);
            especie.LarguraMax = valor.SomaValorMag(especie.LarguraMin, new ValorMag(Convert.ToString(GeraLong(1, 100))));

            return especie;
        }

        public List<Habilidade> GeraListaHabilidades(int min, int max)
        {
            //TODO: Pegar lista a partir do banco de dados de Habilidades
            List<Habilidade> resultado = new List<Habilidade>();
            int numero = GeraInteiro(min, max);

            for (int i = 0; i < numero; i++)
            {
                Habilidade habilidade = GeraHabilidade();
                resultado.Add(habilidade);
            }

            return resultado;
        }

        public Habilidade GeraHabilidade()
        {
            //TODO: Pegar aleatoriamente do banco de dados de habilidades
            //TODO: Pegar Pericia Associada do banco de dados de pericias
            //TODO: Restringir o tipo da Habilidade por uma lista do banco de dados
            //TODO: Criar efeitos secundários. Ex: dano + buff, cura +  piora, etc
            
            string[] duracoes = new string[] { "Permanente", "Segundos", "Minutos", "Horas", "Dias", "Meses", "Anos", "Turnos" };
            int duracaoIndex = GeraInteiro(0, duracoes.Length - 1);
            int tipoIndex = GeraInteiro(0, tiposHabilidade.Length - 1);

            Habilidade habilidade = new Habilidade()
            {
                Id = GeraInteiro(1, 1000),
                Nivel = GeraInteiro(1, 10),
                Nome = GeraNomeAleatorio(2, 8),
                PericiaAssociada = GeraPericia(),
                Tipo = tiposHabilidade[tipoIndex],
                TipoEnergia = GeraEnergia(),
                ValorEnergia = GeraInteiro(1, 10000),
                ValorEfeito = GeraInteiro(1, 100000),
                Duracao = duracoes[duracaoIndex],
                ValorDuracao = GeraInteiro(1, 1000),
                Area = GeraAreaCientifica()
            };
            habilidade.Caracteristicas = habilidade.Tipo + " " + habilidade.ValorEfeito + " pontos";

            if (tipoIndex < 2)
            {
                if (tipoIndex  == 0)
                { 
                    if (GeraBoolean(50))
                        habilidade.Modificadores = GeraListaModificadores("Habilidade", habilidade.Id, '+');
                    else
                        habilidade.Modificadores = GeraListaModificadores("Habilidade", habilidade.Id, '*');
                }
                else
                {
                    if (GeraBoolean(50))
                        habilidade.Modificadores = GeraListaModificadores("Habilidade", habilidade.Id, '-');
                    else
                        habilidade.Modificadores = GeraListaModificadores("Habilidade", habilidade.Id, '/');
                }
            }

            if (duracaoIndex > 0)
            {
                habilidade.Caracteristicas = habilidade.Caracteristicas + " durante " + habilidade.ValorDuracao + " " + habilidade.Duracao;
            }

            return habilidade;
        }

        public Area GeraAreaCientifica()
        {
            Area resultado = new Area()
            {
                Nome = GeraNomeAleatorio(3, 8),
                Ciencia = GeraCiencia()
            };
            return resultado;
        }

        public Ciencia GeraCiencia()
        {
            //TODO: Pegar Ciencia do banco de dados
            Ciencia resultado = new Ciencia()
            {
                Nome = GeraNomeAleatorio(3, 8),
                Esfera = GeraEsferaCientifica()
            };
            return resultado;
        }

        public Esfera GeraEsferaCientifica()
        {
            //TODO: Pegar esfera do banco de dados de esferas
            Esfera resultado = new Esfera()
            {
                Nome = GeraNomeAleatorio(3, 8)
            };
            return resultado;
        }

        public List<Pericia> GeraListaPericias(int numero = 0)
        {
            //TODO: Pegar lista a partir do banco de dados de Pericias
            //TODO: Criar um limite lógico no nivel das pericias adquiridas
            //TODO: Fazer com que as pericias escolhidas sigam a regra de progressão das pericias

            List<Pericia> resultado = new List<Pericia>();
            if (numero == 0)
                numero = GeraInteiro(1, 10);

            for (int i = 0; i < numero; i++)
            {
                Pericia pericia = GeraPericia();
                resultado.Add(pericia);
            }

            return resultado;
        }

        public Pericia GeraPericia()
        {
            //TODO: Pegar perícia dos banco de dados de perícias

            Pericia pericia = new Pericia()
            {
                Nome = GeraNomeAleatorio(3, 8),
                Id = GeraInteiro(0, 1000),
            };

            pericia.Modificadores = GeraListaModificadores("Pericia", pericia.Id, '+');
            pericia.Descricao = "Perícia em " + pericia.Nome;

            foreach (Modificador mod in pericia.Modificadores)
            {
                pericia.Efeitos = mod.Nome + " " + pericia.Efeitos;
            }

            return pericia;
        }

        public List<Modificador> GeraListaModificadores(string origem, int origemId, char t = 'R')
        {
            //TODO: Criar magnitude dos modificadores para limitar sua apelação
            List<Modificador> resultado = new List<Modificador>();
            int numero = GeraInteiro(1, 5 );
            char v;

            for (int i = 0; i < numero; i++)
            {
                if (t == 'R')
                   v = tiposModificadores[GeraInteiro(0, tiposModificadores.Length - 1)];
                else
                    v = t;

                switch (v)
                {
                    case '+':
                        Modificador modPositivo = GeraModificadorInt(origem, origemId, '+');
                        resultado.Add(modPositivo);
                        break;
                    case '-':
                        Modificador modNegativo = GeraModificadorInt(origem, origemId, '-');
                        resultado.Add(modNegativo);
                        break;
                    case '*':
                        Modificador modMultiplicativo = GeraModificadorInt(origem, origemId, '*');
                        resultado.Add(modMultiplicativo);
                        break;
                    case '/':
                        Modificador modDivisivo = GeraModificadorInt(origem, origemId, '/');
                        resultado.Add(modDivisivo);
                        break;

                    default:
                        break;
                }
            }
            return resultado;
        }

        public Modificador GeraModificadorInt(string origem, int origemId, char tipo)
        {
            //TODO: Gerar modifiadores menos random e com mais sentido
            //TODO: Melhorar nome do modificador
            //TODO: Tratamento especial para modificadores de classe
            //TODO: Criar magnitude do modificador para limitar sua apelação e direcionar uso
            PropertyInfo[] propriedades = typeof(Ser).GetProperties().Where(p => p.PropertyType == typeof(int)).ToArray<PropertyInfo>();
            string nomePropriedade = propriedades[GeraInteiro(0, propriedades.Count() - 1)].Name;
            PropertyInfo alvo = typeof(Ser).GetProperty(nomePropriedade);
            int valor = GeraInteiro(1, 100);

            string @nome = nomePropriedade + @tipo + valor;

            Modificador modificador = new Modificador()
            {
                Nome = nome,
                Alvo = alvo,
                Valor = valor,
                Tipo = tipo,
                Origem = origem,
                OrigemId = origemId
            };
            return modificador;
        }

        public Atributo GeraAtributo(string v = "Random")
        {
            if (v == "Random")
                v = tiposAtributo[GeraInteiro(0, tiposAtributo.Length - 1)];

            switch (v)
            {
                case "Força":
                    Forca forca = new Forca()
                    {
                        Carga = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Classe = Convert.ToChar(GeraNomeAleatorio(1, 1)),
                        Dureza = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Golpe = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Nivel = GeraInteiro(1, 6),
                        Pontos = GeraInteiro(1, 100),
                        Porcentagem = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Potencia = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Vigor = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Evolucao = new Evolucao(GeraInteiro(1, 17), 16, GeraBoolean(50))
                    };
                    return forca;

                case "Destreza":
                    Destreza destreza = new Destreza()
                    {
                        Ataque = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Classe = Convert.ToChar(GeraNomeAleatorio(1, 1)),
                        Esquiva = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Iniciativa = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Nivel = GeraInteiro(1, 6),
                        Pontos = GeraInteiro(1, 100),
                        Porcentagem = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Prioridade = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Reflexo = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Evolucao = new Evolucao(GeraInteiro(1, 17), 16, GeraBoolean(50))
                    };
                    return destreza;

                case "Materia":
                    Materia materia = new Materia()
                    {
                        Classe = Convert.ToChar(GeraNomeAleatorio(1, 1)),
                        Colapso = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Imunidade = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Nivel = GeraInteiro(1, 6),
                        Pontos = GeraInteiro(1, 100),
                        Porcentagem = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Regeneracao = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Resistencia = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Vitalidade = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Evolucao = new Evolucao(GeraInteiro(1, 17), 16, GeraBoolean(50))
                    };
                    return materia;

                case "Intelecto":
                    Intelecto intelecto = new Intelecto()
                    {
                        Aprendizagem = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Classe = Convert.ToChar(GeraNomeAleatorio(1, 1)),
                        Concentracao = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Eidos = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Memoria = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Nivel = GeraInteiro(1, 6),
                        Pontos = GeraInteiro(1, 100),
                        Porcentagem = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Senso = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Evolucao = new Evolucao(GeraInteiro(1, 17), 16, GeraBoolean(50))
                    };
                    return intelecto;

                case "Criatividade":
                    Criatividade criatividade = new Criatividade()
                    {
                        Classe = Convert.ToChar(GeraNomeAleatorio(1, 1)),
                        Invencao = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Nivel = GeraInteiro(1, 6),
                        Pontos = GeraInteiro(1, 100),
                        Porcentagem = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Realidade = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Singularidade = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Tutor = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Visualizacao = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Evolucao = new Evolucao(GeraInteiro(1, 17), 16, GeraBoolean(50))
                    };
                    return criatividade;

                case "Existência":
                    Existencia existencia = new Existencia()
                    {
                        Ciencia = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Classe = Convert.ToChar(GeraNomeAleatorio(1, 1)),
                        Conhecimento = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Consciencia = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Experiencia = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Nivel = GeraInteiro(1, 6),
                        Plano = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Pontos = GeraInteiro(1, 100),
                        Porcentagem = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Evolucao = new Evolucao(GeraInteiro(1, 17), 16, GeraBoolean(50))
                    };
                    return existencia;

                case "Idéia":
                    Ideia ideia = new Ideia()
                    {
                        Base = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Classe = Convert.ToChar(GeraNomeAleatorio(1, 1)),
                        Irrealidade = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Ki = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Misterio = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Nexo = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15)),
                        Nivel = GeraInteiro(1, 6),
                        Pontos = GeraInteiro(1, 100),
                        Porcentagem = new ValorMag(GeraInteiro(1, 100), GeraInteiro(1, 15))
                        Evolucao = new Evolucao(GeraInteiro(1, 17), 16, GeraBoolean(50))
                    };
                    return ideia;

                default:
                    return null;
            }

        }

        public List<Energia> GeraListaEnergias()
        {
            //TODO: Pegar criar lista a partir de resultados aleatórios no Banco de Dados

            List<Energia> resultado = new List<Energia>();
            int numero = GeraInteiro(1, 8);

            for (int i = 0; i < numero; i++)
            {
                resultado.Add(GeraEnergia());
            }

            return resultado;
        }

        private Energia GeraEnergia()
        {
            //TODO: pegar uma energia a partir do banco de dados
            Energia energia = new Energia()
            {
                Sigla = GeraNomeAleatorio(1, 1) + GeraNomeAleatorio(1, 1),
                Quantidade = GeraInteiro(1, 1000000)
            };
            return energia;
        }

        public Origem GeraOrigem()
        {
            //TODO: pegar uma origem aleatoria do banco de dados.
            Realidade realidade = new Realidade(GeraNomeAleatorio(2, 8));
            Plano plano = new Plano(GeraNomeAleatorio(2, 8), realidade);
            Origem origem = new Origem(GeraNomeAleatorio(4, 10), plano);

            return origem;
        }

        public string GeraNomeAleatorio(int min, int max)
        {
            string nome = "";
            int tamanhoNome = rnd.Next(min, max);

            while (nome.Length < tamanhoNome)
            {
                if (nome.Length == 0)
                {
                    if (GeraBoolean(50))
                        nome = Convert.ToString(consoantes[rnd.Next(0, consoantes.Length)]).ToUpper();
                    else
                        nome = Convert.ToString(vogais[rnd.Next(0, vogais.Length)]).ToUpper();
                }
                else
                {
                    char ultimaLetra = nome[nome.Length-1]; //Pega última letra
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

                    if (GeraBoolean(chanceVogal))
                        nome = nome + Convert.ToString(vogais[rnd.Next(0, vogais.Length)]);
                    else
                        nome = nome + Convert.ToString(consoantes[rnd.Next(0, consoantes.Length)]);
                }
            }

            return nome;
        }

        public int GeraInteiro(int min, int max)
        {
            return rnd.Next(min, max+1);
        }

        public bool GeraBoolean(int chanceTrue)
        {
            int resultado = rnd.Next(1, 101);

            if (resultado < chanceTrue)
                return true;
            else
                return false;
        }

    }
}
