using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Entity.Compras;
using System.Data;
using System.Data.SqlClient;


namespace ETNA.SGI.Data.Compras
{
    public class MarcaMsSQLDAO : MarcaDAO
    {
        private DConexion cn = new DConexion();

        private static MarcaDAO dMarca;

        public static MarcaDAO getInstance()
        {
            if (dMarca == null)
            {
                dMarca = new MarcaMsSQLDAO();
            }
            return dMarca;
        }


        public DataTable Lista()
        {
            string sql = "SELECT codMarca,desMarca FROM Marca";

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
