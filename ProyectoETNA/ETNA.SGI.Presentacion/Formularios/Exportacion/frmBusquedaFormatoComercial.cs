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
    public partial class frmBusquedaFormatoComercial : Form
    {
        public frmBusquedaFormatoComercial()
        {
            InitializeComponent();
        }

        private void frmBusquedaFormatoComercial_Load(object sender, EventArgs e)
        {
            DataTable tblDetalle = new DataTable();
            tblDetalle.Columns.Add(new DataColumn("1", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("2", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("3", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("4", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("5", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("6", typeof(string)));

            DataRow fila = tblDetalle.NewRow();
            fila["1"] = "1";
            fila["2"] = "Requisitos de Calidad e Inocuidad";
            fila["3"] = "21/05/2013";
            fila["4"] = "31/11/2016";
            fila["5"] = "2.0";
            fila["6"] = "disponible";
            tblDetalle.Rows.Add(fila);
            dataGridView1.DataSource = tblDetalle;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formularios.Exportacion.frmFormatoComercial frm = new frmFormatoComercial();
            
            frm.Show();
        }
    }
}
