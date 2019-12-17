namespace ControlPagos.Formularios.Catalogos.Lugares
{
    partial class frmMunicipioListado
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
            this.grpMenu.SuspendLayout();
            this.grpListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtListado)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMostrarRegistros
            // 
            this.cmbMostrarRegistros.Size = new System.Drawing.Size(683, 22);
            // 
            // cmbBusqueda_02
            // 
            this.cmbBusqueda_02.Size = new System.Drawing.Size(200, 22);
            // 
            // cmbBusqueda_01
            // 
            this.cmbBusqueda_01.Size = new System.Drawing.Size(200, 22);
            // 
            // frmMunicipioListado
            // 
            this.ClientSize = new System.Drawing.Size(896, 645);
            this.Name = "frmMunicipioListado";
            this.Load += new System.EventHandler(this.frmMunicipioListado_Load);
            this.grpMenu.ResumeLayout(false);
            this.grpListado.ResumeLayout(false);
            this.grpListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
