using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Logistica
{
    public class LoteBE
    {
        public int idLote { get; set; }
        public DateTime fechaFabricacion { get; set; }
        public int ordenFabricacion { get; set; }
        public DateTime fechaTomaMuestra { get; set; }
        public int bloqueado { get; set; }
        public int cantidadProducida { get; set; }
        public int cantidadActual { get; set; }
        public int activo { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
