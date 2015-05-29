using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace ETNA.SGI.Data.Compras
{
    public interface CotizacionDAO
    {
        DataTable DCorrelativoCotizacion();

        DataTable getSELECTLIBRE(string SQL);

        //Obtener Listado Cotizacion
        DataTable DGetAllCotizacion(ECotizacion eCotizacion);

        //Obtener Cabecera Cotizaciòn por Id
        DataTable DGetCotizacionById(ECotizacion eCotizacion);

        //Obtener Estado de Cotización por Id
        DataTable DGetEstadoCotizacionById(int codCotizacion);

        //Obtener detalle cotizacion por Id
        DataTable DGetCotizacionDetalleById(ECotizacionDetalle eCotizacionDetalle);

        //Obtener Detalle Cotizacion
        DataTable DGetAllCotizacionDetalle(ECotizacionDetalle eCotizacionDetalle);

        //Insertar datos Cotizacion
        int DInsertCotizacion(ECotizacion eCotizacion, List<ECotizacionDetalle> listaECotizacionDetalle);

        //Actualizar datos Cotizacion
        int DUpdateCotizacion(ECotizacion eCotizacion, List<ECotizacionDetalle> listaECotizacionDetalle);

        //Eliminar datos Cotizacion
        int DDeleteCotizacion(int codCotizacion);     

        /* Aprobación Cotización */
        DataTable DGetCotizacionAprobacion();

        //Actualiza estado cotizacion
        int DUpdateEstadoCotizacion(int codCotizacion, int codEstado);

        DataTable DGetCotizacionAprobacionWithParameters(DateTime dtFrom, DateTime dtTo, int codRequerimiento, int codProveedor);

        int DUpdateAprobacionCotizacion(ECotizacion ECotizacion);

    }
}
