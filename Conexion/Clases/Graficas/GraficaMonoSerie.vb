Imports System.Text

Public Class GraficaMonoSerie
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

#Region "Constructores"
    Public Sub New(nombreDelEjeX As String, nombreDelEjeY As String, titulo As String, datosEstadistica As DataTable, etiqueta As String, valor As String, direccionUrlConFormato As String, direccionUrlCampos As String)
        _NombreDelEjeX = nombreDelEjeX
        _NombreDelEjeY = nombreDelEjeY
        _Titulo = titulo
        _DatosEstadistica = datosEstadistica
        _Etiqueta = etiqueta
        _Valor = valor
        _DireccionUrlConFormato = direccionUrlConFormato
        _DireccionUrlCampos = direccionUrlCampos
    End Sub
    Public Sub New(nombreDelEjeX As String, nombreDelEjeY As String, titulo As String, datosEstadistica As DataTable, etiqueta As String, valor As String)
        _NombreDelEjeX = nombreDelEjeX
        _NombreDelEjeY = nombreDelEjeY
        _Titulo = titulo
        _DatosEstadistica = datosEstadistica
        _Etiqueta = etiqueta
        _Valor = valor
        _DireccionUrlConFormato = ""
        _DireccionUrlCampos = ""
    End Sub
    Public Sub New()
        _NombreDelEjeX = ""
        _NombreDelEjeY = ""
        _Titulo = ""
        _DatosEstadistica = Nothing
        _Etiqueta = ""
        _Valor = """"
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
        _CadenaGrafico.Append("useRoundEdges = '1' ")
        '_CadenaGrafico.Append("useRoundEdges = '0' ")
        _CadenaGrafico.Append("bgColor = 'FFFFFF,FFFFFF' ")
        _CadenaGrafico.Append("showBorder = '0' ")
        _CadenaGrafico.Append("animation = '1' ")
        '_CadenaGrafico.Append("numberPrefix ='Q' ")

        _CadenaGrafico.Append("> ")
        ' Etiquetas y valores
        For Each _Dato As DataRow In _DatosEstadistica.Rows
            _CadenaGrafico.Append("<set label = '" & _Dato(_Etiqueta) & "' ")
            _CadenaGrafico.Append("value = '" & _Dato(_Valor) & "' ")
            If _DireccionUrlConFormato <> "" Then
                If _DireccionUrlCampos = "" Then
                    _CadenaGrafico.Append("link = '" & _DireccionUrlConFormato & "' ")
                Else
                    _DireccionUrlConFormatoDatos = _DireccionUrlConFormato
                    ' Establecer valores para cada campo
                    _CamposUrl = Split(_DireccionUrlCampos, ",")
                    For _ValorUrl As Integer = 0 To UBound(_CamposUrl)
                        _DireccionUrlConFormatoDatos = Replace(_DireccionUrlConFormatoDatos, "{" & _ValorUrl & "}", _Dato(_CamposUrl(_ValorUrl).ToString.Trim))
                    Next
                    _CadenaGrafico.Append(" link = '" & _DireccionUrlConFormatoDatos & "' ")
                End If
            End If
            _CadenaGrafico.Append("/>")
        Next
        ' Pie
        _CadenaGrafico.Append("</chart>")
        Return _CadenaGrafico.ToString
    End Function
#End Region
End Class
