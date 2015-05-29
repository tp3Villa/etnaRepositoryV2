using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using ETNA.SGI.Bussiness.Exportacion;
using System.Globalization;

namespace ETNA.SGI.Presentacion.Formularios.Exportacion
{
    public partial class frmAtencionSolicitud : Form
    {
        public frmAtencionSolicitud()
        {
            InitializeComponent();
        }

        

        BTablas objBus = new BTablas();
        BTransaccion objTra = new BTransaccion();
        DataTable dtSolicitud = new DataTable();
        public static Boolean Actualiza;

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
            dataGridView1.GridColor = Color.Red;
            objBus = new BTablas();
            dtSolicitud = objBus.getSELECTLIBRE("SELECT cod_solicitud,cod_cab_req_solicitud,razon_social,fec_reg_solicitud FROM SolicitudAtencion LEFT OUTER JOIN " +
" Requerimiento ON (cod_cab_req_solicitud=Cod_Cab_Req) LEFT OUTER JOIN " +
" cliente ON (cli_cab_req=Codigo) where estado_solicitud='A'");
            dataGridView1.DataSource = dtSolicitud;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string razon = txtRazon.Text.Trim();
            decimal Desde = Convert.ToDecimal(dtDesde.Value.Year.ToString() + dtDesde.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtDesde.Value.Day.ToString("00", CultureInfo.InvariantCulture));
            decimal hasta = Convert.ToDecimal(dtHasta.Value.Year.ToString() + dtHasta.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtHasta.Value.Day.ToString("00", CultureInfo.InvariantCulture));


            dataGridView1.GridColor = Color.Red;
            objBus = new BTablas();
            dtSolicitud = objBus.getSELECTLIBRE("SELECT cod_solicitud,cod_cab_req_solicitud,razon_social,fec_reg_solicitud FROM SolicitudAtencion LEFT OUTER JOIN " +
" Requerimiento ON (cod_cab_req_solicitud=Cod_Cab_Req) LEFT OUTER JOIN " +
" cliente ON (cli_cab_req=Codigo) WHERE RAZON_SOCIAL LIKE '%" + razon + "%' AND fec_reg_solicitud BETWEEN " + Desde + " AND " + hasta + " and estado_solicitud='A'");
            dataGridView1.DataSource = dtSolicitud;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.GridColor = Color.Red;
            objBus = new BTablas();
            dtSolicitud = objBus.getSELECTLIBRE("SELECT cod_solicitud,cod_cab_req_solicitud,razon_social,fec_reg_solicitud FROM SolicitudAtencion LEFT OUTER JOIN " +
" Requerimiento ON (cod_cab_req_solicitud=Cod_Cab_Req) LEFT OUTER JOIN " +
" cliente ON (cli_cab_req=Codigo) where estado_solicitud='A'");
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
                objBus = new BTablas();
                dtSolicitud = objBus.getSELECTLIBRE("SELECT cod_solicitud,cod_cab_req_solicitud,razon_social,fec_reg_solicitud FROM SolicitudAtencion LEFT OUTER JOIN " +
    " Requerimiento ON (cod_cab_req_solicitud=Cod_Cab_Req) LEFT OUTER JOIN " +
    " cliente ON (cli_cab_req=Codigo) where estado_solicitud='A'");
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

                    if (MessageBox.Show("Se Anulara la Solicitud " + CodSoli, "Exportación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //hacemos la reversa de todo sino se ha aprobado
                        int y = 0;
                        objTra = new BTransaccion();
                        y = objTra.BTransaccionVarias("UPDATE SolicitudAtencion SET estado_solicitud='E' WHERE cod_solicitud=" + CodSoli);

                        objTra = new BTransaccion();
                        y = objTra.BTransaccionVarias("DELETE FROM DocProdReq WHERE Doc_Req=" + CodReq);

                        objTra = new BTransaccion();
                        y = objTra.BTransaccionVarias("UPDATE dbo.Requerimiento SET IATA_CAB_REQ='',EST_CAB_REQ='A' WHERE Cod_Cab_Req=" + CodReq);

                        objTra = new BTransaccion();
                        y = objTra.BTransaccionVarias("UPDATE dbo.Requerimiento_Detalle SET CIF=0,FOB=0 WHERE Cod_Det_Req=" + CodReq);

                        MessageBox.Show("solicitud Anulada correctamente", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        dataGridView1.GridColor = Color.Red;
                        objBus = new BTablas();
                        dtSolicitud = objBus.getSELECTLIBRE("SELECT cod_solicitud,cod_cab_req_solicitud,razon_social,fec_reg_solicitud FROM SolicitudAtencion LEFT OUTER JOIN " +
            " Requerimiento ON (cod_cab_req_solicitud=Cod_Cab_Req) LEFT OUTER JOIN " +
            " cliente ON (cli_cab_req=Codigo) where estado_solicitud='A'");
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
    }
}
