namespace ControlPagos.Formularios.Catalogos.Clientes
{
    partial class frmTratamientoInformacion
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
            this.txtTratamiento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSiglasTratamiento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoTratamiento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpMenu.SuspendLayout();
            this.tpInformacion.SuspendLayout();
            this.tabListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtListado)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMenu
            // 
            this.grpMenu.Location = new System.Drawing.Point(4, 122);
            this.grpMenu.Size = new System.Drawing.Size(464, 71);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(399, 10);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(339, 10);
            // 
            // tpInformacion
            // 
            this.tpInformacion.Controls.Add(this.txtTratamiento);
            this.tpInformacion.Controls.Add(this.label1);
            this.tpInformacion.Controls.Add(this.label3);
            this.tpInformacion.Controls.Add(this.txtCodigoTratamiento);
            this.tpInformacion.Controls.Add(this.txtSiglasTratamiento);
            this.tpInformacion.Controls.Add(this.label2);
            this.tpInformacion.Size = new System.Drawing.Size(456, 94);
            // 
            // tabListado
            // 
            this.tabListado.Size = new System.Drawing.Size(464, 121);
            // 
            // txtTratamiento
            // 
            this.txtTratamiento.Location = new System.Drawing.Point(73, 61);
            this.txtTratamiento.Name = "txtTratamiento";
            this.txtTratamiento.Size = new System.Drawing.Size(366, 20);
            this.txtTratamiento.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tratamiento";
            // 
            // txtSiglasTratamiento
            // 
            this.txtSiglasTratamiento.Location = new System.Drawing.Point(73, 35);
            this.txtSiglasTratamiento.Name = "txtSiglasTratamiento";
            this.txtSiglasTratamiento.Size = new System.Drawing.Size(100, 20);
            this.txtSiglasTratamiento.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Siglas";
            // 
            // txtCodigoTratamiento
            // 
            this.txtCodigoTratamiento.Location = new System.Drawing.Point(73, 9);
            this.txtCodigoTratamiento.Name = "txtCodigoTratamiento";
            this.txtCodigoTratamiento.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoTratamiento.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Código";
            // 
            // frmTratamientoInformacion
            // 
            this.ClientSize = new System.Drawing.Size(473, 195);
            this.Name = "frmTratamientoInformacion";
            this.Load += new System.EventHandler(this.frmTratamientoInformacion_Load);
            this.grpMenu.ResumeLayout(false);
            this.tpInformacion.ResumeLayout(false);
            this.tpInformacion.PerformLayout();
            this.tabListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTratamiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigoTratamiento;
        private System.Windows.Forms.TextBox txtSiglasTratamiento;
        private System.Windows.Forms.Label label2;
    }
}
