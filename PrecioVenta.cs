using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    public class PrecioVenta
    {
        public int _id { get; set; }
        public int _idProductoVenta { get; set; }
        public int _stock { get; set; }
        public int _idVenta { get; set; }

        public PrecioVenta ()
        {
            _id = 0;
            _idProductoVenta = 0;
            _stock = 0;
            _idVenta = 0;
        }

        public PrecioVenta(int id, int idProductoVenta, int stock, int idVenta)
        {
            _id = id;
            _idProductoVenta = idProductoVenta;
            _stock = stock;
            _idVenta = idVenta;
        }
    }
}
