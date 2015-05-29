using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Logistica
{
    public class StockBE
    {
        public int idAlmacen { get; set; }
        public int idProducto { get; set; }
        public int idLote { get; set; }
        public int cantidad { get; set; }
        public int cantidadReservada { get; set; }
        public int activo { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
