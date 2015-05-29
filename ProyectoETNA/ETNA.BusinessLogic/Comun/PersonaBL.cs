using ETNA.BusinessEntity.Comun;
using ETNA.BusinessEntity.Logistica;
using ETNA.DataAccess.Comun;
using ETNA.DataAccess.Logistica;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessLogic.Comun
{
    public class PersonaBL
    {
        public List<PersonaBE> Listar()
        {
            try
            {
                PersonaDA objPersonaDA = new PersonaDA();
                return objPersonaDA.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
