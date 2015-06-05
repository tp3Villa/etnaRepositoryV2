using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Data.Logistica;
using ETNA.SGI.Entity.Logistica;

namespace ETNA.SGI.Bussiness.Logistica
{
    /// <summary>
    /// Clase de interface entre lógica de negocio y datos de la tabla inventario
    /// </summary>
    public class InventarioBL
    {
        private static InventarioDA objInventario;

        public InventarioBL()
        {
            objInventario = new InventarioDA();
        }

        public InventarioBE ObtenerInventario(InventarioBE oBe)
        {
            return objInventario.ObtenerInventario(oBe);
        }
    }
}
