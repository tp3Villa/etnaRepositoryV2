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
    public class AlmacenDA
    {
        public List<AlmacenBE> Listar()
        {
            try
            {
                List<AlmacenBE> objResult = new List<AlmacenBE>();

                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_almacen_Listar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();
                        
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                AlmacenBE objEntidad = new AlmacenBE();
                                objEntidad.idAlmacen = dr.GetInt32(dr.GetOrdinal("idAlmacen"));
                                objEntidad.descripcionAlmacen = dr.GetString(dr.GetOrdinal("descripcionAlmacen"));
                                objEntidad.idSupervisorAlmacen = dr.GetInt32(dr.GetOrdinal("idSupervisorAlmacen"));
                                objEntidad.direccion = dr.GetString(dr.GetOrdinal("direccion"));
                                objEntidad.ubigeo = dr.GetString(dr.GetOrdinal("ubigeo"));
                                objEntidad.telefono = dr.GetString(dr.GetOrdinal("telefono"));
                                objEntidad.tipoAlmacen = dr.GetInt32(dr.GetOrdinal("tipoAlmacen"));
                                //objEntidad.metraje = dr.GetFloat(dr.GetOrdinal("metraje"));
                                objEntidad.activo = dr.GetInt32(dr.GetOrdinal("activo"));

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
