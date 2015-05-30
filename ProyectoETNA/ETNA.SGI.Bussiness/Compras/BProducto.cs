using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Entity.Compras;
using ETNA.SGI.Data.Compras;

namespace ETNA.SGI.Bussiness.Compras
{
    public class BProducto : BBase
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

        private ProductoDAO dProducto;

        public BProducto()
        {
            this.dProducto = ObjFactoryDAO.getProductoDAO();
        } 

        public List<EProducto> ListarPorCategoria(int codCategoria)
        {
            return dProducto.ListarPorCategoria(codCategoria);
        }

        public List<EProducto> ListarPorCategoriaYMarca(int codCategoria, int codMarca)
        {
            return dProducto.ListarPorCategoriaYMarca(codCategoria, codMarca);
        }
    }
}
