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
        T GerarNivel(int nivel);
        ///<summary>
        ///Gera uma lista de itens de nivel específico de quantidade especifíca.
        ///</summary>
        /// <param name="nivel">Nivel do item a ser gerado.</param>
        /// <param name="quantidade">Quantidade itens na lista</param>
        List<T> GerarListaNivel(int nivel, int quantidade);
    }

    public class GeradorItem : IGerador<Item>
    {
        public Item Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            //Número de tipos de item diferentes. Utilizado para aleatorizar o tipo de item a ser gerado. Adicionar mais um a cada novo tipo de item adicionado
            int quantidadeTiposDeItem = 7;

            int tipoDeItem = rng.GerarEntre(1, quantidadeTiposDeItem);

            switch (tipoDeItem)
            {
                //ArmaBranca
                case 1:
                    GeradorArmaBranca genArmaBranca = new GeradorArmaBranca();
                    return genArmaBranca.Gerar();

                //ArmaDeTiro
                case 2:
                    GeradorArmaDeTiro genArmaDeTiro = new GeradorArmaDeTiro();
                    return genArmaDeTiro.Gerar();

                //Consumivel
                case 3:
                    GeradorConsumivel genConsumivel = new GeradorConsumivel();
                    return genConsumivel.Gerar();

                //Material
                case 4:
                    GeradorMaterial genMaterial = new GeradorMaterial();
                    return genMaterial.Gerar();

                //Municao
                case 5:
                    GeradorMunicao genMunicao = new GeradorMunicao();
                    return genMunicao.Gerar();

                //Posse
                case 6:
                    GeradorPosse genPosse = new GeradorPosse();
                    return genPosse.Gerar();

                //Vestivel
                case 7:
                    GeradorVestivel genVestivel = new GeradorVestivel();
                    return genVestivel.Gerar();

                default:
                    return null;
            }
        }

        public List<Item> GerarLista(int quantidade)
        {
            throw new NotImplementedException();
        }
    }

    public class GeradorEquipamento : IGerador<Equipamento>
    {
        public Equipamento Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            //Quantidade de tipos diferentes de equipamento existentes
            int quantidadeTiposEquipamento = 3;

            int tipoDeEquipamento = rng.GerarEntre(1, quantidadeTiposEquipamento);

            switch (tipoDeEquipamento)
            {
                //ArmaBranca
                case 1:
                    GeradorArmaBranca genArmaBranca = new GeradorArmaBranca();
                    return genArmaBranca.Gerar();
                //ArmaDeTiro
                case 2:
                    GeradorArmaDeTiro genArmaDeTiro = new GeradorArmaDeTiro();
                    return genArmaDeTiro.Gerar();
                    //Vestivel
                case 3:
                    GeradorVestivel genVestivel = new GeradorVestivel();
                    return genVestivel.Gerar();

                default:
                    return null;

            }
        }

        public List<Equipamento> GerarLista(int quantidade)
        {
            List<Equipamento> resultado = new List<Equipamento>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }
            return resultado;
        }
    }

    public class GeradorArma : IGerador<Arma>
    {
        public Arma Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            //Quantidade de tipos diferentes de equipamento existentes
            int quantidadeTiposArma = 2;

            int tipoDeArma = rng.GerarEntre(1, quantidadeTiposArma);

            switch (tipoDeArma)
            {
                //ArmaBranca
                case 1:
                    GeradorArmaBranca genArmaBranca = new GeradorArmaBranca();
                    return genArmaBranca.Gerar();
                //ArmaDeTiro
                case 2:
                    GeradorArmaDeTiro genArmaDeTiro = new GeradorArmaDeTiro();
                    return genArmaDeTiro.Gerar();

                default:
                    return null;
            }
        }

            public List<Arma> GerarLista(int quantidade)
            {
                List<Arma> resultado = new List<Arma>();

                for (int i = 0; i < quantidade - 1; i++)
                {
                    resultado.Add(Gerar());
                }
                return resultado;
            }
    }

    public class GeradorVestivel : IGerador<Vestivel>
    {
        public Vestivel Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorMaterial genMaterial = new GeradorMaterial();
            GeradorString genString = new GeradorString();
            GeradorModificador genModificador = new GeradorModificador();
            Vestivel resultado = new Vestivel()
            {
                Id = rng.GerarEntre(1, 1000),
                Caracteristicas = "Vestivel gerado aleatoriamente",
                Comprimento = genValorMag.Gerar(),
                Essencia = rng.GerarEntre(1, 100000),
                Energia = rng.GerarEntre(0, 100000),
                Largura = genValorMag.Gerar(),
                MaterialBase = genMaterial.Gerar(),
                Nivel = rng.GerarEntre(1, 100),
                Nome = genString.GerarTamanhoEspecifico(3, 8),
                Peso = genValorMag.Gerar(),
                Raridade = rng.GerarEntre(1, 100),
                Tipo = rng.GerarEntre(1, 100),
                Valor = rng.GerarEntre(1, 100000),
                Magnitude = rng.GerarEntre(1, 20),
                Massa = genValorMag.Gerar(),
                ResCorte = genValorMag.Gerar(),
                ResDegeneracao = genValorMag.Gerar(),
                ResImpacto = genValorMag.Gerar(),
                ResPenetracao = genValorMag.Gerar(),
                Slot = rng.GerarEntre(1, 10)
            };
            resultado.Modificadores = genModificador.GerarListaComOrigem("Vestivel", resultado.Id, rng.GerarEntre(0, 5));
            return resultado;
        }

        public List<Vestivel> GerarLista(int quantidade)
        {
            List<Vestivel> resultado = new List<Vestivel>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }
            return resultado;
        }
    }

    public class GeradorPosse : IGerador<Posse>
    {
        public Posse Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorMaterial genMaterial = new GeradorMaterial();
            GeradorString genString = new GeradorString();
            GeradorModificador genModificador = new GeradorModificador();
            Posse resultado = new Posse()
            {
                Id = rng.GerarEntre(1, 1000),
                Caracteristicas = "Munição gerada aleatoriamente",
                Comprimento = genValorMag.Gerar(),
                Essencia = rng.GerarEntre(1, 100000),
                Energia = rng.GerarEntre(0, 100000),
                Largura = genValorMag.Gerar(),
                MaterialBase = genMaterial.Gerar(),
                Nivel = rng.GerarEntre(1, 100),
                Nome = genString.GerarTamanhoEspecifico(3, 8),
                Peso = genValorMag.Gerar(),
                Raridade = rng.GerarEntre(1, 100),
                Tipo = rng.GerarEntre(1, 100),
                Valor = rng.GerarEntre(1, 100000),
                Magnitude = rng.GerarEntre(1, 20),
                Massa = genValorMag.Gerar(),
            };
            resultado.Modificadores = genModificador.GerarListaComOrigem("Munição", resultado.Id, rng.GerarEntre(0, 5));

            return resultado;
        }

        public List<Posse> GerarLista(int quantidade)
        {
            List<Posse> resultado = new List<Posse>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }
            return resultado;
        }
    }

    public class GeradorMunicao : IGerador<Municao>
    {
        public Municao Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorMaterial genMaterial = new GeradorMaterial();
            GeradorString genString = new GeradorString();
            GeradorModificador genModificador = new GeradorModificador();
            Municao resultado = new Municao()
            {
                Id = rng.GerarEntre(1, 1000),
                Caracteristicas = "Munição gerada aleatoriamente",
                Comprimento = genValorMag.Gerar(),
                Essencia = rng.GerarEntre(1, 100000),
                Energia = rng.GerarEntre(0, 100000),
                Largura = genValorMag.Gerar(),
                MaterialBase = genMaterial.Gerar(),
                Nivel = rng.GerarEntre(1, 100),
                Nome = genString.GerarTamanhoEspecifico(3, 8),
                Peso = genValorMag.Gerar(),
                Raridade = rng.GerarEntre(1, 100),
                Tipo = rng.GerarEntre(1, 100),
                Valor = rng.GerarEntre(1, 100000),
                Magnitude = rng.GerarEntre(1, 20),
                Massa = genValorMag.Gerar(),
                CorteBonus = genValorMag.Gerar(),
                DanoBonus = genValorMag.Gerar(),
                ImpactoBonus = genValorMag.Gerar(),
                PenetracaoBonus = genValorMag.Gerar()
            };
            resultado.Modificadores = genModificador.GerarListaComOrigem("Munição", resultado.Id, rng.GerarEntre(0, 5));

            return resultado;
        }

        public List<Municao> GerarLista(int quantidade)
        {
            List<Municao> resultado = new List<Municao>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }
            return resultado;
        }
    }

    public class GeradorConsumivel : IGerador<Consumivel>
    {
        public Consumivel Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorMaterial genMaterial = new GeradorMaterial();
            GeradorString genString = new GeradorString();
            GeradorEfeito genEfeito = new GeradorEfeito();
            Consumivel resultado = new Consumivel()
            {
                Id = rng.GerarEntre(1, 1000),
                Caracteristicas = "Consumivel gerado aleatoriamente",
                Comprimento = genValorMag.Gerar(),
                Essencia = rng.GerarEntre(1, 100000),
                Energia = rng.GerarEntre(0, 100000),
                Largura = genValorMag.Gerar(),
                MaterialBase = genMaterial.Gerar(),
                Nivel = rng.GerarEntre(1, 100),
                Nome = genString.GerarTamanhoEspecifico(3, 8),
                Peso = genValorMag.Gerar(),
                Raridade = rng.GerarEntre(1, 100),
                Tipo = rng.GerarEntre(1, 100),
                Valor = rng.GerarEntre(1, 100000),
                Magnitude = rng.GerarEntre(1, 20),
                Massa = genValorMag.Gerar(),
                Efeitos = genEfeito.GerarLista(rng.GerarEntre(1, 5))
            };
            return resultado;
        }

        public List<Consumivel> GerarLista(int quantidade)
        {
            List<Consumivel> resultado = new List<Consumivel>();

            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }
            return resultado;
        }
    }

    public class GeradorArmaDeTiro : IGerador<ArmaDeTiro>
    {
        public ArmaDeTiro Gerar()
        {
            GeradorInteiro rng = new GeradorInteiro();
            GeradorValorMag genValorMag = new GeradorValorMag();
            GeradorMaterial genMaterial = new GeradorMaterial();
            GeradorString genString = new GeradorString();
            GeradorMunicao genMunicao = new GeradorMunicao();
            GeradorModificador genModificador = new GeradorModificador();
            GeradorBoolean genBoolean = new GeradorBoolean();
            int tipoDano = rng.GerarEntre(1, 4);
            string[] tiposOperacao = new string[] { "FullAuto", "Burst", "Single", "Pump", "Charge" };
            int operacoes = 0;
            ArmaDeTiro armaDeFogo = new ArmaDeTiro()
            {
                Id = rng.GerarEntre(1, 1000),
                Caracteristicas = "Arma de Fogo gerada aleatoriamente",
                Comprimento = genValorMag.Gerar(),
                DistanciaMax = genValorMag.Gerar(),
                DistanciaMin = genValorMag.Gerar(),
                Essencia = rng.GerarEntre(1, 100000),
                Energia = rng.GerarEntre(0, 100000),
                Largura = genValorMag.Gerar(),
                MaterialBase = genMaterial.Gerar(),
                Nivel = rng.GerarEntre(1, 100),
                Nome = genString.GerarTamanhoEspecifico(3, 8),
                Peso = genValorMag.Gerar(),
                Raridade = rng.GerarEntre(1, 100),
                Tipo = rng.GerarEntre(1, 100),
                TipoCarga = genMunicao.Gerar(),
                TirosPorCarga = rng.GerarEntre(1, 100000),
                Valor = rng.GerarEntre(1, 100000),
            };

            armaDeFogo.Modificadores = genModificador.GerarListaComOrigem("Arma", armaDeFogo.Id, rng.GerarEntre(0, 5));

            operacoes = rng.GerarEntre(1, tiposOperacao.Length);
            for (int i = 0; i < operacoes; i++)
            {
                armaDeFogo.Operacoes = new string[tiposOperacao.Length];
                armaDeFogo.Operacoes[i] = tiposOperacao[rng.GerarEntre(0, tiposOperacao.Length - 1)];
            }

            if (tipoDano == 1)
                armaDeFogo.DanoCorte = rng.GerarEntre(1, 100000);
            else if (tipoDano == 2)
                armaDeFogo.DanoImpacto = rng.GerarEntre(1, 100000);
            else if (tipoDano == 3)
                armaDeFogo.DanoPenetracao = rng.GerarEntre(1, 1000000);
            if (genBoolean.GeraComChance(10))
                armaDeFogo.ModificadorDano = "por ki";

            armaDeFogo.TirosPorAcao = armaDeFogo.TirosPorCarga - rng.GerarEntre(0, 100000);

            return armaDeFogo;
        }

        public List<ArmaDeTiro> GerarLista(int quantidade)
        {
            List<ArmaDeTiro> resultado = new List<ArmaDeTiro>();

            for (int i = 0; i < quantidade-1; i++)
            {
                resultado.Add(Gerar());
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

        public ArmaBranca Gerar()
        {
            int tipoDanoBranca = rng.GerarEntre(1, 4);
            ArmaBranca armaBranca = new ArmaBranca()
            {
                Comprimento = geradorValorMag.Gerar(),
                Energia = rng.GerarEntre(1, 10000),
                Essencia = rng.GerarEntre(1, 10000),
                Largura = geradorValorMag.Gerar(),
                Magnitude = rng.GerarEntre(1, 100),
                Massa = geradorValorMag.Gerar(),
                Nivel = rng.GerarEntre(1, 10000),
                Peso = geradorValorMag.Gerar(),
                Tipo = 0, //TODO: inserir codigo de "ArmaBranca"
                Nome = geradorString.GerarTamanhoEspecifico(3, 10),
                Raridade = rng.GerarEntre(1, 10000),
                Id = rng.GerarEntre(1, 100),
                AtributoBonus = tiposAtributo[rng.GerarEntre(0, tiposAtributo.Length - 1)],
                Caracteristicas = "Arma Branca gerada aleatoriamente",
                MaterialBase = geradorMaterial.Gerar(),
                MultiplicadorCritico = rng.GerarEntre(1, 10),
                Slot = rng.GerarEntre(1, 10)
            };
            armaBranca.Modificadores = geradorModificador.GerarListaComOrigem("Arma", armaBranca.Id, rng.GerarEntre(1, 5));
            armaBranca.Valor = armaBranca.MaterialBase.Valor + rng.GerarEntre(1, 1000000);

            if (tipoDanoBranca == 1)
                armaBranca.DanoCorte = rng.GerarEntre(1, 100000);
            else if (tipoDanoBranca == 2)
                armaBranca.DanoImpacto = rng.GerarEntre(1, 100000);
            else if (tipoDanoBranca == 3)
                armaBranca.DanoPenetracao = rng.GerarEntre(1, 1000000);
            if (geradorBoolean.GeraComChance(10))
                armaBranca.ModificadorDano = "por ki";

            return armaBranca;
        }

        public List<ArmaBranca> GerarLista(int quantidade)
        {
            List<ArmaBranca> resultado = new List<ArmaBranca>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }
            return resultado;
        }

        public List<ArmaBranca> GerarListaNivel(int magnitude, int quantidade)
        {
            List<ArmaBranca> resultado = new List<ArmaBranca>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                ArmaBranca item = Gerar();
                item.Magnitude = magnitude;
                resultado.Add(Gerar());
            }
            return resultado;
        }

        public ArmaBranca GerarNivel(int magnitude)
        {
            ArmaBranca item = Gerar();
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

        public Material Gerar()
        {
            Material material = new Material()
            {
                Caracteristicas = "Material Gerado Aleatoriamente",
                Comprimento = geradorValorMag.Gerar(),
                Energia = rng.GerarEntre(1, 10000),
                Essencia = rng.GerarEntre(1, 10000),
                Id = rng.GerarEntre(1, 10000),
                Largura = geradorValorMag.Gerar(),
                Magnitude = rng.GerarEntre(1, 100),
                Massa = geradorValorMag.Gerar(),
                MaterialBase = null,
                Nivel = rng.GerarEntre(1, 10000),
                Peso = geradorValorMag.Gerar(),
                Tipo = 0, //TODO: inserir codigo de "Material"
                Valor = rng.GerarEntre(1, 10000),
                Dureza = geradorValorMag.Gerar(),
                Nome = geradorString.GerarTamanhoEspecifico(3, 10),
                Resistencia = new ValorMag(rng.GerarEntre(1, 100), rng.GerarEntre(1, 10)),
                DensidadePorGrama = new ValorMag(rng.GerarEntre(1, 100), rng.GerarEntre(1, 10)),
                Raridade = rng.GerarEntre(1, 10000),
            };

            material.Modificadores = geradorModificador.GerarListaComOrigem("Arma", material.Id, rng.GerarEntre(1, 5));
            return material;
        }

        public List<Material> GerarLista(int quantidade)
        {
            List<Material> resultado = new List<Material>();
            for (int i = 0; i < quantidade - 1; i++)
            {
                resultado.Add(Gerar());
            }

            return resultado;
        }
    }
}
