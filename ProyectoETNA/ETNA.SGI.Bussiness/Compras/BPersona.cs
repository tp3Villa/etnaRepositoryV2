using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Data.Compras;
using ETNA.SGI.Entity.Compras;

namespace ETNA.SGI.Bussiness.Compras
{
    public class BPersona : BBase
    {
        private static BPersona bPersonal;

        public static BPersona getInstance()
        {
            if (bPersonal == null)
            {
                bPersonal = new BPersona();
            }
            return bPersonal;
        }

        private PersonaDAO dPersona;

        public BPersona()
        {
            this.dPersona = ObjFactoryDAO.getPersonaDAO();
        } 


        public EPersona obtenerPersonalxUsuario(string usuario)
        {
            return dPersona.obtenerPersonalxUsuario(usuario);
        }
    }
}
