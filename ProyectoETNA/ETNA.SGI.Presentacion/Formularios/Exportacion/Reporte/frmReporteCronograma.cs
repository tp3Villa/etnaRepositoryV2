using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETNA.SGI.Bussiness.Exportacion;
using ETNA.SGI.Entity.Exportacion;

namespace ETNA.SGI.Presentacion.Formularios.Exportacion.Reporte
{
    public partial class frmReporteCronograma : Form
    {
        public frmReporteCronograma()
        {
            InitializeComponent();
        }

        private BTablas bTablas = BTablas.getInstance();

        public string codSolicitud = "";

        private void frmReporteCronograma_Load(object sender, EventArgs e)
        {
           
        }

        private void frmReporteCronograma_Load_1(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();


            dt = bTablas.getSELECTLIBRE("SELECT cod_solicitud,Razon_Social,fec_esp_cab_req,D.idProducto,P.descripcionProducto,cantidad FROM SolicitudAtencion AS S LEFT OUTER JOIN " +
" Requerimiento AS R ON (S.Cod_Cab_Req=R.Cod_Cab_Req) LEFT OUTER JOIN " +
" Requerimiento_Detalle AS D ON(R.Cod_Cab_Req=D.Cod_Det_Req) LEFT OUTER JOIN " +
" CLIENTE AS C ON(R.Cod_Cliente=C.Cod_Cliente) LEFT OUTER JOIN " +
" producto AS P ON (D.idProducto=P.idProducto) " +
" WHERE S.Estado_Solicitud='X' and cod_solicitud in (" + codSolicitud + ")");

            List<eCronogramaDespacho> lst = new List<eCronogramaDespacho>();
            eCronogramaDespacho entidad = new eCronogramaDespacho();

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                entidad = new eCronogramaDespacho();
                entidad.Cod_solicitud = Convert.ToInt16(dt.Rows[i]["cod_solicitud"].ToString());
                entidad.Razon_Social1 = dt.Rows[i]["Razon_Social"].ToString();
                entidad.Fec_esp_cab_req = dt.Rows[i]["fec_esp_cab_req"].ToString();
                entidad.IdProducto = Convert.ToInt16(dt.Rows[i]["idProducto"].ToString());
                entidad.DescripcionProducto = dt.Rows[i]["descripcionProducto"].ToString();
                entidad.Cantidad = Convert.ToInt16(dt.Rows[i]["cantidad"].ToString());
                lst.Add(entidad);
            }


            eCronograma.DataSource = lst;

            this.reportViewer2.RefreshReport();
        }
    }
}
