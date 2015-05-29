using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ETNA.SGI.Bussiness.Exportacion;
using ETNA.SGI.Entity.Exportacion;
using ETNA.SGI.Utils;




namespace ETNA.SGI.Presentacion.Formularios
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }


        DataTable dtOcpionesxUsuario = new DataTable();
        BTablas objBusTab = new BTablas();
        BTransaccion objTra = new BTransaccion();
        ELogin eLogin = new ELogin();
        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            txtNom.CharacterCasing = CharacterCasing.Upper;
            txtUsu.CharacterCasing = CharacterCasing.Upper;
            txtPwd.CharacterCasing = CharacterCasing.Upper; 

            if (rdb1.Checked == true)
            {
                btnBuscar.Visible = false;
            }
            else
            {
                btnBuscar.Visible = true;            
            }

            dgvUsuarios.GridColor = Color.Red;  
            objBusTab = new BTablas();
            dgvUsuarios.DataSource = objBusTab.getSELECTLIBRE("SELECT * FROM USUARIO WHERE ESTADO_USUARIO='A'");
            dgvUsuarios.Columns["Cod_Usuario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.Columns["Nom_Usuario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.Columns["Tipo_Usuario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            RolearGillaDGVUSUARIO();


            dgvUsuarios1.GridColor = Color.Red;
            objBusTab = new BTablas();
            dgvUsuarios1.DataSource = objBusTab.getSELECTLIBRE("SELECT * FROM USUARIO WHERE ESTADO_USUARIO='A'");
            int j = 0;
            objBusTab = new BTablas();
            DataTable dtOcpiones = objBusTab.getSELECTLIBRE("select cod_opcionmenu,des_opcionmenu from dbo.OpcMenu");
            while (j <= dtOcpiones.Rows.Count - 1)
            {
                ListViewItem List;
                List = lvAccesos.Items.Add(dtOcpiones.Rows[j]["cod_opcionmenu"].ToString());
                List.SubItems.Add(dtOcpiones.Rows[j]["des_opcionmenu"].ToString());
                j += 1;
            }

            objBusTab = new BTablas();
            dtOcpionesxUsuario = objBusTab.getSELECTLIBRE("select * from dbo.UsuMenu");
        }


        string Nom_Usuario1 = "";
        string Cod_Usuario1 = "";
        string Pwd_Usuario1 = "";

        string Tipo_Usuario1 = "";
        string Estado_Usuario1 = "";
        string Filler11 = "";


        string SW = "";

        void RolearGillaDGVUSUARIO()
        {
            try
            {
                int p = dgvUsuarios.CurrentRow.Index;

                Nom_Usuario1 = dgvUsuarios.Rows[p].Cells["Nom_Usuario"].Value.ToString().Trim();
                Cod_Usuario1 = dgvUsuarios.Rows[p].Cells["Cod_Usuario"].Value.ToString().Trim();
                Pwd_Usuario1 = dgvUsuarios.Rows[p].Cells["Pwd_Usuario"].Value.ToString().Trim();
                Tipo_Usuario1 = dgvUsuarios.Rows[p].Cells["Tipo_Usuario"].Value.ToString().Trim();
                Estado_Usuario1 = dgvUsuarios.Rows[p].Cells["Estado_Usuario"].Value.ToString().Trim();
                Filler11 = dgvUsuarios.Rows[p].Cells["Filler1"].Value.ToString().Trim();

                txtNom.Text = Nom_Usuario1;
                txtUsu.Text = Cod_Usuario1;
                txtPwd.Text = Pwd_Usuario1;

                if (Tipo_Usuario1 == "C") { rdb2.Checked = true; }
                else { rdb1.Checked = true; }
            }
            catch { }
        }


        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            btnBuscar.Visible = false;
        }

        private void rdb2_CheckedChanged(object sender, EventArgs e)
        {
            btnBuscar.Visible = true;
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rdb1.Enabled = false;
            rdb2.Enabled = false;
            txtNom.Enabled = false;
            txtUsu.Enabled = false;
            txtPwd.Enabled = false;
            btnBuscar.Enabled = false;
            SW = "";
            btnNuevo.Enabled = true;
            btnModifica.Enabled = true;
            btnEliminar.Enabled = true;
            btnConfirmar.Enabled = false;
            RolearGillaDGVUSUARIO();
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            RolearGillaDGVUSUARIO();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            rdb1.Checked = true;
            rdb1.Enabled = true;
            rdb2.Enabled = true;          

            SW = "NEW";
            Limpiar();
            txtNom.Enabled = true;
            txtPwd.Enabled = true;
            txtUsu.Enabled = true;
            btnBuscar.Enabled = true;
            btnConfirmar.Enabled = true;
            btnModifica.Enabled = false;
            btnEliminar.Enabled = false;

        }

        void Limpiar()
        {
            txtNom.Text = "";
            txtUsu.Text = "";
            txtPwd.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnConfirmar.Enabled = false;
            btnNuevo.Enabled = false;
            btnModifica.Enabled = false;

            if (MessageBox.Show("Desea Eliminar Usuario", "Alm. Ing.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                objTra = new BTransaccion();
                int i = objTra.DDeleteUSUARIO(Cod_Usuario1);
                if (i == 1)
                {
                    MessageBox.Show("Eliminación Correcto", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Fallo Eliminación", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


            dgvUsuarios.GridColor = Color.Red;
            objBusTab = new BTablas();
            dgvUsuarios.DataSource = objBusTab.getSELECTLIBRE("SELECT * FROM USUARIO WHERE ESTADO_USUARIO='A'");

            dgvUsuarios1.GridColor = Color.Red;
            objBusTab = new BTablas();
            dgvUsuarios1.DataSource = objBusTab.getSELECTLIBRE("SELECT * FROM USUARIO WHERE ESTADO_USUARIO='A'");

            rdb1.Enabled = false;
            rdb2.Enabled = false;
            txtNom.Enabled = false;
            txtUsu.Enabled = false;
            txtPwd.Enabled = false;
            btnBuscar.Enabled = false;
            SW = "";
            btnNuevo.Enabled = true;
            btnModifica.Enabled = true;
            btnEliminar.Enabled = true;
            btnConfirmar.Enabled = false;
            RolearGillaDGVUSUARIO();

        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            SW = "CHG";
            txtPwd.Enabled = true;
            txtUsu.Enabled = true;
            btnConfirmar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Exportacion.FrmBusquedaGRAL frm = new Exportacion.FrmBusquedaGRAL();
            //OT = Orden de Trabajo
            frm.Busqueda = "CLI";
            frm.ShowDialog();
            Nom_Usuario1 = frm.vDescripcion;
            Filler11 = frm.vCodigo;
            txtNom.Text = Nom_Usuario1;

            //codPais = frm.vCodigo;
            //nomPais = frm.vDescripcion;
            //txtPai.Text = frm.vDescripcion;
            this.Cursor = Cursors.Default;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (SW == "NEW")
                {
                    if (MessageBox.Show("Desea Ingresar Usuario", "Exportación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        eLogin = new ELogin();
                        eLogin.Usuario = txtUsu.Text.Trim();
                        eLogin.Pasw = txtPwd.Text.Trim();
                        eLogin.Nom_Usuario = txtNom.Text.Trim();
                        if (rdb1.Checked == true) { eLogin.Tipo_Usuario = "E"; eLogin.Filler1 = ""; }
                        else { eLogin.Tipo_Usuario = "C"; eLogin.Filler1 = Filler11; }
                        eLogin.Estado_Usuario = "A";   
                        objTra = new BTransaccion();
                        int i = objTra.BInserUsuario(eLogin);
                        if (i == 1)
                        {
                            MessageBox.Show("Ingreso Correcto", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Fallo Ingreso", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                if (SW == "CHG")
                {
                    if (MessageBox.Show("Desea Modificar Usuario", "Alm. Ing.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        objTra = new BTransaccion();
                        int i = objTra.DUpdateUSUARIO(Cod_Usuario1, "cod_usuario='" + txtUsu.Text.Trim() + "',pwd_usuario='" + txtPwd.Text.Trim() + "'");
                        if (i == 1)
                        {
                            MessageBox.Show("Modificación Correcta", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Fallo Modificación", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch { }

            dgvUsuarios.GridColor = Color.Red;
            objBusTab = new BTablas();
            dgvUsuarios.DataSource = objBusTab.getSELECTLIBRE("SELECT * FROM USUARIO WHERE ESTADO_USUARIO='A'");

            dgvUsuarios1.GridColor = Color.Red;
            objBusTab = new BTablas();
            dgvUsuarios1.DataSource = objBusTab.getSELECTLIBRE("SELECT * FROM USUARIO WHERE ESTADO_USUARIO='A'");

            rdb1.Enabled = false;
            rdb2.Enabled = false;
            txtNom.Enabled = false;
            txtUsu.Enabled = false;
            txtPwd.Enabled = false;
            btnBuscar.Enabled = false;
            SW = "";
            btnNuevo.Enabled = true;
            btnModifica.Enabled = true;
            btnEliminar.Enabled = true;
            btnConfirmar.Enabled = false;
            RolearGillaDGVUSUARIO();





        }


        DataView dvOpcionesxUsuario = new DataView();
        string CodigoUsers = "";
        string opcion = "";
        private void button4_Click(object sender, EventArgs e)
        {           

            int p = dgvUsuarios1.CurrentRow.Index;
            CodigoUsers = dgvUsuarios1.Rows[p].Cells["Cod_Usuario2"].Value.ToString().Trim();
            /*ListView Cuenta Almacen*/
            int i = 0;
            int k = 0;
            string flat = "";
            while (i <= lvAccesos.Items.Count - 1)
            {
                if (lvAccesos.Items[i].Checked == true)
                {
                    k = 0;
                    opcion = lvAccesos.Items[i].Text.ToString().Trim();
                    flat = "1";
                }
                i += 1;
            }

            if (flat == "")
            {
                MessageBox.Show("Ingrese Accesos", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            i = 0;
            k = 0;
            objTra = new BTransaccion();
            k = objTra.BDeleteUsuMenu(CodigoUsers);
            k = 0;
            while (i <= lvAccesos.Items.Count - 1)
            {
                if (lvAccesos.Items[i].Checked == true)
                {
                    k = 0;
                    opcion = lvAccesos.Items[i].Text.ToString().Trim();
                    objTra = new BTransaccion();
                    k = objTra.BInserUsuMenu(CodigoUsers, opcion);
                    flat = "1";
                }
                i += 1;
            }


            

            if (k == 1)
            {
                MessageBox.Show("Ingreso Correcto", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            objBusTab = new BTablas();
            dtOcpionesxUsuario = objBusTab.getSELECTLIBRE("select * from dbo.UsuMenu");
        }       
       

        private void dgvUsuarios1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int p = dgvUsuarios1.CurrentRow.Index;
            CodigoUsers = dgvUsuarios1.Rows[p].Cells["Cod_Usuario2"].Value.ToString().Trim();
            dvOpcionesxUsuario = new DataView(dtOcpionesxUsuario, "cod_usu = '" + CodigoUsers + "' ", "", DataViewRowState.OriginalRows);
            int i = 0;
            while (i <= lvAccesos.Items.Count - 1)
            {
                lvAccesos.Items[i].Checked = false;
                i += 1;
            }
            i = 0;
            if (dvOpcionesxUsuario.Count > 0)
            {
                while (i <= lvAccesos.Items.Count - 1)
                {
                    for (int j = 0; j <= dvOpcionesxUsuario.Count - 1; j++)
                    {
                        if (lvAccesos.Items[i].Text.ToString().Trim() == dvOpcionesxUsuario[j]["cod_men"].ToString().Trim())
                        {
                            lvAccesos.Items[i].Checked = true;
                        }
                    }
                    i += 1;
                }
            }
            else
            {
                while (i <= lvAccesos.Items.Count - 1)
                {
                    lvAccesos.Items[i].Checked = false;
                    i += 1;
                }
            }
        }

        private void dgvUsuarios1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int p = dgvUsuarios1.CurrentRow.Index;
                CodigoUsers = dgvUsuarios1.Rows[p].Cells["Cod_Usuario2"].Value.ToString().Trim();
                dvOpcionesxUsuario = new DataView(dtOcpionesxUsuario, "cod_usu = '" + CodigoUsers + "' ", "", DataViewRowState.OriginalRows);
                int i = 0;
                while (i <= lvAccesos.Items.Count - 1)
                {
                    lvAccesos.Items[i].Checked = false;
                    i += 1;
                }
                i = 0;
                if (dvOpcionesxUsuario.Count > 0)
                {
                    while (i <= lvAccesos.Items.Count - 1)
                    {
                        for (int j = 0; j <= dvOpcionesxUsuario.Count - 1; j++)
                        {
                            if (lvAccesos.Items[i].Text.ToString().Trim() == dvOpcionesxUsuario[j]["cod_men"].ToString().Trim())
                            {
                                lvAccesos.Items[i].Checked = true;
                            }
                        }
                        i += 1;
                    }
                }
                else
                {
                    while (i <= lvAccesos.Items.Count - 1)
                    {
                        lvAccesos.Items[i].Checked = false;
                        i += 1;
                    }
                }
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int p = dgvUsuarios1.CurrentRow.Index;
            CodigoUsers = dgvUsuarios1.Rows[p].Cells["Cod_Usuario2"].Value.ToString().Trim();
            if (MessageBox.Show("Desea Eliminar Accesos Users.", "Alm. Ing.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                objTra = new BTransaccion();
                int i = objTra.BDeleteUsuMenu(CodigoUsers);
                if (i == 1)
                {
                    MessageBox.Show("Eliminación Correcto", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Fallo Eliminación", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 
            objBusTab = new BTablas();
            dtOcpionesxUsuario = objBusTab.getSELECTLIBRE("select * from dbo.UsuMenu");
        }
    }
}
