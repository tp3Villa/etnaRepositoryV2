using ETNA.BusinessEntity.Logistica;
using ETNA.DataAccess.Logistica;
using System;
using System.Collections.Generic;
using System.Text;
namespace ETNA.BusinessLogic.Logistica
{
    public class DetalleDocumentoPendienteBL
    {
        public List<DetalleDocumentoPendienteBE> Listar(int paramidDocPendiente)
        {
            try
            {
                DetalleDocumentoPendienteDA objDetalleDocumentoPendienteDA = new DetalleDocumentoPendienteDA();
                return objDetalleDocumentoPendienteDA.Listar(paramidDocPendiente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
