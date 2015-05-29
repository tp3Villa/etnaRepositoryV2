using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using ETNA.SGI.Data.Exportacion;
//
namespace ETNA.SGI.Bussiness.Exportacion
{
    public class BLogin
    {
        DLogin oDatTab = new DLogin();

        public DataTable BLogueo(ETNA.SGI.Entity.Exportacion.ELogin ObjEn)
        {
            return oDatTab.DLogueo(ObjEn);
        }

    }
}
