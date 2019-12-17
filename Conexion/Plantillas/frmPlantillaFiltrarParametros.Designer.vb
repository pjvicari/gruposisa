<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlantillaFiltrarParametros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlantillaFiltrarParametros))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpMenu = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.grpCriterios = New System.Windows.Forms.GroupBox()
        Me.txtAValor = New System.Windows.Forms.TextBox()
        Me.lblAvalor = New System.Windows.Forms.Label()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.cmbOperador = New System.Windows.Forms.ComboBox()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.cmbColumna = New System.Windows.Forms.ComboBox()
        Me.lblColumna = New System.Windows.Forms.Label()
        Me.grpListado = New System.Windows.Forms.GroupBox()
        Me.btnEliminarFiltro = New System.Windows.Forms.Button()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.btnAgregarFiltro = New System.Windows.Forms.Button()
        Me.dgvParametros = New System.Windows.Forms.DataGridView()
        Me.grpMenu.SuspendLayout()
        Me.grpCriterios.SuspendLayout()
        Me.grpListado.SuspendLayout()
        CType(Me.dgvParametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpMenu
        '
        Me.grpMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMenu.Controls.Add(Me.btnCancelar)
        Me.grpMenu.Controls.Add(Me.btnAceptar)
        Me.grpMenu.Location = New System.Drawing.Point(4, 237)
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Size = New System.Drawing.Size(887, 71)
        Me.grpMenu.TabIndex = 3
        Me.grpMenu.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(822, 10)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(61, 56)
        Me.btnCancelar.TabIndex = 5
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
        Me.btnAceptar.Location = New System.Drawing.Point(762, 10)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(61, 56)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'grpCriterios
        '
        Me.grpCriterios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCriterios.Controls.Add(Me.txtAValor)
        Me.grpCriterios.Controls.Add(Me.lblAvalor)
        Me.grpCriterios.Controls.Add(Me.txtValor)
        Me.grpCriterios.Controls.Add(Me.lblValor)
        Me.grpCriterios.Controls.Add(Me.cmbOperador)
        Me.grpCriterios.Controls.Add(Me.lblOperador)
        Me.grpCriterios.Controls.Add(Me.cmbColumna)
        Me.grpCriterios.Controls.Add(Me.lblColumna)
        Me.grpCriterios.Location = New System.Drawing.Point(4, -2)
        Me.grpCriterios.Name = "grpCriterios"
        Me.grpCriterios.Size = New System.Drawing.Size(887, 65)
        Me.grpCriterios.TabIndex = 0
        Me.grpCriterios.TabStop = False
        '
        'txtAValor
        '
        Me.txtAValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAValor.Location = New System.Drawing.Point(781, 36)
        Me.txtAValor.Name = "txtAValor"
        Me.txtAValor.Size = New System.Drawing.Size(100, 20)
        Me.txtAValor.TabIndex = 6
        '
        'lblAvalor
        '
        Me.lblAvalor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvalor.Location = New System.Drawing.Point(781, 12)
        Me.lblAvalor.Name = "lblAvalor"
        Me.lblAvalor.Size = New System.Drawing.Size(100, 20)
        Me.lblAvalor.TabIndex = 2
        Me.lblAvalor.Text = "A valor"
        Me.lblAvalor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtValor
        '
        Me.txtValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValor.Location = New System.Drawing.Point(334, 36)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(444, 20)
        Me.txtValor.TabIndex = 5
        '
        'lblValor
        '
        Me.lblValor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor.Location = New System.Drawing.Point(334, 12)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(444, 20)
        Me.lblValor.TabIndex = 1
        Me.lblValor.Text = "Valor"
        Me.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbOperador
        '
        Me.cmbOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperador.FormattingEnabled = True
        Me.cmbOperador.Location = New System.Drawing.Point(198, 36)
        Me.cmbOperador.Name = "cmbOperador"
        Me.cmbOperador.Size = New System.Drawing.Size(133, 22)
        Me.cmbOperador.TabIndex = 4
        '
        'lblOperador
        '
        Me.lblOperador.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperador.Location = New System.Drawing.Point(198, 12)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(133, 20)
        Me.lblOperador.TabIndex = 0
        Me.lblOperador.Text = "Operador"
        Me.lblOperador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbColumna
        '
        Me.cmbColumna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColumna.FormattingEnabled = True
        Me.cmbColumna.Location = New System.Drawing.Point(5, 36)
        Me.cmbColumna.Name = "cmbColumna"
        Me.cmbColumna.Size = New System.Drawing.Size(190, 22)
        Me.cmbColumna.TabIndex = 3
        '
        'lblColumna
        '
        Me.lblColumna.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColumna.Location = New System.Drawing.Point(5, 12)
        Me.lblColumna.Name = "lblColumna"
        Me.lblColumna.Size = New System.Drawing.Size(190, 20)
        Me.lblColumna.TabIndex = 0
        Me.lblColumna.Text = "Columna"
        Me.lblColumna.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpListado
        '
        Me.grpListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpListado.Controls.Add(Me.btnEliminarFiltro)
        Me.grpListado.Controls.Add(Me.btnLimpiarFiltros)
        Me.grpListado.Controls.Add(Me.btnAgregarFiltro)
        Me.grpListado.Controls.Add(Me.dgvParametros)
        Me.grpListado.Location = New System.Drawing.Point(4, 64)
        Me.grpListado.Name = "grpListado"
        Me.grpListado.Size = New System.Drawing.Size(887, 176)
        Me.grpListado.TabIndex = 4
        Me.grpListado.TabStop = False
        Me.grpListado.Text = "Criterios de filtrado"
        '
        'btnEliminarFiltro
        '
        Me.btnEliminarFiltro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarFiltro.Image = CType(resources.GetObject("btnEliminarFiltro.Image"), System.Drawing.Image)
        Me.btnEliminarFiltro.Location = New System.Drawing.Point(843, 15)
        Me.btnEliminarFiltro.Name = "btnEliminarFiltro"
        Me.btnEliminarFiltro.Size = New System.Drawing.Size(42, 39)
        Me.btnEliminarFiltro.TabIndex = 32
        Me.btnEliminarFiltro.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiarFiltros.Image = CType(resources.GetObject("btnLimpiarFiltros.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(801, 53)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(84, 39)
        Me.btnLimpiarFiltros.TabIndex = 31
        Me.btnLimpiarFiltros.Text = "&Limpiar"
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        '
        'btnAgregarFiltro
        '
        Me.btnAgregarFiltro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregarFiltro.Image = CType(resources.GetObject("btnAgregarFiltro.Image"), System.Drawing.Image)
        Me.btnAgregarFiltro.Location = New System.Drawing.Point(801, 15)
        Me.btnAgregarFiltro.Name = "btnAgregarFiltro"
        Me.btnAgregarFiltro.Size = New System.Drawing.Size(42, 39)
        Me.btnAgregarFiltro.TabIndex = 30
        Me.btnAgregarFiltro.UseVisualStyleBackColor = True
        '
        'dgvParametros
        '
        Me.dgvParametros.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.dgvParametros.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvParametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParametros.Location = New System.Drawing.Point(6, 15)
        Me.dgvParametros.Name = "dgvParametros"
        Me.dgvParametros.RowHeadersWidth = 26
        Me.dgvParametros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvParametros.Size = New System.Drawing.Size(792, 155)
        Me.dgvParametros.TabIndex = 27
        '
        'frmPlantillaFiltrarParametros
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(896, 311)
        Me.Controls.Add(Me.grpListado)
        Me.Controls.Add(Me.grpCriterios)
        Me.Controls.Add(Me.grpMenu)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(912, 684)
        Me.Name = "frmPlantillaFiltrarParametros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.grpMenu.ResumeLayout(False)
        Me.grpCriterios.ResumeLayout(False)
        Me.grpCriterios.PerformLayout()
        Me.grpListado.ResumeLayout(False)
        CType(Me.dgvParametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected Friend WithEvents grpMenu As System.Windows.Forms.GroupBox
    Protected Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Protected Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Protected Friend WithEvents grpCriterios As System.Windows.Forms.GroupBox
    Friend WithEvents txtAValor As System.Windows.Forms.TextBox
    Friend WithEvents lblAvalor As System.Windows.Forms.Label
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents cmbOperador As System.Windows.Forms.ComboBox
    Friend WithEvents lblOperador As System.Windows.Forms.Label
    Friend WithEvents cmbColumna As System.Windows.Forms.ComboBox
    Friend WithEvents lblColumna As System.Windows.Forms.Label
    Friend WithEvents grpListado As System.Windows.Forms.GroupBox
    Protected Friend WithEvents btnEliminarFiltro As System.Windows.Forms.Button
    Protected Friend WithEvents btnLimpiarFiltros As System.Windows.Forms.Button
    Protected Friend WithEvents btnAgregarFiltro As System.Windows.Forms.Button
    Friend WithEvents dgvParametros As System.Windows.Forms.DataGridView
End Class
