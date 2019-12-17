Imports MySql.Data.MySqlClient

Public Module ModuloGeneral

#Region "Variables"
    Private _ServidorSQLServerProduccion As String = "153116133150110137150116129153115"
    Private _ServidorSQLServerDesarrollo As String = "153116133150110137150116129154109"
    Private _ServidorSQLServerCapacitacion As String = "153116133150110137150113129154113134"

    Private _UsuarioSQLServerProduccion As String = "169160182205176194187166199209172133152110132"
    Private _ContraseñaSQLServerProduccion As String = "204159132153169196219160180216160199218"

    Private _UsuarioSQLServerDesarrollo As String = "169160182205176194187166199209172133152110132"
    Private _ContraseñaSQLServerDesarrollo As String = "205118187204112160222158157156111153218133161224"

    Private _ServidorOracleProduccion As String = "177139167173128148184"
    Private _ServidorOracleDesarrollo As String = "172130169173137162184130"
    Private _ServidorOracleCapacitacion As String = "188143148177139156182132"

    Private _ContraseñaOracleDesarrollo As String = "182181148222147140205128139207156152225111"

    Private _ServidorMySQLProduccion As String = "212172182201169187215176199"
    Private _ServidorMySQLDesarrollo As String = "212172182201169187215176199"
    Private _BaseDeDatos As String = "207175200216172198209176180"

    Private _UsuarioMySQLProduccion As String = "218172194220"
    Private _ContraseñaMySQLProduccion As String = "190166182201175188147110131"
    Private _UsuarioMySQLDesarrollo As String = "218172194220"
    Private _ContraseñaMySQLDesarrollo As String = "190166182201175188147110131"


#End Region

#Region "Enumerados"
    Public Enum Operacion
        Consultar = 0
        Agregar = 1
        Modificar = 2
        Eliminar = 3
    End Enum

    Public Enum EsquemaDeBaseDeDatos
        'Oracle y SQL
        Administracion = 1
        'Oracle y SQL
        Catalogos = 2
        'Oracle y SQL
        Operacion = 3
        'Oracle
        Inventarios = 4
        'Oracle
        Recaudacion = 5
        'Oracle
        Facturacion = 6
        'Oracle
        Sys = 7
        'SQL Server
        Presupuesto = 8
        'Entrenamiento
        Entrenamiento = 9
        ' Aplicaciones Web
        AplicacionesWeb = 10
        ' System (Oracle)
        System = 11
    End Enum

    Public Enum TipoDeOperacion
        Agregar = 1
        Modificar = 2
        Eliminar = 3
        EjecutarProcedimientoAlmacenado = 4
    End Enum

    Public Enum TipoDeOperadorLogico
        AndOperador = 1
        OrOperador = 2
    End Enum

    Public Enum TipoDeOperadorDeComparacion
        Igual = 1
        Mayor = 2
        MayorIgual = 3
        Menor = 4
        MenorIgual = 5
        Diferente = 6
        InOperador = 7
        NotInOperador = 8
        LikeOperador = 9
        NotLikeOperador = 10
        LikeIzquierdoOperador = 11
        NotLikeIzquierdoOperador = 12
        LikeDerechoOperador = 13
        NotLikeDerechoOperador = 14
        IsOperador = 15
        RegExpLike = 16
        NotRegExpLike = 17
    End Enum

    Public Enum GestorDeBaseDeDatos
        Oracle = 1
        SQLServer = 2
        MySQL = 3
        'Excel = 4
        'ODBC = 5
    End Enum

    Public Enum AmbienteDeBaseDeDatos
        Produccion = 1
        Desarrollo = 2
        Capacitacion = 3
    End Enum

    Public Enum DestinoDeReportes
        Pantalla = 0
        Impresora = 1
        Exportar = 2
    End Enum

    ' Enmeraciones para clase Columnas
    Public Enum TipoDeEdicion
        Ninguna = 0
        AlAgregar = 1
        AlModificar = 2
    End Enum

    Public Enum TipoDeColumna
        DataGridViewTextBoxColumn = 1
        DataGridViewCheckBoxColumn = 2
    End Enum
#End Region

    Public Function ConectionString(ByVal tipoDeBaseDeDatos As GestorDeBaseDeDatos, esquemaDeBaseDeDatos As EsquemaDeBaseDeDatos, ByVal añoDeOperacion As Integer, ambiente As AmbienteDeBaseDeDatos) As String
        Dim _Cadena As String = ""
        Try
            Select Case tipoDeBaseDeDatos
                Case GestorDeBaseDeDatos.Oracle
                    Select Case ambiente
                        Case AmbienteDeBaseDeDatos.Produccion
                            _Cadena = "Data Source=" & Encriptar(_ServidorOracleProduccion, False) & "; "
                        Case AmbienteDeBaseDeDatos.Desarrollo
                            _Cadena = "Data Source=" & Encriptar(_ServidorOracleDesarrollo, False) & "; "
                        Case AmbienteDeBaseDeDatos.Capacitacion
                            _Cadena = "Data Source=" & Encriptar(_ServidorOracleCapacitacion, False) & "; "
                    End Select

                    Select Case esquemaDeBaseDeDatos
                        Case EsquemaDeBaseDeDatos.Administracion
                            _Cadena &= "User Id=" & Encriptar("169141163199126151181134161177144167186126150177140161", False) & "; "
                            If ambiente = AmbienteDeBaseDeDatos.Produccion Then
                                _Cadena &= "Password=" & Encriptar("169141163169129160169129160171146156182136", False) & "; "
                            Else
                                _Cadena &= "Password=" & Encriptar(_ContraseñaOracleDesarrollo, False) & "; "
                            End If
                        Case EsquemaDeBaseDeDatos.Catalogos
                            _Cadena &= "User Id=" & Encriptar("169141163199126151181134161199128148188126159183132162187", False) & "; "
                            If ambiente = AmbienteDeBaseDeDatos.Produccion Then
                                '_Cadena &= "Password=" & Encriptar("169141163169129160182128148188144", False) & "; "
                                _Cadena &= "Password=" & Encriptar("183171133218162118177172131181172119204166132186172139205169", False) & "; "
                            Else
                                _Cadena &= "Password=" & Encriptar(_ContraseñaOracleDesarrollo, False) & "; "
                            End If
                        Case EsquemaDeBaseDeDatos.Operacion
                            _Cadena &= "User Id=" & Encriptar("169141163199140163173143148171134162182156", False) & añoDeOperacion.ToString & "; "
                            If ambiente = AmbienteDeBaseDeDatos.Produccion Then
                                Select Case añoDeOperacion
                                    Case 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020
                                        _Cadena &= "Password=" & Encriptar("183171133218162118177172131181172119204166132186172139205169", False) & "; "
                                        'Case Else
                                        '    _Cadena &= "Password=" & Encriptar("169141163169129160183141", False) & añoDeOperacion.ToString & Encriptar("171137148186140", False) & "; "
                                End Select
                            Else
                                _Cadena &= "Password=" & Encriptar(_ContraseñaOracleDesarrollo, False) & "; "
                            End If
                        Case EsquemaDeBaseDeDatos.Inventarios
                            _Cadena &= "User Id=" & Encriptar("169141163199134149173156169155", False) & "; "
                            If ambiente = AmbienteDeBaseDeDatos.Produccion Then
                                _Cadena &= "Password=" & Encriptar("183171133218162118177172131181172119204166132186172139205169", False) & "; "
                            Else
                                _Cadena &= "Password=" & Encriptar(_ContraseñaOracleDesarrollo, False) & "; "
                            End If
                        Case EsquemaDeBaseDeDatos.Recaudacion
                            _Cadena &= "User Id=" & Encriptar("169141163199143152171126168172126150177140161199111131152114", False) & "; "
                            If ambiente = AmbienteDeBaseDeDatos.Produccion Then
                                _Cadena &= "Password=" & Encriptar("183171133218162118177172131181172119204166132186172139205169", False) & "; "
                            Else
                                _Cadena &= "Password=" & Encriptar(_ContraseñaOracleDesarrollo, False) & "; "
                            End If
                        Case EsquemaDeBaseDeDatos.Facturacion
                            _Cadena &= "User Id=" & Encriptar("169141163199131148171145168186126150177140161199111131152115", False) & "; "
                            If ambiente = AmbienteDeBaseDeDatos.Produccion Then
                                _Cadena &= "Password=" & Encriptar("183171133218162118177172131181172119204166132186172139205169", False) & "; "
                            Else
                                _Cadena &= "Password=" & Encriptar(_ContraseñaOracleDesarrollo, False) & "; "
                            End If
                        Case EsquemaDeBaseDeDatos.AplicacionesWeb
                            _Cadena &= "User Id=" & Encriptar("169141163199126163180134150169128156183139152187156170173127", False) & "; "
                            If ambiente = AmbienteDeBaseDeDatos.Produccion Then
                                _Cadena &= "Password=" & Encriptar("183171133218162118177172131181172119204166132186172139205169", False) & "; "
                            Else
                                _Cadena &= "Password=" & Encriptar(_ContraseñaOracleDesarrollo, False) & "; "
                            End If
                        Case EsquemaDeBaseDeDatos.Sys
                            _Cadena &= "User Id=" & Encriptar("187150166", False) & "; "
                            _Cadena &= "Password=" & Encriptar("179181203182112180201148135205", False) & "; "
                            _Cadena &= "DBA Privilege=" & Encriptar("187150166172127148", False) & "; "
                        Case ModuloGeneral.EsquemaDeBaseDeDatos.System
                            _Cadena &= "User Id=" & Encriptar("187150166188130160", False) & "; "
                            _Cadena &= "Password=" & Encriptar("181162199199144204219101152219158181157", False) & ";"
                    End Select

                    '_Cadena &= " Pooling=true; Max Pool Size=50; Connection Timeout=30; Decr Pool Size=3; Connection Lifetime=60;"
                Case GestorDeBaseDeDatos.SQLServer
                    _UsuarioSQLServerProduccion = "169160182205176194187166199209172133152110132"
                    Select Case ambiente
                        Case AmbienteDeBaseDeDatos.Produccion
                            _Cadena = "Data Source=" & Encriptar(_ServidorSQLServerProduccion, False) & "; "
                        Case AmbienteDeBaseDeDatos.Desarrollo
                            _Cadena = "Data Source=" & Encriptar(_ServidorSQLServerDesarrollo, False) & "; "
                        Case AmbienteDeBaseDeDatos.Capacitacion
                            _Cadena = "Data Source=" & Encriptar(_ServidorSQLServerCapacitacion, False) & "; "
                    End Select

                    Select Case esquemaDeBaseDeDatos
                        Case EsquemaDeBaseDeDatos.Administracion
                            _Cadena &= "Initial Catalog=" & Encriptar("169161192209171188219177197201160188215171", False) & "; "
                        Case EsquemaDeBaseDeDatos.Catalogos
                            _Cadena &= "Initial Catalog=" & Encriptar("169161192209171150201177180212172186215176", False) & "; "
                        Case EsquemaDeBaseDeDatos.Operacion
                            _Cadena &= "Initial Catalog=" & Encriptar("169161192347171162216162197201177188222158", False) & añoDeOperacion.ToString & "; "
                        Case EsquemaDeBaseDeDatos.Presupuesto
                            _Cadena &= "Initial Catalog=" & Encriptar("184175184219178195221162198220172", False) & añoDeOperacion.ToString & "; "
                        Case EsquemaDeBaseDeDatos.Entrenamiento
                            _UsuarioSQLServerProduccion = "169160182205176194173171199218162193201170188205171199215"
                            _ContraseñaSQLServerProduccion = "175178180220162192201169180153111134156114137"
                            _Cadena &= "Initial Catalog=" & Encriptar("173171199218162193201170188205171199215", False) & "; "
                    End Select

                    _Cadena &= "User ID=" & Encriptar(_UsuarioSQLServerProduccion, False) & "; "
                    If ambiente = AmbienteDeBaseDeDatos.Produccion Then
                        _Cadena &= "Password=" & Encriptar(_ContraseñaSQLServerProduccion, False) & "; "
                    Else
                        _Cadena &= "Password=" & Encriptar(_ContraseñaSQLServerDesarrollo, False) & "; "
                    End If

                    _Cadena &= "Persist Security Info=True; Workstation ID=CLIENTE; Packet Size=4096"
                Case GestorDeBaseDeDatos.MySQL
                    Select Case ambiente
                        Case AmbienteDeBaseDeDatos.Produccion
                            _Cadena = "Server=" & Encriptar(_ServidorMySQLProduccion, False) & "; "
                        Case AmbienteDeBaseDeDatos.Desarrollo
                            _Cadena = "Server=" & Encriptar(_ServidorMySQLDesarrollo, False) & "; "
                        Case AmbienteDeBaseDeDatos.Capacitacion
                            _Cadena = "Server=" & Encriptar(_ServidorMySQLDesarrollo, False) & "; "
                    End Select
                    _Cadena &= "Database=" & Encriptar(_BaseDeDatos, False) & "; "
                    _Cadena &= "Uid=" & Encriptar(_UsuarioMySQLProduccion, False) & "; "
                    If ambiente = AmbienteDeBaseDeDatos.Produccion Then
                        _Cadena &= "Pwd=" & Encriptar(_ContraseñaMySQLProduccion, False) & "; "
                    Else
                        _Cadena &= "Pwd=" & Encriptar(_ContraseñaMySQLDesarrollo, False) & "; "
                    End If
                    _Cadena &= "Port=3306"

            End Select
            Return _Cadena
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Function Encriptar(ByVal cadena As String, ByVal encriptarCadena As Boolean) As String
        Dim Nueva As String = "", Temp As String, Inc As Integer = 1
        Dim I As Integer, Valor As Integer, Incremento As Integer
        Incremento = IIf(encriptarCadena, 1, 3)
        For I = 1 To Len(cadena) Step Incremento
            Select Case Inc
                Case 1
                    Valor = 104
                    Inc = Inc + 1
                Case 2
                    Valor = 61
                    Inc = Inc + 1
                Case 3
                    Valor = 83
                    Inc = 1
            End Select
            Temp = Mid(cadena, I, Incremento)
            If encriptarCadena Then
                Nueva = Nueva + Format(Asc(Temp) + Valor, "000")
            Else
                Nueva = Nueva + Chr(Val(Temp) - Valor)
            End If
        Next I
        Encriptar = Nueva
    End Function
End Module
