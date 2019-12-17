Public Class frmPlantillaListadoNew
    'Columnas de la grid
    Private _Columnas(0) As Columna
    Protected dtListado As New DataTable
    'Filtrar
    'Private dtBusqueda_01 As New DataTable
    'Private dtBusqueda_02 As New DataTable

    Private dtParametros As New DataTable
    'Registros
    Private dtMostrarRegistros As New DataTable
    ' Formulario generico
    Private _FormularioInformacionInterno As Object
    'Private _TotalDeRegistros As New ToolTip

#Region "Propiedades"
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


    Private _FormularioFiltrarParametros As New frmPlantillaFiltrarParametros
    Public Property FormularioFiltrarParametros() As frmPlantillaFiltrarParametros
        Get
            Return _FormularioFiltrarParametros
        End Get
        Set(ByVal value As frmPlantillaFiltrarParametros)
            _FormularioFiltrarParametros = value
        End Set
    End Property

    'Mostrar los botones de Agregar, Modificar, Eliminar e Imprimir    
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

    Private _MostrarBotonAplicar As Boolean
    Public Property MostratBotonAplicar() As Boolean
        Get
            Return _MostrarBotonAplicar
        End Get
        Set(ByVal value As Boolean)
            _MostrarBotonAplicar = value
        End Set
    End Property

    Private _MostrarBotonDesaplicar As Boolean
    Public Property MostrarBotonDesaplicar() As Boolean
        Get
            Return _MostrarBotonDesaplicar
        End Get
        Set(ByVal value As Boolean)
            _MostrarBotonDesaplicar = value
        End Set
    End Property

    Private _MostrarBotonCerrar As Boolean
    Public Property MostrarBotonCerrar() As Boolean
        Get
            Return _MostrarBotonCerrar
        End Get
        Set(ByVal value As Boolean)
            _MostrarBotonCerrar = value
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

    Private _MostrarRegistros As Integer = 50
    Public Property MostrarRegistros() As String
        Get
            Return _MostrarRegistros
        End Get
        Set(ByVal value As String)
            _MostrarRegistros = value
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

    ' Vista histórica depende del año
    Private _AñoDeOperacion As Integer = 0
    Public Property AñoDeOperacion() As Integer
        Get
            Return _AñoDeOperacion
        End Get
        Set(ByVal value As Integer)
            _AñoDeOperacion = value
        End Set
    End Property

    Private _AñoDeServidor As Integer
    Public Property AñoDeServidor() As Integer
        Get
            Return _AñoDeServidor
        End Get
        Set(ByVal value As Integer)
            _AñoDeServidor = value
        End Set
    End Property
    

#End Region

#Region "Métodos publicos"
    Public Sub AgregarColumna(ByVal TextoAMostrar As String, ByVal NombreDelCampo As String, ByVal TamañoEnPorcentaje As Integer, ByVal ParaFiltrar As Boolean, ByVal Alineacion As DataGridViewContentAlignment, ByVal Formato As String, EsLlavePrimaria As Boolean)
        _Columnas(_Columnas.Length - 1) = New Columna(TextoAMostrar, NombreDelCampo, TamañoEnPorcentaje, ParaFiltrar, Nothing, Alineacion, TipoDeEdicion.Ninguna, Formato, TipoDeColumna.DataGridViewTextBoxColumn, EsLlavePrimaria)
        ReDim Preserve _Columnas(_Columnas.Length)
    End Sub

    Public Sub AgregarColumna(ByVal TextoAMostrar As String, ByVal NombreDelCampo As String, ByVal TamañoEnPorcentaje As Integer, ByVal ParaFiltrar As Boolean, ByVal Alineacion As DataGridViewContentAlignment, EsLlavePrimaria As Boolean)
        _Columnas(_Columnas.Length - 1) = New Columna(TextoAMostrar, NombreDelCampo, TamañoEnPorcentaje, ParaFiltrar, Nothing, Alineacion, TipoDeEdicion.Ninguna, "", TipoDeColumna.DataGridViewTextBoxColumn, EsLlavePrimaria)
        ReDim Preserve _Columnas(_Columnas.Length)
    End Sub

    Protected Friend Sub InicializarFormulario()
        Try
            'Identificacion del formulario
            Me.Text = _NombreDeFormulario & " [" & _SiglasDelSistema & "_FRM" & Format(_NumeroDeFormulario, "0000") & "]"
            'Verificar la clase de conexion
            If _ClaseDeConexion Is Nothing Then
                MsgBox("No se ha definido una clase de conexión, por favor verificar (ClaseDeConexion)", MsgBoxStyle.Critical)
            Else
                'Formato y datos del grid
                FormatearGrid()
                If Not _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, _Where, _GroupBy, _Having, _OrderBy, _MostrarRegistros) Then
                    MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
                Else
                    dgvListado.DataSource = dtListado
                End If
            End If

            'Aplicar los permisos
            If _AccesosPermitidos = "" Then
                MsgBox("No se ha definido permisos, por favor verificar (AccesosPermitidos)", MsgBoxStyle.Critical)
            Else
                HabilitarMenu(True)
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
            If _AñoDeOperacion < _AñoDeServidor Then
                btnConsultar.Visible = False
                btnAgregar.Visible = False
                btnModificar.Visible = False
                btnEliminar.Visible = False
                btnAplicar.Visible = False
                btnDesaplicar.Visible = False
                btnCerrar.Visible = False
            Else
                btnConsultar.Visible = _MostrarBotonConsultar
                btnAgregar.Visible = _MostrarBotonAgregar
                btnModificar.Visible = _MostrarBotonModificar
                btnEliminar.Visible = _MostrarBotonEliminar
                btnAplicar.Visible = _MostrarBotonAplicar
                btnDesaplicar.Visible = _MostrarBotonDesaplicar
                btnCerrar.Visible = _MostrarBotonCerrar
            End If
            btnImprimir.Visible = _MostrarBotonImprimir

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "InicializarFormulario")
        End Try
    End Sub

    Public Overridable Function Aplicar() As Boolean Handles btnAplicar.Click
        Return True
    End Function

    Public Overridable Function Desaplicar() As Boolean Handles btnDesaplicar.Click
        Return True
    End Function

    Public Overridable Function Cerrar() As Boolean Handles btnCerrar.Click
        Return True
    End Function
    Public Overridable Function Imprimir() As Boolean Handles btnImprimir.Click
        Return True
    End Function

    Public Overridable Sub CargarDetalle()
    End Sub

    Public Sub ActualizarFormulario()
        Filtrar(Nothing, Nothing)
        'Adjuntar llaves primarias
        AdjuntarLlavesPrimarias()
    End Sub
#End Region

#Region "Métodos privados"
    Private Sub FormatearGrid()
        Dim MyColumn As New System.Windows.Forms.DataGridViewTextBoxColumn
        dgvListado.Columns.Clear()
        'dtBusqueda_01.Rows.Clear()


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
                ' If MyCol.IncluirEnBusqueda Then dtBusqueda_01.Rows.Add(MyCol.NombreCampo, MyCol.NombreMostrar)
                'If MyCol.IncluirEnBusqueda Then dtBusqueda_02.Rows.Add(MyCol.NombreCampo, MyCol.NombreMostrar)
                dgvListado.Columns.Add(MyColumn)
                MyColumn.Dispose()
            End If
        Next
        'If dtBusqueda_01.Rows.Count > 0 Then
        '    _ClaseDeConexion.Llenar_ComboBox(cmbBusqueda_01, dtBusqueda_01, "NOMBRE_CAMPO", "NOMBRE_MOSTRAR")
        '    _ClaseDeConexion.Llenar_ComboBox(cmbBusqueda_02, dtBusqueda_02, "NOMBRE_CAMPO", "NOMBRE_MOSTRAR")
        'End If
        _ClaseDeConexion.Llenar_ComboBox(cmbMostrarRegistros, dtMostrarRegistros, "CANTIDAD", "DESCRIPCION")
        cmbMostrarRegistros.SelectedValue = _MostrarRegistros
    End Sub

    Private Sub _Agregar() Handles btnAgregar.Click
        'Verificar si hay formulario de informacion
        If _FormularioInformacionInterno Is Nothing Then
            MsgBox("No se ha definido un formulario de información, por favor verificar (FormularioInformacion)", MsgBoxStyle.Critical)
        Else
            _FormularioInformacionInterno.TipoDeOperacion = Operacion.Agregar
            _FormularioInformacionInterno.ShowDialog(Me)
            'Recargar los datos
            If Not _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, _Where, _GroupBy, _Having, _OrderBy, _MostrarRegistros) Then
                MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
            Else
                dgvListado.DataSource = dtListado
            End If
        End If
    End Sub

    Private Sub _Modificar() Handles btnModificar.Click
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
                _FormularioInformacionInterno.ShowDialog(Me)
                'Recargar los datos
                If Not _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, _Where, _GroupBy, _Having, _OrderBy, _MostrarRegistros) Then
                    MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
                Else
                    dgvListado.DataSource = dtListado
                End If
            End If
        End If
    End Sub

    Private Sub _Eliminar() Handles btnEliminar.Click
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
                    _FormularioInformacionInterno.ShowDialog(Me)
                    'Recargar los datos
                    If Not _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, _Where, _GroupBy, _Having, _OrderBy, _MostrarRegistros) Then
                        MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
                    Else
                        dgvListado.DataSource = dtListado
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub _Consultar() Handles btnConsultar.Click
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

    Private Sub HabilitarMenu(ByVal estado As Boolean)
        btnAgregar.Enabled = IIf(btnModificar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnAgregar.Tag) = 0, False, estado), estado)
        btnModificar.Enabled = IIf(btnModificar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnModificar.Tag) = 0, False, estado), estado)
        btnEliminar.Enabled = IIf(btnEliminar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnEliminar.Tag) = 0, False, estado), estado)
        btnImprimir.Enabled = IIf(btnImprimir.Tag <> "", IIf(InStr(_AccesosPermitidos, btnImprimir.Tag) = 0, False, estado), estado)

        btnAplicar.Enabled = IIf(btnAplicar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnAplicar.Tag) = 0, False, estado), estado)
        btnDesaplicar.Enabled = IIf(btnDesaplicar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnDesaplicar.Tag) = 0, False, estado), estado)
        btnCerrar.Enabled = IIf(btnCerrar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnCerrar.Tag) = 0, False, estado), estado)

        btnSalir.Enabled = estado
    End Sub

    Private Sub AdjuntarLlavesPrimarias()
        _FormularioInformacionInterno.LimpiarLlavesPrimarias()
        For Each _Columna As Columna In _Columnas
            If _Columna Is Nothing Then Continue For
            If _Columna.EsLlavePrimaria Then

                _FormularioInformacionInterno.AgregarLlavePrimaria(_Columna.NombreCampo, dgvListado.Item(_Columna.NombreCampo, dgvListado.CurrentRow.Index).Value)
            End If
        Next
    End Sub
#End Region

#Region "Procedimientos"

    Private Sub frmPlantillaListadoNew_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            'If e.KeyCode = Keys.Add Then
            '    btnAgregarFiltro_Click(Nothing, Nothing)
            'ElseIf e.KeyCode = Keys.Subtract Then
            '    btnEliminarFiltro_Click(Nothing, Nothing)
            'End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "frmPlantillaListado_KeyDown")
        End Try
    End Sub

    Private Sub frmPlantillaListado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dtBusqueda_01.Columns.Clear()
        'dtBusqueda_01.Columns.Add("NOMBRE_CAMPO")
        'dtBusqueda_01.Columns.Add("NOMBRE_MOSTRAR")

        dtMostrarRegistros.Columns.Clear()
        dtMostrarRegistros.Columns.Add("CANTIDAD")
        dtMostrarRegistros.Columns.Add("DESCRIPCION")
        dtMostrarRegistros.Rows.Clear()
        

        dtMostrarRegistros.Rows.Add(25, "25 registros")
        dtMostrarRegistros.Rows.Add(50, "50 registros")
        dtMostrarRegistros.Rows.Add(100, "100 registros")
        dtMostrarRegistros.Rows.Add(200, "200 registros")
        dtMostrarRegistros.Rows.Add(500, "500 registros")
        dtMostrarRegistros.Rows.Add(0, "Todos")
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub dgvListado_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.RowEnter
        Try
            If dgvListado Is Nothing Then Exit Sub
            If dgvListado.CurrentRow Is Nothing Then Exit Sub
            If e.RowIndex < 0 Then Exit Sub
            CargarDetalle()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "dgvListado_RowEnter")
        End Try
    End Sub

    Private Sub Filtrar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Dim MyWhere As String = _Where
        Me.Cursor = Cursors.WaitCursor
        Try
            _MostrarRegistros = cmbMostrarRegistros.SelectedValue
            'If cmbBusqueda_01.SelectedValue.ToString <> "0" And txtBusqueda_01.Text.Trim.Length = 0 Then
            '    MsgBox("Debe indicar " & cmbBusqueda_01.Text & " a buscar.", MsgBoxStyle.Exclamation)
            '    Exit Sub
            'ElseIf cmbBusqueda_02.SelectedValue.ToString <> "0" And txtBusqueda_02.Text.Trim.Length = 0 Then
            '    MsgBox("Debe indicar " & cmbBusqueda_02.Text & " a buscar.", MsgBoxStyle.Exclamation)
            '    Exit Sub
            'Else
            '    If cmbBusqueda_01.SelectedValue.ToString <> "0" Then
            '        If _ClaseDeConexion.Gestor = GestorDeBaseDeDatos.Oracle Then
            '            MyWhere &= _Where & " AND UPPER(" & cmbBusqueda_01.SelectedValue & ") LIKE '%" & txtBusqueda_01.Text & "%'"
            '        Else
            '            MyWhere &= _Where & " AND UPPER(" & cmbBusqueda_01.SelectedValue & ") LIKE '%" & txtBusqueda_01.Text & "%'"
            '        End If
            '    End If
            '    If cmbBusqueda_02.SelectedValue.ToString <> "0" Then
            '        If _ClaseDeConexion.Gestor = GestorDeBaseDeDatos.Oracle Then
            '            MyWhere &= _Where & " AND UPPER(" & cmbBusqueda_02.SelectedValue & ") LIKE '%" & txtBusqueda_02.Text & "%'"
            '        Else
            '          MyWhere &= _Where & " AND UPPER(" & cmbBusqueda_02.SelectedValue & ") LIKE '%" & txtBusqueda_02.Text & "%'"
            '        End If
            '    End If
            'End If
            'Se recorre el grid de filtros


            Dim frmParametros As New frmPlantillaFiltrarParametros
            frmParametros._ClaseDeConexion = _ClaseDeConexion
            frmParametros.ColColumnasFiltros.Add(_Columnas)

            If dtParametros.Rows.Count > 0 Then
                frmParametros.dtParametrosFiltros = dtParametros
            End If
            frmParametros.ShowDialog()

            If Not frmParametros.dtParametrosFiltros Is Nothing Then
                If frmParametros.dtParametrosFiltros.Rows.Count > 0 Then
                    dtParametros = frmParametros.dtParametrosFiltros
                    For Each row As DataRow In dtParametros.Rows
                        Dim _Operador As String = ""
                        If row("OperadorCodigo") = "1" Then
                            MyWhere &= " AND  UPPER(" & row("ColumnaCodigo") & ") = '" & row("Valor") & "'"
                        ElseIf row("OperadorCodigo") = "2" Then
                            MyWhere &= " AND UPPER(" & row("ColumnaCodigo") & ") <> '" & row("Valor") & "'"
                        ElseIf row("OperadorCodigo") = "3" Then
                            MyWhere &= " AND UPPER(" & row("ColumnaCodigo") & ") > '" & row("Valor") & "'"
                        ElseIf row("OperadorCodigo") = "4" Then
                            MyWhere &= " AND UPPER(" & row("ColumnaCodigo") & ") >= '" & row("Valor") & "'"
                        ElseIf row("OperadorCodigo") = "5" Then
                            MyWhere &= " AND UPPER(" & row("ColumnaCodigo") & ") < '" & row("Valor") & "'"
                        ElseIf row("OperadorCodigo") = "6" Then
                            MyWhere &= " AND UPPER(" & row("ColumnaCodigo") & ") <= '" & row("Valor") & "'"
                        ElseIf row("OperadorCodigo") = "7" Then
                            MyWhere &= " AND UPPER(" & row("ColumnaCodigo") & ") LIKE '" & row("Valor") & "%'"
                        ElseIf row("OperadorCodigo") = "8" Then
                            MyWhere &= " AND UPPER(" & row("ColumnaCodigo") & ") LIKE '%" & row("Valor") & "'"
                        ElseIf row("OperadorCodigo") = "9" Then
                            MyWhere &= " AND UPPER(" & row("ColumnaCodigo") & ") LIKE '%" & row("Valor") & "%'"
                        ElseIf row("OperadorCodigo") = "10" Then
                            MyWhere &= " AND UPPER(" & row("ColumnaCodigo") & ") BETWEEN '" & row("Valor") & "' AND '" & row("A valor") & "'"
                        End If
                    Next
                    btnFiltrar.BackColor = Color.Silver
                Else
                    btnFiltrar.BackColor = Color.Transparent

                End If
            End If
           
            If (_ClaseDeConexion.Select_Datos(dtListado, _From, _Select, MyWhere, _GroupBy, _Having, _OrderBy, _MostrarRegistros)) Then
                dgvListado.DataSource = dtListado

            Else
                MsgBox(_ClaseDeConexion.mensaje, MsgBoxStyle.Exclamation, "Error")
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    'Private Sub cmbBusqueda_01_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If sender.GetType.ToString Is Nothing Then Exit Sub
    '    If sender.SelectedValue.ToString = "" Or sender.SelectedValue.ToString = "0" Then
    '        Select Case sender.Name
    '            Case "cmbBusqueda_01"
    '                txtBusqueda_01.Text = ""
    '            Case "cmbBusqueda_02"
    '                txtBusqueda_02.Text = ""
    '        End Select
    '    End If
    'End Sub

    'Private Sub txtBusqueda_01_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        txtBusqueda_01.Text = Replace(txtBusqueda_01.Text.ToUpper, "'", "-")
    '        txtBusqueda_02.Text = Replace(txtBusqueda_02.Text.ToUpper, "'", "-")
    '        Filtrar(sender, e)
    '    End If
    '    If e.KeyChar = ChrW(Keys.Return) Then
    '        txtBusqueda_01.Text = Replace(txtBusqueda_01.Text.ToUpper, "'", "-")
    '        txtBusqueda_02.Text = Replace(txtBusqueda_02.Text.ToUpper, "'", "-")
    '        Filtrar(sender, e)
    '    End If
    'End Sub

    Private Sub dgvListado_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick
        If _MostrarBotonConsultar Then
            _Consultar()
        End If
    End Sub

    Private Sub cmbMostrarRegistros_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.GetType.ToString Is Nothing Then Exit Sub
        If sender.SelectedValue.ToString = "System.Data.DataRowView" Then Exit Sub
        If sender.SelectedValue.ToString <> "" Then
            '_Registros = sender.SelectedValue
        End If
    End Sub


  

#End Region


    Private Function FindItems(ByVal strSearchString As String) As Boolean
        dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvListado.ClearSelection()

        For Each myRow As DataGridViewRow In dgvListado.Rows
            For Each myCell As DataGridViewCell In myRow.Cells
                If InStr(myCell.Value.ToString, strSearchString) Then
                    myRow.Selected = True
                    Return True
                End If
            Next
        Next
        Return False

    End Function



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        FindItems(txtBuscar.Text)
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
End Class