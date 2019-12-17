Imports System.Text

Public Class GraficaMultiSerie
#Region "Propiedades"
    Private _CadenaGrafico As New StringBuilder
    Private _NombreDelEjeX As String
    Public Property NombreDelEjeX() As String
        Get
            Return _NombreDelEjeX
        End Get
        Set(ByVal value As String)
            _NombreDelEjeX = value
        End Set
    End Property

    Private _NombreDelEjeY As String
    Public Property NombreDelEjeY() As String
        Get
            Return _NombreDelEjeY
        End Get
        Set(ByVal value As String)
            _NombreDelEjeY = value
        End Set
    End Property

    Private _Titulo As String
    Public Property Titulo() As String
        Get
            Return _Titulo
        End Get
        Set(ByVal value As String)
            _Titulo = value
        End Set
    End Property

    Private _DatosEstadistica As DataTable
    Public Property DatosEstadistica() As DataTable
        Get
            Return _DatosEstadistica
        End Get
        Set(ByVal value As DataTable)
            _DatosEstadistica = value
        End Set
    End Property

    Private _Categoria As String
    Public Property Categoria() As String
        Get
            Return _Categoria
        End Get
        Set(ByVal value As String)
            _Categoria = value
        End Set
    End Property

    Private _ListaDeSeries As List(Of GraficaSeries)
    Public WriteOnly Property AgregarSerie(s As GraficaSeries) As Boolean
        Set(ByVal value As Boolean)
            _ListaDeSeries.Add(s)
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New(nombreDelEjeX As String, nombreDelEjeY As String, titulo As String, datosEstadistica As DataTable)
        _NombreDelEjeX = nombreDelEjeX
        _NombreDelEjeY = nombreDelEjeY
        _Titulo = titulo
        _DatosEstadistica = datosEstadistica
        _ListaDeSeries = New List(Of GraficaSeries)
    End Sub
    Public Sub New()
        _NombreDelEjeX = ""
        _NombreDelEjeY = ""
        _Titulo = ""
        _DatosEstadistica = Nothing
        _ListaDeSeries = New List(Of GraficaSeries)
    End Sub
#End Region

#Region "Metodos"
    Public Function GenerarGrafico() As String
        Dim _DireccionUrlConFormatoDatos As String = ""
        Dim _CamposUrl As Object

        _CadenaGrafico.Clear()
        ' Cabecera
        _CadenaGrafico.Append("<chart ")

        _CadenaGrafico.Append("xAxisName = '" & _NombreDelEjeX & "' ")
        _CadenaGrafico.Append("yAxisName = '" & _NombreDelEjeY & "' ")
        _CadenaGrafico.Append("caption = '" & _Titulo & "' ")
        _CadenaGrafico.Append("useRoundEdges = '1' ") ' Valores 0,1
        _CadenaGrafico.Append("palette = '1' ") ' Rango 1-5
        _CadenaGrafico.Append("numVDivLines = '10' ")
        _CadenaGrafico.Append("divLineAlpha = '30' ")

        _CadenaGrafico.Append("drawAnchors = '0' ")
        _CadenaGrafico.Append("labelPadding = '10' ")
        _CadenaGrafico.Append("yAxisValuesPadding = '10' ")
        _CadenaGrafico.Append("legendBorderAlpha = '0' ")
        _CadenaGrafico.Append("showValues = '1' ")
        _CadenaGrafico.Append("theme = 'zune,ocean' ")
        _CadenaGrafico.Append("bgColor = 'FFFFFF,FFFFFF' ")
        _CadenaGrafico.Append("showBorder = '0' ")
        _CadenaGrafico.Append("animation = '1' ")
        '_CadenaGrafico.Append("numberPrefix ='Q' ")
        _CadenaGrafico.Append("> ")

        ' Categorias
        _CadenaGrafico.Append("<categories> ")
        For Each _Fila As DataRow In _DatosEstadistica.Rows
            _CadenaGrafico.Append("<category label = '" & _Fila(_Categoria) & "'/> ")
        Next
        _CadenaGrafico.Append("</categories> ")

        ' Series y valores
        'Dim _SerieActual As String = ""
        For Each _Serie As GraficaSeries In _ListaDeSeries
            'If _SerieActual <> _Serie.Etiqueta Then
            '_SerieActual = _Serie.Etiqueta
            _CadenaGrafico.Append("<dataset seriesName = '" & _Serie.Etiqueta & "'> ")
            'End If
            For Each _Fila As DataRow In _DatosEstadistica.Rows
                _CadenaGrafico.Append("<set value ='" & _Fila(_Serie.Valor) & "' ")
                If _Serie.DireccionUrlConFormato <> "" Then
                    If _Serie.DireccionUrlCampos = "" Then
                        _CadenaGrafico.Append("link = '" & _Serie.DireccionUrlConFormato & "' ")
                    Else
                        _DireccionUrlConFormatoDatos = _Serie.DireccionUrlConFormato
                        ' Establecer valores para cada campo
                        _CamposUrl = Split(_Serie.DireccionUrlCampos, ",")
                        For _ValorUrl As Integer = 0 To UBound(_CamposUrl)
                            _DireccionUrlConFormatoDatos = Replace(_DireccionUrlConFormatoDatos, "{" & _ValorUrl & "}", _Fila(_CamposUrl(_ValorUrl).ToString.Trim))
                        Next
                        _CadenaGrafico.Append(" link = '" & _DireccionUrlConFormatoDatos & "' ")
                    End If
                End If
                _CadenaGrafico.Append("/>")
            Next
            _CadenaGrafico.Append("</dataset> ")
        Next
        ' Pie
        _CadenaGrafico.Append("</chart>")
        Return _CadenaGrafico.ToString
    End Function
#End Region
End Class

Public Class GraficaSeries

#Region "Propiedades"
    Private _Etiqueta As String
    Public Property Etiqueta() As String
        Get
            Return _Etiqueta
        End Get
        Set(ByVal value As String)
            _Etiqueta = value
        End Set
    End Property

    Private _Valor As String
    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property

    Private _DireccionUrlConFormato As String
    Public Property DireccionUrlConFormato() As String
        Get
            Return _DireccionUrlConFormato
        End Get
        Set(ByVal value As String)
            _DireccionUrlConFormato = value
        End Set
    End Property

    Private _DireccionUrlCampos As String
    Public Property DireccionUrlCampos() As String
        Get
            Return _DireccionUrlCampos
        End Get
        Set(ByVal value As String)
            _DireccionUrlCampos = value
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New(etiqueta As String, valor As String, direccionUrlConFormato As String, direccionUrlCampos As String)
        _Etiqueta = etiqueta
        _Valor = valor
        _DireccionUrlConFormato = direccionUrlConFormato
        _DireccionUrlCampos = direccionUrlCampos
    End Sub
#End Region
End Class
