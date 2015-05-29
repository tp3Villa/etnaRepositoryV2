using ETNA.BusinessEntity.Logistica;
using ETNA.DataAccess.Base;
using ETNA.DataAccess.Logistica;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ETNA.BusinessLogic.Logistica
{
    public class DocumentoAlmacenBL
    {
        public bool Insertar(DocumentoAlmacenBE objDocumentoAlmacenBE, List<DetalleDocumentoAlmacenBE> objDetalleDocumentoAlmacenBE)
        {
            bool OperacionExitosa = true;
            try
            {
                DocumentoAlmacenDA objDocumentoAlmacenDA = new DocumentoAlmacenDA();
                DetalleDocumentoAlmacenDA objDetalleDocumentoAlmacenDA = new DetalleDocumentoAlmacenDA();

                //Insertamos cabecera
                OperacionExitosa = objDocumentoAlmacenDA.Insertar(objDocumentoAlmacenBE);
                if (OperacionExitosa)
                {
                    foreach (DetalleDocumentoAlmacenBE item in objDetalleDocumentoAlmacenBE)
                    {
                        //Insertamos detalle
                        item.correlativo = objDocumentoAlmacenBE.correlativo;                        
                        objDetalleDocumentoAlmacenDA.Insertar(item);
                    }
                }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return OperacionExitosa;
        }

        public List<DocumentoAlmacenBE> Listar(int paramTipoMovimiento, int paramCorrelativo = 0)
        {
            try
            {
                DocumentoAlmacenDA objDocumentoAlmacenDA = new DocumentoAlmacenDA();
                return objDocumentoAlmacenDA.Listar(paramTipoMovimiento, paramCorrelativo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
