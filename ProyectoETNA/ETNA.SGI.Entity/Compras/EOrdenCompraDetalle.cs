using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Compras
{
    public class EOrdenCompraDetalle
    {
        private int codOrdenCompra;

        public int CodOrdenCompra
        {
            get { return codOrdenCompra; }
            set { codOrdenCompra = value; }
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
