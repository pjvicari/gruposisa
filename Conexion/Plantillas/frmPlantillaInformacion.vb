Public Class frmPlantillaInformacion
    'Columnas de la grid
    Private _Columnas(0) As Columna
    Protected dtListado As New DataTable

    Private _LlavesPrimarias(0) As LlavePrimaria
    Private _LlavesPrimariasDetalle As New List(Of LlavePrimaria)

    Private _Mensaje As String

#Region "Propiedades"
    'Operacion
    Private _TipoDeOperacion As Operacion
    Public Property TipoDeOperacion() As Operacion
        Get
            Return _TipoDeOperacion
        End Get
        Set(ByVal value As Operacion)
            _TipoDeOperacion = value
        End Set
    End Property

    Private _EtiquetaParaOperacion As String = ""
    Public Property EtiquetaParaOperacion() As String
        Get
            Return _EtiquetaParaOperacion
        End Get
        Set(ByVal value As String)
            _EtiquetaParaOperacion = value
        End Set
    End Property

    'Idenficación del formulario
    Private _NumeroDeFormulario As Integer
    Public Property NumeroDeFormulario() As Integer
        Get
            Return _NumeroDeFormulario
        End Get
        Set(ByVal value As Integer)
            _NumeroDeFormulario = value
        End Set
    End Property

    Private _NombreDeFormulario As String
    Public Property NombreDeFormulario() As String
        Get
            Return _NombreDeFormulario
        End Get
        Set(ByVal value As String)
            _NombreDeFormulario = value
        End Set
    End Property

    Private _SiglasDelSistema As String
    Public Property SiglasDelSistema() As String
        Get
            Return _SiglasDelSistema
        End Get
        Set(ByVal value As String)
            _SiglasDelSistema = value
        End Set
    End Property

    'Clase de conexion
    Private _ClaseDeConexion As Object
    Public Property ClaseDeConexion() As Object
        Get
            Return _ClaseDeConexion
        End Get
        Set(ByVal value As Object)
            _ClaseDeConexion = value
        End Set
    End Property

    'Sentencia SQL
    Private _Select As String
    Public Property SelectSQL As String
        Get
            Return _Select
        End Get
        Set(ByVal value As String)
            _Select = value
        End Set
    End Property

    Private _From As String
    Public Property From() As String
        Get
            Return _From
        End Get
        Set(ByVal value As String)
            _From = value
        End Set
    End Property

    Private _Where As String
    Public Property Where() As String
        Get
            Return _Where
        End Get
        Set(ByVal value As String)
            _Where = value
        End Set
    End Property

    Private _GroupBy As String
    Public Property GroupBy() As String
        Get
            Return _GroupBy
        End Get
        Set(ByVal value As String)
            _GroupBy = value
        End Set
    End Property

    Private _Having As String
    Public Property Having() As String
        Get
            Return _Having
        End Get
        Set(ByVal value As String)
            _Having = value
        End Set
    End Property

    Private _OrderBy As String
    Public Property OrderBy() As String
        Get
            Return _OrderBy
        End Get
        Set(ByVal value As String)
            _OrderBy = value
        End Set
    End Property
    'Mostrar el boton de Imprimir   
    Private _MostrarBotonImprimir As Boolean = False

    Public Property MostrarBotonImprimir() As Boolean
        Get
            Return _MostrarBotonImprimir
        End Get
        Set(ByVal value As Boolean)
            _MostrarBotonImprimir = value
        End Set
    End Property

    'Permisos
    Private _AccesosPermitidos As String
    Public Property AccesosPermitidos() As String
        Get
            Return _AccesosPermitidos
        End Get
        Set(ByVal value As String)
            _AccesosPermitidos = value
        End Set
    End Property
#End Region

#Region "Metodos publicos"
    Public Sub VincularColumna(ByVal NombreDelCampo As String, Control As Object, ByVal Alineacion As HorizontalAlignment, EditarAl As Conexion.TipoDeEdicion, ByVal Formato As String)
        _Columnas(_Columnas.Length - 1) = New Columna("", NombreDelCampo, 0, False, Control, Alineacion, EditarAl, Formato, TipoDeColumna.DataGridViewTextBoxColumn, False)
        ReDim Preserve _Columnas(_Columnas.Length)
    End Sub

    Public Sub VincularColumna(ByVal NombreDelCampo As String, Control As Object, ByVal Alineacion As HorizontalAlignment, EditarAl As Conexion.TipoDeEdicion)
        _Columnas(_Columnas.Length - 1) = New Columna("", NombreDelCampo, 0, False, Control, Alineacion, EditarAl, "", TipoDeColumna.DataGridViewTextBoxColumn, False)
        ReDim Preserve _Columnas(_Columnas.Length)
    End Sub

    Public Sub AgregarLlavePrimaria(NombreDelCampo As String, ValorDelCampo As Object)
        _LlavesPrimarias(_LlavesPrimarias.Length - 1) = New LlavePrimaria(NombreDelCampo, ValorDelCampo)
        ReDim Preserve _LlavesPrimarias(_LlavesPrimarias.Length)
    End Sub

    Public Sub AgregarLlavePrimariaDetalle(NombreDelCampo As String, ValorDelCampo As Object)
        If _LlavesPrimariasDetalle Is Nothing Then _LlavesPrimariasDetalle = New List(Of LlavePrimaria)
        _LlavesPrimariasDetalle.Add(New LlavePrimaria(NombreDelCampo, ValorDelCampo))
    End Sub

    Public Sub LimpiarLlavesPrimarias()
        Try
            ReDim _LlavesPrimarias(0)
        Catch ex As Exception
            _Mensaje = "Error al LimpiarLlavesPrimarias: " & ex.Message
        End Try
    End Sub

    Public Function ObtenerLlavePrimariaDetalle(NombreDelCampo As String) As String
        Dim _Valor As String = Nothing
        For Each _Llave As LlavePrimaria In _LlavesPrimariasDetalle
            If _Llave.NombreCampo = NombreDelCampo Then
                _Valor = _Llave.ValorCampo.ToString
            End If
        Next
        Return _Valor
    End Function

    Public Overridable Function Imprimir() As Boolean Handles btnImprimir.Click
        Return True
    End Function

    Public Overridable Function Agregar() As Boolean
        Return True
    End Function

    Public Overridable Function Modificar() As Boolean
        Return True
    End Function

    Public Overridable Function Eliminar() As Boolean
        Return True
    End Function

    Public Overridable Sub LimpiarCampos()
    End Sub

    Public Overridable Sub CargarDetalle()
    End Sub

    Protected Friend Sub InicializarFormulario()
        Try
            'Identificacion del formulario
            Me.Text = _NombreDeFormulario & " [" & _SiglasDelSistema & "_FRM" & Format(_NumeroDeFormulario, "0000") & "] Operación: " & IIf(_EtiquetaParaOperacion.Trim <> "", _EtiquetaParaOperacion, _TipoDeOperacion.ToString)
            'Mostrar boton de aceptar
            btnAceptar.Visible = True
            'Verificar la clase de conexion
            If _ClaseDeConexion Is Nothing Then
                MsgBox("No se ha definido una clase de conexión, por favor verificar (ClaseDeConexion)", MsgBoxStyle.Critical)
            Else
                'Cargar las llaves primarias
                Dim _WhereLlavesPrimarias As String = ""
                For Each _Llave As LlavePrimaria In _LlavesPrimarias
                    If _Llave Is Nothing Then Continue For
                    _WhereLlavesPrimarias &= "AND " & _Llave.NombreCampo & " = '" & _Llave.ValorCampo.ToString & "' "
                Next

                Select Case TipoDeOperacion
                    Case Operacion.Consultar
                        btnAceptar.Visible = False

                        If Not _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, _Where & " " & _WhereLlavesPrimarias, _GroupBy, _Having, _OrderBy, 0) Then
                            MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
                        Else
                            _Consultar()
                        End If
                    Case Operacion.Agregar
                        _Agregar()
                    Case Operacion.Modificar
                        If Not _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, _Where & " " & _WhereLlavesPrimarias, _GroupBy, _Having, _OrderBy, 0) Then
                            MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
                        Else
                            _Modificar()
                        End If
                    Case Operacion.Eliminar
                        If Not _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, _Where & " " & _WhereLlavesPrimarias, _GroupBy, _Having, _OrderBy, 0) Then
                            MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
                        Else
                            _Eliminar()
                        End If
                End Select

               
            End If

            HabilitarMenu(True)

            'Mostrar los botones indicados
            btnImprimir.Visible = _MostrarBotonImprimir
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
#End Region

#Region "Medodos privados"
    Private Sub _Consultar()
        Habilitar_Edicion(False)
        VincularDatos()
    End Sub

    Private Sub _Agregar()
        Habilitar_Edicion(True)
        LimpiarCampos()
    End Sub

    Private Sub _Modificar()
        Habilitar_Edicion(True)
        VincularDatos()
    End Sub

    Private Sub _Eliminar()
        Habilitar_Edicion(False)
        VincularDatos()
    End Sub

    Private Sub Habilitar_Edicion(ByVal Estado As Boolean)
        For Each _Columna As Columna In _Columnas
            If Not _Columna Is Nothing Then
                If Not _Columna.Control Is Nothing Then
                    If _Columna.EditarAl = TipoDeEdicion.Ninguna Or Not Estado Then
                        _Columna.Control.Enabled = False
                    ElseIf _Columna.EditarAl = TipoDeEdicion.AlAgregar And _TipoDeOperacion = Operacion.Agregar Then
                        _Columna.Control.Enabled = Estado
                    ElseIf _Columna.EditarAl = TipoDeEdicion.AlAgregar And _TipoDeOperacion = Operacion.Modificar Then
                        _Columna.Control.Enabled = False
                    ElseIf _Columna.EditarAl = TipoDeEdicion.AlModificar And _TipoDeOperacion = Operacion.Agregar Then
                        _Columna.Control.Enabled = Estado
                    ElseIf _Columna.EditarAl = TipoDeEdicion.AlModificar And _TipoDeOperacion = Operacion.Modificar Then
                        _Columna.Control.Enabled = Estado
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub VincularDatos()
        Try
            If dtListado.Rows.Count = 0 Then
                MsgBox("No hay datos para vincular.", MsgBoxStyle.Exclamation)
            Else
                Dim _DataRow As DataRow = dtListado.Rows(0)
                'Vincular los datos
                For Each _Columna As Columna In _Columnas
                    'Si la columna esta definida
                    If Not _Columna Is Nothing Then
                        'Si el control esta definido
                        If Not _Columna.Control Is Nothing Then
                            If _Columna.NombreCampo = "" Then Continue For
                            Select Case _Columna.Control.GetType.Name
                                Case "TextBox", "MaskedTextBox"
                                    '_Columna.Control.TextAlign = _Columna.Alineacion

                                    If Not _DataRow(_Columna.NombreCampo).ToString Is Nothing Then
                                        If _Columna.Formato = "" Then
                                            _Columna.Control.Text = _DataRow(_Columna.NombreCampo).ToString
                                        Else
                                            If IsNumeric(_DataRow(_Columna.NombreCampo)) Then
                                                _Columna.Control.Text = Format(CDbl(_DataRow(_Columna.NombreCampo)), _Columna.Formato)
                                            ElseIf IsDate(_DataRow(_Columna.NombreCampo)) Then
                                                _Columna.Control.Text = Format(CDate(_DataRow(_Columna.NombreCampo)), _Columna.Formato)
                                            Else
                                                If _DataRow(_Columna.NombreCampo).ToString <> "" Then
                                                    _Columna.Control.Text = Format(_DataRow(_Columna.NombreCampo), _Columna.Formato)
                                                End If
                                            End If
                                        End If
                                    End If
                                Case "DateTimePicker"
                                    If Not _DataRow(_Columna.NombreCampo) Is Nothing Then
                                        _Columna.Control.Value = _DataRow(_Columna.NombreCampo).ToString
                                    End If
                                Case "ComboBox"
                                    If Not _Columna.Control Is Nothing Then
                                        _Columna.Control.SelectedValue = _DataRow(_Columna.NombreCampo).ToString
                                    End If
                            End Select
                        End If
                    End If
                Next
                'Vincular el detalle
                CargarDetalle()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "VincularDatos")
        End Try
    End Sub

    Private Sub HabilitarMenu(ByVal ParEstado As Boolean)
        Select Case _TipoDeOperacion
            Case Operacion.Consultar
                btnImprimir.Enabled = IIf(btnImprimir.Tag <> "", IIf(InStr(_AccesosPermitidos, btnImprimir.Tag) = 0, False, ParEstado), ParEstado)
            Case Operacion.Agregar
                btnImprimir.Enabled = False
            Case Operacion.Modificar
                btnImprimir.Enabled = IIf(btnImprimir.Tag <> "", IIf(InStr(_AccesosPermitidos, btnImprimir.Tag) = 0, False, ParEstado), ParEstado)
            Case Operacion.Eliminar
                btnImprimir.Enabled = False
        End Select
    End Sub
#End Region

#Region "Procedimientos"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ReDim _LlavesPrimarias(0)
        _LlavesPrimariasDetalle = Nothing
        Me.Close()
        'Me.Dispose()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Resultado As Boolean = False
        Select Case _TipoDeOperacion
            Case Operacion.Agregar
                Resultado = Agregar()
            Case Operacion.Modificar
                Resultado = Modificar()
            Case Operacion.Eliminar
                Resultado = Eliminar()
            Case Operacion.Consultar
                Resultado = True
        End Select

        If Resultado Then
            ReDim _LlavesPrimarias(0)
            _LlavesPrimariasDetalle = Nothing
            Me.Close()
        Else
            If Not _Mensaje Is Nothing Then
                If _Mensaje.ToString.Length > 0 Then MsgBox(_Mensaje, MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub frmPlantillaInformacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ReDim _LlavesPrimarias(0)
        _LlavesPrimariasDetalle = Nothing
        _EtiquetaParaOperacion = ""
    End Sub

    Private Sub frmPlantillaInformacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
#End Region
End Class