using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Desire.Data;
using Desire.Core;
using Desire.Core.Identidade;
using Desire.Data.Operacoes;
using Desire.Core.Util;
using System.ComponentModel;
using Desire.Core.Util.Geradores;

namespace Desire.WinApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private Ser ser;
        public Ser Personagem
        {
            get{ return ser; }
            set
            {
                ser = value;
                NotifyPropertyChanged("Personagem");
            }
        }

        private int pontosGastos;
        public int PontosGastos
        {
            get { return ser.Forca.Pontos + ser.Materia.Pontos + ser.Destreza.Pontos + ser.Criatividade.Pontos + ser.Existencia.Pontos + ser.Ideia.Pontos + ser.Intelecto.Pontos; }
            set
            {
                pontosGastos = value;
                NotifyPropertyChanged("PontosGastos");
            }
        }

        private DbConsultas dbConsultas;
        private CalculadorSer calculadorSer;

        private int tamanhoMaximoStringAtributos = 4;
        private int tamanhoMaximoStringSubatributos = 5;


        public MainWindow()
        {
            dbConsultas = new DbConsultas();
            calculadorSer = new CalculadorSer();
            InitializeComponent();
            this.DataContext = this;
            geraSerAleatorio();
            atualizaSer();
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void cmb_forca_pts_mais_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Forca.Pontos < 110)
            {
                ser.Forca.Pontos++;
                NotifyPropertyChanged("PontosGastos");
                ser.Forca = dbConsultas.RetornaForca(ser.Forca.Pontos);
                ser = calculadorSer.CalculaSubatributos(ser);
                atualizaSer();
            }
        }

        private void cmb_forca_pts_menos_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Forca.Pontos > 1)
            { 
                ser.Forca.Pontos--;
                NotifyPropertyChanged("PontosGastos");
                ser.Forca = dbConsultas.RetornaForca(ser.Forca.Pontos);
                ser = calculadorSer.CalculaSubatributos(ser);
                atualizaSer();
            }
        }

        private void cmb_materia_pts_mais_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Materia.Pontos < 110)
            {
                ser.Materia.Pontos++;
                NotifyPropertyChanged("PontosGastos");
                ser.Materia = dbConsultas.RetornaMateria(ser.Materia.Pontos);
                ser = calculadorSer.CalculaSubatributos(ser);
                atualizaSer();
            }
        }

        private void cmb_materia_pts_menos_Click(object sender, RoutedEventArgs e)
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

        private void cmb_destreza_pts_mais_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Destreza.Pontos < 110)
            {
                ser.Destreza.Pontos++;
                NotifyPropertyChanged("PontosGastos");
                ser.Destreza = dbConsultas.RetornaDestreza(ser.Destreza.Pontos);
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

        private void cmb_intelecto_pts_mais_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Intelecto.Pontos < 110)
            {
                ser.Intelecto.Pontos++;
                NotifyPropertyChanged("PontosGastos");
                ser.Intelecto = dbConsultas.RetornaIntelecto(ser.Intelecto.Pontos);
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

        private void cmb_criatividade_pts_mais_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Criatividade.Pontos < 110)
            {
                ser.Criatividade.Pontos++;
                NotifyPropertyChanged("PontosGastos");
                ser.Criatividade = dbConsultas.RetornaCriatividade(ser.Criatividade.Pontos);
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

        private void cmb_existencia_pts_mais_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Existencia.Pontos < 110)
            {
                ser.Existencia.Pontos++;
                NotifyPropertyChanged("PontosGastos");
                ser.Existencia = dbConsultas.RetornaExistencia(ser.Existencia.Pontos);
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

        private void cmb_ideia_pts_mais_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Ideia.Pontos < 110)
            {
                ser.Ideia.Pontos++;
                NotifyPropertyChanged("PontosGastos");
                ser.Ideia = dbConsultas.RetornaIdeia(ser.Ideia.Pontos);
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
            validaTamanhoLabelsAtributos();
            validaTamanhoLabelsSubatributos();
            Personagem = ser;
        }

        private void geraSerAleatorio()
        {
            GeradorSer gerador = new GeradorSer();
            GeradorInteiro rng = new GeradorInteiro();
            Random rnd = new Random();

            ser = gerador.Gerar(rnd);

            ser.Forca = dbConsultas.RetornaForca(rng.GerarEntre(1, 110, rnd));
            ser.Materia = dbConsultas.RetornaMateria(rng.GerarEntre(1, 110, rnd));
            ser.Destreza = dbConsultas.RetornaDestreza(rng.GerarEntre(1, 110, rnd));
            ser.Intelecto = dbConsultas.RetornaIntelecto(rng.GerarEntre(1, 110, rnd));
            ser.Criatividade = dbConsultas.RetornaCriatividade(rng.GerarEntre(1, 110, rnd));
            ser.Existencia = dbConsultas.RetornaExistencia(rng.GerarEntre(1, 110, rnd));
            ser.Ideia = dbConsultas.RetornaIdeia(rng.GerarEntre(1, 110, rnd));

            ser = calculadorSer.CalculaSubatributos(ser);
            lbl_rei_valor.Content = ser.Reis.Count();
            NotifyPropertyChanged("PontosGastos");
            atualizaSer();
        }

        private void validaTamanhoLabelsAtributos()
        {
            if (ser.Destreza.Dinamica.ToString().Count() > tamanhoMaximoStringAtributos)
                lbl_destreza_dinamica_vl.FontSize = 24 - ((ser.Destreza.Dinamica.ToString().Count() - tamanhoMaximoStringAtributos) * 2);
            else
                lbl_destreza_dinamica_vl.FontSize = 24;

            if (ser.Destreza.Iniciativa.ToString().Count() > tamanhoMaximoStringAtributos)
                lbl_destreza_iniciativa_vl.FontSize = 24 - ((ser.Destreza.Iniciativa.ToString().Count() - tamanhoMaximoStringAtributos) * 2);
            else
                lbl_destreza_iniciativa_vl.FontSize = 24;

            if (ser.Existencia.Plano.ToString().Count() > tamanhoMaximoStringAtributos)
                lbl_existencia_plano_vl.FontSize = 24 - ((ser.Existencia.Plano.ToString().Count() - tamanhoMaximoStringAtributos) * 2);
            else
                lbl_existencia_plano_vl.FontSize = 24;

            if (ser.Ideia.Ki.ToString().Count() > tamanhoMaximoStringAtributos)
                lbl_ideia_ki_vl.FontSize = 24 - ((ser.Ideia.Ki.ToString().Count() - tamanhoMaximoStringAtributos) * 2);
            else
                lbl_ideia_ki_vl.FontSize = 24;

            if (ser.Ideia.Base.ToString().Count() > tamanhoMaximoStringAtributos)
                lbl_ideia_base_vl.FontSize = 24 - ((ser.Ideia.Base.ToString().Count() - tamanhoMaximoStringAtributos) * 2);
            else
                lbl_ideia_base_vl.FontSize = 24;
        }

        private void validaTamanhoLabelsSubatributos()
        {
            if (ser.BonusAP.ToString().Count() > tamanhoMaximoStringSubatributos)
                lbl_apbonus_vl.FontSize = 22 - ((ser.BonusAP.ToString().Count() - tamanhoMaximoStringSubatributos) * 3);
            else
                lbl_apbonus_vl.FontSize = 22;

            if (ser.BonusSP.ToString().Count() > tamanhoMaximoStringSubatributos)
                lbl_spbonus_vl.FontSize = 22 - ((ser.BonusSP.ToString().Count() - tamanhoMaximoStringSubatributos) * 3);
            else
                lbl_spbonus_vl.FontSize = 22;

            if (ser.Iniciativa.ToString().Count() > tamanhoMaximoStringSubatributos)
                lbl_iniciativa_vl.FontSize = 22 - ((ser.Iniciativa.ToString().Count() - tamanhoMaximoStringSubatributos) * 3);
            else
                lbl_iniciativa_vl.FontSize = 22;

            if (ser.Turno.ToString().Count() > tamanhoMaximoStringSubatributos)
                lbl_turno_vl.FontSize = 22 - ((ser.Turno.ToString().Count() - tamanhoMaximoStringSubatributos) * 3);
            else
                lbl_turno_vl.FontSize = 22;

            if (ser.Destria.ToString().Count() > tamanhoMaximoStringSubatributos)
                lbl_destria_vl.FontSize = 22 - ((ser.Destria.ToString().Count() - tamanhoMaximoStringSubatributos) * 3);
            else
                lbl_destria_vl.FontSize = 22;

        }
    }
}
