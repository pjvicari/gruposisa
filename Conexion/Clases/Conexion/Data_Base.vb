
Public Class Data_Base
#Region "Variables"
    Private _Conexion As IDbConnection
    Private _Comando As IDbCommand
    Private _Transaccion As IDbTransaction
    Private _Adaptador As Object
    'Private _Parametro As IDbDataParameter
    'Private _Parametro As Object
    Private _Parametro As Object
    'Private _Parametro As OracleDbType

    Protected Friend _UsaParametros As Boolean
    Private _Parametros(0) As Parametro
    Private _ParametrosWhere As List(Of Parametro)
#End Region

#Region "Propiedades"
    Private _Gestor As GestorDeBaseDeDatos
    Public ReadOnly Property Gestor() As GestorDeBaseDeDatos
        Get
            Return _Gestor
        End Get
    End Property

    Private _Mensaje As String
    Public Property Mensaje() As String
        Set(value As String)
            _Mensaje = value
        End Set
        Get
            Return _Mensaje.Replace("'", "")
        End Get
    End Property

    Private _RegistrosAfectados As String
    Public ReadOnly Property RegistrosAfectados() As String
        Get
            Return _RegistrosAfectados
        End Get
    End Property

    Private _SentenciaSQL As String
    Public ReadOnly Property SenteciaSQL() As String
        Get
            Return _SentenciaSQL
        End Get
    End Property

    Private _CantidadDeRegistros As Integer
    Public Property CantidadDeRegistros() As Integer
        Get
            Return _CantidadDeRegistros
        End Get
        Set(ByVal value As Integer)
            _CantidadDeRegistros = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Protected Friend Sub New(ByVal gestor As GestorDeBaseDeDatos, ByVal connectionString As String)
        Try
            Select Case gestor
                Case GestorDeBaseDeDatos.SQLServer
                    _Conexion = New SqlConnection
                    _Comando = New SqlCommand
                    _Adaptador = New SqlDataAdapter
                    _Parametro = New SqlParameter
                Case GestorDeBaseDeDatos.Oracle
                    _Conexion = New OracleConnection
                    _Comando = New OracleCommand
                    _Adaptador = New OracleDataAdapter
                    _Parametro = New OracleParameter
                Case GestorDeBaseDeDatos.MySQL
                    _Conexion = New MySql.Data.MySqlClient.MySqlConnection
                    _Comando = New MySql.Data.MySqlClient.MySqlCommand
                    _Adaptador = New MySql.Data.MySqlClient.MySqlDataAdapter
                    _Parametro = New MySql.Data.MySqlClient.MySqlParameter
                    'Case Tipo_de_Base_Datos.ODBC
                    '    _Connection = New Odbc.OdbcConnection
                    '    _Command = New Odbc.OdbcCommand
                    '    _DataAdapter = New Odbc.OdbcDataAdapter
                    '    _DataParameter = New Odbc.OdbcParameter
            End Select
            _Conexion.ConnectionString = connectionString
            _Comando.Connection = _Conexion
            _Mensaje = ""
            ReDim _Parametros(0)
            _Gestor = gestor
        Catch ex As Exception
            _Mensaje = "Error en operación: " & ex.Message
        End Try
    End Sub
#End Region

#Region "Metodos Publicos"
    Public Sub IniciarTransaccion()
        If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
        _Transaccion = _Conexion.BeginTransaction()
        _Comando.Transaction = _Transaccion
    End Sub

    Public Sub ConfirmarTransaccion()
        _Transaccion.Commit()
        If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
    End Sub

    Public Sub ReversarTransaccion()
        _Transaccion.Rollback()
        If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
    End Sub

    Public Function ObtenerDatos(ByVal SentenciaSQL As String, ByRef Contenedor As DataSet, ByVal Tabla As String) As Boolean
        Dim _DataSet As New DataSet
        Try
            If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
            _Comando.CommandText = SentenciaSQL
            _Adaptador.SelectCommand = _Comando
            _Adaptador.Fill(_DataSet, Tabla)
            If Contenedor.Tables.Contains(Tabla) Then
                Contenedor.Tables(Tabla).Clear()
            End If
            Try
                Contenedor.Merge(_DataSet)
            Catch ex As Exception
                Contenedor.Merge(_DataSet, True, MissingSchemaAction.Ignore)
            End Try
            _RegistrosAfectados = Contenedor.Tables(Tabla).Rows.Count
            _Mensaje = "Operación exitosa: (" & _RegistrosAfectados.ToString & ") registros encontrados."
            Return True
        Catch ex As Exception
            _Mensaje = "Error en operación: " & ex.Message
            Return False
        Finally
            If IsNothing(_Comando.Transaction) Then If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
        End Try
    End Function

    Public Function ObtenerDatos(ByVal SentenciaSQL As String, ByRef Contenedor As DataTable) As Boolean
        Try
            If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
            _Comando.CommandText = SentenciaSQL
            _Adaptador.SelectCommand = _Comando
            Contenedor.Clear()
            _Adaptador.Fill(Contenedor)
            _RegistrosAfectados = Contenedor.Rows.Count
            _Mensaje = "Operación exitosa: (" & _RegistrosAfectados.ToString & ") registros encontrados."
            Return True
        Catch ex As Exception
            _Mensaje = "Error en operación: " & ex.Message
            Return False
        Finally
            If IsNothing(_Comando.Transaction) Then If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
        End Try
    End Function

    ' Escalar (String)
    Public Function ObtenerDatos2(ByVal sentenciaSQL As String, ByRef contenedor As String) As Boolean
        Try

            If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
            _Comando.CommandText = sentenciaSQL
            contenedor = ""
            If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
            _Comando.CommandText = sentenciaSQL

            If Not _ParametrosWhere Is Nothing Then
                For Each _Criterio As Parametro In _ParametrosWhere
                    If _Criterio Is Nothing Then Exit For

                    ' Si es IN() por el momento no lo usa como parametro
                    If _Criterio.OperadorDeComparacion = TipoDeOperadorDeComparacion.InOperador Then Continue For
                    If _Criterio.OperadorDeComparacion = TipoDeOperadorDeComparacion.RegExpLike Then Continue For
                    If _Criterio.OperadorDeComparacion = TipoDeOperadorDeComparacion.NotRegExpLike Then Continue For
                    If _Criterio.Nombre = "" Then Continue For
                    If _Criterio.EsExpresion = True Then Continue For

                    Select Case _Gestor
                        Case GestorDeBaseDeDatos.SQLServer
                            _Parametro = New SqlClient.SqlParameter
                        Case GestorDeBaseDeDatos.Oracle
                            _Parametro = New OracleParameter
                    End Select

                    _Parametro.ParameterName = _Criterio.Nombre
                    Select Case _Criterio.TipoDeParametro
                        Case OracleDbType.Blob
                            _Parametro.Value = _Criterio.Valor
                            _Parametro.OracleDbType = OracleDbType.Blob
                        Case OracleDbType.Varchar2, OracleDbType.NVarchar2, DbType.String
                            ' Cuando se tienen que trasladar como vienen los valores
                            If _Criterio.EsExpresion Then
                                _Parametro.Value = _Criterio.Valor
                            Else
                                _Parametro.Value = _Criterio.Valor.ToString.Replace("'", "")
                            End If
                            _Parametro.DbType = _Criterio.TipoDeParametro
                        Case Else
                            _Parametro.Value = _Criterio.Valor
                            _Parametro.DbType = _Criterio.TipoDeParametro
                    End Select

                    _Parametro.Direction = _Criterio.DireccionDelParametro
                    _Comando.Parameters.Add(_Parametro)
                    _Parametro = Nothing
                Next
            End If

            ' Listar los parametros
            Select Case _Gestor
                Case GestorDeBaseDeDatos.SQLServer
                    Debug.Print("SQL: " & _Comando.CommandText)
                    For Each _ParametroComand As SqlClient.SqlParameter In _Comando.Parameters
                        Debug.Print("Nombre: " & _ParametroComand.ParameterName)
                        Debug.Print("Valor: " & _ParametroComand.Value)
                    Next
                Case GestorDeBaseDeDatos.Oracle
                    Debug.Print("SQL: " & _Comando.CommandText)
                    For Each _ParametroComand As OracleParameter In _Comando.Parameters
                        Debug.Print("Nombre: " & _ParametroComand.ParameterName)
                        Debug.Print("Valor: " & _ParametroComand.Value)
                    Next
            End Select

            contenedor = CStr(_Comando.ExecuteScalar)
            If Not IsNothing(contenedor) Then _RegistrosAfectados = 1 Else _RegistrosAfectados = 0
            _Mensaje = "Operación exitosa: (" & _RegistrosAfectados.ToString & ") registros encontrados."
            Return True
        Catch ex As Exception
            _Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    ' DataTable
    Public Function ObtenerDatos2(ByVal sentenciaSQL As String, ByRef contenedor As DataTable) As Boolean
        Try
            'If _Gestor <> GestorDeBaseDeDatos.Excel Then
            If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
            'End If
            _Comando.CommandText = sentenciaSQL

            Select Case Gestor
                Case GestorDeBaseDeDatos.SQLServer
                    _Adaptador = New SqlDataAdapter
                Case GestorDeBaseDeDatos.Oracle
                    _Adaptador = New OracleDataAdapter
            End Select
            _Adaptador.SelectCommand = _Comando

            If Not _ParametrosWhere Is Nothing Then
                For Each _Criterio As Parametro In _ParametrosWhere
                    If _Criterio Is Nothing Then Exit For
                    ' Si es IN() por el momento no lo usa como parametro
                    If _Criterio.OperadorDeComparacion = TipoDeOperadorDeComparacion.InOperador Then Continue For
                    If _Criterio.OperadorDeComparacion = TipoDeOperadorDeComparacion.IsOperador Then Continue For
                    If _Criterio.OperadorDeComparacion = TipoDeOperadorDeComparacion.RegExpLike Then Continue For
                    If _Criterio.OperadorDeComparacion = TipoDeOperadorDeComparacion.NotRegExpLike Then Continue For
                    If _Criterio.Nombre = "" Then Continue For
                    If _Criterio.EsExpresion = True Then Continue For

                    Select Case _Gestor
                        Case GestorDeBaseDeDatos.SQLServer
                            _Parametro = New SqlClient.SqlParameter
                        Case GestorDeBaseDeDatos.Oracle
                            _Parametro = New OracleParameter
                    End Select

                    _Parametro.ParameterName = _Criterio.Nombre
                    Select Case _Criterio.TipoDeParametro
                        Case OracleDbType.Blob
                            _Parametro.Value = _Criterio.Valor
                            _Parametro.OracleDbType = OracleDbType.Blob
                        Case OracleDbType.Varchar2, OracleDbType.NVarchar2, DbType.String
                            ' Cuando se tienen que trasladar como vienen los valores
                            If _Criterio.EsExpresion Then
                                _Parametro.Value = _Criterio.Valor
                            Else
                                _Parametro.Value = _Criterio.Valor.ToString.Replace("'", "")
                            End If
                            _Parametro.DbType = _Criterio.TipoDeParametro
                        Case Else
                            _Parametro.Value = _Criterio.Valor
                            _Parametro.DbType = _Criterio.TipoDeParametro
                    End Select

                    _Parametro.Direction = _Criterio.DireccionDelParametro
                    _Comando.Parameters.Add(_Parametro)
                    _Parametro = Nothing
                Next
            End If

            ' Listar los parametros
            Select Case _Gestor
                Case GestorDeBaseDeDatos.SQLServer
                    Debug.Print("SQL: " & _Comando.CommandText)
                    For Each _ParametroComand As SqlClient.SqlParameter In _Comando.Parameters
                        Debug.Print("Nombre: " & _ParametroComand.ParameterName)
                        Debug.Print("Valor: " & _ParametroComand.Value)
                    Next
                Case GestorDeBaseDeDatos.Oracle
                    Debug.Print("SQL: " & _Comando.CommandText)
                    For Each _ParametroComand As OracleParameter In _Comando.Parameters
                        Debug.Print("Nombre: " & _ParametroComand.ParameterName)
                        Debug.Print("Valor: " & _ParametroComand.Value)
                    Next
            End Select

            contenedor.Clear()
            Debug.Print("Inicio: " & Now & Environment.NewLine)
            _Adaptador.Fill(contenedor)
            Debug.Print("Fin: " & Now & Environment.NewLine)
            _RegistrosAfectados = contenedor.Rows.Count
            _Mensaje = "Operación exitosa: (" & _RegistrosAfectados.ToString & ") registros encontrados."
            Return True
        Catch ex As Exception
            _Mensaje = "Error en operación: " & ex.Message
            Return False
        Finally
            If IsNothing(_Comando.Transaction) Then If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
        End Try
    End Function

    ' DataSet
    Public Function ObtenerDatos2(ByVal sentenciaSQL As String, ByRef contenedor As DataSet, ByVal nombreTabla As String) As Boolean
        Dim _DataSet As New DataSet
        Try
            If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
            _Comando.CommandText = sentenciaSQL
            _Adaptador.SelectCommand = _Comando

            If Not _ParametrosWhere Is Nothing Then
                For Each _Criterio As Parametro In _ParametrosWhere
                    If _Criterio Is Nothing Then Exit For
                    ' Si es IN() por el momento no lo usa como parametro
                    If _Criterio.OperadorDeComparacion = TipoDeOperadorDeComparacion.InOperador Then Continue For
                    If _Criterio.OperadorDeComparacion = TipoDeOperadorDeComparacion.RegExpLike Then Continue For
                    If _Criterio.OperadorDeComparacion = TipoDeOperadorDeComparacion.NotRegExpLike Then Continue For
                    If _Criterio.Nombre = "" Then Continue For
                    If _Criterio.EsExpresion = True Then Continue For

                    Select Case _Gestor
                        Case GestorDeBaseDeDatos.SQLServer
                            _Parametro = New SqlClient.SqlParameter
                        Case GestorDeBaseDeDatos.Oracle
                            _Parametro = New OracleParameter
                    End Select

                    _Parametro.ParameterName = _Criterio.Nombre
                    Select Case _Criterio.TipoDeParametro
                        Case OracleDbType.Blob
                            _Parametro.Value = _Criterio.Valor
                            _Parametro.OracleDbType = OracleDbType.Blob
                        Case OracleDbType.Varchar2, OracleDbType.NVarchar2, DbType.String
                            ' Cuando se tienen que trasladar como vienen los valores
                            If _Criterio.EsExpresion Then
                                _Parametro.Value = _Criterio.Valor
                            Else
                                _Parametro.Value = _Criterio.Valor.ToString.Replace("'", "")
                            End If
                            _Parametro.DbType = _Criterio.TipoDeParametro
                        Case Else
                            _Parametro.Value = _Criterio.Valor
                            _Parametro.DbType = _Criterio.TipoDeParametro
                    End Select

                    _Parametro.Direction = _Criterio.DireccionDelParametro
                    _Comando.Parameters.Add(_Parametro)
                    _Parametro = Nothing
                Next
            End If

            ' Listar los parametros
            Select Case _Gestor
                Case GestorDeBaseDeDatos.SQLServer
                    Debug.Print("SQL: " & _Comando.CommandText)
                    For Each _ParametroComand As SqlClient.SqlParameter In _Comando.Parameters
                        Debug.Print("Nombre: " & _ParametroComand.ParameterName)
                        Debug.Print("Valor: " & _ParametroComand.Value)
                    Next
                Case GestorDeBaseDeDatos.Oracle
                    Debug.Print("SQL: " & _Comando.CommandText)
                    For Each _ParametroComand As OracleParameter In _Comando.Parameters
                        Debug.Print("Nombre: " & _ParametroComand.ParameterName)
                        Debug.Print("Valor: " & _ParametroComand.Value)
                    Next
            End Select

            _Adaptador.Fill(_DataSet, nombreTabla)
            If contenedor.Tables.Contains(nombreTabla) Then contenedor.Tables(nombreTabla).Clear()

            contenedor.Merge(_DataSet)
            _RegistrosAfectados = contenedor.Tables(nombreTabla).Rows.Count
            _Mensaje = "Operación exitosa: (" & _RegistrosAfectados.ToString & ") registros encontrados."
            Return True
        Catch ex As Exception
            _Mensaje = "Error en operación: " & ex.Message
            Return False
        Finally
            If IsNothing(_Comando.Transaction) Then If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
        End Try
    End Function

    Public Function ObtenerDatos(ByVal SentenciaSQL As String, ByRef Contenedor As IDataReader) As Boolean
        Try
            If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
            _Comando.CommandText = SentenciaSQL
            Contenedor = _Comando.ExecuteReader
            _RegistrosAfectados = Contenedor.RecordsAffected
            _Mensaje = "Operación exitosa: (" & _RegistrosAfectados.ToString & ") registros encontrados."
            Return True
        Catch ex As Exception
            _Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    Public Function ObtenerDatos(ByVal SentenciaSQL As String, ByRef Contenedor As String) As Boolean
        Try
            If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
            _Comando.CommandText = SentenciaSQL
            Contenedor = ""
            Contenedor = CStr(_Comando.ExecuteScalar)
            If Not IsNothing(Contenedor) Then _RegistrosAfectados = 1 Else _RegistrosAfectados = 0
            _Mensaje = "Operación exitosa: (" & _RegistrosAfectados.ToString & ") registros encontrados."
            Return True
        Catch ex As Exception
            _Mensaje = "Error en operación: " & ex.Message
            Return False
        Finally
            If IsNothing(_Comando.Transaction) Then _
                If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
        End Try
    End Function

    Public Sub AsignarCampo(ByVal nombreDelCampo As String, ByVal valor As Object, Optional ByVal esLlavePrimaria As Boolean = False, Optional ByVal esIdentity As Boolean = False, Optional ByVal operador As TipoDeOperadorLogico = TipoDeOperadorLogico.AndOperador, Optional ByVal direccionParametro As System.Data.ParameterDirection = ParameterDirection.InputOutput, Optional esExpresion As Boolean = False)
        Dim TipoParametro As OracleDbType = Nothing
        Try
            Select Case valor.GetType.Name
                Case "String"
                    If valor Is System.DBNull.Value Then
                        valor = "NULL"
                    Else
                        If Not esExpresion Then
                            valor = valor.ToString.Replace("||", "")
                            valor = valor.ToString.Replace("'", "´")
                            'Valor = Valor.ToString.Replace("|", "/")
                            Select Case valor.ToString.Trim.ToUpper
                                Case "SYSDATE", "GETDATE()"
                                    valor = valor.ToString
                                Case Else
                                    'If valor.ToString.Trim.ToUpper.Contains(".NEXTVAL") Or valor.ToString.Trim.ToUpper.Contains("SELECT") Then
                                    If valor.ToString.Trim.ToUpper.Contains(".NEXTVAL") Then
                                        valor = valor.ToString
                                    Else
                                        valor = "'" & valor.ToString & "'"
                                    End If
                            End Select
                        Else
                            'valor = valor.ToString.Replace("||", "")
                            valor = valor.ToString
                        End If
                    End If
                    TipoParametro = DbType.String
                Case "Date"
                    If valor Is System.DBNull.Value Then
                        If _Gestor = GestorDeBaseDeDatos.Oracle Then valor = "NULL"
                    Else
                        If _Gestor = GestorDeBaseDeDatos.Oracle Then
                            valor = "TO_DATE('" & Format(valor, "dd/MM/yyyy").ToString & "', 'DD/MM/YYYY')"
                        Else
                            valor = "'" & Format(valor, "yyyyMMdd").ToString & "'"
                        End If
                    End If
                    TipoParametro = DbType.Date
                Case "DateTime"
                    If valor Is System.DBNull.Value Then
                        If _Gestor = GestorDeBaseDeDatos.Oracle Then valor = "NULL"
                    Else
                        If _UsaParametros Then
                            valor = valor
                        Else
                            If _Gestor = GestorDeBaseDeDatos.Oracle Then
                                valor = "TO_DATE('" & Format(valor, "dd/MM/yyyy HH:mm:ss").ToString & "', 'DD/MM/YYYY HH24:MI:SS')"
                            Else
                                valor = "'" & Format(valor, "yyyyMMdd HH:mm:ss").ToString & "'"
                            End If
                        End If
                    End If
                    TipoParametro = DbType.DateTime
                Case "Boolean"
                    If valor Is System.DBNull.Value Then
                        valor = "0"
                    Else
                        valor = IIf(valor, "1", "0")
                    End If
                    TipoParametro = DbType.Boolean
                Case "Int64"
                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor
                    TipoParametro = DbType.Int64
                Case "Int32"
                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor
                    'If _Gestor = GestorDeBaseDeDatos.Oracle Then
                    '    TipoParametro = OracleDbType.Int32
                    'Else
                    TipoParametro = DbType.Int32
                    'End If
                Case "Int16"
                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor
                    TipoParametro = DbType.Int16
                Case "Double"
                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor
                    TipoParametro = DbType.Double
                Case "Byte[]"
                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor
                    'ParTipoParametro = DbType.Byte
                    TipoParametro = OracleDbType.Blob
                Case Else 'Otros Numericos
                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor
                    TipoParametro = DbType.Int16
            End Select

            If Not esIdentity Then
                _Parametros(_Parametros.Length - 1) = New Parametro(nombreDelCampo, valor, TipoParametro, esLlavePrimaria, esIdentity, operador, direccionParametro)
                ReDim Preserve _Parametros(_Parametros.Length)
            End If
        Catch ex As Exception
            _Mensaje = "Error al asociar campo: " & ex.Message
        End Try
    End Sub

    Public Function EjecutarOperacion(ByVal tipoOperacion As TipoDeOperacion, ByVal nombreDeTabla As String) As Boolean
        Dim _Resultado As Boolean, _CadenaSQL As String
        Try
            _CadenaSQL = ContruirSentenciaSQL(tipoOperacion, nombreDeTabla)
            If _CadenaSQL <> "" Then
                _Resultado = EjecutarSentenciaSQL(tipoOperacion, _CadenaSQL, IIf(tipoOperacion = TipoDeOperacion.EjecutarProcedimientoAlmacenado, True, False))
                Return _Resultado
            Else
                _Mensaje = "Error en operación: No se ha definido una sentencia SQL para ejecutar."
                Return False
            End If
        Catch ex As Exception
            _Mensaje = "Error en operación: " & ex.Message
            Return False
        Finally
            ReDim _Parametros(0)
            _Comando.Parameters.Clear()
        End Try
    End Function

    Protected Friend Function LlenarContenedor(ByRef Contenedor As Object, ByVal FromSQL As String, Optional ByVal SelectSQL As String = "*", Optional ByVal WhereSQL As String = "", Optional ByVal GroupBySQL As String = "", Optional ByVal HavingSQL As String = "", Optional ByVal OrderBySQL As String = "", Optional ByVal CantidadDeRegistros As Integer = 0, Optional ByVal ParIntoFrom As String = "") As Boolean
        Dim _Resultado As Boolean = False, _CadenaSQL As String = "", _Carga_String As String = ""
        _SentenciaSQL = ""
        Try
            _CadenaSQL = "SELECT "
            'Cantida de registros SQL Server
            If _Gestor = GestorDeBaseDeDatos.SQLServer And CantidadDeRegistros > 0 Then _CadenaSQL &= "TOP " & CantidadDeRegistros & " "
            _CadenaSQL &= SelectSQL
            _CadenaSQL &= " FROM " & FromSQL
            _CadenaSQL &= " WHERE (1=1) " & WhereSQL & " "
            'Cantidad de registros Oralce
            If _Gestor = GestorDeBaseDeDatos.Oracle And CantidadDeRegistros > 0 Then _CadenaSQL &= " AND ROWNUM < " & CantidadDeRegistros + 1 & " "
            If GroupBySQL <> "" Then _CadenaSQL &= " GROUP BY " & GroupBySQL
            If HavingSQL <> "" Then _CadenaSQL &= " HAVING " & HavingSQL
            If OrderBySQL <> "" Then _CadenaSQL &= " ORDER BY " & OrderBySQL
            If IsNothing(Contenedor) Then Contenedor = ""
            Select Case Contenedor.GetType.Name
                Case "String"
                    _Resultado = ObtenerDatos(_CadenaSQL, Contenedor)
                Case "DataReader" 'Es un DataReader
                    _Resultado = ObtenerDatos(_CadenaSQL, CType(Contenedor, IDataReader))
                Case "DataTable" 'Es un DataTable
                    _Resultado = ObtenerDatos(_CadenaSQL, CType(Contenedor, DataTable))
                Case Else 'Es un DataSet
                    If Contenedor.GetType.Name = "DataSet" Or UCase(Contenedor.GetType.Name.Substring(0, 3)) = "DTS" Then 'Es un DataSet
                        _Resultado = ObtenerDatos(_CadenaSQL, Contenedor, IIf(ParIntoFrom <> "", ParIntoFrom, FromSQL))
                    Else
                        _Mensaje = "Error en operación: tipo de dato no soportado por el método [LlenarContenedor]."
                        _Resultado = False
                    End If
            End Select
            _SentenciaSQL = _CadenaSQL
            Return _Resultado
        Catch ex As Exception
            _Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    ' Sentencia SELECT
    Public Sub AsignarParametroWhere(ByVal nombre As String, expresion As String, ByVal valor As Object, ByVal operadorLogico As TipoDeOperadorLogico, operadorComparacion As TipoDeOperadorDeComparacion, esExpresion As Boolean, agruparCriteriosApertura As Boolean, agruparCriteriosCierre As Boolean)
        Dim _TipoParametro As DbType = Nothing
        Try
            Select Case valor.GetType.Name
                Case "String"
                    If valor Is System.DBNull.Value Then
                        valor = "NULL"
                    Else
                        If esExpresion Then
                            valor = valor.ToString
                        Else
                            valor = valor.ToString.Replace("'", "´")
                            valor = valor.ToString.Replace("|", "/")
                            valor = "'" & valor.ToString & "'"
                        End If
                    End If
                    _TipoParametro = DbType.String
                Case "Date"
                    If valor Is System.DBNull.Value Then
                        If _Gestor = GestorDeBaseDeDatos.Oracle Then valor = "NULL"
                    Else
                        If _Gestor = GestorDeBaseDeDatos.Oracle Then
                            'valor = "TO_DATE('" & Format(valor, "dd/MM/yyyy").ToString & "', 'DD/MM/YYYY')"
                            valor = CDate(Format(valor, "dd/MM/yyyy").ToString)
                        Else
                            valor = "'" & Format(valor, "yyyyMMdd").ToString & "'"
                        End If
                    End If
                    _TipoParametro = DbType.Date
                Case "DateTime"
                    If valor Is System.DBNull.Value Then
                        If _Gestor = GestorDeBaseDeDatos.Oracle Then valor = "NULL"
                    Else
                        If _UsaParametros Then
                            valor = valor
                        Else
                            If _Gestor = GestorDeBaseDeDatos.Oracle Then
                                'valor = "TO_DATE('" & Format(valor, "dd/MM/yyyy HH:mm:ss").ToString & "', 'DD/MM/YYYY HH24:MI:SS')"
                                valor = CDate(Format(valor, "dd/MM/yyyy HH:mm:ss").ToString)
                            Else
                                valor = "'" & Format(valor, "yyyyMMdd HH:mm:ss").ToString & "'"
                            End If
                        End If
                    End If
                    _TipoParametro = DbType.DateTime
                Case "Boolean"
                    If valor Is System.DBNull.Value Then
                        valor = "0"
                    Else
                        valor = IIf(valor, "1", "0")
                    End If
                    _TipoParametro = DbType.Boolean
                Case "Int64"
                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor
                    _TipoParametro = DbType.Int64
                Case "Int32"
                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor
                    _TipoParametro = DbType.Int32
                Case "Int16"
                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor
                    _TipoParametro = DbType.Int16
                Case "Double", "Decimal"
                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor
                    _TipoParametro = DbType.Double
                Case "Byte[]"
                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor
                    _TipoParametro = OracleDbType.Blob
                Case Else 'Otros Numericos
                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor
                    _TipoParametro = DbType.Int16
            End Select

            If _ParametrosWhere Is Nothing Then _ParametrosWhere = New List(Of Parametro)
            _ParametrosWhere.Add(New Parametro(expresion, nombre, valor, _TipoParametro, operadorLogico, operadorComparacion, esExpresion, agruparCriteriosApertura, agruparCriteriosCierre))
        Catch ex As Exception
            _Mensaje = "Error al asignar parametro a la cláusula [WHERE]: " & ex.Message
        End Try
    End Sub
    Protected Friend Function LlenarContenedor2(ByRef contenedor As Object, selectSQL As String, ByVal fromSQL As String, groupBySQL As String, havingSQL As String, orderBySQL As String, nombreDelContenedor As String) As Boolean
        Dim _Resultado As Boolean = False, _CadenaSQL As String = ""
        _SentenciaSQL = ""
        ' Validar los campos
        _Resultado = True
        If selectSQL.Trim = "" Then _Mensaje = "Debe indicar el valor en el campo [SELECT]." : _Resultado = False
        If fromSQL.Trim = "" Then _Mensaje = "Debe indicar el valor en el campo [FROM]." : _Resultado = False

        If _Resultado Then
            Try
                _CadenaSQL = "SELECT "
                ' Cantidad de registros
                If _CantidadDeRegistros <> 0 And Gestor = GestorDeBaseDeDatos.SQLServer Then
                    _CadenaSQL &= "TOP " & _CantidadDeRegistros & " "
                End If
                ' Campos [SELECT]
                _CadenaSQL &= selectSQL & " "

                ' Tabla(s) [FROM] [JOINS]
                _CadenaSQL &= "FROM " & fromSQL & " "

                ' Crierios [WHERE]
                If Not _ParametrosWhere Is Nothing Then
                    If _ParametrosWhere.Count > 0 Then
                        _CadenaSQL &= "WHERE (1=1) "
                        For Each _Criterio As Parametro In _ParametrosWhere
                            ' [AND / OR] <NOMBRE> [= / > / >= / < / <= / <> / LIKE / REGEXP_LIKE] <VALOR>
                            ' Operador lógico
                            If _Criterio.Nombre <> "" Then
                                Select Case _Criterio.OperadorLogico
                                    Case TipoDeOperadorLogico.AndOperador
                                        _CadenaSQL &= "AND "
                                    Case TipoDeOperadorLogico.OrOperador
                                        _CadenaSQL &= "OR "
                                End Select
                            End If
                            ' Grupos de criterios abrir ( y cerrar)
                            If _Criterio.AgruparCriteriosApertura Then _CadenaSQL &= " ("

                            ' Expresión del criterio
                            If _Criterio.OperadorDeComparacion <> TipoDeOperadorDeComparacion.RegExpLike And _Criterio.OperadorDeComparacion <> TipoDeOperadorDeComparacion.NotRegExpLike Then
                                _CadenaSQL &= _Criterio.Expresion & " "
                            End If

                            If _Criterio.Nombre <> "" Then
                                If _Criterio.EsExpresion = False Then
                                    Select Case _Criterio.OperadorDeComparacion
                                        Case TipoDeOperadorDeComparacion.Igual
                                            _CadenaSQL &= "= " & IIf(Gestor = GestorDeBaseDeDatos.Oracle, ":", "@") & _Criterio.Nombre & " "
                                        Case TipoDeOperadorDeComparacion.Mayor
                                            _CadenaSQL &= "> " & IIf(Gestor = GestorDeBaseDeDatos.Oracle, ":", "@") & _Criterio.Nombre & " "
                                        Case TipoDeOperadorDeComparacion.MayorIgual
                                            _CadenaSQL &= ">= " & IIf(Gestor = GestorDeBaseDeDatos.Oracle, ":", "@") & _Criterio.Nombre & " "
                                        Case TipoDeOperadorDeComparacion.Menor
                                            _CadenaSQL &= "< " & IIf(Gestor = GestorDeBaseDeDatos.Oracle, ":", "@") & _Criterio.Nombre & " "
                                        Case TipoDeOperadorDeComparacion.MenorIgual
                                            _CadenaSQL &= "<= " & IIf(Gestor = GestorDeBaseDeDatos.Oracle, ":", "@") & _Criterio.Nombre & " "
                                        Case TipoDeOperadorDeComparacion.Diferente
                                            _CadenaSQL &= "<> " & IIf(Gestor = GestorDeBaseDeDatos.Oracle, ":", "@") & _Criterio.Nombre & " "
                                        Case TipoDeOperadorDeComparacion.LikeOperador, TipoDeOperadorDeComparacion.LikeIzquierdoOperador, TipoDeOperadorDeComparacion.LikeDerechoOperador, TipoDeOperadorDeComparacion.NotLikeOperador, TipoDeOperadorDeComparacion.NotLikeIzquierdoOperador, TipoDeOperadorDeComparacion.NotLikeDerechoOperador
                                            Select Case Gestor
                                                Case GestorDeBaseDeDatos.Oracle
                                                    Select Case _Criterio.OperadorDeComparacion
                                                        Case TipoDeOperadorDeComparacion.LikeOperador
                                                            _CadenaSQL &= "LIKE '%'" & "|| :" & _Criterio.Nombre & " || " & "'%' "
                                                        Case TipoDeOperadorDeComparacion.LikeIzquierdoOperador
                                                            _CadenaSQL &= "LIKE '%'" & "|| :" & _Criterio.Nombre & " || " & "'' "
                                                        Case TipoDeOperadorDeComparacion.LikeDerechoOperador
                                                            _CadenaSQL &= "LIKE ''" & "|| :" & _Criterio.Nombre & " || " & "'%' "

                                                        Case TipoDeOperadorDeComparacion.NotLikeOperador
                                                            _CadenaSQL &= "NOT LIKE '%'" & "|| :" & _Criterio.Nombre & " || " & "'%' "
                                                        Case TipoDeOperadorDeComparacion.NotLikeIzquierdoOperador
                                                            _CadenaSQL &= "NOT LIKE '%'" & "|| :" & _Criterio.Nombre & " || " & "'' "
                                                        Case TipoDeOperadorDeComparacion.NotLikeDerechoOperador
                                                            _CadenaSQL &= "NOT LIKE ''" & "|| :" & _Criterio.Nombre & " || " & "'%' "
                                                    End Select
                                                Case GestorDeBaseDeDatos.SQLServer
                                                    Select Case _Criterio.OperadorDeComparacion
                                                        Case TipoDeOperadorDeComparacion.LikeOperador
                                                            _CadenaSQL &= "LIKE '%'" & "+ @" & _Criterio.Nombre & " + " & "'%' "
                                                        Case TipoDeOperadorDeComparacion.LikeIzquierdoOperador
                                                            _CadenaSQL &= "LIKE '%'" & "+ @" & _Criterio.Nombre & " + " & "'' "
                                                        Case TipoDeOperadorDeComparacion.LikeDerechoOperador
                                                            _CadenaSQL &= "LIKE ''" & "+ @" & _Criterio.Nombre & " + " & "'%' "

                                                        Case TipoDeOperadorDeComparacion.NotLikeOperador
                                                            _CadenaSQL &= "NOT LIKE '%'" & "+ @" & _Criterio.Nombre & " + " & "'%' "
                                                        Case TipoDeOperadorDeComparacion.NotLikeIzquierdoOperador
                                                            _CadenaSQL &= "NOT LIKE '%'" & "+ @" & _Criterio.Nombre & " + " & "'' "
                                                        Case TipoDeOperadorDeComparacion.NotLikeDerechoOperador
                                                            _CadenaSQL &= "NOT LIKE ''" & "+ @" & _Criterio.Nombre & " + " & "'%' "
                                                    End Select
                                            End Select
                                        Case TipoDeOperadorDeComparacion.InOperador
                                            Select Case Gestor
                                                Case GestorDeBaseDeDatos.Oracle
                                                    _CadenaSQL &= "IN (" & _Criterio.Valor & ") "
                                                Case GestorDeBaseDeDatos.SQLServer
                                                    _CadenaSQL &= "IN (" & _Criterio.Valor & ") "
                                            End Select
                                        Case TipoDeOperadorDeComparacion.NotInOperador
                                            _CadenaSQL &= "NOT IN (" & _Criterio.Valor & ") "
                                        Case TipoDeOperadorDeComparacion.IsOperador
                                            _CadenaSQL &= "IS " & _Criterio.Valor & " "
                                        Case TipoDeOperadorDeComparacion.RegExpLike
                                            _CadenaSQL &= "REGEXP_LIKE (" & _Criterio.Expresion & ", " & _Criterio.Valor & ")"
                                        Case TipoDeOperadorDeComparacion.NotRegExpLike
                                            _CadenaSQL &= "NOT REGEXP_LIKE (" & _Criterio.Expresion & ", " & _Criterio.Valor & ")"
                                    End Select
                                Else
                                    Select Case _Criterio.OperadorDeComparacion
                                        Case TipoDeOperadorDeComparacion.Igual
                                            _CadenaSQL &= "= " & _Criterio.Valor & " "
                                        Case TipoDeOperadorDeComparacion.Mayor
                                            _CadenaSQL &= "> " & _Criterio.Valor & " "
                                        Case TipoDeOperadorDeComparacion.MayorIgual
                                            _CadenaSQL &= ">= " & _Criterio.Valor & " "
                                        Case TipoDeOperadorDeComparacion.Menor
                                            _CadenaSQL &= "< " & _Criterio.Valor & " "
                                        Case TipoDeOperadorDeComparacion.MenorIgual
                                            _CadenaSQL &= "<= " & _Criterio.Valor & " "
                                        Case TipoDeOperadorDeComparacion.Diferente
                                            _CadenaSQL &= "<> " & _Criterio.Valor & " "
                                        Case TipoDeOperadorDeComparacion.LikeOperador, TipoDeOperadorDeComparacion.LikeIzquierdoOperador, TipoDeOperadorDeComparacion.LikeDerechoOperador, TipoDeOperadorDeComparacion.NotLikeOperador, TipoDeOperadorDeComparacion.NotLikeIzquierdoOperador, TipoDeOperadorDeComparacion.NotLikeDerechoOperador, TipoDeOperadorDeComparacion.RegExpLike, TipoDeOperadorDeComparacion.NotRegExpLike
                                            Select Case Gestor
                                                Case GestorDeBaseDeDatos.Oracle
                                                    Select Case _Criterio.OperadorDeComparacion
                                                        Case TipoDeOperadorDeComparacion.LikeOperador
                                                            _CadenaSQL &= "LIKE '%" & _Criterio.Valor & "%' "
                                                        Case TipoDeOperadorDeComparacion.LikeIzquierdoOperador
                                                            _CadenaSQL &= "LIKE '%" & _Criterio.Valor & "' "
                                                        Case TipoDeOperadorDeComparacion.LikeDerechoOperador
                                                            _CadenaSQL &= "LIKE '" & _Criterio.Valor & "%' "

                                                        Case TipoDeOperadorDeComparacion.NotLikeOperador
                                                            _CadenaSQL &= "NOT LIKE '%" & _Criterio.Valor & "%' "
                                                        Case TipoDeOperadorDeComparacion.NotLikeIzquierdoOperador
                                                            _CadenaSQL &= "NOT LIKE '%" & _Criterio.Valor & "' "
                                                        Case TipoDeOperadorDeComparacion.NotLikeDerechoOperador
                                                            _CadenaSQL &= "NOT LIKE '" & _Criterio.Valor & "%' "
                                                    End Select
                                                Case GestorDeBaseDeDatos.SQLServer
                                                    Select Case _Criterio.OperadorDeComparacion
                                                        Case TipoDeOperadorDeComparacion.LikeOperador
                                                            _CadenaSQL &= "LIKE '%" & _Criterio.Valor & "'%' "
                                                        Case TipoDeOperadorDeComparacion.LikeIzquierdoOperador
                                                            _CadenaSQL &= "LIKE '%" & _Criterio.Valor & "'' "
                                                        Case TipoDeOperadorDeComparacion.LikeDerechoOperador
                                                            _CadenaSQL &= "LIKE '" & _Criterio.Valor & "'%' "

                                                        Case TipoDeOperadorDeComparacion.NotLikeOperador
                                                            _CadenaSQL &= "NOT LIKE '%" & _Criterio.Valor & "%' "
                                                        Case TipoDeOperadorDeComparacion.NotLikeIzquierdoOperador
                                                            _CadenaSQL &= "NOT LIKE '%" & _Criterio.Valor & "' "
                                                        Case TipoDeOperadorDeComparacion.NotLikeDerechoOperador
                                                            _CadenaSQL &= "NOT LIKE '" & _Criterio.Valor & "%' "
                                                    End Select
                                            End Select
                                        Case TipoDeOperadorDeComparacion.InOperador
                                            _CadenaSQL &= "IN (" & _Criterio.Valor & ") "
                                        Case TipoDeOperadorDeComparacion.NotInOperador
                                            _CadenaSQL &= "NOT IN (" & _Criterio.Valor & ") "
                                        Case TipoDeOperadorDeComparacion.IsOperador
                                            _CadenaSQL &= "IS " & _Criterio.Valor & " "
                                        Case TipoDeOperadorDeComparacion.RegExpLike
                                            _CadenaSQL &= "REGEXP_LIKE (" & _Criterio.Expresion & ", '" & _Criterio.Valor & "')"
                                        Case TipoDeOperadorDeComparacion.NotRegExpLike
                                            _CadenaSQL &= "NOT REGEXP_LIKE (" & _Criterio.Expresion & ", '" & _Criterio.Valor & "')"
                                    End Select
                                End If
                            End If
                            ' Grupos de criterios abrir ( y cerrar)
                            If _Criterio.AgruparCriteriosCierre Then _CadenaSQL &= ") "
                        Next
                    End If
                End If

                ' Grupos [GROUP BY]
                If groupBySQL.Trim <> "" Then
                    _CadenaSQL &= "GROUP BY " & groupBySQL & " "
                End If

                ' Having [HAVING]
                If havingSQL.Trim <> "" Then
                    _CadenaSQL &= "HAVING " & havingSQL & " "
                End If

                ' Ordenamiento [ORDER BY]
                If orderBySQL.Trim <> "" Then
                    _CadenaSQL &= "ORDER BY " & orderBySQL & " "
                End If

                ' Contenedor [String, DataTable, DataSet]
                If IsNothing(contenedor) Then contenedor = ""
                Select Case contenedor.GetType.Name
                    Case "String"
                        _Resultado = ObtenerDatos2(_CadenaSQL, contenedor)
                    Case "DataTable" 'Es un DataTable
                        _Resultado = ObtenerDatos2(_CadenaSQL, CType(contenedor, DataTable))
                    Case Else 'Es un DataSet
                        If contenedor.GetType.Name = "DataSet" Or UCase(contenedor.GetType.Name.Substring(0, 3)) = "DTS" Then
                            '_Resultado = ObtenerDatos2(_CadenaSQL, contenedor, fromSQL)
                            _Resultado = ObtenerDatos2(_CadenaSQL, contenedor, IIf(nombreDelContenedor <> "", nombreDelContenedor, fromSQL))
                        Else
                            _Mensaje = "Error en operación: tipo de contenedor no soportado por el método [LlenarContenedor2]."
                            _Resultado = False
                        End If
                End Select
                _SentenciaSQL = _CadenaSQL

                _ParametrosWhere = Nothing
                _Comando.Parameters.Clear()
                Return _Resultado
            Catch ex As Exception
                _Mensaje = "Error en operación: " & ex.Message
                Return False
            End Try
        Else
            Return False
        End If
    End Function
#End Region

#Region "Metodos Privados"
    Private Function ContruirSentenciaSQL(ByVal ParTipoOperacion As TipoDeOperacion, ByVal FromSQL As String) As String
        Dim _CadenaSQL As String = ""
        Try
            If (ParTipoOperacion = TipoDeOperacion.Agregar Or ParTipoOperacion = TipoDeOperacion.Modificar) And _Parametros.Length <= 0 Then
                _Mensaje = "Error al generar instrucción SQL: La instrucción no contiene parametros."
                Return ""
            End If
            Select Case ParTipoOperacion
                Case TipoDeOperacion.Agregar
                    _CadenaSQL = "INSERT INTO " & FromSQL & " ("
                    For Each MyPar As Parametro In _Parametros
                        If MyPar Is Nothing Then Exit For
                        If Not MyPar.EsIdentidad Then _CadenaSQL &= MyPar.Nombre & ","
                    Next
                    _CadenaSQL = _CadenaSQL.Remove(_CadenaSQL.Length - 1, 1)
                    _CadenaSQL &= ") VALUES ("
                    For Each MyPar As Parametro In _Parametros
                        If MyPar Is Nothing Then Exit For
                        If Not MyPar.EsIdentidad Then
                            If _UsaParametros Then
                                _CadenaSQL &= IIf(_Gestor = GestorDeBaseDeDatos.Oracle, ":", "?")
                                _CadenaSQL &= MyPar.Nombre & ","
                            Else
                                _CadenaSQL &= MyPar.Valor & ","
                            End If
                        End If
                    Next
                    _CadenaSQL = _CadenaSQL.Remove(_CadenaSQL.Length - 1, 1)
                    _CadenaSQL &= ")"
                Case TipoDeOperacion.Modificar
                    _CadenaSQL = "UPDATE " & FromSQL & " SET "
                    For Each MyPar As Parametro In _Parametros
                        If MyPar Is Nothing Then Exit For
                        If Not (MyPar.EsIdentidad Or MyPar.EsLlavePrimaria) Then
                            If _UsaParametros Then
                                _CadenaSQL &= MyPar.Nombre & " = "
                                _CadenaSQL &= IIf(_Gestor = GestorDeBaseDeDatos.Oracle, ":", "?")
                                _CadenaSQL &= MyPar.Nombre & ","
                            Else
                                _CadenaSQL &= MyPar.Nombre & " = " & MyPar.Valor & ","
                            End If
                        End If
                    Next
                    _CadenaSQL = _CadenaSQL.Remove(_CadenaSQL.Length - 1, 1)
                    _CadenaSQL &= " WHERE (1=1) "
                    For Each MyPar As Parametro In _Parametros
                        If MyPar Is Nothing Then Exit For
                        If MyPar.EsLlavePrimaria Then
                            If MyPar.OperadorLogico = TipoDeOperadorLogico.AndOperador Then
                                _CadenaSQL &= " AND "
                            ElseIf MyPar.OperadorLogico = TipoDeOperadorLogico.OrOperador Then
                                _CadenaSQL &= " OR "
                            End If
                            If _UsaParametros Then
                                _CadenaSQL &= MyPar.Nombre & " = "
                                _CadenaSQL &= IIf(_Gestor = GestorDeBaseDeDatos.Oracle, ":", "?")
                                _CadenaSQL &= MyPar.Nombre & " "
                            Else
                                If MyPar.Valor.ToString = "NULL" Then
                                    _CadenaSQL &= MyPar.Nombre & " IS " & MyPar.Valor & " "
                                Else
                                    _CadenaSQL &= MyPar.Nombre & " = " & MyPar.Valor & " "
                                End If
                            End If
                        End If
                    Next
                    _CadenaSQL = _CadenaSQL.Remove(_CadenaSQL.Length - 1, 1)
                Case TipoDeOperacion.Eliminar
                    _CadenaSQL = "DELETE FROM " & FromSQL & " WHERE (1=1) "
                    For Each MyPar As Parametro In _Parametros
                        If MyPar Is Nothing Then Exit For
                        If MyPar.EsLlavePrimaria Then
                            If MyPar.OperadorLogico = TipoDeOperadorLogico.AndOperador Then
                                _CadenaSQL &= " AND "
                            ElseIf MyPar.OperadorLogico = TipoDeOperadorLogico.OrOperador Then
                                _CadenaSQL &= " OR "
                            End If
                            If _UsaParametros Then
                                _CadenaSQL &= MyPar.Nombre & " = "
                                _CadenaSQL &= IIf(_Gestor = GestorDeBaseDeDatos.Oracle, ":", "?")
                                _CadenaSQL &= MyPar.Nombre & " "
                            Else
                                If MyPar.Valor.ToString = "NULL" Then
                                    _CadenaSQL &= MyPar.Nombre & " IS " & MyPar.Valor & " "
                                Else
                                    _CadenaSQL &= MyPar.Nombre & " = " & MyPar.Valor & " "
                                End If
                            End If
                        End If
                    Next
                    _CadenaSQL = _CadenaSQL.Remove(_CadenaSQL.Length - 1, 1)
                Case TipoDeOperacion.EjecutarProcedimientoAlmacenado
                    _CadenaSQL = FromSQL
            End Select
            _SentenciaSQL = _CadenaSQL
            Return _CadenaSQL
        Catch ex As Exception
            _Mensaje = "Error al generar instrucción SQL: " & ex.Message
            Return ""
        End Try
    End Function

    Private Function EjecutarSentenciaSQL(ByVal ParTipoOperacion As TipoDeOperacion, ByVal ParCadenaSQL As String, ByVal ParSinConteo As Boolean) As Boolean
        Try
            If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
            If ParTipoOperacion = TipoDeOperacion.EjecutarProcedimientoAlmacenado Then
                _Comando.CommandType = CommandType.StoredProcedure
            Else
                _Comando.CommandType = CommandType.Text
            End If
            _Comando.CommandText = ParCadenaSQL
            If _UsaParametros Then
                For Each _ParametroDeReporte As Parametro In _Parametros
                    Select Case _Gestor
                        Case GestorDeBaseDeDatos.SQLServer
                            _Parametro = New SqlClient.SqlParameter
                        Case GestorDeBaseDeDatos.Oracle
                            _Parametro = New OracleParameter
                    End Select
                    If _ParametroDeReporte Is Nothing Then Exit For
                    Select Case ParTipoOperacion
                        Case TipoDeOperacion.Agregar, TipoDeOperacion.Modificar, TipoDeOperacion.EjecutarProcedimientoAlmacenado
                            If Not _ParametroDeReporte.EsIdentidad Then
                                _Parametro.ParameterName = _ParametroDeReporte.Nombre
                                '_Parametro.Value = _ParametroDeReporte.Valor.ToString.Replace("'", "")
                                'If _Gestor = GestorDeBaseDeDatos.Oracle Then                                    
                                '    _Parametro.DbType = _ParametroDeReporte.TipoParametro
                                'Else
                                '    _Parametro.DbType = _ParametroDeReporte.TipoParametro
                                'End If
                                Select Case _ParametroDeReporte.TipoDeParametro
                                    Case OracleDbType.Blob
                                        _Parametro.Value = _ParametroDeReporte.Valor
                                        'Cambio hecho por Héctor Ac el dia 06/02/2017
                                        _Parametro.OracleDbType = OracleDbType.Blob
                                    Case OracleDbType.Varchar2, OracleDbType.NVarchar2, DbType.String
                                        _Parametro.Value = _ParametroDeReporte.Valor.ToString.Replace("'", "")
                                        _Parametro.DbType = _ParametroDeReporte.TipoDeParametro
                                    Case Else
                                        _Parametro.Value = _ParametroDeReporte.Valor
                                        'If _Gestor = GestorDeBaseDeDatos.Oracle Then
                                        '_Parametro.OracleDbType = _ParametroDeReporte.TipoDeParametro
                                        'Else
                                        _Parametro.DbType = _ParametroDeReporte.TipoDeParametro
                                        'End If
                                End Select
                                _Parametro.Direction = _ParametroDeReporte.DireccionDelParametro
                                _Comando.Parameters.Add(_Parametro)
                                _Parametro = Nothing
                            End If
                        Case TipoDeOperacion.Eliminar
                            If Not _ParametroDeReporte.EsIdentidad And _ParametroDeReporte.EsLlavePrimaria Then
                                _Parametro.ParameterName = _ParametroDeReporte.Nombre
                                _Parametro.Value = _ParametroDeReporte.Valor.ToString.Replace("'", "")
                                _Parametro.DbType = _ParametroDeReporte.TipoDeParametro
                                _Parametro.Direction = _ParametroDeReporte.DireccionDelParametro
                                _Comando.Parameters.Add(_Parametro)
                                _Parametro = Nothing
                            End If
                    End Select
                Next
            End If

            ' Listar los parametros
            Select Case _Gestor
                Case GestorDeBaseDeDatos.SQLServer
                    Debug.Print("SQL: " & _Comando.CommandText)
                    For Each _ParametroComand As SqlClient.SqlParameter In _Comando.Parameters
                        Debug.Print("Nombre: " & _ParametroComand.ParameterName)
                        Debug.Print("Valor: " & _ParametroComand.Value)
                    Next
                Case GestorDeBaseDeDatos.Oracle
                    Debug.Print("SQL: " & _Comando.CommandText)
                    For Each _ParametroComand As OracleParameter In _Comando.Parameters
                        Debug.Print("Nombre: " & _ParametroComand.ParameterName)
                        Debug.Print("Valor: " & _ParametroComand.Value.ToString)
                    Next
            End Select

            If ParTipoOperacion = TipoDeOperacion.EjecutarProcedimientoAlmacenado Then
                _Comando.ExecuteReader()
                _RegistrosAfectados = 1
            Else
                _RegistrosAfectados = _Comando.ExecuteNonQuery()
            End If

            If _RegistrosAfectados > 0 Or ParSinConteo Then
                _Mensaje = "Operación exitosa: (" & _RegistrosAfectados.ToString & ") registros aplicados."
                Return True
            Else
                _Mensaje = "Error en operación: (0) registros aplicados."
                Return False
            End If
        Catch ex As Exception
            _Mensaje = "Error en operación: " & ex.Message
            Return False
        Finally
            If IsNothing(_Comando.Transaction) Then If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
        End Try
    End Function
#End Region
End Class
