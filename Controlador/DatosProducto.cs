using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class DatosProducto
    {

        UnCafecitoEntities entity = new UnCafecitoEntities();


        public bool IngresarProducto(Producto p)
        {
            bool res = false;

            if (BuscarProducto(p.Nombre_Producto) == null)
            {
                entity.Producto.Add(p);

                try
                {
                    entity.SaveChanges();
                    res = true;

                }
                catch (DbEntityValidationException ex)
                {
                    Console.WriteLine(ex);
                }

            }


            return res;
        }


       

        public Producto BuscarProducto(string nombreProducto)
        {

            Producto p = entity.Producto.FirstOrDefault(a => a.Nombre_Producto.Equals(nombreProducto));
            if (p != null)
            {
                return p;
            }
            else
            {
                return null;
            }

        }

        public bool EliminarProducto(string nombreProducto)
        {
            bool res = false;

            Producto p = BuscarProducto(nombreProducto);

            if (p != null)
            {
                foreach (var item in entity.Producto)
                {
                    if (item.Nombre_Producto == p.Nombre_Producto)
                    {
                        entity.Producto.Remove(item);
                    }
                }

                entity.Producto.Remove(p);

                if (entity.SaveChanges() > 0)
                {
                    res = true;
                }
            }

            return res;
        }


        public bool ModificarProducto(Producto p)
        {

            Producto producto = entity.Producto.FirstOrDefault(a => a.Nombre_Producto.Equals(p.Nombre_Producto));
            if (producto != null)
            {
                producto.Cantidad = p.Cantidad;
                producto.id_Categoria = p.id_Categoria;
                producto.Precio = p.Precio;


                entity.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }

        }

        public List<Producto> ListarProductos()
        {
            var lista = (from con in entity.Producto select con).ToList();
            return lista;
        }

      
    }
}
