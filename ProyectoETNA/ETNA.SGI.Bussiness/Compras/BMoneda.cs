using ETNA.SGI.Data.Compras;
using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Bussiness.Compras
{
    public class BMoneda : BBase
    {

        private static BMoneda bMoneda;

        public static BMoneda getInstance()
        {
            if (bMoneda == null)
            {
                bMoneda = new BMoneda();
            }
            return bMoneda;
        }

        private MonedaDAO dMoneda;

        public BMoneda()
        {
            this.dMoneda = ObjFactoryDAO.getMonedaDAO();
        } 

        public DataTable ObtenerListadoMoneda()
        {
            return dMoneda.DGetAllMoneda();
        }

    }
}
