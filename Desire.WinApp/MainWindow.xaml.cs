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
using System.ComponentModel;

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

        private DbConsultas dbConsultas;

        public MainWindow()
        {
            Personagem = new Ser();
            dbConsultas = new DbConsultas();
            consultaAtributos();
            InitializeComponent();
            this.DataContext = this;
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
            Personagem = ser;
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
                ser.Forca = dbConsultas.RetornaForca(ser.Forca.Pontos);
                Personagem = ser;
            }
        }

        private void cmb_forca_pts_menos_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Forca.Pontos > 1)
            { 
                ser.Forca.Pontos--;
                ser.Forca = dbConsultas.RetornaForca(ser.Forca.Pontos);
                Personagem = ser;
            }
        }

        private void cmb_materia_pts_mais_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Materia.Pontos < 110)
            {
                ser.Materia.Pontos++;
                ser.Materia = dbConsultas.RetornaMateria(ser.Materia.Pontos);
                Personagem = ser;
            }
        }

        private void cmb_materia_pts_menos_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Materia.Pontos > 1)
            {
                ser.Materia.Pontos--;
                ser.Materia = dbConsultas.RetornaMateria(ser.Materia.Pontos);
                Personagem = ser;
            }
        }

        private void cmb_destreza_pts_mais_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Destreza.Pontos < 110)
            {
                ser.Destreza.Pontos++;
                ser.Destreza = dbConsultas.RetornaDestreza(ser.Destreza.Pontos);
                Personagem = ser;
            }
        }

        private void cmb_destreza_pts_menos_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Destreza.Pontos > 1)
            {
                ser.Destreza.Pontos--;
                ser.Destreza = dbConsultas.RetornaDestreza(ser.Destreza.Pontos);
                Personagem = ser;
            }
        }

        private void cmb_intelecto_pts_mais_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Intelecto.Pontos < 110)
            {
                ser.Intelecto.Pontos++;
                ser.Intelecto = dbConsultas.RetornaIntelecto(ser.Intelecto.Pontos);
                Personagem = ser;
            }
        }

        private void cmb_intelecto_pts_menos_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Intelecto.Pontos > 1)
            {
                ser.Intelecto.Pontos--;
                ser.Intelecto = dbConsultas.RetornaIntelecto(ser.Intelecto.Pontos);
                Personagem = ser;
            }
        }

        private void cmb_criatividade_pts_mais_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Criatividade.Pontos < 110)
            {
                ser.Criatividade.Pontos++;
                ser.Criatividade = dbConsultas.RetornaCriatividade(ser.Criatividade.Pontos);
                Personagem = ser;
            }
        }

        private void cmb_criatividade_pts_menos_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Criatividade.Pontos > 1)
            {
                ser.Criatividade.Pontos--;
                ser.Criatividade = dbConsultas.RetornaCriatividade(ser.Criatividade.Pontos);
                Personagem = ser;
            }
        }

        private void cmb_existencia_pts_mais_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Existencia.Pontos < 110)
            {
                ser.Existencia.Pontos++;
                ser.Existencia = dbConsultas.RetornaExistencia(ser.Existencia.Pontos);
                Personagem = ser;
            }
        }

        private void cmb_existencia_pts_menos_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Existencia.Pontos > 1)
            {
                ser.Existencia.Pontos--;
                ser.Existencia = dbConsultas.RetornaExistencia(ser.Existencia.Pontos);
                Personagem = ser;
            }
        }

        private void cmb_ideia_pts_mais_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Ideia.Pontos < 110)
            {
                ser.Ideia.Pontos++;
                ser.Ideia = dbConsultas.RetornaIdeia(ser.Ideia.Pontos);
                Personagem = ser;
            }
        }

        private void cmb_ideia_pts_menos_Click(object sender, RoutedEventArgs e)
        {
            if (ser.Ideia.Pontos > 1)
            {
                ser.Ideia.Pontos--;
                ser.Ideia = dbConsultas.RetornaIdeia(ser.Ideia.Pontos);
                Personagem = ser;
            }
        }
    }
}
