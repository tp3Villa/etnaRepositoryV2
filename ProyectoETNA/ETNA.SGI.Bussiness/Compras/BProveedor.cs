using ETNA.SGI.Data.Compras;
using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Bussiness.Compras
{
    public class BProveedor : BBase
    {
        private static BProveedor bProveedor;

        public static BProveedor getInstance()
        {
            if (bProveedor == null)
            {
                bProveedor = new BProveedor();
            }
            return bProveedor;
        }

        private ProveedorDAO dProveedor;

        public BProveedor()
        {
            this.dProveedor = ObjFactoryDAO.getProveedorDAO();
        } 

        public DataTable BCorrelativoProveedor()
        {
            return dProveedor.DCorrelativoProveedor();
        }

        public DataTable DGetAllProveedor(EProveedor EProveedor)
        {
            return dProveedor.DGetAllProveedor(EProveedor);
        }

        public int BInsertProveedor(EProveedor EProveedor)
        {
            return dProveedor.DInsertProveedor(EProveedor);
        }

        public int DUpdateProveedor(EProveedor EProveedor)
        {
            return dProveedor.DUpdateProveedor(EProveedor);
        }

        public int DDeleteProveedor(int CodProveedor)
        {
            return dProveedor.DDeleteProveedor(CodProveedor);
        }

        public DataTable DGetProveedorById(EProveedor EProveedor)
        {
            return dProveedor.DGetProveedorById(EProveedor);
        }

        public DataTable DGetProveedorWithStatus(EProveedor EProveedor)
        {
            return dProveedor.DGetProveedorWithStatus(EProveedor);
        }


        public DataTable DGetAllProveedorActive(EProveedor EProveedor)
        {
            return dProveedor.DGetAllProveedorActive(EProveedor);
        }

        public DataTable DValidarRUC(string Sql)
        {
            return dProveedor.DValidarRUC(Sql);
        }
    }
}
