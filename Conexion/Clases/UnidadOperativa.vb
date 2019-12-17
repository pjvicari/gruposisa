Public Class UnidadOperativa
#Region "Constructores"
    Public Sub New(ByVal idUnidadOperativa As String, ByVal siglasUnidadOperativa As String, ByVal nombreUnidadOperativa As String)
        _IDUnidadOperativa = idUnidadOperativa
        _SiglasUnidadOperativa = siglasUnidadOperativa
        _NombreUnidadOperativa = nombreUnidadOperativa
    End Sub

    Public Sub New()
        _IDUnidadOperativa = ""
        _SiglasUnidadOperativa = ""
        _NombreUnidadOperativa = ""
        _IDDireccion = 0
        _Direccion = ""
    End Sub
#End Region

#Region "Propiedades"
    Private _IDUnidadOperativa As String
    Public Property IDUnidadOperativa() As String
        Get
            Return _IDUnidadOperativa
        End Get
        Set(ByVal value As String)
            _IDUnidadOperativa = value
        End Set
    End Property

    Private _SiglasUnidadOperativa As String
    Public Property SiglasUnidadOperativa() As String
        Get
            Return _SiglasUnidadOperativa
        End Get
        Set(ByVal value As String)
            _SiglasUnidadOperativa = value
        End Set
    End Property

    Private _NombreUnidadOperativa As String
    Public Property NombreUnidadOperativa() As String
        Get
            Return _NombreUnidadOperativa
        End Get
        Set(ByVal value As String)
            _NombreUnidadOperativa = value
        End Set
    End Property

    Private _IDDireccion As Integer
    Public Property IDDireccion() As Integer
        Get
            Return _IDDireccion
        End Get
        Set(ByVal value As Integer)
            _IDDireccion = value
        End Set
    End Property

    Private _Direccion As String
    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property
#End Region
End Class