<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlantillaInforme
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.objReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'objReporte
        '
        Me.objReporte.ActiveViewIndex = -1
        Me.objReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.objReporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.objReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.objReporte.EnableRefresh = False
        Me.objReporte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.objReporte.Location = New System.Drawing.Point(0, 0)
        Me.objReporte.Name = "objReporte"
        Me.objReporte.ReuseParameterValuesOnRefresh = True
        Me.objReporte.SelectionFormula = ""
        Me.objReporte.ShowCloseButton = False
        Me.objReporte.ShowCopyButton = False
        Me.objReporte.ShowGroupTreeButton = False
        Me.objReporte.ShowParameterPanelButton = False
        Me.objReporte.ShowRefreshButton = False
        Me.objReporte.Size = New System.Drawing.Size(896, 606)
        Me.objReporte.TabIndex = 1
        Me.objReporte.TabStop = False
        Me.objReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.objReporte.ViewTimeSelectionFormula = ""
        '
        'frmPlantillaInforme
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(896, 606)
        Me.Controls.Add(Me.objReporte)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPlantillaInforme"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents objReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
