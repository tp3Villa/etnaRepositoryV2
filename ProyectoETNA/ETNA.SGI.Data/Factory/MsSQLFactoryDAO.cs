using ETNA.SGI.Data.Compras;
using ETNA.SGI.Data.Compras.Impl.MsSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Data.Exportacion;
using ETNA.SGI.Data.Exportacion.Impl.MsSQL;

namespace ETNA.SGI.Data.Factory
{
    class MsSQLFactoryDAO : FactoryDAO
    {
        //Compras FACTORY
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

        public override MarcaDAO getMarcaDAO()
        {
            MarcaDAO objeto = MarcaMsSQLDAO.getInstance();
            return objeto;
        }

        public override ProductoDAO getProductoDAO()
        {
            ProductoDAO objeto = ProductoMsSQLDAO.getInstance();
            return objeto;
        }

        public override PersonaDAO getPersonaDAO()
        {
            PersonaDAO objeto = PersonaMsSQLDAO.getInstance();
            return objeto;
        }
        //Exportacion

        public override daoILogin obtenerLogin()
        {
            daoILogin objeto = (daoILogin)(new daoLoginSQL());
            return objeto;
        }

        public override daoITablas obtenerTablas()
        {
            daoITablas objeto = (daoITablas)(new daoTablasSQL());
            return objeto;
        }

        public override daoITransaccion obtenerTransaccion()
        {
            daoITransaccion objeto = (daoITransaccion)(new daoTransaccionSQL());
            return objeto;
        }

    }
}
