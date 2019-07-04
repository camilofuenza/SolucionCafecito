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
        public List<Controlador.Compra> ListarCompras()
        {
            return (metodos.ListarCompras());
        }
    }
}
