using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Compras
{
    public class EEstado
    {
        private int codEstado;

        public int CodEstado
        {
            get { return codEstado; }
            set { codEstado = value; }
        }
        private string desEstado;

        public string DesEstado
        {
            get { return desEstado; }
            set { desEstado = value; }
        }
    }
}
