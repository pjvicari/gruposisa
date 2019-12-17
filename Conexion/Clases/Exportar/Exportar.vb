Imports System.Reflection
Imports System.Runtime.InteropServices

Public Class Exportar
    Public Function ExcelEscritorio(dataTable As DataTable, ByRef mensaje As String, titulosColumnas As String) As Boolean
        Dim _Resultado As Boolean = True
        Dim _Application As New Microsoft.Office.Interop.Excel.Application
        Dim _Workbook As Microsoft.Office.Interop.Excel.Workbook
        Dim _Worksheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim _ColumnaNumero As Integer = 0
        Dim _FilaNumero As Integer = 0
        Dim _ColumnasTitulos As Object

        Try
            _Workbook = _Application.Workbooks.Add()
            _Worksheet = _Workbook.ActiveSheet()

            If dataTable.Rows.Count > 0 Then
                If titulosColumnas <> "" Then
                    _ColumnasTitulos = Split(titulosColumnas, ",")
                    If UBound(_ColumnasTitulos) + 1 = dataTable.Columns.Count Then
                        Try
                            For _ColumnaNumero = 0 To UBound(_ColumnasTitulos)
                                _Worksheet.Cells(1, _ColumnaNumero + 1).Value = _ColumnasTitulos(_ColumnaNumero).ToString.Trim
                                _Worksheet.Cells(1, _ColumnaNumero + 1).Font.Bold = True
                            Next
                        Catch ex As Exception
                            mensaje = "Error: " & ex.Message
                        End Try
                    Else
                        mensaje = "El número de columnas no coincide con los títulos de las mismas."
                        _Resultado = False
                    End If
                Else
                    For _Columna As Integer = 0 To dataTable.Columns.Count - 1
                        _Worksheet.Cells(1, _Columna + 1).Value = dataTable.Columns(_Columna).ColumnName
                        _Worksheet.Cells(1, _Columna + 1).Font.Bold = True
                    Next
                End If
                If _Resultado Then
                    For Each _Fila As DataRow In dataTable.Rows
                        _FilaNumero += 1
                        _ColumnaNumero = 0
                        For Each _Columna As DataColumn In dataTable.Columns
                            If _Columna Is Nothing Then Continue For
                            _ColumnaNumero += 1
                            Try                                
                                If IsDate(_Fila(_Columna.ColumnName).ToString) And _Columna.ColumnName.Contains("FECHA") Then
                                    _Worksheet.Cells(_FilaNumero + 1, _ColumnaNumero).NumberFormat = "dd/MM/yyyy"
                                    _Worksheet.Cells(_FilaNumero + 1, _ColumnaNumero).Value2 = CDate(_Fila(_Columna.ColumnName).ToString)
                                Else
                                    'If _Fila(_Columna.ColumnName).ToString = "7102" Then
                                    '    MsgBox("Aqui está")
                                    'End If
                                    _Worksheet.Cells(_FilaNumero + 1, _ColumnaNumero).Value = _Fila(_Columna.ColumnName).ToString
                                End If
                            Catch ex As Exception
                                mensaje = "Error: " & ex.Message
                            End Try
                        Next
                    Next
                End If
                mensaje = "Exportación a excel concluido con éxito."
                _Worksheet.Columns.AutoFit()
                _Application.Visible = True
                _Resultado = True
            End If
        Catch ex As System.Runtime.InteropServices.COMException
            _Resultado = False
            Select Case ex.ErrorCode
                Case -2147221164
                    mensaje = "Error al exportar: Por favor instale Microsoft Office (Excel) para usuar la funcionalidad de Exportar a Excel."
                    'Case -2146827284
                    '    mensaje = "Error al exportar: Excel permite unicamente 65,536 lineas máximo en una hoja."
                Case Else
                    mensaje = "Error al exportar: " & ex.Message & ", error #: " & ex.ErrorCode & "."
            End Select
        Catch ex As Exception
            mensaje = "Error al exportar: " & ex.Message & "."
        End Try

        Return _Resultado
    End Function

  

    Public Function ExcelWeb(response As System.Web.HttpResponse, dataTable As DataTable, ByRef mensaje As String, titulosColumnas As String) As Boolean
        Dim _Resultado As Boolean = True
        Dim _ColumnasTitulos As Object
        Dim _Pagina As New Page
        Dim _StringWriter As New System.IO.StringWriter
        Dim _HtmlTextWriter As New HtmlTextWriter(_StringWriter)
        Dim _GridView As New System.Web.UI.WebControls.GridView

        If titulosColumnas <> "" Then
            _ColumnasTitulos = Split(titulosColumnas, ",")
            If UBound(_ColumnasTitulos) + 1 = dataTable.Columns.Count Then
                Try
                    For _ColumnaNumero As Integer = 0 To UBound(_ColumnasTitulos)
                        dataTable.Columns(_ColumnaNumero).ColumnName = _ColumnasTitulos(_ColumnaNumero).ToString
                    Next
                Catch ex As Exception
                    mensaje = "Error: " & ex.Message
                End Try
            Else
                mensaje = "El número de columnas no coincide con los títulos de las mismas."
                _Resultado = False
            End If
        End If

        Try
            'Hacer binding de los datos en la Grid
            'System.IO.FileInfo file = new System.IO.FileInfo(path);
            'Dim _File As New System.IO.FileInfo(_Pagina.MapPath("~/temp"))
            _GridView.DataSource = dataTable
            _GridView.DataBind()

            For Each _GridViewRow As System.Web.UI.WebControls.GridViewRow In _GridView.Rows
                _GridViewRow.Attributes.Add("class", "textmode")
            Next

            response.ClearContent()
            response.Buffer = True
            response.AddHeader("content-disposition", "attachment; filename=" & "Exportado-" & Replace(Date.Now.Date, "/", "") & ".xls")
            'response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            response.ContentType = "application/vnd.ms-excel"
            'response.AddHeader("Content-Disposition", "attachment; filename=" + "theFile.xlsx")
            response.AddHeader("Content-Length", _StringWriter.ToString)

            _Pagina.EnableViewState = False

            ' Colocar negrita a los encabezados
            _GridView.HeaderStyle.Font.Bold = True     ' SET EXCEL HEADERS AS BOLD.
            _GridView.RenderControl(_HtmlTextWriter)

            'im string style = ;
            response.Write("<style> .textmode { mso-number-format:\@; } </style>")
            response.Output.Write(_StringWriter.ToString())
            'response.WriteFile(_StringWriter.ToString())

            'response.BufferOutput = True
            'response.Flush()
            'response.Close()
            response.End()
            response.Redirect("HttpContext.Current.ApplicationInstance.CompleteRequest", False)
            _GridView = Nothing

            _Resultado = True
        Catch ex As Exception
            mensaje = "Error al exportar: " & ex.Message & "."
            _Resultado = False

        End Try
        Return _Resultado

        ' STYLE THE SHEET AND WRITE DATA TO IT.
        'response.Write("<style> TABLE { border:dotted 1px #999; } " & _
        '            "TD { border:dotted 1px #D5D5D5; text-align:center } </style>")

        ' ADD A ROW AT THE END OF THE SHEET SHOWING A RUNNING TOTAL OF PRICE.
        'pagina.Response.Write("<table><tr><td><b>Total: </b></td><td></td><td><b>" & _
        '            Decimal.Parse(dTotalPrice).ToString("N2") & "</b></td></tr></table>")

    End Function
End Class
