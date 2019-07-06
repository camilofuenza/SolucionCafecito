using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Compra
    {
        public int Nro_Factura { get; set; }
        public int id_Proveedor { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }

        public Compra()
        {
            this.Init();
        }

        private void Init()
        {
            Nro_Factura = 0;
            id_Proveedor = 0;
            Fecha = DateTime.Parse("01/01/1990");
            Total = 0.0;

        }

    }
}
