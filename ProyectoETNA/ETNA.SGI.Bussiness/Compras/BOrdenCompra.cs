using ETNA.SGI.Data.Compras;
using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Bussiness.Compras
{
    public class BOrdenCompra : BBase
    {

        private static BOrdenCompra bOrdenCompra;

        public static BOrdenCompra getInstance()
        {
            if (bOrdenCompra == null)
            {
                bOrdenCompra = new BOrdenCompra();
            }
            return bOrdenCompra;
        }

        private OrdenCompraDAO dOrdenCompra;

        public BOrdenCompra()
        {
            this.dOrdenCompra = ObjFactoryDAO.getOrdenCompraDAO();
        } 

        public DataTable ObtenerListadoOrdenCompra(EOrdenCompra EOrdenCompra)
        {
            return dOrdenCompra.DGetAllOrdenCompra(EOrdenCompra);
        }

        public int ActualizarEstadoOrdenCompra(EOrdenCompra eOrdenCompra)
        {
            return dOrdenCompra.DUpdateEstadoOrdenCompra(eOrdenCompra);
        }

        public int ActualizarOrdenCompra(EOrdenCompra eOrdenCompra)
        {
            return dOrdenCompra.DUpdateOrdenCompra(eOrdenCompra);
        }

        public int RegistrarOrdenCompra(EOrdenCompra eOrdenCompra, List<EOrdenCompraDetalle> listaEOrdenCompraDetalle)
        {
            return dOrdenCompra.DInsertOrdenCompra(eOrdenCompra, listaEOrdenCompraDetalle);
        }

    }
}
