using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using ETNA.SGI.Data.Exportacion;

//

namespace ETNA.SGI.Bussiness.Exportacion
{
    public class BTablas : BBase
    {
        private static BTablas bTablas;

        public static BTablas getInstance()
        {
            if (bTablas == null)
            {
                bTablas = new BTablas();
            }
            return bTablas;
        }        

        private daoITablas dTablas;

        public BTablas()
        {
            this.dTablas = ObjFactoryDAO.obtenerTablas();
        } 




        public DataTable getSELECTLIBRE(string SQL)
        {
            //return oDatTab.getSELECTLIBRE(SQL);
            return dTablas.getSELECTLIBRE(SQL);
        }

        public DataTable BPaises()
        {
            return dTablas.DPaises();
        }

        public DataTable BPaisesIATA(string cod_pai)
        {
            return dTablas.DPaisesIATA(cod_pai);
        }

        public DataTable BClienteCodRaz()
        {
            return dTablas.DClienteCodRaz();
        }

        
        public DataTable BProducto()
        {
            return dTablas.DProducto();
        }

        public DataTable BProductoBusquedaXCodigo(string Bus)
        {
            return dTablas.DProductoBusquedaXCodigo(Bus);
        }

        public DataTable BCorrelativo()
        {
            return dTablas.DCorrelativo();
        }

        public DataTable BRequerimientoBusquedaXCodigoCliente(string Bus)
        {
            return dTablas.DRequerimientoBusquedaXCodigoCliente(Bus);
        }

        public DataTable BRequerimientoDetalleXCodREQ(string Req)
        {
            return dTablas.DRequerimientoDetalleXCodREQ(Req);
        }

        public DataTable BRequerimientoCabeceraXCodREQ(string Req)
        {
            return dTablas.DRequerimientoCabeceraXCodREQ(Req);
        }

        public DataTable BRequerimientos()
        {
            return dTablas.DRequerimientos();
        }

        public DataTable BRequerimientosBUSQUEDAANIDAD(string Cod_Req, string Razon, decimal desde, decimal hasta)
        {
            return dTablas.DRequerimientosBUSQUEDAANIDAD(Cod_Req, Razon, desde, hasta);
        }



        //TALLER DE PROYECTOS 3 APLICACION DE PATRONES 
        public DataTable BConsula_Aprobacion_Solicitudes(string Estado1, string Estado2, string fecha1, string fecha2, int opcion)
        {
            return dTablas.DListaSolicitudesPendienteAprobacion(Estado1, Estado2, fecha1, fecha2, opcion);
        }


        public DataTable BConsula_Versiones_Documentos_Detalle(int Estado1, string Estado2, string fecha1, string fecha2, int opcion)
        {
            return dTablas.DListaDocumentosVersionDetalle(Estado1, Estado2, fecha1, fecha2, opcion);
        }


    }
}
