using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Producto
    {


        public string Nombre_Producto { get; set; }
        public int Cantidad { get; set; }
        public int id_Categoria { get; set; }
        public int Precio { get; set; }
        public byte[] QRProducto { get; set; }

        public Producto()
        {
            this.Init();
        }

        private void Init()
        {
            Nombre_Producto = string.Empty;
            Cantidad = 0;
            id_Categoria = 0;
            Precio = 0;
            byte[] QRProducto = new byte[0];
        }
    }
}
