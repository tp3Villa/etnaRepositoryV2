using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Logistica
{
    public class DocumentoAlmacenBE
    {
        public int correlativo { get; set; }
        public int idDocPendiente { get; set; }        
        public string numeroDocAlmacen { get; set; }
        public int tipoMovimiento { get; set; }
        public DateTime fechaDocumento { get; set; }
        public int idAlmacen { get; set; }
        public int activo { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaCreacion { get; set; }

        //Propiedades Personalizadas
        public string descripcionAlmacen { get; set; }
        public string descripcionTipoMovimiento { get; set; }
        public string numeroDocPendiente { get; set; }
        public string descripcionDocumentoPendiente { get; set; }
        public string Origen { get; set; }
        public string centrocosto { get; set; }
    }
}
