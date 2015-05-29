using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Logistica
{
    public class DetalleInventarioBE
    {
        public int idDetalleInventario { get; set; }
        public int idInventario { get; set; }
        public int idAlmacen { get; set; }
        public int idProducto { get; set; }
        public int idOperadorAlmacen { get; set; }
        public int cantidadActual { get; set; }
        public int cantidad { get; set; }
        public int cantidadAjuste { get; set; }
        public DateTime fechaHoraToma { get; set; }
        public int numeroToma { get; set; }
    }
}
