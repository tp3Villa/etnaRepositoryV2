using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Entity.Compras;
using System.Data;
using System.Data.SqlClient;

namespace ETNA.SGI.Data.Compras
{
    public interface ProductoDAO
    {
        List<EProducto> ListarPorCategoria(int codCategoria);

        List<EProducto> ListarPorCategoriaYMarca(int codCategoria, int codMarca);
    }
}
