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
using ETNA.SGI.Utils;
using System.Globalization;

namespace ETNA.SGI.Presentacion.Formularios.Compras
{
    public partial class frmProveedor : Form
    {
        public int icodProveedor;
        public string sOpcion;

        EProveedor proveedor = new EProveedor();
        BProveedor bProveedor = BProveedor.getInstance(); 

        public frmProveedor()
        {
            InitializeComponent();
        }       

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            /* Se valida la modalidad de ingreso */
            if (sOpcion == "UPD")
            {
                DataTable tblDetalle = new DataTable();

                proveedor.CodProveedor = icodProveedor;
                tblDetalle = bProveedor.DGetProveedorById(proveedor);

                txtRazonSocial.Text = tblDetalle.Rows[0]["razonSocial"].ToString();
                txtRUC.Text = tblDetalle.Rows[0]["ruc"].ToString();
                txtTelefono.Text = tblDetalle.Rows[0]["telefono"].ToString();
                txtDire.Text = tblDetalle.Rows[0]["direccion"].ToString();
                txtEmail.Text = tblDetalle.Rows[0]["email"].ToString();
                txtCondPago.Text = tblDetalle.Rows[0]["codCondicionPago"].ToString();
                txtObs.Text = tblDetalle.Rows[0]["observacion"].ToString();
                lblCondicionPago.Text = tblDetalle.Rows[0]["desCondicionPago"].ToString();

                if (tblDetalle.Rows[0]["codEstado"].ToString() == "5")
                {
                    rdActivo.Checked = true;
                }
                else {
                    rdInactivo.Checked = true;
                }

            }
            else
            {
                rdActivo.Checked = true;
            }
        }

       

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            /* UPC - 14.02.2015 - Edinson Rojas Villarreyes - Begin */
            /* Se valida que se ingrese los campos requeridos */

            DateTime FechaSis = DateTime.Now;

            string fecha;
            FechaSis = DateTime.Now;

            if (txtRazonSocial.Text == "") { MessageBox.Show("Ingresar razón social", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); txtRazonSocial.Focus(); this.Cursor = Cursors.Default; return; }
            if (txtRUC.Text == "") { MessageBox.Show("Ingresar RUC", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); txtRUC.Focus(); this.Cursor = Cursors.Default; return; }
            if (txtTelefono.Text == "") { MessageBox.Show("Ingresar teléfono", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); txtTelefono.Focus(); this.Cursor = Cursors.Default; return; }
            if (txtDire.Text == "") { MessageBox.Show("Ingresar dirección", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); txtDire.Focus(); this.Cursor = Cursors.Default; return; }
            if (txtEmail.Text == "") { MessageBox.Show("Ingresar correo eléctronico", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); txtEmail.Focus(); this.Cursor = Cursors.Default; return; }
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (txtEmail.Text.Length > 0 && txtEmail.Text.Trim().Length != 0)
            {
                if (!rEmail.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Correo eléctronico inválido", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    this.Cursor = Cursors.Default; return;

                }
            }

            if (txtCondPago.Text == "") { MessageBox.Show("Ingresar condición de pago", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); txtEmail.Focus(); this.Cursor = Cursors.Default; return; }
           
            /* Validar duplicidad de RUC */
            string SqlString,strErrorMsg;

            SqlString = "Select 'X' as existe from proveedor where ruc =" + txtRUC.Text;
            strErrorMsg = "RUC ingresado ya esta registrado, por favor ingrese otro.";

            if (sOpcion == "UPD")            {

                SqlString = SqlString  + " and codProveedor <> " + icodProveedor;
                
                if (bProveedor.DValidarRUC(SqlString).Rows.Count > 0)
                {
                    { MessageBox.Show(strErrorMsg, "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); txtEmail.Focus(); this.Cursor = Cursors.Default; return; }
                }
            }
            else
            {
               if (bProveedor.DValidarRUC(SqlString).Rows.Count > 0) {
                   { MessageBox.Show(strErrorMsg, "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); txtEmail.Focus(); this.Cursor = Cursors.Default; return; }
                }
            }

            /* Actualizar/Registrar el Proveedor */
            if (MessageBox.Show("Se procederá a grabar el proveedor, desea continuar?", "Compras", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    string corr = "";

                    if (sOpcion == "UPD")
                    {
                        corr = Convert.ToString(icodProveedor);
                    }
                    else
                    {
                        corr = bProveedor.BCorrelativoProveedor().Rows[0][0].ToString();
                    }
                    fecha = FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2);

                    proveedor = new EProveedor();
                    proveedor.CodProveedor = Convert.ToInt32(corr);
                    proveedor.RazonSocial = txtRazonSocial.Text.Trim();
                    proveedor.Direccion = txtDire.Text.Trim();
                    proveedor.Telefono = Convert.ToInt32(txtTelefono.Text.Trim());
                    proveedor.FechaRegistro = FechaSis;
                    proveedor.Email = txtEmail.Text.Trim();
                    proveedor.Ruc = Convert.ToInt64(txtRUC.Text.Trim());
                    proveedor.Observacion = txtObs.Text.Trim();
                    proveedor.CodCondicionPago = Convert.ToInt32(txtCondPago.Text.Trim());

                    if (rdActivo.Checked)
                    {
                        proveedor.CodEstado = 5;
                    }
                    else
                    {
                        proveedor.CodEstado = 6;
                    }

                    if (sOpcion == "UPD")
                    {
                        proveedor.FechaActualizacion = FechaSis;
                        proveedor.UsuarioModificacion = Program.Usuario;
                    }
                    else
                    {
                        proveedor.FechaRegistro = FechaSis;
                        proveedor.UsuarioRegistro = Program.Usuario;
                    }
                    if (sOpcion == "UPD")
                    {
                        bProveedor.DUpdateProveedor(proveedor);
                        MessageBox.Show("Proveedor actualizado correctamente ", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int result = bProveedor.BInsertProveedor(proveedor);
                        MessageBox.Show("Proveedor registrado correctamente ", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    this.Close();


                
            }
            /* UPC - 14.02.2015 - Edinson Rojas Villarreyes - End */

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se procederá a cerrar la ventana, desea continuar?", "Compras", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Validamos sólo el ingreso de nùmeros */
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Validamos sólo el ingreso de nùmeros */
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Compras.frmListadoCondicionPago frm = new frmListadoCondicionPago();
            frm.ShowDialog();

            txtCondPago.Text = frm.vCodigo;
            lblCondicionPago.Text = frm.vDescripcion;
        }

                
    }
}
