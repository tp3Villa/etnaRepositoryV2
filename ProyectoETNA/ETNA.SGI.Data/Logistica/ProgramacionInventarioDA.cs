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
    public class ProgramacionInventarioDA
    {

        public List<ProgramacionInventarioBE> Listar(int paramIdProgInventario, int paramTipoInventario)
        {
            try
            {
                List<ProgramacionInventarioBE> objResult = new List<ProgramacionInventarioBE>();

                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_programacionInventario_Listar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();

                        if (paramIdProgInventario>0)
                            cmd.Parameters.AddWithValue("@idProgInventario", paramIdProgInventario);

                        if (paramTipoInventario != -1)
                            cmd.Parameters.AddWithValue("@tipoInventario", paramTipoInventario);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ProgramacionInventarioBE objEntidad = new ProgramacionInventarioBE();
                                objEntidad.idProgInventario = dr.GetInt32(dr.GetOrdinal("idProgInventario"));
                                objEntidad.tipoInventario = dr.GetInt32(dr.GetOrdinal("tipoInventario"));
                                objEntidad.fechaProgramada = dr.GetDateTime(dr.GetOrdinal("fechaProgramada"));
                                objEntidad.frecuencia = dr.GetInt32(dr.GetOrdinal("frecuencia"));
                                objEntidad.idAlmacen = dr.GetInt32(dr.GetOrdinal("idAlmacen"));
                                objEntidad.idPersona = dr.GetInt32(dr.GetOrdinal("idPersona"));
                                objEntidad.idEstadoInventario = dr.GetInt32(dr.GetOrdinal("idEstadoInventario"));

                                objEntidad.descripcionTipoInventario = dr.GetString(dr.GetOrdinal("descripcionTipoInventario"));
                                objEntidad.Responsable = dr.GetString(dr.GetOrdinal("Responsable"));
                                objEntidad.descripcionAlmacen = dr.GetString(dr.GetOrdinal("descripcionAlmacen"));
                                objEntidad.descripcionEstadoInventario = dr.GetString(dr.GetOrdinal("descripcionEstadoInventario"));

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

        public bool Insertar(ProgramacionInventarioBE objProgramacionInventarioBE)
        {
            bool OperacionExitosa = true;
            try
            {
                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_programacionInventario_Insertar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();

                        cmd.Parameters.AddWithValue("@tipoInventario", objProgramacionInventarioBE.tipoInventario);
                        cmd.Parameters.AddWithValue("@fechaProgramada", objProgramacionInventarioBE.fechaProgramada);
                        cmd.Parameters.AddWithValue("@frecuencia", objProgramacionInventarioBE.frecuencia);
                        cmd.Parameters.AddWithValue("@idAlmacen", objProgramacionInventarioBE.idAlmacen);
                        cmd.Parameters.AddWithValue("@idPersona", objProgramacionInventarioBE.idPersona);
                        cmd.Parameters.AddWithValue("@idEstadoInventario", objProgramacionInventarioBE.idEstadoInventario);
                        cmd.Parameters.AddWithValue("idUsuario", objProgramacionInventarioBE.idUsuario);
                        
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

        public bool Actualizar(ProgramacionInventarioBE objProgramacionInventarioBE)
        {
            bool OperacionExitosa = true;
            try
            {
                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_programacionInventario_Actualizar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();

                        cmd.Parameters.AddWithValue("@idProgInventario", objProgramacionInventarioBE.idProgInventario);
                        cmd.Parameters.AddWithValue("@tipoInventario", objProgramacionInventarioBE.tipoInventario);
                        cmd.Parameters.AddWithValue("@fechaProgramada", objProgramacionInventarioBE.fechaProgramada);                        
                        cmd.Parameters.AddWithValue("@idAlmacen", objProgramacionInventarioBE.idAlmacen);
                        cmd.Parameters.AddWithValue("@idPersona", objProgramacionInventarioBE.idPersona);                                                

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

        public bool Eliminar(int paramIdProgInventario)
        {
            bool OperacionExitosa = true;
            try
            {
                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_programacionInventario_Eliminar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();

                        cmd.Parameters.AddWithValue("@idProgInventario", paramIdProgInventario);
                        
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

        public bool Existe_Inventario(int paramIdProgInventario)
        {
            int idProgInventario = 0;
            bool Existe = false;
            try
            {
                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_programacionInventario_ConsultarReferencia", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();

                        if (paramIdProgInventario > 0)
                            cmd.Parameters.AddWithValue("@idProgInventario", paramIdProgInventario);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {                                
                                 idProgInventario = dr.GetInt32(dr.GetOrdinal("idProgInventario"));                              
                            }
                        }
                        if (idProgInventario > 0)
                            Existe = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Existe;
        }
    }
}
