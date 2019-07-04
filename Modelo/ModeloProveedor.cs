using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloProveedor
    {
        Controlador.DatosProveedor metodos = new Controlador.DatosProveedor();

        public bool IngresarProveedor(Proveedor p)
        {

            Controlador.Proveedor nuevo = new Controlador.Proveedor
            {
                
                id_Proveedor=p.id_Proveedor,
                NombreProveedor = p.NombreProveedor,
                NombreContacto = p.NombreContacto,
                RutProveedor = p.RutProveedor,
                TelefonoContacto = p.TelefonoContacto
              


            };

            return metodos.IngresarProveedor(nuevo);

        }

        public Controlador.Proveedor BuscarProveedor(string RutProveedor)
        {
            Controlador.Proveedor p = metodos.BuscarProveedor(RutProveedor);
            return p;
        }

        public bool EliminarProveedor(string RutProveedor)
        {
            return metodos.EliminarProveedor(RutProveedor);
        }

        public List<Controlador.Proveedor> ListarProveedor()
        {
            return metodos.ListarProveedores();
        }

    }
}
