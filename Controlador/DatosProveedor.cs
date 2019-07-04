using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class DatosProveedor
    {
        UnCafecitoEntities entity = new UnCafecitoEntities();


        public bool IngresarProveedor(Proveedor p)
        {
            bool res = false;

            if (BuscarProveedor(p.RutProveedor) == null)
            {
                entity.Proveedor.Add(p);

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

        public Proveedor BuscarProveedor(string RutProveedor)
        {

            Proveedor p = entity.Proveedor.FirstOrDefault(a => a.RutProveedor.Equals(RutProveedor));
            if (p != null)
            {
                return p;
            }
            else
            {
                return null;
            }

        }

        public bool EliminarProveedor(string RutProveedor)
        {
            bool res = false;

            Proveedor p = BuscarProveedor(RutProveedor);

            if (p != null)
            {
                foreach (var item in entity.Proveedor)
                {
                    if (item.RutProveedor == p.RutProveedor)
                    {
                        entity.Proveedor.Remove(item);
                    }
                }

                entity.Proveedor.Remove(p);

                if (entity.SaveChanges() > 0)
                {
                    res = true;
                }
            }

            return res;
        }

        public List<Proveedor> ListarProveedores()
        {
            var lista = (from con in entity.Proveedor select con).ToList();
            return lista;
        }
    }
}