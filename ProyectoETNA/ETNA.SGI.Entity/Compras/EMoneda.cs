using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Compras
{
    public class EMoneda
    {
        private int codMoneda;

        public int CodMoneda
        {
            get { return codMoneda; }
            set { codMoneda = value; }
        }
        private string desMoneda;

        public string DesMoneda
        {
            get { return desMoneda; }
            set { desMoneda = value; }
        }
    }
}
