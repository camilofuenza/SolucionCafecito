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
    /// Lógica de interacción para RegistroProveedor.xaml
    /// </summary>
    public partial class RegistroProveedor : Window
    {
        Modelo.Proveedor proveedor = new Modelo.Proveedor();
        Modelo.ModeloProveedor modeloProveedor = new Modelo.ModeloProveedor();
        RegistroProveedor ventana3;
        ListarProveedores ventana2;
        MainWindow ventana1;
        RegistrarCompra ventana4;


        public RegistroProveedor()
        {
            InitializeComponent();
        }

        private void btnAgregarProveedor_Click(object sender, RoutedEventArgs e)
        {
            proveedor.id_Proveedor = 0;
            proveedor.NombreProveedor = txtNombreProveedor.Text.ToString();
            proveedor.RutProveedor = txtRutProveedor.Text.ToString();
            proveedor.NombreContacto = txtNombreContacto.Text.ToString();
            proveedor.TelefonoContacto = txtTelefonoContacto.Text.ToString();

            if (modeloProveedor.IngresarProveedor(proveedor))
            {
                MessageBox.Show("EUREKA");
            }
            else
            {
                MessageBox.Show("kagaste win");
            }

        }


        private void ListarProveedoresClick(object sender, RoutedEventArgs e)
        {
            ventana2 = new ListarProveedores();
            ventana2.Show();
            this.Close();
        }

        private void RegistrarProveedoresClick(object sender, RoutedEventArgs e)
        {
            ventana3 = new RegistroProveedor();
            ventana3.Show();
            this.Close();
        }
        private void RegistrarCompraClick(object sender, RoutedEventArgs e)
        {
            ventana4 = new RegistrarCompra();
            ventana4.Show();
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
