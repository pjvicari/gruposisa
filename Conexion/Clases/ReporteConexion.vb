Public Class ReporteConexion
    Inherits Base

    Public Sub New(ByVal gestorDeBaseDeDatos As GestorDeBaseDeDatos, esquemaDeBaseDeDatos As EsquemaDeBaseDeDatos, añoDeOperacion As Integer, ambienteDeBaseDeDatos As AmbienteDeBaseDeDatos)
        MyBase.New(gestorDeBaseDeDatos, esquemaDeBaseDeDatos, añoDeOperacion, False, ambienteDeBaseDeDatos)
    End Sub
End Class
