using System;
using System.Collections.Generic;
using System.Text;
using ETNA.BusinessEntity;
using ETNA.BusinessEntity.Logistica;
using System.Data.SqlClient;
using System.Data;
using ETNA.DataAccess.Base;
using ETNA.BusinessEntity.Comun;

namespace ETNA.DataAccess.Comun
{
    public class PersonaDA
    {
        public List<PersonaBE> Listar()
        {
            try
            {
                List<PersonaBE> objResult = new List<PersonaBE>();

                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Persona_Listar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                PersonaBE objEntidad = new PersonaBE();
                                objEntidad.idPersona = dr.GetInt32(dr.GetOrdinal("idPersona"));
                                objEntidad.nombres = dr.GetString(dr.GetOrdinal("nombres"));
                                objEntidad.apellidoPaterno = dr.GetString(dr.GetOrdinal("apellidoPaterno"));
                                objEntidad.apellidoMaterno = dr.GetString(dr.GetOrdinal("apellidoMaterno"));
                                objEntidad.NombreCompleto = objEntidad.nombres + " " + objEntidad.apellidoPaterno + " " + objEntidad.apellidoMaterno;

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
