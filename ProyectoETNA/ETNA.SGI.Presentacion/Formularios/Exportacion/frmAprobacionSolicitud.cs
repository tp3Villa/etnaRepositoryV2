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
    public partial class frmAprobacionSolicitud : Form
    {
        public frmAprobacionSolicitud()
        {
            InitializeComponent();
        }

        private void frmAprobacionSolicitud_Load(object sender, EventArgs e)
        {
            DataTable tblDetalle = new DataTable();
            tblDetalle.Columns.Add(new DataColumn("1", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("2", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("3", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("4", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("5", typeof(string)));
            tblDetalle.Columns.Add(new DataColumn("6", typeof(string)));

            DataRow fila = tblDetalle.NewRow();
            fila["1"] = "S00001";
            fila["2"] = "Barcenas Miguel";
            fila["3"] = "10/03/2015";
            fila["4"] = "15/04/2015";
            fila["5"] = "Jose Sisniegas";
            fila["6"] = "Pendiente";
            tblDetalle.Rows.Add(fila);

            fila = tblDetalle.NewRow();
            fila["1"] = "S00002";
            fila["2"] = "Ubillus Chaname";
            fila["3"] = "01/03/2015";
            fila["4"] = "05/04/2015";
            fila["5"] = "Iccher Espinoza";
            fila["6"] = "Aprobado";
            tblDetalle.Rows.Add(fila);

            fila = tblDetalle.NewRow();
            fila["1"] = "S00003";
            fila["2"] = "Baylon Miller";
            fila["3"] = "03/03/2015";
            fila["4"] = "09/04/2015";
            fila["5"] = "Wendolyn Picardo";
            fila["6"] = "Aprobado";
            tblDetalle.Rows.Add(fila);


            fila = tblDetalle.NewRow();
            fila["1"] = "S00004";
            fila["2"] = "Chang Ernesto";
            fila["3"] = "05/04/2015";
            fila["4"] = "06/05/2015";
            fila["5"] = "Omar Mejia";
            fila["6"] = "Pendiente";
            tblDetalle.Rows.Add(fila);

            dgvRequerimiento.DataSource = tblDetalle;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Formularios.Exportacion.frmAprobacionDetaSolicitud frm = new frmAprobacionDetaSolicitud();
            frm.ShowDialog();
        }
    }
}
