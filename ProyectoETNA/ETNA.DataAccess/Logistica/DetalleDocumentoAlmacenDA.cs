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
    public class DetalleDocumentoAlmacenDA
    {
        public bool Insertar(DetalleDocumentoAlmacenBE objDetalleDocumentoAlmacenBE)
        {
            bool OperacionExitosa = true;
            try
            {
                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_detalleDocumentoAlmacen_Insertar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();

                        cmd.Parameters.AddWithValue("@correlativo", objDetalleDocumentoAlmacenBE.correlativo);
                        cmd.Parameters.AddWithValue("@idDetalleDocAlmacen", objDetalleDocumentoAlmacenBE.idDetalleDocAlmacen);
                        cmd.Parameters.AddWithValue("@idProducto", objDetalleDocumentoAlmacenBE.idProducto);
                        cmd.Parameters.AddWithValue("@cantidad", objDetalleDocumentoAlmacenBE.cantidad);
                        cmd.Parameters.AddWithValue("@idDocPendiente", objDetalleDocumentoAlmacenBE.idDocPendiente);

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

        public List<DetalleDocumentoPendienteBE> Listar(int paramcorrelativo)
        {
            try
            {
                List<DetalleDocumentoPendienteBE> objResult = new List<DetalleDocumentoPendienteBE>();

                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_detalledocumentoAlmacen_Listar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@correlativo", paramcorrelativo);


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
