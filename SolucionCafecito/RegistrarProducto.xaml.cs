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

            var lista = (from a in metodoCategoria.ListarCategoria()
                         select new
                         {
                             a.Nombre_Categoria,
                             a.id_Categoria

                         });


            
            foreach (var item in lista)
            {
                ComboBoxItem item2 = new ComboBoxItem();
                item2.Content = item.Nombre_Categoria;
                item2.Tag= item.id_Categoria;
                comboCategoria.Items.Add(item2);
                
                
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

            int id_Categoria= (int)comboCategoria.SelectedValue;
           producto.id_Categoria = id_Categoria;
          
           
            
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
