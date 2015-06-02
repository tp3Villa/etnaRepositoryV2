using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Data.Compras.Impl.MsSQL
{
    public class ProveedorMsSQLDAO : ProveedorDAO
    {

        private DConexion cn = new DConexion();

        private static ProveedorDAO dProveedor;

        public static ProveedorDAO getInstance()
        {
            if (dProveedor == null){
                dProveedor = new ProveedorMsSQLDAO();
            }
            return dProveedor;
        }        

        public DataTable DCorrelativoProveedor()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT isnull(MAX(codproveedor),0) + 1 AS corr FROM Proveedor", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable DValidarRUC(string Sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(Sql, cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable DGetAllProveedor(EProveedor EProveedor)
        {
            string sql = "SELECT codProveedor,razonSocial,direccion,telefono,email,ruc,observacion,(CASE codEstado when 5 then 'Activo' else 'Inactivo' end)  estado FROM Proveedor " +
                          "WHERE razonSocial like '%" + EProveedor.RazonSocial + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn.Conectar);
            DataTable tabla = new DataTable();
            try
            {
                da.Fill(tabla);
            }
            catch {  }
            return tabla;
                
        }

        public DataTable DGetAllProveedorActive(EProveedor EProveedor)
        {
            string sql = "SELECT codProveedor,razonSocial,direccion,telefono,email,ruc,observacion FROM Proveedor "+
                " WHERE codEstado =" + EProveedor.CodEstado + " and razonSocial like '%" + EProveedor.RazonSocial + "%'";

            SqlDataAdapter da = new SqlDataAdapter(sql, cn.Conectar);
            DataTable tabla = new DataTable();
            try
            {
                da.Fill(tabla);
            }
            catch { }
            return tabla;

        }

        /* Datos por Proveedor */
        public DataTable DGetProveedorById(EProveedor EProveedor)
        {
            string sql = "SELECT codProveedor,razonSocial,direccion,telefono,email,ruc,observacion,a.codCondicionPago,codEstado, b.desCondicionPago FROM Proveedor a , condicionpago b " +
                          "WHERE codProveedor = " + EProveedor.CodProveedor + " and b.codCondicionPago = a.codCondicionPago";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn.Conectar);
            DataTable tabla = new DataTable();
            try
            {
                da.Fill(tabla);
            }
            catch { }
            return tabla;

        }

        public DataTable DGetProveedorWithStatus(EProveedor EProveedor)
        {
            string sql = "SELECT codProveedor,razonSocial,direccion,telefono,email,ruc,observacion, (CASE codEstado when 5 then 'Activo' else 'Inactivo' end)  estado FROM Proveedor " +
                          "WHERE razonSocial like '%" + EProveedor.RazonSocial + "%' and codEstado ="+EProveedor.CodEstado+"";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn.Conectar);
            DataTable tabla = new DataTable();
            try
            {
                da.Fill(tabla);
            }
            catch { }
            return tabla;

        }

        public int DInsertProveedor(EProveedor EProveedor)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "INSERT INTO Proveedor (codProveedor, razonSocial, direccion, telefono, fechaRegistro, email, ruc, observacion,codCondicionPago,codEstado,usuarioRegistro) " +
                " VALUES (" + EProveedor.CodProveedor + ", '" + EProveedor.RazonSocial + "', '" + EProveedor.Direccion + "', " +
                " " + EProveedor.Telefono + ", '" + EProveedor.FechaRegistro + "', '" + EProveedor.Email + "', " +
                " " + EProveedor.Ruc + ", '" + EProveedor.Observacion + "'" +
                ", '" + EProveedor.CodCondicionPago + "'"  +
                ", '" + EProveedor.CodEstado + "'" +
                ", '" + EProveedor.UsuarioRegistro + "'" +
                ")";


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

        public int DUpdateProveedor(EProveedor EProveedor)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "UPDATE Proveedor" +
                             " SET razonSocial = '" + EProveedor.RazonSocial + "'" +
                              ",direccion = '" + EProveedor.Direccion + "'" +
                              ",telefono = " + EProveedor.Telefono +
                              ",fechaRegistro = '" + EProveedor.FechaRegistro +"'"+
                              ",email = '" + EProveedor.Email + "'" +
                              ",ruc = " + EProveedor.Ruc +
                              ",observacion = '" + EProveedor.Observacion + "'" +
                              ",codCondicionPago = " + EProveedor.CodCondicionPago +
                              ",codEstado = " + EProveedor.CodEstado +
                              ",fechaActualizacion = '" + EProveedor.FechaActualizacion + "'" +
                              ",usuarioModificacion = '" + EProveedor.UsuarioModificacion.Trim() + "'" +
                         " WHERE codProveedor = " + EProveedor.CodProveedor;

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

        public int DDeleteProveedor(int CodProveedor)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "DELETE Proveedor WHERE codProveedor = " + CodProveedor;

                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                i = 1;
                cmd.Dispose();
                cn.Conectar.Dispose();
                cn.Conectar.Close();
            }
            catch { throw; }
            return i;
        }
    }
}
