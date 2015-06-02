using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Data.Logistica;
using ETNA.SGI.Entity.Logistica;

namespace ETNA.SGI.Bussiness.Logistica
{
    public class DetalleInventarioBL
    {
        private static DetalleInventarioDA objDetalleInventario;

        public DetalleInventarioBL()
        {
            objDetalleInventario = new DetalleInventarioDA();
        }

        public List<DetalleInventarioBE> ObtenerDetalleInventario(DetalleInventarioBE oBe)
        {
            return objDetalleInventario.ObtenerDetalleInventario(oBe);
        }

        public int FinalizarTomaInventario(DetalleInventarioBE oBe)
        {
            return objDetalleInventario.FinalizarTomaInventario(oBe);
        }

        public int EditarTomaInventario(DetalleInventarioBE oBe)
        {
            return objDetalleInventario.EditarTomaInventario(oBe);
        }
    }
}
