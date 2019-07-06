using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloCompra
    {
        Controlador.DatosCompra metodos = new Controlador.DatosCompra();

        public bool IngresarCompra(Compra c)
        {

            Controlador.Compra nuevo = new Controlador.Compra
            {

                Nro_Factura = c.Nro_Factura,
                id_Proveedor = c.id_Proveedor,
                Total=c.Total,
                Fecha = c.Fecha,
              



            };

            return metodos.IngresarCompra(nuevo);

        }

        public Controlador.Compra BuscarCompra(int nrofactura)
        {
            Controlador.Compra p = metodos.BuscarCompra(nrofactura);
            return p;
        }
        public List<Controlador.Compra> ListarCompras()
        {
            return (metodos.ListarCompras());
        }

        public bool ModificarCompra(Compra c)
        {
            Controlador.Compra nuevo = new Controlador.Compra
            {

                Nro_Factura = c.Nro_Factura,
                id_Proveedor = c.id_Proveedor,
                Total = c.Total,
                Fecha = c.Fecha,


            };
            return metodos.ModificarCompra(nuevo);
        }
    }
}
