﻿using System;
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
        DataTable ListarPorCategoria(int codCategoria);

        DataTable ListarPorCategoriaYMarca(int codCategoria, int codMarca);
    }
}
