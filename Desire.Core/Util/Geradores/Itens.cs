using System;
using System.Collections.Generic;
using System.Text;
using Desire.Core.Itens;
using Desire.Core.Util;

namespace Desire.Core.Util.Geradores
{
    interface IGeradorItem<T>
    {
        ///<summary>
        ///Gera gera um item com um nivel específico.
        ///</summary>
        /// <param name="nivel">Nivel do item a ser gerado.</param>
        T GerarNivel(int nivel, Random rnd);
        ///<summary>
        ///Gera uma lista de itens de nivel específico de quantidade especifíca.
        ///</summary>
        /// <param name="nivel">Nivel do item a ser gerado.</param>
        /// <param name="quantidade">Quantidade itens na lista</param>
        List<T> GerarListaNivel(int nivel, int quantidade, Random rnd);
    }

    public class GeradorItem : IGerador<Item>
    {
        public Item Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            //Número de tipos de item diferentes. Utilizado para aleatorizar o tipo de item a ser gerado. Adicionar mais um a cada novo tipo de item adicionado
            int quantidadeTiposDeItem = 7;

            int tipoDeItem = rng.GerarEntre(1, quantidadeTiposDeItem, rnd);

            switch (tipoDeItem)
            {
                //ArmaBranca
                case 1:
                    GeradorArmaBranca genArmaBranca = new GeradorArmaBranca();
                    return genArmaBranca.Gerar(rnd);

                //ArmaDeTiro
                case 2:
                    GeradorArmaDeTiro genArmaDeTiro = new GeradorArmaDeTiro();
                    return genArmaDeTiro.Gerar(rnd);

                //Consumivel
                case 3:
                    GeradorConsumivel genConsumivel = new GeradorConsumivel();
                    return genConsumivel.Gerar(rnd);

                //Material
                case 4:
                    GeradorMaterial genMaterial = new GeradorMaterial();
                    return genMaterial.Gerar(rnd);

                //Municao
                case 5:
                    GeradorMunicao genMunicao = new GeradorMunicao();
                    return genMunicao.Gerar(rnd);

                //Posse
                case 6:
                    GeradorPosse genPosse = new GeradorPosse();
                    return genPosse.Gerar(rnd);

                //Vestivel
                case 7:
                    GeradorVestivel genVestivel = new GeradorVestivel();
                    return genVestivel.Gerar(rnd);

                default:
                    return null;
            }
        }

        public List<Item> GerarLista(int quantidade, Random rnd)
        {
            List<Item> resultado = new List<Item>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }

    public class GeradorEquipamento : IGerador<Equipamento>
    {
        public Equipamento Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            //Quantidade de tipos diferentes de equipamento existentes
            int quantidadeTiposEquipamento = 3;

            int tipoDeEquipamento = rng.GerarEntre(1, quantidadeTiposEquipamento, rnd);

            switch (tipoDeEquipamento)
            {
                //ArmaBranca
                case 1:
                    GeradorArmaBranca genArmaBranca = new GeradorArmaBranca();
                    return genArmaBranca.Gerar(rnd);
                //ArmaDeTiro
                case 2:
                    GeradorArmaDeTiro genArmaDeTiro = new GeradorArmaDeTiro();
                    return genArmaDeTiro.Gerar(rnd);
                    //Vestivel
                case 3:
                    GeradorVestivel genVestivel = new GeradorVestivel();
                    return genVestivel.Gerar(rnd);

                default:
                    return null;

            }
        }

        public List<Equipamento> GerarLista(int quantidade, Random rnd)
        {
            List<Equipamento> resultado = new List<Equipamento>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }
            return resultado;
        }
    }

    public class GeradorArma : IGerador<Arma>
    {
        public Arma Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            //Quantidade de tipos diferentes de equipamento existentes
            int quantidadeTiposArma = 2;

            int tipoDeArma = rng.GerarEntre(1, quantidadeTiposArma, rnd);

            switch (tipoDeArma)
            {
                //ArmaBranca
                case 1:
                    GeradorArmaBranca genArmaBranca = new GeradorArmaBranca();
                    return genArmaBranca.Gerar(rnd);
                //ArmaDeTiro
                case 2:
                    GeradorArmaDeTiro genArmaDeTiro = new GeradorArmaDeTiro();
                    return genArmaDeTiro.Gerar(rnd);

                default:
                    return null;
            }
        }

            public List<Arma> GerarLista(int quantidade, Random rnd)
            {
                List<Arma> resultado = new List<Arma>();

                for (int i = 0; i < quantidade; i++)
                {
                    resultado.Add(Gerar(rnd));
                }
                return resultado;
            }
    }

    public class GeradorVestivel : IGerador<Vestivel>
    {
        public Vestivel Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorMaterial genMaterial = new GeradorMaterial();
            GeradorString genString = new GeradorString();
            GeradorModificador genModificador = new GeradorModificador();
            Vestivel resultado = new Vestivel()
            {
                Id = rng.GerarEntre(1, 1000, rnd),
                Caracteristicas = "Vestivel gerado aleatoriamente",
                Comprimento = genValorMag.Gerar(rnd),
                Essencia = rng.GerarEntre(1, 100000, rnd),
                Energia = rng.GerarEntre(0, 100000, rnd),
                Largura = genValorMag.Gerar(rnd),
                MaterialBase = genMaterial.Gerar(rnd),
                Nivel = rng.GerarEntre(1, 100, rnd),
                Nome = genString.GerarTamanhoEspecifico(3, 8, rnd),
                Peso = genValorMag.Gerar(rnd),
                Raridade = rng.GerarEntre(1, 100, rnd),
                Tipo = rng.GerarEntre(1, 100, rnd),
                Valor = rng.GerarEntre(1, 100000, rnd),
                Magnitude = rng.GerarEntre(1, 20, rnd),
                Massa = genValorMag.Gerar(rnd),
                ResCorte = genValorMag.Gerar(rnd),
                ResDegeneracao = genValorMag.Gerar(rnd),
                ResImpacto = genValorMag.Gerar(rnd),
                ResPenetracao = genValorMag.Gerar(rnd),
                Slot = rng.GerarEntre(1, 10, rnd)
            };
            resultado.Modificadores = genModificador.GerarListaComOrigem("Vestivel", resultado.Id, rng.GerarEntre(0, 5, rnd), rnd);
            return resultado;
        }

        public List<Vestivel> GerarLista(int quantidade, Random rnd)
        {
            List<Vestivel> resultado = new List<Vestivel>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }
            return resultado;
        }
    }

    public class GeradorPosse : IGerador<Posse>
    {
        public Posse Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorMaterial genMaterial = new GeradorMaterial();
            GeradorString genString = new GeradorString();
            GeradorModificador genModificador = new GeradorModificador();
            Posse resultado = new Posse()
            {
                Id = rng.GerarEntre(1, 1000, rnd),
                Caracteristicas = "Munição gerada aleatoriamente",
                Comprimento = genValorMag.Gerar(rnd),
                Essencia = rng.GerarEntre(1, 100000, rnd),
                Energia = rng.GerarEntre(0, 100000, rnd),
                Largura = genValorMag.Gerar(rnd),
                MaterialBase = genMaterial.Gerar(rnd),
                Nivel = rng.GerarEntre(1, 100, rnd),
                Nome = genString.GerarTamanhoEspecifico(3, 8, rnd),
                Peso = genValorMag.Gerar(rnd),
                Raridade = rng.GerarEntre(1, 100, rnd),
                Tipo = rng.GerarEntre(1, 100, rnd),
                Valor = rng.GerarEntre(1, 100000, rnd),
                Magnitude = rng.GerarEntre(1, 20, rnd),
                Massa = genValorMag.Gerar(rnd),
            };
            resultado.Modificadores = genModificador.GerarListaComOrigem("Munição", resultado.Id, rng.GerarEntre(0, 5, rnd), rnd);

            return resultado;
        }

        public List<Posse> GerarLista(int quantidade, Random rnd)
        {
            List<Posse> resultado = new List<Posse>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }
            return resultado;
        }
    }

    public class GeradorMunicao : IGerador<Municao>
    {
        public Municao Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorMaterial genMaterial = new GeradorMaterial();
            GeradorString genString = new GeradorString();
            GeradorModificador genModificador = new GeradorModificador();
            Municao resultado = new Municao()
            {
                Id = rng.GerarEntre(1, 1000, rnd),
                Caracteristicas = "Munição gerada aleatoriamente",
                Comprimento = genValorMag.Gerar(rnd),
                Essencia = rng.GerarEntre(1, 100000, rnd),
                Energia = rng.GerarEntre(0, 100000, rnd),
                Largura = genValorMag.Gerar(rnd),
                MaterialBase = genMaterial.Gerar(rnd),
                Nivel = rng.GerarEntre(1, 100, rnd),
                Nome = genString.GerarTamanhoEspecifico(3, 8, rnd),
                Peso = genValorMag.Gerar(rnd),
                Raridade = rng.GerarEntre(1, 100, rnd),
                Tipo = rng.GerarEntre(1, 100, rnd),
                Valor = rng.GerarEntre(1, 100000, rnd),
                Magnitude = rng.GerarEntre(1, 20, rnd),
                Massa = genValorMag.Gerar(rnd),
                CorteBonus = genValorMag.Gerar(rnd),
                DanoBonus = genValorMag.Gerar(rnd),
                ImpactoBonus = genValorMag.Gerar(rnd),
                PenetracaoBonus = genValorMag.Gerar(rnd)
            };
            resultado.Modificadores = genModificador.GerarListaComOrigem("Munição", resultado.Id, rng.GerarEntre(0, 5, rnd), rnd);

            return resultado;
        }

        public List<Municao> GerarLista(int quantidade, Random rnd)
        {
            List<Municao> resultado = new List<Municao>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }
            return resultado;
        }
    }

    public class GeradorConsumivel : IGerador<Consumivel>
    {
        public Consumivel Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorMaterial genMaterial = new GeradorMaterial();
            GeradorString genString = new GeradorString();
            GeradorEfeito genEfeito = new GeradorEfeito();
            Consumivel resultado = new Consumivel()
            {
                Id = rng.GerarEntre(1, 1000, rnd),
                Caracteristicas = "Consumivel gerado aleatoriamente",
                Comprimento = genValorMag.Gerar(rnd),
                Essencia = rng.GerarEntre(1, 100000, rnd),
                Energia = rng.GerarEntre(0, 100000, rnd),
                Largura = genValorMag.Gerar(rnd),
                MaterialBase = genMaterial.Gerar(rnd),
                Nivel = rng.GerarEntre(1, 100, rnd),
                Nome = genString.GerarTamanhoEspecifico(3, 8, rnd),
                Peso = genValorMag.Gerar(rnd),
                Raridade = rng.GerarEntre(1, 100, rnd),
                Tipo = rng.GerarEntre(1, 100, rnd),
                Valor = rng.GerarEntre(1, 100000, rnd),
                Magnitude = rng.GerarEntre(1, 20, rnd),
                Massa = genValorMag.Gerar(rnd),
                Efeitos = genEfeito.GerarLista(rng.GerarEntre(1, 5, rnd), rnd)
            };
            return resultado;
        }

        public List<Consumivel> GerarLista(int quantidade, Random rnd)
        {
            List<Consumivel> resultado = new List<Consumivel>();

            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }
            return resultado;
        }
    }

    public class GeradorArmaDeTiro : IGerador<ArmaDeTiro>
    {
        public ArmaDeTiro Gerar(Random rnd)
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorMaterial genMaterial = new GeradorMaterial();
            GeradorString genString = new GeradorString();
            GeradorMunicao genMunicao = new GeradorMunicao();
            GeradorModificador genModificador = new GeradorModificador();
            GeradorBoolean genBoolean = new GeradorBoolean();
            int tipoDano = rng.GerarEntre(1, 4, rnd);
            string[] tiposOperacao = new string[] { "FullAuto", "Burst", "Single", "Pump", "Charge" };
            int operacoes = 0;
            ArmaDeTiro armaDeFogo = new ArmaDeTiro()
            {
                Id = rng.GerarEntre(1, 1000, rnd),
                Caracteristicas = "Arma de Fogo gerada aleatoriamente",
                Comprimento = genValorMag.Gerar(rnd),
                DistanciaMax = genValorMag.Gerar(rnd),
                DistanciaMin = genValorMag.Gerar(rnd),
                Essencia = rng.GerarEntre(1, 100000, rnd),
                Energia = rng.GerarEntre(0, 100000, rnd),
                Largura = genValorMag.Gerar(rnd),
                MaterialBase = genMaterial.Gerar(rnd),
                Nivel = rng.GerarEntre(1, 100, rnd),
                Nome = genString.GerarTamanhoEspecifico(3, 8, rnd),
                Peso = genValorMag.Gerar(rnd),
                Raridade = rng.GerarEntre(1, 100, rnd),
                Tipo = rng.GerarEntre(1, 100, rnd),
                TipoCarga = genMunicao.Gerar(rnd),
                TirosPorCarga = rng.GerarEntre(1, 100000, rnd),
                Valor = rng.GerarEntre(1, 100000, rnd),
            };

            armaDeFogo.Modificadores = genModificador.GerarListaComOrigem("Arma", armaDeFogo.Id, rng.GerarEntre(0, 5, rnd), rnd);

            operacoes = rng.GerarEntre(1, tiposOperacao.Length, rnd);
            for (int i = 0; i < operacoes; i++)
            {
                armaDeFogo.Operacoes = new string[tiposOperacao.Length];
                armaDeFogo.Operacoes[i] = tiposOperacao[rng.GerarEntre(0, tiposOperacao.Length - 1, rnd)];
            }

            if (tipoDano == 1)
                armaDeFogo.DanoCorte = rng.GerarEntre(1, 100000, rnd);
            else if (tipoDano == 2)
                armaDeFogo.DanoImpacto = rng.GerarEntre(1, 100000, rnd);
            else if (tipoDano == 3)
                armaDeFogo.DanoPenetracao = rng.GerarEntre(1, 1000000, rnd);
            if (genBoolean.GeraComChance(10, rnd))
                armaDeFogo.ModificadorDano = "por ki";

            armaDeFogo.TirosPorAcao = armaDeFogo.TirosPorCarga - rng.GerarEntre(0, 100000, rnd);

            return armaDeFogo;
        }

        public List<ArmaDeTiro> GerarLista(int quantidade, Random rnd)
        {
            List<ArmaDeTiro> resultado = new List<ArmaDeTiro>();

            for (int i = 0; i < quantidade-1; i++)
            {
                resultado.Add(Gerar(rnd));
            }
            return resultado;
        }
    }

    public class GeradorArmaBranca: IGerador<ArmaBranca>, IGeradorItem<ArmaBranca>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorMaterial geradorMaterial = new GeradorMaterial();
        GeradorString geradorString = new GeradorString();
        GeradorValorMag geradorValorMag = new GeradorValorMag();
        GeradorModificador geradorModificador = new GeradorModificador();
        GeradorBoolean geradorBoolean = new GeradorBoolean();
        string[] tiposAtributo = new string[] { "Força", "Materia", "Destreza", "Intelecto", "Criatividade", "Idéia", "Existência" };

        public ArmaBranca Gerar(Random rnd)
        {
            int tipoDanoBranca = rng.GerarEntre(1, 4, rnd);
            ArmaBranca armaBranca = new ArmaBranca()
            {
                Comprimento = geradorValorMag.Gerar(rnd),
                Energia = rng.GerarEntre(1, 10000, rnd),
                Essencia = rng.GerarEntre(1, 10000, rnd),
                Largura = geradorValorMag.Gerar(rnd),
                Magnitude = rng.GerarEntre(1, 100, rnd),
                Massa = geradorValorMag.Gerar(rnd),
                Nivel = rng.GerarEntre(1, 10000, rnd),
                Peso = geradorValorMag.Gerar(rnd),
                Tipo = 0, //TODO: inserir codigo de "ArmaBranca"
                Nome = geradorString.GerarTamanhoEspecifico(3, 10, rnd),
                Raridade = rng.GerarEntre(1, 10000, rnd),
                Id = rng.GerarEntre(1, 100, rnd),
                AtributoBonus = tiposAtributo[rng.GerarEntre(0, tiposAtributo.Length - 1, rnd)],
                Caracteristicas = "Arma Branca gerada aleatoriamente",
                MaterialBase = geradorMaterial.Gerar(rnd),
                MultiplicadorCritico = rng.GerarEntre(1, 10, rnd),
                Slot = rng.GerarEntre(1, 10, rnd)
            };
            armaBranca.Modificadores = geradorModificador.GerarListaComOrigem("Arma", armaBranca.Id, rng.GerarEntre(1, 5, rnd), rnd);
            armaBranca.Valor = armaBranca.MaterialBase.Valor + rng.GerarEntre(1, 1000000, rnd);

            if (tipoDanoBranca == 1)
                armaBranca.DanoCorte = rng.GerarEntre(1, 100000, rnd);
            else if (tipoDanoBranca == 2)
                armaBranca.DanoImpacto = rng.GerarEntre(1, 100000, rnd);
            else if (tipoDanoBranca == 3)
                armaBranca.DanoPenetracao = rng.GerarEntre(1, 1000000, rnd);
            if (geradorBoolean.GeraComChance(10, rnd))
                armaBranca.ModificadorDano = "por ki";

            return armaBranca;
        }

        public List<ArmaBranca> GerarLista(int quantidade, Random rnd)
        {
            List<ArmaBranca> resultado = new List<ArmaBranca>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }
            return resultado;
        }

        public List<ArmaBranca> GerarListaNivel(int magnitude, int quantidade, Random rnd)
        {
            List<ArmaBranca> resultado = new List<ArmaBranca>();
            for (int i = 0; i < quantidade; i++)
            {
                ArmaBranca item = Gerar(rnd);
                item.Magnitude = magnitude;
                resultado.Add(Gerar(rnd));
            }
            return resultado;
        }

        public ArmaBranca GerarNivel(int magnitude, Random rnd)
        {
            ArmaBranca item = Gerar(rnd);
            item.Magnitude = magnitude;
            return item;
        }
    }

    public class GeradorMaterial:IGerador<Material>
    {
        GeradorInteiro rng = new GeradorInteiro();
        GeradorValorMag geradorValorMag = new GeradorValorMag();
        GeradorString geradorString = new GeradorString();
        GeradorModificador geradorModificador = new GeradorModificador();

        public Material Gerar(Random rnd)
        {
            Material material = new Material()
            {
                Caracteristicas = "Material Gerado Aleatoriamente",
                Comprimento = geradorValorMag.Gerar(rnd),
                Energia = rng.GerarEntre(1, 10000, rnd),
                Essencia = rng.GerarEntre(1, 10000, rnd),
                Id = rng.GerarEntre(1, 10000, rnd),
                Largura = geradorValorMag.Gerar(rnd),
                Magnitude = rng.GerarEntre(1, 100, rnd),
                Massa = geradorValorMag.Gerar(rnd),
                MaterialBase = null,
                Nivel = rng.GerarEntre(1, 10000, rnd),
                Peso = geradorValorMag.Gerar(rnd),
                Tipo = 0, //TODO: inserir codigo de "Material"
                Valor = rng.GerarEntre(1, 10000, rnd),
                Dureza = geradorValorMag.Gerar(rnd),
                Nome = geradorString.GerarTamanhoEspecifico(3, 10, rnd),
                Resistencia = new ValorMag(rng.GerarEntre(1, 100, rnd), rng.GerarEntre(1, 10, rnd)),
                DensidadePorGrama = new ValorMag(rng.GerarEntre(1, 100, rnd), rng.GerarEntre(1, 10, rnd)),
                Raridade = rng.GerarEntre(1, 10000, rnd),
            };

            material.Modificadores = geradorModificador.GerarListaComOrigem("Arma", material.Id, rng.GerarEntre(1, 5, rnd), rnd);
            return material;
        }

        public List<Material> GerarLista(int quantidade, Random rnd)
        {
            List<Material> resultado = new List<Material>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }
}
