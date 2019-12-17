Public Interface IWindowsFormABC    
    Function Agregar() As Boolean
    Function Modificar() As Boolean
    Function Eliminar() As Boolean
    Function Validar_Campos() As Boolean    
    Sub Limpiar_Campos()
    Sub Cargar_Detalle()
End Interface
