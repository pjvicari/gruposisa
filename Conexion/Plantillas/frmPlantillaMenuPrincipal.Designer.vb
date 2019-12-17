<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlantillaMenuPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlantillaMenuPrincipal))
        Me.mnuPrincipal = New System.Windows.Forms.MenuStrip()
        Me.mnuArchivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCambioDeAño = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCambioDeUnidadOperativa = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProcesos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCatalogos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInformes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAyudaEInformacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCentroDeAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSeparador_1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAperturaDeTickets = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSeparador_2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPaginaWeb = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssPie = New System.Windows.Forms.StatusStrip()
        Me.tsAperturaDeIncidente = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsUnidadesOperativas = New System.Windows.Forms.ToolStripStatusLabel()
        Me.mnuPrincipal.SuspendLayout()
        Me.ssPie.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuPrincipal
        '
        Me.mnuPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.mnuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivo, Me.mnuProcesos, Me.mnuCatalogos, Me.mnuInformes, Me.mnuAyudaEInformacion})
        Me.mnuPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.mnuPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.mnuPrincipal.Name = "mnuPrincipal"
        Me.mnuPrincipal.Size = New System.Drawing.Size(1020, 40)
        Me.mnuPrincipal.TabIndex = 1
        '
        'mnuArchivo
        '
        Me.mnuArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.mnuCambioDeAño, Me.mnuCambioDeUnidadOperativa, Me.ToolStripSeparator2, Me.mnuSalir})
        Me.mnuArchivo.Image = CType(resources.GetObject("mnuArchivo.Image"), System.Drawing.Image)
        Me.mnuArchivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuArchivo.Name = "mnuArchivo"
        Me.mnuArchivo.Size = New System.Drawing.Size(92, 36)
        Me.mnuArchivo.Tag = ""
        Me.mnuArchivo.Text = "Archivo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(221, 6)
        '
        'mnuCambioDeAño
        '
        Me.mnuCambioDeAño.Image = CType(resources.GetObject("mnuCambioDeAño.Image"), System.Drawing.Image)
        Me.mnuCambioDeAño.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuCambioDeAño.Name = "mnuCambioDeAño"
        Me.mnuCambioDeAño.Size = New System.Drawing.Size(224, 22)
        Me.mnuCambioDeAño.Text = "Cambio de año"
        '
        'mnuCambioDeUnidadOperativa
        '
        Me.mnuCambioDeUnidadOperativa.Image = CType(resources.GetObject("mnuCambioDeUnidadOperativa.Image"), System.Drawing.Image)
        Me.mnuCambioDeUnidadOperativa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuCambioDeUnidadOperativa.Name = "mnuCambioDeUnidadOperativa"
        Me.mnuCambioDeUnidadOperativa.Size = New System.Drawing.Size(224, 22)
        Me.mnuCambioDeUnidadOperativa.Text = "Cambio de unidad operativa"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(221, 6)
        '
        'mnuSalir
        '
        Me.mnuSalir.Image = CType(resources.GetObject("mnuSalir.Image"), System.Drawing.Image)
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.Size = New System.Drawing.Size(224, 22)
        Me.mnuSalir.Text = "Salir"
        '
        'mnuProcesos
        '
        Me.mnuProcesos.Image = CType(resources.GetObject("mnuProcesos.Image"), System.Drawing.Image)
        Me.mnuProcesos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuProcesos.Name = "mnuProcesos"
        Me.mnuProcesos.Size = New System.Drawing.Size(98, 36)
        Me.mnuProcesos.Tag = ""
        Me.mnuProcesos.Text = "Procesos"
        '
        'mnuCatalogos
        '
        Me.mnuCatalogos.Image = CType(resources.GetObject("mnuCatalogos.Image"), System.Drawing.Image)
        Me.mnuCatalogos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuCatalogos.Name = "mnuCatalogos"
        Me.mnuCatalogos.Size = New System.Drawing.Size(104, 36)
        Me.mnuCatalogos.Tag = ""
        Me.mnuCatalogos.Text = "Catálogos"
        '
        'mnuInformes
        '
        Me.mnuInformes.Image = CType(resources.GetObject("mnuInformes.Image"), System.Drawing.Image)
        Me.mnuInformes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuInformes.Name = "mnuInformes"
        Me.mnuInformes.Size = New System.Drawing.Size(98, 36)
        Me.mnuInformes.Tag = ""
        Me.mnuInformes.Text = "Informes"
        '
        'mnuAyudaEInformacion
        '
        Me.mnuAyudaEInformacion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAyuda, Me.mnuCentroDeAyuda, Me.mnuSeparador_1, Me.mnuAperturaDeTickets, Me.mnuSeparador_2, Me.mnuPaginaWeb})
        Me.mnuAyudaEInformacion.Image = CType(resources.GetObject("mnuAyudaEInformacion.Image"), System.Drawing.Image)
        Me.mnuAyudaEInformacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuAyudaEInformacion.Name = "mnuAyudaEInformacion"
        Me.mnuAyudaEInformacion.Size = New System.Drawing.Size(162, 36)
        Me.mnuAyudaEInformacion.Text = "Ayuda e Información"
        '
        'mnuAyuda
        '
        Me.mnuAyuda.Image = CType(resources.GetObject("mnuAyuda.Image"), System.Drawing.Image)
        Me.mnuAyuda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuAyuda.Name = "mnuAyuda"
        Me.mnuAyuda.Size = New System.Drawing.Size(248, 22)
        Me.mnuAyuda.Text = "Ayuda"
        '
        'mnuCentroDeAyuda
        '
        Me.mnuCentroDeAyuda.Image = CType(resources.GetObject("mnuCentroDeAyuda.Image"), System.Drawing.Image)
        Me.mnuCentroDeAyuda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuCentroDeAyuda.Name = "mnuCentroDeAyuda"
        Me.mnuCentroDeAyuda.Size = New System.Drawing.Size(248, 22)
        Me.mnuCentroDeAyuda.Text = "Centro de Ayuda y Recursos"
        '
        'mnuSeparador_1
        '
        Me.mnuSeparador_1.Name = "mnuSeparador_1"
        Me.mnuSeparador_1.Size = New System.Drawing.Size(245, 6)
        '
        'mnuAperturaDeTickets
        '
        Me.mnuAperturaDeTickets.Image = CType(resources.GetObject("mnuAperturaDeTickets.Image"), System.Drawing.Image)
        Me.mnuAperturaDeTickets.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuAperturaDeTickets.Name = "mnuAperturaDeTickets"
        Me.mnuAperturaDeTickets.Size = New System.Drawing.Size(248, 22)
        Me.mnuAperturaDeTickets.Text = "Apertura de Tickets de Asistencia"
        '
        'mnuSeparador_2
        '
        Me.mnuSeparador_2.Name = "mnuSeparador_2"
        Me.mnuSeparador_2.Size = New System.Drawing.Size(245, 6)
        '
        'mnuPaginaWeb
        '
        Me.mnuPaginaWeb.Image = CType(resources.GetObject("mnuPaginaWeb.Image"), System.Drawing.Image)
        Me.mnuPaginaWeb.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuPaginaWeb.Name = "mnuPaginaWeb"
        Me.mnuPaginaWeb.Size = New System.Drawing.Size(248, 22)
        Me.mnuPaginaWeb.Text = "Página Web Intecap"
        '
        'ssPie
        '
        Me.ssPie.AutoSize = False
        Me.ssPie.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAperturaDeIncidente, Me.tsUsuario, Me.tsVersion, Me.tsUnidadesOperativas})
        Me.ssPie.Location = New System.Drawing.Point(0, 581)
        Me.ssPie.Name = "ssPie"
        Me.ssPie.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.ssPie.ShowItemToolTips = True
        Me.ssPie.Size = New System.Drawing.Size(1020, 24)
        Me.ssPie.TabIndex = 48
        '
        'tsAperturaDeIncidente
        '
        Me.tsAperturaDeIncidente.AutoSize = False
        Me.tsAperturaDeIncidente.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tsAperturaDeIncidente.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsAperturaDeIncidente.Image = CType(resources.GetObject("tsAperturaDeIncidente.Image"), System.Drawing.Image)
        Me.tsAperturaDeIncidente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsAperturaDeIncidente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsAperturaDeIncidente.IsLink = True
        Me.tsAperturaDeIncidente.LinkColor = System.Drawing.Color.SteelBlue
        Me.tsAperturaDeIncidente.Name = "tsAperturaDeIncidente"
        Me.tsAperturaDeIncidente.Size = New System.Drawing.Size(175, 19)
        Me.tsAperturaDeIncidente.Text = "Apertura de incidentes"
        Me.tsAperturaDeIncidente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsUsuario
        '
        Me.tsUsuario.AutoSize = False
        Me.tsUsuario.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tsUsuario.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsUsuario.Image = CType(resources.GetObject("tsUsuario.Image"), System.Drawing.Image)
        Me.tsUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsUsuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsUsuario.Name = "tsUsuario"
        Me.tsUsuario.Size = New System.Drawing.Size(180, 19)
        Me.tsUsuario.Text = "Usuario: -Sin Usuario-"
        Me.tsUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsUsuario.ToolTipText = "Usuario"
        '
        'tsVersion
        '
        Me.tsVersion.AutoSize = False
        Me.tsVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tsVersion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsVersion.Image = CType(resources.GetObject("tsVersion.Image"), System.Drawing.Image)
        Me.tsVersion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsVersion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsVersion.Name = "tsVersion"
        Me.tsVersion.Size = New System.Drawing.Size(90, 19)
        Me.tsVersion.Text = "Ver. 1.0.0.0"
        Me.tsVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsVersion.ToolTipText = "Versión"
        '
        'tsUnidadesOperativas
        '
        Me.tsUnidadesOperativas.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsUnidadesOperativas.Image = CType(resources.GetObject("tsUnidadesOperativas.Image"), System.Drawing.Image)
        Me.tsUnidadesOperativas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tsUnidadesOperativas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsUnidadesOperativas.IsLink = True
        Me.tsUnidadesOperativas.LinkColor = System.Drawing.Color.SteelBlue
        Me.tsUnidadesOperativas.Name = "tsUnidadesOperativas"
        Me.tsUnidadesOperativas.Size = New System.Drawing.Size(529, 19)
        Me.tsUnidadesOperativas.Spring = True
        Me.tsUnidadesOperativas.Text = "Unidades de Operación"
        Me.tsUnidadesOperativas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmPlantillaMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1020, 605)
        Me.Controls.Add(Me.ssPie)
        Me.Controls.Add(Me.mnuPrincipal)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnuPrincipal
        Me.Name = "frmPlantillaMenuPrincipal"
        Me.Text = "..."
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnuPrincipal.ResumeLayout(False)
        Me.mnuPrincipal.PerformLayout()
        Me.ssPie.ResumeLayout(False)
        Me.ssPie.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsAperturaDeIncidente As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsUnidadesOperativas As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents ssPie As System.Windows.Forms.StatusStrip
    Public WithEvents mnuArchivo As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuAyuda As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuCentroDeAyuda As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSeparador_1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuAperturaDeTickets As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSeparador_2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuPaginaWeb As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuCambioDeUnidadOperativa As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuCambioDeAño As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSalir As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuCatalogos As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuInformes As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuAyudaEInformacion As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuProcesos As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents mnuPrincipal As System.Windows.Forms.MenuStrip

End Class
