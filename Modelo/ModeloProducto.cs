using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloProducto
    {
        Controlador.DatosProducto metodos = new Controlador.DatosProducto();

        public bool IngresarProducto(Producto p)
        {

            Controlador.Producto nuevo = new Controlador.Producto
            {

                Nombre_Producto = p.Nombre_Producto,
                Cantidad=p.Cantidad,
                id_Categoria=p.id_Categoria,
                Precio=p.Precio



            };

            return metodos.IngresarProducto(nuevo);

        }

        public Controlador.Producto BuscarProducto(string RutProducto)
        {
            Controlador.Producto p = metodos.BuscarProducto(RutProducto);
            return p;
        }

        public bool EliminarProducto(string RutProducto)
        {
            return metodos.EliminarProducto(RutProducto);
        }

        public List<Controlador.Producto> ListarProducto()
        {
            return metodos.ListarProductos();
        }

        
    }
}
