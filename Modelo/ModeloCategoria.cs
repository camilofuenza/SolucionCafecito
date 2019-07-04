using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloCategoria
    {
        Controlador.DatosCategoria metodos = new Controlador.DatosCategoria();

        public List<Controlador.Categoria> ListarCategoria()
        {
            return metodos.ListarCategorias();
        }

    }
}
