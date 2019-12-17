Public Class frmPlantillaInforme
    Private _FuentesDatos As New List(Of ReporteFuente)
    'Para los parametros
    Private _Parametros As New CrystalDecisions.Shared.ParameterFields
    Private _DiscretValue As New CrystalDecisions.Shared.ParameterDiscreteValue
    Private _ParameterField As New CrystalDecisions.Shared.ParameterField
    'Para la clase de conexion
    Private _ClaseDeConexion As New ReporteConexion(GestorDeBaseDeDatos.Oracle, EsquemaDeBaseDeDatos.Administracion, Now.Year, AmbienteDeBaseDeDatos.Produccion)

#Region "Propiedades"
    'Sentencia SQL
    Private _Select As String
    Public Property SelectSQL As String
        Get
            Return _Select
        End Get
        Set(ByVal value As String)
            _Select = value
        End Set
    End Property

    Private _From As String
    Public Property From() As String
        Get
            Return _From
        End Get
        Set(ByVal value As String)
            _From = value
        End Set
    End Property

    Private _Where As String
    Public Property Where() As String
        Get
            Return _Where
        End Get
        Set(ByVal value As String)
            _Where = value
        End Set
    End Property

    Private _GroupBy As String
    Public Property GroupBy() As String
        Get
            Return _GroupBy
        End Get
        Set(ByVal value As String)
            _GroupBy = value
        End Set
    End Property

    Private _Having As String
    Public Property Having() As String
        Get
            Return _Having
        End Get
        Set(ByVal value As String)
            _Having = value
        End Set
    End Property

    Private _OrderBy As String
    Public Property OrderBy() As String
        Get
            Return _OrderBy
        End Get
        Set(ByVal value As String)
            _OrderBy = value
        End Set
    End Property

    Private _IntoFrom As String 'Alias en DataSets
    Public Property IntoFrom() As String
        Get
            Return _IntoFrom
        End Get
        Set(ByVal value As String)
            _IntoFrom = value
        End Set
    End Property

    'Identificacion del reporte
    Private _NumeroDelReporte As Integer
    Public Property NumeroDelReporte() As Integer
        Get
            Return _NumeroDelReporte
        End Get
        Set(ByVal value As Integer)
            _NumeroDelReporte = value
        End Set
    End Property

    Private _NombreDelReporte As String
    Public Property NombreDelReporte() As String
        Get
            Return _NombreDelReporte
        End Get
        Set(ByVal value As String)
            _NombreDelReporte = value
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

    ' Propiedades del reporte    
    Private _DestinoDelReporte As DestinoDeReportes
    Public Property DestinoDelReporte() As DestinoDeReportes
        Get
            Return _DestinoDelReporte
        End Get
        Set(ByVal value As DestinoDeReportes)
            _DestinoDelReporte = value
        End Set
    End Property

    Private _Reporte As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Public Property Reporte() As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Get
            Return _Reporte
        End Get
        Set(ByVal value As CrystalDecisions.CrystalReports.Engine.ReportDocument)
            _Reporte = value
        End Set
    End Property

    Private _DataSet As DataSet
    Public Property DataSet() As DataSet
        Get
            Return _DataSet
        End Get
        Set(ByVal value As DataSet)
            _DataSet = value
        End Set
    End Property

    '_DataSet.EnforceConstraints
    Private _ForzarConstraints As Boolean
    Public Property ForzarConstraints() As Boolean
        Get
            Return _ForzarConstraints
        End Get
        Set(ByVal value As Boolean)
            _ForzarConstraints = value
        End Set
    End Property

    Private _NombreDeImpresora As String
    Public Property NombreDeImpresora() As String
        Get
            Return _NombreDeImpresora
        End Get
        Set(ByVal value As String)
            _NombreDeImpresora = value
        End Set
    End Property

    Private _NumeroDeCopias As Integer = 1
    Public Property NumeroDeCopias() As Integer
        Get
            Return _NumeroDeCopias
        End Get
        Set(ByVal value As Integer)
            _NumeroDeCopias = value
        End Set
    End Property

    'Public _ShowExportButton As Boolean = True
    Private _MostrarBotonDeImpresion As Boolean = True
    Public Property MostrarBotonDeImpresion() As Boolean
        Get
            Return _MostrarBotonDeImpresion
        End Get
        Set(ByVal value As Boolean)
            _MostrarBotonDeImpresion = value
        End Set
    End Property

    Private _MostrarBotonDeExportar As Boolean = True
    Public Property MostrarBotonDeExportar() As Boolean
        Get
            Return _MostrarBotonDeExportar
        End Get
        Set(ByVal value As Boolean)
            _MostrarBotonDeExportar = value
        End Set
    End Property

    'Exportacion    
    Private _RutaParaExportarArchivo As String
    Public Property RutaParaExportarArchivo() As String
        Get
            Return _RutaParaExportarArchivo
        End Get
        Set(ByVal value As String)
            _RutaParaExportarArchivo = value
        End Set
    End Property

    Private _MostrarBotonGroupTree As Boolean = False
    Public Property MostrarBotonGroupTree() As Boolean
        Get
            Return _MostrarBotonGroupTree
        End Get
        Set(ByVal value As Boolean)
            _MostrarBotonGroupTree = value
        End Set
    End Property
#End Region

#Region "Metodos privados"
    Private Sub GenerarReporte(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Msg As String = ""        
        Me.Text = _NombreDelReporte & " [" & _SiglasDelSistema & "_RPT" & Format(_NumeroDelReporte, "0000") & "]"
        objReporte.Cursor = Cursors.Default

        Try
            Me.objReporte.ShowExportButton = _MostrarBotonDeExportar
            'Me.objReporte.AllowedExportFormats =  (CrystalDecisions.Shared.ViewerExportFormats.PdfFormat, CrystalDecisions.Shared.ViewerExportFormats.XLSXFormat)
            Me.objReporte.ShowPrintButton = _MostrarBotonDeImpresion
            Me.objReporte.ShowGroupTreeButton = _MostrarBotonGroupTree

            If _ForzarConstraints Then _DataSet.EnforceConstraints = False
            For Each _FuenteDeDatos As ReporteFuente In _FuentesDatos
                If _FuenteDeDatos Is Nothing Then Continue For
                If _FuenteDeDatos.Gestor <> _ClaseDeConexion.Gestor Then
                    _ClaseDeConexion = New ReporteConexion(_FuenteDeDatos.Gestor, _FuenteDeDatos.Esquema, _FuenteDeDatos.AñoDeOperacion, _FuenteDeDatos.Ambiente)
                Else
                    _ClaseDeConexion = New ReporteConexion(_FuenteDeDatos.Gestor, _FuenteDeDatos.Esquema, _FuenteDeDatos.AñoDeOperacion, _FuenteDeDatos.Ambiente)
                End If
                If Not _ClaseDeConexion.Select_Datos(_DataSet, _FuenteDeDatos.From, _FuenteDeDatos.Select_, _FuenteDeDatos.Where, _FuenteDeDatos.GroupBy, _FuenteDeDatos.Having, _FuenteDeDatos.OrderBy, 0, _FuenteDeDatos.IntoFrom) Then
                    MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
                    Exit Sub
                End If
            Next

            Select Case _DestinoDelReporte
                Case DestinoDeReportes.Pantalla
                    If Not EnviarAPantalla(Msg) Then MsgBox(Msg, MsgBoxStyle.Critical)
                Case DestinoDeReportes.Impresora
                    If Not EnviarAImpresora(Msg) Then MsgBox(Msg, MsgBoxStyle.Critical)
                Case DestinoDeReportes.Exportar
                    If Not Exportar(_RutaParaExportarArchivo) Then MsgBox(Msg, MsgBoxStyle.Critical)
            End Select
            'If _DestinoReporte = Destino_Reporte.Exportar Or _DestinoReporte = Destino_Reporte.Impresora Then Me.Visible = False
        Catch ex As Exception
            MsgBox("Error generando reporte: " & ex.Message, MsgBoxStyle.Critical)
        Finally            
            objReporte.Cursor = Cursors.Default
            Me.Refresh()
        End Try
    End Sub

    Private Function EnviarAPantalla(ByRef Mensaje As String) As Boolean
        Try
            _Reporte.SetDataSource(_DataSet)
            objReporte.ReportSource = _Reporte
            objReporte.ParameterFieldInfo = _Parametros

            Mensaje = "Reporte generado exitosamente"
            Return True
        Catch ex As Exception
            Mensaje = "Error enviando reporte a pantalla: " & ex.Message
            Return False
        End Try
    End Function

    Private Function Exportar(ByVal RutaDelArchivo As String) As Boolean
        Dim diskOpts As New DiskFileDestinationOptions
        If RutaDelArchivo = "" Then RutaDelArchivo = "C:\reporte_de_verificacion_de_bienes_INTECAP.pdf"
        _Reporte.SetDataSource(_DataSet)
        objReporte.ReportSource = _Reporte
        objReporte.ParameterFieldInfo = _Parametros

        Try
            With _Reporte.ExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
            End With

            If File.Exists(RutaDelArchivo) Then File.Delete(RutaDelArchivo)
            diskOpts.DiskFileName = RutaDelArchivo
            _Reporte.ExportOptions.DestinationOptions = diskOpts

            For Each MyParameter As CrystalDecisions.Shared.ParameterField In _Parametros
                _Reporte.SetParameterValue(MyParameter.Name, MyParameter.CurrentValues)
            Next
            _Reporte.Export()
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function EnviarAImpresora(ByRef Mensaje As String) As Boolean
        Try
          
            _Reporte.SetDataSource(_DataSet)
            objReporte.ReportSource = _Reporte
            objReporte.ParameterFieldInfo = _Parametros

            _Reporte.SetDataSource(_DataSet)

            For Each MyParameter As CrystalDecisions.Shared.ParameterField In _Parametros
                _Reporte.SetParameterValue(MyParameter.Name, MyParameter.CurrentValues)
            Next

            _Reporte.PrintOptions.PrinterName = _NombreDeImpresora
            _Reporte.PrintToPrinter(_NumeroDeCopias, False, 0, 0)
            _Reporte.Close()
            _Reporte.Dispose()
            Return True
        Catch ex As Exception
            Mensaje = "Error enviando reporte a impresora: " & ex.Message
            Return False
        End Try
    End Function
#End Region

#Region "Metodos publicos"
    Public Sub AgregarFormula(ByVal NombreFormula As String, ByVal ValorFormula As Object)
        Try
            _Reporte.DataDefinition.FormulaFields(NombreFormula).Text = "'" & ValorFormula & "'"
        Catch ex As Exception
            MsgBox("Error en AgregarFormula: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Public Sub AgregarParametro(ByVal NombreParametro As String, ByVal ValorParametro As Object)
        Try
            _DiscretValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            _ParameterField = New CrystalDecisions.Shared.ParameterField
            _ParameterField.Name = NombreParametro
            _DiscretValue.Value = ValorParametro
            _ParameterField.CurrentValues.Add(_DiscretValue)
            _Parametros.Add(_ParameterField)
        Catch ex As Exception
            MsgBox("Error en AgregarParametro: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Public Sub AgregarFuenteDeDatos(ByVal Gestor As GestorDeBaseDeDatos, Esquema As EsquemaDeBaseDeDatos, AñoDeOperacion As Integer, Ambiente As AmbienteDeBaseDeDatos)
        _FuentesDatos.Add(New ReporteFuente(Gestor, Esquema, AñoDeOperacion, Ambiente, _Select, _From, _Where, _GroupBy, _Having, _OrderBy, _IntoFrom))
        _Select = "" : _From = "" : _Where = "" : _GroupBy = "" : _Having = "" : _OrderBy = "" : _IntoFrom = ""
    End Sub
#End Region

#Region "Procedimientos"
    Private Sub objReporte_Error(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ExceptionEventArgs) Handles objReporte.Error
        e.Handled = True
        MsgBox(e.Exception.Message, MsgBoxStyle.Critical)
    End Sub

    Private Sub tmpReporte_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If _DestinoDelReporte = DestinoDeReportes.Exportar Or _DestinoDelReporte = DestinoDeReportes.Impresora Then
            'Try
            '    If IsHandleCreated Then
            '        Me.Hide()
            '    End If
            'Catch ex As Exception
            '    MsgBox("Error generando reporte: " & ex.Message, MsgBoxStyle.Critical)
            'Finally
            '    Me.Cursor = Cursors.Default
            'End Try
        End If
    End Sub
#End Region

    Private Sub objReporte_Load(sender As Object, e As EventArgs) Handles objReporte.Load

    End Sub
End Class