Public Class frmPlantillaSelectorDeUnidad
    Private _UnidadesOperativas As New Base(GestorDeBaseDeDatos.Oracle, EsquemaDeBaseDeDatos.Operacion, _AñoDeOperacion, False, _BaseDeDatosDePrueba)
    Private dtUnidadesOperativas As New DataTable
    Private dtUnidadesOperativasArbol As New DataTable

#Region "Propiedades"
    Private _IDUnidadOperativa As String
    Public Property IDUnidadOperativa() As String
        Get
            Return _IDUnidadOperativa
        End Get
        Set(ByVal value As String)
            _IDUnidadOperativa = value
        End Set
    End Property

    Private _SiglasUnidadOperativa As String
    Public Property SiglasUnidadOperativa() As String
        Get
            Return _SiglasUnidadOperativa
        End Get
        Set(ByVal value As String)
            _SiglasUnidadOperativa = value
        End Set
    End Property

    Private _NombreUnidadOperativa As String
    Public Property NombreUnidadOperativa() As String
        Get
            Return _NombreUnidadOperativa
        End Get
        Set(ByVal value As String)
            _NombreUnidadOperativa = value
        End Set
    End Property

    Private _ActualizaUnidadesOperativas As Boolean = True
    Public Property ActualizaUnidadesOperativas() As Boolean
        Get
            Return _ActualizaUnidadesOperativas
        End Get
        Set(ByVal value As Boolean)
            _ActualizaUnidadesOperativas = value
        End Set
    End Property

    Private _Control As Object = Nothing
    Public Property Control() As Object
        Get
            Return _Control
        End Get
        Set(ByVal value As Object)
            _Control = value
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

    Private _AñoDeOperacion As Integer
    Public Property AñoDeOperacion() As Integer
        Get
            Return _AñoDeOperacion
        End Get
        Set(ByVal value As Integer)
            _AñoDeOperacion = value
        End Set
    End Property

    Private _BaseDeDatosDePrueba As Boolean = False
    Public Property BaseDeDatosDePrueba() As Boolean
        Get
            Return _BaseDeDatosDePrueba
        End Get
        Set(ByVal value As Boolean)
            _BaseDeDatosDePrueba = value
        End Set
    End Property

    Private _NumeroDeEmpleado As String
    Public Property NumeroDeEmpleado() As String
        Get
            Return _NumeroDeEmpleado
        End Get
        Set(ByVal value As String)
            _NumeroDeEmpleado = value
        End Set
    End Property

    Private _IDPrograma As Integer
    Public Property IDPrograma() As String
        Get
            Return _IDPrograma
        End Get
        Set(ByVal value As String)
            _IDPrograma = value
        End Set
    End Property
#End Region

    Private Sub Crear_Nodos(ByVal IDNodoPadre As String, ByVal NodoPadre As TreeNode)
        Dim dvNodos As DataView, _ImageIndex As Integer, _SelectedImageIndex As Integer
        Dim _Nodo As TreeNode

        dvNodos = New DataView(dtUnidadesOperativasArbol)
        dvNodos.RowFilter = dtUnidadesOperativasArbol.Columns("CODIGO_DEL_PADRE").ColumnName & "=" & IDNodoPadre.ToString

        For Each _DataRowView As DataRowView In dvNodos
            If _DataRowView("NOMBRE_DEL_NODO").ToString.Trim.StartsWith("Unidades de operación") Then
                _ImageIndex = 0
            ElseIf _DataRowView("NOMBRE_DEL_NODO").ToString.Trim.StartsWith("División Regional") Then
                _ImageIndex = 1
            ElseIf _DataRowView("NOMBRE_DEL_NODO").ToString.Trim.StartsWith("Administración") Then
                _ImageIndex = 2
            ElseIf _DataRowView("NOMBRE_DEL_NODO").ToString.Trim.StartsWith("Centro") Or _DataRowView("NOMBRE_DEL_NODO").ToString.Trim.StartsWith("Formación") Then
                _ImageIndex = 3
            ElseIf _DataRowView("NOMBRE_DEL_NODO").ToString.Trim.StartsWith("Servicios Empresariales") Then
                _ImageIndex = 4
            ElseIf _DataRowView("NOMBRE_DEL_NODO").ToString.Trim.StartsWith("Delegación") Then
                _ImageIndex = 5
            Else
                _ImageIndex = 6
            End If
            'If _ImageIndex = 6 Then _SelectedImageIndex = 7 Else _SelectedImageIndex = _ImageIndex
            _SelectedImageIndex = 7

            _Nodo = New TreeNode(_DataRowView("NOMBRE_DEL_NODO").ToString.Trim, _ImageIndex, _SelectedImageIndex)
            If NodoPadre Is Nothing Then
                trvUnidadesOperativas.Nodes.Add(_Nodo)
            Else
                NodoPadre.Nodes.Add(_Nodo)
            End If
            Crear_Nodos(_DataRowView("CODIGO_DEL_NODO").ToString, _Nodo)
        Next _DataRowView
    End Sub

    Private Sub Cargar_Datos()
        Try
            Dim NumeroDelNodo As String = 0, NumeroDelNodoPadre As String
            dtUnidadesOperativasArbol.Columns.Clear()
            dtUnidadesOperativasArbol.Columns.Add("NOMBRE_DEL_NODO", GetType(String))
            dtUnidadesOperativasArbol.Columns.Add("CODIGO_DEL_NODO", GetType(String))
            dtUnidadesOperativasArbol.Columns.Add("CODIGO_DEL_PADRE", GetType(String))
            dtUnidadesOperativasArbol.Columns.Add("SIGLAS_UNIDAD_OPERATIVA", GetType(String))
            dtUnidadesOperativasArbol.Columns.Add("ID_UNIDAD_OPERATIVA", GetType(String))

            dtUnidadesOperativasArbol.Rows.Add("Unidades de operación", NumeroDelNodo, -1, "", "")
            ' Agregar las regiones
            dtUnidadesOperativasArbol.Rows.Add("Administración", 9, 0, "", "")

            dtUnidadesOperativasArbol.Rows.Add("Regional Central", 1, 0, "", "")
            dtUnidadesOperativasArbol.Rows.Add("Regional Sur", 2, 0, "", "")
            dtUnidadesOperativasArbol.Rows.Add("Regional Occidente", 3, 0, "", "")
            dtUnidadesOperativasArbol.Rows.Add("Regional Norte", 4, 0, "", "")
            dtUnidadesOperativasArbol.Rows.Add("Regional Oriente", 5, 0, "", "")

            _UnidadesOperativas = New Base(GestorDeBaseDeDatos.Oracle, EsquemaDeBaseDeDatos.Operacion, _AñoDeOperacion, _BaseDeDatosDePrueba)
            _UnidadesOperativas.AsignarParametroWhere("ID_PROGRAMA", "UA.ID_PROGRAMA", _IDPrograma, TipoDeOperadorLogico.AndOperador, TipoDeOperadorDeComparacion.Igual, False)
            _UnidadesOperativas.AsignarParametroWhere("NUMERO_EMPLEADO", "UA.NUMERO_EMPLEADO", _NumeroDeEmpleado, TipoDeOperadorLogico.AndOperador, TipoDeOperadorDeComparacion.Igual, False)
            _UnidadesOperativas.AsignarParametroWhere("ID_TIPO_DE_UNIDAD", "UOP.ID_TIPO_DE_UNIDAD", 6, TipoDeOperadorLogico.AndOperador, TipoDeOperadorDeComparacion.MenorIgual, False, True)
            _UnidadesOperativas.AsignarParametroWhere("ID_TIPO_DE_UNIDAD", "UOP.ID_TIPO_DE_UNIDAD", "9,10,11", TipoDeOperadorLogico.OrOperador, TipoDeOperadorDeComparacion.InOperador, True, False, True)
            'If Not _UnidadesOperativas.CargarDatos(dtUnidadesOperativas, "UA.ID_UNIDAD_OPERATIVA, UOP.SIGLAS, UOP.NOMBRE_UNIDAD_OPERATIVA, UOP.ORDEN", "V_UNIDADES_2012 UOP INNER JOIN UNIDADES_AUTORIZADAS UA ON UOP.ID_UNIDAD_OPERATIVA = UA.ID_UNIDAD_OPERATIVA", "", "", "UOP.ORDEN") Then
            If Not _UnidadesOperativas.CargarDatos(dtUnidadesOperativas, "DECODE(UOP.ID_REGION,6,4,UOP.ID_REGION) AS ID_REGION, REG.NOMBRE_REGION, UOP.ID_UNIDAD_OPERATIVA,  UOP.SIGLAS,  UOP.NOMBRE_UNIDAD_OPERATIVA, UOP.ORDEN ", "V_UNIDADES_2012 UOP INNER JOIN UNIDADES_AUTORIZADAS UA  ON UOP.ID_UNIDAD_OPERATIVA = UA.ID_UNIDAD_OPERATIVA INNER JOIN REGIONES REG ON  DECODE(UOP.ID_REGION,6,4,UOP.ID_REGION) = REG.ID_REGION ", "", "", "DECODE(UOP.ID_REGION,9,0,DECODE(UOP.ID_REGION,6,4,UOP.ID_REGION)), UOP.ORDEN") Then
                MsgBox(_UnidadesOperativas.Mensaje, MsgBoxStyle.Exclamation)
            Else               
                For Each _Fila As DataRow In dtUnidadesOperativas.Rows
                    NumeroDelNodo = _Fila("ID_UNIDAD_OPERATIVA").ToString.Trim
                    'NumeroDelNodoPadre = _Fila("ID_UNIDAD_OPERATIVA").ToString.Trim.Substring(0, _Fila("ID_UNIDAD_OPERATIVA").ToString.Trim.Length - 2)
                    Trace.WriteLine("Nodo: " & NumeroDelNodo)

                    If _Fila("ID_UNIDAD_OPERATIVA").ToString.Length < 5 Then
                        NumeroDelNodoPadre = _Fila("ID_REGION")
                    Else
                        If _Fila("ID_UNIDAD_OPERATIVA").ToString = "104602" Then
                            NumeroDelNodoPadre = _Fila("ORDEN").ToString.Trim.Substring(0, _Fila("ORDEN").ToString.Trim.Length - 2)
                        Else
                            NumeroDelNodoPadre = _Fila("ID_UNIDAD_OPERATIVA").ToString.Trim.Substring(0, _Fila("ID_UNIDAD_OPERATIVA").ToString.Trim.Length - 2)
                        End If
                    End If

                    'NumeroDelNodoPadre = _Fila("ID_REGION")

                    Trace.WriteLine("NodoPadre:" & NumeroDelNodoPadre)
                    If NumeroDelNodoPadre = "" Then NumeroDelNodoPadre = 0
                    dtUnidadesOperativasArbol.Rows.Add(_Fila("NOMBRE_UNIDAD_OPERATIVA"), _Fila("ID_UNIDAD_OPERATIVA"), NumeroDelNodoPadre, _Fila("SIGLAS"), _Fila("ID_UNIDAD_OPERATIVA"))
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Seleccionar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionar.Click
        SeleccionarUnidadOperativa()
        If Not _Control Is Nothing Then
            _Control.Tag = _IDUnidadOperativa
            _Control.Text = trvUnidadesOperativas.SelectedNode.Text
        End If
        AlSeleccionarUnidad()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub trvUnidadesOperativas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvUnidadesOperativas.DoubleClick
        Seleccionar(sender, e)
    End Sub

    Private Sub SeleccionarUnidadOperativa()
        For Each _Fila As DataRow In dtUnidadesOperativasArbol.Rows
            If trvUnidadesOperativas.SelectedNode.Text = _Fila("NOMBRE_DEL_NODO") Then
                _IDUnidadOperativa = _Fila("ID_UNIDAD_OPERATIVA")
                _SiglasUnidadOperativa = _Fila("SIGLAS_UNIDAD_OPERATIVA")
                _NombreUnidadOperativa = _Fila("NOMBRE_DEL_NODO")
                Exit For
            End If
        Next _Fila
        If _IDUnidadOperativa = "" Then
            MsgBox("No ha seleccionado una unidad de operación, por favor verifique.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Salir(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        _IDUnidadOperativa = ""
        _SiglasUnidadOperativa = ""
        _NombreUnidadOperativa = ""
        AlSeleccionarUnidad()
        Me.Close()
        Me.Dispose()
    End Sub

    Public Sub InicializarFormulario()
        Try
            Me.Text = "Selector de unidades de operación [" & _SiglasDelSistema & "_FRM" & Format(_NumeroDeFormulario, "0000") & "] " & Me.Width & "," & Me.Height
            Cargar_Datos()
            trvUnidadesOperativas.Nodes.Clear()
            Crear_Nodos(-1, Nothing)
            trvUnidadesOperativas.ExpandAll()
            trvUnidadesOperativas.SelectedNode = trvUnidadesOperativas.Nodes(0)
            Dim i As Integer = 0

            For i = 0 To trvUnidadesOperativas.Nodes(0).Nodes.Count
                If trvUnidadesOperativas.Nodes(0).Nodes.Count = i Then
                    Exit For
                End If
                Dim n As TreeNode = trvUnidadesOperativas.Nodes(0).Nodes(i)
                Try
                    If n.Text = "Regional Central" Then
                        If n.Nodes.Count() = 0 Then
                            trvUnidadesOperativas.Nodes.Remove(n)
                            i = i - 1
                        End If
                    End If
                    If n.Text = "Regional Sur" Then
                        If n.Nodes.Count() = 0 Then
                            trvUnidadesOperativas.Nodes.Remove(n)
                            i = i - 1
                        End If
                    End If
                    If n.Text = "Regional Occidente" Then
                        If n.Nodes.Count() = 0 Then
                            trvUnidadesOperativas.Nodes.Remove(n)
                            i = i - 1
                        End If
                    End If
                    If n.Text = "Regional Norte" Then
                        If n.Nodes.Count() = 0 Then
                            trvUnidadesOperativas.Nodes.Remove(n)
                            i = i - 1
                        End If
                    End If
                    If n.Text = "Regional Oriente" Then
                        If n.Nodes.Count() = 0 Then
                            trvUnidadesOperativas.Nodes.Remove(n)
                            i = i - 1
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next i
            'For Each n As TreeNode In trvUnidadesOperativas.Nodes(0).Nodes
            '    Try
            '        If n.Text = "Regional Central" Then
            '            If n.Nodes.Count() = 0 Then trvUnidadesOperativas.Nodes.Remove(n)
            '        End If
            '        If n.Text = "Regional Sur" Then
            '            If n.Nodes.Count() = 0 Then trvUnidadesOperativas.Nodes.Remove(n)
            '        End If
            '        If n.Text = "Regional Occidente" Then
            '            If n.Nodes.Count() = 0 Then trvUnidadesOperativas.Nodes.Remove(n)
            '        End If
            '        If n.Text = "Regional Norte" Then
            '            If n.Nodes.Count() = 0 Then trvUnidadesOperativas.Nodes.Remove(n)
            '        End If
            '        If n.Text = "Regional Oriente" Then
            '            If n.Nodes.Count() = 0 Then trvUnidadesOperativas.Nodes.Remove(n)
            '        End If
            '    Catch ex As Exception
            '    End Try
            'Next
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Overridable Sub AlSeleccionarUnidad()

    End Sub
End Class