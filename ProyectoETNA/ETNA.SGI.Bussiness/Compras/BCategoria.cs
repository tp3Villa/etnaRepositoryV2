using ETNA.SGI.Data.Compras;
using ETNA.SGI.Data.Factory;
using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Bussiness.Compras
{
    public class BCategoria : BBase
    {
        private static BCategoria bCategoria;

        public static BCategoria getInstance()
        {
            if (bCategoria == null)
            {
               bCategoria = new BCategoria();
            }
            return bCategoria;
        }

        private CategoriaDAO dCategoria;

        public BCategoria()
        {
            this.dCategoria = ObjFactoryDAO.getCategoriaDAO();
        } 
                
        public DataTable ObtenerListadoCategoria()
        {
            return dCategoria.DGetAllCategoria();
        }

    }
}
