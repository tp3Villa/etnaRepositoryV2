using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETNA.SGI.Entity.Compras;
using ETNA.SGI.Bussiness.Compras;

namespace ETNA.SGI.Presentacion.Formularios.Compras
{
    public partial class frmListadoReqCompra : Form
    {

        //RCR
        public int vCodReq;

        private BRequerimientoCompra bRequerimientoCompra = BRequerimientoCompra.getInstance();

        private const int ESTADO_PENDIENTE = 1;
        private const int ESTADO_ANULADA = 3;

        private BEstado bEstado = BEstado.getInstance();

        DataTable dtEstado = new DataTable();

        public frmListadoReqCompra()
        {
            InitializeComponent();
        }

        private void FrmRequerimientos_Load(object sender, EventArgs e)
        {
            groupBox2.Text = Program.Nombre.Trim();

            dtEstado = bEstado.ObtenerListadoEstadoPorReqCompra();
            cboEstado.DataSource = dtEstado;
            cboEstado.DisplayMember = "desEstado";
            cboEstado.ValueMember = "codEstado";

            DataRow dr = dtEstado.NewRow();
            dr["desEstado"] = "Todos";
            dr["codEstado"] = 0;

            dtEstado.Rows.InsertAt(dr, 0);
            cboEstado.SelectedIndex = 0;

           listar();
        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReqCompra nuevo = SingletonFormProvider.GetInstance<frmReqCompra>(this);
            nuevo.EventoActualizarLista += listar;
            nuevo.MdiParent = this.MdiParent;
            nuevo.ShowDialog();
        }

        private void listar()
        {
            
            int estado = Convert.ToInt32(cboEstado.SelectedValue);
            if (estado == 0)
            {
                DataTable tblReqCompra= new DataTable();
                tblReqCompra = bRequerimientoCompra.ListarPorCodigoPersonal(Program.Usuario);

                dataGridView1.DataSource = tblReqCompra;
            }
            else
            {
                dataGridView1.DataSource = bRequerimientoCompra.ListarPorCodigoPersonalYEstado(Program.Usuario, estado);
            }
           
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           if (dataGridView1.Rows.Count > 0)
            {
                int codRequerimiento = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                dataGridView2.DataSource = bRequerimientoCompra.ListaDetallePorCodigoRequerimiento(codRequerimiento);
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
           if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hitTest = dataGridView1.HitTest(e.X, e.Y);
                if (hitTest.Type == DataGridViewHitTestType.Cell)
                {
                    dataGridView1.Rows[hitTest.RowIndex].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[hitTest.RowIndex].Cells[hitTest.ColumnIndex];
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          /*  if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow.Index >= 0)
                {
                    int codEstado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
                    if (codEstado == ESTADO_PENDIENTE)
                    {
                        ERequerimientoCompra req = new ERequerimientoCompra();
                        req.CodRequerimiento = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                        req.CodCategoria = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
                        req.FechaRegistro = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[1].Value);
                        req.Observacion = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                        //FrmActualizarReq actualizar = SingletonFormProvider.GetInstance<FrmActualizarReq>(this);
                        frmReqCompra actualizar = SingletonFormProvider.GetInstance<frmReqCompra>(this);
                        //actualizar.vRequerimiento = req;
                        actualizar.EventoActualizarLista += listar;
                        actualizar.MdiParent = this.MdiParent;
                        actualizar.Show();
                    }
                    else
                    {
                        MessageBox.Show("Estado no permite modificar el requerimiento", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }*/
        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow.Index >= 0)
                {
                    int codEstado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
                    if (codEstado == ESTADO_PENDIENTE)
                    {
                        int codRequerimiento = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                        DialogResult resultado = MessageBox.Show("¿Esta seguro que desea anular el requerimiento " + codRequerimiento.ToString("0000000") + "?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.Yes)
                        {
                            bRequerimientoCompra.ActualizarEstado(codRequerimiento, ESTADO_ANULADA);
                            listar();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El estado actual no permite anular el requerimiento", "Anular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (Char.IsNumber(e.KeyChar) || e.KeyChar == (Char)Keys.Back)
            {
                e.Handled = false;
            }
            else if(e.KeyChar == (Char)Keys.Enter && !String.IsNullOrEmpty(txtCodigo.Text))
            {
                bool encontrado = false;
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (fila.Cells[0].Value.ToString() == txtCodigo.Text) 
                    {
                        fila.Selected = true;
                        dataGridView1.CurrentCell = fila.Cells[0];
                        dataGridView2.DataSource = bRequerimientoCompra.ListaDetallePorCodigoRequerimiento(Convert.ToInt32(txtCodigo.Text));
                        encontrado = true;
                        break;
                    }
                }
                if (!encontrado)
                {
                    MessageBox.Show("Codigo de requerimiento no existe", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            try
            {
                listar();
            }
            catch
            { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          if (e.ColumnIndex == 0)
            {
                try
                {
                    vCodReq =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    this.Close();
                }
                catch { }
            }
         
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            int estado = Convert.ToInt32(cboEstado.SelectedValue);
            if  (txtCodigo.Text != "")
            {         
            int codreq = Convert.ToInt32(txtCodigo.Text);
            dataGridView1.DataSource = bRequerimientoCompra.ListarPorCodigoReqYEstado(codreq , estado);
            }else {
                DataTable tblReqCompra = new DataTable();
                tblReqCompra = bRequerimientoCompra.ListarPorCodigoPersonal(Program.Usuario);
                dataGridView1.DataSource = tblReqCompra;
            }
        }

 
    }
}
