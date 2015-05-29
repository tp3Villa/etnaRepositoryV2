using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Compras
{
    public class ERequerimientoCompra
    {
        private int codRequerimiento;

        public int CodRequerimiento
        {
            get { return codRequerimiento; }
            set { codRequerimiento = value; }
        }

        private int codEstado;

        public int CodEstado
        {
            get { return codEstado; }
            set { codEstado = value; }
        }

        private int codCategoria;

        public int CodCategoria
        {
            get { return codCategoria; }
            set { codCategoria = value; }
        }

        private DateTime fechaRegistro;

        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        private DateTime fechaActualizacion;

        public DateTime FechaActualizacion
        {
            get { return fechaActualizacion; }
            set { fechaActualizacion = value; }
        }

        private string usuarioRegistro;
        public string UsuarioRegistro
        {
            get { return usuarioRegistro; }
            set { usuarioRegistro = value; }
        }

        private string usuarioModificacion;
        public string UsuarioModificacion
        {
            get { return usuarioModificacion; }
            set { usuarioModificacion = value; }
        }

        private string observacion;

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }



    }
}
