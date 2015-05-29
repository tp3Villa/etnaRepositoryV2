using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Logistica
{
    public class AlmacenBE
    {
        public int idAlmacen { get; set; }
        public string descripcionAlmacen { get; set; }
        public int idSupervisorAlmacen { get; set; }
        public string direccion { get; set; }
        public string ubigeo { get; set; }
        public string telefono { get; set; }
        public int tipoAlmacen { get; set; }
        public float metraje { get; set; }
        public int activo { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaCreacion { get; set; }

    }
}
