using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Data.Logistica;
using ETNA.SGI.Entity.Logistica;

namespace ETNA.SGI.Bussiness.Logistica
{
    /// <summary>
    /// Clase para interface lógica de negocio y datos para la obtención de los tipos usados en las listas de control
    /// </summary>
    public class TipoBL
    {
        private static TipoDA objTipo;

        public TipoBL()
        {
            objTipo = new TipoDA();
        }

        public List<TipoBE> ObtenerTipoInventario()
        {
            return objTipo.ObtenerTipoInventario();
        }

        public List<TipoBE> ObtenerTipoEstadoInventario()
        {
            return objTipo.ObtenerTipoEstadoInventario();
        }

        public List<TipoBE> ObtenerEstadoAtencion()
        {
            return objTipo.ObtenerEstadoAtencion();
        }

        public List<TipoBE> ObtenerTipoMovimiento()
        {
            return objTipo.ObtenerTipoMovimiento();
        }
    }
}
