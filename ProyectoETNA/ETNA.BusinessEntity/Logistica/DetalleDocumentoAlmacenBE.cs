using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Logistica
{
    public class DetalleDocumentoAlmacenBE
    {
        public int correlativo { get; set; }
        public int idDetalleDocAlmacen { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }

        //Propiedades personalizadas
        public int idDocPendiente { get; set; }
        public int idLote { get; set; }
    }
}
