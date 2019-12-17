Public Class frmPlantillaListadoInformacion
    'Columnas de la grid
    Private _Columnas(0) As Columna
    Protected dtListado As New DataTable
    'Filtrar
    Private dtBusqueda_01 As New DataTable
    Private dtBusqueda_02 As New DataTable
    'Registros
    Private dtMostrarRegistros As New DataTable
    'Mensaje interno
    Protected _Mensaje As String

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

    'Mostrar los botones de Agregar, Modificar, Eliminar e Imprimir            
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
#End Region

#Region "Metodos publicos"
    Public Sub AgregarColumna(ByVal TextoAMostrar As String, ByVal NombreDelCampo As String, ByVal TamañoEnPorcentaje As Integer, ByVal ParaFiltrar As Boolean, ByVal Control As Object, ByVal Alineacion As DataGridViewContentAlignment, ByVal EditarAl As TipoDeEdicion, ByVal Formato As String, EsLlavePrimaria As Boolean)
        _Columnas(_Columnas.Length - 1) = New Columna(TextoAMostrar, NombreDelCampo, TamañoEnPorcentaje, ParaFiltrar, Control, Alineacion, EditarAl, Formato, TipoDeColumna.DataGridViewTextBoxColumn, EsLlavePrimaria)
        ReDim Preserve _Columnas(_Columnas.Length)
    End Sub

    Public Sub AgregarColumna(ByVal TextoAMostrar As String, ByVal NombreDelCampo As String, ByVal TamañoEnPorcentaje As Integer, ByVal ParaFiltrar As Boolean, ByVal Control As Object, ByVal Alineacion As DataGridViewContentAlignment, ByVal EditarAl As TipoDeEdicion)
        _Columnas(_Columnas.Length - 1) = New Columna(TextoAMostrar, NombreDelCampo, TamañoEnPorcentaje, ParaFiltrar, Control, Alineacion, EditarAl, "", TipoDeColumna.DataGridViewTextBoxColumn, False)
        ReDim Preserve _Columnas(_Columnas.Length)
    End Sub

    Protected Friend Sub InicializarFormulario()
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

        'Mostrar los botones indicados        
        btnAgregar.Visible = _MostrarBotonAgregar
        btnModificar.Visible = _MostrarBotonModificar
        btnEliminar.Visible = _MostrarBotonEliminar
        btnImprimir.Visible = _MostrarBotonImprimir
    End Sub

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

    Public Overridable Sub CargarDetalle()
    End Sub

    Public Overridable Sub Limpiar_Campos()
    End Sub
#End Region

#Region "Metodos privados"
    Private Sub FormatearGrid()
        Dim _ColumnaGrid As New System.Windows.Forms.DataGridViewTextBoxColumn
        dgvListado.Columns.Clear()
        cmbBusqueda_01.Items.Clear()
        dgvListado.RowsDefaultCellStyle.BackColor = Color.White
        dgvListado.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
        For Each _Col As Columna In _Columnas
            If Not _Col Is Nothing Then
                _ColumnaGrid = New System.Windows.Forms.DataGridViewTextBoxColumn
                _ColumnaGrid.HeaderText = _Col.NombreMostrar
                _ColumnaGrid.Name = _Col.NombreCampo
                _ColumnaGrid.DataPropertyName = _Col.NombreCampo
                If _Col.Formato <> "" Then _ColumnaGrid.DefaultCellStyle.Format = _Col.Formato
                _ColumnaGrid.Width = _Col.PorcentajeTamaño * (dgvListado.Width - 60) / 100
                If _Col.PorcentajeTamaño = 0 Then _ColumnaGrid.Visible = False
                _ColumnaGrid.ReadOnly = True
                _ColumnaGrid.DefaultCellStyle.Alignment = _Col.Alineacion
                'Agregar la Busqueda
                If _Col.IncluirEnBusqueda Then dtBusqueda_01.Rows.Add(_Col.NombreCampo, _Col.NombreMostrar)
                If _Col.IncluirEnBusqueda Then dtBusqueda_02.Rows.Add(_Col.NombreCampo, _Col.NombreMostrar)
                dgvListado.Columns.Add(_ColumnaGrid)
                _ColumnaGrid.Dispose()
            End If
        Next
        If dtBusqueda_01.Rows.Count > 0 Then
            _ClaseDeConexion.Llenar_ComboBox(cmbBusqueda_01, dtBusqueda_01, "NOMBRE_CAMPO", "NOMBRE_MOSTRAR")
            _ClaseDeConexion.Llenar_ComboBox(cmbBusqueda_02, dtBusqueda_02, "NOMBRE_CAMPO", "NOMBRE_MOSTRAR")
        End If
        _ClaseDeConexion.Llenar_ComboBox(cmbMostrarRegistros, dtMostrarRegistros, "CANTIDAD", "DESCRIPCION")
        cmbMostrarRegistros.SelectedValue = _MostrarRegistros
    End Sub

    Private Sub _Agregar() Handles btnAgregar.Click
        _TipoDeOperacion = Operacion.Agregar
        HabilitarMenu(False)
        HabilitarEdicion(True)
        tabListado.SelectedTab = tpInformacion
        Limpiar_Campos()
    End Sub

    Private Sub _Modificar() Handles btnModificar.Click
        If dgvListado.CurrentRow Is Nothing Then
            MsgBox("Seleccione un registro", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        _TipoDeOperacion = Operacion.Modificar
        HabilitarMenu(False)
        HabilitarEdicion(True)
        tabListado.SelectedTab = tpInformacion
    End Sub

    Private Sub _Eliminar() Handles btnEliminar.Click
        If dgvListado.CurrentRow Is Nothing Then
            MsgBox("Seleccione un registro", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If MsgBox("Confirma Eliminar el Registro Actual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Eliminar") = MsgBoxResult.Yes Then
            _TipoDeOperacion = Operacion.Eliminar
            HabilitarMenu(False)
            HabilitarEdicion(False)
            tabListado.SelectedTab = tpInformacion
        End If
    End Sub

    Private Sub HabilitarEdicion(ByVal ParEstado As Boolean)
        For Each MyCol As Columna In _Columnas
            If Not MyCol Is Nothing Then
                If Not MyCol.Control Is Nothing Then
                    If MyCol.EditarAl = TipoDeEdicion.Ninguna Or Not ParEstado Then
                        MyCol.Control.Enabled = False
                    ElseIf MyCol.EditarAl = TipoDeEdicion.AlAgregar And _TipoDeOperacion = Operacion.Agregar Then
                        MyCol.Control.Enabled = ParEstado
                    ElseIf MyCol.EditarAl = TipoDeEdicion.AlAgregar And _TipoDeOperacion = Operacion.Modificar Then
                        MyCol.Control.Enabled = False
                    ElseIf MyCol.EditarAl = TipoDeEdicion.AlModificar And _TipoDeOperacion = Operacion.Agregar Then
                        MyCol.Control.Enabled = ParEstado
                    ElseIf MyCol.EditarAl = TipoDeEdicion.AlModificar And _TipoDeOperacion = Operacion.Modificar Then
                        MyCol.Control.Enabled = ParEstado
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub HabilitarMenu(ByVal ParEstado As Boolean)
        btnAgregar.Enabled = IIf(btnModificar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnAgregar.Tag) = 0, False, ParEstado), ParEstado)
        btnModificar.Enabled = IIf(btnModificar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnModificar.Tag) = 0, False, ParEstado), ParEstado)
        btnEliminar.Enabled = IIf(btnEliminar.Tag <> "", IIf(InStr(_AccesosPermitidos, btnEliminar.Tag) = 0, False, ParEstado), ParEstado)

        btnSalir.Enabled = ParEstado
        btnAceptar.Enabled = Not ParEstado
        btnCancelar.Enabled = Not ParEstado
    End Sub

#End Region

#Region "Procedimientos"
    Private Sub tmpForma_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tabListado.SelectedTab = tpListado
        dtBusqueda_01.Columns.Clear()
        dtBusqueda_01.Columns.Add("NOMBRE_CAMPO")
        dtBusqueda_01.Columns.Add("NOMBRE_MOSTRAR")
        dtBusqueda_02.Columns.Clear()
        dtBusqueda_02.Columns.Add("NOMBRE_CAMPO")
        dtBusqueda_02.Columns.Add("NOMBRE_MOSTRAR")
        dtMostrarRegistros.Columns.Clear()
        dtMostrarRegistros.Columns.Add("CANTIDAD")
        dtMostrarRegistros.Columns.Add("DESCRIPCION")
        dtMostrarRegistros.Rows.Clear()
        dtMostrarRegistros.Rows.Add(25, "25 registros")
        dtMostrarRegistros.Rows.Add(50, "50 registros")
        dtMostrarRegistros.Rows.Add(100, "100 registros")
        dtMostrarRegistros.Rows.Add(200, "200 registros")
        dtMostrarRegistros.Rows.Add(500, "500 registros")
        dtMostrarRegistros.Rows.Add(0, "Todos los registros")
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
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
        End Select

        If Resultado Then
            tabListado.SelectedTab = tpListado
            _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, _Where, _GroupBy, _Having, _OrderBy, _MostrarRegistros)
            FormatearGrid()
            HabilitarMenu(True)
            HabilitarEdicion(False)
            _TipoDeOperacion = Operacion.Consultar
        Else
            If Not _Mensaje Is Nothing Then
                If _Mensaje.ToString.Length > 0 Then MsgBox(_Mensaje, MsgBoxStyle.Critical, "Error")
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        HabilitarMenu(True)
        HabilitarEdicion(False)
        tabListado.SelectedTab = tpListado
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim MyWhere As String = _Where
        Me.Cursor = Cursors.WaitCursor
        Try
            _MostrarRegistros = cmbMostrarRegistros.SelectedValue
            If cmbBusqueda_01.SelectedValue.ToString <> "0" And txtBusqueda_01.Text.Trim.Length = 0 Then
                MsgBox("Debe indicar " & cmbBusqueda_01.Text & " a buscar.", MsgBoxStyle.Exclamation)
                Exit Sub
            ElseIf cmbBusqueda_02.SelectedValue.ToString <> "0" And txtBusqueda_02.Text.Trim.Length = 0 Then
                MsgBox("Debe indicar " & cmbBusqueda_02.Text & " a buscar.", MsgBoxStyle.Exclamation)
                Exit Sub
            Else
                If cmbBusqueda_01.SelectedValue.ToString <> "0" Then
                    If IsNumeric(txtBusqueda_01.Text) Then
                        MyWhere &= _Where & " AND " & cmbBusqueda_01.SelectedValue & " = " & txtBusqueda_01.Text
                    Else
                        If _ClaseDeConexion.Tipo_de_Base_de_Datos = GestorDeBaseDeDatos.Oracle Then
                            MyWhere &= _Where & " AND UPPER(" & cmbBusqueda_01.SelectedValue & ") LIKE '%" & txtBusqueda_01.Text & "%'"
                        Else
                            MyWhere &= _Where & " AND UPPER(" & cmbBusqueda_01.SelectedValue & ") LIKE '%" & txtBusqueda_01.Text & "%'"
                        End If
                    End If
                End If
                If cmbBusqueda_02.SelectedValue.ToString <> "0" Then
                    If IsNumeric(txtBusqueda_01.Text) Then
                        MyWhere &= _Where & " AND " & cmbBusqueda_02.SelectedValue & " = " & txtBusqueda_02.Text
                    Else
                        If _ClaseDeConexion.Tipo_de_Base_de_Datos = GestorDeBaseDeDatos.Oracle Then
                            MyWhere &= _Where & " AND UPPER(" & cmbBusqueda_02.SelectedValue & ") LIKE '%" & txtBusqueda_02.Text & "%'"
                        Else
                            MyWhere &= _Where & " AND UPPER(" & cmbBusqueda_02.SelectedValue & ") LIKE '%" & txtBusqueda_02.Text & "%'"
                        End If
                    End If
                End If
            End If

            If _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, MyWhere, _GroupBy, _Having, _OrderBy, _MostrarRegistros) Then
                dgvListado.DataSource = dtListado
            Else
                MsgBox(_ClaseDeConexion.Mensaje, MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmbBusqueda_01_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBusqueda_01.SelectedValueChanged, cmbBusqueda_02.SelectedValueChanged
        If sender.GetType.ToString Is Nothing Then Exit Sub
        If sender.SelectedValue.ToString = "" Or sender.SelectedValue.ToString = "0" Then
            Select Case sender.Name
                Case "cmbBusqueda_01"
                    txtBusqueda_01.Text = ""
                Case "cmbBusqueda_02"
                    txtBusqueda_02.Text = ""
            End Select
        End If
    End Sub

    Private Sub txtBusqueda_01_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBusqueda_01.KeyPress, txtBusqueda_02.KeyPress, cmbBusqueda_01.KeyPress, cmbBusqueda_02.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtBusqueda_01.Text = Replace(txtBusqueda_01.Text.ToUpper, "'", "-")
            txtBusqueda_02.Text = Replace(txtBusqueda_02.Text.ToUpper, "'", "-")
            btnBuscar_Click(sender, e)
        End If
        If e.KeyChar = ChrW(Keys.Return) Then
            txtBusqueda_01.Text = Replace(txtBusqueda_01.Text.ToUpper, "'", "-")
            txtBusqueda_02.Text = Replace(txtBusqueda_02.Text.ToUpper, "'", "-")
        End If
    End Sub

    Private Sub dgvListado_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellDoubleClick
        If Not dgvListado.CurrentRow Is Nothing Then
            Me.tabListado.SelectedTab = tpInformacion
        End If
    End Sub

    Private Sub cmbMostrarRegistros_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMostrarRegistros.SelectedValueChanged
        If sender.GetType.ToString Is Nothing Then Exit Sub
        If sender.SelectedValue.ToString = "System.Data.DataRowView" Then Exit Sub
        If sender.SelectedValue.ToString <> "" Then
            '_Registros = sender.SelectedValue
        End If
    End Sub

    Private Sub dgvListado_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.RowEnter
        Try
            If dgvListado Is Nothing Then Exit Sub
            If dgvListado.CurrentRow Is Nothing Then Exit Sub
            If e.RowIndex < 0 Then Exit Sub
            For Each MyCol As Columna In _Columnas
                If Not MyCol Is Nothing Then
                    If Not MyCol.Control Is Nothing Then
                        Select Case MyCol.Control.GetType.Name
                            Case "TextBox", "MaskedTextBox"
                                If Not dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value Is Nothing Then
                                    If MyCol.Formato = "" Then
                                        MyCol.Control.Text = dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value.ToString
                                    Else
                                        If IsNumeric(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value) Then
                                            MyCol.Control.Text = Format(CDbl(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value), MyCol.Formato)
                                        ElseIf IsDate(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value) Then
                                            MyCol.Control.Text = Format(CDate(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value), MyCol.Formato)
                                        Else
                                            MyCol.Control.Text = Format(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value.ToString, MyCol.Formato)
                                        End If
                                    End If
                                End If
                            Case "DateTimePicker"
                                If Not dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value Is Nothing Then
                                    MyCol.Control.Value = dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value.ToString
                                End If
                            Case "ComboBox"
                                If Not MyCol.Control Is Nothing Then
                                    MyCol.Control.SelectedValue = dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value.ToString
                                End If
                        End Select
                    End If
                End If
            Next
            CargarDetalle()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "dgvListado_RowEnter")
        End Try
    End Sub

    Private Sub tpInformacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpInformacion.Enter
        Try
            If dgvListado Is Nothing Then Exit Sub
            If dgvListado.CurrentRow Is Nothing Then Exit Sub
            If _TipoDeOperacion = Operacion.Eliminar Or _TipoDeOperacion = Operacion.Modificar Or _TipoDeOperacion = Operacion.Consultar Then
                For Each MyCol As Columna In _Columnas
                    If Not MyCol Is Nothing And Not dgvListado.CurrentRow Is Nothing Then
                        If Not MyCol.Control Is Nothing Then
                            Select Case MyCol.Control.GetType.Name
                                Case "TextBox", "MaskedTextBox"
                                    If Not dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value Is Nothing Then
                                        If MyCol.Formato = "" Then
                                            MyCol.Control.Text = dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value.ToString
                                        Else
                                            If IsNumeric(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value) Then
                                                MyCol.Control.Text = Format(CDbl(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value), MyCol.Formato)
                                            ElseIf IsDate(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value) Then
                                                MyCol.Control.Text = Format(CDate(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value), MyCol.Formato)
                                            Else
                                                MyCol.Control.Text = Format(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value.ToString, MyCol.Formato)
                                            End If
                                        End If
                                    End If
                                Case "DateTimePicker"
                                    If Not dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value Is Nothing Then
                                        MyCol.Control.Value = dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value.ToString
                                    End If
                                Case "ComboBox"
                                    If Not MyCol.Control Is Nothing Then
                                        MyCol.Control.SelectedValue = dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value.ToString
                                    End If
                            End Select
                        End If
                    End If
                Next
                CargarDetalle()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "tpInformacion_Enter")
        End Try
    End Sub

    Private Sub tabListado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabListado.SelectedIndexChanged
        If Not tabListado.SelectedTab Is tabListado Then
            Try
                If dgvListado Is Nothing Then Exit Sub
                If dgvListado.CurrentRow Is Nothing Then Exit Sub
                If _TipoDeOperacion = Operacion.Eliminar Or _TipoDeOperacion = Operacion.Modificar Or _TipoDeOperacion = Operacion.Consultar Then
                    For Each MyCol As Columna In _Columnas
                        If Not MyCol Is Nothing And Not dgvListado.CurrentRow Is Nothing Then
                            If Not MyCol.Control Is Nothing Then
                                Select Case MyCol.Control.GetType.Name
                                    Case "TextBox", "MaskedTextBox"
                                        If Not dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value Is Nothing Then
                                            If MyCol.Formato = "" Then
                                                MyCol.Control.Text = dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value.ToString
                                            Else
                                                If IsNumeric(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value) Then
                                                    MyCol.Control.Text = Format(CDbl(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value), MyCol.Formato)
                                                ElseIf IsDate(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value) Then
                                                    MyCol.Control.Text = Format(CDate(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value), MyCol.Formato)
                                                Else
                                                    MyCol.Control.Text = Format(dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value.ToString, MyCol.Formato)
                                                End If
                                            End If
                                        End If
                                    Case "DateTimePicker"
                                        If Not dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value Is Nothing Then
                                            MyCol.Control.Value = dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value.ToString
                                        End If
                                    Case "ComboBox"
                                        If Not MyCol.Control Is Nothing Then
                                            MyCol.Control.SelectedValue = dgvListado.Item(MyCol.NombreCampo, dgvListado.CurrentRow.Index).Value.ToString
                                        End If
                                End Select
                            End If
                        End If
                    Next
                    CargarDetalle()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "tpInformacion_Enter")
            End Try
        End If
    End Sub
#End Region
End Class