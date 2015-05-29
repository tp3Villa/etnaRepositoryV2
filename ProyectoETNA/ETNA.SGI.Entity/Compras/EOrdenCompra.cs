using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Compras
{
    public class EOrdenCompra
    {
        private int codOrdenCompra;

        public int CodOrdenCompra
        {
            get { return codOrdenCompra; }
            set { codOrdenCompra = value; }
        }
        private int codRequerimiento;

        public int CodRequerimiento
        {
            get { return codRequerimiento; }
            set { codRequerimiento = value; }
        }
        private int codCotizacion;

        public int CodCotizacion
        {
            get { return codCotizacion; }
            set { codCotizacion = value; }
        }
        private int codMoneda;

        public int CodMoneda
        {
            get { return codMoneda; }
            set { codMoneda = value; }
        }

        private int codEstado;

        public int CodEstado
        {
            get { return codEstado; }
            set { codEstado = value; }
        }

        private double igv;

        public double Igv
        {
            get { return igv; }
            set { igv = value; }
        }

        private DateTime fechaEntrega;

        public DateTime FechaEntrega
        {
            get { return fechaEntrega; }
            set { fechaEntrega = value; }
        }

        private string lugarEntrega;

        public string LugarEntrega
        {
            get { return lugarEntrega; }
            set { lugarEntrega = value; }
        }

        private string observacion;

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
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
    }
}
