using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using ETNA.SGI.Data.Exportacion;

//

namespace ETNA.SGI.Bussiness.Exportacion
{
    public class BTablas
    {
        DTablas oDatTab = new DTablas();

        public DataTable getSELECTLIBRE(string SQL)
        {
            return oDatTab.getSELECTLIBRE(SQL);
        }

        public DataTable BPaises()
        {
            return oDatTab.DPaises();
        }

        public DataTable BPaisesIATA(string cod_pai)
        {
            return oDatTab.DPaisesIATA(cod_pai);
        }

        public DataTable BClienteCodRaz()
        {
            return oDatTab.DClienteCodRaz();
        }

        
        public DataTable BProducto()
        {
            return oDatTab.DProducto();
        }

        public DataTable BProductoBusquedaXCodigo(string Bus)
        {
            return oDatTab.DProductoBusquedaXCodigo(Bus);
        }

        public DataTable BCorrelativo()
        {
            return oDatTab.DCorrelativo();
        }

        public DataTable BRequerimientoBusquedaXCodigoCliente(string Bus)
        {
            return oDatTab.DRequerimientoBusquedaXCodigoCliente(Bus);
        }

        public DataTable BRequerimientoDetalleXCodREQ(string Req)
        {
            return oDatTab.DRequerimientoDetalleXCodREQ(Req);
        }

        public DataTable BRequerimientoCabeceraXCodREQ(string Req)
        {
            return oDatTab.DRequerimientoCabeceraXCodREQ(Req);
        }

        public DataTable BRequerimientos()
        {
            return oDatTab.DRequerimientos();
        }

        public DataTable BRequerimientosBUSQUEDAANIDAD(string Cod_Req, string Razon, decimal desde, decimal hasta)
        {
            return oDatTab.DRequerimientosBUSQUEDAANIDAD(Cod_Req, Razon, desde, hasta);
        }

    }
}
