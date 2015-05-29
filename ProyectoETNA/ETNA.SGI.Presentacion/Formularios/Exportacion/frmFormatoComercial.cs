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
    public partial class frmFormatoComercial : Form
    {
        public frmFormatoComercial()
        {
            InitializeComponent();
        }

        public string textFormatoComercial = "";
        private void frmFormatoComercial_Load(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el Formato Comercia Nº 1?", "Formato Comercial", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
            }

        }
    }
}
