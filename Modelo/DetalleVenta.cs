using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class DetalleVenta
    {
        public int Nro_Boleta { get; set; }
        public string Nombre_Producto { get; set; }
        public int Cantidad { get; set; }

        public DetalleVenta()
        {
            this.Init();
        }

        private void Init()
        {
            Nro_Boleta = 0;
            Nombre_Producto = string.Empty;
            Cantidad = 0;
        }
    }
}
