Public Class frmPlantillaProcesos    

#Region "Propiedades"
    Private _NombreDeFormulario As String
    Public Property NombreDeFormulario() As String
        Get
            Return _NombreDeFormulario
        End Get
        Set(ByVal value As String)
            _NombreDeFormulario = value
        End Set
    End Property

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
#End Region

    Private Sub Salir(sender As Object, e As EventArgs) Handles btnSalir.Click        
        Me.Close()
        Me.Dispose()
    End Sub

    Public Sub InicializarFormulario()
        Me.Text = _NombreDeFormulario & " [" & _SiglasDelSistema & "_FRM" & Format(_NumeroDeFormulario, "0000") & "]"
    End Sub

    Private Sub frmPlantillaProcesos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class