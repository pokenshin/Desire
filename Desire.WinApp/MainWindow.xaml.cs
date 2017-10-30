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
using Desire.Data;
using System.Data.SQLite;
    
namespace Desire.WinApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ser ser;

        public MainWindow()
        {
            InitializeComponent();
            //Instancia novo ser e inicializa componentes de UI
            //InicializaSer();
       }

        private void InicializaSer()
        {
            ser = new Ser();
        }

        private void cmb_forca_pts_mais_Click(object sender, RoutedEventArgs e)
        {
            

            //using (var db = new DesireSQLiteContext(optionsBuilder.Options))
            //{
            //    Forca atributo = new Forca()
            //    {
            //        Pontos = 1,
            //        Classe = 'P',
            //        Nivel = 1,
            //        BonusAP = new ValorMag(),
            //        Dureza = new ValorMag(),
            //        Evolucao = new Evolucao(),
            //        Golpe = new ValorMag(),
            //        Porcentagem = new ValorMag(),
            //        Potencia = new ValorMag(),
            //        Sustentacao = new ValorMag(),
            //        Vigor = new ValorMag()
            //    };
            //    db.TabelaForca.Add(atributo);
            //    db.SaveChanges();
            //}
        }
    }
}
