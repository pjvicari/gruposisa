﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlantillaListadoNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlantillaListadoNew))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpMenu = New System.Windows.Forms.GroupBox()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.btnDesaplicar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.grpListado = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.cmbMostrarRegistros = New System.Windows.Forms.ComboBox()
        Me.dgvListado = New System.Windows.Forms.DataGridView()
        Me.lblMostrarRegistros = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.grpMenu.SuspendLayout()
        Me.grpListado.SuspendLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpMenu
        '
        Me.grpMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMenu.Controls.Add(Me.btnAplicar)
        Me.grpMenu.Controls.Add(Me.btnDesaplicar)
        Me.grpMenu.Controls.Add(Me.btnCerrar)
        Me.grpMenu.Controls.Add(Me.btnConsultar)
        Me.grpMenu.Controls.Add(Me.btnImprimir)
        Me.grpMenu.Controls.Add(Me.btnSalir)
        Me.grpMenu.Controls.Add(Me.btnEliminar)
        Me.grpMenu.Controls.Add(Me.btnModificar)
        Me.grpMenu.Controls.Add(Me.btnAgregar)
        Me.grpMenu.Location = New System.Drawing.Point(3, 534)
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Size = New System.Drawing.Size(888, 69)
        Me.grpMenu.TabIndex = 3
        Me.grpMenu.TabStop = False
        '
        'btnAplicar
        '
        Me.btnAplicar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicar.Image = CType(resources.GetObject("btnAplicar.Image"), System.Drawing.Image)
        Me.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAplicar.Location = New System.Drawing.Point(635, 10)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(61, 56)
        Me.btnAplicar.TabIndex = 8
        Me.btnAplicar.Text = "A&plicar"
        Me.btnAplicar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAplicar.UseVisualStyleBackColor = True
        '
        'btnDesaplicar
        '
        Me.btnDesaplicar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesaplicar.Image = CType(resources.GetObject("btnDesaplicar.Image"), System.Drawing.Image)
        Me.btnDesaplicar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDesaplicar.Location = New System.Drawing.Point(695, 10)
        Me.btnDesaplicar.Name = "btnDesaplicar"
        Me.btnDesaplicar.Size = New System.Drawing.Size(69, 56)
        Me.btnDesaplicar.TabIndex = 7
        Me.btnDesaplicar.Text = "&Desaplicar"
        Me.btnDesaplicar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDesaplicar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCerrar.Location = New System.Drawing.Point(763, 10)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(61, 56)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.Text = "Ce&rrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConsultar.Location = New System.Drawing.Point(4, 10)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(61, 56)
        Me.btnConsultar.TabIndex = 0
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(244, 10)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(61, 56)
        Me.btnImprimir.TabIndex = 4
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(823, 10)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(61, 56)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(184, 10)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(61, 56)
        Me.btnEliminar.TabIndex = 3
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnModificar.Location = New System.Drawing.Point(124, 10)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(61, 56)
        Me.btnModificar.TabIndex = 2
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(64, 10)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(61, 56)
        Me.btnAgregar.TabIndex = 1
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'grpListado
        '
        Me.grpListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpListado.Controls.Add(Me.lblBuscar)
        Me.grpListado.Controls.Add(Me.btnBuscar)
        Me.grpListado.Controls.Add(Me.txtBuscar)
        Me.grpListado.Controls.Add(Me.cmbMostrarRegistros)
        Me.grpListado.Controls.Add(Me.dgvListado)
        Me.grpListado.Controls.Add(Me.lblMostrarRegistros)
        Me.grpListado.Controls.Add(Me.btnFiltrar)
        Me.grpListado.Location = New System.Drawing.Point(3, -2)
        Me.grpListado.Name = "grpListado"
        Me.grpListado.Size = New System.Drawing.Size(888, 540)
        Me.grpListado.TabIndex = 8
        Me.grpListado.TabStop = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(793, 37)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(91, 28)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(100, 41)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(691, 20)
        Me.txtBuscar.TabIndex = 2
        '
        'cmbMostrarRegistros
        '
        Me.cmbMostrarRegistros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMostrarRegistros.FormattingEnabled = True
        Me.cmbMostrarRegistros.Location = New System.Drawing.Point(100, 13)
        Me.cmbMostrarRegistros.Name = "cmbMostrarRegistros"
        Me.cmbMostrarRegistros.Size = New System.Drawing.Size(691, 22)
        Me.cmbMostrarRegistros.TabIndex = 0
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.AllowUserToOrderColumns = True
        Me.dgvListado.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvListado.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListado.Location = New System.Drawing.Point(5, 67)
        Me.dgvListado.MultiSelect = False
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.ReadOnly = True
        Me.dgvListado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvListado.RowHeadersWidth = 26
        Me.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListado.Size = New System.Drawing.Size(878, 466)
        Me.dgvListado.TabIndex = 25
        '
        'lblMostrarRegistros
        '
        Me.lblMostrarRegistros.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMostrarRegistros.Location = New System.Drawing.Point(4, 14)
        Me.lblMostrarRegistros.Name = "lblMostrarRegistros"
        Me.lblMostrarRegistros.Size = New System.Drawing.Size(90, 20)
        Me.lblMostrarRegistros.TabIndex = 23
        Me.lblMostrarRegistros.Text = "Registros"
        Me.lblMostrarRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltrar.Image = CType(resources.GetObject("btnFiltrar.Image"), System.Drawing.Image)
        Me.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFiltrar.Location = New System.Drawing.Point(793, 10)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(90, 28)
        Me.btnFiltrar.TabIndex = 1
        Me.btnFiltrar.Text = "&Filtrar"
        Me.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscar.Location = New System.Drawing.Point(4, 41)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(90, 20)
        Me.lblBuscar.TabIndex = 33
        Me.lblBuscar.Text = "Buscar"
        Me.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmPlantillaListadoNew
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(896, 606)
        Me.Controls.Add(Me.grpListado)
        Me.Controls.Add(Me.grpMenu)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(912, 684)
        Me.Name = "frmPlantillaListadoNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.grpMenu.ResumeLayout(False)
        Me.grpListado.ResumeLayout(False)
        Me.grpListado.PerformLayout()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected Friend WithEvents grpMenu As System.Windows.Forms.GroupBox
    Protected Friend WithEvents btnSalir As System.Windows.Forms.Button
    Protected WithEvents btnImprimir As System.Windows.Forms.Button
    Protected WithEvents btnEliminar As System.Windows.Forms.Button
    Protected WithEvents btnModificar As System.Windows.Forms.Button
    Protected WithEvents btnAgregar As System.Windows.Forms.Button
    Protected Friend WithEvents grpListado As System.Windows.Forms.GroupBox
    Protected Friend WithEvents dgvListado As System.Windows.Forms.DataGridView
    Protected Friend WithEvents lblMostrarRegistros As System.Windows.Forms.Label
    Protected Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Protected WithEvents btnConsultar As System.Windows.Forms.Button
    Protected WithEvents btnCerrar As System.Windows.Forms.Button
    Protected WithEvents btnDesaplicar As System.Windows.Forms.Button
    Protected WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents cmbMostrarRegistros As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblBuscar As System.Windows.Forms.Label
End Class
