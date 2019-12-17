Public Class frmPlantillaSelectorDeAño
    Private dtAños As New DataTable

#Region "Propiedades"
    Private _NumeroDeFormulario As Integer
    Public Property NumeroDeFormulario() As Integer
        Get
            Return _NumeroDeFormulario
        End Get
        Set(ByVal value As Integer)
            _NumeroDeFormulario = value
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

    Private _AñoInicial As Integer
    Public Property AñoInicial() As Integer
        Get
            Return _AñoInicial
        End Get
        Set(ByVal value As Integer)
            _AñoInicial = value
        End Set
    End Property

    Private _AñoFinal As Integer = Now.Year
    Public Property AñoFinal() As Integer
        Get
            Return _AñoFinal
        End Get
        Set(ByVal value As Integer)
            _AñoFinal = value
        End Set
    End Property

    Private _AñoSeleccionado As Integer
    Public Property AñoSeleccionado() As Integer
        Get
            Return _AñoSeleccionado
        End Get
        Set(ByVal value As Integer)
            _AñoSeleccionado = value
        End Set
    End Property
#End Region

    Private Sub Salir(sender As Object, e As EventArgs) Handles btnSalir.Click
        _AñoSeleccionado = 0
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Seleccionar(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        If cmbAños.SelectedValue <> "0" Then
            _AñoSeleccionado = cmbAños.SelectedValue
            Accion()
        Else
            MsgBox("Debe seleccionar el año de operación.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub InicializarFormulario()
        Try
            Me.Text = "Selector del año de operación [" & _SiglasDelSistema & "_FRM" & Format(_NumeroDeFormulario, "0000") & "]"
            dtAños.Columns.Clear()
            dtAños.Columns.Add("AÑO")
            dtAños.Rows.Clear()
            For Cont As Integer = _AñoInicial To _AñoFinal
                dtAños.Rows.Add(Cont)
            Next
            cmbAños.DataSource = dtAños
            cmbAños.DisplayMember = "AÑO"
            cmbAños.ValueMember = "AÑO"
            If _AñoSeleccionado <> 0 Then
                cmbAños.SelectedValue = _AñoSeleccionado
            Else
                cmbAños.SelectedValue = _AñoFinal
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try        
    End Sub

    Public Overridable Sub Accion()

    End Sub
End Class