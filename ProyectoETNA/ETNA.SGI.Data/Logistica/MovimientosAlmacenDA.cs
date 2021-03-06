﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETNA.SGI.Entity.Logistica;

namespace ETNA.SGI.Data.Logistica
{
    public class MovimientosAlmacenDA
    {
        /// <summary>
        /// Retorna los documentos que se encuentran pendientes de atención por el almacén
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<MovimientosAlmacenBE> ObtenerMovimientosAlmacen(MovimientosAlmacenBE oBe)
        {
            List<MovimientosAlmacenBE> listMovimientosAlmacen = new List<MovimientosAlmacenBE>();

            Dictionary<string, object> parameter = new Dictionary<string, object>();

            parameter.Add("@IN_SITUACIONATENCION", oBe.In_situacionAtencion);
            parameter.Add("@IN_IDALMACEN", oBe.In_idAlmacen);
            parameter.Add("@IN_TIPOMOVIMIENTO", oBe.In_tipoMovimiento);

            MovimientosAlmacenBE objMovimientosAlmacen;

            using (IDataReader dr = SqlHelper.Instance.ExecuteReader("SP_DOCUMENTOPENDIENTE_LISTAR", parameter))
            {
                while (dr.Read())
                {
                    objMovimientosAlmacen = new MovimientosAlmacenBE();
                    objMovimientosAlmacen.In_idDocPendiente = dr.GetInt32(dr.GetOrdinal("idDocPendiente"));
                    objMovimientosAlmacen.Ch_numeroDocPendiente = dr.GetString(dr.GetOrdinal("numeroDocPendiente"));
                    objMovimientosAlmacen.Dt_fechaDocumento = dr.GetDateTime(dr.GetOrdinal("fechaDocumento"));
                    objMovimientosAlmacen.Vc_tipoDocumentoPendiente = dr.GetString(dr.GetOrdinal("descripcionDocumentoPendiente"));
                    objMovimientosAlmacen.Vc_situacionAtencion = dr.GetString(dr.GetOrdinal("descripcionSituacionAtencion"));
                    objMovimientosAlmacen.Vc_tipoMovimiento = dr.GetString(dr.GetOrdinal("descripcionTipoMovimiento"));
                    objMovimientosAlmacen.Vc_almacen = dr.GetString(dr.GetOrdinal("descripcionAlmacen"));
                    listMovimientosAlmacen.Add(objMovimientosAlmacen);
                }
            }
            return listMovimientosAlmacen;
        }
        /// <summary>
        /// Retorna los datos de un documento pendiente específico
        /// </summary>
        /// <param name="cod"></param>
        /// <returns></returns>
        public MovimientosAlmacenBE ObtenerDocumentoPendiente(int cod)
        {
            MovimientosAlmacenBE objDocumento = new MovimientosAlmacenBE();

            Dictionary<string, object> parameter = new Dictionary<string, object>();

            parameter.Add("@IN_IDDOCPENDIENTE",cod);

            using (IDataReader dr = SqlHelper.Instance.ExecuteReader("SP_OBTENER_DOCUMENTOPENDIENTE", parameter))
            {
                if (dr.Read())
                {
                    objDocumento.In_idDocPendiente = cod;
                    objDocumento.Vc_tipoMovimiento = dr.GetString(dr.GetOrdinal("tipoMovimiento"));
                    objDocumento.Vc_situacionAtencion = dr.GetString(dr.GetOrdinal("situacionAtencion"));
                    objDocumento.Vc_almacen = dr.GetString(dr.GetOrdinal("almacen"));
                    objDocumento.Dt_fechaDocumento = dr.GetDateTime(dr.GetOrdinal("fechaDocumento"));
                    objDocumento.Vc_areaSolicitante = dr.GetString(dr.GetOrdinal("areaSolicitante"));
                    objDocumento.In_idUsuarioSolicitante = dr.GetInt32(dr.GetOrdinal("usuarioSolicitante"));
                }
            }
            return objDocumento;
        }
    }
}
