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
    /// Lógica de interacción para RegistrarVenta.xaml
    /// </summary>
    public partial class RegistrarVenta : Window
    {
        MainWindow ventana1;
        RegistrarVenta ventana2;
        ListarVentas ventana3;

        Modelo.ModeloVenta ventas = new Modelo.ModeloVenta();
        Modelo.ModeloProducto productos = new Modelo.ModeloProducto();
        Modelo.ModeloVendedor vendedores = new Modelo.ModeloVendedor();
        Modelo.ModeloDetalleVenta detalleVenta = new Modelo.ModeloDetalleVenta();

        Modelo.Venta venta = new Modelo.Venta();
        Modelo.DetalleVenta dv = new Modelo.DetalleVenta();

       double totalporproducto;
        double cantidadComprada;
        double precioUnitarioUnidad;
        double unidadescontenidas;
        double oldvalueforTotal;

        public RegistrarVenta()
        {
            InitializeComponent();

            var listavendedores = (from c in vendedores.ListarVendedor()

                                  select new
                                  {
                                      c.Nombre,
                                      c.Rut
                                  });

            foreach (var item in listavendedores)
            {
                ComboBoxItem item2 = new ComboBoxItem();
                item2.Content = item.Nombre;
                item2.Tag = item.Rut;
                comboVendedor.Items.Add(item2);

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            venta.Nro_Boleta = int.Parse(txtNroBoleta.Text.ToString());
            venta.FechaVenta = Convert.ToDateTime(dtpFechaVenta.SelectedDate);
            string rutVendedor = comboVendedor.SelectedValue.ToString();
            venta.RutVendedor = rutVendedor;
            venta.TotalVenta = 0;
            

            dv.Nro_Boleta= int.Parse(txtNroBoleta.Text.ToString());
            dv.id_DetalleVenta = 0;
            string nombreProducto = comboProducto.SelectedValue.ToString();
            dv.Nombre_Producto = nombreProducto;
            dv.Cantidad = int.Parse(txtCantidadProducto.Text);
            dv.TotalporProducto = int.Parse(txtTotalPorProducto.Text);


            if (rbdEfectivo.IsChecked == true)
            {
                venta.TipoVenta="Efectivo";

            }
            if (rbdTarjeta.IsChecked == true)
            {
                venta.TipoVenta="Tarjeta";
            }




            if (rbdUnidad.IsChecked == true)
            {
                totalporproducto = double.Parse(txtTotalPorProducto.Text);
                cantidadComprada = double.Parse(txtCantidadProducto.Text);
                precioUnitarioUnidad = (totalporproducto / cantidadComprada);
                dv.Precio_unitario = double.Parse(precioUnitarioUnidad.ToString());
                
                
            }

            if (rbdPorMayor.IsChecked == true)
            {

                totalporproducto = double.Parse(txtTotalPorProducto.Text);
                cantidadComprada = double.Parse(txtCantidadProducto.Text);
                unidadescontenidas = double.Parse(txtUnidadesPorMayor.Text);
                precioUnitarioUnidad = (totalporproducto / (cantidadComprada * unidadescontenidas));
                
                dv.Precio_unitario = precioUnitarioUnidad;
            }

            txtTotalNeto.Text = (double.Parse(txtTotalPorProducto.Text) + oldvalueforTotal).ToString();





            if (ventas.BuscarVenta(venta.Nro_Boleta) == null)
            {
                ventas.IngresarVenta(venta);

            }
            else
            {
                ventas.ModificarVenta(venta);
            }



            if (ventas.BuscarVenta(venta.Nro_Boleta) != null)
            {
                if (detalleVenta.IngresarDetalleVenta(dv))
                {
                    //Control de stock, disminuye cantidad de producto
                    Controlador.Producto productocontrolador = productos.BuscarProducto(dv.Nombre_Producto);
                    Modelo.Producto cantidadProducto = new Modelo.Producto();
                    cantidadProducto.Cantidad = Convert.ToInt32(productocontrolador.Cantidad);
                    cantidadProducto.Nombre_Producto = productocontrolador.Nombre_Producto;
                    cantidadProducto.id_Categoria = Convert.ToInt32(productocontrolador.id_Categoria);
                    cantidadProducto.Precio = Convert.ToInt32(productocontrolador.Precio);
                    cantidadProducto.Cantidad = cantidadProducto.Cantidad - Convert.ToInt32(cantidadComprada);
                    productos.ModificarProducto(cantidadProducto);

                    //Setea campos a blanco y añade valor a label
                    txtCantidadProducto.Text = "";
                    txtUnidadesPorMayor.Text = "";
                    lbloldValue.Content = txtTotalNeto.Text.ToString();
                    oldvalueforTotal = double.Parse(lbloldValue.Content.ToString());
                    txtTotalPorProducto.Text = "";


                    MessageBox.Show("Ha ingresado su producto!");
                }
                else
                {
                    MessageBox.Show("Cagaste win");
                }
            }
        }

        private void Iva_Click(object sender, RoutedEventArgs e)
        {
            
            
           
            venta.TotalVenta = int.Parse(txtTotalNeto.Text);
            if (ventas.BuscarVenta(venta.Nro_Boleta) == null)
            {
                ventas.IngresarVenta(venta);
                MessageBox.Show("Ah ingresado una VENTA!");
            }
            else
            {
                ventas.ModificarVenta(venta);
                MessageBox.Show("Cagaste win");
            }
            
        }
    }
}
