using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using ETNA.SGI.Entity.Exportacion;


namespace ETNA.SGI.Data.Exportacion.Impl.MsSQL
{
    public class daoTransaccionSQL : daoITransaccion
    {
        DConexion cn = new DConexion();

        private static daoITransaccion dTransaccion;

        public static daoITransaccion getInstance()
        {
            if (dTransaccion == null)
            {
                dTransaccion = new daoTransaccionSQL();
            }
            return dTransaccion;
        }

        public int DTransaccionVarias(string sql)
        {
            int i = 0;
            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                //cmd.Connection.Open();
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                i = 1;
                //cmd.Dispose();
                //cn.Conectar.Dispose();
                
            }
            catch { transaction.Rollback(); }
            cn.Conectar.Close();
            return i;
        }



        public int DInsertCabReq(eReqCab eReqCab)
        {
            int i = 0;
            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "INSERT INTO Requerimiento (Cod_Cab_Req, Cod_Cliente, Cod_Pais, Destino_Cab_Req, IATA_Cab_Req, Fec_Reg_Cab_Req, Fec_Esp_Cab_Req, Pre_Tot_Cab_Req, Est_Cab_Req, Obs_Cab_Req) " +
                " VALUES (" + eReqCab.Cod_Cab_Req + ", " + eReqCab.Cli_Cab_Req + ", '" + eReqCab.Pais_Cab_Req + "', " +
                " '" + eReqCab.Destino_Cab_Req + "', '" + eReqCab.IATA_Cab_Req + "', " + eReqCab.Fec_Reg_Cab_Req + ", " +
                " " + eReqCab.Fec_Esp_Cab_Req + ", " + eReqCab.Pre_Tot_Cab_Req + ", '" + eReqCab.Est_Cab_Req + "', '" + eReqCab.Obs_Cab_Req + "')";
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                //cmd.Connection.Open();
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                i = 1;
                //cmd.Dispose();
                //cn.Conectar.Dispose();
                //cn.Conectar.Close();
            }
            catch { transaction.Rollback(); }
            cn.Conectar.Close();
            return i;
        }


        public int DInsertDetReq(EReqDetalle eReqDet)
        {
            int i = 0;
            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "INSERT INTO dbo.Requerimiento_Detalle (Cod_Det_Req, idProducto , Cantidad, Precio_Unit, CIF, FOB) " +
                    " VALUES (" + eReqDet.Cod_Det_Req + ", " + eReqDet.Cod_Prod_Det_Req + ", " + eReqDet.Cantidad + "," + eReqDet.Precio_Unit + ", " + eReqDet.CIF + ", " + eReqDet.FOB + ")";
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                //cmd.Connection.Open();
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                i = 1;
                //cmd.Dispose();
                //cn.Conectar.Dispose();
                //cn.Conectar.Close();
            }
            catch { transaction.Rollback(); }
            cn.Conectar.Close();
            return i;
        }

        public int DDeleteCabReq(string REQ)
        {
            int i = 0;
            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "DELETE FROM dbo.Requerimiento WHERE Cod_Cab_Req='" + REQ + "'";
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                //cmd.Connection.Open();
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                i = 1;
                //cmd.Dispose();
                //cn.Conectar.Dispose();
                //cn.Conectar.Close();
            }
            catch { transaction.Rollback(); }            
            cn.Conectar.Close();
            return i;
        }

        public int DDeleteDetReq(string REQ)
        {
            int i = 0;
            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "DELETE FROM Requerimiento_Detalle WHERE Cod_Det_Req='" + REQ + "'";
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                //cmd.Connection.Open();
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                i = 1;
                //cmd.Dispose();
                //cn.Conectar.Dispose();
                //cn.Conectar.Close();
            }
            catch { transaction.Rollback(); }
            cn.Conectar.Close();
            return i;
        }


        public int DUpdateEstadoReq(string REQ)
        {
            int i = 0;
            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "UPDATE dbo.Requerimiento SET Est_Cab_Req='E'  WHERE Cod_Cab_Req='" + REQ + "'";
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                //cmd.Connection.Open();
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                i = 1;
                //cmd.Dispose();
                //cn.Conectar.Dispose();
                //cn.Conectar.Close();
            }
            catch { transaction.Rollback(); }
            cn.Conectar.Close();
            return i;
        }


        public int DInserUsuario(ELogin eLogin)
        {
            int i = 0;
            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "INSERT INTO [Usuario] ([Cod_Usuario],[Pwd_Usuario],[Nom_Usuario],[Tipo_Usuario],[Estado_Usuario],[Filler1]) " +
" VALUES ('" + eLogin.Usuario + "','" + eLogin.Pasw + "','" + eLogin.Nom_Usuario + "','" + eLogin.Tipo_Usuario + "','" + eLogin.Estado_Usuario + "','" + eLogin.Filler1 + "')";
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;                
                //cmd.Connection.Open();
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                i = 1;
                //cmd.Dispose();
                //cn.Conectar.Dispose();
                //cn.Conectar.Close();
            }
            catch { transaction.Rollback(); }
            cn.Conectar.Close();
            return i;
        }

        public int DDeleteUSUARIO(string Usuario)
        {
            int i = 0;
            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "DELETE FROM usuario where Cod_Usuario='" + Usuario + "'";
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                //cmd.Connection.Open();
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                i = 1;
                //cmd.Dispose();
                //cn.Conectar.Dispose();
                //cn.Conectar.Close();
            }
            catch { transaction.Rollback(); }
            cn.Conectar.Close();
            return i;
        }

        public int DUpdateUSUARIO(string Usuario, string SET)
        {
            int i = 0;
            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "update usuario set " + SET + " where Cod_Usuario='" + Usuario + "'";
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                //cmd.Connection.Open();
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                i = 1;
                transaction.Commit();
                //cmd.Dispose();
                //cn.Conectar.Dispose();
                //cn.Conectar.Close();
            }
            catch { transaction.Rollback(); }
            cn.Conectar.Close();
            return i;
        }


        public int DInserUsuMenu(string Usu, string opc)
        {
            int i = 0;
            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string sql = "INSERT INTO [UsuMenu] ([COD_USUARIO] ,[COD_OPCIONMENU]) VALUES " +
                             " ('" + Usu + "','" + opc + "')";
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                //cmd.Connection.Open();
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                i = 1;
                //cmd.Dispose();
                //cn.Conectar.Dispose();
                //cn.Conectar.Close();
            }
            catch { transaction.Rollback(); }
            cn.Conectar.Close();
            return i;
        }

        public int DDeleteUsuMenu(string Usu)
        {
            int i = 0;
            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string sql = "DELETE FROM UsuMenu WHERE COD_USUARIO='" + Usu + "'";
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                //cmd.Connection.Open();
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                i = 1;
                //cmd.Dispose();
                //cn.Conectar.Dispose();
                //cn.Conectar.Close();
            }
            catch { transaction.Rollback(); }
            cn.Conectar.Close();
            return i;
        }



    }
}
