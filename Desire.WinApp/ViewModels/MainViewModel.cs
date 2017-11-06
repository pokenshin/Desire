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
        private int multiplicadorFontSizeAtributos = 2;
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

        public RelayCommand<string> CmdDiminuiAtributo
        {
            get; private set;
        }

        public MainViewModel()
        {
            dbConsultas = new DbConsultas();
            calculadorSer = new CalculadorSer();
            geraSerAleatorio();
            atualizaSer();
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
                    ser.Criatividade.Pontos++;
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
            atualizaSer();
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
            atualizaSer();
        }

        public void CmdDiminuniForca(object sender, RoutedEventArgs e)
        {
            if (ser.Forca.Pontos > 1)
            {

            }
        }

        private void CmdDiminuiMateria(object sender, RoutedEventArgs e)
        {
            if (ser.Materia.Pontos > 1)
            {
                ser.Materia.Pontos--;
                NotifyPropertyChanged("PontosGastos");
                ser.Materia = dbConsultas.RetornaMateria(ser.Materia.Pontos);
                ser = calculadorSer.CalculaSubatributos(ser);
                atualizaSer();
            }
        }

        private void cmb_destreza_pts_menos_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Destreza.Pontos > 1)
            {
                ser.Destreza.Pontos--;
                NotifyPropertyChanged("PontosGastos");
                ser.Destreza = dbConsultas.RetornaDestreza(ser.Destreza.Pontos);
                ser = calculadorSer.CalculaSubatributos(ser);
                atualizaSer();
            }
        }

        private void cmb_intelecto_pts_menos_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Intelecto.Pontos > 1)
            {
                ser.Intelecto.Pontos--;
                NotifyPropertyChanged("PontosGastos");
                ser.Intelecto = dbConsultas.RetornaIntelecto(ser.Intelecto.Pontos);
                ser = calculadorSer.CalculaSubatributos(ser);
                atualizaSer();
            }
        }

        private void cmb_criatividade_pts_menos_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Criatividade.Pontos > 1)
            {
                ser.Criatividade.Pontos--;
                NotifyPropertyChanged("PontosGastos");
                ser.Criatividade = dbConsultas.RetornaCriatividade(ser.Criatividade.Pontos);
                ser = calculadorSer.CalculaSubatributos(ser);
                atualizaSer();
            }
        }

        private void cmb_existencia_pts_menos_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Existencia.Pontos > 1)
            {
                ser.Existencia.Pontos--;
                NotifyPropertyChanged("PontosGastos");
                ser.Existencia = dbConsultas.RetornaExistencia(ser.Existencia.Pontos);
                ser = calculadorSer.CalculaSubatributos(ser);
                atualizaSer();
            }
        }

        private void cmb_ideia_pts_menos_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Ideia.Pontos > 1)
            {
                ser.Ideia.Pontos--;
                NotifyPropertyChanged("PontosGastos");
                ser.Ideia = dbConsultas.RetornaIdeia(ser.Ideia.Pontos);
                ser = calculadorSer.CalculaSubatributos(ser);
                atualizaSer();
            }
        }

        private void cmb_aleatorio_Click(object sender, RoutedEventArgs e)
        {
            geraSerAleatorio();
            atualizaSer();
        }

        private void atualizaSer()
        {
            Personagem = ser;
        }

        private void geraSerAleatorio()
        {
            GeradorSer gerador = new GeradorSer();
            GeradorInteiro rng = new GeradorInteiro();
            Random rnd = new Random();

            ser = gerador.Gerar(rnd);

            ser.Forca = dbConsultas.RetornaForca(rng.GerarEntre(1, 30, rnd));
            ser.Materia = dbConsultas.RetornaMateria(rng.GerarEntre(1, 30, rnd));
            ser.Destreza = dbConsultas.RetornaDestreza(rng.GerarEntre(1, 30, rnd));
            ser.Intelecto = dbConsultas.RetornaIntelecto(rng.GerarEntre(1, 30, rnd));
            ser.Criatividade = dbConsultas.RetornaCriatividade(rng.GerarEntre(1, 30, rnd));
            ser.Existencia = dbConsultas.RetornaExistencia(rng.GerarEntre(1, 30, rnd));
            ser.Ideia = dbConsultas.RetornaIdeia(rng.GerarEntre(1, 30, rnd));

            ser = calculadorSer.CalculaSubatributos(ser);
            NotifyPropertyChanged("ReisCount");
            NotifyPropertyChanged("PontosGastos");
            atualizaSer();
        }

        
    }
}
