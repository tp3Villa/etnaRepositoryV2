using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Data.Compras.Impl.MsSQL
{
    public class OrdenCompraMsSQLDAO : OrdenCompraDAO
    {
        private DConexion cn = new DConexion();

        private static OrdenCompraDAO dOrdenCompra;

        public static OrdenCompraDAO getInstance()
        {
            if (dOrdenCompra == null)
            {
                dOrdenCompra = new OrdenCompraMsSQLDAO();
            }
            return dOrdenCompra;
        }

        /* @Autor GPC
           Modificación: Se agregó filtro de lugar de entrega en el listado de orden de compra
           Fecha: 04/06/2015
         */
        public DataTable DGetAllOrdenCompra(EOrdenCompra EOrdenCompra)
        {
            string sql = "SELECT oc.codOrdenCompra,oc.codRequerimiento,oc.codCotizacion,p.razonSocial,oc.codEstado,e.desEstado,oc.fechaEntrega,oc.lugarEntrega, oc.observacion " +
                              "FROM OrdenCompra oc " +
                              "INNER JOIN Cotizacion c " +
                              "ON oc.codCotizacion = c.codCotizacion " +
                              "INNER JOIN Proveedor p " +
                              "ON c.codProveedor = p.codProveedor " +
                              "INNER JOIN Estado e " +
                              "ON oc.codEstado = e.codEstado " +
                          "WHERE  ( @codOrdenCompra = 0 OR oc.codOrdenCompra = @codOrdenCompra ) " +
                          "AND ( @codRequerimiento = 0 OR oc.codRequerimiento = @codRequerimiento ) " +
                          "AND ( @codEstado = 0 OR oc.codEstado = @codEstado ) AND oc.lugarEntrega like @lugarEntrega ";
            
            SqlDataAdapter adapter = new SqlDataAdapter();
           
            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Configurando los parametros
            command.Parameters.Add("@codOrdenCompra", SqlDbType.Int);
            command.Parameters["@codOrdenCompra"].Value = EOrdenCompra.CodOrdenCompra;
            command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
            command.Parameters["@codRequerimiento"].Value = EOrdenCompra.CodRequerimiento;
            command.Parameters.Add("@codEstado", SqlDbType.Int);
            command.Parameters["@codEstado"].Value = EOrdenCompra.CodEstado;
            command.Parameters.Add("@lugarEntrega", SqlDbType.VarChar);
            command.Parameters["@lugarEntrega"].Value = "%" + EOrdenCompra.LugarEntrega + "%";

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

         public int DUpdateEstadoOrdenCompra(EOrdenCompra eOrdenCompra)
        {
            int i = 0;
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;

                string sql = "UPDATE OrdenCompra " +
                             "SET codEstado = @codEstado " +    
                                  ",fechaActualizacion = @fechaActualizacion " +
                                  ",usuarioModificacion = @usuarioModificacion " +
                             "WHERE codOrdenCompra = @codOrdenCompra";

                // Configurando los parametros
                command.Parameters.Add("@codEstado", SqlDbType.Int);
                command.Parameters["@codEstado"].Value = eOrdenCompra.CodEstado;
                command.Parameters.Add("@fechaActualizacion", SqlDbType.DateTime);
                command.Parameters["@fechaActualizacion"].Value = eOrdenCompra.FechaActualizacion;
                command.Parameters.Add("@usuarioModificacion", SqlDbType.VarChar);
                command.Parameters["@usuarioModificacion"].Value = eOrdenCompra.UsuarioModificacion;
                command.Parameters.Add("@codOrdenCompra", SqlDbType.Int);
                command.Parameters["@codOrdenCompra"].Value = eOrdenCompra.CodOrdenCompra;

                command.CommandText = sql;
                command.Connection = cn.Conectar;
                command.Connection.Open();
                command.ExecuteNonQuery();
                i = 1;
                command.Dispose();
                //command.Connection.Dispose();
                command.Connection.Close();
            }
            catch { throw; }
            return i;
        }

          public int DUpdateOrdenCompra(EOrdenCompra eOrdenCompra)
        {
            int i = 0;
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;

                string sql = "UPDATE OrdenCompra " +
                              "SET fechaEntrega = @fechaEntrega " +
                                  ",lugarEntrega = @lugarEntrega " +
                                  ",observacion = @observacion " +
                                  ",fechaActualizacion = @fechaActualizacion " +
                                  ",usuarioModificacion = @usuarioModificacion " +
                             "WHERE codOrdenCompra = @codOrdenCompra";

                // Configurando los parametros
               /* command.Parameters.Add("@codMoneda", SqlDbType.Int);
                command.Parameters["@codMoneda"].Value = eOrdenCompra.CodMoneda;*/
                command.Parameters.Add("@fechaEntrega", SqlDbType.DateTime);
                command.Parameters["@fechaEntrega"].Value = eOrdenCompra.FechaEntrega;
                command.Parameters.Add("@lugarEntrega", SqlDbType.VarChar);
                command.Parameters["@lugarEntrega"].Value = eOrdenCompra.LugarEntrega;
                command.Parameters.Add("@observacion", SqlDbType.VarChar);
                command.Parameters["@observacion"].Value = eOrdenCompra.Observacion;
                command.Parameters.Add("@fechaActualizacion", SqlDbType.DateTime);
                command.Parameters["@fechaActualizacion"].Value = eOrdenCompra.FechaActualizacion;
                command.Parameters.Add("@usuarioModificacion", SqlDbType.VarChar);
                command.Parameters["@usuarioModificacion"].Value = eOrdenCompra.UsuarioModificacion;
                command.Parameters.Add("@codOrdenCompra", SqlDbType.Int);
                command.Parameters["@codOrdenCompra"].Value = eOrdenCompra.CodOrdenCompra;

                command.CommandText = sql;
                command.Connection = cn.Conectar;
                command.Connection.Open();
                command.ExecuteNonQuery();
                i = 1;
                command.Dispose();
                //command.Connection.Dispose();
                command.Connection.Close();
            }
            catch { throw; }
            return i;
        }
        

         public int DInsertOrdenCompra(EOrdenCompra eOrdenCompra, List<EOrdenCompraDetalle> listaEOrdenCompraDetalle)
         {
             int i = 0;
                    
             cn.Conectar.Open();
             SqlTransaction transaction = cn.Conectar.BeginTransaction();
             try
             {
                 // Se registra la cabecera de la Orden de Compra
                 SqlCommand command = new SqlCommand();
                 command.CommandType = CommandType.Text;
                 string sql = "INSERT INTO OrdenCompra " +
                                   "(codRequerimiento,codCotizacion,codEstado,igv,fechaEntrega,lugarEntrega " +
                                   ",observacion,fechaRegistro,usuarioRegistro) " +
                               "VALUES " +
                               "(@codRequerimiento,@codCotizacion,@codEstado,@igv,@fechaEntrega,@lugarEntrega " +
                               ",@observacion,@fechaRegistro,@usuarioRegistro) ";

                 command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
                 command.Parameters["@codRequerimiento"].Value = eOrdenCompra.CodRequerimiento;
                 command.Parameters.Add("@codCotizacion", SqlDbType.Int);
                 command.Parameters["@codCotizacion"].Value = eOrdenCompra.CodCotizacion;
                 /*command.Parameters.Add("@codMoneda", SqlDbType.Int);
                 command.Parameters["@codMoneda"].Value = eOrdenCompra.CodMoneda;*/
                 command.Parameters.Add("@codEstado", SqlDbType.Int);
                 command.Parameters["@codEstado"].Value = eOrdenCompra.CodEstado;
                 command.Parameters.Add("@igv", SqlDbType.Decimal);
                 command.Parameters["@igv"].Value = eOrdenCompra.Igv;
                 command.Parameters.Add("@fechaEntrega", SqlDbType.DateTime);
                 command.Parameters["@fechaEntrega"].Value = eOrdenCompra.FechaEntrega;
                 command.Parameters.Add("@lugarEntrega", SqlDbType.VarChar);
                 command.Parameters["@lugarEntrega"].Value = eOrdenCompra.LugarEntrega;
                 command.Parameters.Add("@observacion", SqlDbType.VarChar);
                 command.Parameters["@observacion"].Value = eOrdenCompra.Observacion;
                 command.Parameters.Add("@fechaRegistro", SqlDbType.DateTime);
                 command.Parameters["@fechaRegistro"].Value = eOrdenCompra.FechaEntrega;
                 command.Parameters.Add("@usuarioRegistro", SqlDbType.VarChar);
                 command.Parameters["@usuarioRegistro"].Value = eOrdenCompra.UsuarioRegistro;
                 
                 command.CommandText = sql;
                 command.Connection = cn.Conectar;
                 command.Transaction = transaction;
                 command.ExecuteNonQuery();

                 // Se obtiene el codigo de la Orden de Compra registrada
                 command = new SqlCommand();
                 command.CommandType = CommandType.Text;
                 sql = "SELECT Max(oc.codOrdenCompra) AS corr FROM OrdenCompra oc";
                 
                 command.CommandText = sql;
                 command.Connection = cn.Conectar;
                 command.Transaction = transaction;
                 int codOrdenCompra = (int)command.ExecuteScalar();

                 // Se registra el detalle de la Orden de Compra
                 foreach (EOrdenCompraDetalle eOrdenCompraDetalle in listaEOrdenCompraDetalle)
                 {
                     command = new SqlCommand();
                     command.CommandType = CommandType.Text;
                     sql = "INSERT INTO OrdenCompraDetalle " +
                               "(codOrdenCompra,idProducto,cantidad,precioUnidad,descuento) " +
                           "VALUES " +
                               "(@codOrdenCompra,@idProducto,@cantidad,@precioUnidad,@descuento) ";

                     command.Parameters.Add("@codOrdenCompra", SqlDbType.Int);
                     command.Parameters["@codOrdenCompra"].Value = codOrdenCompra;
                     command.Parameters.Add("@idProducto", SqlDbType.Int);
                     command.Parameters["@idProducto"].Value = eOrdenCompraDetalle.IdProducto;
                     command.Parameters.Add("@cantidad", SqlDbType.Int);
                     command.Parameters["@cantidad"].Value = eOrdenCompraDetalle.Cantidad;
                     command.Parameters.Add("@precioUnidad", SqlDbType.Decimal);
                     command.Parameters["@precioUnidad"].Value = eOrdenCompraDetalle.PrecioUnidad;
                     command.Parameters.Add("@descuento", SqlDbType.Decimal);
                     command.Parameters["@descuento"].Value = eOrdenCompraDetalle.Descuento;

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

    }
}
