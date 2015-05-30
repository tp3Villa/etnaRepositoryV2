using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Entity.Compras;
using System.Data;
using System.Data.SqlClient;

namespace ETNA.SGI.Data.Compras.Impl.MsSQL
{
    public class ProductoMsSQLDAO : ProductoDAO
    {
        private DConexion cn = new DConexion();

        private static ProductoDAO dProducto;

        public static ProductoDAO getInstance()
        {
            if (dProducto == null)
            {
                dProducto = new ProductoMsSQLDAO();
            }
            return dProducto;
        }

        public List<EProducto> ListarPorCategoria(int codCategoria)
        {
            List<EProducto> lista = null;
            using (SqlConnection connection = cn.Conectar)
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "usp_listarProductosxCategoria";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = codCategoria;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        lista = new List<EProducto>();
                        while (reader.Read())
                        {
                            EProducto art = new EProducto();
                            art.IdProducto = reader.GetInt32(0);
                            art.CodCategoria = reader.GetInt32(1);
                            art.DesCategoria = reader.GetString(2);
                            art.CodMarca = reader.GetInt32(3);
                            art.DesMarca = reader.GetString(4);
                            art.DescripcionProducto = reader.GetString(5);
                            art.TipoUnidadMedida = reader.GetString(6);
                            lista.Add(art);
                        }
                    }
                }
            }
            return lista;
        }

        public List<EProducto> ListarPorCategoriaYMarca(int codCategoria, int codMarca)
        {
            List<EProducto> lista = null;
            using (SqlConnection connection = cn.Conectar)
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "usp_listarProductosxCategoriaMarca";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = codCategoria;
                    cmd.Parameters.Add("@CodMarca", SqlDbType.Int).Value = codMarca;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        lista = new List<EProducto>();
                        while (reader.Read())
                        {
                            EProducto art = new EProducto();
                            art.IdProducto = reader.GetInt32(0);
                            art.CodCategoria = reader.GetInt32(1);
                            art.DesCategoria = reader.GetString(2);
                            art.CodMarca = reader.GetInt32(3);
                            art.DesMarca = reader.GetString(4);
                            art.DescripcionProducto = reader.GetString(5);
                            art.TipoUnidadMedida = reader.GetString(6);
                            lista.Add(art);
                        }
                    }
                }
            }
            return lista;   
        }
    }
}
