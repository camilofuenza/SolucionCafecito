using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class DatosCompra
    {
        UnCafecitoEntities entity = new UnCafecitoEntities();


        public bool IngresarCompra(Compra c)
        {
            bool res = false;

            if (BuscarCompra(c.Nro_Factura) == null)
            {
                entity.Compra.Add(c);

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

        public Compra BuscarCompra(int nrofactura)
        {

            Compra c = entity.Compra.FirstOrDefault(a => a.Nro_Factura.Equals(nrofactura));
            if (c != null)
            {
                return c;
            }
            else
            {
                return null;
            }

        }
        public List<Compra> ListarCompras()
        {
            var lista = (from con in entity.Compra select con).ToList();
            return lista;
        }
    }
}
