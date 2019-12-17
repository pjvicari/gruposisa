<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlantillaSelectorDeUnidad
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlantillaSelectorDeUnidad))
        Me.imlUnidadesOperativas = New System.Windows.Forms.ImageList(Me.components)
        Me.grpMenu = New System.Windows.Forms.GroupBox()
        Me.btnSeleccionar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.trvUnidadesOperativas = New System.Windows.Forms.TreeView()
        Me.imlUnidadesOperativasNew = New System.Windows.Forms.ImageList(Me.components)
        Me.grpMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'imlUnidadesOperativas
        '
        Me.imlUnidadesOperativas.ImageStream = CType(resources.GetObject("imlUnidadesOperativas.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlUnidadesOperativas.TransparentColor = System.Drawing.Color.Transparent
        Me.imlUnidadesOperativas.Images.SetKeyName(0, "iIntecap.jpg")
        Me.imlUnidadesOperativas.Images.SetKeyName(1, "casita.jpg")
        Me.imlUnidadesOperativas.Images.SetKeyName(2, "delegacion2.jpg")
        Me.imlUnidadesOperativas.Images.SetKeyName(3, "rcentral.jpg")
        Me.imlUnidadesOperativas.Images.SetKeyName(4, "rnorte.jpg")
        Me.imlUnidadesOperativas.Images.SetKeyName(5, "roriente.jpg")
        Me.imlUnidadesOperativas.Images.SetKeyName(6, "rnorte2.jpg")
        Me.imlUnidadesOperativas.Images.SetKeyName(7, "roccidente.jpg")
        Me.imlUnidadesOperativas.Images.SetKeyName(8, "rsur.jpg")
        Me.imlUnidadesOperativas.Images.SetKeyName(9, "arr.ico")
        Me.imlUnidadesOperativas.Images.SetKeyName(10, "der.ico")
        Me.imlUnidadesOperativas.Images.SetKeyName(11, "proveedores.ico")
        '
        'grpMenu
        '
        Me.grpMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMenu.Controls.Add(Me.btnSeleccionar)
        Me.grpMenu.Controls.Add(Me.btnSalir)
        Me.grpMenu.Location = New System.Drawing.Point(2, 537)
        Me.grpMenu.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.grpMenu.Size = New System.Drawing.Size(779, 67)
        Me.grpMenu.TabIndex = 5
        Me.grpMenu.TabStop = False
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeleccionar.Image = CType(resources.GetObject("btnSeleccionar.Image"), System.Drawing.Image)
        Me.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSeleccionar.Location = New System.Drawing.Point(626, 9)
        Me.btnSeleccionar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(75, 56)
        Me.btnSeleccionar.TabIndex = 1
        Me.btnSeleccionar.Text = "&Seleccionar"
        Me.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(700, 9)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 56)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'trvUnidadesOperativas
        '
        Me.trvUnidadesOperativas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvUnidadesOperativas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trvUnidadesOperativas.ImageIndex = 0
        Me.trvUnidadesOperativas.ImageList = Me.imlUnidadesOperativasNew
        Me.trvUnidadesOperativas.Location = New System.Drawing.Point(2, 2)
        Me.trvUnidadesOperativas.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.trvUnidadesOperativas.Name = "trvUnidadesOperativas"
        Me.trvUnidadesOperativas.SelectedImageIndex = 0
        Me.trvUnidadesOperativas.Size = New System.Drawing.Size(779, 538)
        Me.trvUnidadesOperativas.TabIndex = 4
        '
        'imlUnidadesOperativasNew
        '
        Me.imlUnidadesOperativasNew.ImageStream = CType(resources.GetObject("imlUnidadesOperativasNew.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlUnidadesOperativasNew.TransparentColor = System.Drawing.Color.Transparent
        Me.imlUnidadesOperativasNew.Images.SetKeyName(0, "iIntecap.jpg")
        Me.imlUnidadesOperativasNew.Images.SetKeyName(1, "uo_division_regional.ico")
        Me.imlUnidadesOperativasNew.Images.SetKeyName(2, "uo_administracion.ico")
        Me.imlUnidadesOperativasNew.Images.SetKeyName(3, "uo_centros.ico")
        Me.imlUnidadesOperativasNew.Images.SetKeyName(4, "uo_servicios_empresariales.ico")
        Me.imlUnidadesOperativasNew.Images.SetKeyName(5, "uo_delegaciones.ico")
        Me.imlUnidadesOperativasNew.Images.SetKeyName(6, "uo_otras.ico")
        Me.imlUnidadesOperativasNew.Images.SetKeyName(7, "uo_seleccion.ico")
        '
        'frmPlantillaSelectorDeUnidad
        '
        Me.AcceptButton = Me.btnSeleccionar
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(784, 606)
        Me.ControlBox = False
        Me.Controls.Add(Me.trvUnidadesOperativas)
        Me.Controls.Add(Me.grpMenu)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 645)
        Me.MinimizeBox = False
        Me.Name = "frmPlantillaSelectorDeUnidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "..."
        Me.grpMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents imlUnidadesOperativas As System.Windows.Forms.ImageList
    Friend WithEvents grpMenu As System.Windows.Forms.GroupBox
    Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents trvUnidadesOperativas As System.Windows.Forms.TreeView
    Friend WithEvents imlUnidadesOperativasNew As System.Windows.Forms.ImageList
End Class
