using System;
using System.Collections.Generic;
using Desire.Core.Ciencias;

namespace Desire.Core.Util.Geradores
{
    public class GeradorTipoDeAlvo : IGerador<IAlvoHabilidade>
    {
        GeradorInteiro rng = new GeradorInteiro();

        public IAlvoHabilidade Gerar(Random rnd)
        {
            int tipoDeAlvo = rng.GerarEntre(1, 8, rnd);
            switch (tipoDeAlvo)
            {
                case 1:
                    GeradorAlvoEgo genEgo = new GeradorAlvoEgo();
                    return genEgo.Gerar(rnd);
                case 2:
                    GeradorAlvoPonto genPonto = new GeradorAlvoPonto();
                    return genPonto.Gerar(rnd);
                case 3:
                    GeradorAlvoLinha genLinha = new GeradorAlvoLinha();
                    return genLinha.Gerar(rnd);
                case 4:
                    GeradorAlvoCirculo genCirculo = new GeradorAlvoCirculo();
                    return genCirculo.Gerar(rnd);
                case 5:
                    GeradorAlvoVetor genVetor = new GeradorAlvoVetor();
                    return genVetor.Gerar(rnd);
                case 6:
                    GeradorAlvoLosango genLosango = new GeradorAlvoLosango();
                    return genLosango.Gerar(rnd);
                case 7:
                    GeradorAlvoTriangulo genTriangulo = new GeradorAlvoTriangulo();
                    return genTriangulo.Gerar(rnd);
                case 8:
                    GeradorAlvoElipse genElipse = new GeradorAlvoElipse();
                    return genElipse.Gerar(rnd);
                default:
                    return null;
            }
        }

        public List<IAlvoHabilidade> GerarLista(int quantidade, Random rnd)
        {
            List<IAlvoHabilidade> resultado = new List<IAlvoHabilidade>();

            for (int i = 0; i < quantidade-1; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }

    public class GeradorAlvoEgo : IGerador<AlvoEgo>
    {
        public AlvoEgo Gerar(Random rnd)
        {
            AlvoEgo resultado = new AlvoEgo();

            return resultado;
        }

        public List<AlvoEgo> GerarLista(int quantidade, Random rnd)
        {
            List<AlvoEgo> resultado = new List<AlvoEgo>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }

    public class GeradorAlvoPonto : IGerador<AlvoPonto>
    {
        public AlvoPonto Gerar(Random rnd)
        {
            AlvoPonto resultado = new AlvoPonto()
            {
                Alvo = new Ser() 
            };

            return resultado;
        }

        public List<AlvoPonto> GerarLista(int quantidade, Random rnd)
        {
            List<AlvoPonto> resultado = new List<AlvoPonto>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }

    public class GeradorAlvoLinha : IGerador<AlvoLinha>
    {
        public AlvoLinha Gerar(Random rnd)
        {
            GeradorValorMag genValorMag = new GeradorValorMag();
            AlvoLinha resultado = new AlvoLinha()
            {
                Alvo = new Ser(),
                DistanciaMaxima = genValorMag.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd),
                Velocidade = genValorMag.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd)
            };
            return resultado;
        }

        public List<AlvoLinha> GerarLista(int quantidade, Random rnd)
        {
            List<AlvoLinha> resultado = new List<AlvoLinha>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }

            return resultado;
        }
    }

    public class GeradorAlvoCirculo : IGerador<AlvoCirculo>
    {
        public AlvoCirculo Gerar(Random rnd)
        {
            GeradorValorMag genValorMag = new GeradorValorMag();
            AlvoCirculo resultado = new AlvoCirculo()
            {
                Alvos = new List<Ser>(),
                RaioMaximo = genValorMag.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd)
            };
            return resultado;
        }

        public List<AlvoCirculo> GerarLista(int quantidade, Random rnd)
        {
            List<AlvoCirculo> resultado = new List<AlvoCirculo>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }
            return resultado;
        }
    }

    public class GeradorAlvoVetor : IGerador<AlvoVetor>
    {
        public AlvoVetor Gerar(Random rnd)
        {
            GeradorValorMag genValorMag = new GeradorValorMag();
            AlvoVetor resultado = new AlvoVetor()
            {
                Alvos = new List<Ser>(),
                PulosMaximos = genValorMag.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd)
            };
            return resultado;
        }

        public List<AlvoVetor> GerarLista(int quantidade, Random rnd)
        {
            List<AlvoVetor> resultado = new List<AlvoVetor>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }
            return resultado;
        }
    }

    public class GeradorAlvoLosango : IGerador<AlvoLosango>
    {
        public AlvoLosango Gerar(Random rnd)
        {
            GeradorValorMag genValorMag = new GeradorValorMag();
            AlvoLosango resultado = new AlvoLosango()
            {
                AlvosDeclarados = new List<Ser>(),
                RaioMaximo = genValorMag.GerarEntre(new ValorMag(10, 0), new ValorMag(99, 15), rnd)
            };
            return resultado;
        }

        public List<AlvoLosango> GerarLista(int quantidade, Random rnd)
        {
            List<AlvoLosango> resultado = new List<AlvoLosango>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }
            return resultado;
        }
    }

    public class GeradorAlvoTriangulo : IGerador<AlvoTriangulo>
    {
        public AlvoTriangulo Gerar(Random rnd)
        {
            AlvoTriangulo resultado = new AlvoTriangulo()
            {
                AlvoDeclarado = new Ser()
            };
            return resultado;
        }

        public List<AlvoTriangulo> GerarLista(int quantidade, Random rnd)
        {
            List<AlvoTriangulo> resultado = new List<AlvoTriangulo>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }
            return resultado;
        }
    }

    public class GeradorAlvoElipse : IGerador<AlvoElipse>
    {
        public AlvoElipse Gerar(Random rnd)
        {
            AlvoElipse resultado = new AlvoElipse()
            {
                AlvosAfetados = new List<Ser>(),
                Regras = "Alvo gerado aleatoriamente com regras aleatorias."
            };
            return resultado;
        }

        public List<AlvoElipse> GerarLista(int quantidade, Random rnd)
        {
            List<AlvoElipse> resultado = new List<AlvoElipse>();
            for (int i = 0; i < quantidade; i++)
            {
                resultado.Add(Gerar(rnd));
            }
            return resultado;
        }
    }





}