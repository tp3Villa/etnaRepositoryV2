using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Logistica
{
    public class DocumentoPendienteBE
    {
        public int idDocPendiente { get; set; }
        public string numeroDocPendiente { get; set; }
        public int tipoDocumentoPendiente { get; set; }
        public int idClienteProveedor { get; set; }        
        public DateTime fechaDocumento { get; set; }
        public int situacionatencion { get; set; }
        public int activo { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaCreacion { get; set; }

        //Propiedades Personalizadas
        public string descripcionSituacionAtencion { get; set; }
        public string descripcionDocumentoPendiente { get; set; }
        public string centrocosto { get; set; }
        public string origen { get; set; }
    }
}
