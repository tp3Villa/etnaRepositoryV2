using ETNA.BusinessEntity.Logistica;
using ETNA.DataAccess.Logistica;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessLogic.Logistica
{
    public class AlmacenBL
    {
        public List<AlmacenBE> Listar()
        {
            try
            {
                AlmacenDA objAlmacenDA = new AlmacenDA();
                return objAlmacenDA.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
