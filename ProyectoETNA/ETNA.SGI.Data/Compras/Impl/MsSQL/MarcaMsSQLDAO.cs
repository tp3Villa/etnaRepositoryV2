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


        public List<EMarca> Lista()
        {
            List<EMarca> lista = null;
            using (SqlConnection connection = cn.Conectar)
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "usp_listarMarcas";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        lista = new List<EMarca>();
                        while (reader.Read())
                        {
                            EMarca mar = new EMarca();
                            mar.CodMarca = reader.GetInt32(0);
                            mar.DesMarca = reader.GetString(1);
                            lista.Add(mar);
                        }
                    }
                }

            }
            return lista;
        }
    }
}
