using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Compras
{
   public class ECondicionPago
    {

        private int codCondicionPago;

        public int CodCondicionPago
        {
            get { return codCondicionPago; }
            set { codCondicionPago = value; }
        }


        private string desCondicionPago;

        public string DesCondicionPago
        {
            get { return desCondicionPago; }
            set { desCondicionPago = value; }
        }
    }
}
