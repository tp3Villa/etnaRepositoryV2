using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Exportacion
{
    public class EReqDetalle
    {
        private decimal cod_Det_Req;

        public decimal Cod_Det_Req
        {
            get { return cod_Det_Req; }
            set { cod_Det_Req = value; }
        }
        private decimal cod_Prod_Det_Req;

        public decimal Cod_Prod_Det_Req
        {
            get { return cod_Prod_Det_Req; }
            set { cod_Prod_Det_Req = value; }
        }
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private decimal precio_Unit;

        public decimal Precio_Unit
        {
            get { return precio_Unit; }
            set { precio_Unit = value; }
        }

        private decimal cIF;

        public decimal CIF
        {
            get { return cIF; }
            set { cIF = value; }
        }
        private decimal fOB;

        public decimal FOB
        {
            get { return fOB; }
            set { fOB = value; }
        }
    }
}
