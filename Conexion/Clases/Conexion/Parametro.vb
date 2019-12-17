Imports Oracle.DataAccess.Client

Public Class Parametro
#Region "Propiedades"
    Private _Nombre As String
    Friend ReadOnly Property Nombre() As String
        Get
            Return _Nombre
        End Get
    End Property

    Private _Expresion As String
    Public Property Expresion() As String
        Get
            Return _Expresion
        End Get
        Set(ByVal value As String)
            _Expresion = value
        End Set
    End Property

    Private _Valor As Object
    Friend ReadOnly Property Valor() As Object
        Get
            Return _Valor
        End Get
    End Property

    Private _EsLlavePrimaria As Boolean
    Friend ReadOnly Property EsLlavePrimaria() As Boolean
        Get
            Return _EsLlavePrimaria
        End Get
    End Property

    Private _EsIdentidad As Boolean
    Friend ReadOnly Property EsIdentidad() As Boolean
        Get
            Return _EsIdentidad
        End Get
    End Property

    Private _OperadorLogico As TipoDeOperadorLogico
    Friend ReadOnly Property OperadorLogico() As TipoDeOperadorLogico
        Get
            Return _OperadorLogico
        End Get
    End Property

    Private _OperadorDeCompracion As TipoDeOperadorDeComparacion = TipoDeOperadorDeComparacion.Igual
    Public Property OperadorDeComparacion() As TipoDeOperadorDeComparacion
        Get
            Return _OperadorDeCompracion
        End Get
        Set(ByVal value As TipoDeOperadorDeComparacion)
            _OperadorDeCompracion = value
        End Set
    End Property

    Private _DireccionDelParametro As System.Data.ParameterDirection
    Friend ReadOnly Property DireccionDelParametro() As System.Data.ParameterDirection
        Get
            Return _DireccionDelParametro
        End Get
    End Property

    Private _TipoDeParametro As OracleDbType
    Friend ReadOnly Property TipoDeParametro() As OracleDbType
        Get
            Return _TipoDeParametro
        End Get
    End Property

    Private _EsExpresion As Boolean
    Public Property EsExpresion() As Boolean
        Get
            Return _EsExpresion
        End Get
        Set(ByVal value As Boolean)
            _EsExpresion = value
        End Set
    End Property

    Private _AgruparCriteriosApertura As Boolean
    Public Property AgruparCriteriosApertura() As Boolean
        Get
            Return _AgruparCriteriosApertura
        End Get
        Set(ByVal value As Boolean)
            _AgruparCriteriosApertura = value
        End Set
    End Property

    Private _AgruparCriteriosCierre As Boolean
    Public Property AgruparCriteriosCierre() As Boolean
        Get
            Return _AgruparCriteriosCierre
        End Get
        Set(ByVal value As Boolean)
            _AgruparCriteriosCierre = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Friend Sub New(ByVal nombreDelParametro As String, ByVal valorDelParametro As Object, ByVal tipoDelParametro As OracleDbType)
        _Nombre = nombreDelParametro
        _Valor = valorDelParametro
        _TipoDeParametro = tipoDelParametro
        _EsLlavePrimaria = False
        _EsIdentidad = False
        _OperadorLogico = TipoDeOperadorLogico.AndOperador
        _DireccionDelParametro = ParameterDirection.InputOutput
    End Sub

    Friend Sub New(ByVal nombreDelParametro As String, ByVal valorDelParametro As Object, ByVal tipoDelParametro As OracleDbType, ByVal esLlavePrimaria As Boolean)
        _Nombre = nombreDelParametro
        _Valor = valorDelParametro
        _EsLlavePrimaria = esLlavePrimaria
        _EsIdentidad = False
        _OperadorLogico = TipoDeOperadorLogico.AndOperador
        _DireccionDelParametro = ParameterDirection.InputOutput
        _TipoDeParametro = tipoDelParametro
    End Sub

    Friend Sub New(ByVal nombreDelParametro As String, ByVal valorDelParametro As Object, ByVal tipoDelParametro As OracleDbType, ByVal esLlavePrimaria As Boolean, ByVal esIdentidad As Boolean)
        _Nombre = nombreDelParametro
        _Valor = valorDelParametro
        _EsLlavePrimaria = esLlavePrimaria
        _EsIdentidad = esIdentidad
        _OperadorLogico = TipoDeOperadorLogico.AndOperador
        _DireccionDelParametro = ParameterDirection.InputOutput
        _TipoDeParametro = tipoDelParametro
    End Sub

    Friend Sub New(ByVal nombreDelParametro As String, ByVal valorDelParametro As Object, ByVal tipoDelParametro As OracleDbType, ByVal esLlavePrimaria As Boolean, ByVal esIdentidad As Boolean, ByVal operadorLogico As TipoDeOperadorLogico)
        _Nombre = nombreDelParametro
        _Valor = valorDelParametro
        _EsLlavePrimaria = esLlavePrimaria
        _EsIdentidad = esIdentidad
        _OperadorLogico = operadorLogico
        _DireccionDelParametro = ParameterDirection.InputOutput
        _TipoDeParametro = tipoDelParametro
    End Sub

    Friend Sub New(ByVal nombreDelParametro As String, ByVal valorDelParametro As Object, ByVal tipoDelParametro As OracleDbType, ByVal esLlavePrimaria As Boolean, ByVal esIdentidad As Boolean, ByVal operadorLogico As TipoDeOperadorLogico, ByVal direccionDelParametro As ParameterDirection)
        _Nombre = nombreDelParametro
        _Valor = valorDelParametro
        _EsLlavePrimaria = esLlavePrimaria
        _EsIdentidad = esIdentidad
        _OperadorLogico = operadorLogico
        _DireccionDelParametro = direccionDelParametro
        _TipoDeParametro = tipoDelParametro
    End Sub

    ' Para uso de los parametros WHERE
    Friend Sub New(ByVal expresionDelParametro As String, ByVal valorDelParametro As Object, ByVal tipoDelParametro As OracleDbType, ByVal operadorLogico As TipoDeOperadorLogico, operadorDeComparacion As TipoDeOperadorDeComparacion, esExpresion As Boolean)
        _DireccionDelParametro = ParameterDirection.InputOutput
        _EsLlavePrimaria = False
        _EsIdentidad = False
        _AgruparCriteriosApertura = False
        _AgruparCriteriosCierre = False

        _Expresion = expresionDelParametro
        _Valor = valorDelParametro
        _OperadorLogico = operadorLogico
        _TipoDeParametro = tipoDelParametro
        _OperadorDeCompracion = operadorDeComparacion
        _Nombre = expresionDelParametro
        _EsExpresion = esExpresion
    End Sub

    Friend Sub New(ByVal expresionDelParametro As String, ByVal valorDelParametro As Object, ByVal tipoDelParametro As OracleDbType, ByVal operadorLogico As TipoDeOperadorLogico, operadorDeComparacion As TipoDeOperadorDeComparacion, esExpresion As Boolean, agruparCriteriosApertura As Boolean, agruparCriteriosCierre As Boolean)
        _DireccionDelParametro = ParameterDirection.InputOutput
        _EsLlavePrimaria = False
        _EsIdentidad = False
        _AgruparCriteriosApertura = agruparCriteriosApertura
        _AgruparCriteriosCierre = agruparCriteriosCierre

        _Expresion = expresionDelParametro
        _Valor = valorDelParametro
        _OperadorLogico = operadorLogico
        _TipoDeParametro = tipoDelParametro
        _OperadorDeCompracion = operadorDeComparacion
        _Nombre = expresionDelParametro
        _EsExpresion = esExpresion
    End Sub

    Friend Sub New(ByVal expresionDelParametro As String, nombreDelParametro As String, ByVal valorDelParametro As Object, ByVal tipoDelParametro As OracleDbType, ByVal operadorLogico As TipoDeOperadorLogico, operadorDeComparacion As TipoDeOperadorDeComparacion, esExpresion As Boolean)
        _DireccionDelParametro = ParameterDirection.InputOutput
        _EsLlavePrimaria = False
        _EsIdentidad = False
        _AgruparCriteriosApertura = False
        _AgruparCriteriosCierre = False

        _Expresion = expresionDelParametro
        _Nombre = nombreDelParametro
        _Valor = valorDelParametro
        _OperadorLogico = operadorLogico
        _TipoDeParametro = tipoDelParametro
        _OperadorDeCompracion = operadorDeComparacion
        _EsExpresion = esExpresion
    End Sub

    Friend Sub New(ByVal expresionDelParametro As String, nombreDelParametro As String, ByVal valorDelParametro As Object, ByVal tipoDelParametro As OracleDbType, ByVal operadorLogico As TipoDeOperadorLogico, operadorDeComparacion As TipoDeOperadorDeComparacion, esExpresion As Boolean, agruparCriteriosApertura As Boolean, agruparCriteriosCierre As Boolean)
        _DireccionDelParametro = ParameterDirection.InputOutput
        _EsLlavePrimaria = False
        _EsIdentidad = False
        _AgruparCriteriosApertura = agruparCriteriosApertura
        _AgruparCriteriosCierre = agruparCriteriosCierre

        _Expresion = expresionDelParametro
        _Nombre = nombreDelParametro
        _Valor = valorDelParametro
        _OperadorLogico = operadorLogico
        _TipoDeParametro = tipoDelParametro
        _OperadorDeCompracion = operadorDeComparacion
        _EsExpresion = esExpresion
    End Sub
#End Region
End Class