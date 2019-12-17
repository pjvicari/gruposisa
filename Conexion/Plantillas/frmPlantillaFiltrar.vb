Public Class frmPlantillaFiltrar
    'Columnas de la grid
    Private _Columnas(0) As Columna
    Protected dtListado As New DataTable
    'Filtrar
    Private dtBusqueda_01 As New DataTable
    Private dtBusqueda_02 As New DataTable
    'Registros
    Private dtMostrarRegistros As New DataTable

#Region "Propiedades"
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

    Private _MostrarRegistros As Integer = 50
    Public Property MostrarRegistros() As String
        Get
            Return _MostrarRegistros
        End Get
        Set(ByVal value As String)
            _MostrarRegistros = value
        End Set
    End Property

    Private _FilaSeleccionada As DataGridViewRow
    Public ReadOnly Property FilaSeleccionada() As DataGridViewRow
        Get
            Return _FilaSeleccionada
        End Get
    End Property
#End Region

#Region "Metodos publicos"
    Public Sub AgregarColumna(ByVal ParNombreMostrar As String, ByVal ParNombreCampo As String, ByVal ParPorcentajeTamaño As Integer, ByVal ParBusqueda As Boolean, ByVal ParAliniacion As DataGridViewContentAlignment, ByVal ParFormato As String)
        _Columnas(_Columnas.Length - 1) = New Columna(ParNombreMostrar, ParNombreCampo, ParPorcentajeTamaño, ParBusqueda, Nothing, ParAliniacion, TipoDeEdicion.Ninguna, ParFormato, TipoDeColumna.DataGridViewTextBoxColumn, False)
        ReDim Preserve _Columnas(_Columnas.Length)
    End Sub

    Protected Friend Sub InicializarFormulario()
        Me.Text = _NombreDeFormulario & " [" & _SiglasDelSistema & "_FRM" & Format(_NumeroDeFormulario, "0000") & "]"
        FormatearGrid()
        If _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, _Where, _GroupBy, _Having, _OrderBy, _MostrarRegistros) Then
            dgvListado.DataSource = dtListado
        Else
            MsgBox("Error: " & _ClaseDeConexion.Mensaje, MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region

#Region "Metodos privados"
    Private Sub FormatearGrid()
        Dim MyColumn As New System.Windows.Forms.DataGridViewTextBoxColumn
        dgvListado.Columns.Clear()
        dtBusqueda_01.Rows.Clear()
        dtBusqueda_02.Rows.Clear()

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
                If MyCol.IncluirEnBusqueda Then dtBusqueda_02.Rows.Add(MyCol.NombreCampo, MyCol.NombreMostrar)
                dgvListado.Columns.Add(MyColumn)
                MyColumn.Dispose()
            End If
        Next
        If dtBusqueda_01.Rows.Count > 0 Then
            _ClaseDeConexion.Llenar_ComboBox(cmbBusqueda_01, dtBusqueda_01, "NOMBRE_CAMPO", "NOMBRE_MOSTRAR")
            _ClaseDeConexion.Llenar_ComboBox(cmbBusqueda_02, dtBusqueda_02, "NOMBRE_CAMPO", "NOMBRE_MOSTRAR")
        End If        
        _ClaseDeConexion.Llenar_ComboBox(cmbMostrarRegistros, dtMostrarRegistros, "CANTIDAD", "DESCRIPCION")
        cmbMostrarRegistros.SelectedValue = _MostrarRegistros
    End Sub
#End Region

#Region "Procedimientos"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub tmpPlantillaFiltrar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub Filtrar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
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
                    If _ClaseDeConexion.Gestor = GestorDeBaseDeDatos.Oracle Then
                        MyWhere &= _Where & " AND UPPER(" & cmbBusqueda_01.SelectedValue & ") LIKE '%" & txtBusqueda_01.Text.ToUpper & "%'"
                    Else
                        MyWhere &= _Where & " AND UPPER(" & cmbBusqueda_01.SelectedValue & ") LIKE '%" & txtBusqueda_01.Text.ToUpper & "%'"
                    End If
                End If
                If cmbBusqueda_02.SelectedValue.ToString <> "0" Then
                    If _ClaseDeConexion.Gestor = GestorDeBaseDeDatos.Oracle Then
                        MyWhere &= _Where & " AND UPPER(" & cmbBusqueda_02.SelectedValue & ") LIKE '%" & txtBusqueda_02.Text.ToUpper & "%'"
                    Else
                        MyWhere &= _Where & " AND UPPER(" & cmbBusqueda_02.SelectedValue & ") LIKE '%" & txtBusqueda_02.Text.ToUpper & "%'"
                    End If
                End If
            End If

            If _ClaseDeConexion.Select_Datos(dtListado, _From, _Select, MyWhere, _GroupBy, _Having, _OrderBy, _MostrarRegistros) Then
                dgvListado.DataSource = dtListado
            Else
                MsgBox("Error: " & _ClaseDeConexion.Mensaje, MsgBoxStyle.Exclamation)
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

    Private Sub txtBusqueda_01_GotFocus(sender As Object, e As EventArgs) Handles txtBusqueda_01.GotFocus, txtBusqueda_02.GotFocus
        Me.AcceptButton = btnFiltrar
    End Sub

    Private Sub txtBusqueda_01_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBusqueda_01.KeyPress, txtBusqueda_02.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtBusqueda_01.Text = Replace(txtBusqueda_01.Text.ToUpper, "'", "-")
            txtBusqueda_02.Text = Replace(txtBusqueda_02.Text.ToUpper, "'", "-")
            Filtrar(sender, e)
        End If
        If e.KeyChar = ChrW(Keys.Return) Then
            txtBusqueda_01.Text = Replace(txtBusqueda_01.Text.ToUpper, "'", "-")
            txtBusqueda_02.Text = Replace(txtBusqueda_02.Text.ToUpper, "'", "-")
        End If
    End Sub

    Private Sub cmbMostrarRegistros_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMostrarRegistros.SelectedValueChanged
        If sender.GetType.ToString Is Nothing Then Exit Sub
        If sender.SelectedValue.ToString = "System.Data.DataRowView" Then Exit Sub
        If sender.SelectedValue.ToString <> "" Then
            '_Registros = sender.SelectedValue
        End If
    End Sub

    Private Sub btnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionar.Click
        If dgvListado.SelectedRows.Count = 0 Then
            MsgBox("Seleccione un registro", MsgBoxStyle.Exclamation)
        Else
            _FilaSeleccionada = dgvListado.CurrentRow
            Me.Close()
        End If
    End Sub

    Private Sub dgvListado_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellContentDoubleClick
        btnSeleccionar_Click(Nothing, Nothing)
    End Sub
#End Region

    Private Sub txtBusqueda_01_LostFocus(sender As Object, e As EventArgs) Handles txtBusqueda_01.LostFocus, txtBusqueda_02.LostFocus
        Me.AcceptButton = btnSeleccionar
    End Sub
End Class