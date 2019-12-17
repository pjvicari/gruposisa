<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlantillaListadoVacio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlantillaListadoVacio))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpMenu = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.tabListado = New System.Windows.Forms.TabControl()
        Me.tpListado = New System.Windows.Forms.TabPage()
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
        Me.grpMenu.Controls.Add(Me.btnSalir)
        Me.grpMenu.Location = New System.Drawing.Point(3, 572)
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Size = New System.Drawing.Size(890, 70)
        Me.grpMenu.TabIndex = 3
        Me.grpMenu.TabStop = False
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(825, 10)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(61, 56)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'tabListado
        '
        Me.tabListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabListado.Controls.Add(Me.tpListado)
        Me.tabListado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabListado.Location = New System.Drawing.Point(3, 3)
        Me.tabListado.Multiline = True
        Me.tabListado.Name = "tabListado"
        Me.tabListado.SelectedIndex = 0
        Me.tabListado.Size = New System.Drawing.Size(890, 571)
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
        Me.tpListado.Controls.Add(Me.btnFiltrar)
        Me.tpListado.Controls.Add(Me.txtBusqueda_01)
        Me.tpListado.Controls.Add(Me.cmbBusqueda_01)
        Me.tpListado.Controls.Add(Me.lblBusqueda_01)
        Me.tpListado.Controls.Add(Me.dgvListado)
        Me.tpListado.Location = New System.Drawing.Point(4, 23)
        Me.tpListado.Name = "tpListado"
        Me.tpListado.Padding = New System.Windows.Forms.Padding(3)
        Me.tpListado.Size = New System.Drawing.Size(882, 544)
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
        Me.cmbMostrarRegistros.Location = New System.Drawing.Point(117, 52)
        Me.cmbMostrarRegistros.Name = "cmbMostrarRegistros"
        Me.cmbMostrarRegistros.Size = New System.Drawing.Size(679, 22)
        Me.cmbMostrarRegistros.TabIndex = 15
        '
        'lblMostrarRegistros
        '
        Me.lblMostrarRegistros.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMostrarRegistros.Location = New System.Drawing.Point(3, 55)
        Me.lblMostrarRegistros.Name = "lblMostrarRegistros"
        Me.lblMostrarRegistros.Size = New System.Drawing.Size(110, 15)
        Me.lblMostrarRegistros.TabIndex = 14
        Me.lblMostrarRegistros.Text = "Mostrar registros"
        '
        'txtBusqueda_02
        '
        Me.txtBusqueda_02.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda_02.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBusqueda_02.Location = New System.Drawing.Point(320, 29)
        Me.txtBusqueda_02.Name = "txtBusqueda_02"
        Me.txtBusqueda_02.Size = New System.Drawing.Size(476, 20)
        Me.txtBusqueda_02.TabIndex = 12
        '
        'cmbBusqueda_02
        '
        Me.cmbBusqueda_02.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbBusqueda_02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBusqueda_02.FormattingEnabled = True
        Me.cmbBusqueda_02.Location = New System.Drawing.Point(117, 29)
        Me.cmbBusqueda_02.Name = "cmbBusqueda_02"
        Me.cmbBusqueda_02.Size = New System.Drawing.Size(200, 22)
        Me.cmbBusqueda_02.TabIndex = 11
        '
        'lblBusqueda_02
        '
        Me.lblBusqueda_02.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusqueda_02.Location = New System.Drawing.Point(3, 32)
        Me.lblBusqueda_02.Name = "lblBusqueda_02"
        Me.lblBusqueda_02.Size = New System.Drawing.Size(110, 15)
        Me.lblBusqueda_02.TabIndex = 12
        Me.lblBusqueda_02.Text = "Selección 2"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltrar.Image = CType(resources.GetObject("btnFiltrar.Image"), System.Drawing.Image)
        Me.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFiltrar.Location = New System.Drawing.Point(799, 4)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(79, 70)
        Me.btnFiltrar.TabIndex = 13
        Me.btnFiltrar.Text = "&Filtrar"
        Me.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'txtBusqueda_01
        '
        Me.txtBusqueda_01.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBusqueda_01.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBusqueda_01.Location = New System.Drawing.Point(320, 5)
        Me.txtBusqueda_01.Name = "txtBusqueda_01"
        Me.txtBusqueda_01.Size = New System.Drawing.Size(476, 20)
        Me.txtBusqueda_01.TabIndex = 10
        '
        'cmbBusqueda_01
        '
        Me.cmbBusqueda_01.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbBusqueda_01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBusqueda_01.FormattingEnabled = True
        Me.cmbBusqueda_01.Location = New System.Drawing.Point(117, 5)
        Me.cmbBusqueda_01.Name = "cmbBusqueda_01"
        Me.cmbBusqueda_01.Size = New System.Drawing.Size(200, 22)
        Me.cmbBusqueda_01.TabIndex = 9
        '
        'lblBusqueda_01
        '
        Me.lblBusqueda_01.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusqueda_01.Location = New System.Drawing.Point(3, 7)
        Me.lblBusqueda_01.Name = "lblBusqueda_01"
        Me.lblBusqueda_01.Size = New System.Drawing.Size(110, 15)
        Me.lblBusqueda_01.TabIndex = 8
        Me.lblBusqueda_01.Text = "Selección 1"
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.AllowUserToOrderColumns = True
        Me.dgvListado.AllowUserToResizeRows = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvListado.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListado.Location = New System.Drawing.Point(4, 78)
        Me.dgvListado.MultiSelect = False
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.RowHeadersWidth = 26
        Me.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListado.Size = New System.Drawing.Size(873, 461)
        Me.dgvListado.TabIndex = 7
        '
        'frmPlantillaListadoVacio
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(896, 645)
        Me.Controls.Add(Me.tabListado)
        Me.Controls.Add(Me.grpMenu)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(912, 684)
        Me.Name = "frmPlantillaListadoVacio"
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
    Protected Friend WithEvents cmbBusqueda_02 As System.Windows.Forms.ComboBox
    Protected Friend WithEvents lblBusqueda_02 As System.Windows.Forms.Label
    Protected Friend WithEvents cmbBusqueda_01 As System.Windows.Forms.ComboBox
    Protected Friend WithEvents lblBusqueda_01 As System.Windows.Forms.Label
    Protected Friend WithEvents cmbMostrarRegistros As System.Windows.Forms.ComboBox
    Protected Friend WithEvents lblMostrarRegistros As System.Windows.Forms.Label
    Protected Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Protected Friend WithEvents txtBusqueda_02 As System.Windows.Forms.TextBox
    Protected Friend WithEvents txtBusqueda_01 As System.Windows.Forms.TextBox
    Public WithEvents tpListado As System.Windows.Forms.TabPage
    Public WithEvents tabListado As System.Windows.Forms.TabControl
    Public WithEvents dgvListado As System.Windows.Forms.DataGridView
End Class
