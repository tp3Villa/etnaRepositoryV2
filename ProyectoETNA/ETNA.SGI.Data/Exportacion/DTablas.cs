using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;


namespace ETNA.SGI.Data.Exportacion
{
    public class DTablas
    {
        DConexion cn = new DConexion();

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
            SqlDataAdapter da = new SqlDataAdapter("select codigo,razon_social from dbo.Cliente", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable DProducto()
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM producto", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable DProductoBusquedaXCodigo(string Bus)
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM producto WHERE Cod_Prod='" + Bus + "'", cn.Conectar);
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
            SqlDataAdapter da = new SqlDataAdapter("SELECT Cod_Cab_Req,Fec_Esp_Cab_Req,(SELECT nom_pais FROM pais WHERE Cod_Pais=Pais_Cab_Req) AS pais,Destino_Cab_Req FROM Requerimiento WHERE CLI_CAB_REQ='" + cli + "' AND EST_CAB_REQ<>'E'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable DRequerimientoDetalleXCodREQ(string Req)
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter(" SELECT             Cod_Prod_Det_Req AS codProd,            DES_PROD AS desProd,            cantidad AS cantidad, " +
            " pre_prod AS PrecioS,            (cantidad*pre_prod) AS subPrecioS,            cod_unidad AS UndMeda,            pes_prod AS Peso FROM Requerimiento_Detalle " +
            " LEFT OUTER JOIN  Producto ON (Cod_Prod_Det_Req=COD_PROD)             WHERE Cod_Det_Req='" + Req + "'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable DRequerimientoCabeceraXCodREQ(string Req)
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT COD_CAB_REQ,PAIS_CAB_REQ,(SELECT nom_pais FROM Pais WHERE Cod_Pais=PAIS_CAB_REQ ) AS nompais,DESTINO_CAB_REQ,OBS_CAB_REQ,FEC_ESP_CAB_REQ,FEC_REG_CAB_REQ FROM requerimiento WHERE COD_CAB_REQ='" + Req + "'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }



        public DataTable DRequerimientos()
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT COD_CAB_REQ,RAZON_SOCIAL,PAIS_CAB_REQ,NOM_PAIS, " +
" Fec_Reg_Cab_Req, Fec_Esp_Cab_Req,  " +
" CLI_CAB_REQ,DESTINO_CAB_REQ,DIRECCION,(SELECT Nom_Pais FROM PAIS WHERE Cod_Pais=CODPAI) AS PAIS,RUC  " +            
            " FROM Requerimiento LEFT OUTER JOIN " +
" CLIENTE ON (CLI_CAB_REQ=CODIGO) LEFT OUTER JOIN " +
" PAIS ON (PAIS_CAB_REQ=COD_PAIS) where EST_CAB_REQ='A'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable DRequerimientosBUSQUEDAANIDAD(string Cod_Req,string Razon,decimal desde, decimal hasta)
        {
            //iDB2DataAdapter da = new iDB2DataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT COD_CAB_REQ,RAZON_SOCIAL,PAIS_CAB_REQ,NOM_PAIS, " +
" Fec_Reg_Cab_Req, Fec_Esp_Cab_Req, " +
" CLI_CAB_REQ,DESTINO_CAB_REQ,DIRECCION,(SELECT Nom_Pais FROM PAIS WHERE Cod_Pais=CODPAI) AS PAIS,RUC " +
" FROM Requerimiento LEFT OUTER JOIN " +
" CLIENTE ON (CLI_CAB_REQ=CODIGO) LEFT OUTER JOIN " +
" PAIS ON (PAIS_CAB_REQ=COD_PAIS) " +
" WHERE CAST(COD_CAB_REQ AS CHAR(3))+' '+RAZON_SOCIAL LIKE '%" + Cod_Req + "%" + Razon + "%' " +
" AND Fec_Reg_Cab_Req BETWEEN " + desde + " AND " + hasta + " AND EST_CAB_REQ='A'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }
    }
}
