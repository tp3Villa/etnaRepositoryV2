using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Comun
{
    public class PersonaBE
    {
        public int idPersona { get; set; }
        public int tipoPersona { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string razonSocial { get; set; }
        public int tipoDocIdentidad { get; set; }
        public string numeroDocIdentidad { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string paginaWeb { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string cargo { get; set; }
        public string centrocosto { get; set; }
        public int activo { get; set; }
        public DateTime fechaIngreso { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaCreacion { get; set; }

        public string NombreCompleto { get; set; }
    }
}
