using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Data.Compras.Impl.MsSQL
{
    public class EstadoMsSQLDAO : EstadoDAO
    {
        private DConexion cn = new DConexion();

        private static EstadoDAO dEstado;

        public static EstadoDAO getInstance()
        {
            if (dEstado == null)
            {
                dEstado = new EstadoMsSQLDAO();
            }
            return dEstado;
        }

        public DataTable DGetAllEstadoByOrdenCompra()
        {
            string sql = "SELECT codEstado,desEstado FROM Estado where codEstado in (4,3)";

            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create the SelectCommand.
            SqlCommand command = new SqlCommand(sql, cn.Conectar);
            
            adapter.SelectCommand = command;
                
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

        public DataTable DGetAllEstadoByCotizacion()
        {
            string sql = "SELECT codEstado,desEstado FROM Estado where codEstado in (4,2)";

            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create the SelectCommand.
            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }
    }
}
