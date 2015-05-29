using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Data.Compras
{
    public interface OrdenCompraDAO
    {
        DataTable DGetAllOrdenCompra(EOrdenCompra EOrdenCompra);

        int DUpdateEstadoOrdenCompra(EOrdenCompra eOrdenCompra);

        int DUpdateOrdenCompra(EOrdenCompra eOrdenCompra);

        int DInsertOrdenCompra(EOrdenCompra eOrdenCompra, List<EOrdenCompraDetalle> listaEOrdenCompraDetalle);

    }
}
