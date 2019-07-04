using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Categoria
    {

        public int id_Categoria { get; set; }
        public string Nombre_Categoria { get; set; }

        public Categoria()
        {
            this.Init();

        }

        private void Init()
        {
            id_Categoria = 0;
            Nombre_Categoria = string.Empty;
        }
    }
}

