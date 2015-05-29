using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Data.Compras.Impl.MsSQL
{
    public class MonedaMsSQLDAO : MonedaDAO
    {
        private DConexion cn = new DConexion();

        private static MonedaDAO dMoneda;

        public static MonedaDAO getInstance()
        {
            if (dMoneda == null)
            {
                dMoneda = new MonedaMsSQLDAO();
            }
            return dMoneda;
        }

        public DataTable DGetAllMoneda()
        {
            string sql = "SELECT codMoneda,desMoneda FROM Moneda";

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
