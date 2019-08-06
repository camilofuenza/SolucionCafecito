using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloDetalleVenta
    {
        Controlador.DatosDetalleVenta metodos = new Controlador.DatosDetalleVenta();

        public bool IngresarDetalleVenta(DetalleVenta dc)
        {

            Controlador.DetalleVenta nuevo = new Controlador.DetalleVenta
            {

                Nro_Boleta = dc.Nro_Boleta,
                Nombre_Producto = dc.Nombre_Producto,
                id_DetalleVenta = dc.id_DetalleVenta,
                Cantidad = dc.Cantidad,
                TotalporProducto = dc.TotalporProducto,
                Precio_unitario=dc.Precio_unitario



            };

            return metodos.IngresarDetalleVenta(nuevo);

        }

        public Controlador.DetalleVenta BuscarDetalleVenta(int nrofactura)
        {
            Controlador.DetalleVenta p = metodos.BuscarDetalleVenta(nrofactura);
            return p;
        }
        public List<Controlador.DetalleVenta> ListarDetallesCompras()
        {
            return (metodos.ListarDetallesCompra());
        }

        public bool ModificarDetalle(DetalleVenta dc)
        {
            Controlador.DetalleVenta nuevo = new Controlador.DetalleVenta
            {

                Nro_Boleta = dc.Nro_Boleta,
                Nombre_Producto = dc.Nombre_Producto,
                id_DetalleVenta = dc.id_DetalleVenta,
                Cantidad = dc.Cantidad,
                TotalporProducto = dc.TotalporProducto,
                Precio_unitario=dc.Precio_unitario



            };

            return metodos.ModificarDetalleVenta(nuevo);
        }
    }
}
