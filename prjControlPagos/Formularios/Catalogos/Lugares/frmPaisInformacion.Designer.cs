namespace ControlPagos.Formularios.Catalogos.Lugares
{
    partial class frmPaisInformacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoPais = new System.Windows.Forms.TextBox();
            this.txtNombrePais = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcionPais = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpMenu.SuspendLayout();
            this.tpInformacion.SuspendLayout();
            this.tabListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtListado)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMenu
            // 
            this.grpMenu.Location = new System.Drawing.Point(4, 181);
            this.grpMenu.Size = new System.Drawing.Size(745, 71);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(680, 10);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(620, 10);
            // 
            // tpInformacion
            // 
            this.tpInformacion.Controls.Add(this.txtDescripcionPais);
            this.tpInformacion.Controls.Add(this.label3);
            this.tpInformacion.Controls.Add(this.txtNombrePais);
            this.tpInformacion.Controls.Add(this.label2);
            this.tpInformacion.Controls.Add(this.txtCodigoPais);
            this.tpInformacion.Controls.Add(this.label1);
            this.tpInformacion.Size = new System.Drawing.Size(737, 153);
            // 
            // tabListado
            // 
            this.tabListado.Size = new System.Drawing.Size(745, 180);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // txtCodigoPais
            // 
            this.txtCodigoPais.Location = new System.Drawing.Point(76, 9);
            this.txtCodigoPais.Name = "txtCodigoPais";
            this.txtCodigoPais.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoPais.TabIndex = 1;
            // 
            // txtNombrePais
            // 
            this.txtNombrePais.Location = new System.Drawing.Point(76, 35);
            this.txtNombrePais.Name = "txtNombrePais";
            this.txtNombrePais.Size = new System.Drawing.Size(655, 20);
            this.txtNombrePais.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pais";
            // 
            // txtDescripcionPais
            // 
            this.txtDescripcionPais.Location = new System.Drawing.Point(76, 61);
            this.txtDescripcionPais.Multiline = true;
            this.txtDescripcionPais.Name = "txtDescripcionPais";
            this.txtDescripcionPais.Size = new System.Drawing.Size(655, 86);
            this.txtDescripcionPais.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripción";
            // 
            // frmPaisInformacion
            // 
            this.ClientSize = new System.Drawing.Size(754, 254);
            this.Name = "frmPaisInformacion";
            this.Load += new System.EventHandler(this.frmPaisInformacion_Load);
            this.grpMenu.ResumeLayout(false);
            this.tpInformacion.ResumeLayout(false);
            this.tpInformacion.PerformLayout();
            this.tabListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcionPais;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombrePais;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoPais;
        private System.Windows.Forms.Label label1;
    }
}
