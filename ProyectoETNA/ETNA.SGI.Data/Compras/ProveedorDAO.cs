using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Data.Compras
{
    public interface ProveedorDAO
    {
        DataTable DCorrelativoProveedor();

        DataTable DGetAllProveedor(EProveedor EProveedor);

        DataTable DGetAllProveedorActive(EProveedor EProveedor);

        DataTable DGetProveedorById(EProveedor EProveedor);

        DataTable DGetProveedorWithStatus(EProveedor EProveedor);

        int DInsertProveedor(EProveedor EProveedor);

        int DUpdateProveedor(EProveedor EProveedor);

        int DDeleteProveedor(int CodProveedor);

        DataTable DValidarRUC(string Sql);
    }
}
