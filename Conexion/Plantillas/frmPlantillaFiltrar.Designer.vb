<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlantillaFiltrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlantillaFiltrar))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.cmbMostrarRegistros = New System.Windows.Forms.ComboBox()
        Me.lblMostrarRegistros = New System.Windows.Forms.Label()
        Me.txtBusqueda_02 = New System.Windows.Forms.TextBox()
        Me.cmbBusqueda_02 = New System.Windows.Forms.ComboBox()
        Me.lblBusqueda_02 = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.txtBusqueda_01 = New System.Windows.Forms.TextBox()
        Me.cmbBusqueda_01 = New System.Windows.Forms.ComboBox()
        Me.lblBusqueda_01 = New System.Windows.Forms.Label()
        Me.dgvListado = New System.Windows.Forms.DataGridView()
        Me.grpMenu = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnSeleccionar = New System.Windows.Forms.Button()
        Me.grpDatos.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDatos
        '
        Me.grpDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDatos.Controls.Add(Me.cmbMostrarRegistros)
        Me.grpDatos.Controls.Add(Me.lblMostrarRegistros)
        Me.grpDatos.Controls.Add(Me.txtBusqueda_02)
        Me.grpDatos.Controls.Add(Me.cmbBusqueda_02)
        Me.grpDatos.Controls.Add(Me.lblBusqueda_02)
        Me.grpDatos.Controls.Add(Me.btnFiltrar)
        Me.grpDatos.Controls.Add(Me.txtBusqueda_01)
        Me.grpDatos.Controls.Add(Me.cmbBusqueda_01)
        Me.grpDatos.Controls.Add(Me.lblBusqueda_01)
        Me.grpDatos.Controls.Add(Me.dgvListado)
        Me.grpDatos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDatos.Location = New System.Drawing.Point(2, -4)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(891, 539)
        Me.grpDatos.TabIndex = 6
        Me.grpDatos.TabStop = False
        '
        'cmbMostrarRegistros
        '
        Me.cmbMostrarRegistros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMostrarRegistros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMostrarRegistros.FormattingEnabled = True
        Me.cmbMostrarRegistros.Location = New System.Drawing.Point(121, 58)
        Me.cmbMostrarRegistros.Name = "cmbMostrarRegistros"
        Me.cmbMostrarRegistros.Size = New System.Drawing.Size(680, 22)
        Me.cmbMostrarRegistros.TabIndex = 25
        '
        'lblMostrarRegistros
        '
        Me.lblMostrarRegistros.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMostrarRegistros.Location = New System.Drawing.Point(6, 60)
        Me.lblMostrarRegistros.Name = "lblMostrarRegistros"
        Me.lblMostrarRegistros.Size = New System.Drawing.Size(110, 15)
        Me.lblMostrarRegistros.TabIndex = 24
        Me.lblMostrarRegistros.Text = "Mostrar registros"
        '
        'txtBusqueda_02
        '
        Me.txtBusqueda_02.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda_02.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBusqueda_02.Location = New System.Drawing.Point(324, 35)
        Me.txtBusqueda_02.Name = "txtBusqueda_02"
        Me.txtBusqueda_02.Size = New System.Drawing.Size(477, 20)
        Me.txtBusqueda_02.TabIndex = 22
        '
        'cmbBusqueda_02
        '
        Me.cmbBusqueda_02.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbBusqueda_02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBusqueda_02.FormattingEnabled = True
        Me.cmbBusqueda_02.Location = New System.Drawing.Point(121, 34)
        Me.cmbBusqueda_02.Name = "cmbBusqueda_02"
        Me.cmbBusqueda_02.Size = New System.Drawing.Size(200, 22)
        Me.cmbBusqueda_02.TabIndex = 20
        '
        'lblBusqueda_02
        '
        Me.lblBusqueda_02.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusqueda_02.Location = New System.Drawing.Point(6, 37)
        Me.lblBusqueda_02.Name = "lblBusqueda_02"
        Me.lblBusqueda_02.Size = New System.Drawing.Size(110, 15)
        Me.lblBusqueda_02.TabIndex = 21
        Me.lblBusqueda_02.Text = "Selección 2"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltrar.Image = CType(resources.GetObject("btnFiltrar.Image"), System.Drawing.Image)
        Me.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFiltrar.Location = New System.Drawing.Point(805, 10)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(80, 70)
        Me.btnFiltrar.TabIndex = 23
        Me.btnFiltrar.Text = "&Filtrar"
        Me.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'txtBusqueda_01
        '
        Me.txtBusqueda_01.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda_01.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBusqueda_01.Location = New System.Drawing.Point(324, 11)
        Me.txtBusqueda_01.Name = "txtBusqueda_01"
        Me.txtBusqueda_01.Size = New System.Drawing.Size(477, 20)
        Me.txtBusqueda_01.TabIndex = 19
        '
        'cmbBusqueda_01
        '
        Me.cmbBusqueda_01.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbBusqueda_01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBusqueda_01.FormattingEnabled = True
        Me.cmbBusqueda_01.Location = New System.Drawing.Point(121, 10)
        Me.cmbBusqueda_01.Name = "cmbBusqueda_01"
        Me.cmbBusqueda_01.Size = New System.Drawing.Size(200, 22)
        Me.cmbBusqueda_01.TabIndex = 18
        '
        'lblBusqueda_01
        '
        Me.lblBusqueda_01.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusqueda_01.Location = New System.Drawing.Point(6, 13)
        Me.lblBusqueda_01.Name = "lblBusqueda_01"
        Me.lblBusqueda_01.Size = New System.Drawing.Size(110, 15)
        Me.lblBusqueda_01.TabIndex = 17
        Me.lblBusqueda_01.Text = "Selección 1"
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.AllowUserToResizeRows = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvListado.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListado.Location = New System.Drawing.Point(6, 85)
        Me.dgvListado.MultiSelect = False
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.RowHeadersWidth = 26
        Me.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListado.Size = New System.Drawing.Size(879, 447)
        Me.dgvListado.TabIndex = 16
        '
        'grpMenu
        '
        Me.grpMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMenu.Controls.Add(Me.btnSalir)
        Me.grpMenu.Controls.Add(Me.btnSeleccionar)
        Me.grpMenu.Location = New System.Drawing.Point(2, 532)
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Size = New System.Drawing.Size(891, 71)
        Me.grpMenu.TabIndex = 5
        Me.grpMenu.TabStop = False
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(811, 11)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 56)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSeleccionar.BackColor = System.Drawing.SystemColors.Control
        Me.btnSeleccionar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeleccionar.Image = CType(resources.GetObject("btnSeleccionar.Image"), System.Drawing.Image)
        Me.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSeleccionar.Location = New System.Drawing.Point(737, 11)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(75, 56)
        Me.btnSeleccionar.TabIndex = 3
        Me.btnSeleccionar.Text = "&Seleccionar"
        Me.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSeleccionar.UseVisualStyleBackColor = False
        '
        'frmPlantillaFiltrar
        '
        Me.AcceptButton = Me.btnSeleccionar
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(896, 606)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.grpMenu)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(912, 645)
        Me.Name = "frmPlantillaFiltrar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Protected Friend WithEvents cmbMostrarRegistros As System.Windows.Forms.ComboBox
    Protected Friend WithEvents lblMostrarRegistros As System.Windows.Forms.Label
    Private WithEvents txtBusqueda_02 As System.Windows.Forms.TextBox
    Protected Friend WithEvents cmbBusqueda_02 As System.Windows.Forms.ComboBox
    Protected Friend WithEvents lblBusqueda_02 As System.Windows.Forms.Label
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Private WithEvents txtBusqueda_01 As System.Windows.Forms.TextBox
    Protected Friend WithEvents cmbBusqueda_01 As System.Windows.Forms.ComboBox
    Protected Friend WithEvents lblBusqueda_01 As System.Windows.Forms.Label
    Protected Friend WithEvents dgvListado As System.Windows.Forms.DataGridView
    Protected Friend WithEvents grpMenu As System.Windows.Forms.GroupBox
    Protected Friend WithEvents btnSalir As System.Windows.Forms.Button
    Protected Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
End Class
