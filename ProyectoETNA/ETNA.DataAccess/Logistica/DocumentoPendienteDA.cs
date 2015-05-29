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
    public class DocumentoPendienteDA
    {
        public List<DocumentoPendienteBE> Listar(int paramSituacionatencion , int paramidDocPendiente)
        {
            try
            {
                List<DocumentoPendienteBE> objResult = new List<DocumentoPendienteBE>();

                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DocumentoPendiente_Listar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();
                        if (paramSituacionatencion!=-1)
                            cmd.Parameters.AddWithValue("@situacionatencion", paramSituacionatencion);

                        if (paramidDocPendiente>0)
                            cmd.Parameters.AddWithValue("@idDocPendiente", paramidDocPendiente);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                DocumentoPendienteBE objEntidad = new DocumentoPendienteBE();
                                objEntidad.idDocPendiente = dr.GetInt32(dr.GetOrdinal("idDocPendiente"));
                                objEntidad.numeroDocPendiente = dr.GetString(dr.GetOrdinal("numeroDocPendiente"));
                                objEntidad.idClienteProveedor = dr.GetInt32(dr.GetOrdinal("idClienteProveedor"));
                                objEntidad.tipoDocumentoPendiente = dr.GetInt32(dr.GetOrdinal("tipoDocumentoPendiente"));
                                objEntidad.fechaDocumento = dr.GetDateTime(dr.GetOrdinal("fechaDocumento"));
                                objEntidad.situacionatencion = dr.GetInt32(dr.GetOrdinal("situacionatencion"));
                                objEntidad.activo = dr.GetInt32(dr.GetOrdinal("activo"));
                                objEntidad.descripcionSituacionAtencion = dr.GetString(dr.GetOrdinal("descripcionSituacionAtencion"));
                                objEntidad.descripcionDocumentoPendiente = dr.GetString(dr.GetOrdinal("descripcionDocumentoPendiente"));
                                objEntidad.origen = dr.GetString(dr.GetOrdinal("Origen"));                                
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

        public bool ActualizaSituacion(int paramidDocPendiente, int paramsituacionatencion)
        {
            bool OperacionExitosa = true;
            try
            {
                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_documentoPendiente_ActualizarSituacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();

                        cmd.Parameters.AddWithValue("@idDocPendiente", paramidDocPendiente);
                        cmd.Parameters.AddWithValue("@situacionatencion", paramsituacionatencion);
                        
                        cmd.ExecuteNonQuery();

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

    }
}
