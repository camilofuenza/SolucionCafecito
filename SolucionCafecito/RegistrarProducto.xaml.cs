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
    /// Lógica de interacción para RegistrarProducto.xaml
    /// </summary>
    public partial class RegistrarProducto : Window
    {
        MainWindow ventana1;
        RegistrarProducto registrarProducto;
        Inventario inventario;

        Modelo.ModeloProducto metodoProduto = new Modelo.ModeloProducto();
        Modelo.ModeloCategoria metodoCategoria = new Modelo.ModeloCategoria();
        public RegistrarProducto()
        {

            InitializeComponent();

            var lista = (from c in metodoProduto.ListarProducto()
                         from a in metodoCategoria.ListarCategoria()
                         select new
                         {
                             a.Nombre_Categoria
                         });
            foreach (var item in lista)
            {
                comboCategoria.Items.Add(Convert.ToString(item.Nombre_Categoria));
            }

           
        }

        private void MenuPrincipalClick(object sender, RoutedEventArgs e)
        {
            ventana1 = new MainWindow();
            ventana1.Show();
            this.Close();
        }
        private void RegistrarProductoClick(object sender, RoutedEventArgs e)
        {
            registrarProducto = new RegistrarProducto();
            registrarProducto.Show();
            this.Close();
        }
        private void inventarioClick(object sender, RoutedEventArgs e)
        {
            inventario = new Inventario();
            inventario.Show();
            this.Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Modelo.Producto producto = new Modelo.Producto();
            producto.Cantidad = 0;
            producto.Nombre_Producto = txtNombreProducto.Text.ToString();
            producto.Precio = int.Parse(txtPrecioVenta.Text);
         

            if (comboCategoria.SelectedIndex==0)
            {
                producto.id_Categoria = 1;
            }
            if (comboCategoria.SelectedIndex == 1)
            {
                producto.id_Categoria = 2;
            }
            if (comboCategoria.SelectedIndex == 2)
            {
                producto.id_Categoria = 3;
            }
            if (comboCategoria.SelectedIndex == 3)
            {
                producto.id_Categoria = 4;
            }
            if (comboCategoria.SelectedIndex == 4)
            {
                producto.id_Categoria = 5;
            }
            if (comboCategoria.SelectedIndex == 5)
            {
                producto.id_Categoria = 6;
            }
            if (comboCategoria.SelectedIndex == 6)
            {
                producto.id_Categoria = 7;
            }
            if (comboCategoria.SelectedIndex == 7)
            {
                producto.id_Categoria = 1004;
            }
            if (comboCategoria.SelectedIndex == 8)
            {
                producto.id_Categoria = 1005;
            }

            if (metodoProduto.IngresarProducto(producto))
            {
                MessageBox.Show("Ingresaste un Producto correctamente");
            }
            else
            {
                MessageBox.Show("kgaste wimbilimbi");
            }
        }
    }


}
