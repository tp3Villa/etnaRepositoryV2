using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Data.Compras.Impl.MsSQL
{
    public class CategoriaMsSQLDAO : CategoriaDAO
    {
        private DConexion cn = new DConexion();

        private static CategoriaDAO dCategoria;

        public static CategoriaDAO getInstance()
        {
            if (dCategoria == null)
            {
                dCategoria = new CategoriaMsSQLDAO();
            }
            return dCategoria;
        }

        public DataTable DGetAllCategoria()
        {
            string sql = "SELECT codCategoria,desCategoria FROM Categoria";

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
