using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Logistica
{
    public class ProgramacionInventarioBE
    {
        public int idProgInventario { get; set; }
        public int tipoInventario { get; set; }
        public DateTime fechaProgramada { get; set; }
        public int frecuencia { get; set; }
        public int idAlmacen { get; set; }
        public int idPersona { get; set; }
        public int idEstadoInventario { get; set; }
        public int activo { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaCreacion { get; set; }


        //Propiedades personalizadas
        public string descripcionTipoInventario { get; set; }
        public string Responsable { get; set; }
        public string descripcionAlmacen { get; set; }
        public string descripcionEstadoInventario { get; set; }

    }
}
