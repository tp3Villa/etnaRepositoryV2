using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Logistica
{
    public class DetalleDocumentoPendienteBE
    {
        public int idDocPendiente { get; set; }
        public int idDetalleDocPendiente { get; set; }        
        public int idProducto { get; set; }
        public int cantidadPedida { get; set; }
        public int cantidadAtendida { get; set; }

        //Propiedades Personalizadas
        public string codigoProducto { get; set; }
        public string descripcionProducto { get; set; }
        public int tipounidadMedida { get; set; }
        public string descripcionUnidadMedida { get; set; }
        public int cantidadPendienteAtencion { get; set; }

    }
}
