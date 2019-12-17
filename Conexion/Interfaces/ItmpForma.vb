Public Interface ItmpForma
    Sub Agregar_Columna(ByVal ParNombreMostrar As String, ByVal ParNombreCampo As String, ByVal ParPorcentajeTamaño As Integer, ByVal ParBusqueda As Boolean, ByVal ParControl As Object, ByVal ParAliniacion As DataGridViewContentAlignment, ByVal ParEditarAl As TipoDeEdicion, ByVal ParFormato As String)
    Sub Agregar_Columna(ByVal ParNombreMostrar As String, ByVal ParNombreCampo As String, ByVal ParPorcentajeTamaño As Integer, ByVal ParBusqueda As Boolean, ByVal ParControl As Object, ByVal ParAliniacion As DataGridViewContentAlignment, ByVal ParEditarAl As TipoDeEdicion)

    Function Agregar() As Boolean
    Function Modificar() As Boolean
    Function Eliminar() As Boolean
    Function Imprimir() As Boolean

    Sub Limpiar_Campos()    
    Sub Iniciar_Forma()
    Sub Cargar_Detalle()

    ReadOnly Property Tipo_de_Operacion() As TipoDeOperacion
End Interface
