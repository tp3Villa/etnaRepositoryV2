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
    public partial class frmActualizarInfoRequerimiento : Form
    {
        public frmActualizarInfoRequerimiento()
        {
            InitializeComponent();
        }
        private BTablas bTablas = BTablas.getInstance();
        private BTransaccion bTransaccion = BTransaccion.getInstance();
        //BTablas objBus = new BTablas();
        public static Boolean Actualiza;

        private void frmActualizarInfoRequerimiento_Load(object sender, EventArgs e)
        {
            dtHasta.MinDate = dtDesde.Value;


            dataGridView1.GridColor = Color.Red;
            txtCliente.Text = Program.Nombre;
            //objBus = new BTablas();
            dataGridView1.DataSource = bTablas.BRequerimientoBusquedaXCodigoCliente(Program.CodCli);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formularios.Exportacion.frmNuevoRequerimiento frm = new frmNuevoRequerimiento();
            frm.ShowDialog();
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal Desde = Convert.ToDecimal(dtDesde.Value.Year.ToString() + dtDesde.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtDesde.Value.Day.ToString("00", CultureInfo.InvariantCulture));
            decimal hasta = Convert.ToDecimal(dtHasta.Value.Year.ToString() + dtHasta.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtHasta.Value.Day.ToString("00", CultureInfo.InvariantCulture));
                       
            dataGridView1.GridColor = Color.Red;
            //objBus = new BTablas();
            dataGridView1.DataSource = bTablas.getSELECTLIBRE("SELECT Cod_Cab_Req,Fec_Esp_Cab_Req,(SELECT nom_pais FROM pais AS P WHERE P.Cod_Pais=R.Cod_Pais) AS pais,Destino_Cab_Req FROM Requerimiento AS R  " +
" WHERE COD_CLIENTE='" + Program.CodCli + "' AND EST_CAB_REQ='A' AND fec_reg_cab_req BETWEEN " + Desde + " AND " + hasta + "");

        }

        private void frmActualizarInfoRequerimiento_Activated(object sender, EventArgs e)
        {
            if (Actualiza == true)
            {
                this.Cursor = Cursors.WaitCursor;
                //objBus = new BTablas();
                dataGridView1.DataSource = bTablas.BRequerimientoBusquedaXCodigoCliente(Program.CodCli);
                Actualiza = false;
                this.Cursor = Cursors.Default;
            }
        }


        //BTransaccion objtra = new BTransaccion();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    int p = dataGridView1.CurrentRow.Index;
                    Formularios.Exportacion.frmNuevoRequerimiento frm = new frmNuevoRequerimiento();
                    frm.Opcion = "UPD";
                    frm.CorrReqUPD = dataGridView1.Rows[p].Cells["codREQ"].Value.ToString();
                    frm.ShowDialog();

                }
                catch { }                
            }
            if (e.ColumnIndex == 1)
            {
                try
                {
                    int p = dataGridView1.CurrentRow.Index;
                    if (MessageBox.Show("¿Desea Anular el Requerimiento Nro " + dataGridView1.Rows[p].Cells["codREQ"].Value.ToString() + " ?", "Exportación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //objtra = new BTransaccion();
                        int i = bTransaccion.BUpdateEstadoReq(dataGridView1.Rows[p].Cells["codREQ"].Value.ToString());
                        MessageBox.Show("Requerimiento Eliminado Correctamente ", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //objBus = new BTablas();
                        dataGridView1.DataSource = bTablas.BRequerimientoBusquedaXCodigoCliente(Program.CodCli);
                    }

                }
                catch { }
            }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {          
            
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            dtHasta.MinDate = dtDesde.Value;
        }
    }
}
