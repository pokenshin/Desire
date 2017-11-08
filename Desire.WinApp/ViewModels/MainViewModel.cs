using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Desire.Core;
using Desire.Data.Operacoes;
using Desire.Core.Util;
using System.Windows;
using Desire.Core.Util.Geradores;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace Desire.WinApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Ser ser;
        private int fontSizeSubatributos = 22;
        private int multiplicadorFontSizeSubatributos = 3;
        private int fontSizeAtributos = 24;
        private int multiplicadorFontSizeAtributos = 3;
        private int tamanhoMaximoStringAtributos = 4;
        private int tamanhoMaximoStringSubatributos = 5;
        private DbConsultas dbConsultas;
        private CalculadorSer calculadorSer;

        public event PropertyChangedEventHandler PropertyChanged;

        public Ser Personagem
        {
            get { return ser; }
            set
            {
                ser = value;
                NotifyPropertyChanged("Personagem");
                NotifyPropertyChanged("ReisCount");
                NotifyPropertyChanged("PontosGastos");
                NotifyPropertyChanged("Nivel");
                NotifyPropertyChanged("Ki");
                NotifyPropertyChanged("FontSizeForcaGolpe");
                NotifyPropertyChanged("FontSizeForcaDureza");
                NotifyPropertyChanged("FontSizeDestrezaDinamica");
                NotifyPropertyChanged("FontSizeDestrezaIniciativa");
                NotifyPropertyChanged("FontSizeExistenciaPlano");
                NotifyPropertyChanged("FontSizeIdeiaKi");
                NotifyPropertyChanged("FontSizeIdeiaBase");
                NotifyPropertyChanged("FontSizeApBonus");
                NotifyPropertyChanged("FontSizeSpBonus");
                NotifyPropertyChanged("FontSizeIniciativa");
                NotifyPropertyChanged("FontSizeTurno");
                NotifyPropertyChanged("FontSizeDestria");
            }
        }

        public string Nivel {
            get
            {
                return Convert.ToString(this.ser.Nivel);
            }
            set
            {
                if (int.TryParse(value, out int valor))
                {
                    this.ser.Nivel = valor;
                    atualizaPersonagem();
                }
            }
        }

        public string Ki
        {
            get
            {
                return Convert.ToString(this.ser.Ki);
            }
            set
            {
                if (int.TryParse(value, out int valor))
                {
                    this.ser.Ki = valor;
                    atualizaPersonagem();
                }
            }
        }

        public string PontosGastos
        {
            get { return Convert.ToString(ser.Forca.Pontos + ser.Materia.Pontos + ser.Destreza.Pontos + ser.Criatividade.Pontos + ser.Existencia.Pontos + ser.Ideia.Pontos + ser.Intelecto.Pontos); }
        }

        public string ReisCount
        {
            get { return Convert.ToString(ser.Reis.Count()); }
        }

        public int FontSizeForcaGolpe
        {
            get
            {
                if (ser.Forca.Golpe.ToString().Count() > tamanhoMaximoStringAtributos)
                    return calculaFontSizeAtributo(ser.Forca.Golpe.ToString().Count());
                else
                    return fontSizeAtributos;
            }
        }

        public int FontSizeForcaDureza
        {
            get
            {
                if (ser.Forca.Dureza.ToString().Count() > tamanhoMaximoStringAtributos)
                    return calculaFontSizeAtributo(ser.Forca.Dureza.ToString().Count());
                else
                    return fontSizeAtributos;
            }
        }

        public int FontSizeDestrezaDinamica
        {
            get
            {
                if (ser.Destreza.Dinamica.ToString().Count() > tamanhoMaximoStringAtributos)
                    return calculaFontSizeAtributo(ser.Destreza.Dinamica.ToString().Count());
                else
                    return fontSizeAtributos;
            }
        }

        public int FontSizeDestrezaIniciativa
        {
            get
            {
                if (ser.Destreza.Iniciativa.ToString().Count() > tamanhoMaximoStringAtributos)
                    return calculaFontSizeAtributo(ser.Destreza.Iniciativa.ToString().Count());
                else
                    return fontSizeAtributos;
            }
        }

        public int FontSizeExistenciaPlano
        {
            get
            {
                if (ser.Existencia.Plano.ToString().Count() > tamanhoMaximoStringAtributos)
                    return calculaFontSizeAtributo(ser.Existencia.Plano.ToString().Count());
                else
                    return fontSizeAtributos;
            }
        }

        public int FontSizeIdeiaKi
        {
            get
            {
                if (ser.Ideia.Ki.ToString().Count() > tamanhoMaximoStringAtributos)
                    return calculaFontSizeAtributo(ser.Ideia.Ki.ToString().Count());
                else
                    return fontSizeAtributos;
            }
        }

        public int FontSizeIdeiaBase
        {
            get
            {
                if (ser.Ideia.Base.ToString().Count() > tamanhoMaximoStringAtributos)
                    return calculaFontSizeAtributo(ser.Ideia.Base.ToString().Count());
                else
                    return fontSizeAtributos;
            }
        }

        public int FontSizeApBonus
        {
            get
            {
                if (ser.BonusAP.ToString().Count() > tamanhoMaximoStringSubatributos)
                    return calculaFontSizeSubAtributo(ser.BonusAP.ToString().Count());
                else
                    return fontSizeSubatributos;
            }
        }

        public int FontSizeSpBonus
        {
            get
            {
                if (ser.BonusSP.ToString().Count() > tamanhoMaximoStringSubatributos)
                    return calculaFontSizeSubAtributo(ser.BonusSP.ToString().Count());
                else
                    return fontSizeSubatributos;
            }
        }

        public int FontSizeIniciativa
        {
            get
            {
                if (ser.Iniciativa.ToString().Count() > tamanhoMaximoStringSubatributos)
                    return calculaFontSizeSubAtributo(ser.Iniciativa.ToString().Count());
                else
                    return fontSizeSubatributos;
            }
        }

        public int FontSizeTurno
        {
            get
            {
                if (ser.Turno.ToString().Count() > tamanhoMaximoStringSubatributos)
                    return calculaFontSizeSubAtributo(ser.Turno.ToString().Count());
                else
                    return fontSizeSubatributos;
            }
        }

        public int FontSizeDestria
        {
            get
            {
                if (ser.Destria.ToString().Count() > tamanhoMaximoStringSubatributos)
                    return calculaFontSizeSubAtributo(ser.Destria.ToString().Count());
                else
                    return fontSizeSubatributos;
            }
        }

        public RelayCommand<string> CmdAlteraAtributo
        {
            get; private set;
        }

        public RelayCommand CmdSerAleatorio
        {
            get; private set;
        }

        public MainViewModel()
        {
            dbConsultas = new DbConsultas();
            calculadorSer = new CalculadorSer();
            geraSerAleatorio();
            criaComandos();
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void alteraAtributo(string atributo)
        {
            switch (atributo)
            {
                case "Forca++":
                    ser.Forca.Pontos++;
                    ser.Forca = dbConsultas.RetornaForca(ser.Forca.Pontos);
                    break;

                case "Forca--":
                    ser.Forca.Pontos--;
                    ser.Forca = dbConsultas.RetornaForca(ser.Forca.Pontos);
                    break;

                case "Materia++":
                    ser.Materia.Pontos++;
                    ser.Materia = dbConsultas.RetornaMateria(ser.Materia.Pontos);
                    break;

                case "Materia--":
                    ser.Materia.Pontos--;
                    ser.Materia = dbConsultas.RetornaMateria(ser.Materia.Pontos);
                    break;

                case "Destreza++":
                    ser.Destreza.Pontos++;
                    ser.Destreza = dbConsultas.RetornaDestreza(ser.Destreza.Pontos);
                    break;

                case "Destreza--":
                    ser.Destreza.Pontos--;
                    ser.Destreza = dbConsultas.RetornaDestreza(ser.Destreza.Pontos);
                    break;

                case "Intelecto++":
                    ser.Intelecto.Pontos++;
                    ser.Intelecto = dbConsultas.RetornaIntelecto(ser.Intelecto.Pontos);
                    break;

                case "Intelecto--":
                    ser.Intelecto.Pontos--;
                    ser.Intelecto = dbConsultas.RetornaIntelecto(ser.Intelecto.Pontos);
                    break;

                case "Criatividade++":
                    ser.Criatividade.Pontos++;
                    ser.Criatividade = dbConsultas.RetornaCriatividade(ser.Criatividade.Pontos);
                    break;

                case "Criatividade--":
                    ser.Criatividade.Pontos--;
                    ser.Criatividade = dbConsultas.RetornaCriatividade(ser.Criatividade.Pontos);
                    break;

                case "Existencia++":
                    ser.Existencia.Pontos++;
                    ser.Existencia = dbConsultas.RetornaExistencia(ser.Existencia.Pontos);
                    break;

                case "Existencia--":
                    ser.Existencia.Pontos--;
                    ser.Existencia = dbConsultas.RetornaExistencia(ser.Existencia.Pontos);
                    break;

                case "Ideia++":
                    ser.Ideia.Pontos++;
                    ser.Ideia = dbConsultas.RetornaIdeia(ser.Ideia.Pontos);
                    break;

                case "Ideia--":
                    ser.Ideia.Pontos--;
                    ser.Ideia = dbConsultas.RetornaIdeia(ser.Ideia.Pontos);
                    break;

                default:
                    break;
            }

            NotifyPropertyChanged("PontosGastos");
            ser = calculadorSer.CalculaSubatributos(ser);
            atualizaPersonagem();
        }

        private bool validaAlterarAtributo(string atributo)
        {
            switch (atributo)
            {
                case "Forca++":
                    if (ser.Forca.Pontos < 110)
                        return true;
                    else
                        return false;

                case "Forca--":
                    if (ser.Forca.Pontos > 0 && ser.Forca.Pontos != 1)
                        return true;
                    else
                        return false;

                case "Materia++":
                    if (ser.Materia.Pontos < 110)
                        return true;
                    else
                        return false;

                case "Materia--":
                    if (ser.Materia.Pontos > 0 && ser.Materia.Pontos != 1)
                        return true;
                    else
                        return false;

                case "Destreza++":
                    if (ser.Destreza.Pontos < 110)
                        return true;
                    else
                        return false;

                case "Destreza--":
                    if (ser.Destreza.Pontos > 0 && ser.Destreza.Pontos != 1)
                        return true;
                    else
                        return false;

                case "Intelecto++":
                    if (ser.Intelecto.Pontos < 110)
                        return true;
                    else
                        return false;

                case "Intelecto--":
                    if (ser.Intelecto.Pontos > 0 && ser.Intelecto.Pontos != 1)
                        return true;
                    else
                        return false;

                case "Criatividade++":
                    if (ser.Criatividade.Pontos < 110)
                        return true;
                    else
                        return false;

                case "Criatividade--":
                    if (ser.Criatividade.Pontos > 0 && ser.Criatividade.Pontos != 1)
                        return true;
                    else
                        return false;

                case "Ideia++":
                    if (ser.Ideia.Pontos < 110)
                        return true;
                    else
                        return false;

                case "Ideia--":
                    if (ser.Ideia.Pontos > 0 && ser.Ideia.Pontos != 1)
                        return true;
                    else
                        return false;

                case "Existencia++":
                    if (ser.Existencia.Pontos < 110)
                        return true;
                    else
                        return false;

                case "Existencia--":
                    if (ser.Existencia.Pontos > 0 && ser.Existencia.Pontos != 1)
                        return true;
                    else
                        return false;

                default:
                    return false;
            }
        }

        private void criaComandos()
        {
            CmdAlteraAtributo = new RelayCommand<string>((s) => alteraAtributo(s), (s) => validaAlterarAtributo(s));
            CmdSerAleatorio = new RelayCommand(geraSerAleatorio);
        }

        private int calculaFontSizeAtributo(int tamanhoString)
        {
            return fontSizeAtributos - ((tamanhoString - tamanhoMaximoStringAtributos) * multiplicadorFontSizeAtributos);
        }

        private int calculaFontSizeSubAtributo(int tamanhoString)
        {
            return fontSizeSubatributos - ((tamanhoString - tamanhoMaximoStringAtributos) * multiplicadorFontSizeSubatributos);
        }

        private void consultaAtributos()
        {
            ser.Forca = dbConsultas.RetornaForca(ser.Forca.Pontos);
            ser.Materia = dbConsultas.RetornaMateria(ser.Materia.Pontos);
            ser.Destreza = dbConsultas.RetornaDestreza(ser.Destreza.Pontos);
            ser.Intelecto = dbConsultas.RetornaIntelecto(ser.Intelecto.Pontos);
            ser.Criatividade = dbConsultas.RetornaCriatividade(ser.Criatividade.Pontos);
            ser.Existencia = dbConsultas.RetornaExistencia(ser.Existencia.Pontos);
            ser.Ideia = dbConsultas.RetornaIdeia(ser.Ideia.Pontos);
            atualizaPersonagem();
        }

        private void cmb_aleatorio_Click(object sender, RoutedEventArgs e)
        {
            geraSerAleatorio();
        }

        private void atualizaPersonagem()
        {
            ser = calculadorSer.CalculaSer(ser);
            Personagem = ser;
        }

        private void geraSerAleatorio()
        {
            GeradorSer gerador = new GeradorSer();
            GeradorInteiro rng = new GeradorInteiro();
            Random rnd = new Random();

            ser = gerador.Gerar(rnd);

            ser.Forca = dbConsultas.RetornaForca(ser.Forca.Pontos);
            ser.Materia = dbConsultas.RetornaMateria(ser.Forca.Pontos);
            ser.Destreza = dbConsultas.RetornaDestreza(ser.Destreza.Pontos);
            ser.Intelecto = dbConsultas.RetornaIntelecto(ser.Intelecto.Pontos);
            ser.Criatividade = dbConsultas.RetornaCriatividade(ser.Criatividade.Pontos);
            ser.Existencia = dbConsultas.RetornaExistencia(ser.Existencia.Pontos);
            ser.Ideia = dbConsultas.RetornaIdeia(ser.Ideia.Pontos);

            Personagem = ser;
        }

        
    }
}
