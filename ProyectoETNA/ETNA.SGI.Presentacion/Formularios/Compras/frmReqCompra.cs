using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETNA.SGI.Bussiness.Compras;
using ETNA.SGI.Entity.Compras;

namespace ETNA.SGI.Presentacion.Formularios.Compras
{
    public partial class frmReqCompra : Form
    {
        public delegate void ActualizarLista();
        public event ActualizarLista EventoActualizarLista;

        private BCategoria bCategoria = BCategoria.getInstance();
        private BRequerimientoCompra bRequerimientoCompra = BRequerimientoCompra.getInstance();

        public frmReqCompra()
        {
            InitializeComponent();
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            //groupBox2.Text = Presentacion.Menu.Usuario.Nom_Usuario;
            groupBox2.Text = Program.Usuario.Trim();
            cboCategoria.DataSource = bCategoria.ObtenerListadoCategoria();
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.ValueMember = "Codigo";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Compras.frmListadoReqCompra frmreq = new frmListadoReqCompra();

            if (validarRegistro())
            {
                List<ERequerimientoCompraDetalle> reqDets = new List<ERequerimientoCompraDetalle>();
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    ERequerimientoCompraDetalle reqDet = new ERequerimientoCompraDetalle();
                    reqDet.IdProducto = Convert.ToInt32(fila.Cells[0].Value);
                    reqDet.Cantidad = Convert.ToInt32(fila.Cells[5].Value);
                    reqDets.Add(reqDet);
                }
                ERequerimientoCompra reqCab = new ERequerimientoCompra();
                //reqCab.IdPersona = Presentacion.Menu.Personal.Codigo;
                reqCab.CodEstado = 600;
                reqCab.CodCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
                reqCab.FechaRegistro = dtFechaRegistro.Value;
                reqCab.FechaActualizacion = dtFechaRegistro.Value;
                reqCab.UsuarioRegistro = Program.Usuario.Trim();

                reqCab.Observacion = txtObservacion.Text;
                bRequerimientoCompra.Registrar(reqCab, reqDets);
                MessageBox.Show("Se ha grabado el registro con exito", "Registrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                               
                if (EventoActualizarLista != null)
                {
                    EventoActualizarLista();
                    
                }
                this.Close();
            }
        }

        private bool validarRegistro()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Se ha intentado grabar un requerimiento sin productos, por favor seleccione un producto.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmListadoProducto frmArt = SingletonFormProvider.GetInstance<frmListadoProducto>(this); ;
            frmArt.MdiParent = this.MdiParent;
            ECategoria categoria = new ECategoria();
            categoria.CodCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
            categoria.DesCategoria = cboCategoria.Text;
            frmArt.EventoSeleccionarArticulo += SeleccionarArticulo;
            frmArt.vCategoria = categoria;
            frmArt.Show();
        }

        private void SeleccionarArticulo(EProducto producto)
        {
            bool existe = false;
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (Convert.ToInt32(fila.Cells[0].Value) == producto.IdProducto)
                {
                    existe = true;
                }
            }
            if (!existe)
            {
                dataGridView1.Rows.Add(producto.IdProducto, producto.DesCategoria, producto.DesMarca, producto.DescripcionProducto, producto.TipoUnidadMedida, 1);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentCell.ColumnIndex == 5)
                {
                    if (dataGridView1.CurrentCell.Value == null)
                    {
                        dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value = "1";
                    }
                    else 
                    { 
                        string valor = dataGridView1.CurrentCell.Value.ToString().Trim();
                        if (valor == "" || valor == "0")
                        {
                            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value = "1";
                        }
                    }
                }
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentCell.ColumnIndex == 5)
                {
                    TextBox control = e.Control as TextBox;
                    if (control != null)
                    {
                        control.KeyPress += dataGridviewKeyPress;
                    }
                }
            }
        }

        private void dataGridviewKeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == (Char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("Seleccionar una fila para eliminar", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       

        

    }
}
