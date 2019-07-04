using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Vendedor
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Pass { get; set; }

        public Vendedor()
        {
            this.Init();
        }

        private void Init()
        {
            Rut = string.Empty;
            Nombre = string.Empty;
            Pass = string.Empty;
        }
    }
}
