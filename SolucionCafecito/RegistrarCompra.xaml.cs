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
    /// Lógica de interacción para RegistrarCompra.xaml
    /// </summary>
    public partial class RegistrarCompra : Window
    {

        MainWindow ventana1;
        ListarProveedores ventana2;
        RegistroProveedor ventana3;
        RegistrarCompra ventana5;

        Modelo.ModeloProveedor proveedores = new Modelo.ModeloProveedor();
        Modelo.ModeloProducto productos = new Modelo.ModeloProducto();
        public RegistrarCompra()
        {
            InitializeComponent();

            var lista = (from c in proveedores.ListarProveedor()

                         select new
                         {
                             c.NombreProveedor,
                             c.id_Proveedor
                         });

            foreach(var item in lista)
            {
                
                
               
                comboProveedor.Items.Add(Convert.ToString(item.NombreProveedor));
                
                comboProveedor.SelectedValuePath = item.id_Proveedor.ToString();
               
            }

            var listaproductos = (from c in productos.ListarProducto()

                         select new
                         {
                             c.Nombre_Producto
                         });

            foreach (var item in listaproductos)
            {
                comboProducto.Items.Add(Convert.ToString(item.Nombre_Producto));
                comboProveedor.SelectedValuePath = item.Nombre_Producto.ToString();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Modelo.Compra compra = new Modelo.Compra();
            Modelo.DetalleCompra dc = new Modelo.DetalleCompra();

            compra.Nro_Factura = int.Parse(txtFactura.Text);
            compra.Fecha = Convert.ToDateTime(dtpFechaCompra.SelectedDate);
            compra.Total = 0;
            compra.id_Proveedor = int.Parse(comboProveedor.SelectedValuePath);

            dc.Nro_Factura = int.Parse(txtFactura.Text);
            dc.Nombre_Producto = comboProducto.SelectedValuePath;
            dc.Cantidad = int.Parse(txtCantidadProducto.Text);
            dc.Precio = int.Parse(txtTotalPorProducto.Text);


            
        }
    }
}
