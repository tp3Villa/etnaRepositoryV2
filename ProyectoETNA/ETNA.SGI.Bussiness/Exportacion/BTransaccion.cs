using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ETNA.SGI.Data.Exportacion;
using ETNA.SGI.Entity.Exportacion;

namespace ETNA.SGI.Bussiness.Exportacion
{
    public class BTransaccion:BBase
    {
        
        private static BTransaccion bTransaccion;

        public static BTransaccion getInstance()
        {
            if (bTransaccion == null)
            {
                bTransaccion = new BTransaccion();
            }
            return bTransaccion;
        }        

        private daoITransaccion dTransaccion;

        public BTransaccion()
        {
            this.dTransaccion = ObjFactoryDAO.obtenerTransaccion();
        }


        public int BTransaccionVarias(string sql)
        {
            //return oDatTab.DTransaccionVarias(sql);
            return dTransaccion.DTransaccionVarias(sql);
        }

        public int BInsertCabReq(eReqCab eReqCab)
        {
            return dTransaccion.DInsertCabReq(eReqCab);
        }

        public int BInsertDetReq(EReqDetalle eReqDet)
        {
            return dTransaccion.DInsertDetReq(eReqDet);
        }

        public int DDeleteCabReq(string REQ)
        {
            return dTransaccion.DDeleteCabReq(REQ);
        }

        public int DDeleteDetReq(string REQ)
        {
            return dTransaccion.DDeleteDetReq(REQ);
        }

        public int BUpdateEstadoReq(string REQ)
        {
            return dTransaccion.DUpdateEstadoReq(REQ);
        }

        public int BInserUsuario(ELogin eLogin)
        {
            return dTransaccion.DInserUsuario(eLogin);
        }

        public int DDeleteUSUARIO(string Usuario)
        {
            return dTransaccion.DDeleteUSUARIO(Usuario);
        }

        public int DUpdateUSUARIO(string Usuario, string set)
        {
            return dTransaccion.DUpdateUSUARIO(Usuario, set);
        }

        public int BInserUsuMenu(string Usu, string opc)
        {
            return dTransaccion.DInserUsuMenu(Usu, opc);
        }

        public int BDeleteUsuMenu(string Usu)
        {
            return dTransaccion.DDeleteUsuMenu(Usu);
        }

    }
}
