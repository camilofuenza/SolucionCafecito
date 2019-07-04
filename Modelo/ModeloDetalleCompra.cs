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
        public List<Controlador.DetalleCompra> ListarDetallesCompras()
        {
            return (metodos.ListarDetallesCompra());
        }
    }
}
