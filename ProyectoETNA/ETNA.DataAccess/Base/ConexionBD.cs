using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace ETNA.DataAccess.Base
{
    public static class ConexionBD
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cnETNA"].ConnectionString);
            return cn;
        }
    }
}
