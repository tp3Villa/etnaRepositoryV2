using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ETNA.SGI.Data.Exportacion;
using ETNA.SGI.Entity.Exportacion;

namespace ETNA.SGI.Bussiness.Exportacion
{
    public class BTransaccion
    {
        DTransaccion oDatTab = new DTransaccion();

        public int BTransaccionVarias(string sql)
        {
            return oDatTab.DTransaccionVarias(sql);
        }

        public int BInsertCabReq(eReqCab eReqCab)
        {
            return oDatTab.DInsertCabReq(eReqCab);
        }

        public int BInsertDetReq(EReqDetalle eReqDet)
        {
            return oDatTab.DInsertDetReq(eReqDet);
        }

        public int DDeleteCabReq(string REQ)
        {
            return oDatTab.DDeleteCabReq(REQ);
        }

        public int DDeleteDetReq(string REQ)
        {
            return oDatTab.DDeleteDetReq(REQ);
        }

        public int BUpdateEstadoReq(string REQ)
        {
            return oDatTab.DUpdateEstadoReq(REQ);
        }

        public int BInserUsuario(ELogin eLogin)
        {
            return oDatTab.DInserUsuario(eLogin);
        }

        public int DDeleteUSUARIO(string Usuario)
        {
            return oDatTab.DDeleteUSUARIO(Usuario);
        }

        public int DUpdateUSUARIO(string Usuario,string set)
        {
            return oDatTab.DUpdateUSUARIO(Usuario, set);
        }

        public int BInserUsuMenu(string Usu, string opc)
        {
            return oDatTab.DInserUsuMenu(Usu, opc);
        }

        public int BDeleteUsuMenu(string Usu)
        {
            return oDatTab.DDeleteUsuMenu(Usu);
        }
    }
}
