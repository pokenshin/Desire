using Desire.Core.Energias;
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

namespace Desire.WinApp.Controls
{
    /// <summary>
    /// Interaction logic for EnergiaBarList.xaml
    /// </summary>
    public partial class EnergiaBarList : UserControl
    {


        public List<Energia> Energias
        {
            get { return (List<Energia>)GetValue(EnergiasProperty); }
            set
            {
                SetValue(EnergiasProperty, value);

                constroiControles();
            }
        }

        private void constroiControles()
        {
            if (this.Energias.Count > 0)
            { 
                lbl_sigla.Content = this.Energias[0].Sigla;
                lbl_valor.Content = this.Energias[0].Quantidade;
            }
        }

        // Using a DependencyProperty as the backing store for Energias.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnergiasProperty =
            DependencyProperty.Register("Energias", typeof(List<Energia>), typeof(EnergiaBarList));



        public EnergiaBarList()
        {
            InitializeComponent();
        }
    }
}
