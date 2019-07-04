using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class DatosCategoria
    {
        UnCafecitoEntities entity = new UnCafecitoEntities();

        public List<Categoria> ListarCategorias()
        {
            var lista = (from con in entity.Categoria select con).ToList();
            return lista;
        }
    }
}
