using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Compras
{
    public class ERequerimientoCompraDetalle
    {
        private int codRequerimiento;

        public int CodRequerimiento
        {
            get { return codRequerimiento; }
            set { codRequerimiento = value; }
        }

        private int idProducto;

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        /* RICHARD */
        private string desCategoria;

        public string DesCategoria
        {
            get { return desCategoria; }
            set { desCategoria = value; }
        }
        private string desMarca;

        public string DesMarca
        {
            get { return desMarca; }
            set { desMarca = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private string tipoUnidad;

        public string TipoUnidad
        {
            get { return tipoUnidad; }
            set { tipoUnidad = value; }
        }
    }
}
