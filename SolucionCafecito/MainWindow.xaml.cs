using SolucionCafecito;
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

namespace SolucionCafecito
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        ListarProveedores ventana2;
        Inventario ventana5;
        ListarVentas ventana1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ventana2 = new ListarProveedores();
            ventana2.Show();
            this.Close();

            

        }

        private void IrInventario(object sender, RoutedEventArgs e)
        {
            ventana5 = new Inventario();
            ventana5.Show();
            this.Close();



        }
        private void Ventas_Click(object sender, RoutedEventArgs e)
        {
            ventana1 = new ListarVentas();
            ventana1.Show();
            this.Close();



        }
    }
}