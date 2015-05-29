using ETNA.SGI.Bussiness.Compras;
using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ETNA.SGI.Presentacion.Formularios.Compras
{
    public partial class frmListadoOrdenCompra : Form
    {
        private BOrdenCompra bOrdenCompra = BOrdenCompra.getInstance();
        private BEstado bEstado = BEstado.getInstance();
        private static int ESTADO_ANULADA = 3;

        public frmListadoOrdenCompra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EOrdenCompra eOrdenCompra = new EOrdenCompra();
            if (!"".Equals(txtCodOC.Text)) {
                eOrdenCompra.CodOrdenCompra = Int32.Parse(txtCodOC.Text);
            }
            if (!"".Equals(txtCodReq.Text))
            {
                eOrdenCompra.CodRequerimiento = Int32.Parse(txtCodReq.Text);
            }
            
            eOrdenCompra.CodEstado = (int)cboEstado.SelectedValue;

            cargaGrilla(eOrdenCompra);
        }
              
        private void txtCodOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void txtCodReq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmListadoOrdenCompra_Load(object sender, EventArgs e)
        {
            // Carga de Combo Estado
            DataTable dtEstado = bEstado.ObtenerListadoEstadoPorOrdenCompra();
            cboEstado.DataSource = dtEstado;
            cboEstado.DisplayMember = "desEstado";
            cboEstado.ValueMember = "codEstado";

            DataRow dr = dtEstado.NewRow();
            dr["desEstado"] = "Todos";
            dr["codEstado"] = 0;

            dtEstado.Rows.InsertAt(dr, 0);
            cboEstado.SelectedIndex = 0;

            // Carga de Grilla
            cargaGrilla(new EOrdenCompra());
        }

        private void cargaGrilla(EOrdenCompra eOrdenCompra)
        {
            DataTable dt = bOrdenCompra.ObtenerListadoOrdenCompra(eOrdenCompra);           
            dt.Columns["codEstado"].ColumnMapping = MappingType.Hidden;
            //dt.Columns["codMoneda"].ColumnMapping = MappingType.Hidden;
            dt.Columns["observacion"].ColumnMapping = MappingType.Hidden;
            dt.AcceptChanges();
            dtGridOC.DataSource = dt;            
        }
        
        private void dtGridOC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ("3".Equals(dtGridOC.Rows[e.RowIndex].Cells["codEstado"].Value.ToString()))
            {
                if (e.ColumnIndex == 0) { MessageBox.Show("No se puede modificar una orden de compra anulada"); }
                if (e.ColumnIndex == 1) { MessageBox.Show("No se puede anular una orden de compra anulada"); }                
                return;
            }
            // Modificar
            if (e.ColumnIndex == 0) 
            {
                try
                {
                    int currentIndex = dtGridOC.CurrentRow.Index;
                    Formularios.Compras.frmOrdenCompra frm = new frmOrdenCompra();

                    frm.CodOrdenCompra = dtGridOC.Rows[currentIndex].Cells["codOrdenCompra"].Value.ToString();
                    frm.CodRequerimiento = dtGridOC.Rows[currentIndex].Cells["codRequerimiento"].Value.ToString();
                    frm.CodCotizacion = dtGridOC.Rows[currentIndex].Cells["codCotizacion"].Value.ToString();
                    frm.Proveedor = dtGridOC.Rows[currentIndex].Cells["razonSocial"].Value.ToString();
                    frm.FechaEntrega = dtGridOC.Rows[currentIndex].Cells["fechaEntrega"].Value.ToString();
                    frm.LugarEntrega = dtGridOC.Rows[currentIndex].Cells["lugarEntrega"].Value.ToString();
                    //frm.CodMoneda = dtGridOC.Rows[currentIndex].Cells["codMoneda"].Value.ToString();
                    frm.Observacion = dtGridOC.Rows[currentIndex].Cells["observacion"].Value.ToString();
                    frm.ShowDialog();
                    cargaGrilla(new EOrdenCompra());
                    resetFiltro();
                }
                catch {
                    MessageBox.Show("Ocurrió un error inesperado.\nSi el error persiste comuniquese con el administrador.");
                }

            }

            // Anular
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("¿Está seguro que desea anular la Orden de Compra?\nNro OC: " + dtGridOC.Rows[e.RowIndex].Cells["codOrdenCompra"].Value.ToString(), "Compras", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    EOrdenCompra eOrdenCompra = new EOrdenCompra();
                    eOrdenCompra.CodOrdenCompra = Int32.Parse(dtGridOC.Rows[e.RowIndex].Cells["codOrdenCompra"].Value.ToString());
                    eOrdenCompra.FechaActualizacion = DateTime.Today;
                    eOrdenCompra.UsuarioModificacion = Program.Usuario.Trim();
                    eOrdenCompra.CodEstado = ESTADO_ANULADA;
                    bOrdenCompra.ActualizarEstadoOrdenCompra(eOrdenCompra);
                    MessageBox.Show("Orden de compra anulada satisfactoriamente");
                    cargaGrilla(new EOrdenCompra());
                    resetFiltro();
                }
            }
        }

        private void resetFiltro() {
            txtCodOC.Text = "";
            txtCodReq.Text = "";
            cboEstado.SelectedIndex = 0;
        }

       private void btnGenerarOC_Click(object sender, EventArgs e)
        {
            Formularios.Compras.frmOrdenCompra frm = new frmOrdenCompra();
            frm.CodOrdenCompra = "";
            frm.ShowDialog();
            cargaGrilla(new EOrdenCompra());
            resetFiltro();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
