using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace ETNA.SGI.Data.Exportacion.Impl.MsSQL
{
    public class daoLoginSQL : daoILogin
    {
        DConexion cn = new DConexion();


        private static daoILogin dLogin;

        public static daoILogin getInstance()
        {
            if (dLogin == null)
            {
                dLogin = new daoLoginSQL();
            }
            return dLogin;
        }


        public DataTable DLogueo(ETNA.SGI.Entity.Exportacion.ELogin ObjEn)
        {
            DataTable dt = new DataTable();
            try
            {
                string Usuario = ObjEn.Usuario;
                string Pasw = ObjEn.Pasw;
                SqlDataAdapter da = new SqlDataAdapter("select * FROM dbo.Usuario WHERE COD_USUARIO='" + Usuario + "' AND PWD_USUARIO='" + Pasw + "' AND ESTADO_USUARIO='A'", cn.Conectar);

                da.Fill(dt);
            }
            catch { throw; }
            return dt;
        }
    }
}
