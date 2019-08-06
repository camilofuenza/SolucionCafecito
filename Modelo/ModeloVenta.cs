using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloVenta
    {
        Controlador.DatosVenta metodos = new Controlador.DatosVenta();

        public bool IngresarVenta(Venta v)
        {

            Controlador.Venta nuevo = new Controlador.Venta
            {
                Nro_Boleta=v.Nro_Boleta,
                RutVendedor = v.RutVendedor,
                FechaVenta = v.FechaVenta,
                Total = v.TotalVenta,
                TipoVenta = v.TipoVenta,




        };

            return metodos.IngresarVenta(nuevo);

        }

        public Controlador.Venta BuscarVenta(int nrofactura)
        {
            Controlador.Venta p = metodos.BuscarVenta(nrofactura);
            return p;
        }
        public List<Controlador.Venta> ListarVentas()
        {
            return (metodos.ListarVentas());
        }

        public bool ModificarVenta(Venta v)
        {
            Controlador.Venta nuevo = new Controlador.Venta

            {
                Nro_Boleta=v.Nro_Boleta,
                RutVendedor=v.RutVendedor,
                FechaVenta=v.FechaVenta,
                Total=v.TotalVenta,
                TipoVenta=v.TipoVenta
               


            };
            return metodos.ModificarVenta(nuevo);
        }
    }
}
