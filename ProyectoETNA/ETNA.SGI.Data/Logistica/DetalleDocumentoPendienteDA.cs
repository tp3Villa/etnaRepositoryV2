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
    public class DetalleDocumentoPendienteDA
    {
        public List<DetalleDocumentoPendienteBE> Listar(int paramidDocPendiente)
        {
            try
            {
                List<DetalleDocumentoPendienteBE> objResult = new List<DetalleDocumentoPendienteBE>();

                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DetalleDocumentoPendiente_Listar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@idDocPendiente", paramidDocPendiente);
                        

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                DetalleDocumentoPendienteBE objEntidad = new DetalleDocumentoPendienteBE();
                                objEntidad.idDocPendiente = dr.GetInt32(dr.GetOrdinal("idDocPendiente"));                                
                                objEntidad.idDetalleDocPendiente = dr.GetInt32(dr.GetOrdinal("idDetalleDocPendiente"));
                                objEntidad.idProducto = dr.GetInt32(dr.GetOrdinal("idProducto"));
                                objEntidad.cantidadPedida = dr.GetInt32(dr.GetOrdinal("cantidadPedida"));
                                objEntidad.cantidadAtendida = dr.GetInt32(dr.GetOrdinal("cantidadAtendida"));
                                objEntidad.cantidadPendienteAtencion = objEntidad.cantidadPedida - objEntidad.cantidadAtendida;

                                objEntidad.codigoProducto = dr.GetString(dr.GetOrdinal("codigoProducto"));
                                objEntidad.descripcionProducto = dr.GetString(dr.GetOrdinal("descripcionProducto"));
                                objEntidad.tipounidadMedida = dr.GetInt32(dr.GetOrdinal("tipounidadMedida"));
                                objEntidad.descripcionUnidadMedida = dr.GetString(dr.GetOrdinal("descripcionUnidadMedida"));

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
