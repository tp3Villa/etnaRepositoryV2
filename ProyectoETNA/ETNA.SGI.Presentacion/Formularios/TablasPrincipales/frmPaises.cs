using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ETNA.SGI.Bussiness.Exportacion;

namespace ETNA.SGI.Presentacion.Formularios.TablasPrincipales
{
    public partial class frmPaises : Form
    {
        public frmPaises()
        {
            InitializeComponent();
        }


        BTablas objBUS = new BTablas();
        DataTable dt = new DataTable();
        private void frmPaises_Load(object sender, EventArgs e)
        {
            dt = objBUS.getSELECTLIBRE("SELECT * FROM dbo.Cliente");
            dataGridView1.DataSource = dt;

        }
    }
}
