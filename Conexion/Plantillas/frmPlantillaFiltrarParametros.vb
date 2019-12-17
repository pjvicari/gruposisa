Public Class frmPlantillaFiltrarParametros
    Private _Mensaje As String
    Private _Operadores As New DataTable
    Private _Columnas As New DataTable

#Region "Propiedades"

    'Clase de conexion
    Public _ClaseDeConexion As Object
    Public Property ClaseDeConexion() As Object
        Get
            Return _ClaseDeConexion
        End Get
        Set(ByVal value As Object)
            _ClaseDeConexion = value
        End Set
    End Property


    Public _ColColumnasFiltros As New List(Of Columna())
    Public Property ColColumnasFiltros() As List(Of Columna())
        Get
            Return _ColColumnasFiltros
        End Get
        Set(value As List(Of Columna()))
            _ColColumnasFiltros = value
        End Set
    End Property

    ' elementos 
    Private _Columna As String
    Public Property Columna() As String
        Get
            Return _Columna
        End Get
        Set(ByVal value As String)
            _Columna = value
        End Set
    End Property

    Private _ColumnaNombre As String

    Public Property ColumnaNombre() As String
        Get
            Return _ColumnaNombre
        End Get
        Set(ByVal value As String)
            _ColumnaNombre = value
        End Set
    End Property

    Private _Operador As String
    Public Property Operador() As String
        Get
            Return _Operador
        End Get
        Set(ByVal value As String)
            _Operador = value
        End Set
    End Property

    Private _OperadorTexto As String
    Public Property OperadorTexto() As String
        Get
            Return _OperadorTexto
        End Get
        Set(ByVal value As String)
            _OperadorTexto = value
        End Set
    End Property

    Private _Valor As String
    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property

    Private _AValor As String
    Public Property AValor() As String
        Get
            Return _AValor
        End Get
        Set(ByVal value As String)
            _AValor = value
        End Set
    End Property

    Private _dtParametrosFiltros As New DataTable
    Public Property dtParametrosFiltros As DataTable
        Get
            Return _dtParametrosFiltros
        End Get
        Set(value As DataTable)
            _dtParametrosFiltros = value
        End Set
    End Property

#End Region

#Region "Medodos Privados"
    Private Function ValidarCampos() As Boolean
        Dim _Resultado As Boolean = True
        Try
            If cmbColumna.SelectedIndex = 0 Then _Resultado = False : _Mensaje &= "Debe seleccionar una [Columna]" & vbCrLf
            If cmbOperador.SelectedIndex = 0 Then _Resultado = False : _Mensaje &= "Debe seleccionar un [Operador]" & vbCrLf
            If txtValor.Text = "" Then _Resultado = False : _Mensaje &= "Debe ingresar un [Valor]" & vbCrLf
            If txtAValor.Text = "" And cmbOperador.SelectedValue = 10 Then _Resultado = False : _Mensaje &= "Debe ingresar un [A valor]" & vbCrLf
            Return _Resultado
        Catch ex As Exception
            _Mensaje = ex.Message
            Return False
        End Try
    End Function

    Private Sub FormatoGrid()
        dgvParametros.RowsDefaultCellStyle.BackColor = Color.White
        dgvParametros.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
        dgvParametros.Columns(0).Width = 200
        dgvParametros.Columns(1).Width = 100
        dgvParametros.Columns(2).Width = 210
        dgvParametros.Columns(3).Width = 210
        dgvParametros.Columns(4).Width = 0
        dgvParametros.Columns(5).Width = 0
        dgvParametros.Columns(4).Visible = False
        dgvParametros.Columns(5).Visible = False
    End Sub

#End Region

#Region "Procedimientos"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            _dtParametrosFiltros = TryCast(dgvParametros.DataSource, DataTable)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub frmPlantillaInformacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            _Columnas.Columns.Clear()
            _Columnas.Columns.Add("NOMBRE_CAMPO")
            _Columnas.Columns.Add("NOMBRE_MOSTRAR")

            Dim _ArrayColumnas() As Columna = _ColColumnasFiltros(0)
            For Each _Colum As Columna In _ArrayColumnas
                If Not _Colum Is Nothing Then
                    If _Colum.IncluirEnBusqueda Then _Columnas.Rows.Add(_Colum.NombreCampo, _Colum.NombreMostrar)
                End If
            Next

            If _Columnas.Rows.Count > 0 Then
                _ClaseDeConexion.Llenar_ComboBox(cmbColumna, _Columnas, "NOMBRE_CAMPO", "NOMBRE_MOSTRAR", "")
            End If

            'Operadores
            If _ClaseDeConexion.CargarDatos(_Operadores, "CODIGO,DESCRIPCION", "(SELECT 1 AS CODIGO, 'Igual a' as DESCRIPCION FROM DUAL UNION  SELECT 2 AS CODIGO, 'No igual a' as DESCRIPCION FROM DUAL UNION  SELECT 3 AS CODIGO, 'Mayor que' as DESCRIPCION FROM DUAL UNION  SELECT 4 AS CODIGO, 'Mayor o igual que' as DESCRIPCION FROM DUAL UNION  SELECT 5 AS CODIGO, 'Menor que' as DESCRIPCION FROM DUAL UNION  SELECT 6 AS CODIGO, 'Menor o igual que' as DESCRIPCION FROM DUAL UNION  SELECT 7 AS CODIGO, 'Inicia con' as DESCRIPCION FROM DUAL UNION  SELECT 8 AS CODIGO, 'Finaliza con' as DESCRIPCION FROM DUAL UNION  SELECT 9 AS CODIGO, 'Que contenga' as DESCRIPCION FROM DUAL UNION  SELECT 10 AS CODIGO, 'Entre' as DESCRIPCION FROM DUAL) Z") Then
                _ClaseDeConexion.Llenar_ComboBox(cmbOperador, _Operadores, "CODIGO", "DESCRIPCION", "")
            Else
                MsgBox(_ClaseDeConexion.Meensaje, MsgBoxStyle.Critical)
            End If

            cmbColumna.Focus()
            cmbColumna.SelectedIndex = 1
            cmbOperador.SelectedIndex = 1

            'Se inicializa el dt para parametros
            If dtParametrosFiltros.Rows.Count <= 0 Then
                dtParametrosFiltros.Columns.Clear()
                dtParametrosFiltros.Columns.Add("Columna")
                dtParametrosFiltros.Columns.Add("Operador")
                dtParametrosFiltros.Columns.Add("Valor")
                dtParametrosFiltros.Columns.Add("A valor")
                dtParametrosFiltros.Columns.Add("ColumnaCodigo")
                dtParametrosFiltros.Columns.Add("OperadorCodigo")
            End If

            If dtParametrosFiltros.Rows.Count > 0 Then
                dgvParametros.DataSource = dtParametrosFiltros
                FormatoGrid()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
#End Region

    Private Sub cmbOperador_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbOperador.SelectedValueChanged
        If cmbOperador.SelectedValue.ToString() = "10" Then
            txtAValor.Enabled = True
        Else
            txtAValor.Enabled = False
        End If
    End Sub

    Private Sub btnAgregarFiltro_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltro.Click
        Try
            If ValidarCampos() Then
                _Columna = cmbColumna.SelectedValue.ToString()
                _ColumnaNombre = cmbColumna.Text
                _Operador = cmbOperador.SelectedValue.ToString()
                _OperadorTexto = cmbOperador.Text
                _Valor = txtValor.Text.Trim()
                _AValor = txtAValor.Text.Trim()

                dtParametrosFiltros.Rows.Add(_ColumnaNombre, _OperadorTexto, _Valor, _AValor, _Columna, _Operador)
                dgvParametros.DataSource = dtParametrosFiltros
                FormatoGrid()
            Else
                MsgBox(_Mensaje, MsgBoxStyle.Critical)
                _Mensaje = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        Try
            dtParametrosFiltros.Clear()
            If dgvParametros.Rows.Count > 0 Then
                Me.dgvParametros.Rows.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnEliminarFiltro_Click(sender As Object, e As EventArgs) Handles btnEliminarFiltro.Click
        Try
            If dgvParametros.Rows.Count > 0 Then
                dgvParametros.Rows.Remove(dgvParametros.CurrentRow)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class