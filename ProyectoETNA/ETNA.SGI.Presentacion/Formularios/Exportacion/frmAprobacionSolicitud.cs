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

namespace ETNA.SGI.Presentacion.Formularios.Exportacion
{
    public partial class frmAprobacionSolicitud : Form
    {
        public frmAprobacionSolicitud()
        {
            InitializeComponent();
        }

        DataTable dtSolicitud = new DataTable();
        public static Boolean Actualiza;


        private BTablas bTablas = BTablas.getInstance();
        private BTransaccion bTransaccion = BTransaccion.getInstance();

        private void frmAprobacionSolicitud_Load(object sender, EventArgs e)
        {
            dtHasta.MinDate = dtDesde.Value;
            dataGridView1.GridColor = Color.Red;
            //objBus = new BTablas();
            dtSolicitud = bTablas.BConsula_Aprobacion_Solicitudes("A", "P", "0", "0", 0);
            dataGridView1.DataSource = dtSolicitud;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Formularios.Exportacion.frmAprobacionDetaSolicitud frm = new frmAprobacionDetaSolicitud();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Desde = dtDesde.Value.Year.ToString() + dtDesde.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtDesde.Value.Day.ToString("00", CultureInfo.InvariantCulture);
            string hasta = dtHasta.Value.Year.ToString() + dtHasta.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtHasta.Value.Day.ToString("00", CultureInfo.InvariantCulture);
            
            dataGridView1.GridColor = Color.Red;
            //objBus = new BTablas();
            dtSolicitud = bTablas.BConsula_Aprobacion_Solicitudes("A", "P", Desde, hasta, 1);
            dataGridView1.DataSource = dtSolicitud;
        }

        private void frmAprobacionSolicitud_Activated(object sender, EventArgs e)
        {
            if (Actualiza == true)
            {
                dataGridView1.GridColor = Color.Red;                //objBus = new BTablas();
                dtSolicitud = bTablas.BConsula_Aprobacion_Solicitudes("A", "P", "0", "0", 0);
                dataGridView1.DataSource = dtSolicitud;
                dtDesde.Value = DateTime.Now;
                dtHasta.Value = DateTime.Now;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString());
            if (e.ColumnIndex == 0)
            {
                try
                {
                    int p = dataGridView1.CurrentRow.Index;
                    Formularios.Exportacion.frmAprobacionDetaSolicitud frm = new frmAprobacionDetaSolicitud();
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
                    string CodSoli = "";
                    string CodReq = "";

                    int p = dataGridView1.CurrentRow.Index;
                    CodSoli = dataGridView1.Rows[p].Cells["cod_solicitud"].Value.ToString();
                    CodReq = dataGridView1.Rows[p].Cells["cod_cab_req_solicitud"].Value.ToString();

                    if (MessageBox.Show("¿Desea Desaprobar la solicitud " + CodSoli + "?", "Exportación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                        dtSolicitud = bTablas.BConsula_Aprobacion_Solicitudes("A", "P", "0", "0", 0);
                        dataGridView1.DataSource = dtSolicitud;
                        dtDesde.Value = DateTime.Now;
                        dtHasta.Value = DateTime.Now;
                    }

                }
                catch { }
            }
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            dtHasta.MinDate = dtDesde.Value;
        }


    }
}
