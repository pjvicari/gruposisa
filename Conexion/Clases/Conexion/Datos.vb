Public Class Datos
    '#Region "Propiedades"
    '    Private _CantidadDeRegistros As Integer = 0
    '    Public Property CantidadDeRegistros() As Integer
    '        Get
    '            Return _CantidadDeRegistros
    '        End Get
    '        Set(ByVal value As Integer)
    '            _CantidadDeRegistros = value
    '        End Set
    '    End Property

    '    Private _Ambiente As AmbienteDeBaseDeDatos
    '    Public ReadOnly Property Ambiente() As AmbienteDeBaseDeDatos
    '        Get
    '            Return _Ambiente
    '        End Get
    '    End Property

    '    Private _AñoDeOperacion As Integer
    '    Public ReadOnly Property AñoDeOperacion() As Integer
    '        Get
    '            Return _AñoDeOperacion
    '        End Get
    '    End Property
    '#End Region

    '#Region "Constructores"
    '    Public Sub New(ByVal gestor As GestorDeBaseDeDatos, esquema As EsquemaDeBaseDeDatos, ByVal añoDeOperacion As Integer, usaParametros As Boolean, ambiente As AmbienteDeBaseDeDatos)
    '        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-GT")
    '        '_Data = New Data_Base(gestor, ConectionString(gestor, esquema, añoDeOperacion, ambiente))
    '        '_Data._UsaParametros = IIf(gestor = GestorDeBaseDeDatos.Oracle, usaParametros, False)

    '        _Ambiente = ambiente
    '        _AñoDeOperacion = añoDeOperacion
    '    End Sub

    '    Public Sub New(ByVal gestor As GestorDeBaseDeDatos, esquema As EsquemaDeBaseDeDatos, ByVal añoDeOperacion As Integer, usaParametros As Boolean)
    '        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-GT")
    '        ' _Data = New Data_Base(gestor, ConectionString(gestor, esquema, añoDeOperacion, AmbienteDeBaseDeDatos.Produccion))
    '        '_Data._UsaParametros = IIf(gestor = GestorDeBaseDeDatos.Oracle, usaParametros, False)

    '        _Ambiente = AmbienteDeBaseDeDatos.Produccion
    '        _AñoDeOperacion = añoDeOperacion
    '    End Sub

    '    Public Sub New(ByVal gestor As GestorDeBaseDeDatos, esquema As EsquemaDeBaseDeDatos, ByVal añoDeOperacion As Integer)
    '        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-GT")
    '        '_Data = New Data_Base(gestor, ConectionString(gestor, esquema, añoDeOperacion, AmbienteDeBaseDeDatos.Produccion))
    '        '_Data._UsaParametros = False

    '        _Ambiente = AmbienteDeBaseDeDatos.Produccion
    '        _AñoDeOperacion = añoDeOperacion
    '    End Sub
    '#End Region

    '#Region "Metodos publicos"
    '#Region "CargarDatos"
    '    'Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String) As Boolean
    '    '    Try
    '    '        Return _Data.LlenarContenedor(Contenedor, FromSQL)
    '    '    Catch ex As Exception
    '    '        _Data.Mensaje = "Error en operación: " & ex.Message
    '    '        Return False
    '    '    End Try
    '    'End Function

    '    'Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal CantidadDeRegistros As Integer) As Boolean
    '    '    Try
    '    '        Return _Data.LlenarContenedor(Contenedor, FromSQL, CantidadDeRegistros)
    '    '    Catch ex As Exception
    '    '        _Data.Mensaje = "Error en operación: " & ex.Message
    '    '        Return False
    '    '    End Try
    '    'End Function

    '    'Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String) As Boolean
    '    '    Try
    '    '        SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
    '    '        Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL)
    '    '    Catch ex As Exception
    '    '        _Data.Mensaje = "Error en operación: " & ex.Message
    '    '        Return False
    '    '    End Try
    '    'End Function

    '    'Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal CantidadDeRegistros As Integer) As Boolean
    '    '    Try
    '    '        SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
    '    '        Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, "", "", "", "", CantidadDeRegistros)
    '    '    Catch ex As Exception
    '    '        _Data.Mensaje = "Error en operación: " & ex.Message
    '    '        Return False
    '    '    End Try
    '    'End Function

    '    'Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String) As Boolean
    '    '    Try
    '    '        SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
    '    '        Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL)
    '    '    Catch ex As Exception
    '    '        _Data.Mensaje = "Error en operación: " & ex.Message
    '    '        Return False
    '    '    End Try
    '    'End Function

    '    'Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal CantidadDeRegistros As Integer) As Boolean
    '    '    Try
    '    '        SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
    '    '        Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, "", "", "", CantidadDeRegistros)
    '    '    Catch ex As Exception
    '    '        _Data.Mensaje = "Error en operación: " & ex.Message
    '    '        Return False
    '    '    End Try
    '    'End Function

    '    'Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal GroupBySQL As String) As Boolean
    '    '    Try
    '    '        SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
    '    '        Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, GroupBySQL)
    '    '    Catch ex As Exception
    '    '        _Data.Mensaje = "Error en operación: " & ex.Message
    '    '        Return False
    '    '    End Try
    '    'End Function

    '    'Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal GroupBySQL As String, ByVal CantidadDeRegistros As Integer) As Boolean
    '    '    Try
    '    '        SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
    '    '        Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, GroupBySQL, CantidadDeRegistros)
    '    '    Catch ex As Exception
    '    '        _Data.Mensaje = "Error en operación: " & ex.Message
    '    '        Return False
    '    '    End Try
    '    'End Function

    '    'Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal GroupBySQL As String, ByVal HavingSQL As String) As Boolean
    '    '    Try
    '    '        SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
    '    '        Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, GroupBySQL, HavingSQL)
    '    '    Catch ex As Exception
    '    '        _Data.Mensaje = "Error en operación: " & ex.Message
    '    '        Return False
    '    '    End Try
    '    'End Function

    '    'Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal GroupBySQL As String, ByVal HavingSQL As String, ByVal CantidadDeRegistros As Integer) As Boolean
    '    '    Try
    '    '        SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
    '    '        Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, GroupBySQL, HavingSQL, "", CantidadDeRegistros)
    '    '    Catch ex As Exception
    '    '        _Data.Mensaje = "Error en operación: " & ex.Message
    '    '        Return False
    '    '    End Try
    '    'End Function

    '    'Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal GroupBySQL As String, ByVal HavingSQL As String, ByVal OrderBySQL As String) As Boolean
    '    '    Try
    '    '        SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
    '    '        Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, GroupBySQL, HavingSQL, OrderBySQL)
    '    '    Catch ex As Exception
    '    '        _Data.Mensaje = "Error en operación: " & ex.Message
    '    '        Return False
    '    '    End Try
    '    'End Function

    '    'Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal GroupBySQL As String, ByVal HavingSQL As String, ByVal OrderBySQL As String, ByVal CantidadDeRegistros As Integer) As Boolean
    '    '    Try
    '    '        SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
    '    '        Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, GroupBySQL, HavingSQL, OrderBySQL, CantidadDeRegistros)
    '    '    Catch ex As Exception
    '    '        _Data.Mensaje = "Error en operación: " & ex.Message
    '    '        Return False
    '    '    End Try
    '    'End Function

    '    'Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal GroupBySQL As String, ByVal HavingSQL As String, ByVal OrderBySQL As String, ByVal CantidadDeRegistros As Integer, ByVal IntoFromSQL As String) As Boolean
    '    '    Try
    '    '        SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
    '    '        Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, GroupBySQL, HavingSQL, OrderBySQL, CantidadDeRegistros, IntoFromSQL)
    '    '    Catch ex As Exception
    '    '        _Data.Mensaje = "Error en operación: " & ex.Message
    '    '        Return False
    '    '    End Try
    '    'End Function
    '#End Region

    '#Region "LlenarCombo"
    '    Public Sub LlenarCombo(ByRef ParDataCombo As Object, ByVal ParTabla As String, ByVal ParLlave As String, ByVal ParNombre As String, Optional ByVal ParCondicion As String = "")
    '        Dim Tabla As New DataTable
    '        Try
    '            'Select_Datos(Tabla, ParTabla, ParLlave & ", " & ParNombre, ParCondicion, "", "", ParNombre & " ASC")
    '            LlenarCombo(ParDataCombo, Tabla, ParLlave, ParNombre)
    '        Catch ex As Exception
    '            '_Data.Mensaje = "Error en Llenar_ComboBox: " & ex.Message
    '        End Try
    '    End Sub
    '    Public Sub LlenarCombo(ByRef ParDataCombo As Object, ByVal ParTabla As String, ByVal ParLlave As String, ByVal ParNombre As String, ByVal ParCondicion As String, ByVal ParOrderBy As String)
    '        Dim Tabla As New DataTable
    '        If ParOrderBy = "" Then ParOrderBy = ParNombre
    '        Try
    '            'Select_Datos(Tabla, ParTabla, ParLlave & ", " & ParNombre, ParCondicion, "", "", ParOrderBy & " ASC")
    '            LlenarCombo(ParDataCombo, Tabla, ParLlave, ParNombre)
    '        Catch ex As Exception
    '            '_Data.Mensaje = "Error en Llenar_ComboBox: " & ex.Message
    '        End Try
    '    End Sub
    '    Public Sub LlenarCombo(ByVal ParDataCombo As Object, ByVal ParOrigenDatos As DataTable, ByVal ParLlave As String, ByVal ParTexto As String, Optional ByVal ParDesplegar As String = "")
    '        Dim Fila As DataRow
    '        Try
    '            Fila = ParOrigenDatos.NewRow
    '            If Fila(ParLlave).GetType.Name = "String" Then
    '                Fila(ParLlave) = ""
    '            Else
    '                Fila(ParLlave) = 0
    '            End If
    '            Fila(ParTexto) = ParDesplegar
    '            ParOrigenDatos.Rows.InsertAt(Fila, 0)
    '            ParDataCombo.DataSource = ParOrigenDatos
    '            If ParDataCombo.GetType.Name.ToString = "ComboBox" Then
    '                ParDataCombo.DisplayMember = ParTexto
    '                ParDataCombo.ValueMember = ParLlave
    '            ElseIf ParDataCombo.GetType.Name.ToString = "DropDownList" Then
    '                ParDataCombo.DataTextField = ParTexto
    '                ParDataCombo.DataValueField = ParLlave
    '                ParDataCombo.DataBind()
    '            Else
    '                ParDataCombo.DisplayMember = ParTexto
    '                ParDataCombo.ValueMember = ParLlave
    '            End If
    '            If ParDataCombo.GetType.Name.ToString = "ComboBox" Then ParDataCombo.SelectedIndex = 0
    '        Catch ex As Exception
    '            Mensaje = "Error en Llenar_ComboBox: " & ex.Message
    '        End Try
    '    End Sub
    '    Public Sub LlenarCombo(ByVal ParDataCombo As Object, ByVal ParOrigenDatos As DataTable, ByVal ParLlave As String, ByVal ParTexto As String, ByVal ParDesplegar As String, ByVal ParLlaveNula As String)
    '        Dim Fila As DataRow
    '        Try
    '            Fila = ParOrigenDatos.NewRow
    '            If Fila(ParLlave).GetType.Name = "String" Then
    '                Fila(ParLlave) = ParLlaveNula.ToString
    '            Else
    '                Fila(ParLlave) = ParLlaveNula
    '            End If
    '            Fila(ParTexto) = ParDesplegar
    '            ParOrigenDatos.Rows.InsertAt(Fila, 0)
    '            ParDataCombo.DataSource = ParOrigenDatos

    '            ParDataCombo.DataSource = ParOrigenDatos
    '            If ParDataCombo.GetType.Name.ToString = "ComboBox" Then
    '                ParDataCombo.DisplayMember = ParTexto
    '                ParDataCombo.ValueMember = ParLlave
    '            ElseIf ParDataCombo.GetType.Name.ToString = "DropDownList" Then
    '                ParDataCombo.DataTextField = ParTexto
    '                ParDataCombo.DataValueField = ParLlave
    '                ParDataCombo.DataBind()
    '            Else
    '                ParDataCombo.DisplayMember = ParTexto
    '                ParDataCombo.ValueMember = ParLlave
    '            End If

    '            If ParDataCombo.GetType.Name.ToString = "ComboBox" Then ParDataCombo.SelectedIndex = 0
    '        Catch ex As Exception
    '            Mensaje = "Error en Llenar_ComboBox: " & ex.Message
    '        End Try
    '    End Sub
    '#End Region

    '#End Region


    '#Region "Data_Base"
    '#Region "Variables"
    '    Private _Conexion As IDbConnection
    '    Private _Comando As IDbCommand
    '    Private _Transaccion As IDbTransaction
    '    Private _Adaptador As Object
    '    Private _Parametro As Object
    '    Protected Friend _UsaParametros As Boolean
    '    Private _Parametros As List(Of Parametro)
    '#End Region

    '#Region "Propiedades"
    '    Private _Gestor As GestorDeBaseDeDatos
    '    Public ReadOnly Property Gestor() As GestorDeBaseDeDatos
    '        Get
    '            Return _Gestor
    '        End Get
    '    End Property

    '    Private _Mensaje As String
    '    Public Property Mensaje() As String
    '        Set(value As String)
    '            _Mensaje = value
    '        End Set
    '        Get
    '            Return _Mensaje.Replace("'", "")
    '        End Get
    '    End Property

    '    Private _RegistrosAfectados As String
    '    Public ReadOnly Property RegistrosAfectados() As String
    '        Get
    '            Return _RegistrosAfectados
    '        End Get
    '    End Property

    '    Private _SentenciaSQL As String
    '    Public ReadOnly Property SenteciaSQL() As String
    '        Get
    '            Return _SentenciaSQL
    '        End Get
    '    End Property

    '    Private _NumeroDeRegistros As Integer
    '    Public Property NumeroDeRegistros() As Integer
    '        Get
    '            Return _NumeroDeRegistros
    '        End Get
    '        Set(ByVal value As Integer)
    '            _NumeroDeRegistros = value
    '        End Set
    '    End Property
    '#End Region

    '#Region "Constructores"
    '    Protected Friend Sub New(ByVal gestor As GestorDeBaseDeDatos, ByVal cadenaDeConexion As String)
    '        Try
    '            Select Case gestor
    '                Case GestorDeBaseDeDatos.SQLServer
    '                    _Conexion = New SqlConnection
    '                    _Comando = New SqlCommand
    '                    _Adaptador = New SqlDataAdapter
    '                    _Parametro = New SqlParameter
    '                Case GestorDeBaseDeDatos.Oracle
    '                    _Conexion = New OracleClient.OracleConnection
    '                    _Comando = New OracleClient.OracleCommand
    '                    _Adaptador = New OracleClient.OracleDataAdapter
    '                    _Parametro = New OracleClient.OracleParameter
    '            End Select
    '            _Conexion.ConnectionString = cadenaDeConexion
    '            _Comando.Connection = _Conexion
    '            _Mensaje = ""
    '            _Gestor = gestor
    '            _Parametros = New List(Of Parametro)
    '        Catch ex As Exception
    '            _Mensaje = "Error en operación: " & ex.Message
    '        End Try
    '    End Sub
    '#End Region

    '#Region "Metodos Publicos"
    '    Public Sub IniciarTransaction()
    '        If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
    '        _Transaccion = _Conexion.BeginTransaction()
    '        _Comando.Transaction = _Transaccion
    '    End Sub

    '    Public Sub ConfirmarTransaction()
    '        _Transaccion.Commit()
    '        If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
    '    End Sub

    '    Public Sub ReversarTransaction()
    '        _Transaccion.Rollback()
    '        If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
    '    End Sub

    '    Public Function ObtenerDatos(ByVal SentenciaSQL As String, ByRef Contenedor As DataSet, ByVal Tabla As String) As Boolean
    '        Dim _DataSet As New DataSet
    '        Try
    '            If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
    '            _Comando.CommandText = SentenciaSQL
    '            _Adaptador.SelectCommand = _Comando
    '            _Adaptador.Fill(_DataSet, Tabla)
    '            If Contenedor.Tables.Contains(Tabla) Then
    '                Contenedor.Tables(Tabla).Clear()
    '            End If
    '            Contenedor.Merge(_DataSet)
    '            _RegistrosAfectados = Contenedor.Tables(Tabla).Rows.Count
    '            _Mensaje = "Operación exitosa: (" & _RegistrosAfectados.ToString & ") registros encontrados."
    '            Return True
    '        Catch ex As Exception
    '            _Mensaje = "Error en operación: " & ex.Message
    '            Return False
    '        Finally
    '            If IsNothing(_Comando.Transaction) Then If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
    '        End Try
    '    End Function

    '    Public Function ObtenerDatos(ByVal SentenciaSQL As String, ByRef Contenedor As DataTable) As Boolean
    '        Try
    '            If _Gestor <> GestorDeBaseDeDatos.Excel Then
    '                If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
    '            End If
    '            _Comando.CommandText = SentenciaSQL
    '            _Adaptador.SelectCommand = _Comando
    '            Contenedor.Clear()
    '            _Adaptador.Fill(Contenedor)
    '            _RegistrosAfectados = Contenedor.Rows.Count
    '            _Mensaje = "Operación exitosa: (" & _RegistrosAfectados.ToString & ") registros encontrados."
    '            Return True
    '        Catch ex As Exception
    '            _Mensaje = "Error en operación: " & ex.Message
    '            Return False
    '        Finally
    '            If IsNothing(_Comando.Transaction) Then If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
    '        End Try
    '    End Function

    '    Public Function ObtenerDatos(ByVal SentenciaSQL As String, ByRef Contenedor As IDataReader) As Boolean
    '        Try
    '            If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
    '            _Comando.CommandText = SentenciaSQL
    '            Contenedor = _Comando.ExecuteReader
    '            _RegistrosAfectados = Contenedor.RecordsAffected
    '            _Mensaje = "Operación exitosa: (" & _RegistrosAfectados.ToString & ") registros encontrados."
    '            Return True
    '        Catch ex As Exception
    '            _Mensaje = "Error en operación: " & ex.Message
    '            Return False
    '        End Try
    '    End Function

    '    Public Function ObtenerDatos(ByVal SentenciaSQL As String, ByRef Contenedor As String) As Boolean
    '        Try
    '            If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
    '            _Comando.CommandText = SentenciaSQL
    '            Contenedor = ""
    '            Contenedor = CStr(_Comando.ExecuteScalar)
    '            If Not IsNothing(Contenedor) Then _RegistrosAfectados = 1 Else _RegistrosAfectados = 0
    '            _Mensaje = "Operación exitosa: (" & _RegistrosAfectados.ToString & ") registros encontrados."
    '            Return True
    '        Catch ex As Exception
    '            _Mensaje = "Error en operación: " & ex.Message
    '            Return False
    '        Finally
    '            If IsNothing(_Comando.Transaction) Then _
    '                If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
    '        End Try
    '    End Function

    '    Public Sub AsignarCampo(ByVal nombreDelCampo As String, ByVal valor As Object, ByVal esLlavePrimaria As Boolean, ByVal esIdentidad As Boolean, ByVal operadorLogico As TipoDeOperadorLogico, direccionDelParametro As System.Data.ParameterDirection)
    '        Dim _TipoParametro As DbType
    '        Select Case Gestor
    '            Case GestorDeBaseDeDatos.Oracle
    '                _TipoParametro = New OracleType            
    '            Case Else
    '                _TipoParametro = New DbType
    '        End Select

    '        Try
    '            Select Case valor.GetType.Name
    '                Case "String"
    '                    If valor Is System.DBNull.Value Then
    '                        valor = "NULL"
    '                    Else
    '                        If valor.ToString.Contains("||") Then
    '                            valor = valor.ToString.Replace("||", "")
    '                        Else
    '                            valor = "'" & valor.ToString.Replace("'", "´") & "'"
    '                        End If
    '                    End If
    '                    _TipoParametro = DbType.String
    '                    Select Case Gestor
    '                        Case GestorDeBaseDeDatos.Oracle
    '                            _TipoParametro = OracleType.VarChar
    '                        Case Else
    '                            _TipoParametro = DbType.String
    '                    End Select
    '                Case "Date"
    '                    If valor Is System.DBNull.Value Then
    '                        If _Gestor = GestorDeBaseDeDatos.Oracle Then valor = "NULL"
    '                    Else
    '                        If _Gestor = GestorDeBaseDeDatos.Oracle Then
    '                            valor = "TO_DATE('" & Format(valor, "dd/MM/yyyy").ToString & "', 'DD/MM/YYYY')"
    '                        Else
    '                            valor = "'" & Format(valor, "yyyyMMdd").ToString & "'"
    '                        End If
    '                    End If                    
    '                    Select Case Gestor
    '                        Case GestorDeBaseDeDatos.Oracle
    '                            _TipoParametro = OracleType.DateTime
    '                        Case Else
    '                            _TipoParametro = DbType.Date
    '                    End Select
    '                Case "DateTime"
    '                    If valor Is System.DBNull.Value Then
    '                        If _Gestor = GestorDeBaseDeDatos.Oracle Then valor = "NULL"
    '                    Else
    '                        If _UsaParametros Then
    '                            valor = valor
    '                        Else
    '                            If _Gestor = GestorDeBaseDeDatos.Oracle Then
    '                                valor = "TO_DATE('" & Format(valor, "dd/MM/yyyy HH:mm:ss").ToString & "', 'DD/MM/YYYY HH24:MI:SS')"
    '                            Else
    '                                valor = "'" & Format(valor, "yyyyMMdd HH:mm:ss").ToString & "'"
    '                            End If
    '                        End If
    '                    End If

    '                    Select Case Gestor
    '                        Case GestorDeBaseDeDatos.Oracle
    '                            _TipoParametro = OracleType.DateTime
    '                        Case Else
    '                            _TipoParametro = DbType.DateTime
    '                    End Select
    '                Case "Boolean"
    '                    If valor Is System.DBNull.Value Then
    '                        valor = "0"
    '                    Else
    '                        valor = IIf(valor, "1", "0")
    '                    End If

    '                    Select Case Gestor
    '                        Case GestorDeBaseDeDatos.Oracle
    '                            _TipoParametro = OracleType.Byte
    '                        Case Else
    '                            _TipoParametro = DbType.Boolean
    '                    End Select
    '                Case "Int64"
    '                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor.ToString

    '                    'TipoParametro = DbType.Int64
    '                    Select Case Gestor
    '                        Case GestorDeBaseDeDatos.Oracle
    '                            _TipoParametro = OracleType.Number
    '                        Case Else
    '                            _TipoParametro = DbType.Int64
    '                    End Select
    '                Case "Int32"
    '                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor.ToString
    '                    'TipoParametro = DbType.Int32
    '                    Select Case Gestor
    '                        Case GestorDeBaseDeDatos.Oracle
    '                            _TipoParametro = OracleType.Int32
    '                        Case Else
    '                            _TipoParametro = DbType.Int32
    '                    End Select
    '                Case "Int16"
    '                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor.ToString

    '                    'TipoParametro = DbType.Int16
    '                    Select Case Gestor
    '                        Case GestorDeBaseDeDatos.Oracle
    '                            _TipoParametro = OracleType.Int16
    '                        Case Else
    '                            _TipoParametro = DbType.Int16
    '                    End Select
    '                Case "Double"
    '                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor.ToString

    '                    'TipoParametro = DbType.Double
    '                    Select Case Gestor
    '                        Case GestorDeBaseDeDatos.Oracle
    '                            _TipoParametro = OracleType.Double
    '                        Case Else
    '                            _TipoParametro = DbType.Double
    '                    End Select
    '                Case "Byte[]"
    '                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor
    '                    'ParTipoParametro = DbType.Byte
    '                    'TipoParametro = OracleType.Blob
    '                    Select Case Gestor
    '                        Case GestorDeBaseDeDatos.Oracle
    '                            _TipoParametro = OracleType.Blob
    '                        Case Else
    '                            _TipoParametro = DbType.Byte
    '                    End Select
    '                Case Else 'Otros Numericos
    '                    If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor.ToString

    '                    'TipoParametro = DbType.Int16
    '                    Select Case Gestor
    '                        Case GestorDeBaseDeDatos.Oracle
    '                            _TipoParametro = OracleType.Int16
    '                        Case Else
    '                            _TipoParametro = DbType.Int16
    '                    End Select
    '            End Select
    '            If Not esIdentidad Then
    '                _Parametros.Add(New Parametro(nombreDelCampo, valor, esLlavePrimaria, esIdentidad, operadorLogico, direccionDelParametro, _TipoParametro))
    '            End If
    '        Catch ex As Exception
    '            _Mensaje = "Error al asociar campo: " & ex.Message
    '        End Try
    '    End Sub

    '    'Public Sub AsignarCampo(ByVal nombreDelCampo As String, ByVal valor As Object, Optional ByVal esLlavePrimaria As Boolean = False, Optional ByVal EsIdentity As Boolean = False, Optional ByVal Operador As TipoDeOperadorLogico = TipoDeOperadorLogico.AndOperador, Optional ByVal DireccionParametro As System.Data.ParameterDirection = ParameterDirection.InputOutput)
    '    '    Dim TipoParametro As DbType = Nothing
    '    '    Try
    '    '        Select Case valor.GetType.Name
    '    '            Case "String"
    '    '                If valor Is System.DBNull.Value Then
    '    '                    valor = "NULL"
    '    '                Else
    '    '                    If valor.ToString.Contains("||") Then
    '    '                        valor = valor.ToString.Replace("||", "")
    '    '                    Else
    '    '                        valor = "'" & valor.ToString.Replace("'", "´") & "'"
    '    '                    End If
    '    '                End If
    '    '                TipoParametro = DbType.String
    '    '            Case "Date"
    '    '                If valor Is System.DBNull.Value Then
    '    '                    If _Gestor = GestorDeBaseDeDatos.Oracle Then valor = "NULL"
    '    '                Else
    '    '                    If _Gestor = GestorDeBaseDeDatos.Oracle Then
    '    '                        valor = "TO_DATE('" & Format(valor, "dd/MM/yyyy").ToString & "', 'DD/MM/YYYY')"
    '    '                    Else
    '    '                        valor = "'" & Format(valor, "yyyyMMdd").ToString & "'"
    '    '                    End If
    '    '                End If
    '    '                TipoParametro = DbType.Date
    '    '            Case "DateTime"
    '    '                If valor Is System.DBNull.Value Then
    '    '                    If _Gestor = GestorDeBaseDeDatos.Oracle Then valor = "NULL"
    '    '                Else
    '    '                    If _UsaParametros Then
    '    '                        valor = valor
    '    '                    Else
    '    '                        If _Gestor = GestorDeBaseDeDatos.Oracle Then
    '    '                            valor = "TO_DATE('" & Format(valor, "dd/MM/yyyy HH:mm:ss").ToString & "', 'DD/MM/YYYY HH24:MI:SS')"
    '    '                        Else
    '    '                            valor = "'" & Format(valor, "yyyyMMdd HH:mm:ss").ToString & "'"
    '    '                        End If
    '    '                    End If
    '    '                End If
    '    '                TipoParametro = DbType.DateTime
    '    '            Case "Boolean"
    '    '                If valor Is System.DBNull.Value Then
    '    '                    valor = "0"
    '    '                Else
    '    '                    valor = IIf(valor, "1", "0")
    '    '                End If
    '    '                TipoParametro = DbType.Boolean
    '    '            Case "Int64"
    '    '                If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor.ToString
    '    '                TipoParametro = DbType.Int64
    '    '            Case "Int32"
    '    '                If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor.ToString
    '    '                TipoParametro = DbType.Int32
    '    '            Case "Int16"
    '    '                If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor.ToString
    '    '                TipoParametro = DbType.Int16
    '    '            Case "Double"
    '    '                If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor.ToString
    '    '                TipoParametro = DbType.Double
    '    '            Case "Byte[]"
    '    '                If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor
    '    '                'ParTipoParametro = DbType.Byte
    '    '                TipoParametro = OracleType.Blob
    '    '            Case Else 'Otros Numericos
    '    '                If valor Is System.DBNull.Value Then valor = "NULL" Else valor = valor.ToString
    '    '                TipoParametro = DbType.Int16
    '    '        End Select
    '    '        If Not EsIdentity Then
    '    '            _Parametros.Add(New Parametro(nombreDelCampo, valor, esLlavePrimaria, EsIdentity, Operador, DireccionParametro, TipoParametro))                
    '    '        End If
    '    '    Catch ex As Exception
    '    '        _Mensaje = "Error al asociar campo: " & ex.Message
    '    '    End Try
    '    'End Sub

    '    Public Function EjecutarOperar(ByVal tipoDeOperacion As TipoDeOperacion, ByVal nombreDeLaTabla As String) As Boolean
    '        Dim _Resultado As Boolean, _CadenaSQL As String
    '        Try
    '            _CadenaSQL = ContruirSentenciaSQL(tipoDeOperacion, nombreDeLaTabla)
    '            If _CadenaSQL <> "" Then
    '                _Resultado = EjecutarSentenciaSQL(tipoDeOperacion, _CadenaSQL, IIf(tipoDeOperacion = tipoDeOperacion.EjecutarProcedimientoAlmacenado, True, False))
    '                Return _Resultado
    '            Else
    '                _Mensaje = "Error en operación: No se ha definido una sentencia SQL para ejecutar."
    '                Return False
    '            End If
    '        Catch ex As Exception
    '            _Mensaje = "Error en operación: " & ex.Message
    '            Return False
    '        Finally
    '            _Parametros = New List(Of Parametro)
    '            _Comando.Parameters.Clear()
    '        End Try
    '    End Function

    '    Protected Friend Function LlenarContenedor(ByRef Contenedor As Object, ByVal FromSQL As String, Optional ByVal SelectSQL As String = "*", Optional ByVal WhereSQL As String = "", Optional ByVal GroupBySQL As String = "", Optional ByVal HavingSQL As String = "", Optional ByVal OrderBySQL As String = "", Optional ByVal CantidadDeRegistros As Integer = 0, Optional ByVal ParIntoFrom As String = "") As Boolean
    '        Dim _Resultado As Boolean = False, _CadenaSQL As String = "", _Carga_String As String = ""
    '        _SentenciaSQL = ""
    '        Try
    '            _CadenaSQL = "SELECT "
    '            'Cantida de registros SQL Server
    '            If _Gestor = GestorDeBaseDeDatos.SQLServer And CantidadDeRegistros > 0 Then _CadenaSQL &= "TOP " & CantidadDeRegistros & " "
    '            _CadenaSQL &= SelectSQL
    '            _CadenaSQL &= " FROM " & FromSQL
    '            _CadenaSQL &= " WHERE (1=1) " & WhereSQL & " "
    '            'Cantidad de registros Oralce
    '            If _Gestor = GestorDeBaseDeDatos.Oracle And CantidadDeRegistros > 0 Then _CadenaSQL &= " AND ROWNUM < " & CantidadDeRegistros + 1 & " "
    '            If GroupBySQL <> "" Then _CadenaSQL &= " GROUP BY " & GroupBySQL
    '            If HavingSQL <> "" Then _CadenaSQL &= " HAVING " & HavingSQL
    '            If OrderBySQL <> "" Then _CadenaSQL &= " ORDER BY " & OrderBySQL
    '            If IsNothing(Contenedor) Then Contenedor = ""
    '            Select Case Contenedor.GetType.Name
    '                Case "String"
    '                    _Resultado = ObtenerDatos(_CadenaSQL, Contenedor)
    '                Case "DataReader" 'Es un DataReader
    '                    _Resultado = ObtenerDatos(_CadenaSQL, CType(Contenedor, IDataReader))
    '                Case "DataTable" 'Es un DataTable
    '                    _Resultado = ObtenerDatos(_CadenaSQL, CType(Contenedor, DataTable))
    '                Case Else 'Es un DataSet
    '                    If Contenedor.GetType.Name = "DataSet" Or UCase(Contenedor.GetType.Name.Substring(0, 3)) = "DTS" Then 'Es un DataSet
    '                        _Resultado = ObtenerDatos(_CadenaSQL, Contenedor, IIf(ParIntoFrom <> "", ParIntoFrom, FromSQL))
    '                    Else
    '                        _Mensaje = "Error en operación: tipo de dato no soportado por el método [Fill]."
    '                        _Resultado = False
    '                    End If
    '            End Select
    '            _SentenciaSQL = _CadenaSQL
    '            Return _Resultado
    '        Catch ex As Exception
    '            _Mensaje = "Error en operación: " & ex.Message
    '            Return False
    '        End Try
    '    End Function
    '#End Region

    '#Region "Metodos Privados"
    '    Private Function ContruirSentenciaSQL(ByVal tipoDeOperacion As TipoDeOperacion, ByVal fromSQL As String) As String
    '        Dim _CadenaSQL As String = ""
    '        Try
    '            If (tipoDeOperacion = tipoDeOperacion.Agregar Or tipoDeOperacion = tipoDeOperacion.Modificar) And _Parametros.Count <= 0 Then
    '                _Mensaje = "Error al generar instrucción SQL: La instrucción no contiene parametros."
    '                Return ""
    '            End If
    '            Select Case tipoDeOperacion
    '                Case tipoDeOperacion.Agregar
    '                    _CadenaSQL = "INSERT INTO " & fromSQL & " ("
    '                    For Each MyPar As Parametro In _Parametros
    '                        If MyPar Is Nothing Then Exit For
    '                        If Not MyPar.EsIdentidad Then _CadenaSQL &= MyPar.Nombre & ","
    '                    Next
    '                    _CadenaSQL = _CadenaSQL.Remove(_CadenaSQL.Length - 1, 1)
    '                    _CadenaSQL &= ") VALUES ("
    '                    For Each MyPar As Parametro In _Parametros
    '                        If MyPar Is Nothing Then Exit For
    '                        If Not MyPar.EsIdentidad Then
    '                            If _UsaParametros Then
    '                                _CadenaSQL &= IIf(_Gestor = GestorDeBaseDeDatos.Oracle, ":", "?")
    '                                _CadenaSQL &= MyPar.Nombre & ","
    '                            Else
    '                                _CadenaSQL &= MyPar.Valor & ","
    '                            End If
    '                        End If
    '                    Next
    '                    _CadenaSQL = _CadenaSQL.Remove(_CadenaSQL.Length - 1, 1)
    '                    _CadenaSQL &= ")"
    '                Case tipoDeOperacion.Modificar
    '                    _CadenaSQL = "UPDATE " & FromSQL & " SET "
    '                    For Each MyPar As Parametro In _Parametros
    '                        If MyPar Is Nothing Then Exit For
    '                        If Not (MyPar.EsIdentidad Or MyPar.EsLlavePrimaria) Then
    '                            If _UsaParametros Then
    '                                _CadenaSQL &= MyPar.Nombre & " = "
    '                                _CadenaSQL &= IIf(_Gestor = GestorDeBaseDeDatos.Oracle, ":", "?")
    '                                _CadenaSQL &= MyPar.Nombre & ","
    '                            Else
    '                                _CadenaSQL &= MyPar.Nombre & " = " & MyPar.Valor & ","
    '                            End If
    '                        End If
    '                    Next
    '                    _CadenaSQL = _CadenaSQL.Remove(_CadenaSQL.Length - 1, 1)
    '                    _CadenaSQL &= " WHERE (1=1) "
    '                    For Each MyPar As Parametro In _Parametros
    '                        If MyPar Is Nothing Then Exit For
    '                        If MyPar.EsLlavePrimaria Then
    '                            If MyPar.OperadorLogico = TipoDeOperadorLogico.AndOperador Then
    '                                _CadenaSQL &= " AND "
    '                            ElseIf MyPar.OperadorLogico = TipoDeOperadorLogico.OrOperador Then
    '                                _CadenaSQL &= " OR "
    '                            End If
    '                            If _UsaParametros Then
    '                                _CadenaSQL &= MyPar.Nombre & " = "
    '                                _CadenaSQL &= IIf(_Gestor = GestorDeBaseDeDatos.Oracle, ":", "?")
    '                                _CadenaSQL &= MyPar.Nombre & " "
    '                            Else
    '                                If MyPar.Valor = "NULL" Then
    '                                    _CadenaSQL &= MyPar.Nombre & " IS " & MyPar.Valor & " "
    '                                Else
    '                                    _CadenaSQL &= MyPar.Nombre & " = " & MyPar.Valor & " "
    '                                End If
    '                            End If
    '                        End If
    '                    Next
    '                    _CadenaSQL = _CadenaSQL.Remove(_CadenaSQL.Length - 1, 1)
    '                Case tipoDeOperacion.Eliminar
    '                    _CadenaSQL = "DELETE FROM " & FromSQL & " WHERE (1=1) "
    '                    For Each p As Parametro In _Parametros
    '                        If p Is Nothing Then Exit For
    '                        If p.EsLlavePrimaria Then
    '                            If p.OperadorLogico = TipoDeOperadorLogico.AndOperador Then
    '                                _CadenaSQL &= " AND "
    '                            ElseIf p.OperadorLogico = TipoDeOperadorLogico.OrOperador Then
    '                                _CadenaSQL &= " OR "
    '                            End If
    '                            If _UsaParametros Then
    '                                _CadenaSQL &= p.Nombre & " = "
    '                                _CadenaSQL &= IIf(_Gestor = GestorDeBaseDeDatos.Oracle, ":", "?")
    '                                _CadenaSQL &= p.Nombre & " "
    '                            Else
    '                                If p.Valor = "NULL" Then
    '                                    _CadenaSQL &= p.Nombre & " IS " & p.Valor & " "
    '                                Else
    '                                    _CadenaSQL &= p.Nombre & " = " & p.Valor & " "
    '                                End If
    '                            End If
    '                        End If
    '                    Next
    '                    _CadenaSQL = _CadenaSQL.Remove(_CadenaSQL.Length - 1, 1)
    '                Case tipoDeOperacion.EjecutarProcedimientoAlmacenado
    '                    _CadenaSQL = FromSQL
    '            End Select
    '            _SentenciaSQL = _CadenaSQL
    '            Return _CadenaSQL
    '        Catch ex As Exception
    '            _Mensaje = "Error al generar instrucción SQL: " & ex.Message
    '            Return ""
    '        End Try
    '    End Function

    '    Private Function EjecutarSentenciaSQL(ByVal tipoDeOperacion As TipoDeOperacion, ByVal cadenaSQL As String, ByVal sinConteo As Boolean) As Boolean
    '        Try
    '            If _Conexion.State = ConnectionState.Closed Then _Conexion.Open()
    '            If tipoDeOperacion = tipoDeOperacion.EjecutarProcedimientoAlmacenado Then
    '                _Comando.CommandType = CommandType.StoredProcedure
    '            Else
    '                _Comando.CommandType = CommandType.Text
    '            End If
    '            _Comando.CommandText = cadenaSQL
    '            If _UsaParametros Then
    '                For Each _ParametroDeReporte As Parametro In _Parametros
    '                    Select Case _Gestor
    '                        Case GestorDeBaseDeDatos.SQLServer
    '                            _Parametro = New SqlClient.SqlParameter
    '                        Case GestorDeBaseDeDatos.Oracle
    '                            _Parametro = New OracleClient.OracleParameter
    '                    End Select
    '                    If _ParametroDeReporte Is Nothing Then Exit For
    '                    Select Case tipoDeOperacion
    '                        Case tipoDeOperacion.Agregar, tipoDeOperacion.Modificar, tipoDeOperacion.EjecutarProcedimientoAlmacenado
    '                            If Not _ParametroDeReporte.EsIdentidad Then
    '                                _Parametro.ParameterName = _ParametroDeReporte.Nombre
    '                                '_Parametro.Value = _ParametroDeReporte.Valor.ToString.Replace("'", "")
    '                                'If _Gestor = GestorDeBaseDeDatos.Oracle Then                                    
    '                                '    _Parametro.DbType = _ParametroDeReporte.TipoParametro
    '                                'Else
    '                                '    _Parametro.DbType = _ParametroDeReporte.TipoParametro
    '                                'End If
    '                                If _ParametroDeReporte.TipoDeParametro <> OracleType.Blob Then
    '                                    _Parametro.Value = _ParametroDeReporte.Valor.ToString.Replace("'", "")
    '                                    _Parametro.DbType = _ParametroDeReporte.TipoDeParametro
    '                                Else
    '                                    _Parametro.Value = _ParametroDeReporte.Valor
    '                                    'Verificar aquí el OracleType                                    
    '                                    _Parametro.OracleType = OracleType.Blob
    '                                End If
    '                                _Parametro.Direction = _ParametroDeReporte.DireccionDelParametro
    '                                _Comando.Parameters.Add(_Parametro)
    '                                _Parametro = Nothing
    '                            End If
    '                        Case tipoDeOperacion.Eliminar
    '                            If Not _ParametroDeReporte.EsIdentidad And _ParametroDeReporte.EsLlavePrimaria Then
    '                                _Parametro.ParameterName = _ParametroDeReporte.Nombre
    '                                _Parametro.Value = _ParametroDeReporte.Valor.ToString.Replace("'", "")
    '                                _Parametro.DbType = _ParametroDeReporte.TipoDeParametro
    '                                _Parametro.Direction = _ParametroDeReporte.DireccionDelParametro
    '                                _Comando.Parameters.Add(_Parametro)
    '                                _Parametro = Nothing
    '                            End If
    '                    End Select

    '                Next
    '            End If
    '            If tipoDeOperacion = tipoDeOperacion.EjecutarProcedimientoAlmacenado Then
    '                _Comando.ExecuteReader()
    '                _RegistrosAfectados = 1
    '            Else
    '                _RegistrosAfectados = _Comando.ExecuteNonQuery()
    '            End If

    '            If _RegistrosAfectados > 0 Or sinConteo Then
    '                _Mensaje = "Operación exitosa: (" & _RegistrosAfectados.ToString & ") registros aplicados."
    '                Return True
    '            Else
    '                _Mensaje = "Error en operación: (0) registros aplicados."
    '                Return False
    '            End If
    '        Catch ex As Exception
    '            _Mensaje = "Error en operación: " & ex.Message
    '            Return False
    '        Finally
    '            If IsNothing(_Comando.Transaction) Then If _Conexion.State = ConnectionState.Open Then _Conexion.Close()
    '        End Try
    '    End Function
    '#End Region
    '#End Region
End Class