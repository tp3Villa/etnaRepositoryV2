using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Compras
{
    public class EMarca
    {
        private int codMarca;

        public int CodMarca
        {
            get { return codMarca; }
            set { codMarca = value; }
        }
        private string desMarca;

        public string DesMarca
        {
            get { return desMarca; }
            set { desMarca = value; }
        }
    }
}
