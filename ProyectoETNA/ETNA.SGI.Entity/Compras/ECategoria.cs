using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Compras
{
    public class ECategoria
    {
        private int codCategoria;

        public int CodCategoria
        {
            get { return codCategoria; }
            set { codCategoria = value; }
        }
        private string desCategoria;

        public string DesCategoria
        {
            get { return desCategoria; }
            set { desCategoria = value; }
        }
    }
}
