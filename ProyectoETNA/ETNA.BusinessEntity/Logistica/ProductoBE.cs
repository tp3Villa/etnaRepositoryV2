using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Logistica
{
    public class ProductoBE
    {
        public int idProducto { get; set; }
        public int tipoProducto { get; set; }
        public string descripcion { get; set; }
        public int unidadMedida { get; set; }
        public int numeroPlacas { get; set; }
        public int capacidadNominal { get; set; }
        public int capacidadArranque { get; set; }
        public float largo { get; set; }
        public float ancho { get; set; }
        public float alto { get; set; }
        public float peso { get; set; }
        public int periodoRecarga { get; set; }
        public int tiempoMaxSinCarga { get; set; }
        public int temperaturaMaxCarga { get; set; }
        public int tipoDeUso { get; set; }
        public int tiempoGarantia { get; set; }
        public int stockMinimo { get; set; }
        public int stockMaximo { get; set; }
        public int activo { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
