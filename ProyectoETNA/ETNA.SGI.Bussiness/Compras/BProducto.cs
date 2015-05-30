using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Entity.Compras;
using ETNA.SGI.Data.Compras;

namespace ETNA.SGI.Bussiness.Compras
{
    public class BProducto
    {
        private static BProducto bProducto;

        public static BProducto getInstance()
        {
            if (bProducto == null)
            {
                bProducto = new BProducto();
            }
            return bProducto;
        }

        public List<EProducto> ListarPorCategoria(int codCategoria)
        {
            return null; // ArticuloDAO.ListarPorCategoria(codCategoria);
        }

        public List<EProducto> ListarPorCategoriaYMarca(int codCategoria, int codMarca)
        {
            return null; //ArticuloDAO.ListarPorCategoriaYMarca(codCategoria, codMarca);
        }
    }
}
