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
    public partial class frmAtencionSolicitud : Form
    {
        public frmAtencionSolicitud()
        {
            InitializeComponent();
        }

        TControlVB oControl = new TControlVB();

        DataTable dtSolicitud = new DataTable();
        public static Boolean Actualiza;

        private BTablas bTablas = BTablas.getInstance();
        private BTransaccion bTransaccion = BTransaccion.getInstance();

        private void button3_Click(object sender, EventArgs e)
        {

            Formularios.Exportacion.frmRegistroSolicitudAtencion frm = new frmRegistroSolicitudAtencion();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmAtencionSolicitud_Load(object sender, EventArgs e)
        {
            dtHasta.MinDate = dtDesde.Value;

            dataGridView1.GridColor = Color.Red;
            //objBus = new BTablas();
            dtSolicitud = bTablas.getSELECTLIBRE("SELECT cod_solicitud,S.Cod_Cab_Req AS cod_cab_req_solicitud,razon_social,Convert(varchar(10), fec_reg_solicitud,103) AS fec_reg_solicitud FROM SolicitudAtencion AS S LEFT OUTER JOIN " +
" Requerimiento AS R ON (S.Cod_Cab_Req=R.Cod_Cab_Req) LEFT OUTER JOIN " +
" cliente AS C ON (R.Cod_Cliente=C.Cod_Cliente) where estado_solicitud='A'");
            dataGridView1.DataSource = dtSolicitud;            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string razon = txtRazon.Text.Trim();
            decimal Desde = Convert.ToDecimal(dtDesde.Value.Year.ToString() + dtDesde.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtDesde.Value.Day.ToString("00", CultureInfo.InvariantCulture));
            decimal hasta = Convert.ToDecimal(dtHasta.Value.Year.ToString() + dtHasta.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtHasta.Value.Day.ToString("00", CultureInfo.InvariantCulture));


            dataGridView1.GridColor = Color.Red;
            //objBus = new BTablas();
            dtSolicitud = bTablas.getSELECTLIBRE("SELECT cod_solicitud,S.Cod_Cab_Req AS cod_cab_req_solicitud,razon_social,Convert(varchar(10), fec_reg_solicitud,103) AS fec_reg_solicitud FROM SolicitudAtencion AS S LEFT OUTER JOIN " +
" Requerimiento AS R ON (S.Cod_Cab_Req=R.Cod_Cab_Req) LEFT OUTER JOIN " +
" cliente AS C ON (R.Cod_Cliente=C.Cod_Cliente) WHERE RAZON_SOCIAL LIKE '%" + razon + "%' AND fec_reg_solicitud BETWEEN '" + Desde + "' AND '" + hasta + "' and estado_solicitud='A'");
            dataGridView1.DataSource = dtSolicitud;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.GridColor = Color.Red;
            //objBus = new BTablas();
            dtSolicitud = bTablas.getSELECTLIBRE("SELECT cod_solicitud,S.Cod_Cab_Req AS cod_cab_req_solicitud,razon_social,Convert(varchar(10), fec_reg_solicitud,103) AS fec_reg_solicitud FROM SolicitudAtencion AS S LEFT OUTER JOIN " +
" Requerimiento AS R ON (S.Cod_Cab_Req=R.Cod_Cab_Req) LEFT OUTER JOIN  " +
" cliente AS C ON (R.Cod_Cliente=C.Cod_Cliente) where estado_solicitud='A'");
            dataGridView1.DataSource = dtSolicitud;
            txtRazon.Text = "";
            txtRazon.Focus();
            dtDesde.Value = DateTime.Now;
            dtHasta.Value = DateTime.Now;
        }

        private void frmAtencionSolicitud_Activated(object sender, EventArgs e)
        {
            if (Actualiza == true)
            {
                dataGridView1.GridColor = Color.Red;
                //objBus = new BTablas();
                dtSolicitud = bTablas.getSELECTLIBRE("SELECT cod_solicitud,S.Cod_Cab_Req AS cod_cab_req_solicitud,razon_social,Convert(varchar(10), fec_reg_solicitud,103) AS fec_reg_solicitud FROM SolicitudAtencion AS S LEFT OUTER JOIN " +
" Requerimiento AS R ON (S.Cod_Cab_Req=R.Cod_Cab_Req) LEFT OUTER JOIN  " +
" cliente AS C ON (R.Cod_Cliente=C.Cod_Cliente) where estado_solicitud='A'");
                dataGridView1.DataSource = dtSolicitud;
                txtRazon.Text = "";
                txtRazon.Focus();
                dtDesde.Value = DateTime.Now;
                dtHasta.Value = DateTime.Now;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show(e.ColumnIndex.ToString());
            if (e.ColumnIndex == 0)
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

            if (e.ColumnIndex == 1)
            {
                try
                {
                    int p = dataGridView1.CurrentRow.Index;
                    Formularios.Exportacion.frmRegistroSolicitudAtencion frm = new frmRegistroSolicitudAtencion();
                    frm.Opcion = "UPD";
                    frm.CorrSOLUPD = dataGridView1.Rows[p].Cells["cod_solicitud"].Value.ToString();
                    frm.CorrREQUPD = dataGridView1.Rows[p].Cells["cod_cab_req_solicitud"].Value.ToString();
                    frm.ShowDialog();
                }
                catch { }
            }


            if (e.ColumnIndex == 2)
            {
                try
                {
                    string CodSoli = "";
                    string CodReq = "";

                    int p = dataGridView1.CurrentRow.Index;
                    CodSoli = dataGridView1.Rows[p].Cells["cod_solicitud"].Value.ToString();
                    CodReq = dataGridView1.Rows[p].Cells["cod_cab_req_solicitud"].Value.ToString();

                    if (MessageBox.Show("¿Desea Anular la Solicitud " + CodSoli + "?", "Exportación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //hacemos la reversa de todo sino se ha aprobado
                        int y = 0;
                        //objTra = new BTransaccion();
                        y = bTransaccion.BTransaccionVarias("UPDATE SolicitudAtencion SET estado_solicitud='E' WHERE cod_solicitud=" + CodSoli);

                        //objTra = new BTransaccion();
                        y = bTransaccion.BTransaccionVarias("DELETE FROM DocProdReq WHERE Cod_Cab_Req=" + CodReq);

                        //objTra = new BTransaccion();
                        y = bTransaccion.BTransaccionVarias("UPDATE dbo.Requerimiento SET IATA_CAB_REQ='',EST_CAB_REQ='A' WHERE Cod_Cab_Req=" + CodReq);

                        //objTra = new BTransaccion();
                        y = bTransaccion.BTransaccionVarias("UPDATE dbo.Requerimiento_Detalle SET CIF=0,FOB=0 WHERE Cod_Det_Req=" + CodReq);

                        MessageBox.Show("solicitud Anulada correctamente", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        dataGridView1.GridColor = Color.Red;
                        //objBus = new BTablas();
                        dtSolicitud = bTablas.getSELECTLIBRE("SELECT cod_solicitud,S.Cod_Cab_Req AS cod_cab_req_solicitud,razon_social,Convert(varchar(10), fec_reg_solicitud,103) AS fec_reg_solicitud FROM SolicitudAtencion AS S LEFT OUTER JOIN " +
" Requerimiento AS R ON (S.Cod_Cab_Req=R.Cod_Cab_Req) LEFT OUTER JOIN  " +
" cliente AS C ON (R.Cod_Cliente=C.Cod_Cliente) where estado_solicitud='A'");
                        dataGridView1.DataSource = dtSolicitud;
                        txtRazon.Text = "";
                        txtRazon.Focus();
                        dtDesde.Value = DateTime.Now;
                        dtHasta.Value = DateTime.Now;
                    }
                    
                }
                catch { }
            }

        }

        private void txtRazon_KeyPress(object sender, KeyPressEventArgs e)
        {
            oControl.ValidarCajaTexto(e, e.KeyChar);
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            dtHasta.MinDate = dtDesde.Value;
        }
    }
}
