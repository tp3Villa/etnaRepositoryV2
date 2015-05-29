using ETNA.SGI.Data.Compras;
using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Bussiness.Compras
{
    public class BEstado : BBase
    {

        private static BEstado bEstado;

        public static BEstado getInstance()
        {
            if (bEstado == null)
            {
                bEstado = new BEstado();
            }
            return bEstado;
        }

        private EstadoDAO dEstado;

        public BEstado()
        {
            this.dEstado = ObjFactoryDAO.getEstadoDAO();
        } 
        
        public DataTable ObtenerListadoEstadoPorOrdenCompra()
        {
            return dEstado.DGetAllEstadoByOrdenCompra();
        }

        public DataTable ObtenerListadoEstadoPorCotizacion()
        {
            return dEstado.DGetAllEstadoByCotizacion();
        }
    }
}
