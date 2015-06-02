using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Entity.Compras;
using System.Data;
using System.Data.SqlClient;

namespace ETNA.SGI.Data.Compras
{
    public class PersonaMsSQLDAO : PersonaDAO
    {
        private DConexion cn = new DConexion();

        private static PersonaDAO dPersonal;

        public static PersonaDAO getInstance()
        {
            if (dPersonal == null)
            {
                dPersonal = new PersonaMsSQLDAO();
            }
            return dPersonal;
        }

        public EPersona obtenerPersonalxUsuario(string usuario)
        {
            EPersona personal = null;
            using (SqlConnection connection = cn.Conectar)
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "usp_obtenerPersonalxUsuario";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            personal = new EPersona();
                            personal.IdPersona = reader.GetInt32(0);
                            
                        }
                    }
                }
            }
            return personal;
        }
    }
}
