Public Class ReporteFuente
#Region "Propiedades"
    Private _Gestor As GestorDeBaseDeDatos
    Public ReadOnly Property Gestor() As GestorDeBaseDeDatos
        Get
            Return _Gestor
        End Get
    End Property

    Private _Esquema As EsquemaDeBaseDeDatos
    Public Property Esquema() As EsquemaDeBaseDeDatos
        Get
            Return _Esquema
        End Get
        Set(ByVal value As EsquemaDeBaseDeDatos)
            _Esquema = value
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

    Private _Ambiente As AmbienteDeBaseDeDatos
    Public Property Ambiente() As AmbienteDeBaseDeDatos
        Get
            Return _Ambiente
        End Get
        Set(ByVal value As AmbienteDeBaseDeDatos)
            _Ambiente = value
        End Set
    End Property

    Private _Select As String
    Public ReadOnly Property Select_() As String
        Get
            Return _Select
        End Get
    End Property

    Private _From As String
    Public ReadOnly Property From() As String
        Get
            Return _From
        End Get
    End Property

    Private _Where As String
    Public ReadOnly Property Where() As String
        Get
            Return _Where
        End Get
    End Property

    Private _GroupBy As String
    Public ReadOnly Property GroupBy() As String
        Get
            Return _GroupBy
        End Get
    End Property

    Private _Having As String
    Public ReadOnly Property Having() As String
        Get
            Return _Having
        End Get
    End Property

    Private _OrderBy As String
    Public ReadOnly Property OrderBy() As String
        Get
            Return _OrderBy
        End Get
    End Property

    ' DataSet alias para incrustar queries en estructuras
    Private _IntoFrom As String
    Public ReadOnly Property IntoFrom() As String
        Get
            Return _IntoFrom
        End Get
    End Property
#End Region

#Region "Contstructor"
    Public Sub New(ByVal gestorDeBaseDeDatos As GestorDeBaseDeDatos, esquemaDeBaseDeDatos As EsquemaDeBaseDeDatos, añoDeOperacion As Integer, ambienteDeBaseDeDatos As AmbienteDeBaseDeDatos, ByVal selectSQL As String, ByVal fromSQL As String, ByVal where As String, ByVal groupBy As String, ByVal having As String, ByVal orderBy As String, ByVal intoFrom As String)
        _Gestor = gestorDeBaseDeDatos
        _Esquema = esquemaDeBaseDeDatos
        _AñoDeOperacion = añoDeOperacion
        _Ambiente = ambienteDeBaseDeDatos

        _Select = selectSQL
        _From = fromSQL
        _Where = where
        _GroupBy = groupBy
        _Having = having
        _OrderBy = orderBy
        _IntoFrom = intoFrom
    End Sub
#End Region
End Class
