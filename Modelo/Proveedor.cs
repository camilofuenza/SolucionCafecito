using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Proveedor
    {
        public int id_Proveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string NombreContacto { get; set; }
        public string RutProveedor { get; set; }
        public string TelefonoContacto { get; set; }


        public Proveedor()
        {
            this.Init();
        }

        private void Init()
        {
            
            id_Proveedor = 0;
            NombreProveedor = string.Empty;
            NombreContacto = string.Empty;
            RutProveedor = string.Empty;
            TelefonoContacto = string.Empty;
           
        }

    }
}
