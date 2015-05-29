using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Compras
{
    public class ProveedorBE
    {
        public int codProveedor { get; set; }
        public string razonSocial { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string email { get; set; }
        public int ruc { get; set; }
        public string observacion { get; set; }
 }
}
