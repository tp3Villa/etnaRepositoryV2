using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using ETNA.SGI.Data.Exportacion;
//
namespace ETNA.SGI.Bussiness.Exportacion
{
    public class BLogin : BBase
    {
        private static BLogin bLogin;

        public static BLogin getInstance()
        {
            if (bLogin == null)
            {
                bLogin = new BLogin();
            }
            return bLogin;
        }
        
        private daoILogin dLogin;

        public BLogin()
        {
            this.dLogin = ObjFactoryDAO.obtenerLogin();
        } 
        
        public DataTable BLogueo(ETNA.SGI.Entity.Exportacion.ELogin ObjEn)
        {
            return dLogin.DLogueo(ObjEn);
        }

    }
}
