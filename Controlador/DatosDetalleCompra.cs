using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class DatosDetalleCompra
    {
        UnCafecitoEntities entity = new UnCafecitoEntities();



        public bool IngresarDetalleCompra(DetalleCompra dc)
        {
            bool res = false;
            
            
                entity.DetalleCompra.Add(dc);

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

        public DetalleCompra BuscarDetalleCompra(int nrofactura)
        {

            DetalleCompra dc = entity.DetalleCompra.FirstOrDefault(a => a.Nro_Factura==nrofactura);
            if (dc != null)
            {
                return dc;
            }
            else
            {
                return null;
            }

        }
        
        public bool ModificarDetalleCompra(DetalleCompra dc)
        {

            DetalleCompra detalleCompra = entity.DetalleCompra.FirstOrDefault(a => a.Nro_Factura == dc.Nro_Factura);
            if (detalleCompra != null)
            {
                detalleCompra.Cantidad = dc.Cantidad;
                detalleCompra.Comentario = dc.Comentario;
                detalleCompra.Precio = dc.Precio;
                detalleCompra.Validacion = dc.Validacion;
                detalleCompra.Nombre_Producto = dc.Nombre_Producto;

                entity.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }

        }
        public List<DetalleCompra> ListarDetallesCompra()
        {
            var lista = (from con in entity.DetalleCompra select con).ToList();
            return lista;
        }
    }
}
