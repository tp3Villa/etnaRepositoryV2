using ETNA.SGI.Data.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Bussiness
{
    public class BBase
    {
        private FactoryDAO objFactoryDAO = FactoryDAO.getFactory(FactoryDAO.MSSQL_FACTORY);

        public FactoryDAO ObjFactoryDAO
        {
            get { return objFactoryDAO; }
            set { objFactoryDAO = value; }
        }

               
    }
}
