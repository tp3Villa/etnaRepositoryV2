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
    public partial class frmBusquedaFormatoComercial : Form
    {
        public frmBusquedaFormatoComercial()
        {
            InitializeComponent();
        }


        DataTable dtTipoDoc = new DataTable();
        DataTable dtDocVersiones = new DataTable();
        string tipo = "";
        string estado = "";
        public static Boolean Actualiza;


        private BTablas bTablas = BTablas.getInstance();
        private BTransaccion bTransaccion = BTransaccion.getInstance();

        private void frmBusquedaFormatoComercial_Load(object sender, EventArgs e)
        {
            dtTipoDoc = bTablas.getSELECTLIBRE("SELECT cod_siicex,des_siicex FROM dbo.DosSIICEX");
            cbTipoDoc.DataSource = dtTipoDoc;
            cbTipoDoc.DisplayMember = "des_siicex";
            cbTipoDoc.ValueMember = "cod_siicex";

            dgvVersiones.GridColor = Color.Red;
            dtDocVersiones = bTablas.BConsula_Versiones_Documentos_Detalle(0, "", "", "", 0);
            dgvVersiones.DataSource = dtDocVersiones;
            cbEstado.SelectedIndex = 0;               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formularios.Exportacion.frmFormatoComercial frm = new frmFormatoComercial();
            frm.evalua = "NEW";
            frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string Desde = dtDesde.Value.Year.ToString() + dtDesde.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtDesde.Value.Day.ToString("00", CultureInfo.InvariantCulture);
            string hasta = dtHasta.Value.Year.ToString() + dtHasta.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtHasta.Value.Day.ToString("00", CultureInfo.InvariantCulture);
            tipo = cbTipoDoc.SelectedValue.ToString();

            if (cbEstado.SelectedIndex == 0)
            {
                estado = "A";
            }
            else
            {
                estado = "I";
            }

            dtDocVersiones = bTablas.BConsula_Versiones_Documentos_Detalle(Convert.ToInt16(tipo), estado, Desde, hasta, 1);
            dgvVersiones.DataSource = dtDocVersiones;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvVersiones.GridColor = Color.Red;
            dtDocVersiones = bTablas.BConsula_Versiones_Documentos_Detalle(0, "", "", "", 0);
            dgvVersiones.DataSource = dtDocVersiones;
        }

        private void dgvVersiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString());
            if (e.ColumnIndex == 0)
            {
                try
                {
                    int p = dgvVersiones.CurrentRow.Index;
                    OpenFileDialog openfiledialog = new OpenFileDialog();
                    openfiledialog.FileName = dgvVersiones.Rows[p].Cells["docadju"].Value.ToString();
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = openfiledialog.FileName.ToString();
                    proc.Start();
                    proc.Close();
                }
                catch { }
            }
            else
            {
                try
                {
                    int p = dgvVersiones.CurrentRow.Index;
                    Formularios.Exportacion.frmFormatoComercial frm = new frmFormatoComercial();                    
                    frm.tipo = dgvVersiones.Rows[p].Cells["Codigo"].Value.ToString();
                    frm.fechaPubli = dgvVersiones.Rows[p].Cells["fecha1"].Value.ToString();
                    frm.fechaExpi = dgvVersiones.Rows[p].Cells["fecha2"].Value.ToString();
                    frm.estado = dgvVersiones.Rows[p].Cells["est"].Value.ToString();
                    frm.ruta = dgvVersiones.Rows[p].Cells["docadju"].Value.ToString();
                    frm.version = dgvVersiones.Rows[p].Cells["Version"].Value.ToString();
                    frm.ShowDialog();                    
                }
                catch { }
            }
        }

        private void frmBusquedaFormatoComercial_Activated(object sender, EventArgs e)
        {
            if (Actualiza == true)
            {
                dgvVersiones.GridColor = Color.Red;
                dtDocVersiones = bTablas.BConsula_Versiones_Documentos_Detalle(0, "", "", "", 0);
                dgvVersiones.DataSource = dtDocVersiones;
                cbEstado.SelectedIndex = 0;   
                dtDesde.Value = DateTime.Now;
                dtHasta.Value = DateTime.Now;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
