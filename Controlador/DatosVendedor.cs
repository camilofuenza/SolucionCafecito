using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class DatosVendedor
    {
        UnCafecitoEntities entity = new UnCafecitoEntities();


        public bool IngresarVendedor(Vendedor p)
        {
            bool res = false;

            if (BuscarVendedor(p.Nombre) == null)
            {
                entity.Vendedor.Add(p);

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

        public Vendedor BuscarVendedor(string nombreVendedor)
        {

            Vendedor p = entity.Vendedor.FirstOrDefault(a => a.Nombre.Equals(nombreVendedor));
            if (p != null)
            {
                return p;
            }
            else
            {
                return null;
            }

        }

        public bool EliminarVendedor(string nombreVendedor)
        {
            bool res = false;

            Vendedor p = BuscarVendedor(nombreVendedor);

            if (p != null)
            {
                foreach (var item in entity.Vendedor)
                {
                    if (item.Nombre == p.Nombre)
                    {
                        entity.Vendedor.Remove(item);
                    }
                }

                entity.Vendedor.Remove(p);

                if (entity.SaveChanges() > 0)
                {
                    res = true;
                }
            }

            return res;
        }

        public List<Vendedor> ListarVendedores()
        {
            var lista = (from con in entity.Vendedor select con).ToList();
            return lista;
        }

    }
}
