using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Venta
    {
        public int Nro_Boleta { get; set; }
        public string RutVendedor { get; set; }
        public DateTime FechaVenta { get; set; }
        public int TotalVenta { get; set; }
        public string TipoVenta { get; set; }

        public Venta()
        {
            this.Init();
        }

        private void Init()
        {
            Nro_Boleta = 0;
            RutVendedor = string.Empty;
            FechaVenta = DateTime.Parse("01-01-1990");
            TotalVenta = 0;
            TipoVenta = string.Empty;
        }

    }
}
