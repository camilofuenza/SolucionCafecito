using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class DatosVenta
    {
        UnCafecitoEntities entity = new UnCafecitoEntities();


        public bool IngresarVenta(Venta v)
        {
            bool res = false;

            if (BuscarVenta(v.Nro_Boleta) == null)
            {

                entity.Venta.Add(v);

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

        public Venta BuscarVenta(int nroBoleta)
        {

            Venta v = entity.Venta.FirstOrDefault(a => a.Nro_Boleta.Equals(nroBoleta));
            if (v != null)
            {
                return v;
            }
            else
            {
                return null;
            }

        }



        public bool ModificarVenta(Venta v)
        {

            Venta Venta = entity.Venta.FirstOrDefault(a => a.Nro_Boleta == v.Nro_Boleta);
            if (Venta != null)
            {
                Venta.RutVendedor = v.RutVendedor;
                Venta.FechaVenta = v.FechaVenta;
                Venta.Total = v.Total;
                Venta.TipoVenta = v.TipoVenta;

                entity.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }

        }
        public List<Venta> ListarVentas()
        {
            var lista = (from con in entity.Venta select con).ToList();
            return lista;
        }
    }
}

