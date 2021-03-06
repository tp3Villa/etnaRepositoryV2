﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Globalization;
using ETNA.SGI.Bussiness.Exportacion;
using ETNA.SGI.Utils;



namespace ETNA.SGI.Presentacion.Formularios.Exportacion
{
    public partial class frmBusquedaRequerimiento : Form
    {
        public frmBusquedaRequerimiento()
        {
            InitializeComponent();
        }


        TControlVB oControl = new TControlVB();


        private BTablas bTablas = BTablas.getInstance();
        private BTransaccion bTransaccion = BTransaccion.getInstance();

        private void frmBusquedaRequerimiento_Load(object sender, EventArgs e)
        {

            dtHasta.MinDate = dtDesde.Value;

            dgvRequerimiento.GridColor = Color.Red;
            //objBus = new BTablas();
            dgvRequerimiento.DataSource = bTablas.BRequerimientos();
        }


        public string vcodigoReq = "";
        public string vRazon = "";
        public string vDestino = "";
        public string vDireccion = "";
        public string vfecha1 = "";
        public string vfecha2 = "";
        public string vPAIS_CAB_REQ = "";

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    vcodigoReq = dgvRequerimiento.Rows[dgvRequerimiento.CurrentCell.RowIndex].Cells["Codigo"].Value.ToString();
                    vRazon = dgvRequerimiento.Rows[dgvRequerimiento.CurrentCell.RowIndex].Cells["razon"].Value.ToString();
                    vDestino = dgvRequerimiento.Rows[dgvRequerimiento.CurrentCell.RowIndex].Cells["Destino"].Value.ToString();
                    vDireccion = dgvRequerimiento.Rows[dgvRequerimiento.CurrentCell.RowIndex].Cells["DIRECCION"].Value.ToString();
                    vfecha1 = dgvRequerimiento.Rows[dgvRequerimiento.CurrentCell.RowIndex].Cells["fecha1"].Value.ToString();
                    vfecha2 = dgvRequerimiento.Rows[dgvRequerimiento.CurrentCell.RowIndex].Cells["fecha2"].Value.ToString();
                    vPAIS_CAB_REQ = dgvRequerimiento.Rows[dgvRequerimiento.CurrentCell.RowIndex].Cells["PAIS_CAB_REQ"].Value.ToString();
                    this.Close();
                }
            }
            catch { }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string cod = txtCod.Text.Trim();
            string razon = txtRazon.Text.Trim();
            decimal Desde = Convert.ToDecimal(dtDesde.Value.Year.ToString() + dtDesde.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtDesde.Value.Day.ToString("00", CultureInfo.InvariantCulture));
            decimal hasta = Convert.ToDecimal(dtHasta.Value.Year.ToString() + dtHasta.Value.Month.ToString("00", CultureInfo.InvariantCulture) + dtHasta.Value.Day.ToString("00", CultureInfo.InvariantCulture));

            //objBus = new BTablas();
            dgvRequerimiento.DataSource = bTablas.BRequerimientosBUSQUEDAANIDAD(cod, razon, Desde, hasta);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvRequerimiento.GridColor = Color.Red;
            //objBus = new BTablas();
            dgvRequerimiento.DataSource = bTablas.BRequerimientos();
        }

        private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            oControl.Numero(e, txtCod);  
        }

        private void txtRazon_KeyPress(object sender, KeyPressEventArgs e)
        {
            oControl.ValidarCajaTexto(e, e.KeyChar);
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            dtHasta.MinDate = dtDesde.Value;
        }
    }
}
