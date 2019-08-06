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
        public int id_DetalleVenta { get; set; }
        public int TotalporProducto { get; set; }
        public double Precio_unitario { get; set; }

        public DetalleVenta()
        {
            this.Init();
        }

        private void Init()
        {
            Nro_Boleta = 0;
            Nombre_Producto = string.Empty;
            Cantidad = 0;
            id_DetalleVenta = 0;
            TotalporProducto = 0;
            Precio_unitario = 0.0;
        }
    }
}
