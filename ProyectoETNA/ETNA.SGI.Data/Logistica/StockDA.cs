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
    public class StockDA
    {
        public bool Actualizar(int paramIdAlmacen, int paramIdProducto, int paramCantidadIngreso, int paramCantidadSalida)
        {
            bool OperacionExitosa = true;
            try
            {
                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_stock_Actualizar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();

                        cmd.Parameters.AddWithValue("@idAlmacen", paramIdAlmacen);
                        cmd.Parameters.AddWithValue("@idProducto", paramIdProducto);
                        cmd.Parameters.AddWithValue("@cantidadIngreso", paramCantidadIngreso);
                        cmd.Parameters.AddWithValue("@cantidadSalida", paramCantidadSalida);                        
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

        public StockBE Consultar(int paramIdAlmacen, int paramIdProducto)
        {
            try
            {
                StockBE objResult = null;

                using (SqlConnection cn = ConexionBD.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_stock_Consultar", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@idAlmacen", paramIdAlmacen);
                        cmd.Parameters.AddWithValue("@idProducto", paramIdProducto);


                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                objResult = new StockBE();

                                objResult.idAlmacen = dr.GetInt32(dr.GetOrdinal("idAlmacen"));
                                objResult.idProducto = dr.GetInt32(dr.GetOrdinal("idProducto"));
                                objResult.idLote = dr.GetInt32(dr.GetOrdinal("idLote"));
                                objResult.cantidad = dr.GetInt32(dr.GetOrdinal("cantidad"));
                                objResult.cantidadReservada = dr.GetInt32(dr.GetOrdinal("cantidadReservada"));
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
