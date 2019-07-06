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
    /// Lógica de interacción para Inventario.xaml
    /// </summary>
    public partial class Inventario : Window
    {
        Modelo.ModeloProducto producto = new Modelo.ModeloProducto();
        Modelo.ModeloCategoria categoria = new Modelo.ModeloCategoria();
        Modelo.ModeloDetalleCompra detalleCompra = new Modelo.ModeloDetalleCompra();

        MainWindow ventana1;
        RegistrarProducto registrarProducto;
        public Inventario()
        {
            InitializeComponent();

            var lista = (from p in producto.ListarProducto()
                         from c in categoria.ListarCategoria()
                         
                         where p.id_Categoria==c.id_Categoria
                         

                         select new
                         {
                             p.Nombre_Producto,
                             p.Cantidad,
                             c.Nombre_Categoria,
                             p.Precio,
                             


                         });

            ProductosGrid.ItemsSource = lista;

        }

        private void MenuPrincipalClick(object sender, RoutedEventArgs e)
        {
            ventana1 = new MainWindow();
            ventana1.Show();
            this.Close();
        }
        private void RegistrarProductoClick(object sender, RoutedEventArgs e)
        {
            registrarProducto= new RegistrarProducto();
            registrarProducto.Show();
            this.Close();
        }
    }
}
