namespace ControlPagos.Formularios.Catalogos
{
    partial class frmContactoAsociacionInformacion
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
            this.txtCodigoContacto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.txtTipoCliente = new System.Windows.Forms.TextBox();
            this.txtCodigoClienteContacto = new System.Windows.Forms.TextBox();
            this.grpMenu.SuspendLayout();
            this.tpInformacion.SuspendLayout();
            this.tabListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtListado)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMenu
            // 
            this.grpMenu.Location = new System.Drawing.Point(4, 94);
            // 
            // tpInformacion
            // 
            this.tpInformacion.Controls.Add(this.txtCodigoClienteContacto);
            this.tpInformacion.Controls.Add(this.txtTipoCliente);
            this.tpInformacion.Controls.Add(this.btnCliente);
            this.tpInformacion.Controls.Add(this.txtNombreCliente);
            this.tpInformacion.Controls.Add(this.txtCodigoCliente);
            this.tpInformacion.Controls.Add(this.label2);
            this.tpInformacion.Controls.Add(this.txtCodigoContacto);
            this.tpInformacion.Controls.Add(this.label1);
            this.tpInformacion.Size = new System.Drawing.Size(879, 66);
            // 
            // tabListado
            // 
            this.tabListado.Size = new System.Drawing.Size(887, 93);
            // 
            // txtCodigoContacto
            // 
            this.txtCodigoContacto.Location = new System.Drawing.Point(76, 6);
            this.txtCodigoContacto.Name = "txtCodigoContacto";
            this.txtCodigoContacto.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoContacto.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "Código";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(102, 32);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(74, 20);
            this.txtCodigoCliente.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 22;
            this.label2.Text = "Cliente";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(204, 32);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(669, 20);
            this.txtNombreCliente.TabIndex = 24;
            // 
            // btnCliente
            // 
            this.btnCliente.Image = global::ControlPagos.Properties.Resources.buscar_16;
            this.btnCliente.Location = new System.Drawing.Point(179, 31);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(22, 23);
            this.btnCliente.TabIndex = 25;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // txtTipoCliente
            // 
            this.txtTipoCliente.Location = new System.Drawing.Point(76, 32);
            this.txtTipoCliente.Name = "txtTipoCliente";
            this.txtTipoCliente.Size = new System.Drawing.Size(27, 20);
            this.txtTipoCliente.TabIndex = 26;
            // 
            // txtCodigoClienteContacto
            // 
            this.txtCodigoClienteContacto.Location = new System.Drawing.Point(179, 5);
            this.txtCodigoClienteContacto.Name = "txtCodigoClienteContacto";
            this.txtCodigoClienteContacto.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoClienteContacto.TabIndex = 27;
            this.txtCodigoClienteContacto.Visible = false;
            // 
            // frmContactoAsociacionInformacion
            // 
            this.ClientSize = new System.Drawing.Size(896, 167);
            this.Name = "frmContactoAsociacionInformacion";
            this.Load += new System.EventHandler(this.frmContactoAsociacionInformacion_Load);
            this.grpMenu.ResumeLayout(false);
            this.tpInformacion.ResumeLayout(false);
            this.tpInformacion.PerformLayout();
            this.tabListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.TextBox txtCodigoCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoContacto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTipoCliente;
        private System.Windows.Forms.TextBox txtCodigoClienteContacto;
    }
}
