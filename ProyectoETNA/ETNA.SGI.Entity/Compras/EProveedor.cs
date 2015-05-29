using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Compras
{
    public class EProveedor
    {
        private int codProveedor;
        
        public int CodProveedor
        {
            get { return codProveedor; }
            set { codProveedor = value; }
        }
        private string razonSocial;

        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private int telefono;

       public int Telefono
        {
           get { return telefono; }
            set { telefono = value; }
        }

        private DateTime fechaRegistro;

       public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private long ruc;

        public long Ruc
        {
            get { return ruc; }
            set { ruc = value; }
        }

        private string observacion;

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }

        private int codCondicionPago;
        public int CodCondicionPago

        {
            get { return codCondicionPago; }
            set { codCondicionPago = value; }
        }

        private int codEstado;
        public int CodEstado
        {
            get { return codEstado; }
            set { codEstado = value; }
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

    }
}