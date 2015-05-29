using ETNA.SGI.Data.Compras;
using ETNA.SGI.Data.Compras.Impl.MsSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Data.Factory
{
    class MsSQLFactoryDAO : FactoryDAO
    {
        public override CategoriaDAO getCategoriaDAO()
        {
            CategoriaDAO objeto = CategoriaMsSQLDAO.getInstance();
            return objeto;
        }

        public override CondicionPagoDAO getCondicionPagoDAO()
        {
            CondicionPagoDAO objeto = CondicionPagoMsSQLDAO.getInstance();
            return objeto;
        }

        public override CotizacionDAO getCotizacionDAO()
        {
            CotizacionDAO objeto = CotizacionMsSQLDAO.getInstance();
            return objeto;
        }

        public override EstadoDAO getEstadoDAO()
        {
            EstadoDAO objeto = EstadoMsSQLDAO.getInstance();
            return objeto;
        }

        public override MonedaDAO getMonedaDAO()
        {
            MonedaDAO objeto = MonedaMsSQLDAO.getInstance();
            return objeto;
        }

        public override OrdenCompraDAO getOrdenCompraDAO()
        {
            OrdenCompraDAO objeto = OrdenCompraMsSQLDAO.getInstance();
            return objeto;
        }

        public override ProveedorDAO getProveedorDAO()
        {
            ProveedorDAO objeto = ProveedorMsSQLDAO.getInstance();
            return objeto;
        }

        public override RequerimientoCompraDAO getRequerimientoCompraDAO()
        {
            RequerimientoCompraDAO objeto = RequerimientoCompraMsSQLDAO.getInstance();
            return objeto;
        }       
    }
}
