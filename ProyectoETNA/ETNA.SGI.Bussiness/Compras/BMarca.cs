using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Entity.Compras;
using ETNA.SGI.Data.Compras;
using System.Data;

namespace ETNA.SGI.Bussiness.Compras
{
    public class BMarca : BBase
    {
        private static BMarca bMarca;

        public static BMarca getInstance()
        {
            if (bMarca == null)
            {
                bMarca = new BMarca();
            }
            return bMarca;
        }

        private MarcaDAO dMarca;

        public BMarca()
        {
            this.dMarca = ObjFactoryDAO.getMarcaDAO();
        }

        public DataTable Lista() 
        {
            return dMarca.Lista();
        } 
    }
}
