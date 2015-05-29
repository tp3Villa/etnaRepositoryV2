namespace ETNA.SGI.Presentacion
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Sistema = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ETN01S = new System.Windows.Forms.ToolStripMenuItem();
            this.ETN02S = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paisesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculadoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Compras = new System.Windows.Forms.ToolStripMenuItem();
            this.ETN010C = new System.Windows.Forms.ToolStripMenuItem();
            this.ETN011C = new System.Windows.Forms.ToolStripMenuItem();
            this.ETN012C = new System.Windows.Forms.ToolStripMenuItem();
            this.aprobacionCotizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exportacion = new System.Windows.Forms.ToolStripMenuItem();
            this.ETN05S = new System.Windows.Forms.ToolStripMenuItem();
            this.ETN06S = new System.Windows.Forms.ToolStripMenuItem();
            this.ETN07S = new System.Windows.Forms.ToolStripMenuItem();
            this.ETN08S = new System.Windows.Forms.ToolStripMenuItem();
            this.Consultas = new System.Windows.Forms.ToolStripMenuItem();
            this.Reportes = new System.Windows.Forms.ToolStripMenuItem();
            this.stStrip = new System.Windows.Forms.StatusStrip();
            this.stStrip00 = new System.Windows.Forms.ToolStripProgressBar();
            this.stStrip01 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stStrip02 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stStrip03 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stStrip04 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.stStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.tsbExit,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(691, 61);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::ETNA.SGI.Presentacion.Properties.Resources.CALC1;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(14, 5, 14, 5);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(37, 51);
            this.toolStripButton1.Text = "Calc.";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 61);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::ETNA.SGI.Presentacion.Properties.Resources.close;
            this.tsbExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Margin = new System.Windows.Forms.Padding(14, 5, 14, 5);
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(36, 51);
            this.tsbExit.Text = "&Salir";
            this.tsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 61);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sistema,
            this.Compras,
            this.Exportacion,
            this.Consultas,
            this.Reportes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(691, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Sistema
            // 
            this.Sistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administraciónDeToolStripMenuItem,
            this.ETN01S,
            this.ETN02S,
            this.calculadoraToolStripMenuItem,
            this.acercaDeToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.Sistema.Name = "Sistema";
            this.Sistema.Size = new System.Drawing.Size(60, 20);
            this.Sistema.Text = "&Sistema";
            // 
            // administraciónDeToolStripMenuItem
            // 
            this.administraciónDeToolStripMenuItem.Image = global::ETNA.SGI.Presentacion.Properties.Resources.ACCESOS;
            this.administraciónDeToolStripMenuItem.Name = "administraciónDeToolStripMenuItem";
            this.administraciónDeToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.administraciónDeToolStripMenuItem.Text = "Cambio de Contraseña";
            // 
            // ETN01S
            // 
            this.ETN01S.Image = global::ETNA.SGI.Presentacion.Properties.Resources.mant;
            this.ETN01S.Name = "ETN01S";
            this.ETN01S.Size = new System.Drawing.Size(199, 22);
            this.ETN01S.Text = "Administración Sistema";
            this.ETN01S.Visible = false;
            this.ETN01S.Click += new System.EventHandler(this.adminstracionSistemaToolStripMenuItem_Click);
            // 
            // ETN02S
            // 
            this.ETN02S.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.paisesToolStripMenuItem});
            this.ETN02S.Image = global::ETNA.SGI.Presentacion.Properties.Resources.abacus;
            this.ETN02S.Name = "ETN02S";
            this.ETN02S.Size = new System.Drawing.Size(199, 22);
            this.ETN02S.Text = "Tabla";
            this.ETN02S.Visible = false;
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Image = global::ETNA.SGI.Presentacion.Properties.Resources.conference1;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // paisesToolStripMenuItem
            // 
            this.paisesToolStripMenuItem.Image = global::ETNA.SGI.Presentacion.Properties.Resources.PAISES;
            this.paisesToolStripMenuItem.Name = "paisesToolStripMenuItem";
            this.paisesToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.paisesToolStripMenuItem.Text = "Paises";
            this.paisesToolStripMenuItem.Click += new System.EventHandler(this.paisesToolStripMenuItem_Click);
            // 
            // calculadoraToolStripMenuItem
            // 
            this.calculadoraToolStripMenuItem.Image = global::ETNA.SGI.Presentacion.Properties.Resources.CALC1;
            this.calculadoraToolStripMenuItem.Name = "calculadoraToolStripMenuItem";
            this.calculadoraToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.calculadoraToolStripMenuItem.Text = "Calculadora";
            this.calculadoraToolStripMenuItem.Click += new System.EventHandler(this.calculadoraToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Image = global::ETNA.SGI.Presentacion.Properties.Resources.ACERCA_DE;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::ETNA.SGI.Presentacion.Properties.Resources.close;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // Compras
            // 
            this.Compras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ETN010C,
            this.ETN011C,
            this.ETN012C,
            this.aprobacionCotizacionToolStripMenuItem});
            this.Compras.Name = "Compras";
            this.Compras.Size = new System.Drawing.Size(67, 20);
            this.Compras.Text = "&Compras";
            this.Compras.Click += new System.EventHandler(this.Compras_Click);
            // 
            // ETN010C
            // 
            this.ETN010C.Image = global::ETNA.SGI.Presentacion.Properties.Resources.BO12;
            this.ETN010C.Name = "ETN010C";
            this.ETN010C.Size = new System.Drawing.Size(193, 22);
            this.ETN010C.Text = "Proveedor";
            this.ETN010C.Visible = false;
            this.ETN010C.Click += new System.EventHandler(this.proveedorToolStripMenuItem_Click);
            // 
            // ETN011C
            // 
            this.ETN011C.Image = global::ETNA.SGI.Presentacion.Properties.Resources.CALC1;
            this.ETN011C.Name = "ETN011C";
            this.ETN011C.Size = new System.Drawing.Size(193, 22);
            this.ETN011C.Text = "Orden de Compra";
            this.ETN011C.Visible = false;
            this.ETN011C.Click += new System.EventHandler(this.ordenDeCompraToolStripMenuItem_Click);
            // 
            // ETN012C
            // 
            this.ETN012C.Image = global::ETNA.SGI.Presentacion.Properties.Resources.CALC1;
            this.ETN012C.Name = "ETN012C";
            this.ETN012C.Size = new System.Drawing.Size(193, 22);
            this.ETN012C.Text = "Cotización";
            this.ETN012C.Visible = false;
            this.ETN012C.Click += new System.EventHandler(this.ETN03C_Click);
            // 
            // aprobacionCotizacionToolStripMenuItem
            // 
            this.aprobacionCotizacionToolStripMenuItem.Image = global::ETNA.SGI.Presentacion.Properties.Resources.FACTURAR12;
            this.aprobacionCotizacionToolStripMenuItem.Name = "aprobacionCotizacionToolStripMenuItem";
            this.aprobacionCotizacionToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.aprobacionCotizacionToolStripMenuItem.Text = "Aprobación cotización";
            this.aprobacionCotizacionToolStripMenuItem.Click += new System.EventHandler(this.aprobacionCotizacionToolStripMenuItem_Click);
            // 
            // Exportacion
            // 
            this.Exportacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ETN05S,
            this.ETN06S,
            this.ETN07S,
            this.ETN08S});
            this.Exportacion.Name = "Exportacion";
            this.Exportacion.Size = new System.Drawing.Size(81, 20);
            this.Exportacion.Text = "&Exportación";
            this.Exportacion.Click += new System.EventHandler(this.Exportacion_Click);
            // 
            // ETN05S
            // 
            this.ETN05S.Image = global::ETNA.SGI.Presentacion.Properties.Resources.CALC1;
            this.ETN05S.Name = "ETN05S";
            this.ETN05S.Size = new System.Drawing.Size(187, 22);
            this.ETN05S.Text = "Requerimiento ";
            this.ETN05S.Visible = false;
            this.ETN05S.Click += new System.EventHandler(this.requerimientoToolStripMenuItem_Click);
            // 
            // ETN06S
            // 
            this.ETN06S.Image = global::ETNA.SGI.Presentacion.Properties.Resources.BO12;
            this.ETN06S.Name = "ETN06S";
            this.ETN06S.Size = new System.Drawing.Size(187, 22);
            this.ETN06S.Text = "Solicitud de Atención";
            this.ETN06S.Visible = false;
            this.ETN06S.Click += new System.EventHandler(this.anulaciónDeFacturaToolStripMenuItem_Click);
            // 
            // ETN07S
            // 
            this.ETN07S.Image = global::ETNA.SGI.Presentacion.Properties.Resources.FACTURAR12;
            this.ETN07S.Name = "ETN07S";
            this.ETN07S.Size = new System.Drawing.Size(187, 22);
            this.ETN07S.Text = "Formato Comercial";
            this.ETN07S.Visible = false;
            this.ETN07S.Click += new System.EventHandler(this.formatoComercialToolStripMenuItem_Click);
            // 
            // ETN08S
            // 
            this.ETN08S.Image = global::ETNA.SGI.Presentacion.Properties.Resources.Aprobado;
            this.ETN08S.Name = "ETN08S";
            this.ETN08S.Size = new System.Drawing.Size(187, 22);
            this.ETN08S.Text = "Aprobación Solicitud";
            this.ETN08S.Visible = false;
            this.ETN08S.Click += new System.EventHandler(this.aprobacionSolicitudToolStripMenuItem_Click);
            // 
            // Consultas
            // 
            this.Consultas.Name = "Consultas";
            this.Consultas.Size = new System.Drawing.Size(71, 20);
            this.Consultas.Text = "&Consultas";
            // 
            // Reportes
            // 
            this.Reportes.Name = "Reportes";
            this.Reportes.Size = new System.Drawing.Size(65, 20);
            this.Reportes.Text = "Reportes";
            // 
            // stStrip
            // 
            this.stStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stStrip00,
            this.stStrip01,
            this.stStrip02,
            this.stStrip03,
            this.stStrip04});
            this.stStrip.Location = new System.Drawing.Point(0, 379);
            this.stStrip.Name = "stStrip";
            this.stStrip.Size = new System.Drawing.Size(691, 22);
            this.stStrip.TabIndex = 10;
            this.stStrip.Text = "statusStrip1";
            // 
            // stStrip00
            // 
            this.stStrip00.Name = "stStrip00";
            this.stStrip00.Size = new System.Drawing.Size(300, 16);
            // 
            // stStrip01
            // 
            this.stStrip01.Name = "stStrip01";
            this.stStrip01.Size = new System.Drawing.Size(111, 17);
            this.stStrip01.Text = "Aplicación: nombre";
            // 
            // stStrip02
            // 
            this.stStrip02.Name = "stStrip02";
            this.stStrip02.Size = new System.Drawing.Size(83, 17);
            this.stStrip02.Text = "Usuario: name";
            // 
            // stStrip03
            // 
            this.stStrip03.Name = "stStrip03";
            this.stStrip03.Size = new System.Drawing.Size(41, 17);
            this.stStrip03.Text = "Fecha:";
            // 
            // stStrip04
            // 
            this.stStrip04.Name = "stStrip04";
            this.stStrip04.Size = new System.Drawing.Size(36, 17);
            this.stStrip04.Text = "Hora:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ETNA.SGI.Presentacion.Properties.Resources.ETc;
            this.pictureBox1.Location = new System.Drawing.Point(68, 116);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(570, 219);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(691, 401);
            this.Controls.Add(this.stStrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Módulo Integrado Baterias ETNA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.stStrip.ResumeLayout(false);
            this.stStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Sistema;
        private System.Windows.Forms.ToolStripMenuItem administraciónDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Compras;
        private System.Windows.Forms.ToolStripMenuItem ETN010C;
        private System.Windows.Forms.ToolStripMenuItem Exportacion;
        private System.Windows.Forms.ToolStripMenuItem ETN06S;
        private System.Windows.Forms.ToolStripMenuItem Consultas;
        private System.Windows.Forms.ToolStripMenuItem Reportes;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem ETN01S;
        private System.Windows.Forms.ToolStripMenuItem calculadoraToolStripMenuItem;
        private System.Windows.Forms.StatusStrip stStrip;
        private System.Windows.Forms.ToolStripProgressBar stStrip00;
        private System.Windows.Forms.ToolStripStatusLabel stStrip01;
        private System.Windows.Forms.ToolStripStatusLabel stStrip02;
        private System.Windows.Forms.ToolStripStatusLabel stStrip03;
        private System.Windows.Forms.ToolStripStatusLabel stStrip04;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ETN05S;
        private System.Windows.Forms.ToolStripMenuItem ETN07S;
        private System.Windows.Forms.ToolStripMenuItem ETN08S;
        private System.Windows.Forms.ToolStripMenuItem ETN02S;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paisesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ETN011C;
        private System.Windows.Forms.ToolStripMenuItem ETN012C;
        private System.Windows.Forms.ToolStripMenuItem aprobacionCotizacionToolStripMenuItem;
    }
}

