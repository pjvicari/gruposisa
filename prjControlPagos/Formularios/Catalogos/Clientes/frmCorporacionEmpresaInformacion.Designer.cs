namespace ControlPagos.Formularios.Catalogos
{
    partial class frmCorporacionEmpresaInformacion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEmpresa = new System.Windows.Forms.Button();
            this.txtNombreEmpresa = new System.Windows.Forms.TextBox();
            this.txtCodigoEmpresa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoCorporacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpMenu.SuspendLayout();
            this.tpInformacion.SuspendLayout();
            this.tabListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtListado)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMenu
            // 
            this.grpMenu.Location = new System.Drawing.Point(4, 103);
            // 
            // tpInformacion
            // 
            this.tpInformacion.Controls.Add(this.btnEmpresa);
            this.tpInformacion.Controls.Add(this.txtCodigoCorporacion);
            this.tpInformacion.Controls.Add(this.txtNombreEmpresa);
            this.tpInformacion.Controls.Add(this.label1);
            this.tpInformacion.Controls.Add(this.txtCodigoEmpresa);
            this.tpInformacion.Controls.Add(this.label2);
            this.tpInformacion.Size = new System.Drawing.Size(879, 75);
            // 
            // tabListado
            // 
            this.tabListado.Size = new System.Drawing.Size(887, 102);
            // 
            // btnEmpresa
            // 
            this.btnEmpresa.Image = global::ControlPagos.Properties.Resources.buscar_16;
            this.btnEmpresa.Location = new System.Drawing.Point(171, 31);
            this.btnEmpresa.Name = "btnEmpresa";
            this.btnEmpresa.Size = new System.Drawing.Size(22, 23);
            this.btnEmpresa.TabIndex = 31;
            this.btnEmpresa.UseVisualStyleBackColor = true;
            this.btnEmpresa.Click += new System.EventHandler(this.btnEmpresa_Click);
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.Location = new System.Drawing.Point(196, 32);
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.Size = new System.Drawing.Size(669, 20);
            this.txtNombreEmpresa.TabIndex = 30;
            // 
            // txtCodigoEmpresa
            // 
            this.txtCodigoEmpresa.Location = new System.Drawing.Point(68, 32);
            this.txtCodigoEmpresa.Name = "txtCodigoEmpresa";
            this.txtCodigoEmpresa.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoEmpresa.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 28;
            this.label2.Text = "Empresa";
            // 
            // txtCodigoCorporacion
            // 
            this.txtCodigoCorporacion.Location = new System.Drawing.Point(68, 6);
            this.txtCodigoCorporacion.Name = "txtCodigoCorporacion";
            this.txtCodigoCorporacion.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoCorporacion.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 26;
            this.label1.Text = "Código";
            // 
            // frmCorporacionEmpresaInformacion
            // 
            this.ClientSize = new System.Drawing.Size(896, 176);
            this.Name = "frmCorporacionEmpresaInformacion";
            this.Load += new System.EventHandler(this.frmCorporacionEmpresaInformacion_Load);
            this.grpMenu.ResumeLayout(false);
            this.tpInformacion.ResumeLayout(false);
            this.tpInformacion.PerformLayout();
            this.tabListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmpresa;
        private System.Windows.Forms.TextBox txtCodigoCorporacion;
        private System.Windows.Forms.TextBox txtNombreEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoEmpresa;
        private System.Windows.Forms.Label label2;
    }
}
