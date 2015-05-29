using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Logistica
{
    public class InventarioBE
    {
        public int idInventario { get; set; }
        public int idAlmacen { get; set; }
        public int idProgInventario { get; set; }
        public DateTime fechaHoraInicio { get; set; }
        public DateTime fechaHoraFin { get; set; }
        public int tipo { get; set; }
        public int activo { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
