Public Class Base
#Region "Propiedades"
    Protected Friend _Data As Data_Base
    Public ReadOnly Property Gestor() As GestorDeBaseDeDatos
        Get
            Return _Data.Gestor
        End Get
    End Property

    Public Property Mensaje() As String
        Set(value As String)
            _Data.Mensaje = value
        End Set
        Get
            Return _Data.Mensaje
        End Get
    End Property

    Private _Ambiente As AmbienteDeBaseDeDatos
    Public ReadOnly Property Ambiente() As AmbienteDeBaseDeDatos
        Get
            Return _Ambiente
        End Get
    End Property

    Private _AñoDeOperacion As Integer
    Public ReadOnly Property AñoDeOperacion() As Integer
        Get
            Return _AñoDeOperacion
        End Get
    End Property
    ' Sentencia SELECT
    Private _CantidadDeRegistros As Integer = 0
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
    Public Sub New(ByVal gestor As GestorDeBaseDeDatos, esquema As EsquemaDeBaseDeDatos, ByVal añoDeOperacion As Integer, usaParametros As Boolean, ambiente As AmbienteDeBaseDeDatos)
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-GT")
        _Data = New Data_Base(gestor, ConectionString(gestor, esquema, añoDeOperacion, ambiente))
        _Data._UsaParametros = IIf(gestor = GestorDeBaseDeDatos.Oracle, usaParametros, False)

        _Ambiente = ambiente
        _AñoDeOperacion = añoDeOperacion
    End Sub

    Public Sub New(ByVal gestor As GestorDeBaseDeDatos, esquema As EsquemaDeBaseDeDatos, ByVal añoDeOperacion As Integer, usaParametros As Boolean)
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-GT")
        _Data = New Data_Base(gestor, ConectionString(gestor, esquema, añoDeOperacion, AmbienteDeBaseDeDatos.Produccion))
        _Data._UsaParametros = IIf(gestor = GestorDeBaseDeDatos.Oracle, usaParametros, False)

        _Ambiente = AmbienteDeBaseDeDatos.Produccion
        _AñoDeOperacion = añoDeOperacion
    End Sub

    Public Sub New(ByVal gestor As GestorDeBaseDeDatos, esquema As EsquemaDeBaseDeDatos, ByVal añoDeOperacion As Integer)
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-GT")
        _Data = New Data_Base(gestor, ConectionString(gestor, esquema, añoDeOperacion, AmbienteDeBaseDeDatos.Produccion))
        _Data._UsaParametros = False

        _Ambiente = AmbienteDeBaseDeDatos.Produccion
        _AñoDeOperacion = añoDeOperacion
    End Sub
#End Region

#Region "Metodos publicos"
#Region "CargarDatos"
    Public Sub AsignarParametroWhere(ByVal nombre As String, ByVal valor As Object, ByVal operadorLogico As TipoDeOperadorLogico, operadorComparacion As TipoDeOperadorDeComparacion, esExpresion As Boolean)
        _Data.AsignarParametroWhere(nombre, nombre, valor, operadorLogico, operadorComparacion, esExpresion, False, False)
    End Sub

    Public Sub AsignarParametroWhere(ByVal nombre As String, ByVal valor As Object, ByVal operadorLogico As TipoDeOperadorLogico, operadorComparacion As TipoDeOperadorDeComparacion, esExpresion As Boolean, agruparCriteriosApertura As Boolean)
        _Data.AsignarParametroWhere(nombre, nombre, valor, operadorLogico, operadorComparacion, esExpresion, agruparCriteriosApertura, False)
    End Sub

    Public Sub AsignarParametroWhere(ByVal nombre As String, ByVal valor As Object, ByVal operadorLogico As TipoDeOperadorLogico, operadorComparacion As TipoDeOperadorDeComparacion, esExpresion As Boolean, agruparCriteriosApertura As Boolean, agruparCriteriosCierre As Boolean)
        _Data.AsignarParametroWhere(nombre, nombre, valor, operadorLogico, operadorComparacion, esExpresion, agruparCriteriosApertura, agruparCriteriosCierre)
    End Sub

    Public Sub AsignarParametroWhere(ByVal nombre As String, expresion As String, ByVal valor As Object, ByVal operadorLogico As TipoDeOperadorLogico, operadorComparacion As TipoDeOperadorDeComparacion, esExpresion As Boolean)
        _Data.AsignarParametroWhere(nombre, expresion, valor, operadorLogico, operadorComparacion, esExpresion, False, False)
    End Sub

    Public Sub AsignarParametroWhere(ByVal nombre As String, expresion As String, ByVal valor As Object, ByVal operadorLogico As TipoDeOperadorLogico, operadorComparacion As TipoDeOperadorDeComparacion, esExpresion As Boolean, agruparCriteriosApertura As Boolean)
        _Data.AsignarParametroWhere(nombre, expresion, valor, operadorLogico, operadorComparacion, esExpresion, agruparCriteriosApertura, False)
    End Sub

    Public Sub AsignarParametroWhere(ByVal nombre As String, expresion As String, ByVal valor As Object, ByVal operadorLogico As TipoDeOperadorLogico, operadorComparacion As TipoDeOperadorDeComparacion, esExpresion As Boolean, agruparCriteriosApertura As Boolean, agruparCriteriosCierre As Boolean)
        _Data.AsignarParametroWhere(nombre, expresion, valor, operadorLogico, operadorComparacion, esExpresion, agruparCriteriosApertura, agruparCriteriosCierre)
    End Sub

    ' Sentencia SELECT
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="contenedor"></param>
    ''' <param name="selectSQL"></param>
    ''' <param name="fromSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CargarDatos(ByRef contenedor As String, selectSQL As String, fromSQL As String) As Boolean
        Try
            Select Case Gestor
                Case GestorDeBaseDeDatos.Oracle, GestorDeBaseDeDatos.SQLServer, GestorDeBaseDeDatos.MySQL
                    _Data.CantidadDeRegistros = _CantidadDeRegistros
                    Return _Data.LlenarContenedor2(contenedor, selectSQL, fromSQL, "", "", "", "")
                Case Else
                    Mensaje = "Esta funcionalidad está disponible unicamente para Oracle y SQLServer."
                    Return False
            End Select
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    Public Function CargarDatos(ByRef contenedor As DataTable, selectSQL As String, fromSQL As String) As Boolean
        Try
            Select Case Gestor
                Case GestorDeBaseDeDatos.Oracle, GestorDeBaseDeDatos.SQLServer, GestorDeBaseDeDatos.MySQL
                    _Data.CantidadDeRegistros = _CantidadDeRegistros
                    Return _Data.LlenarContenedor2(contenedor, selectSQL, fromSQL, "", "", "", "")
                Case Else
                    Mensaje = "Esta funcionalidad está disponible unicamente para Oracle y SQLServer."
                    Return False
            End Select
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    Public Function CargarDatos(ByRef contenedor As DataSet, selectSQL As String, fromSQL As String) As Boolean
        Try
            Select Case Gestor
                Case GestorDeBaseDeDatos.Oracle, GestorDeBaseDeDatos.SQLServer, GestorDeBaseDeDatos.MySQL
                    _Data.CantidadDeRegistros = _CantidadDeRegistros
                    Return _Data.LlenarContenedor2(contenedor, selectSQL, fromSQL, "", "", "", "")
                Case Else
                    Mensaje = "Esta funcionalidad está disponible unicamente para Oracle y SQLServer."
                    Return False
            End Select
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="contenedor"></param>
    ''' <param name="selectSQL"></param>
    ''' <param name="fromSQL"></param>
    ''' <param name="groupBySQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CargarDatos(ByRef contenedor As String, selectSQL As String, fromSQL As String, groupBySQL As String) As Boolean
        Try
            Select Case Gestor
                Case GestorDeBaseDeDatos.Oracle, GestorDeBaseDeDatos.SQLServer, GestorDeBaseDeDatos.MySQL
                    _Data.CantidadDeRegistros = _CantidadDeRegistros
                    Return _Data.LlenarContenedor2(contenedor, selectSQL, fromSQL, groupBySQL, "", "", "")
                Case Else
                    Mensaje = "Esta funcionalidad está disponible unicamente para Oracle y SQLServer."
                    Return False
            End Select
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    Public Function CargarDatos(ByRef contenedor As DataTable, selectSQL As String, fromSQL As String, groupBySQL As String) As Boolean
        Try
            Select Case Gestor
                Case GestorDeBaseDeDatos.Oracle, GestorDeBaseDeDatos.SQLServer, GestorDeBaseDeDatos.MySQL
                    _Data.CantidadDeRegistros = _CantidadDeRegistros
                    Return _Data.LlenarContenedor2(contenedor, selectSQL, fromSQL, groupBySQL, "", "", "")
                Case Else
                    Mensaje = "Esta funcionalidad está disponible unicamente para Oracle y SQLServer."
                    Return False
            End Select
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    Public Function CargarDatos(ByRef contenedor As DataSet, selectSQL As String, fromSQL As String, groupBySQL As String) As Boolean
        Try
            Select Case Gestor
                Case GestorDeBaseDeDatos.Oracle, GestorDeBaseDeDatos.SQLServer, GestorDeBaseDeDatos.MySQL
                    _Data.CantidadDeRegistros = _CantidadDeRegistros
                    Return _Data.LlenarContenedor2(contenedor, selectSQL, fromSQL, groupBySQL, "", "", "")
                Case Else
                    Mensaje = "Esta funcionalidad está disponible unicamente para Oracle y SQLServer."
                    Return False
            End Select
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="contenedor"></param>
    ''' <param name="selectSQL"></param>
    ''' <param name="fromSQL"></param>
    ''' <param name="groupBySQL"></param>
    ''' <param name="havingSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function CargarDatos(ByRef contenedor As String, selectSQL As String, fromSQL As String, groupBySQL As String, havingSQL As String) As Boolean
        Try
            Select Case Gestor
                Case GestorDeBaseDeDatos.Oracle, GestorDeBaseDeDatos.SQLServer, GestorDeBaseDeDatos.MySQL
                    _Data.CantidadDeRegistros = _CantidadDeRegistros
                    Return _Data.LlenarContenedor2(contenedor, selectSQL, fromSQL, groupBySQL, havingSQL, "", "")
                Case Else
                    Mensaje = "Esta funcionalidad está disponible unicamente para Oracle y SQLServer."
                    Return False
            End Select
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    Public Function CargarDatos(ByRef contenedor As DataTable, selectSQL As String, fromSQL As String, groupBySQL As String, havingSQL As String) As Boolean
        Try
            Select Case Gestor
                Case GestorDeBaseDeDatos.Oracle, GestorDeBaseDeDatos.SQLServer, GestorDeBaseDeDatos.MySQL
                    _Data.CantidadDeRegistros = _CantidadDeRegistros
                    Return _Data.LlenarContenedor2(contenedor, selectSQL, fromSQL, groupBySQL, havingSQL, "", "")
                Case Else
                    Mensaje = "Esta funcionalidad está disponible unicamente para Oracle y SQLServer."
                    Return False
            End Select
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    Public Function CargarDatos(ByRef contenedor As DataSet, selectSQL As String, fromSQL As String, groupBySQL As String, havingSQL As String) As Boolean
        Try
            Select Case Gestor
                Case GestorDeBaseDeDatos.Oracle, GestorDeBaseDeDatos.SQLServer, GestorDeBaseDeDatos.MySQL
                    _Data.CantidadDeRegistros = _CantidadDeRegistros
                    Return _Data.LlenarContenedor2(contenedor, selectSQL, fromSQL, groupBySQL, havingSQL, "", "")
                Case Else
                    Mensaje = "Esta funcionalidad está disponible unicamente para Oracle y SQLServer."
                    Return False
            End Select
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="contenedor"></param>
    ''' <param name="selectSQL"></param>
    ''' <param name="fromSQL"></param>
    ''' <param name="groupBySQL"></param>
    ''' <param name="havingSQL"></param>
    ''' <param name="orderBySQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CargarDatos(ByRef contenedor As String, selectSQL As String, fromSQL As String, groupBySQL As String, havingSQL As String, orderBySQL As String) As Boolean
        Try
            Select Case Gestor
                Case GestorDeBaseDeDatos.Oracle, GestorDeBaseDeDatos.SQLServer, GestorDeBaseDeDatos.MySQL
                    _Data.CantidadDeRegistros = _CantidadDeRegistros
                    Return _Data.LlenarContenedor2(contenedor, selectSQL, fromSQL, groupBySQL, havingSQL, orderBySQL, "")
                Case Else
                    Mensaje = "Esta funcionalidad está disponible unicamente para Oracle y SQLServer."
                    Return False
            End Select
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function
    Public Function CargarDatos(ByRef contenedor As DataTable, selectSQL As String, fromSQL As String, groupBySQL As String, havingSQL As String, orderBySQL As String) As Boolean
        Try
            Select Case Gestor
                Case GestorDeBaseDeDatos.Oracle, GestorDeBaseDeDatos.SQLServer, GestorDeBaseDeDatos.MySQL
                    _Data.CantidadDeRegistros = _CantidadDeRegistros
                    Return _Data.LlenarContenedor2(contenedor, selectSQL, fromSQL, groupBySQL, havingSQL, orderBySQL, "")
                Case Else
                    Mensaje = "Esta funcionalidad está disponible unicamente para Oracle y SQLServer."
                    Return False
            End Select
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function
    Public Function CargarDatos(ByRef contenedor As DataSet, selectSQL As String, fromSQL As String, groupBySQL As String, havingSQL As String, orderBySQL As String) As Boolean
        Try
            Select Case Gestor
                Case GestorDeBaseDeDatos.Oracle, GestorDeBaseDeDatos.SQLServer, GestorDeBaseDeDatos.MySQL
                    _Data.CantidadDeRegistros = _CantidadDeRegistros
                    Return _Data.LlenarContenedor2(contenedor, selectSQL, fromSQL, groupBySQL, havingSQL, orderBySQL, "")
                Case Else
                    Mensaje = "Esta funcionalidad está disponible unicamente para Oracle y SQLServer."
                    Return False
            End Select
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    Public Function CargarDatos(ByRef contenedor As DataSet, selectSQL As String, fromSQL As String, groupBySQL As String, havingSQL As String, orderBySQL As String, nombreDelContenedor As String) As Boolean
        Try
            Select Case Gestor
                Case GestorDeBaseDeDatos.Oracle, GestorDeBaseDeDatos.SQLServer, GestorDeBaseDeDatos.MySQL
                    _Data.CantidadDeRegistros = _CantidadDeRegistros
                    Return _Data.LlenarContenedor2(contenedor, selectSQL, fromSQL, groupBySQL, havingSQL, orderBySQL, nombreDelContenedor)
                Case Else
                    Mensaje = "Esta funcionalidad está disponible unicamente para Oracle y SQLServer."
                    Return False
            End Select
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function
#End Region

#Region "Select_Datos"
    <Obsolete("Este método es obsoleto, utilizar CargarDatos en su lugar.")>
    Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String) As Boolean
        Try
            Return _Data.LlenarContenedor(Contenedor, FromSQL)
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    <Obsolete("Este método es obsoleto, utilizar CargarDatos en su lugar.")>
    Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal CantidadDeRegistros As Integer) As Boolean
        Try
            Return _Data.LlenarContenedor(Contenedor, FromSQL, CantidadDeRegistros)
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    <Obsolete("Este método es obsoleto, utilizar CargarDatos en su lugar.")>
    Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String) As Boolean
        Try
            SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
            Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL)
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    <Obsolete("Este método es obsoleto, utilizar CargarDatos en su lugar.")>
    Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal CantidadDeRegistros As Integer) As Boolean
        Try
            SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
            Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, "", "", "", "", CantidadDeRegistros)
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    <Obsolete("Este método es obsoleto, utilizar CargarDatos en su lugar.")>
    Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String) As Boolean
        Try
            SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
            Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL)
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    <Obsolete("Este método es obsoleto, utilizar CargarDatos en su lugar.")>
    Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal CantidadDeRegistros As Integer) As Boolean
        Try
            SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
            Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, "", "", "", CantidadDeRegistros)
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    <Obsolete("Este método es obsoleto, utilizar CargarDatos en su lugar.")>
    Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal GroupBySQL As String) As Boolean
        Try
            SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
            Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, GroupBySQL)
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    <Obsolete("Este método es obsoleto, utilizar CargarDatos en su lugar.")>
    Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal GroupBySQL As String, ByVal CantidadDeRegistros As Integer) As Boolean
        Try
            SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
            Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, GroupBySQL, CantidadDeRegistros)
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    <Obsolete("Este método es obsoleto, utilizar CargarDatos en su lugar.")>
    Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal GroupBySQL As String, ByVal HavingSQL As String) As Boolean
        Try
            SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
            Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, GroupBySQL, HavingSQL)
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    <Obsolete("Este método es obsoleto, utilizar CargarDatos en su lugar.")>
    Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal GroupBySQL As String, ByVal HavingSQL As String, ByVal CantidadDeRegistros As Integer) As Boolean
        Try
            SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
            Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, GroupBySQL, HavingSQL, "", CantidadDeRegistros)
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    <Obsolete("Este método es obsoleto, utilizar CargarDatos en su lugar.")>
    Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal GroupBySQL As String, ByVal HavingSQL As String, ByVal OrderBySQL As String) As Boolean
        Try
            SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
            Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, GroupBySQL, HavingSQL, OrderBySQL)
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    <Obsolete("Este método es obsoleto, utilizar CargarDatos en su lugar.")>
    Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal GroupBySQL As String, ByVal HavingSQL As String, ByVal OrderBySQL As String, ByVal CantidadDeRegistros As Integer) As Boolean
        Try
            SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
            Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, GroupBySQL, HavingSQL, OrderBySQL, CantidadDeRegistros)
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function

    <Obsolete("Este método es obsoleto, utilizar CargarDatos en su lugar.")>
    Public Function Select_Datos(ByRef Contenedor As Object, ByVal FromSQL As String, ByVal SelectSQL As String, ByVal WhereSQL As String, ByVal GroupBySQL As String, ByVal HavingSQL As String, ByVal OrderBySQL As String, ByVal CantidadDeRegistros As Integer, ByVal IntoFromSQL As String) As Boolean
        Try
            SelectSQL = IIf(SelectSQL = "", "*", SelectSQL)
            Return _Data.LlenarContenedor(Contenedor, FromSQL, SelectSQL, WhereSQL, GroupBySQL, HavingSQL, OrderBySQL, CantidadDeRegistros, IntoFromSQL)
        Catch ex As Exception
            _Data.Mensaje = "Error en operación: " & ex.Message
            Return False
        End Try
    End Function
#End Region

#Region "LlenarComboBox"
    Public Sub Llenar_ComboBox(ByRef ParDataCombo As Object, ByVal ParTabla As String, ByVal ParLlave As String, ByVal ParNombre As String, Optional ByVal ParCondicion As String = "")
        Dim Tabla As New DataTable
        Try
            Select_Datos(Tabla, ParTabla, ParLlave & ", " & ParNombre, ParCondicion, "", "", ParNombre & " ASC")
            Llenar_ComboBox(ParDataCombo, Tabla, ParLlave, ParNombre)
        Catch ex As Exception
            _Data.Mensaje = "Error en Llenar_ComboBox: " & ex.Message
        End Try
    End Sub
    Public Sub Llenar_ComboBox(ByRef ParDataCombo As Object, ByVal ParTabla As String, ByVal ParLlave As String, ByVal ParNombre As String, ByVal ParCondicion As String, ByVal ParOrderBy As String)
        Dim Tabla As New DataTable
        If ParOrderBy = "" Then ParOrderBy = ParNombre
        Try
            Select_Datos(Tabla, ParTabla, ParLlave & ", " & ParNombre, ParCondicion, "", "", ParOrderBy & " ASC")
            Llenar_ComboBox(ParDataCombo, Tabla, ParLlave, ParNombre)
        Catch ex As Exception
            _Data.Mensaje = "Error en Llenar_ComboBox: " & ex.Message
        End Try
    End Sub
    Public Sub Llenar_ComboBox(ByVal ParDataCombo As Object, ByVal ParOrigenDatos As DataTable, ByVal ParLlave As String, ByVal ParTexto As String, Optional ByVal ParDesplegar As String = "")
        Dim Fila As DataRow
        Try
            Fila = ParOrigenDatos.NewRow
            If Fila(ParLlave).GetType.Name = "String" Then
                Fila(ParLlave) = ""
            Else
                Fila(ParLlave) = 0
            End If
            Fila(ParTexto) = ParDesplegar
            ParOrigenDatos.Rows.InsertAt(Fila, 0)
            ParDataCombo.DataSource = ParOrigenDatos
            If ParDataCombo.GetType.Name.ToString = "ComboBox" Then
                ParDataCombo.DisplayMember = ParTexto
                ParDataCombo.ValueMember = ParLlave
            ElseIf ParDataCombo.GetType.Name.ToString = "DropDownList" Then
                ParDataCombo.DataTextField = ParTexto
                ParDataCombo.DataValueField = ParLlave
                ParDataCombo.DataBind()
            Else
                ParDataCombo.DisplayMember = ParTexto
                ParDataCombo.ValueMember = ParLlave
            End If
            If ParDataCombo.GetType.Name.ToString = "ComboBox" Then ParDataCombo.SelectedIndex = 0
        Catch ex As Exception
            Mensaje = "Error en Llenar_ComboBox: " & ex.Message
        End Try
    End Sub
    Public Sub Llenar_ComboBox(ByVal ParDataCombo As Object, ByVal ParOrigenDatos As DataTable, ByVal ParLlave As String, ByVal ParTexto As String, ByVal ParDesplegar As String, ByVal ParLlaveNula As String)
        Dim Fila As DataRow
        Try
            Fila = ParOrigenDatos.NewRow
            If Fila(ParLlave).GetType.Name = "String" Then
                Fila(ParLlave) = ParLlaveNula.ToString
            Else
                Fila(ParLlave) = ParLlaveNula
            End If
            Fila(ParTexto) = ParDesplegar
            ParOrigenDatos.Rows.InsertAt(Fila, 0)
            ParDataCombo.DataSource = ParOrigenDatos

            ParDataCombo.DataSource = ParOrigenDatos
            If ParDataCombo.GetType.Name.ToString = "ComboBox" Then
                ParDataCombo.DisplayMember = ParTexto
                ParDataCombo.ValueMember = ParLlave
            ElseIf ParDataCombo.GetType.Name.ToString = "DropDownList" Then
                ParDataCombo.DataTextField = ParTexto
                ParDataCombo.DataValueField = ParLlave
                ParDataCombo.DataBind()
            Else
                ParDataCombo.DisplayMember = ParTexto
                ParDataCombo.ValueMember = ParLlave
            End If

            If ParDataCombo.GetType.Name.ToString = "ComboBox" Then ParDataCombo.SelectedIndex = 0
        Catch ex As Exception
            Mensaje = "Error en Llenar_ComboBox: " & ex.Message
        End Try
    End Sub
#End Region

#End Region
End Class