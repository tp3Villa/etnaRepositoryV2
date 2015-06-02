using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Data.Logistica;
using ETNA.SGI.Entity.Logistica;

namespace ETNA.SGI.Bussiness.Logistica
{
    public class MovimientosAlmacenDetalleBL
    {
        private static MovimientosAlmacenDetalleDA objMovimientosAlmacenDetalle;

        public MovimientosAlmacenDetalleBL()
        {
            objMovimientosAlmacenDetalle = new MovimientosAlmacenDetalleDA();
        }

        public List<MovimientosAlmacenDetalleBE> ObtenerDetalleMovimientos(int id)
        {
            return objMovimientosAlmacenDetalle.ObtenerDetalleMovimientos(id);
        }

        public int EditarDetalleMovimiento(MovimientosAlmacenDetalleBE oBe)
        {
            return objMovimientosAlmacenDetalle.EditarDetalleMovimiento(oBe);
        }

        public int GuardarDetalleMovimiento(MovimientosAlmacenDetalleBE oBe)
        {
            return objMovimientosAlmacenDetalle.GuardarDetalleMovimiento(oBe);
        }
    }
}
