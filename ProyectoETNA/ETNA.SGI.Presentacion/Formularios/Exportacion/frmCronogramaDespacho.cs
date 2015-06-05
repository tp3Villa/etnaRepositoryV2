using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;
using ETNA.SGI.Bussiness.Exportacion;
using ETNA.SGI.Utils;



namespace ETNA.SGI.Presentacion.Formularios.Exportacion
{
    public partial class frmCronogramaDespacho : Form
    {
        public frmCronogramaDespacho()
        {
            InitializeComponent();
        }

        TControlVB oControl = new TControlVB();

        DataTable dtSolicitud = new DataTable();
        public static Boolean Actualiza;

        private BTablas bTablas = BTablas.getInstance();
        private BTransaccion bTransaccion = BTransaccion.getInstance();

        private void frmCronogramaDespacho_Load(object sender, EventArgs e)
        {
            dataGridView1.GridColor = Color.Red;
            dtSolicitud = bTablas.getSELECTLIBRE("SELECT cod_solicitud,S.Cod_Cab_Req AS cod_cab_req_solicitud,razon_social,Convert(varchar(10), fec_res_esp_solicitud,103) AS fec_res_esp_solicitud FROM SolicitudAtencion AS S LEFT OUTER JOIN " +
" Requerimiento AS R ON (S.Cod_Cab_Req=R.Cod_Cab_Req) LEFT OUTER JOIN " +
" cliente AS C ON (R.Cod_Cliente=C.Cod_Cliente) where estado_solicitud='S'");
            dataGridView1.DataSource = dtSolicitud; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string razon = txtRazon.Text.Trim();
            decimal Desde = Convert.ToDecimal(dtDesde.Value.Year.ToString() + dtDesde.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtDesde.Value.Day.ToString("00", CultureInfo.InvariantCulture));
            decimal hasta = Convert.ToDecimal(dtHasta.Value.Year.ToString() + dtHasta.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtHasta.Value.Day.ToString("00", CultureInfo.InvariantCulture));


            dataGridView1.GridColor = Color.Red;
            //objBus = new BTablas();
            dtSolicitud = bTablas.getSELECTLIBRE("SELECT cod_solicitud,S.Cod_Cab_Req AS cod_cab_req_solicitud,razon_social,Convert(varchar(10), fec_res_esp_solicitud,103) AS fec_res_esp_solicitud FROM SolicitudAtencion AS S LEFT OUTER JOIN " +
" Requerimiento AS R ON (S.Cod_Cab_Req=R.Cod_Cab_Req) LEFT OUTER JOIN " +
" cliente AS C ON (R.Cod_Cliente=C.Cod_Cliente) WHERE RAZON_SOCIAL LIKE '%" + razon + "%' AND fec_res_esp_solicitud BETWEEN '" + Desde + "' AND '" + hasta + "' and estado_solicitud='S'");
            dataGridView1.DataSource = dtSolicitud;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string condi = "";
            foreach (DataGridViewRow fees_row in this.dataGridView1.Rows)
            {
                var cell = fees_row.Cells[0];
                var cell1 = fees_row.Cells["cod_solicitud"];
                if (cell.Value != null)
                {
                    var value = cell.Value;
                    if (value != null && (bool)value == true)
                    {
                        condi = condi + cell1.Value.ToString() + ",";
                    }
                }

            }
            if (condi == "")
            {
                 MessageBox.Show("Seleccione Solicitudes", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }

            condi = condi.Substring(0, condi.Length - 1);
            //MessageBox.Show(condi);

            if (MessageBox.Show("¿Desea Generar Despacho?", "Exportación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int K = bTransaccion.BTransaccionVarias("UPDATE dbo.SolicitudAtencion SET Estado_Solicitud='X' where Cod_Solicitud IN (" + condi + ")");
                MessageBox.Show("Despacho se generó correctamente", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Actualiza = true;
                Reporte.frmReporteCronograma frm = new Reporte.frmReporteCronograma();
                frm.codSolicitud = condi;
                frm.ShowDialog();
            }              


            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.GridColor = Color.Red;
            //objBus = new BTablas();
            dtSolicitud = bTablas.getSELECTLIBRE("SELECT cod_solicitud,S.Cod_Cab_Req AS cod_cab_req_solicitud,razon_social,Convert(varchar(10), fec_res_esp_solicitud,103) AS fec_res_esp_solicitud FROM SolicitudAtencion AS S LEFT OUTER JOIN " +
" Requerimiento AS R ON (S.Cod_Cab_Req=R.Cod_Cab_Req) LEFT OUTER JOIN  " +
" cliente AS C ON (R.Cod_Cliente=C.Cod_Cliente) where estado_solicitud='S'");
            dataGridView1.DataSource = dtSolicitud;
            txtRazon.Text = "";
            txtRazon.Focus();
            dtDesde.Value = DateTime.Now;
            dtHasta.Value = DateTime.Now;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCronogramaDespacho_Activated(object sender, EventArgs e)
        {
            if (Actualiza == true)
            {
                dataGridView1.GridColor = Color.Red;
                //objBus = new BTablas();
                dtSolicitud = bTablas.getSELECTLIBRE("SELECT cod_solicitud,S.Cod_Cab_Req AS cod_cab_req_solicitud,razon_social,Convert(varchar(10), fec_res_esp_solicitud,103) AS fec_res_esp_solicitud FROM SolicitudAtencion AS S LEFT OUTER JOIN " +
" Requerimiento AS R ON (S.Cod_Cab_Req=R.Cod_Cab_Req) LEFT OUTER JOIN  " +
" cliente AS C ON (R.Cod_Cliente=C.Cod_Cliente) where estado_solicitud='S'");
                dataGridView1.DataSource = dtSolicitud;
                txtRazon.Text = "";
                txtRazon.Focus();
                dtDesde.Value = DateTime.Now;
                dtHasta.Value = DateTime.Now;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString());
            if (e.ColumnIndex == 1)
            {
                try
                {
                    int p = dataGridView1.CurrentRow.Index;
                    Formularios.Exportacion.frmRegistroSolicitudAtencion frm = new frmRegistroSolicitudAtencion();
                    frm.Opcion = "VIS";
                    frm.CorrSOLUPD = dataGridView1.Rows[p].Cells["cod_solicitud"].Value.ToString();
                    frm.CorrREQUPD = dataGridView1.Rows[p].Cells["cod_cab_req_solicitud"].Value.ToString();
                    frm.ShowDialog();
                }
                catch { }
            }
        }

        private void txtRazon_KeyPress(object sender, KeyPressEventArgs e)
        {
            oControl.ValidarCajaTexto(e, e.KeyChar);
        }
    }
}
