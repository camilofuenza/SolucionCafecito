using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloDetalleCompra
    {
        Controlador.DatosDetalleCompra metodos = new Controlador.DatosDetalleCompra();

        public bool IngresarDetalleCompra(DetalleCompra dc)
        {

            Controlador.DetalleCompra nuevo = new Controlador.DetalleCompra
            {

                Nro_Factura = dc.Nro_Factura,
                Nombre_Producto = dc.Nombre_Producto,
                id_detalleCompra = dc.id_detalleCompra,
                Precio = dc.Precio,
                Validacion = dc.Validacion,
                Comentario=dc.Comentario,
                Cantidad=dc.Cantidad,
                precio_Unitario=dc.valorUnitario,
                tipoCompra=dc.tipoCompra



            };

            return metodos.IngresarDetalleCompra(nuevo);

        }

        public Controlador.DetalleCompra BuscarDetalleCompra(int nrofactura)
        {
            Controlador.DetalleCompra p = metodos.BuscarDetalleCompra(nrofactura);
            return p;
        }
        public List<Controlador.DetalleCompra> ListarDetallesCompras()
        {
            return (metodos.ListarDetallesCompra());
        }

        public bool ModificarDetalle(DetalleCompra dc)
        {
            Controlador.DetalleCompra nuevo = new Controlador.DetalleCompra
            {

                Nro_Factura = dc.Nro_Factura,
                Nombre_Producto = dc.Nombre_Producto,
                id_detalleCompra = dc.id_detalleCompra,
                Precio = dc.Precio,
                Validacion = dc.Validacion,
                Comentario = dc.Comentario,
                Cantidad = dc.Cantidad,
                precio_Unitario=dc.valorUnitario,
                tipoCompra=dc.tipoCompra



            };

            return metodos.ModificarDetalleCompra(nuevo);
        }
    }
}
