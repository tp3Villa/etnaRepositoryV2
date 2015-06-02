using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Data.Logistica;
using ETNA.SGI.Entity.Logistica;

namespace ETNA.SGI.Bussiness.Logistica
{
    public class MovimientosAlmacenBL
    {
        private static MovimientosAlmacenDA objMovimientosAlmacen;

        public MovimientosAlmacenBL()
        {
            objMovimientosAlmacen = new MovimientosAlmacenDA();
        }

        public List<MovimientosAlmacenBE> ObtenerMovimientosAlmacen(MovimientosAlmacenBE oBe)
        {
            return objMovimientosAlmacen.ObtenerMovimientosAlmacen(oBe);
        }

        public MovimientosAlmacenBE ObtenerDocumentoPendiente(int cod)
        {
            return objMovimientosAlmacen.ObtenerDocumentoPendiente(cod);
        }
    }
}
