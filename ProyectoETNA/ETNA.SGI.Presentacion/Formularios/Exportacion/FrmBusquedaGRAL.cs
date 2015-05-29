using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ETNA.SGI.Bussiness.Exportacion;

namespace ETNA.SGI.Presentacion.Formularios.Exportacion
{
    public partial class FrmBusquedaGRAL : Form
    {
        public FrmBusquedaGRAL()
        {
            InitializeComponent();
        }

        public string Busqueda = "";
        public string cod_pai_IATA = "";


        public string vCodigo = "";
        public string vDescripcion = "";
        public decimal vPrecio = 0;
        public decimal vPeso = 0;
        public string vUnidaMed = "";


        



        BTablas oBusTab = new BTablas();
        DataView dv = new DataView();
        DataTable dt = new DataTable();
       

        private void FrmBusquedaGRAL_Load(object sender, EventArgs e)
        {
            dgvBusqueda.GridColor = Color.Red;
            if (Busqueda == "PAI")
            {
                Paises();
                cboBusqueda.SelectedIndex = 1;
                txtBusqueda.Focus();
            }

            if (Busqueda == "PRD")
            {
                Producto();
                cboBusqueda.SelectedIndex = 1;
                txtBusqueda.Focus();
            }

            if (Busqueda == "CLI")
            {
                Cliente();
                cboBusqueda.SelectedIndex = 1;
                txtBusqueda.Focus();
            }

            if (Busqueda == "IAT")
            {
                IATA();
                cboBusqueda.SelectedIndex = 1;
                txtBusqueda.Focus();
            }


        }

        void Paises()
        {
            Text = "Lista de Paises";
            lblBusqueda.Text = "Lista de Paises";

            oBusTab = new BTablas();
            dt = oBusTab.BPaises();
            dgvBusqueda.DataSource = dt;

            cboBusqueda.Items.Add("Cod.Pais");
            cboBusqueda.Items.Add("Des.Pais");

            dgvBusqueda.Columns["Codigo"].Visible = false;
            dgvBusqueda.Columns["Cod_Prod"].Visible = false;
            dgvBusqueda.Columns["iata_cod"].Visible = false;

            dgvBusqueda.Columns["Cod_Pais"].DisplayIndex = 0;
            dgvBusqueda.Columns["Nom_Pais"].DisplayIndex = 1;

            dgvBusqueda.Columns["Cod_Pais"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["Nom_Pais"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBusqueda.Columns["Cod_Pais"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["Nom_Pais"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvBusqueda.Columns["Cod_Pais"].Width = 120;
            dgvBusqueda.Columns["Nom_Pais"].Width = 300;
        }


        void IATA()
        {
            Text = "Lista IATA";
            lblBusqueda.Text = "Lista IATA";

            oBusTab = new BTablas();
            dt = oBusTab.BPaisesIATA(cod_pai_IATA);
            dgvBusqueda.DataSource = dt;

            cboBusqueda.Items.Add("Cod.IATA");
            cboBusqueda.Items.Add("Des.IATA");

            dgvBusqueda.Columns["Codigo"].Visible = false;
            dgvBusqueda.Columns["Cod_Prod"].Visible = false;
            dgvBusqueda.Columns["Cod_Pais"].Visible = false;
            dgvBusqueda.Columns["iata_cod"].DisplayIndex = 0;
            dgvBusqueda.Columns["iata_des"].DisplayIndex = 1;

            dgvBusqueda.Columns["iata_cod"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["iata_des"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBusqueda.Columns["iata_cod"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["iata_des"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvBusqueda.Columns["Cod_Pais"].Width = 120;
            dgvBusqueda.Columns["iata_des"].Width = 300;
        }


        void Cliente()
        {
            Text = "Lista de Clientes";
            lblBusqueda.Text = "Lista de Clientes";

            oBusTab = new BTablas();
            dt = oBusTab.BClienteCodRaz();
            dgvBusqueda.DataSource = dt;

            cboBusqueda.Items.Add("Cod.Cliente");
            cboBusqueda.Items.Add("Des.Cliente");

            dgvBusqueda.Columns["Cod_Prod"].Visible = false;
            dgvBusqueda.Columns["Cod_Pais"].Visible = false;
            dgvBusqueda.Columns["iata_cod"].Visible = false;
            dgvBusqueda.Columns["codigo"].DisplayIndex = 0;
            dgvBusqueda.Columns["razon_social"].DisplayIndex = 1;

            dgvBusqueda.Columns["codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["razon_social"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBusqueda.Columns["codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["razon_social"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvBusqueda.Columns["codigo"].Width = 120;
            dgvBusqueda.Columns["razon_social"].Width = 300;

        }

        void Producto()
        {
            Text = "Lista de Producto";
            lblBusqueda.Text = "Lista de Producto";

            oBusTab = new BTablas();
            dt = oBusTab.BProducto();
            dgvBusqueda.DataSource = dt;

            cboBusqueda.Items.Add("Cod.Producto");
            cboBusqueda.Items.Add("Des.Producto");

            dgvBusqueda.Columns["Codigo"].Visible = false;
            dgvBusqueda.Columns["Cod_Pais"].Visible = false;
            dgvBusqueda.Columns["iata_cod"].Visible = false;
            dgvBusqueda.Columns["Pre_Prod"].Visible = false;
            dgvBusqueda.Columns["Cod_Prod"].DisplayIndex = 0;
            dgvBusqueda.Columns["Des_Prod"].DisplayIndex = 1;
            dgvBusqueda.Columns["Cod_Unidad"].DisplayIndex = 2;
            dgvBusqueda.Columns["Pes_Prod"].DisplayIndex = 3;

            dgvBusqueda.Columns["Cod_Prod"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["Des_Prod"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["Cod_Unidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["Pes_Prod"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBusqueda.Columns["Cod_Prod"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["Des_Prod"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvBusqueda.Columns["Cod_Unidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["Pes_Prod"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvBusqueda.Columns["Cod_Prod"].Width = 100;
            dgvBusqueda.Columns["Des_Prod"].Width = 150;
            dgvBusqueda.Columns["Cod_Unidad"].Width = 80;
            dgvBusqueda.Columns["Pes_Prod"].Width = 100;




        }
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (Busqueda == "PAI")
            {
                try
                {
                    switch (cboBusqueda.SelectedIndex)
                    {
                        case 0:
                            dv = new DataView(dt, "Cod_Pais like '%" + txtBusqueda.Text.ToString() + "%'", "Cod_Pais ASC", DataViewRowState.OriginalRows);
                            dgvBusqueda.DataSource = dv;
                            break;
                        case 1:
                            dv = new DataView(dt, "Nom_Pais like '%" + txtBusqueda.Text.ToString() + "%'", "Nom_Pais ASC", DataViewRowState.OriginalRows);
                            dgvBusqueda.DataSource = dv;
                            break;
                    }
                }
                catch
                {
                    dv = new DataView(dt, "", "Cod_Pais ASC", DataViewRowState.OriginalRows);
                    dgvBusqueda.DataSource = dv;
                }
            }

            if (Busqueda == "IAT")
            {
                try
                {
                    switch (cboBusqueda.SelectedIndex)
                    {
                        case 0:
                            dv = new DataView(dt, "iata_cod like '%" + txtBusqueda.Text.ToString() + "%'", "iata_cod ASC", DataViewRowState.OriginalRows);
                            dgvBusqueda.DataSource = dv;
                            break;
                        case 1:
                            dv = new DataView(dt, "iata_des like '%" + txtBusqueda.Text.ToString() + "%'", "iata_des ASC", DataViewRowState.OriginalRows);
                            dgvBusqueda.DataSource = dv;
                            break;
                    }
                }
                catch
                {
                    dv = new DataView(dt, "", "iata_cod ASC", DataViewRowState.OriginalRows);
                    dgvBusqueda.DataSource = dv;
                }
            }


            if (Busqueda == "PRD")
            {
                try
                {
                    switch (cboBusqueda.SelectedIndex)
                    {
                        case 0:
                            dv = new DataView(dt, "Cod_Prod = '" + txtBusqueda.Text.ToString() + "'", "Cod_Prod ASC", DataViewRowState.OriginalRows);
                            dgvBusqueda.DataSource = dv;
                            break;
                        case 1:
                            dv = new DataView(dt, "Des_Prod like '%" + txtBusqueda.Text.ToString() + "%'", "Des_Prod ASC", DataViewRowState.OriginalRows);
                            dgvBusqueda.DataSource = dv;
                            break;
                    }
                }
                catch
                {
                    dv = new DataView(dt, "", "Cod_Prod ASC", DataViewRowState.OriginalRows);
                    dgvBusqueda.DataSource = dv;
                }
            }


            if (Busqueda == "CLI")
            {
                try
                {
                    switch (cboBusqueda.SelectedIndex)
                    {
                        case 0:
                            dv = new DataView(dt, "Codigo = '" + txtBusqueda.Text.ToString() + "'", "Codigo ASC", DataViewRowState.OriginalRows);
                            dgvBusqueda.DataSource = dv;
                            break;
                        case 1:
                            dv = new DataView(dt, "razon_social like '%" + txtBusqueda.Text.ToString() + "%'", "razon_social ASC", DataViewRowState.OriginalRows);
                            dgvBusqueda.DataSource = dv;
                            break;
                    }
                }
                catch
                {
                    dv = new DataView(dt, "", "Codigo ASC", DataViewRowState.OriginalRows);
                    dgvBusqueda.DataSource = dv;
                }
            }
        }

        private void dgvBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Busqueda == "PAI")
            {
                if (e.ColumnIndex == 3)
                {
                    try
                    {
                        int p = dgvBusqueda.CurrentRow.Index;
                        vCodigo = dgvBusqueda.Rows[p].Cells["Cod_Pais"].Value.ToString();
                        vDescripcion = dgvBusqueda.Rows[p].Cells["Nom_Pais"].Value.ToString();
                        this.Close();
                    }
                    catch { }
                }
            }

            if (Busqueda == "IAT")
            {
                if (e.ColumnIndex == 3)
                {
                    try
                    {
                        int p = dgvBusqueda.CurrentRow.Index;
                        vCodigo = dgvBusqueda.Rows[p].Cells["iata_cod"].Value.ToString();
                        vDescripcion = dgvBusqueda.Rows[p].Cells["iata_des"].Value.ToString();
                        this.Close();
                    }
                    catch { }
                }
            }

            if (Busqueda == "PRD")
            {
                if (e.ColumnIndex == 3)
                {
                    try
                    {
                        int p = dgvBusqueda.CurrentRow.Index;
                        vCodigo = dgvBusqueda.Rows[p].Cells["Cod_Prod"].Value.ToString();
                        vDescripcion = dgvBusqueda.Rows[p].Cells["Des_Prod"].Value.ToString();
                        vPrecio = Convert.ToDecimal(dgvBusqueda.Rows[p].Cells["Pre_Prod"].Value.ToString());
                        vUnidaMed = dgvBusqueda.Rows[p].Cells["Cod_Unidad"].Value.ToString();
                        vPeso = Convert.ToDecimal(dgvBusqueda.Rows[p].Cells["Pes_Prod"].Value.ToString()); ;

                        this.Close();
                    }
                    catch { }
                }
            }

            if (Busqueda == "CLI")
            {
                if (e.ColumnIndex == 3)
                {
                    try
                    {
                        int p = dgvBusqueda.CurrentRow.Index;
                        vCodigo = dgvBusqueda.Rows[p].Cells["Codigo"].Value.ToString();
                        vDescripcion = dgvBusqueda.Rows[p].Cells["razon_social"].Value.ToString();
                        this.Close();
                    }
                    catch { }
                }
            }
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Busqueda == "PAI")
            {
                switch (cboBusqueda.SelectedIndex)
                {
                    case 0:
                        dv = new DataView(dt, "", "Cod_Pais ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                        break;
                    case 1:
                        dv = new DataView(dt, "", "Nom_Pais ASC", DataViewRowState.OriginalRows);
                        break;
                }
            }

            if (Busqueda == "IAT")
            {
                switch (cboBusqueda.SelectedIndex)
                {
                    case 0:
                        dv = new DataView(dt, "", "iata_cod ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                        break;
                    case 1:
                        dv = new DataView(dt, "", "iata_cod ASC", DataViewRowState.OriginalRows);
                        break;
                }
            }

            if (Busqueda == "PRD")
            {
                switch (cboBusqueda.SelectedIndex)
                {
                    case 0:
                        dv = new DataView(dt, "", "Cod_Prod ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                        break;
                    case 1:
                        dv = new DataView(dt, "", "Des_Prod ASC", DataViewRowState.OriginalRows);
                        break;
                }
            }


            if (Busqueda == "CLI")
            {
                switch (cboBusqueda.SelectedIndex)
                {
                    case 0:
                        dv = new DataView(dt, "", "Codigo ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                        break;
                    case 1:
                        dv = new DataView(dt, "", "razon_social ASC", DataViewRowState.OriginalRows);
                        break;
                }
            }


        }
    }
}
