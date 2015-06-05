using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Data.Exportacion
{
    public interface daoILogin
    {
        DataTable DLogueo(ETNA.SGI.Entity.Exportacion.ELogin ObjEn);
    }
}
