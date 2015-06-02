using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Data.Logistica;
using ETNA.SGI.Entity.Logistica;

namespace ETNA.SGI.Bussiness.Logistica
{
    public class UsuarioAlmacenBL
    {
        private static UsuarioAlmacenDA objUsuarioAlmacen;

        public UsuarioAlmacenBL()
        {
            objUsuarioAlmacen = new UsuarioAlmacenDA();
        }

        public List<UsuarioAlmacenBE> ObtenerAlmacen(string cod)
        {
            return objUsuarioAlmacen.ObtenerAlmacen(cod);
        }
    }
}
