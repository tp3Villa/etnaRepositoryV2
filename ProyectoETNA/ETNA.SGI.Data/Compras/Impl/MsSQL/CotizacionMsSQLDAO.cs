using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace ETNA.SGI.Data.Compras.Impl.MsSQL
{
    public class CotizacionMsSQLDAO : CotizacionDAO
    {
        private DConexion cn = new DConexion();

        private static CotizacionDAO dCotizacion;

        public static CotizacionDAO getInstance()
        {
            if (dCotizacion == null)
            {
                dCotizacion = new CotizacionMsSQLDAO();
            }
            return dCotizacion;
        }

        public DataTable DCorrelativoCotizacion()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT isnull(max(codCotizacion),0)+1 AS corr FROM Cotizacion", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable getSELECTLIBRE(string SQL)
        {
            SqlDataAdapter da = new SqlDataAdapter(SQL, cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        //Obtener Listado Cotizacion
        public DataTable DGetAllCotizacion(ECotizacion eCotizacion)
        {
            string sql = "SELECT c.codCotizacion,c.codRequerimiento,p.razonSocial,c.descripcion,c.telefono, c.fechaExpiracion,e.desEstado " +
                              "FROM Cotizacion c " +
                              "INNER JOIN Proveedor p " +
                              "ON c.codProveedor = p.codProveedor " +
                              "INNER JOIN Estado e " +
                              "ON c.codEstado = e.codEstado " +
                          "WHERE  ( @codCotizacion = 0 OR c.codCotizacion = @codCotizacion ) " +
                          "AND ( @codRequerimiento = 0 OR c.codRequerimiento = @codRequerimiento ) " +
                          "AND ( @codEstado = 0 OR c.codEstado = @codEstado )";

            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create the SelectCommand.
            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Add the parameters for the SelectCommand.
            command.Parameters.Add("@codCotizacion", SqlDbType.Int);
            command.Parameters["@codCotizacion"].Value = eCotizacion.CodCotizacion;
            command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
            command.Parameters["@codRequerimiento"].Value = eCotizacion.CodRequerimiento;
            command.Parameters.Add("@codEstado", SqlDbType.Int);
            command.Parameters["@codEstado"].Value = eCotizacion.CodEstado;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

        //Obtener Cabecera Cotizaciòn por Id
        public DataTable DGetCotizacionById(ECotizacion eCotizacion)
        {
            string sql = "SELECT c.codCotizacion,c.codRequerimiento,c.codProveedor, p.razonSocial,c.descripcion,c.telefono, c.fechaExpiracion,e.desEstado " +
                              "FROM Cotizacion c " +
                              "INNER JOIN Proveedor p " +
                              "ON c.codProveedor = p.codProveedor " +
                              "INNER JOIN Estado e " +
                              "ON c.codEstado = e.codEstado " +
                          "WHERE  ( @codCotizacion = 0 OR c.codCotizacion = @codCotizacion ) " +
                          "AND ( @codRequerimiento = 0 OR c.codRequerimiento = @codRequerimiento ) " +
                          "AND ( @codEstado = 0 OR c.codEstado = @codEstado )";

            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create the SelectCommand.
            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Add the parameters for the SelectCommand.
            command.Parameters.Add("@codCotizacion", SqlDbType.Int);
            command.Parameters["@codCotizacion"].Value = eCotizacion.CodCotizacion;
            command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
            command.Parameters["@codRequerimiento"].Value = eCotizacion.CodRequerimiento;
            command.Parameters.Add("@codEstado", SqlDbType.Int);
            command.Parameters["@codEstado"].Value = eCotizacion.CodEstado;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }


        //Obtener Estado de Cotización por Id
        public DataTable DGetEstadoCotizacionById(int codCotizacion)
        {
            string sql = "SELECT c.codEstado " +
                              "FROM Cotizacion c " +
                          "WHERE  ( @codCotizacion = 0 OR c.codCotizacion = @codCotizacion ) ";

            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create the SelectCommand.
            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Add the parameters for the SelectCommand.
            command.Parameters.Add("@codCotizacion", SqlDbType.Int);
            command.Parameters["@codCotizacion"].Value = codCotizacion;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

        //Obtener detalle cotizacion por Id
        public DataTable DGetCotizacionDetalleById(ECotizacionDetalle eCotizacionDetalle)
        {
            string sql = "SELECT c.idProducto, p.descripcionProducto, c.cantidad,c.precioUnidad,c.descuento " +
                              "FROM CotizacionDetalle c " +
                               "INNER JOIN Producto p " +
                              "ON c.idProducto = p.idProducto " +
                          "WHERE  ( @codCotizacion = 0 OR c.codCotizacion = @codCotizacion ) ";

            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create the SelectCommand.
            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Add the parameters for the SelectCommand.
            command.Parameters.Add("@codCotizacion", SqlDbType.Int);
            command.Parameters["@codCotizacion"].Value = eCotizacionDetalle.CodCotizacion;
            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;



        }

        //Obtener Detalle Cotizacion
        public DataTable DGetAllCotizacionDetalle(ECotizacionDetalle eCotizacionDetalle)
        {
            string sql = "SELECT c.codCotizacion,c.idProducto,c.cantidad,c.precioUnidad,c.descuento " +
                              "FROM CotizacionDetalle c " +
                          "WHERE  ( @codCotizacion = 0 OR c.codCotizacion = @codCotizacion ) " +
                          "AND ( @idProducto = 0 OR c.idProducto = @idProducto ) ";

            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create the SelectCommand.
            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Add the parameters for the SelectCommand.
            command.Parameters.Add("@codCotizacion", SqlDbType.Int);
            command.Parameters["@codCotizacion"].Value = eCotizacionDetalle.CodCotizacion;
            command.Parameters.Add("@idProducto", SqlDbType.Int);
            command.Parameters["@idProducto"].Value = eCotizacionDetalle.IdProducto;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
                        
        }


        //Insertar datos Cotizacion
        public int DInsertCotizacion(ECotizacion eCotizacion,  List<ECotizacionDetalle> listaECotizacionDetalle)
        {
            int i = 0;

            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                // Se registra la cabecera de la Cotizacion
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                string sql = "INSERT INTO Cotizacion (codCotizacion, codRequerimiento ,codProveedor ,descripcion ,telefono ,fechaExpiracion ,codEstado, fechaRegistro, fechaActualizacion, usuarioRegistro, usuarioModificacion) " +
                " VALUES (@codCotizacion, @codRequerimiento, @codProveedor, @descripcion, @telefono, @fechaExpiracion, @codEstado, @fechaRegistro, @fechaActualizacion, @usuarioRegistro, @usuarioActualizacion)";

                // Configurando los parametros
                command.Parameters.Add("@codCotizacion", SqlDbType.Int);
                command.Parameters["@codCotizacion"].Value = eCotizacion.CodCotizacion;
                command.Parameters.Add("@codRequerimiento", SqlDbType.Int);
                command.Parameters["@codRequerimiento"].Value = eCotizacion.CodRequerimiento;
                command.Parameters.Add("@codProveedor", SqlDbType.Int);
                command.Parameters["@codProveedor"].Value = eCotizacion.CodProveedor;
                command.Parameters.Add("@descripcion", SqlDbType.VarChar);
                command.Parameters["@descripcion"].Value = eCotizacion.Descripcion;
                command.Parameters.Add("@telefono", SqlDbType.Int);
                command.Parameters["@telefono"].Value = eCotizacion.Telefono;
                command.Parameters.Add("@fechaExpiracion", SqlDbType.Date);
                command.Parameters["@fechaExpiracion"].Value = eCotizacion.FechaExpiracion;
                command.Parameters.Add("@codEstado", SqlDbType.Int);
                command.Parameters["@codEstado"].Value = eCotizacion.CodEstado;
                command.Parameters.Add("@fechaRegistro", SqlDbType.DateTime);
                command.Parameters["@fechaRegistro"].Value = eCotizacion.FechaRegistro;
                command.Parameters.Add("@fechaActualizacion", SqlDbType.DateTime);
                command.Parameters["@fechaActualizacion"].Value = eCotizacion.FechaActualizacion;
                command.Parameters.Add("@usuarioRegistro", SqlDbType.VarChar);
                command.Parameters["@usuarioRegistro"].Value = eCotizacion.UsuarioRegistro;
                command.Parameters.Add("@usuarioActualizacion", SqlDbType.VarChar);
                command.Parameters["@usuarioActualizacion"].Value = eCotizacion.UsuarioModificacion;

                command.CommandText = sql;
                command.Connection = cn.Conectar;
                command.Transaction = transaction;
                command.ExecuteNonQuery();

                // Se obtiene el codigo de la cotizacion registrada

                int codCotizacion = eCotizacion.CodCotizacion;

                // Se registra el detalle de la Orden de Compra
                foreach (ECotizacionDetalle eCotizacionDetalle in listaECotizacionDetalle)
                {
                    command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    sql = "INSERT INTO CotizacionDetalle " +
                              "(codCotizacion,idProducto,cantidad,precioUnidad,descuento) " +
                          "VALUES " +
                              "(@codOrdenCompra,@idProducto,@cantidad,@precioUnidad,@descuento) ";

                    command.Parameters.Add("@codOrdenCompra", SqlDbType.Int);
                    command.Parameters["@codOrdenCompra"].Value = codCotizacion;
                    command.Parameters.Add("@idProducto", SqlDbType.Int);
                    command.Parameters["@idProducto"].Value = eCotizacionDetalle.IdProducto;
                    command.Parameters.Add("@cantidad", SqlDbType.Int);
                    command.Parameters["@cantidad"].Value = eCotizacionDetalle.Cantidad;
                    command.Parameters.Add("@precioUnidad", SqlDbType.Decimal);
                    command.Parameters["@precioUnidad"].Value = eCotizacionDetalle.PrecioUnidad;
                    command.Parameters.Add("@descuento", SqlDbType.Decimal);
                    command.Parameters["@descuento"].Value = eCotizacionDetalle.Descuento;

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



        //Actualizar datos Cotizacion
        public int DUpdateCotizacion(ECotizacion eCotizacion, List<ECotizacionDetalle> listaECotizacionDetalle)
        {
            int i = 0;

            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                // Se actualiza datos  la cabecera de Cotizacion
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                string sql = "UPDATE Cotizacion " +
               "SET descripcion = @descripcion " +
                          ",fechaExpiracion = @fechaExpiracion " +
                          ",telefono = @telefono " +
                          ",fechaActualizacion = @fechaActualizacion " +
                          ",usuarioModificacion = @usuarioModificacion " +
                     " WHERE codCotizacion = @codCotizacion ";
              

                // Configurando los parametros
                command.Parameters.Add("@codCotizacion", SqlDbType.Int);
                command.Parameters["@codCotizacion"].Value = eCotizacion.CodCotizacion;
                command.Parameters.Add("@descripcion", SqlDbType.VarChar);
                command.Parameters["@descripcion"].Value = eCotizacion.Descripcion;
                command.Parameters.Add("@telefono", SqlDbType.Int);
                command.Parameters["@telefono"].Value = eCotizacion.Telefono;
                command.Parameters.Add("@fechaExpiracion", SqlDbType.Date);
                command.Parameters["@fechaExpiracion"].Value = eCotizacion.FechaExpiracion;
                command.Parameters.Add("@fechaActualizacion", SqlDbType.DateTime);
                command.Parameters["@fechaActualizacion"].Value = eCotizacion.FechaActualizacion;
                command.Parameters.Add("@usuarioModificacion", SqlDbType.VarChar);
                command.Parameters["@usuarioModificacion"].Value = eCotizacion.UsuarioModificacion;

                command.CommandText = sql;
                command.Connection = cn.Conectar;
                command.Transaction = transaction;
                command.ExecuteNonQuery();

                 // Se actualiza el detalle de la cotizacion
                foreach (ECotizacionDetalle eCotizacionDetalle in listaECotizacionDetalle)
                {
                    command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    sql = "UPDATE CotizacionDetalle " +
                     "SET precioUnidad = @precioUnidad " +
                         ",descuento = @descuento " +
                    " WHERE codCotizacion = @codCotizacion AND idProducto = @idProducto ";

                    command.Parameters.Add("@codCotizacion", SqlDbType.Int);
                    command.Parameters["@codCotizacion"].Value = eCotizacion.CodCotizacion;
                    command.Parameters.Add("@idProducto", SqlDbType.Int);
                    command.Parameters["@idProducto"].Value = eCotizacionDetalle.IdProducto;
                    command.Parameters.Add("@precioUnidad", SqlDbType.Decimal);
                    command.Parameters["@precioUnidad"].Value = eCotizacionDetalle.PrecioUnidad;
                    command.Parameters.Add("@descuento", SqlDbType.Decimal);
                    command.Parameters["@descuento"].Value = eCotizacionDetalle.Descuento;

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

        //Eliminar datos Cotizacion
        public int DDeleteCotizacion(int codCotizacion)
        {
            int i = 0;

            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                // Se actualiza datos  la cabecera de Cotizacion
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                string sql = "DELETE FROM Cotizacion " +
                             "WHERE codCotizacion = @codCotizacion";


                // Configurando los parametros
                command.Parameters.Add("@codCotizacion", SqlDbType.Int);
                command.Parameters["@codCotizacion"].Value = codCotizacion;
              
                command.CommandText = sql;
                command.Connection = cn.Conectar;
                command.Transaction = transaction;
                command.ExecuteNonQuery();

                // Se Elimina el detalle de la Cotizacion

                    command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    sql = "DELETE FROM CotizacionDetalle " +
                    "WHERE codCotizacion = @codCotizacion";

                    command.Parameters.Add("@CodCotizacion", SqlDbType.Int);
                    command.Parameters["@CodCotizacion"].Value = codCotizacion;
                 
                    command.CommandText = sql;
                    command.Connection = cn.Conectar;
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
              

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
        


        /* Aprobación Cotización */
        public DataTable DGetCotizacionAprobacion()
        {
            //string sql = "select codCotizacion ,descripcion , codRequerimiento , fechaExpiracion from Cotizacion a INNER JOIN Proveedor b where a.codEstado = 4 and b.codProveedor = a.codProveedor and codCotizacion not in (select c.codCotizacion from OrdenCompra c where c.codCotizacion = a.codCotizacion and c.codRequerimiento = a.codRequerimiento )";
            string sql = "select codCotizacion ,descripcion , codRequerimiento , fechaExpiracion , b.razonSocial razonSocial, (select sum((x.cantidad * x.precioUnidad ) - x.descuento) from CotizacionDetalle x where x.codCotizacion = a.codCotizacion) as monto from Cotizacion a , proveedor b where b.codProveedor = a.codProveedor and a.codEstado =@codEstado and a.codCotizacion not in (select c.codCotizacion from OrdenCompra c where c.codCotizacion = a.codCotizacion and c.codRequerimiento = a.codRequerimiento ) and a.codRequerimiento not in ( select d.codRequerimiento  from Cotizacion d   where d.codEstado = 2   and d.codRequerimiento = a.codRequerimiento  )";

            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create the SelectCommand.
            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Add the parameters for the SelectCommand.
            command.Parameters.Add("@codEstado", SqlDbType.Int);
            command.Parameters["@codEstado"].Value = 4;
            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

        //Actualiza estado cotizacion
        public int DUpdateEstadoCotizacion(int codCotizacion, int codEstado)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "UPDATE Cotizacion SET codEstado='" + codEstado + "'  WHERE codCotizacion='" + codCotizacion + "'";
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


        public DataTable DGetCotizacionAprobacionWithParameters(DateTime dtFrom , DateTime dtTo, int codRequerimiento , int codProveedor)
        {
            //string sql = "select codCotizacion ,descripcion , codRequerimiento , fechaExpiracion from Cotizacion a INNER JOIN Proveedor b where a.codEstado = 4 and b.codProveedor = a.codProveedor and codCotizacion not in (select c.codCotizacion from OrdenCompra c where c.codCotizacion = a.codCotizacion and c.codRequerimiento = a.codRequerimiento )";
            string sql = "select codCotizacion ,descripcion , codRequerimiento , fechaExpiracion , b.razonSocial razonSocial ,(select sum((x.cantidad * x.precioUnidad ) - x.descuento) from CotizacionDetalle x where x.codCotizacion = a.codCotizacion) as monto  from Cotizacion a , proveedor b where b.codProveedor = a.codProveedor and a.codEstado =@codEstado and a.codCotizacion not in (select c.codCotizacion from OrdenCompra c where c.codCotizacion = a.codCotizacion and c.codRequerimiento = a.codRequerimiento ) and a.codRequerimiento not in ( select d.codRequerimiento  from Cotizacion d  where d.codEstado = 2  and d.codRequerimiento = a.codRequerimiento ) and fechaExpiracion between @dtFrom and @dtTo";

            if (codRequerimiento > 0) {
                sql = sql + " and a.codRequerimiento =" + codRequerimiento;
            }

            if (codProveedor > 0)
            {
                sql = sql + " and a.codProveedor =" + codProveedor;
            }

            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create the SelectCommand.
            SqlCommand command = new SqlCommand(sql, cn.Conectar);

            // Add the parameters for the SelectCommand.
            command.Parameters.Add("@codEstado", SqlDbType.Int);
            command.Parameters["@codEstado"].Value = 4;

            command.Parameters.Add("@dtFrom", SqlDbType.Date);
            command.Parameters["@dtFrom"].Value = dtFrom;

            command.Parameters.Add("@dtTo", SqlDbType.Date);
            command.Parameters["@dtTo"].Value = dtTo;

            adapter.SelectCommand = command;

            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

        public int DUpdateAprobacionCotizacion(ECotizacion ECotizacion)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "UPDATE Cotizacion SET codEstado='" + ECotizacion.CodEstado 
                    + "', usuarioAprobacion='"+ECotizacion.UsuarioAprobacion
                    + "', fechaAprobacion='" + ECotizacion.FechaAprobacion+"'"
                    +"WHERE codCotizacion='" + ECotizacion.CodCotizacion + "'";
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
