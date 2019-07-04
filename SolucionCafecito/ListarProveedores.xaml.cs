using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para ListarProveedores.xaml
    /// </summary>
    public partial class ListarProveedores : Window
    {

        Modelo.ModeloProveedor proveedores = new Modelo.ModeloProveedor();
        
        MainWindow ventana1;
        ListarProveedores ventana2;
        RegistroProveedor ventana3;
        ListaProductosProveedor ventana4;
        RegistrarCompra ventana5;


        public ListarProveedores()
        {
            InitializeComponent();

            var lista = (from c in proveedores.ListarProveedor()

                         select new
                         {
                             c.id_Proveedor,
                             c.NombreProveedor,
                             c.NombreContacto,
                             c.RutProveedor,
                             c.TelefonoContacto

                         });



            ProveedoresGrid.ItemsSource = lista;
            
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
        private void MenuPrincipalClick(object sender, RoutedEventArgs e)
        {
            ventana1 = new MainWindow();
            ventana1.Show();
            this.Close();
        }

        private void RegistrarCompraClick(object sender, RoutedEventArgs e)
        {
            ventana5 = new RegistrarCompra();
            ventana5.Show();
            this.Close();
        }

        private void SeleccionarProveedor(object sender, RoutedEventArgs e)
        {
           

            
            string idprov=(ProveedoresGrid.Columns[0].GetCellContent(ProveedoresGrid.SelectedItem) as TextBlock).Text;
            string nombreprov= (ProveedoresGrid.Columns[1].GetCellContent(ProveedoresGrid.SelectedItem) as TextBlock).Text;
            int id_proveedor = int.Parse(idprov);
            ventana4 = new ListaProductosProveedor(nombreprov,id_proveedor);
            ventana4.Show();
        }

    }
}
