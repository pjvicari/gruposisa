<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlantillaSelectorDeAño
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlantillaSelectorDeAño))
        Me.lblSelectorDeAnios = New System.Windows.Forms.Label()
        Me.ptbSitio = New System.Windows.Forms.PictureBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnSeleccionar = New System.Windows.Forms.Button()
        Me.cmbAños = New System.Windows.Forms.ComboBox()
        Me.grpMenu = New System.Windows.Forms.GroupBox()
        CType(Me.ptbSitio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSelectorDeAnios
        '
        Me.lblSelectorDeAnios.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectorDeAnios.ForeColor = System.Drawing.Color.Black
        Me.lblSelectorDeAnios.Location = New System.Drawing.Point(4, 40)
        Me.lblSelectorDeAnios.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSelectorDeAnios.Name = "lblSelectorDeAnios"
        Me.lblSelectorDeAnios.Size = New System.Drawing.Size(260, 24)
        Me.lblSelectorDeAnios.TabIndex = 7
        Me.lblSelectorDeAnios.Text = "Seleccione el año en que va a trabajar"
        Me.lblSelectorDeAnios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ptbSitio
        '
        Me.ptbSitio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ptbSitio.Image = CType(resources.GetObject("ptbSitio.Image"), System.Drawing.Image)
        Me.ptbSitio.Location = New System.Drawing.Point(1, 1)
        Me.ptbSitio.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ptbSitio.Name = "ptbSitio"
        Me.ptbSitio.Size = New System.Drawing.Size(532, 239)
        Me.ptbSitio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ptbSitio.TabIndex = 9
        Me.ptbSitio.TabStop = False
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(450, 10)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 56)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeleccionar.Image = CType(resources.GetObject("btnSeleccionar.Image"), System.Drawing.Image)
        Me.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSeleccionar.Location = New System.Drawing.Point(376, 10)
        Me.btnSeleccionar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(75, 56)
        Me.btnSeleccionar.TabIndex = 4
        Me.btnSeleccionar.Text = "&Seleccionar"
        Me.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'cmbAños
        '
        Me.cmbAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAños.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAños.FormattingEnabled = True
        Me.cmbAños.Location = New System.Drawing.Point(271, 40)
        Me.cmbAños.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbAños.Name = "cmbAños"
        Me.cmbAños.Size = New System.Drawing.Size(103, 24)
        Me.cmbAños.TabIndex = 6
        '
        'grpMenu
        '
        Me.grpMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMenu.BackColor = System.Drawing.Color.Transparent
        Me.grpMenu.Controls.Add(Me.lblSelectorDeAnios)
        Me.grpMenu.Controls.Add(Me.btnSalir)
        Me.grpMenu.Controls.Add(Me.btnSeleccionar)
        Me.grpMenu.Controls.Add(Me.cmbAños)
        Me.grpMenu.Location = New System.Drawing.Point(3, 238)
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Size = New System.Drawing.Size(528, 70)
        Me.grpMenu.TabIndex = 10
        Me.grpMenu.TabStop = False
        '
        'frmPlantillaSelectorDeAño
        '
        Me.AcceptButton = Me.btnSeleccionar
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(534, 311)
        Me.ControlBox = False
        Me.Controls.Add(Me.ptbSitio)
        Me.Controls.Add(Me.grpMenu)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "frmPlantillaSelectorDeAño"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selector del año de Operación"
        CType(Me.ptbSitio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSelectorDeAnios As System.Windows.Forms.Label
    Friend WithEvents ptbSitio As System.Windows.Forms.PictureBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
    Friend WithEvents cmbAños As System.Windows.Forms.ComboBox
    Friend WithEvents grpMenu As System.Windows.Forms.GroupBox
End Class
