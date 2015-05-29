using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ETNA.SGI.Entity.Compras
{
    public class ECotizacion
    {

        private int codCotizacion;

        public int CodCotizacion
        {
            get { return codCotizacion; }
            set { codCotizacion = value; }
        }
        private int codRequerimiento;

        public int CodRequerimiento
        {
            get { return codRequerimiento; }
            set { codRequerimiento = value; }
        }

        private int codProveedor;

        public int CodProveedor
        {
            get { return codProveedor; }
            set { codProveedor = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private int telefono;

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private DateTime fechaExpiracion;

        public DateTime FechaExpiracion
        {
            get { return fechaExpiracion; }
            set { fechaExpiracion = value; }
        }

        private int codEstado;

        public int CodEstado
        {
            get { return codEstado; }
            set { codEstado = value; }
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

        private string usuarioAprobacion;
        public string UsuarioAprobacion
        {
            get { return usuarioAprobacion; }
            set { usuarioAprobacion = value; }
        }

        private DateTime fechaAprobacion;
        public DateTime FechaAprobacion
        {
            get { return fechaAprobacion; }
            set { fechaAprobacion = value; }
        }
    }

}
