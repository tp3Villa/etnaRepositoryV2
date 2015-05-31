using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace ETNA.SGI.Data.Compras.Impl.MsSQL
{
    public class RequerimientoCompraMsSQLDAO : RequerimientoCompraDAO
    {

        private DConexion cn = new DConexion();

        private static RequerimientoCompraDAO dRequerimientoCompra;

        public static RequerimientoCompraDAO getInstance()
        {
            if (dRequerimientoCompra == null)
            {
                dRequerimientoCompra = new RequerimientoCompraMsSQLDAO();
            }
            return dRequerimientoCompra;
        }

        public DataTable DGetAllRequerimientoCompraCotizacion(ERequerimientoCompra eRequerimientoCompra)
        {
            string sql = "SELECT rc.codRequerimiento, c.desCategoria, rc.fechaRegistro, rc.observacion " +
                              "FROM RequerimientoCompra rc " +
                              "INNER JOIN Categoria c " +
                              "ON rc.codCategoria = c.codCategoria " +
                          "WHERE  ( @codRequerimiento = 0 OR rc.codRequerimiento = @codRequerimiento ) " +
                          "AND ( @codCategoria = 0 OR rc.codCategoria = @codCategoria ) " +
                          "AND rc.codEstado='2' ";

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Configurando los parametros
            command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
            command.Parameters["@codRequerimiento"].Value = eRequerimientoCompra.CodRequerimiento;
            command.Parameters.Add("@codCategoria", SqlDbType.Int);
            command.Parameters["@codCategoria"].Value = eRequerimientoCompra.CodCategoria;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

        public DataTable DGetAllRequerimientoCompraCotizacion_Final(ERequerimientoCompra eRequerimientoCompra)
        {
            string sql = "SELECT rc.codRequerimiento, c.desCategoria, rc.fechaRegistro, rc.observacion " +
                              "FROM RequerimientoCompra rc " +
                              "INNER JOIN Categoria c " +
                              "ON rc.codCategoria = c.codCategoria " +
                          "WHERE  ( @codRequerimiento = 0 OR rc.codRequerimiento = @codRequerimiento ) " +
                          "AND ( @codCategoria = 0 OR rc.codCategoria = @codCategoria ) " +
                          "AND rc.codEstado='2' and rc.codRequerimiento not in ( select d.codRequerimiento " +
                        "from Cotizacion d  where d.codEstado = 2  and d.codRequerimiento = rc.codRequerimiento ) ";

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Configurando los parametros
            command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
            command.Parameters["@codRequerimiento"].Value = eRequerimientoCompra.CodRequerimiento;
            command.Parameters.Add("@codCategoria", SqlDbType.Int);
            command.Parameters["@codCategoria"].Value = eRequerimientoCompra.CodCategoria;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }


        public DataTable DGetAllRequerimientoCompraCotizacionDetalle(string codReq)
        {
            string sql = "SELECT rc.idProducto, p.descripcionProducto, rc.cantidad " +
                              "FROM RequerimientoDetalleCompra rc " +
                              "INNER JOIN Producto p " +
                              "ON rc.idProducto = p.idProducto " +
                          "WHERE  ( @codRequerimiento = 0 OR rc.codRequerimiento = @codRequerimiento ) " ;

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Configurando los parametros
            command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
            command.Parameters["@codRequerimiento"].Value = codReq;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }


        public DataTable DGetAllRequerimientoCompraOrdenCompra(ERequerimientoCompra eRequerimientoCompra)
        {
            string sql = "select rq.codRequerimiento,c.desCategoria, rq.fechaRegistro, rq.usuarioRegistro, rq.observacion from RequerimientoCompra rq " +
                            "INNER JOIN Categoria c " +
                            "ON c.codCategoria = rq.codCategoria " +
                            "INNER JOIN Cotizacion ct " +
                            "ON ct.codRequerimiento = rq.codRequerimiento " +
                         "WHERE rq.codEstado = 2 AND ct.codEstado = 2 AND ct.fechaExpiracion > @fechaExpiracion " +
                         " AND rq.codRequerimiento not in (select oc.codRequerimiento from OrdenCompra oc WHERE oc.codEstado <> 3) " +
                         " AND ( @codRequerimiento = 0 OR rq.codRequerimiento = @codRequerimiento ) " +
                          "AND ( @codCategoria = 0 OR rq.codCategoria = @codCategoria ) ";
            
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Configurando los parametros
            command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
            command.Parameters["@codRequerimiento"].Value = eRequerimientoCompra.CodRequerimiento;
            command.Parameters.Add("@codCategoria", SqlDbType.Int);
            command.Parameters["@codCategoria"].Value = eRequerimientoCompra.CodCategoria;
            command.Parameters.Add("@fechaExpiracion", SqlDbType.Date);
            command.Parameters["@fechaExpiracion"].Value = DateTime.Today.Date;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

        public DataTable DGetAllDetalleByCodRequerimientoCompra(int codRequerimientoCompra)
        {
            string sql = "select rq.codRequerimiento, ct.codCotizacion, pv.razonSocial, ctd.idProducto, pd.descripcionProducto, ctd.cantidad, ctd.precioUnidad, ctd.descuento from RequerimientoCompra rq " +
                            "INNER JOIN Cotizacion ct " +
                            "ON ct.codRequerimiento = rq.codRequerimiento " +
                            "INNER JOIN Proveedor pv " +
                            "ON pv.codProveedor = ct.codProveedor " +
                            "INNER JOIN CotizacionDetalle ctd " +
                            "ON ctd.codCotizacion = ct.codCotizacion " +
                            "INNER JOIN producto pd " +
                            "ON pd.idProducto = ctd.idProducto " +
                         "WHERE rq.codRequerimiento = @codRequerimiento AND ct.codEstado = 2";

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Configurando los parametros
            command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
            command.Parameters["@codRequerimiento"].Value = codRequerimientoCompra;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }


        /* METODOS RICHARD */
        public DataTable ListarPorCodigoPersonal(string usuarioRegistro)
        {
            string sql = "select a.codRequerimiento,a.fechaRegistro, a.observacion, a.codEstado, b.desEstado, a.codCategoria, c.desCategoria " +
                  " from RequerimientoCompra a, Estado b, Categoria c where " +
                  " b.codEstado = a.codEstado and c.codCategoria = a.codCategoria " +
                  " and a.usuarioRegistro = @usuarioRegistro ";

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Configurando los parametros
            command.Parameters.Add("@usuarioRegistro", SqlDbType.VarChar);
            command.Parameters["@usuarioRegistro"].Value = usuarioRegistro;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

        public DataTable ListarPorCodigoPersonalYEstado(string usuarioRegistro, int codEstado)
        {
            string sql = "select a.codRequerimiento,a.fechaRegistro, a.observacion, a.codEstado, b.desEstado, a.codCategoria, c.desCategoria " +
          " from RequerimientoCompra a, Estado b, Categoria c where " +
          " b.codEstado = a.codEstado and c.codCategoria = a.codCategoria " +
          " and a.usuarioRegistro = @usuarioRegistro AND a.codEstado = @codEstado";

 
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Configurando los parametros
            command.Parameters.Add("@usuarioRegistro", SqlDbType.VarChar);
            command.Parameters["@usuarioRegistro"].Value = usuarioRegistro;
            command.Parameters.Add("@codEstado", SqlDbType.Int);
            command.Parameters["@codEstado"].Value = codEstado;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }


        public DataTable ListarPorCodigoReqYEstado(int codRequerimiento, int codEstado)
        {
            string sql = "select a.codRequerimiento,a.fechaRegistro, a.observacion, a.codEstado, b.desEstado, a.codCategoria, c.desCategoria " +
          " from RequerimientoCompra a, Estado b, Categoria c where " +
          " b.codEstado = a.codEstado and c.codCategoria = a.codCategoria " +
          " and a.codRequerimiento = @codRequerimiento AND ( @codEstado = 0 OR a.codEstado = @codEstado)";

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Configurando los parametros
            command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
            command.Parameters["@codRequerimiento"].Value = codRequerimiento;
            command.Parameters.Add("@codEstado", SqlDbType.Int);
            command.Parameters["@codEstado"].Value = codEstado;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }


        public DataTable ListaDetallePorCodigoRequerimiento(int codRequerimiento)
        {
            string sql = "select a.idProducto, b.descripcionProducto, b.codCategoria, c.desCategoria, b.codMarca, d.desMarca, a.cantidad " +
          " from RequerimientoDetalleCompra a, producto b, Categoria c, Marca d " +
          " where b.idProducto = a.idProducto and c.codCategoria = b.codCategoria and d.codMarca = b.codMarca " +
          " and a.codRequerimiento = @codRequerimiento";

             SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Configurando los parametros
            command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
            command.Parameters["@codRequerimiento"].Value = codRequerimiento;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }


        //Insertar datos Requerimiento
        public int Registrar(ERequerimientoCompra eRequerimientoCompra, List<ERequerimientoCompraDetalle> listaERequerimientoCompraDetalle)
        {
            int i = 0;

            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                // Se registra la cabecera de la Cotizacion
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                string sql = "INSERT INTO RequerimientoCompra (codRequerimiento ,codEstado ,codCategoria, fechaRegistro, fechaActualizacion, usuarioRegistro, usuarioModificacion, observacion) " +
                " VALUES (@codRequerimiento, @codEstado, @codCategoria, @fechaRegistro, @fechaActualizacion, @usuarioRegistro, @usuarioActualizacion, @observacion)";

                // Configurando los parametros
                command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
                command.Parameters["@codRequerimiento"].Value = eRequerimientoCompra.CodRequerimiento;
                command.Parameters.Add("@codEstado", SqlDbType.Int);
                command.Parameters["@codEstado"].Value = eRequerimientoCompra.CodEstado;
                command.Parameters.Add("@codCategoria", SqlDbType.Int);
                command.Parameters["@codCategoria"].Value = eRequerimientoCompra.CodCategoria;
                command.Parameters.Add("@fechaRegistro", SqlDbType.DateTime);
                command.Parameters["@fechaRegistro"].Value = eRequerimientoCompra.FechaRegistro;
                command.Parameters.Add("@fechaActualizacion", SqlDbType.DateTime);
                command.Parameters["@fechaActualizacion"].Value = eRequerimientoCompra.FechaActualizacion;
                command.Parameters.Add("@usuarioRegistro", SqlDbType.VarChar);
                command.Parameters["@usuarioRegistro"].Value = eRequerimientoCompra.UsuarioRegistro;
                command.Parameters.Add("@usuarioActualizacion", SqlDbType.VarChar);
                command.Parameters["@usuarioActualizacion"].Value = eRequerimientoCompra.UsuarioModificacion;
                command.Parameters.Add("@observacion", SqlDbType.VarChar);
                command.Parameters["@observacion"].Value = eRequerimientoCompra.Observacion;

                command.CommandText = sql;
                command.Connection = cn.Conectar;
                command.Transaction = transaction;
                command.ExecuteNonQuery();

                // Se obtiene el codigo de la requerimiento registrado

                int codRequerimiento = eRequerimientoCompra.CodRequerimiento;

                // Se registra el detalle de la Orden de Compra
                foreach (ERequerimientoCompraDetalle eRequerimientoCompraDetalle in listaERequerimientoCompraDetalle)
                {
                    command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    sql = "INSERT INTO RequerimientoDetalleCompra " +
                              "(codRequerimiento,idProducto,cantidad) " +
                          "VALUES " +
                              "(@codRequerimiento,@idProducto,@cantidad) ";

                    command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
                    command.Parameters["@codRequerimiento"].Value = codRequerimiento;
                    command.Parameters.Add("@idProducto", SqlDbType.Int);
                    command.Parameters["@idProducto"].Value = eRequerimientoCompraDetalle.IdProducto;
                    command.Parameters.Add("@cantidad", SqlDbType.Int);
                    command.Parameters["@cantidad"].Value = eRequerimientoCompraDetalle.Cantidad;
    

                    command.CommandText = sql;
                    command.Connection = cn.Conectar;
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
                i = 1;
            }
            catch
            {
                transaction.Rollback();
            }
            cn.Conectar.Close();
            return i;
        }


        //Actualizar datos Requerimiento
        public int Actualizar(ERequerimientoCompra eRequerimientoCompra, List<ERequerimientoCompraDetalle> listaERequerimientoCompraDetalle)
        {
            int i = 0;

            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                // Se actualiza datos  la cabecera de Cotizacion
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                string sql = "UPDATE RequerimientoCompra " +
               "SET codCategoria = @codCategoria " +
                          ",observacion = @observacion " +
                          ",fechaActualizacion = @fechaActualizacion " +
                          ",usuarioModificacion = @usuarioModificacion " +
                     " WHERE codRequerimiento = @codRequerimiento ";


                // Configurando los parametros
                command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
                command.Parameters["@codRequerimiento"].Value = eRequerimientoCompra.CodRequerimiento;
                command.Parameters.Add("@codCategoria", SqlDbType.Int);
                command.Parameters["@codCategoria"].Value = eRequerimientoCompra.CodCategoria;
                command.Parameters.Add("@observacion", SqlDbType.VarChar);
                command.Parameters["@observacion"].Value = eRequerimientoCompra.Observacion;
                    command.Parameters.Add("@fechaActualizacion", SqlDbType.DateTime);
                command.Parameters["@fechaActualizacion"].Value = eRequerimientoCompra.FechaActualizacion;
                command.Parameters.Add("@usuarioModificacion", SqlDbType.VarChar);
                command.Parameters["@usuarioModificacion"].Value = eRequerimientoCompra.UsuarioModificacion;

                command.CommandText = sql;
                command.Connection = cn.Conectar;
                command.Transaction = transaction;
                command.ExecuteNonQuery();

                // Se actualiza el detalle de la cotizacion
                foreach (ERequerimientoCompraDetalle eRequerimientoCompraDetalle in listaERequerimientoCompraDetalle)
                {
                    command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    sql = "UPDATE CotizacionDetalle " +
                     "SET cantidad = @cantidad " +
                    " WHERE codRequerimiento = @codRequerimiento AND idProducto = @idProducto ";

                    command.Parameters.Add("@codCotizacion", SqlDbType.Int);
                    command.Parameters["@codCotizacion"].Value = eRequerimientoCompraDetalle.CodRequerimiento;
                    command.Parameters.Add("@idProducto", SqlDbType.Int);
                    command.Parameters["@idProducto"].Value = eRequerimientoCompraDetalle.IdProducto;
                    command.Parameters.Add("@cantidad", SqlDbType.Int);
                    command.Parameters["@cantidad"].Value = eRequerimientoCompraDetalle.Cantidad;

                    command.CommandText = sql;
                    command.Connection = cn.Conectar;
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
                i = 1;
            }
            catch
            {
                transaction.Rollback();
            }
            cn.Conectar.Close();
            return i;
        }


        public void EliminarDetalle(int codRequerimiento)
        {
            using (SqlConnection connection = cn.Conectar)
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "usp_eliminarDetallePorCodigoRequerimiento";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodRequerimiento", SqlDbType.Int).Value = codRequerimiento;
                    cmd.ExecuteNonQuery();
                }
            }
        }

 
        //Actualiza estado requerimiento
        public int ActualizarEstado(int codRequerimiento, int codEstado)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "UPDATE RequerimientoCompra SET codEstado='" + codEstado + "'  WHERE codRequerimiento='" + codRequerimiento + "'";
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                i = 1;
                cmd.Dispose();
                //cn.Conectar.Dispose();
                cn.Conectar.Close();
            }
            catch { throw; }
            return i;
        }


    }
}
