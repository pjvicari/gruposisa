<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlantillaListadoInformacion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlantillaListadoInformacion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpMenu = New System.Windows.Forms.GroupBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.tabListado = New System.Windows.Forms.TabControl()
        Me.tpListado = New System.Windows.Forms.TabPage()
        Me.cmbMostrarRegistros = New System.Windows.Forms.ComboBox()
        Me.lblMostrarRegistros = New System.Windows.Forms.Label()
        Me.txtBusqueda_02 = New System.Windows.Forms.TextBox()
        Me.cmbBusqueda_02 = New System.Windows.Forms.ComboBox()
        Me.lblBusqueda_02 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtBusqueda_01 = New System.Windows.Forms.TextBox()
        Me.cmbBusqueda_01 = New System.Windows.Forms.ComboBox()
        Me.lblBusqueda_01 = New System.Windows.Forms.Label()
        Me.dgvListado = New System.Windows.Forms.DataGridView()
        Me.tpInformacion = New System.Windows.Forms.TabPage()
        Me.lblNombreForma = New System.Windows.Forms.Label()
        Me.grpMenu.SuspendLayout()
        Me.tabListado.SuspendLayout()
        Me.tpListado.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpMenu
        '
        Me.grpMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMenu.Controls.Add(Me.btnImprimir)
        Me.grpMenu.Controls.Add(Me.btnSalir)
        Me.grpMenu.Controls.Add(Me.btnCancelar)
        Me.grpMenu.Controls.Add(Me.btnAceptar)
        Me.grpMenu.Controls.Add(Me.btnEliminar)
        Me.grpMenu.Controls.Add(Me.btnModificar)
        Me.grpMenu.Controls.Add(Me.btnAgregar)
        Me.grpMenu.Location = New System.Drawing.Point(5, -3)
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Size = New System.Drawing.Size(887, 71)
        Me.grpMenu.TabIndex = 3
        Me.grpMenu.TabStop = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(186, 10)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(61, 56)
        Me.btnImprimir.TabIndex = 6
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(821, 10)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(61, 56)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(761, 10)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(61, 56)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAceptar.Location = New System.Drawing.Point(701, 10)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(61, 56)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(126, 10)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(61, 56)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnModificar.Location = New System.Drawing.Point(66, 10)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(61, 56)
        Me.btnModificar.TabIndex = 1
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(6, 10)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(61, 56)
        Me.btnAgregar.TabIndex = 0
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'tabListado
        '
        Me.tabListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabListado.Controls.Add(Me.tpListado)
        Me.tabListado.Controls.Add(Me.tpInformacion)
        Me.tabListado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabListado.Location = New System.Drawing.Point(5, 72)
        Me.tabListado.Multiline = True
        Me.tabListado.Name = "tabListado"
        Me.tabListado.SelectedIndex = 0
        Me.tabListado.Size = New System.Drawing.Size(889, 571)
        Me.tabListado.TabIndex = 7
        Me.tabListado.Tag = ""
        '
        'tpListado
        '
        Me.tpListado.BackColor = System.Drawing.SystemColors.Control
        Me.tpListado.Controls.Add(Me.cmbMostrarRegistros)
        Me.tpListado.Controls.Add(Me.lblMostrarRegistros)
        Me.tpListado.Controls.Add(Me.txtBusqueda_02)
        Me.tpListado.Controls.Add(Me.cmbBusqueda_02)
        Me.tpListado.Controls.Add(Me.lblBusqueda_02)
        Me.tpListado.Controls.Add(Me.btnBuscar)
        Me.tpListado.Controls.Add(Me.txtBusqueda_01)
        Me.tpListado.Controls.Add(Me.cmbBusqueda_01)
        Me.tpListado.Controls.Add(Me.lblBusqueda_01)
        Me.tpListado.Controls.Add(Me.dgvListado)
        Me.tpListado.Location = New System.Drawing.Point(4, 23)
        Me.tpListado.Name = "tpListado"
        Me.tpListado.Padding = New System.Windows.Forms.Padding(3)
        Me.tpListado.Size = New System.Drawing.Size(881, 544)
        Me.tpListado.TabIndex = 0
        Me.tpListado.Tag = ""
        Me.tpListado.Text = "Listado"
        '
        'cmbMostrarRegistros
        '
        Me.cmbMostrarRegistros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMostrarRegistros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMostrarRegistros.FormattingEnabled = True
        Me.cmbMostrarRegistros.Location = New System.Drawing.Point(114, 53)
        Me.cmbMostrarRegistros.Name = "cmbMostrarRegistros"
        Me.cmbMostrarRegistros.Size = New System.Drawing.Size(682, 22)
        Me.cmbMostrarRegistros.TabIndex = 15
        '
        'lblMostrarRegistros
        '
        Me.lblMostrarRegistros.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMostrarRegistros.Location = New System.Drawing.Point(3, 55)
        Me.lblMostrarRegistros.Name = "lblMostrarRegistros"
        Me.lblMostrarRegistros.Size = New System.Drawing.Size(106, 15)
        Me.lblMostrarRegistros.TabIndex = 14
        Me.lblMostrarRegistros.Text = "Mostrar registros"
        '
        'txtBusqueda_02
        '
        Me.txtBusqueda_02.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda_02.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBusqueda_02.Location = New System.Drawing.Point(317, 29)
        Me.txtBusqueda_02.Name = "txtBusqueda_02"
        Me.txtBusqueda_02.Size = New System.Drawing.Size(479, 20)
        Me.txtBusqueda_02.TabIndex = 12
        '
        'cmbBusqueda_02
        '
        Me.cmbBusqueda_02.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbBusqueda_02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBusqueda_02.FormattingEnabled = True
        Me.cmbBusqueda_02.Location = New System.Drawing.Point(114, 29)
        Me.cmbBusqueda_02.Name = "cmbBusqueda_02"
        Me.cmbBusqueda_02.Size = New System.Drawing.Size(200, 22)
        Me.cmbBusqueda_02.TabIndex = 11
        '
        'lblBusqueda_02
        '
        Me.lblBusqueda_02.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusqueda_02.Location = New System.Drawing.Point(3, 32)
        Me.lblBusqueda_02.Name = "lblBusqueda_02"
        Me.lblBusqueda_02.Size = New System.Drawing.Size(106, 15)
        Me.lblBusqueda_02.TabIndex = 12
        Me.lblBusqueda_02.Text = "Selección 2"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(798, 2)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(79, 74)
        Me.btnBuscar.TabIndex = 13
        Me.btnBuscar.Text = "&Filtrar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtBusqueda_01
        '
        Me.txtBusqueda_01.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda_01.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBusqueda_01.Location = New System.Drawing.Point(317, 5)
        Me.txtBusqueda_01.Name = "txtBusqueda_01"
        Me.txtBusqueda_01.Size = New System.Drawing.Size(479, 20)
        Me.txtBusqueda_01.TabIndex = 10
        '
        'cmbBusqueda_01
        '
        Me.cmbBusqueda_01.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbBusqueda_01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBusqueda_01.FormattingEnabled = True
        Me.cmbBusqueda_01.Location = New System.Drawing.Point(114, 5)
        Me.cmbBusqueda_01.Name = "cmbBusqueda_01"
        Me.cmbBusqueda_01.Size = New System.Drawing.Size(200, 22)
        Me.cmbBusqueda_01.TabIndex = 9
        '
        'lblBusqueda_01
        '
        Me.lblBusqueda_01.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusqueda_01.Location = New System.Drawing.Point(3, 7)
        Me.lblBusqueda_01.Name = "lblBusqueda_01"
        Me.lblBusqueda_01.Size = New System.Drawing.Size(106, 15)
        Me.lblBusqueda_01.TabIndex = 8
        Me.lblBusqueda_01.Text = "Selección 1"
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.AllowUserToOrderColumns = True
        Me.dgvListado.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvListado.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListado.Location = New System.Drawing.Point(5, 79)
        Me.dgvListado.MultiSelect = False
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.ReadOnly = True
        Me.dgvListado.RowHeadersWidth = 26
        Me.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListado.Size = New System.Drawing.Size(871, 461)
        Me.dgvListado.TabIndex = 7
        '
        'tpInformacion
        '
        Me.tpInformacion.BackColor = System.Drawing.SystemColors.Control
        Me.tpInformacion.Location = New System.Drawing.Point(4, 23)
        Me.tpInformacion.Name = "tpInformacion"
        Me.tpInformacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInformacion.Size = New System.Drawing.Size(881, 544)
        Me.tpInformacion.TabIndex = 1
        Me.tpInformacion.Text = "Información"
        '
        'lblNombreForma
        '
        Me.lblNombreForma.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreForma.ForeColor = System.Drawing.Color.Green
        Me.lblNombreForma.Location = New System.Drawing.Point(616, 69)
        Me.lblNombreForma.Name = "lblNombreForma"
        Me.lblNombreForma.Size = New System.Drawing.Size(120, 16)
        Me.lblNombreForma.TabIndex = 8
        Me.lblNombreForma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmPlantillaListadoInformacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(896, 645)
        Me.Controls.Add(Me.lblNombreForma)
        Me.Controls.Add(Me.tabListado)
        Me.Controls.Add(Me.grpMenu)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(912, 684)
        Me.Name = "frmPlantillaListadoInformacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.grpMenu.ResumeLayout(False)
        Me.tabListado.ResumeLayout(False)
        Me.tpListado.ResumeLayout(False)
        Me.tpListado.PerformLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected Friend WithEvents grpMenu As System.Windows.Forms.GroupBox
    Protected Friend WithEvents btnSalir As System.Windows.Forms.Button
    Protected Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Protected Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Protected Friend WithEvents cmbBusqueda_02 As System.Windows.Forms.ComboBox
    Protected Friend WithEvents lblBusqueda_02 As System.Windows.Forms.Label
    Protected Friend WithEvents cmbBusqueda_01 As System.Windows.Forms.ComboBox
    Protected Friend WithEvents lblBusqueda_01 As System.Windows.Forms.Label
    Public WithEvents tpInformacion As System.Windows.Forms.TabPage
    Protected Friend WithEvents cmbMostrarRegistros As System.Windows.Forms.ComboBox
    Protected Friend WithEvents lblMostrarRegistros As System.Windows.Forms.Label
    Protected Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Protected Friend WithEvents txtBusqueda_02 As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtBusqueda_01 As System.Windows.Forms.TextBox
    Protected WithEvents btnImprimir As System.Windows.Forms.Button
    Protected WithEvents btnEliminar As System.Windows.Forms.Button
    Protected WithEvents btnModificar As System.Windows.Forms.Button
    Protected WithEvents btnAgregar As System.Windows.Forms.Button
    Public WithEvents tpListado As System.Windows.Forms.TabPage
    Public WithEvents tabListado As System.Windows.Forms.TabControl
    Friend WithEvents lblNombreForma As System.Windows.Forms.Label
    Protected Friend WithEvents dgvListado As System.Windows.Forms.DataGridView
End Class
