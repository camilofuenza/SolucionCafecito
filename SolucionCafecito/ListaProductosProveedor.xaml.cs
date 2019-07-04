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
    /// Lógica de interacción para ListaProductosProveedor.xaml
    /// </summary>
    public partial class ListaProductosProveedor : Window
    {
        Modelo.ModeloCompra compra = new Modelo.ModeloCompra();
        Modelo.ModeloDetalleCompra detalleCompra = new Modelo.ModeloDetalleCompra();

        public ListaProductosProveedor(string nombre_proveedor,int id_proveedor)
        {
            InitializeComponent();

            NombreProveedor.Text = "Nombre Proveedor: "+nombre_proveedor;
           var lista = (from c in compra.ListarCompras()
                         from dc in detalleCompra.ListarDetallesCompras()
                         where c.Nro_Factura == dc.Nro_Factura && c.id_Proveedor == id_proveedor

                         select new
                         {
                             dc.Nro_Factura,
                             dc.Nombre_Producto,
                             dc.Cantidad,
                             dc.Precio,
                             dc.Validacion,
                             c.Fecha,
                             c.Total

                         });

            ProductoProveedorGrid.ItemsSource = lista;
            


        }
    }
}
