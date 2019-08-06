using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloVendedor
    {
        Controlador.DatosVendedor metodos = new Controlador.DatosVendedor();

        public bool IngresarVendedor(Vendedor p)
        {

            Controlador.Vendedor nuevo = new Controlador.Vendedor
            {

                Rut=p.Rut,
                Nombre=p.Nombre,
                Pass=p.Pass



            };

            return metodos.IngresarVendedor(nuevo);

        }

        public Controlador.Vendedor BuscarVendedor(string RutVendedor)
        {
            Controlador.Vendedor p = metodos.BuscarVendedor(RutVendedor);
            return p;
        }

        public bool EliminarVendedor(string RutVendedor)
        {
            return metodos.EliminarVendedor(RutVendedor);
        }

        public List<Controlador.Vendedor> ListarVendedor()
        {
            return metodos.ListarVendedores();
        }

    }
}

