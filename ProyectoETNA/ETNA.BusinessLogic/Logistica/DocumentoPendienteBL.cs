using ETNA.BusinessEntity.Logistica;
using ETNA.DataAccess.Logistica;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessLogic.Logistica
{
    public class DocumentoPendienteBL
    {
        public List<DocumentoPendienteBE> Listar(int paramSituacionatencion, int paramidDocPendiente = 0)
        {
            try
            {
                DocumentoPendienteDA objDocumentoPendienteDA = new DocumentoPendienteDA();
                return objDocumentoPendienteDA.Listar(paramSituacionatencion, paramidDocPendiente);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool ActualizaSituacion(int paramidDocPendiente, int paramsituacionatencion)
        {
            try
            {
                DocumentoPendienteDA objDocumentoPendienteDA = new DocumentoPendienteDA();
                return objDocumentoPendienteDA.ActualizaSituacion(paramidDocPendiente, paramsituacionatencion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
