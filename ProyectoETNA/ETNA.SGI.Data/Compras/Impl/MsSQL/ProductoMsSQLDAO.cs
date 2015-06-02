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

        public DataTable ListarPorCategoria(int codCategoria)
        {
           string sql = "select a.idProducto, a.codCategoria, b.desCategoria, a.codMarca, c.desMarca, a.descripcionProducto, a.tipounidadMedida " +
                         "from producto a inner join Categoria b " +
                         "on a.codCategoria = b.codCategoria inner join Marca c on a.codMarca = c.codMarca " +
                         "where a.codCategoria = @CodCategoria";

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Configurando los parametros
            command.Parameters.Add("@CodCategoria", SqlDbType.Int);
            command.Parameters["@CodCategoria"].Value = codCategoria;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

        public DataTable ListarPorCategoriaYMarca(int codCategoria, int codMarca)
        {
            string sql = "select a.idProducto, a.codCategoria, b.desCategoria, a.codMarca, c.desMarca, a.descripcionProducto, a.tipounidadMedida " +
                         "from producto a inner join Categoria b " +
                         "on a.codCategoria = b.codCategoria inner join Marca c on a.codMarca = c.codMarca " +
                         "where a.codCategoria = @CodCategoria and a.codMarca = @CodMarca";

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Configurando los parametros
            command.Parameters.Add("@CodCategoria", SqlDbType.Int);
            command.Parameters["@CodCategoria"].Value = codCategoria;
            command.Parameters.Add("@CodMarca", SqlDbType.Int);
            command.Parameters["@CodMarca"].Value = codMarca;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;  
        }
    }
}
