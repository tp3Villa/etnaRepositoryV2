using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ETNA.SGI.Presentacion.Formularios.Exportacion
{
    public partial class frmAprobacionDetaSolicitud : Form
    {
        public frmAprobacionDetaSolicitud()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmAprobacionDetaSolicitud_Load(object sender, EventArgs e)
        {
            DataTable tblDetalle = new DataTable();
            tblDetalle.Columns.Add(new DataColumn("1", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("2", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("3", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("4", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("5", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("6", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("7", typeof(string)));

            DataRow fila = tblDetalle.NewRow();
            fila["1"] = "1";
            fila["2"] = "BATERIA  MT-5 PRO";
            fila["3"] = "25";
            fila["4"] = "Unidad";
            fila["5"] = "180.23";
            fila["6"] = "1400.00";
            fila["7"] = "100.00";
            tblDetalle.Rows.Add(fila);

            fila = tblDetalle.NewRow();
            fila["1"] = "2";
            fila["2"] = "BATERIA  MT-7 PRO";
            fila["3"] = "28";
            fila["4"] = "Unidad";
            fila["5"] = "195.01";
            fila["6"] = "1450.00";
            fila["7"] = "1300.00";
            tblDetalle.Rows.Add(fila);

            fila = tblDetalle.NewRow();
            fila["1"] = "3";
            fila["2"] = "BATERIA  WS-11A PRO";
            fila["3"] = "35";
            fila["4"] = "Unidad";
            fila["5"] = "156.11";
            fila["6"] = "1562.30";
            fila["7"] = "1520.32";
            tblDetalle.Rows.Add(fila);
            dataGridView1.DataSource = tblDetalle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Formularios.Exportacion.frmListadocumentosAsociados frm = new frmListadocumentosAsociados();
            frm.ShowDialog();
        }
    }
}
