Public Class frmPlantillaInformacionDetalle
    'Columnas de la grid
    Private _Columnas(0) As Columna
    Protected dtListado As New DataTable
    Protected dtListadoDetalle As New DataTable

    Private _LlavesPrimarias(0) As LlavePrimaria
    Private _LlavesPrimariasDetalle As New List(Of LlavePrimaria)
    Private _WhereLlavesPrimarias As String = ""

    Private _Mensaje As String
    'Filtrar
    Private dtBusqueda_01 As New DataTable
    ' Formulario generico
    Private _FormularioInformacionInterno As Object

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

    'Sentencia SQL (Encabezado)
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
    Private _QuitarLlavesDetalle As Boolean = False
    Public Property QuitarLlavesDetalle() As Boolean
        Get
            Return _QuitarLlavesDetalle
        End Get
        Set(ByVal value As Boolean)
            _QuitarLlavesDetalle = value
        End Set
    End Property

    ' Nuevas funcionalidades para ABC del detalle
    'Formulario de detalle
    Private _FormularioInformacion As frmPlantillaInformacion
    Public Property FormularioInformacion() As frmPlantillaInformacion
        Get
            Return _FormularioInformacion
        End Get
        Set(ByVal value As frmPlantillaInformacion)
            _FormularioInformacion = value
        End Set
    End Property
    'Formulario de detalle
    Private _FormularioInformacionDetalle As frmPlantillaInformacionDetalle
    Public Property FormularioInformacionDetalle() As frmPlantillaInformacionDetalle
        Get
            Return _FormularioInformacionDetalle
        End Get
        Set(ByVal value As frmPlantillaInformacionDetalle)
            _FormularioInformacionDetalle = value
        End Set
    End Property

    'Mostrar los botones de Consultar, Agregar, Modificar, Eliminar e Imprimir            
    Private _MostrarBotonConsultar As Boolean = True
    Public Property MostrarBotonConsultar() As Boolean
        Get
            Return _MostrarBotonConsultar
        End Get
        Set(ByVal value As Boolean)
            _MostrarBotonConsultar = value
        End Set
    End Property

    Private _MostrarBotonAgregar As Boolean = True
    Public Property MostrarBotonAgregar() As Boolean
        Get
            Return _MostrarBotonAgregar
        End Get
        Set(ByVal value As Boolean)
            _MostrarBotonAgregar = value
        End Set
    End Property

    Private _MostrarBotonModificar As Boolean = True
    Public Property MostrarBotonModificar() As Boolean
        Get
            Return _MostrarBotonModificar
        End Get
        Set(ByVal value As Boolean)
            _MostrarBotonModificar = value
        End Set
    End Property

    Private _MostrarBotonEliminar As Boolean = True
    Public Property MostrarBotonEliminar() As Boolean
        Get
            Return _MostrarBotonEliminar
        End Get
        Set(ByVal value As Boolean)
            _MostrarBotonEliminar = value
        End Set
    End Property

    Private _MostrarBotonImprimir As Boolean
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

    'Sentencia SQL (Detalle)
    Private _SelectDetalle As String
    Public Property SelectSQLDetalle As String
        Get
            Return _SelectDetalle
        End Get
        Set(ByVal value As String)
            _SelectDetalle = value
        End Set
    End Property

    Private _FromDetalle As String
    Public Property FromDetalle() As String
        Get
            Return _FromDetalle
        End Get
        Set(ByVal value As String)
            _FromDetalle = value
        End Set
    End Property

    Private _WhereDetalle As String
    Public Property WhereDetalle() As String
        Get
            Return _WhereDetalle
        End Get
        Set(ByVal value As String)
            _WhereDetalle = value
        End Set
    End Property

    Private _GroupByDetalle As String
    Public Property GroupByDetalle() As String
        Get
            Return _GroupByDetalle
        End Get
        Set(ByVal value As String)
            _GroupByDetalle = value
        End Set
    End Property

    Private _HavingDetalle As String
    Public Property HavingDetalle() As String
        Get
            Return _HavingDetalle
        End Get
        Set(ByVal value As String)
            _HavingDetalle = value
        End Set
    End Property

    Private _OrderByDetalle As String
    Public Property OrderByDetalle() As String
        Get
            Return _OrderByDetalle
        End Get
        Set(ByVal value As String)
            _OrderByDetalle = value
        End Set
    End Property
#End Region

#Region "Metodos publicos"
    Public Sub VincularColumna(ByVal NombreDelCampo As String, Control As Object, ByVal Alineacion As HorizontalAlignment, EditarAl As Conexion.TipoDeEdicion, ByVal Formato As String, EsLlavePrimaria As Boolean)
        _Columnas(_Columnas.Length - 1) = New Columna("", NombreDelCampo, 0, False, Control, Alineacion, EditarAl, Formato, TipoDeColumna.DataGridViewTextBoxColumn, EsLlavePrimaria)
        ReDim Preserve _Columnas(_Columnas.Length)
    End Sub
    Public Sub VincularColumna(ByVal NombreDelCampo As String, Control As Object, ByVal Alineacion As HorizontalAlignment, EditarAl As Conexion.TipoDeEdicion, ByVal Formato As String)
        _Columnas(_Columnas.Length - 1) = New Columna("", NombreDelCampo, 0, False, Control, Alineacion, EditarAl, Formato, TipoDeColumna.DataGridViewTextBoxColumn, False)
        ReDim Preserve _Columnas(_Columnas.Length)
    End Sub

    Public Sub VincularColumna(ByVal NombreDelCampo As String, Control As Object, ByVal Alineacion As HorizontalAlignment, EditarAl As Conexion.TipoDeEdicion)
        _Columnas(_Columnas.Length - 1) = New Columna("", NombreDelCampo, 0, False, Control, Alineacion, EditarAl, "", TipoDeColumna.DataGridViewTextBoxColumn, False)
        ReDim Preserve _Columnas(_Columnas.Length)
    End Sub

    Public Sub AgregarLlavePrimaria(NombreDelCampo As String, ValorDelCampo As Object)
        Try
            _LlavesPrimarias(_LlavesPrimarias.Length - 1) = New LlavePrimaria(NombreDelCampo, ValorDelCampo)
            ReDim Preserve _LlavesPrimarias(_LlavesPrimarias.Length)
        Catch ex As Exception
            _Mensaje = "Error al AgregarLlavePrimaria: " & ex.Message
        End Try
    End Sub

    Public Sub LimpiarLlavesPrimarias()
        Try
            ReDim _LlavesPrimarias(0)
        Catch ex As Exception
            _Mensaje = "Error al LimpiarLlavesPrimarias: " & ex.Message
        End Try
    End Sub

    Public Function ObtenerLlavePrimaria(NombreDelCampo As String) As String
        Dim _Valor As String = Nothing
        For Each _Llave As LlavePrimaria In _LlavesPrimarias
            If _Llave Is Nothing Then Continue For
            If _Llave.NombreCampo = NombreDelCampo Then
                _Valor = _Llave.ValorCampo.ToString
            End If
        Next
        Return _Valor
    End Function

    Public Sub AgregarLlavePrimariaDetalle(NombreDelCampo As String, ValorDelCampo As Object)
        Try
            If _LlavesPrimariasDetalle Is Nothing Then _LlavesPrimariasDetalle = New List(Of LlavePrimaria)
            _LlavesPrimariasDetalle.Add(New LlavePrimaria(NombreDelCampo, ValorDelCampo))
        Catch ex As Exception
            _Mensaje = "Error al AgregarLlavePrimariaDetalle: " & ex.Message
        End Try
    End Sub
    Public Function ObtenerLlavePrimariaDetalle(NombreDelCampo As String) As String
        Try
            Dim _Valor As String = Nothing
            For Each _Llave As LlavePrimaria In _LlavesPrimariasDetalle
                If _Llave.NombreCampo = NombreDelCampo Then
                    _Valor = _Llave.ValorCampo.ToString
                End If
            Next
            Return _Valor
        Catch ex As Exception
            Return ""
        End Try        
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

    Public Overridable Function Imprimir() As Boolean Handles btnImprimir.Click
        Return True
    End Function

    Public Overridable Sub LimpiarCampos()
    End Sub

    Public Overridable Sub CargarDetalle()
    End Sub

    Public Sub ActualizarFormulario()
        Filtrar(Nothing, Nothing)
        'Adjuntar llaves primarias
        'AdjuntarLlavesPrimarias()
    End Sub

    Protected Friend Sub InicializarFormulario()
        Try
            'Identificacion del formulario
            Me.Text = _NombreDeFormulario & " [" & _SiglasDelSistema & "_FRM" & Format(_NumeroDeFormulario, "0000") & "] Operación: " & IIf(_EtiquetaParaOperacion.Trim <> "", _EtiquetaParaOperacion, _TipoDeOperacion.ToString)
            'Mostrar boton de aceptar
            btnAceptar.Visible = True
            _WhereLlavesPrimarias = ""
            'Verificar la clase de conexion
            If _ClaseDeConexion Is Nothing Then
                MsgBox("No se ha definido una clase de conexión, por favor verificar (ClaseDeConexion)", MsgBoxStyle.Critical)
            Else
                'Cargar las llaves primarias
                For Each _Llave As LlavePrimaria In _LlavesPrimarias
                    If _Llave Is Nothing Then Continue For
                    _WhereLlavesPrimarias &= "AND " & _Llave.NombreCampo & " = '" & _Llave.ValorCampo.ToString & "' "
                Next
                'Criterio para limpiar la selección al agregar
                If _TipoDeOperacion = Operacion.Agregar Then
                    _WhereLlavesPrimarias &= "AND 1=2 "
                End If

                Select Case TipoDeOperacion
                    Case Operacion.Consultar
                        btnAceptar.Visible = False
                        HabilitarMenu(False)
                        If Not _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, _Where & " " & _WhereLlavesPrimarias, _GroupBy, _Having, _OrderBy, 0) Then
                            MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
                        Else
                            _Consultar()
                        End If
                    Case Operacion.Agregar
                        HabilitarMenu(False)
                        _Agregar()
                    Case Operacion.Modificar
                        HabilitarMenu(False)
                        If Not _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, _Where & " " & _WhereLlavesPrimarias, _GroupBy, _Having, _OrderBy, 0) Then
                            MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
                        Else
                            _Modificar()
                        End If
                    Case Operacion.Eliminar
                        HabilitarMenu(False)
                        If Not _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, _Where & " " & _WhereLlavesPrimarias, _GroupBy, _Having, _OrderBy, 0) Then
                            MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
                        Else
                            _Eliminar()
                        End If
                End Select
            End If

            'Aplicar los permisos
            If _AccesosPermitidos = "" Then
                MsgBox("No se ha definido permisos, por favor verificar (AccesosPermitidos)", MsgBoxStyle.Critical)
            Else
                HabilitarMenu(True)
            End If

            ' Grid detalle
            ' Formato y datos del grid
            FormatearGrid()
            If _QuitarLlavesDetalle Then
                _WhereLlavesPrimarias = ""
            End If
            If Not _ClaseDeConexion.Select_Datos(dtListadoDetalle, _FromDetalle, _SelectDetalle, _WhereDetalle & " " & _WhereLlavesPrimarias, _GroupByDetalle, _HavingDetalle, _OrderByDetalle, 0) Then
                MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
            Else
                dgvListado.DataSource = dtListadoDetalle
            End If            

            'Verificar si hay formulario de informacion
            If _FormularioInformacion Is Nothing Then
                If _FormularioInformacionDetalle Is Nothing Then
                    MsgBox("No se ha definido un formulario de información, por favor verificar (FormularioInformacion)", MsgBoxStyle.Critical)
                Else
                    _FormularioInformacionInterno = _FormularioInformacionDetalle
                End If
            Else
                _FormularioInformacionInterno = _FormularioInformacion
            End If

            'Mostrar los botones indicados
            btnConsultar.Visible = _MostrarBotonConsultar
            btnAgregar.Visible = _MostrarBotonAgregar
            btnModificar.Visible = _MostrarBotonModificar
            btnEliminar.Visible = _MostrarBotonEliminar
            btnImprimir.Visible = _MostrarBotonImprimir
            'grpListado.Visible = _MostrarGridDetalle

        Catch ex As Exception
            MsgBox(ex.Message & " (FormularioInformacion)", MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub AgregarColumna(ByVal TextoAMostrar As String, ByVal NombreDelCampo As String, ByVal TamañoEnPorcentaje As Integer, ByVal ParaFiltrar As Boolean, ByVal Alineacion As DataGridViewContentAlignment, ByVal Formato As String, EsLlavePrimaria As Boolean)
        _Columnas(_Columnas.Length - 1) = New Columna(TextoAMostrar, NombreDelCampo, TamañoEnPorcentaje, ParaFiltrar, Nothing, Alineacion, TipoDeEdicion.Ninguna, Formato, TipoDeColumna.DataGridViewTextBoxColumn, EsLlavePrimaria)
        ReDim Preserve _Columnas(_Columnas.Length)
    End Sub

    Public Sub AgregarColumna(ByVal TextoAMostrar As String, ByVal NombreDelCampo As String, ByVal TamañoEnPorcentaje As Integer, ByVal ParaFiltrar As Boolean, ByVal Alineacion As DataGridViewContentAlignment, EsLlavePrimaria As Boolean)
        _Columnas(_Columnas.Length - 1) = New Columna(TextoAMostrar, NombreDelCampo, TamañoEnPorcentaje, ParaFiltrar, Nothing, Alineacion, TipoDeEdicion.Ninguna, "", TipoDeColumna.DataGridViewTextBoxColumn, EsLlavePrimaria)
        ReDim Preserve _Columnas(_Columnas.Length)
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

    Private Sub _ConsultarDetalle() Handles btnConsultar.Click
        If _FormularioInformacionInterno Is Nothing Then
            MsgBox("No se ha definido un formulario de información, por favor verificar (FormularioInformacion)", MsgBoxStyle.Critical)
        Else
            If dgvListado.CurrentRow Is Nothing Then
                MsgBox("Debe seleccionar un registro.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                _FormularioInformacionInterno.TipoDeOperacion = Operacion.Consultar
                'Adjuntar llaves primarias
                AdjuntarLlavesPrimarias()
                _FormularioInformacionInterno.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub _AgregarDetalle() Handles btnAgregar.Click
        'Verificar si hay formulario de informacion
        If _FormularioInformacionInterno Is Nothing Then
            MsgBox("No se ha definido un formulario de información, por favor verificar (FormularioInformacion)", MsgBoxStyle.Critical)
        Else
            Select Case _TipoDeOperacion
                Case Operacion.Agregar
                    'MsgBox("Debe guardar los datos de la cabecera.", MsgBoxStyle.Information)
                    If Agregar() Then
                        _TipoDeOperacion = Operacion.Modificar
                        Me.Text = _NombreDeFormulario & " [" & _SiglasDelSistema & "_FRM" & Format(_NumeroDeFormulario, "0000") & "] Operación: " & _TipoDeOperacion.ToString
                        'Cargar las llaves primarias
                        _WhereLlavesPrimarias = ""
                        For Each _Llave As LlavePrimaria In _LlavesPrimarias
                            If _Llave Is Nothing Then Continue For
                            _WhereLlavesPrimarias &= "AND " & _Llave.NombreCampo & " = '" & _Llave.ValorCampo.ToString & "' "
                        Next
                        If Not _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, _Where & " " & _WhereLlavesPrimarias, _GroupBy, _Having, _OrderBy, 0) Then
                            MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
                        Else
                            HabilitarMenu(True)
                            _Modificar()
                        End If
                        _FormularioInformacionInterno.TipoDeOperacion = Operacion.Agregar
                        'Adjuntar llaves primarias
                        AdjuntarLlavesPrimariasDetalle()
                        _FormularioInformacionInterno.ShowDialog(Me)
                    End If
                    'Case Operacion.Modificar
                    '    'MsgBox("Debe guardar los datos de la cabecera.", MsgBoxStyle.Information)
                    '    If Modificar() Then                      
                    '        'Cargar las llaves primarias                        
                    '        _WhereLlavesPrimarias = ""
                    '        For Each _Llave As LlavePrimaria In _LlavesPrimarias
                    '            If _Llave Is Nothing Then Continue For
                    '            _WhereLlavesPrimarias &= "AND " & _Llave.NombreCampo & " = '" & _Llave.ValorCampo.ToString & "' "
                    '        Next
                    '        If Not _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, _Where & " " & _WhereLlavesPrimarias, _GroupBy, _Having, _OrderBy, 0) Then
                    '            MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
                    '        Else
                    '            HabilitarMenu(True)
                    '            _Modificar()
                    '        End If
                    '        _FormularioInformacionInterno.TipoDeOperacion = Operacion.Agregar
                    '        'Adjuntar llaves primarias
                    '        AdjuntarLlavesPrimariasDetalle()
                    '        _FormularioInformacionInterno.ShowDialog(Me)
                    '    End If
                Case Else
                    _FormularioInformacionInterno.TipoDeOperacion = Operacion.Agregar
                    'Adjuntar llaves primarias
                    AdjuntarLlavesPrimariasDetalle()
                    _FormularioInformacionInterno.ShowDialog(Me)
            End Select
            'Recargar los datos
            If Not _ClaseDeConexion.Select_Datos(dtListadoDetalle, _FromDetalle, _SelectDetalle, _WhereDetalle & " " & _WhereLlavesPrimarias, _GroupByDetalle, _HavingDetalle, _OrderByDetalle, 0) Then
                MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
            Else
                dgvListado.DataSource = dtListadoDetalle
            End If
        End If
    End Sub

    Private Sub _ModificarDetalle() Handles btnModificar.Click
        If _FormularioInformacionInterno Is Nothing Then
            MsgBox("No se ha definido un formulario de información, por favor verificar (FormularioInformacion)", MsgBoxStyle.Critical)
        Else
            If dgvListado.CurrentRow Is Nothing Then
                MsgBox("Debe seleccionar un registro.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                _FormularioInformacionInterno.TipoDeOperacion = Operacion.Modificar
                'Adjuntar llaves primarias
                AdjuntarLlavesPrimarias()
                AdjuntarLlavesPrimariasDetalle()
                _FormularioInformacionInterno.ShowDialog(Me)
                'Recargar los datos
                If Not _ClaseDeConexion.Select_Datos(dtListadoDetalle, _FromDetalle, _SelectDetalle, _WhereDetalle & " " & _WhereLlavesPrimarias, _GroupByDetalle, _HavingDetalle, _OrderByDetalle, 0) Then
                    MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
                Else
                    dgvListado.DataSource = dtListadoDetalle
                End If
            End If
        End If
    End Sub

    Private Sub _EliminarDetalle() Handles btnEliminar.Click
        If _FormularioInformacionInterno Is Nothing Then
            MsgBox("No se ha definido un formulario de información, por favor verificar (FormularioInformacion)", MsgBoxStyle.Critical)
        Else
            If dgvListado.CurrentRow Is Nothing Then
                MsgBox("Debe seleccionar un registro.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                If MsgBox("Confirma eliminar el registro actual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Eliminar") = MsgBoxResult.Yes Then
                    _FormularioInformacionInterno.TipoDeOperacion = Operacion.Eliminar
                    'Adjuntar llaves primarias
                    AdjuntarLlavesPrimarias()
                    AdjuntarLlavesPrimariasDetalle()
                    _FormularioInformacionInterno.ShowDialog(Me)
                    'Recargar los datos
                    If Not _ClaseDeConexion.Select_Datos(dtListadoDetalle, _FromDetalle, _SelectDetalle, WhereDetalle & " " & _WhereLlavesPrimarias, _GroupByDetalle, _HavingDetalle, _OrderByDetalle, 0) Then
                        MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
                    Else
                        dgvListado.DataSource = dtListadoDetalle
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub AdjuntarLlavesPrimarias()
        For Each _Columna As Columna In _Columnas
            If _Columna Is Nothing Then Continue For
            If _Columna.EsLlavePrimaria Then
                _FormularioInformacionInterno.AgregarLlavePrimaria(_Columna.NombreCampo, dgvListado.Item(_Columna.NombreCampo, dgvListado.CurrentRow.Index).Value)
            End If
        Next
    End Sub
    Private Sub AdjuntarLlavesPrimariasDetalle()
        For Each _Columna As Columna In _Columnas
            If _Columna Is Nothing Then Continue For
            If _Columna.EsLlavePrimaria Then
                _FormularioInformacionInterno.AgregarLlavePrimariaDetalle(_Columna.NombreCampo, ObtenerLlavePrimaria(_Columna.NombreCampo))
            End If
        Next
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
                                    If Not _DataRow(_Columna.NombreCampo).ToString Is Nothing Then
                                        '_Columna.Control.TextAlign = _Columna.Alineacion

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
                                                Else
                                                    _Columna.Control.Text = _DataRow(_Columna.NombreCampo).ToString
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

    Private Sub FormatearGrid()
        Dim MyColumn As New System.Windows.Forms.DataGridViewTextBoxColumn
        dgvListado.Columns.Clear()
        dtBusqueda_01.Rows.Clear()

        dgvListado.RowsDefaultCellStyle.BackColor = Color.White
        dgvListado.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
        For Each MyCol As Columna In _Columnas
            If Not MyCol Is Nothing Then
                MyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
                MyColumn.HeaderText = MyCol.NombreMostrar
                MyColumn.Name = MyCol.NombreCampo
                MyColumn.DataPropertyName = MyCol.NombreCampo
                If MyCol.Formato <> "" Then MyColumn.DefaultCellStyle.Format = MyCol.Formato
                MyColumn.Width = MyCol.PorcentajeTamaño * (dgvListado.Width - 60) / 100
                If MyCol.PorcentajeTamaño = 0 Then MyColumn.Visible = False
                MyColumn.ReadOnly = True
                MyColumn.DefaultCellStyle.Alignment = MyCol.Alineacion
                'Agregar la Busqueda
                If MyCol.IncluirEnBusqueda Then dtBusqueda_01.Rows.Add(MyCol.NombreCampo, MyCol.NombreMostrar)
                dgvListado.Columns.Add(MyColumn)
                MyColumn.Dispose()
            End If
        Next
        If dtBusqueda_01.Rows.Count > 0 Then
            _ClaseDeConexion.Llenar_ComboBox(cmbBusqueda_01, dtBusqueda_01, "NOMBRE_CAMPO", "NOMBRE_MOSTRAR")
        End If
    End Sub

    Private Sub HabilitarMenu(ByVal ParEstado As Boolean)
        Select Case _TipoDeOperacion
            Case Operacion.Consultar
                btnConsultar.Enabled = IIf(btnConsultar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnConsultar.Tag) = 0, False, ParEstado), ParEstado)
                btnAgregar.Enabled = False
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
                btnImprimir.Enabled = IIf(btnImprimir.Tag <> "", IIf(InStr(_AccesosPermitidos, btnImprimir.Tag) = 0, False, ParEstado), ParEstado)
            Case Operacion.Agregar
                btnConsultar.Enabled = False
                btnAgregar.Enabled = IIf(btnAgregar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnAgregar.Tag) = 0, False, ParEstado), ParEstado)
                'btnModificar.Enabled = IIf(btnModificar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnModificar.Tag) = 0, False, ParEstado), ParEstado)
                'btnEliminar.Enabled = IIf(btnEliminar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnEliminar.Tag) = 0, False, ParEstado), ParEstado)
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
                btnImprimir.Enabled = False
            Case Operacion.Modificar
                btnConsultar.Enabled = IIf(btnConsultar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnConsultar.Tag) = 0, False, ParEstado), ParEstado)
                btnAgregar.Enabled = IIf(btnAgregar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnAgregar.Tag) = 0, False, ParEstado), ParEstado)
                btnModificar.Enabled = IIf(btnModificar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnModificar.Tag) = 0, False, ParEstado), ParEstado)
                btnEliminar.Enabled = IIf(btnEliminar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnEliminar.Tag) = 0, False, ParEstado), ParEstado)
                btnImprimir.Enabled = IIf(btnImprimir.Tag <> "", IIf(InStr(_AccesosPermitidos, btnImprimir.Tag) = 0, False, ParEstado), ParEstado)
            Case Operacion.Eliminar
                btnConsultar.Enabled = False
                btnAgregar.Enabled = False
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
                btnImprimir.Enabled = False
        End Select
    End Sub
#End Region

#Region "Procedimientos"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ReDim _LlavesPrimarias(0)
        _LlavesPrimariasDetalle = Nothing
        ReDim _Columnas(0)
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
            ReDim _Columnas(0)
            Me.Close()
            'Me.Dispose()
        Else
            If Not _Mensaje Is Nothing Then
                If _Mensaje.ToString.Length > 0 Then MsgBox(_Mensaje, MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub frmPlantillaInformacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ReDim _LlavesPrimarias(0)
        _LlavesPrimariasDetalle = Nothing
        ReDim _Columnas(0)
        _EtiquetaParaOperacion = ""
    End Sub

    Private Sub frmPlantillaInformacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtBusqueda_01.Columns.Clear()
        dtBusqueda_01.Columns.Add("NOMBRE_CAMPO")
        dtBusqueda_01.Columns.Add("NOMBRE_MOSTRAR")
    End Sub

    Private Sub dgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick
        If _MostrarBotonConsultar Then _ConsultarDetalle()
    End Sub

    Private Sub Filtrar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Dim _WhereInterno As String = _WhereLlavesPrimarias & " " & _WhereDetalle
        Me.Cursor = Cursors.WaitCursor
        Try
            If cmbBusqueda_01.SelectedValue.ToString <> "0" And txtBusqueda_01.Text.Trim.Length = 0 Then
                MsgBox("Debe indicar " & cmbBusqueda_01.Text & " a buscar.", MsgBoxStyle.Exclamation)
                Exit Sub
            Else
                If cmbBusqueda_01.SelectedValue.ToString <> "0" Then
                    If _ClaseDeConexion.Gestor = GestorDeBaseDeDatos.Oracle Then
                        _WhereInterno &= _WhereDetalle & " AND UPPER(" & cmbBusqueda_01.SelectedValue & ") LIKE '%" & txtBusqueda_01.Text & "%'"
                    Else
                        _WhereInterno &= _WhereDetalle & " AND UPPER(" & cmbBusqueda_01.SelectedValue & ") LIKE '%" & txtBusqueda_01.Text & "%'"
                    End If
                End If
            End If

            If _ClaseDeConexion.Select_Datos(dtListadoDetalle, _FromDetalle, _SelectDetalle, _WhereInterno, _GroupByDetalle, _HavingDetalle, _OrderByDetalle, 0) Then
                dgvListado.DataSource = dtListadoDetalle
            Else
                MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub txtBusqueda_01_GotFocus(sender As Object, e As EventArgs) Handles txtBusqueda_01.GotFocus
        Me.AcceptButton = btnFiltrar
    End Sub

    Private Sub txtBusqueda_01_LostFocus(sender As Object, e As EventArgs) Handles txtBusqueda_01.LostFocus
        Me.AcceptButton = btnAceptar
    End Sub

    Private Sub txtBusqueda_01_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBusqueda_01.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtBusqueda_01.Text = Replace(txtBusqueda_01.Text.ToUpper, "'", "-")
            Filtrar(sender, e)
        End If
        If e.KeyChar = ChrW(Keys.Return) Then
            txtBusqueda_01.Text = Replace(txtBusqueda_01.Text.ToUpper, "'", "-")
            Filtrar(sender, e)
        End If
    End Sub
#End Region

    Private Sub grpListado_Resize(sender As Object, e As EventArgs) Handles grpListado.Resize
        dgvListado.Height = grpListado.Height - 40
        dgvListado.Refresh()
    End Sub    
End Class