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
using System.Windows.Shapes;

namespace SolucionCafecito
{
    /// <summary>
    /// Lógica de interacción para ListarVentas.xaml
    /// </summary>
    /// 
    

    public partial class ListarVentas : Window
    {
        MainWindow ventana1;
        RegistrarVenta ventana2;
        ListarVentas ventana3;
        Modelo.ModeloVenta ventas = new Modelo.ModeloVenta();

        public ListarVentas()
        {
            InitializeComponent();

            var lista = (from c in ventas.ListarVentas()

                         select new
                         {
                             c.Nro_Boleta,
                             c.RutVendedor,
                             c.FechaVenta,
                             c.Total,
                             c.TipoVenta,

                         });



            VentasGrid.ItemsSource = lista;

        }

        private void RegistrarVentasClick(object sender, RoutedEventArgs e)
        {
            ventana2 = new RegistrarVenta();
            ventana2.Show();
            this.Close();
        }

        private void ListarVentasClick(object sender, RoutedEventArgs e)
        {
            ventana3 = new ListarVentas();
            ventana3.Show();
            this.Close();
        }
        private void MenuPrincipalClick(object sender, RoutedEventArgs e)
        {
            ventana1 = new MainWindow();
            ventana1.Show();
            this.Close();
        }
    }
}
