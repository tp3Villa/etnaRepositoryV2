using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ETNA.SGI.Entity.Exportacion;

namespace ETNA.SGI.Data.Exportacion
{
    public interface daoITransaccion
    {
        int DTransaccionVarias(string sql);
        int DInsertCabReq(eReqCab eReqCab);
        int DInsertDetReq(EReqDetalle eReqDet);
        int DDeleteCabReq(string REQ);
        int DDeleteDetReq(string REQ);
        int DUpdateEstadoReq(string REQ);
        int DInserUsuario(ELogin eLogin);
        int DDeleteUSUARIO(string Usuario);
        int DUpdateUSUARIO(string Usuario, string SET);
        int DInserUsuMenu(string Usu, string opc);
        int DDeleteUsuMenu(string Usu);
    }
}
