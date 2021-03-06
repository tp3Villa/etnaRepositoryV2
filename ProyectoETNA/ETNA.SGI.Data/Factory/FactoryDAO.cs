﻿using ETNA.SGI.Data.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Data.Exportacion;

namespace ETNA.SGI.Data.Factory
{
    public abstract class FactoryDAO
    {
        public const int MSSQL_FACTORY = 1;
        public const int ORACLE_FACTORY = 2;


        //Compras
        public abstract CategoriaDAO getCategoriaDAO();
        public abstract CondicionPagoDAO getCondicionPagoDAO();
        public abstract CotizacionDAO getCotizacionDAO();
        public abstract EstadoDAO getEstadoDAO();
        public abstract MonedaDAO getMonedaDAO();
        public abstract OrdenCompraDAO getOrdenCompraDAO();
        public abstract ProveedorDAO getProveedorDAO();
        public abstract RequerimientoCompraDAO getRequerimientoCompraDAO();
        public abstract MarcaDAO getMarcaDAO();
        public abstract ProductoDAO getProductoDAO();
        public abstract PersonaDAO getPersonaDAO();


        //Exportacion
        public abstract daoILogin obtenerLogin();
        public abstract daoITablas obtenerTablas();
        public abstract daoITransaccion obtenerTransaccion();





        public static FactoryDAO getFactory(int keyFactory)
        {
            switch (keyFactory)
            {
                case MSSQL_FACTORY:
                    return new MsSQLFactoryDAO();
                case ORACLE_FACTORY:
                    //return new OracleFactoryDAO();
                default:
                    throw new Exception();
            }
        }
    }
}
