
using ETNA.SGI.Entity.Compras;
using ETNA.SGI.Data.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Bussiness.Compras
{
    public class BCondicionPago : BBase
    {
        private static BCondicionPago bCondicionPago;

        public static BCondicionPago getInstance()
        {
            if (bCondicionPago == null)
            {
                bCondicionPago = new BCondicionPago();
            }
            return bCondicionPago;
        }

        private CondicionPagoDAO dCondicionPago;

        public BCondicionPago()
        {
            this.dCondicionPago = ObjFactoryDAO.getCondicionPagoDAO();
        } 

        public DataTable DGetAllCondicionPago()
        {
            return dCondicionPago.DGetAllCondicionPago();
        }

        public DataTable DGetAllCondicionPagoByDesc(ECondicionPago ECondicionPago)
        {
            return dCondicionPago.DGetAllCondicionPagoByDesc(ECondicionPago);
        }
    }
}
