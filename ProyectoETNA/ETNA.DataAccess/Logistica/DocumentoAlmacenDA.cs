using System;
using System.Collections.Generic;
using System.Text;
using ETNA.BusinessEntity;
using ETNA.BusinessEntity.Logistica;
using System.Data.SqlClient;
using System.Data;
using ETNA.DataAccess.Base;

namespace ETNA.DataAccess.Logistica
{
    public class DocumentoAlmacenDA
    {
        public bool Insertar(DocumentoAlmacenBE objDocumentoAlmacenBE)
        {
            bool OperacionExitosa = true;
            try
            {
                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_documentoAlmacen_Insertar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();

                        cmd.Parameters.Add("@correlativo",SqlDbType.Int).Direction = ParameterDirection.Output;

                        cmd.Parameters.AddWithValue("@idDocPendiente", objDocumentoAlmacenBE.idDocPendiente);                        
                        cmd.Parameters.AddWithValue("@tipoMovimiento", objDocumentoAlmacenBE.tipoMovimiento);
                        cmd.Parameters.AddWithValue("@fechaDocumento", objDocumentoAlmacenBE.fechaDocumento);
                        cmd.Parameters.AddWithValue("@idAlmacen", objDocumentoAlmacenBE.idAlmacen);
                        cmd.Parameters.AddWithValue("@idUsuario", objDocumentoAlmacenBE.idUsuario);

                        cmd.ExecuteNonQuery();

                        objDocumentoAlmacenBE.correlativo = Convert.ToInt32(cmd.Parameters["@correlativo"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                OperacionExitosa = false;
                throw ex;                
            }
            return OperacionExitosa;
        }

        public List<DocumentoAlmacenBE> Listar(int paramTipoMovimiento,int paramCorrelativo)
        {
            try
            {
                List<DocumentoAlmacenBE> objResult = new List<DocumentoAlmacenBE>();

                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_documentoAlmacen_Listar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();

                        if (paramTipoMovimiento!=-1)
                            cmd.Parameters.AddWithValue("@tipoMovimiento", paramTipoMovimiento);

                        if (paramCorrelativo >0)
                            cmd.Parameters.AddWithValue("@correlativo", paramCorrelativo);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                DocumentoAlmacenBE objEntidad = new DocumentoAlmacenBE();
                                objEntidad.correlativo = dr.GetInt32(dr.GetOrdinal("correlativo"));
                                objEntidad.idDocPendiente = dr.GetInt32(dr.GetOrdinal("idDocPendiente"));
                                objEntidad.numeroDocAlmacen = dr.GetString(dr.GetOrdinal("numeroDocAlmacen"));
                                objEntidad.tipoMovimiento = dr.GetInt32(dr.GetOrdinal("tipoMovimiento"));
                                objEntidad.fechaDocumento = dr.GetDateTime(dr.GetOrdinal("fechaDocumento"));
                                objEntidad.idAlmacen = dr.GetInt32(dr.GetOrdinal("idAlmacen"));
                                objEntidad.activo = dr.GetInt32(dr.GetOrdinal("activo"));
                                objEntidad.descripcionAlmacen = dr.GetString(dr.GetOrdinal("descripcionAlmacen"));
                                objEntidad.descripcionTipoMovimiento = dr.GetString(dr.GetOrdinal("descripcionTipoMovimiento"));
                                objEntidad.numeroDocPendiente = dr.GetString(dr.GetOrdinal("numeroDocPendiente"));
                                objEntidad.descripcionDocumentoPendiente = dr.GetString(dr.GetOrdinal("descripcionDocumentoPendiente"));
                                objEntidad.Origen = dr.GetString(dr.GetOrdinal("origen"));
                                objEntidad.centrocosto = dr.GetString(dr.GetOrdinal("centrocosto"));

                                objResult.Add(objEntidad);
                            }
                        }
                        return objResult;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
