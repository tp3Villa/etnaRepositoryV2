using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Exportacion
{
    public class eCronogramaDespacho
    {
        private Int16 cod_solicitud;

        public Int16 Cod_solicitud
        {
            get { return cod_solicitud; }
            set { cod_solicitud = value; }
        }
        private string Razon_Social;

        public string Razon_Social1
        {
            get { return Razon_Social; }
            set { Razon_Social = value; }
        }
        private string fec_esp_cab_req;

        public string Fec_esp_cab_req
        {
            get { return fec_esp_cab_req; }
            set { fec_esp_cab_req = value; }
        }
        private Int16 idProducto;

        public Int16 IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }
        private string descripcionProducto;

        public string DescripcionProducto
        {
            get { return descripcionProducto; }
            set { descripcionProducto = value; }
        }
        private Int16 cantidad;

        public Int16 Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

    }
}
