namespace ControlPagos.Formularios.Catalogos.Productos
{
    partial class frmUnidadMedidaInformacion
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
            this.txtUnidadMedida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoUnidadMedida = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpMenu.SuspendLayout();
            this.tpInformacion.SuspendLayout();
            this.tabListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtListado)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMenu
            // 
            this.grpMenu.Location = new System.Drawing.Point(4, 99);
            this.grpMenu.Size = new System.Drawing.Size(786, 71);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(721, 10);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(661, 10);
            // 
            // tpInformacion
            // 
            this.tpInformacion.Controls.Add(this.txtUnidadMedida);
            this.tpInformacion.Controls.Add(this.label1);
            this.tpInformacion.Controls.Add(this.label2);
            this.tpInformacion.Controls.Add(this.txtCodigoUnidadMedida);
            this.tpInformacion.Size = new System.Drawing.Size(778, 71);
            // 
            // tabListado
            // 
            this.tabListado.Size = new System.Drawing.Size(786, 98);
            // 
            // txtUnidadMedida
            // 
            this.txtUnidadMedida.Location = new System.Drawing.Point(109, 36);
            this.txtUnidadMedida.Name = "txtUnidadMedida";
            this.txtUnidadMedida.Size = new System.Drawing.Size(655, 20);
            this.txtUnidadMedida.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Unidad de medida";
            // 
            // txtCodigoUnidadMedida
            // 
            this.txtCodigoUnidadMedida.Location = new System.Drawing.Point(109, 10);
            this.txtCodigoUnidadMedida.Name = "txtCodigoUnidadMedida";
            this.txtCodigoUnidadMedida.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoUnidadMedida.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Código";
            // 
            // frmUnidadMedidaInformacion
            // 
            this.ClientSize = new System.Drawing.Size(795, 172);
            this.Name = "frmUnidadMedidaInformacion";
            this.Load += new System.EventHandler(this.frmUnidadMedidaInformacion_Load);
            this.grpMenu.ResumeLayout(false);
            this.tpInformacion.ResumeLayout(false);
            this.tpInformacion.PerformLayout();
            this.tabListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUnidadMedida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoUnidadMedida;
    }
}
