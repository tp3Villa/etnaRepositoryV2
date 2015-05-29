using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Configuration;


namespace ETNA.SGI.Data
{
    public class DConexion
    {
        private SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cn"].ConnectionString);
        public SqlConnection Conectar
        {
            get
            {
                return cn;
            }
        } 
    }
}
