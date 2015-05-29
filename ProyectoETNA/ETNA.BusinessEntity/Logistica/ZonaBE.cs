using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Logistica
{
    public class ZonaBE
    {
        public int idZona { get; set; }
        public int idAlmacen { get; set; }
        public int idProducto { get; set; }
        public int fila { get; set; }
        public int columna { get; set; }
        public int nivel { get; set; }
        public int posicion { get; set; }
        public int metraje { get; set; }
        public int capacidad { get; set; }
        public int disponibilidad { get; set; }
        public string observacion { get; set; }
        public int activo { get; set; }
    }
}
