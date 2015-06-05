using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;


namespace ETNA.SGI.Data.Exportacion.Impl.MsSQL
{
    public class daoTablasSQL : daoITablas
    {
        DConexion cn = new DConexion();

        private static daoITablas dTablas;

        public static daoITablas getInstance()
        {
            if (dTablas == null)
            {
                dTablas = new daoTablasSQL();
            }
            return dTablas;
        }

       
        public DataTable getSELECTLIBRE(string SQL)
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter(SQL, cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable DPaises()
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Pais", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable DPaisesIATA(string cod_pai)
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT iata_cod,iata_des FROM IATA WHERE IATA_PAIS='" + cod_pai + "'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable DClienteCodRaz()
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("select COD_CLIENTE AS codigo,razon_social from dbo.Cliente", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable DProducto()
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT IDPRODUCTO AS Cod_Prod,DESCRIPCIONPRODUCTO AS Des_Prod,PESO AS Pes_Prod,TIPOUNIDADMEDIDA AS Cod_Unidad,PRE_PROD AS Pre_Prod FROM producto", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable DProductoBusquedaXCodigo(string Bus)
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT IDPRODUCTO AS Cod_Prod,DESCRIPCIONPRODUCTO AS Des_Prod,PESO AS Pes_Prod,TIPOUNIDADMEDIDA AS Cod_Unidad,PRE_PROD AS Pre_Prod FROM producto WHERE IDPRODUCTO='" + Bus + "'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable DCorrelativo()
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT count(*)+1 AS corr FROM Requerimiento", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable DRequerimientoBusquedaXCodigoCliente(string cli)
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT Cod_Cab_Req,Fec_Esp_Cab_Req,(SELECT nom_pais FROM pais AS P WHERE P.Cod_Pais=R.Cod_Pais) AS pais,Destino_Cab_Req FROM Requerimiento AS R WHERE R.COD_CLIENTE='" + cli + "' AND EST_CAB_REQ='A'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable DRequerimientoDetalleXCodREQ(string Req)
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter(" SELECT             R.idProducto AS codProd,            P.descripcionProducto AS desProd,            cantidad AS cantidad, " +
 " pre_prod AS PrecioS,            (cantidad*pre_prod) AS subPrecioS,            P.tipounidadMedida  AS UndMeda,            PESO AS Peso FROM Requerimiento_Detalle AS R " +
 " LEFT OUTER JOIN  Producto AS P ON (R.idProducto= P.idProducto)             WHERE R.Cod_Det_Req='" + Req + "'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable DRequerimientoCabeceraXCodREQ(string Req)
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT COD_CAB_REQ,R.Cod_Pais AS PAIS_CAB_REQ,(SELECT nom_pais FROM Pais AS P WHERE P.Cod_Pais=R.Cod_Pais) AS nompais,DESTINO_CAB_REQ,OBS_CAB_REQ,FEC_ESP_CAB_REQ,FEC_REG_CAB_REQ FROM requerimiento AS R WHERE COD_CAB_REQ='" + Req + "'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }



        public DataTable DRequerimientos()
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT COD_CAB_REQ,RAZON_SOCIAL,R.Cod_Pais AS PAIS_CAB_REQ,NOM_PAIS, " +
 " Fec_Reg_Cab_Req, Fec_Esp_Cab_Req,  " +
 " R.Cod_Cliente AS CLI_CAB_REQ,DESTINO_CAB_REQ,DIRECCION,(SELECT Nom_Pais FROM PAIS AS PAI WHERE PAI.Cod_Pais=C.Cod_Pais) AS PAIS,RUC   " +
  "           FROM Requerimiento AS R LEFT OUTER JOIN  " +
 " CLIENTE AS C ON (R.Cod_Cliente=C.Cod_Cliente) LEFT OUTER JOIN  " +
 " PAIS AS P ON (R.Cod_Pais=P.COD_PAIS) where EST_CAB_REQ='A'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable DRequerimientosBUSQUEDAANIDAD(string Cod_Req, string Razon, decimal desde, decimal hasta)
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT COD_CAB_REQ,RAZON_SOCIAL,R.Cod_Pais AS PAIS_CAB_REQ,NOM_PAIS, " +
  " Fec_Reg_Cab_Req, Fec_Esp_Cab_Req,   " +
  " R.Cod_Cliente AS CLI_CAB_REQ,DESTINO_CAB_REQ,DIRECCION,(SELECT Nom_Pais FROM PAIS AS PAI WHERE PAI.Cod_Pais=C.Cod_Pais) AS PAIS,RUC    " +
   "           FROM Requerimiento AS R LEFT OUTER JOIN   " +
  " CLIENTE AS C ON (R.Cod_Cliente=C.Cod_Cliente) LEFT OUTER JOIN   " +
  " PAIS AS P ON (R.Cod_Pais=P.COD_PAIS) " +
  "  WHERE CAST(R.Cod_Cab_Req AS CHAR(3))+' '+RAZON_SOCIAL LIKE '%" + Cod_Req + "%" + Razon + "%'  " +
 " AND Fec_Reg_Cab_Req BETWEEN " + desde + " AND " + hasta + " AND EST_CAB_REQ='A'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        //Aprobacion de Solicitudes/////////////////////////////////////////////////////////   Taller de Proyecto 3 Uso de Factora y Singleton
        public DataTable DListaSolicitudesPendienteAprobacion(string Estado1, string Estado2, string fecha1, string fecha2, int opcion)
        {
            DataTable dt = new DataTable();

            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CONSULTA_APROBACION_SOLICITUD";
                cmd.Connection = cn.Conectar;
                cmd.Parameters.Add("@estado1", SqlDbType.Char, 1).Value = Estado1;
                cmd.Parameters.Add("@estado2", SqlDbType.Char, 1).Value = Estado2;
                cmd.Parameters.Add("@fecha1", SqlDbType.Char, 8).Value = fecha1;
                cmd.Parameters.Add("@fecha2", SqlDbType.Char, 8).Value = fecha2;
                cmd.Parameters.Add("@opcion", SqlDbType.Int, 1).Value = opcion;
                cmd.Transaction = transaction;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                transaction.Commit();
                //cmd.Dispose();
                //cn.Conectar.Dispose();
            }
            catch { transaction.Rollback(); }
            cn.Conectar.Close();
            return dt;
        }


        //FORMATO COMERCIAL//TALLER DE PORYECTO 3 SINGLETON
        public DataTable DListaDocumentosVersionDetalle(int Estado1, string Estado2, string fecha1, string fecha2, int opcion)
        {
            DataTable dt = new DataTable();

            cn.Conectar.Open();
            SqlTransaction transaction = cn.Conectar.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CONSULTA_DETALLEDOCEXPORTACION";
                cmd.Connection = cn.Conectar;
                cmd.Parameters.Add("@estado1", SqlDbType.Int, 1).Value = Estado1;
                cmd.Parameters.Add("@estado2", SqlDbType.Char, 1).Value = Estado2;
                cmd.Parameters.Add("@fecha1", SqlDbType.Char, 8).Value = fecha1;
                cmd.Parameters.Add("@fecha2", SqlDbType.Char, 8).Value = fecha2;
                cmd.Parameters.Add("@opcion", SqlDbType.Int, 1).Value = opcion;
                cmd.Transaction = transaction;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                transaction.Commit();
                //cmd.Dispose();
                //cn.Conectar.Dispose();
            }
            catch { transaction.Rollback(); }
            cn.Conectar.Close();
            return dt;
        }


       
    }
}
