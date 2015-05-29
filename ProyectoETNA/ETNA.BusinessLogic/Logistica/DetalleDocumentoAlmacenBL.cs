using ETNA.BusinessEntity.Logistica;
using ETNA.DataAccess.Logistica;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessLogic.Logistica
{
    public class DetalleDocumentoAlmacenBL
    {
        public List<DetalleDocumentoPendienteBE> Listar(int paramcorrelativo)
        {
            try
            {
                DetalleDocumentoAlmacenDA objDetalleDocumentoAlmacenDA = new DetalleDocumentoAlmacenDA();
                return objDetalleDocumentoAlmacenDA.Listar(paramcorrelativo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
