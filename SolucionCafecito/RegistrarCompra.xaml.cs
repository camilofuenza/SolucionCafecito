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
        Modelo.ModeloCompra compras = new Modelo.ModeloCompra();
        Modelo.ModeloDetalleCompra detalleCompra = new Modelo.ModeloDetalleCompra();
        

        Modelo.Compra compra = new Modelo.Compra();
        Modelo.DetalleCompra dc = new Modelo.DetalleCompra();

        double totalporproducto;
        double cantidadComprada;
        double precioUnitarioUnidad;
        double unidadescontenidas;
        double calculoIva;
        double oldvalueforTotal;

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

                ComboBoxItem item2 = new ComboBoxItem();
                item2.Content = item.NombreProveedor;
                item2.Tag = item.id_Proveedor;
                comboProveedor.Items.Add(item2);

               
            }

            var listaproductos = (from c in productos.ListarProducto()

                         select new
                         {
                             c.Nombre_Producto
                         });

            foreach (var item in listaproductos)
            {
                ComboBoxItem item2 = new ComboBoxItem();
                item2.Content = item.Nombre_Producto;
                item2.Tag = item.Nombre_Producto;
                comboProducto.Items.Add(item2);
                
            }

            
            lbloldValue.Content = 0;
            oldvalueforTotal = 0;
            txtUnidadesPorMayor.IsEnabled = false;
            lbloldValue.Visibility = Visibility.Hidden;
             
           
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

        private void PorMayorChecked(object sender, RoutedEventArgs e)
        {
            txtUnidadesPorMayor.IsEnabled=Convert.ToBoolean(rbdPorMayor.IsChecked);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            

            compra.Nro_Factura = int.Parse(txtFactura.Text.ToString());
            compra.Fecha = Convert.ToDateTime(dtpFechaCompra.SelectedDate);
            int id_Proveedor = (int)comboProveedor.SelectedValue;
            compra.id_Proveedor = id_Proveedor;
            compra.Total = 0;

            dc.Nro_Factura = compra.Nro_Factura;
            string Nombre_Producto= (string)comboProducto.SelectedValue;
            dc.Nombre_Producto = Nombre_Producto.Trim();
            dc.Cantidad = int.Parse(txtCantidadProducto.Text.ToString());
            dc.Precio = int.Parse(txtTotalPorProducto.Text.ToString());

            if (rdbSi.IsChecked==true)
            {
                dc.Validacion = "Si";

            }
            if (rdbNo.IsChecked == true)
            {
                dc.Validacion = "No";
            }
            dc.Comentario = txtComentario.Text.ToString();

            

            if (rdbUnidad.IsChecked == true)
            {
                totalporproducto = double.Parse(txtTotalPorProducto.Text);
                cantidadComprada = double.Parse(txtCantidadProducto.Text);
                precioUnitarioUnidad = (totalporproducto / cantidadComprada);
                txtValorUnitario.Text = precioUnitarioUnidad.ToString();
                dc.valorUnitario = precioUnitarioUnidad;
            }

            if (rbdPorMayor.IsChecked == true)
            {
                
                totalporproducto = double.Parse(txtTotalPorProducto.Text);
                cantidadComprada = double.Parse(txtCantidadProducto.Text);
                unidadescontenidas = double.Parse(txtUnidadesPorMayor.Text);
                precioUnitarioUnidad = (totalporproducto / (cantidadComprada*unidadescontenidas));
                txtValorUnitario.Text = precioUnitarioUnidad.ToString();
                dc.valorUnitario = precioUnitarioUnidad;
            }

            txtTotalNeto.Text= (double.Parse(txtTotalPorProducto.Text) + oldvalueforTotal).ToString();
            



            
            if (compras.BuscarCompra(compra.Nro_Factura) == null)
            {
                compras.IngresarCompra(compra);

            }
            else
            {
                compras.ModificarCompra(compra);
            }
           
            
            
                if (compras.BuscarCompra(compra.Nro_Factura)!=null)
                {
                    if (detalleCompra.IngresarDetalleCompra(dc))
                    {
                    //Control de stock, aumenta cantidad de producto
                    Controlador.Producto productocontrolador= productos.BuscarProducto(dc.Nombre_Producto);
                    Modelo.Producto cantidadProducto= new Modelo.Producto();
                    cantidadProducto.Cantidad= Convert.ToInt32(productocontrolador.Cantidad);
                    cantidadProducto.Nombre_Producto = productocontrolador.Nombre_Producto;
                    cantidadProducto.id_Categoria = Convert.ToInt32(productocontrolador.id_Categoria);
                    cantidadProducto.Precio = Convert.ToInt32(productocontrolador.Precio);
                    cantidadProducto.Cantidad=cantidadProducto.Cantidad + Convert.ToInt32(cantidadComprada);
                    productos.ModificarProducto(cantidadProducto);

                    //Setea campos a blanco y añade valor a label
                    txtCantidadProducto.Text = "";
                    txtComentario.Text = "";
                    lbloldValue.Content = txtTotalNeto.Text.ToString();
                    oldvalueforTotal = double.Parse(lbloldValue.Content.ToString());
                    txtTotalPorProducto.Text = "";
                    
                        
                        MessageBox.Show("Su compra se ha agregado exitosamente!");
                    }
                    else
                    {
                        MessageBox.Show("Cagaste win");
                    }
                }
        }

        private void Iva_Click(object sender, RoutedEventArgs e)
        {
            calculoIva = double.Parse(txtTotalNeto.Text) * 0.19;
            txtIva.Text = (calculoIva).ToString();
            txtTotalFactura.Text = (calculoIva + double.Parse(txtTotalNeto.Text)).ToString();
            compra.Total = double.Parse(txtTotalFactura.Text);
            if (compras.BuscarCompra(compra.Nro_Factura) == null)
            {
                compras.IngresarCompra(compra);

            }
            else
            {
                compras.ModificarCompra(compra);
            }
            
        }
    }
}
