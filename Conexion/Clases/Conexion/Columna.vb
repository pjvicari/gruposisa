Public Class Columna

#Region "Propiedades"
    Private _NombreMostrar As String
    Friend ReadOnly Property NombreMostrar() As String
        Get
            Return _NombreMostrar
        End Get
    End Property

    Private _NombreCampo As String
    Friend ReadOnly Property NombreCampo() As String
        Get
            Return _NombreCampo
        End Get
    End Property

    Private _PorcentajeTamaño As Integer
    Friend ReadOnly Property PorcentajeTamaño() As Integer
        Get
            Return _PorcentajeTamaño
        End Get
    End Property

    Private _IncluirEnBusqueda As Boolean
    Friend ReadOnly Property IncluirEnBusqueda() As Boolean
        Get
            Return _IncluirEnBusqueda
        End Get
    End Property

    Private _Control As Object
    Friend ReadOnly Property Control() As Object
        Get
            Return _Control
        End Get
    End Property

    Private _Alineacion As DataGridViewContentAlignment
    Friend ReadOnly Property Alineacion() As DataGridViewContentAlignment
        Get
            Return _Alineacion
        End Get
    End Property

    Private _AlineacionHorizontal As HorizontalAlignment
    Public Property AlineacionHorizontal() As HorizontalAlignment
        Get
            Return _AlineacionHorizontal
        End Get
        Set(ByVal value As HorizontalAlignment)
            _AlineacionHorizontal = value
        End Set
    End Property

    Private _EditarAl As TipoDeEdicion
    Friend ReadOnly Property EditarAl() As TipoDeEdicion
        Get
            Return _EditarAl
        End Get
    End Property

    Private _Formato As String
    Friend ReadOnly Property Formato() As String
        Get
            Return _Formato
        End Get
    End Property

    Private _TipoDeColumna As TipoDeColumna
    Public Property TipoDeColumna() As TipoDeColumna
        Get
            Return _TipoDeColumna
        End Get
        Set(ByVal value As TipoDeColumna)
            _TipoDeColumna = value
        End Set
    End Property

    Private _EsLlavePrimaria As Boolean
    Public Property EsLlavePrimaria() As Boolean
        Get
            Return _EsLlavePrimaria
        End Get
        Set(ByVal value As Boolean)
            _EsLlavePrimaria = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New(ByVal ParNombreMostrar As String, ByVal ParNombreCampo As String, ByVal ParPorcentajeTamaño As Integer, ByVal ParBusqueda As Boolean, ByVal ParControl As Object, ByVal ParAliniacion As DataGridViewContentAlignment, ByVal ParEditarAl As TipoDeEdicion, ByVal ParFormato As String, ParTipoColumna As TipoDeColumna, ParEsLlavePrimaria As Boolean)
        _NombreMostrar = ParNombreMostrar
        _NombreCampo = ParNombreCampo
        _PorcentajeTamaño = ParPorcentajeTamaño
        _IncluirEnBusqueda = ParBusqueda
        _Control = ParControl
        _Alineacion = ParAliniacion
        _EditarAl = ParEditarAl
        _Formato = ParFormato
        _TipoDeColumna = ParTipoColumna
        _EsLlavePrimaria = ParEsLlavePrimaria
    End Sub
#End Region
End Class

Public Class LlavePrimaria
#Region "Propiedades"
    Private _NombreDelCampo As String
    Friend ReadOnly Property NombreCampo() As String
        Get
            Return _NombreDelCampo
        End Get
    End Property

    Private _ValorDelCampo As Object
    Public Property ValorCampo() As Object
        Get
            Return _ValorDelCampo
        End Get
        Set(ByVal value As Object)
            _ValorDelCampo = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New(ByVal nombreDelCampo As String, valorDelCampo As Object)
        _NombreDelCampo = nombreDelCampo
        _ValorDelCampo = valorDelCampo
    End Sub
#End Region
End Class