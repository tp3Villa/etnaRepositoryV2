using ETNA.BusinessEntity.Logistica;
using ETNA.DataAccess.Logistica;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessLogic.Logistica
{
    public class LoteBL
    {
        public bool Actualizar(int paramIdLote, int paramBloqueado)
        {
            try
            {
                LoteDA objLoteDA = new LoteDA();
                return objLoteDA.Actualizar(paramIdLote, paramBloqueado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
