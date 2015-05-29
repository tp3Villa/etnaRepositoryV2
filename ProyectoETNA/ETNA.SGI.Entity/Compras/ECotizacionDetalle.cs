using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Compras
{
    public class ECotizacionDetalle
    {
        private int codCotizacion;

        public int CodCotizacion
        {
            get { return codCotizacion; }
            set { codCotizacion = value; }
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

        private Double precioUnidad;

        public Double PrecioUnidad
        {
            get { return precioUnidad; }
            set { precioUnidad = value; }
        }

        private Double descuento;

        public Double Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
    }
}
