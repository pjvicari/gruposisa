Public Class frmPlantillaMenuPrincipal
    'Private ParMensaje As String = "", _Seguridad As New clsSeguridad(0, _Ambiente)
    'Private _Tickets As New clsTicketsAsistencia(Now.Year, _Ambiente)
    Private _UnidadOperativa As New UnidadOperativa()   

#Region "Propiedades"
    Private _NombreDelSistema As String
    Public Property NombreDelSistema() As String
        Get
            Return _NombreDelSistema
        End Get
        Set(ByVal value As String)
            _NombreDelSistema = value
        End Set
    End Property

    Private _SiglasDelSistema As String
    Public Property SiglasDelSistema() As String
        Get
            Return _SiglasDelSistema
        End Get
        Set(ByVal value As String)
            _SiglasDelSistema = value
        End Set
    End Property

    Private _NumeroDeFormulario As Integer
    Public Property NumeroDeFormulario() As Integer
        Get
            Return _NumeroDeFormulario
        End Get
        Set(ByVal value As Integer)
            _NumeroDeFormulario = value
        End Set
    End Property

    Private _AñoDeOperacion As Integer
    Public Property AñoDeOperacion() As Integer
        Get
            Return _AñoDeOperacion
        End Get
        Set(ByVal value As Integer)
            _AñoDeOperacion = value
        End Set
    End Property

    Private _IDUsuario As String
    Public Property IDUsuario() As String
        Get
            Return _IDUsuario
        End Get
        Set(ByVal value As String)
            _IDUsuario = value
        End Set
    End Property

    Private _Ambiente As AmbienteDeBaseDeDatos
    Public ReadOnly Property Ambiente() As AmbienteDeBaseDeDatos
        Get
            Return _Ambiente
        End Get       
    End Property

    Private _IDAplicacion As Integer
    Public Property IDAplicacion() As Integer
        Get
            Return _IDAplicacion
        End Get
        Set(ByVal value As Integer)
            _IDAplicacion = value
        End Set
    End Property

    Private _FormularioIncidentes As System.Windows.Forms.Form
    Public Property FormularioIncidentes() As Form
        Get
            Return _FormularioIncidentes
        End Get
        Set(ByVal value As Form)
            _FormularioIncidentes = value
        End Set
    End Property
#End Region


#Region "Metodos publicos"
    Public Sub InicializarFormulario()
        ' Nombre de la aplicacion
        If NombreDelSistema.ToString.Trim.Length <= 0 Then
            MsgBox("No se ha definido el nombre de la aplicación.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        ' Siglas de la aplicacion
        If _SiglasDelSistema.ToString.Trim.Length <= 0 Then
            MsgBox("No se han definido las siglas de la aplicación.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        ' Año de operacion
        If AñoDeOperacion <= 0 Then
            MsgBox("No se ha definido el año de operacion.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        ' Usuario
        If _IDUsuario.ToString.Trim.Length <= 0 Then
            MsgBox("No se ha definido el usuario.", MsgBoxStyle.Critical)
            Exit Sub
        Else
            tsUsuario.Text = "Usuario: " & _IDUsuario
        End If
        ' Version del sistema
        tsVersion.Text = "Ver. " & ProductVersion

        Me.BackgroundImage = System.Drawing.Image.FromFile("\\dinf-aiis-svr\upg$\Admón Operativa\Año " & _AñoDeOperacion & "\BitMaps\Logo SITIO " & _AñoDeOperacion & ".jpg")

        Select Case _IDUsuario
            Case "ADMINISTRADOR", "DANIEL", "PLINIOG_011", "SUPERVISOR2"
                If MsgBox("Desea usar la base de datos de [Desarrollo]", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    _Ambiente = AmbienteDeBaseDeDatos.Desarrollo
                Else
                    _Ambiente = AmbienteDeBaseDeDatos.Produccion
                End If
            Case Else
                _Ambiente = AmbienteDeBaseDeDatos.Produccion
        End Select

        Me.Text = NombreDelSistema & " [" & _SiglasDelSistema & "_FRM" & Format(_NumeroDeFormulario, "0000") & "] DB: " & _Ambiente.ToString

        'OperarBitacora(_IDAplicacion, ProductVersion.ToString, "", "", _AñoOperacion, _Ambiente)
    End Sub
#End Region

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Desea salir del " & _NombreDelSistema & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1) <> MsgBoxResult.Yes Then
            e.Cancel = True
        Else
            'Bitacora de salida -_IDAplicacion-S
            'Operar_Bitacora(_IDAplicacion & "-S", ProductVersion.ToString, "", "", _AñoOperacion, _Ambiente)            
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim dtUnidadesOperativas As New DataTable                  

        '    If Not _Seguridad.Get_IDUsuario(_Usuario) Then
        '        _Usuario.IDUsuario = ""
        '    Else
        '        _Usuario.AccesosPermitidos = _Seguridad.Get_Accesos_Permitidos(_Usuario.IDUsuario, _IDAplicacion)
        '        _Usuario.UnidadesAutorizadas = _Seguridad.Get_Unidades_Autorizadas(_Usuario.NumeroEmpleado, _IDAplicacion)
        '    End If

        '    If _Usuario.IDUsuario = "" Then
        '        ParMensaje = "Debe registrar el usuario en el nuevo sistema Ingresos Institucionales." & vbCrLf & vbCrLf
        '        ParMensaje &= "Consulte con su Soporte Regional acerca de cómo registrarse"
        '        MsgBox(ParMensaje, vbCritical)
        '        End
        '    End If

        '    'Aplicar_Permisos()
        '    dtUnidadesOperativas = _Usuario.UnidadesAutorizadas

        '    If dtUnidadesOperativas.Rows.Count = 0 Then
        '        MsgBox("No tiene Unidades Operativas Asignadas a su Usuario, consulte al Administrador del Sistema")
        '        Me.Close()
        '        Me.Dispose()
        '    ElseIf dtUnidadesOperativas.Rows.Count > 0 Then
        '        If dtUnidadesOperativas.Rows.Count > 1 Then
        '            frmSelectorDeUnidadesOperativas.MdiParent = Me
        '            frmSelectorDeUnidadesOperativas.Show()
        '        Else
        '            _UnidadOperativa = New clsUnidadOperativa(dtUnidadesOperativas.Rows(0)("ID_UNIDAD_OPERATIVA"), dtUnidadesOperativas.Rows(0)("SIGLAS"), dtUnidadesOperativas.Rows(0)("NOMBRE_UNIDAD_OPERATIVA"))
        '            Actualizar_Unidad_Operativa()
        '        End If
        '    End If       
    End Sub

    'Public Sub ActualizarUnidadOperativa()
    '    If _UnidadOperativa Is Nothing Then Exit Sub
    '    If _UnidadOperativa.IDUnidadOperativa.ToString <> "" Then
    '        tsUnidadesOperativas.Text = "Unidad de Operación: "
    '        tsUnidadesOperativas.Text &= _UnidadOperativa.SiglasUnidadOperativa
    '        tsUnidadesOperativas.Text &= " - "
    '        tsUnidadesOperativas.Text &= _UnidadOperativa.NombreUnidadOperativa
    '    Else
    '        tsUnidadesOperativas.Text = "Unidad de Operación: Ninguna"
    '    End If
    'End Sub

    'Private Sub Aplicar_Permisos()
    '    Dim _Item_Interno_02 As New ToolStripMenuItem, _Item_Interno_03 As New ToolStripMenuItem, _Item_Interno_04 As New ToolStripMenuItem
    '    Dim _Item_Interno_05 As New ToolStripMenuItem, _Item_Interno_06 As New ToolStripMenuItem

    '    For Each _Menu_01 As ToolStripMenuItem In mnuPrincipal.Items
    '        If _Menu_01.Tag Is Nothing Then Continue For
    '        If _Menu_01.Tag.ToString = "" Then Continue For
    '        _Menu_01.Enabled = IIf(InStr(_Usuario.AccesosPermitidosStr, _Menu_01.Tag) <> 0, True, False)

    '        For Each _Menu_02 As ToolStripItem In _Menu_01.DropDownItems
    '            If _Menu_02.Tag Is Nothing Then Continue For
    '            If _Menu_02.Tag.ToString = "" Then Continue For
    '            _Menu_02.Enabled = IIf(InStr(_Usuario.AccesosPermitidosStr, _Menu_02.Tag) <> 0, True, False)
    '            If _Menu_02.IsOnDropDown Then _Item_Interno_02 = _Menu_02

    '            For Each _Menu_03 As ToolStripItem In _Item_Interno_02.DropDownItems
    '                If _Menu_03.Tag Is Nothing Then Continue For
    '                If _Menu_03.Tag.ToString = "" Then Continue For
    '                _Menu_03.Enabled = IIf(InStr(_Usuario.AccesosPermitidosStr, _Menu_03.Tag) <> 0, True, False)
    '                If _Menu_03.IsOnDropDown Then _Item_Interno_03 = _Menu_03

    '                For Each _Menu_04 As ToolStripItem In _Item_Interno_03.DropDownItems
    '                    If _Menu_04.Tag Is Nothing Then Continue For
    '                    If _Menu_04.Tag.ToString = "" Then Continue For
    '                    _Menu_04.Enabled = IIf(InStr(_Usuario.AccesosPermitidosStr, _Menu_04.Tag) <> 0, True, False)
    '                Next
    '            Next
    '        Next
    '    Next
    'End Sub

    'Private Sub Salir_Click(sender As Object, e As EventArgs)        
    '    Me.Close()
    'End Sub

    Private Sub tsEnviarMensaje_Click(sender As Object, e As EventArgs) Handles tsAperturaDeIncidente.Click
        If MsgBox("¿Desea revisar si su problema ya está resuelto?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Ayuda(sender, e)
        Else            
            _FormularioIncidentes.ShowDialog(Me)
        End If
    End Sub

    Private Sub Ayuda(sender As Object, e As EventArgs)
        Dim _Proceso As New System.Diagnostics.Process
        With _Proceso
            .StartInfo.FileName = "http://dinf-awis-svr:8082/wfmConocimiento.aspx"
            .Start()
        End With
    End Sub

    'Private Sub tsMensajes_Click(sender As Object, e As EventArgs) Handles tsUnidadesOperativas.Click
    '    frmSelectorDeUnidadesOperativas.MdiParent = Me
    '    frmSelectorDeUnidadesOperativas.Show()
    'End Sub

    'Private Sub mnuInformeMensualDeIngresos_Click(sender As Object, e As EventArgs) Handles mnuInformeMensualDeIngresos.Click
    '    frmSelectorDeReportesAnioMes.PorTipoDeReportes = frmSelectorDeReportesAnioMes.PorTipoReportes.ReporteDeIngresos
    '    frmSelectorDeReportesAnioMes.MdiParent = Me
    '    frmSelectorDeReportesAnioMes.Show()
    'End Sub

    'Private Sub mnuReporteDeValidaciónDeFacturasYF63A_Click(sender As Object, e As EventArgs) Handles mnuReporteDeValidaciónDeFacturasYF63A.Click
    '    frmSelectorDeReportesAnioMes.PorTipoDeReportes = frmSelectorDeReportesAnioMes.PorTipoReportes.ReporteDeBitacoras
    '    frmSelectorDeReportesAnioMes.MdiParent = Me
    '    frmSelectorDeReportesAnioMes.Show()
    'End Sub
    'Private Sub ControlDeBitácorasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlDeBitácorasToolStripMenuItem.Click
    '    frmControlDeBitacoras.MdiParent = Me
    '    frmControlDeBitacoras.Show()
    'End Sub


    'Private Sub mnuPaginaWeb_Click(sender As Object, e As EventArgs) Handles mnuPaginaWeb.Click
    '    Dim _Proceso As New System.Diagnostics.Process
    '    With _Proceso
    '        .StartInfo.FileName = "http://www.intecap.edu.gt"
    '        .Start()
    '    End With
    'End Sub

    'Private Sub CierresInstitucionalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CierresInstitucionalesToolStripMenuItem.Click
    '    frmAdministracionDeCierres.MdiParent = Me
    '    frmAdministracionDeCierres.Show()
    '    'frmAdministracionOperacionalCierres.MdiParent = Me
    '    'frmAdministracionOperacionalCierres.Show()
    'End Sub

    'Private Sub CambioDeAñoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuCambioDeAño.Click
    '    frmSelectorDeAño.Show()
    'End Sub

    'Private Sub mnuCambioDeUnidadOperativa_Click(sender As Object, e As EventArgs) Handles mnuCambioDeUnidadOperativa.Click
    '    frmSelectorDeUnidadesOperativas.MdiParent = Me
    '    frmSelectorDeUnidadesOperativas.Show()
    'End Sub

    'Private Sub mnuPaises_Click(sender As Object, e As EventArgs) Handles mnuPaises.Click
    '    ABCListado.MdiParent = Me
    '    ABCListado.Show()
    'End Sub

    'Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
    '    End
    'End Sub    
End Class
