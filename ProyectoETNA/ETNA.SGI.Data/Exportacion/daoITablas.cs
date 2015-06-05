using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Data.Exportacion
{
    public interface daoITablas
    {
        DataTable getSELECTLIBRE(string SQL);
        DataTable DPaises();
        DataTable DPaisesIATA(string cod_pai);
        DataTable DClienteCodRaz();
        DataTable DProducto();
        DataTable DProductoBusquedaXCodigo(string Bus);
        DataTable DCorrelativo();
        DataTable DRequerimientoBusquedaXCodigoCliente(string cli);
        DataTable DRequerimientoDetalleXCodREQ(string Req);
        DataTable DRequerimientoCabeceraXCodREQ(string Req);
        DataTable DRequerimientos();
        DataTable DRequerimientosBUSQUEDAANIDAD(string Cod_Req, string Razon, decimal desde, decimal hasta);

        //TALLER DE PROYECTOS 3 APLICACION DE ESTANDARES
        DataTable DListaSolicitudesPendienteAprobacion(string Estado1, string Estado2, string fecha1, string fecha2, int opcion);
        DataTable DListaDocumentosVersionDetalle(int Estado1, string Estado2, string fecha1, string fecha2, int opcion);
    }
}
