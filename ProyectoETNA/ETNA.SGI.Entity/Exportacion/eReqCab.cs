using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Exportacion
{
    public class eReqCab
    {
        private decimal cod_Cab_Req;

        public decimal Cod_Cab_Req
        {
            get { return cod_Cab_Req; }
            set { cod_Cab_Req = value; }
        }
        private decimal cli_Cab_Req;

        public decimal Cli_Cab_Req
        {
            get { return cli_Cab_Req; }
            set { cli_Cab_Req = value; }
        }
        private string pais_Cab_Req;

        public string Pais_Cab_Req
        {
            get { return pais_Cab_Req; }
            set { pais_Cab_Req = value; }
        }
        private string destino_Cab_Req;

        public string Destino_Cab_Req
        {
            get { return destino_Cab_Req; }
            set { destino_Cab_Req = value; }
        }
        private string iATA_Cab_Req;

        public string IATA_Cab_Req
        {
            get { return iATA_Cab_Req; }
            set { iATA_Cab_Req = value; }
        }
        private decimal fec_Reg_Cab_Req;

        public decimal Fec_Reg_Cab_Req
        {
            get { return fec_Reg_Cab_Req; }
            set { fec_Reg_Cab_Req = value; }
        }
        private decimal fec_Esp_Cab_Req;

        public decimal Fec_Esp_Cab_Req
        {
            get { return fec_Esp_Cab_Req; }
            set { fec_Esp_Cab_Req = value; }
        }
        private decimal pre_Tot_Cab_Req;

        public decimal Pre_Tot_Cab_Req
        {
            get { return pre_Tot_Cab_Req; }
            set { pre_Tot_Cab_Req = value; }
        }
        private string est_Cab_Req;

        public string Est_Cab_Req
        {
            get { return est_Cab_Req; }
            set { est_Cab_Req = value; }
        }
        private string obs_Cab_Req;

        public string Obs_Cab_Req
        {
            get { return obs_Cab_Req; }
            set { obs_Cab_Req = value; }
        }
    }
}
