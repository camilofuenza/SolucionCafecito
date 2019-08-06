using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class DatosDetalleVenta
    {
        UnCafecitoEntities entity = new UnCafecitoEntities();



        public bool IngresarDetalleVenta(DetalleVenta dc)
        {
            bool res = false;


            entity.DetalleVenta.Add(dc);

            try
            {
                entity.SaveChanges();
                res = true;

            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex);
            }




            return res;
        }

        public DetalleVenta BuscarDetalleVenta(int nroboleta)
        {

            DetalleVenta dc = entity.DetalleVenta.FirstOrDefault(a => a.Nro_Boleta == nroboleta);
            if (dc != null)
            {
                return dc;
            }
            else
            {
                return null;
            }

        }

        public bool ModificarDetalleVenta(DetalleVenta dc)
        {

            DetalleVenta DetalleVenta = entity.DetalleVenta.FirstOrDefault(a => a.Nro_Boleta == dc.Nro_Boleta);
            if (DetalleVenta != null)
            {
                DetalleVenta.Nombre_Producto = dc.Nombre_Producto;
                DetalleVenta.Cantidad = dc.Cantidad;
                DetalleVenta.TotalporProducto = dc.TotalporProducto;
                

                entity.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }

        }
        public List<DetalleVenta> ListarDetallesCompra()
        {
            var lista = (from con in entity.DetalleVenta select con).ToList();
            return lista;
        }
    }
}
