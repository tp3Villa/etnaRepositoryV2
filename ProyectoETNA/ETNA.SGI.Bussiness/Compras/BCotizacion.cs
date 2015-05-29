using ETNA.SGI.Data.Compras;
using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Bussiness.Compras
{
    public class BCotizacion : BBase
    {
        private static BCotizacion bCotizacion;

        public static BCotizacion getInstance()
        {
            if (bCotizacion == null)
            {
                bCotizacion = new BCotizacion();
            }
            return bCotizacion;
        }

        private CotizacionDAO dCotizacion;

        public BCotizacion()
        {
            this.dCotizacion = ObjFactoryDAO.getCotizacionDAO();
        } 

        public DataTable SelectLibre(string SQL)
        {
            return dCotizacion.getSELECTLIBRE(SQL);
        }

        public DataTable CorrelativoCotizacion()
        {
            return dCotizacion.DCorrelativoCotizacion();
        }

        // Listados de Cotizacion -- frmListadoCotizacion Load
        public DataTable ObtenerListadoCotizacion(ECotizacion ECotizacion)
        {
            return dCotizacion.DGetAllCotizacion(ECotizacion);
        }


        public DataTable ObtenerCotizacionPorId(ECotizacion eCotizacion)
        {
            return dCotizacion.DGetCotizacionById(eCotizacion);
        }

          //Obtener Estado de Cotización por Id
        public DataTable ObtenerEstadoCotizacionPorId(int codCotizacion)
        {
            return dCotizacion.DGetEstadoCotizacionById(codCotizacion);
        }


        public DataTable ObtenerCotizacionDetallePorId(ECotizacionDetalle eCotizacionDetalle)
        {
            return dCotizacion.DGetCotizacionDetalleById(eCotizacionDetalle);
        }
                

        public DataTable ObtenerCotizacionDetalle(ECotizacionDetalle ECotizacionDetalle)
        {
            return dCotizacion.DGetAllCotizacionDetalle(ECotizacionDetalle);
        }

        // Registrar Cotizacion
        public int RegistrarCotizacion(ECotizacion eCotizacion, List<ECotizacionDetalle> listaECotizacionDetalle)
        {
            return dCotizacion.DInsertCotizacion(eCotizacion, listaECotizacionDetalle);
        }


        // Actualizar Cotizacion
        public int ActualizarCotizacion(ECotizacion eCotizacion, List<ECotizacionDetalle> listaECotizacionDetalle)
        {
            return dCotizacion.DUpdateCotizacion(eCotizacion, listaECotizacionDetalle);
        }

        //Actualiza estado cotizacion
        public int ActualizarEstadoCotizacion(int CodCotizacion, int CodEstado)
        {
            return dCotizacion.DUpdateEstadoCotizacion(CodCotizacion, CodEstado);
        }

        //Eliminar Cotizacion
        public int EliminarCotizacion(int codCotizacion)
        {
            return dCotizacion.DDeleteCotizacion(codCotizacion);
        }

      
         public DataTable DGetCotizacionAprobacion()
        {
            return dCotizacion.DGetCotizacionAprobacion();
        }

         public int DUpdateAprobacionCotizacion(ECotizacion ECotizacion)
        {
            return dCotizacion.DUpdateAprobacionCotizacion(ECotizacion);
        }

         public DataTable DGetCotizacionAprobacionWithParameters(DateTime dtFrom , DateTime dtTo , int codRequerimiento , int codProveedor)
        {
            return dCotizacion.DGetCotizacionAprobacionWithParameters(dtFrom, dtTo, codRequerimiento, codProveedor);
        }
        

    }
}
