using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace ControlPagos.Formularios.Catalogos.Productos
{
    public partial class frmProductosInformacion : Conexion.frmPlantillaInformacion
    {
        Negocio.Productos _ClaseConexion = new Negocio.Productos(Funciones.AñoDeOperacion, Funciones.Ambiente);
        public frmProductosInformacion()
        {
            InitializeComponent();
        }

        private void frmProductosInformacion_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Información de pais";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 2029;
                ClaseDeConexion = _ClaseConexion;


                // Consultas        
                SelectSQL = "CODIGO_PRODUCTO, NOMBRE_PRODUCTO, DESCRIPCION_PRODUCTO, PRECIO_SUGERIDO, COSTO_NETO, IMPUESTO, PORCENTAJE_IMPUESTO, TIPO_PRODUCTO, CODIGO_UNIDAD_MEDIDA, ESTADO_PRODUCTO";
                From = "PRODUCTOS";
                Where = "";
                OrderBy = "CODIGO_PRODUCTO";

                VincularColumna("CODIGO_PRODUCTO", txtCodigoProducto, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("NOMBRE_PRODUCTO", txtNombreProducto, HorizontalAlignment.Left, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("DESCRIPCION_PRODUCTO", txtDescripcionProducto, HorizontalAlignment.Left, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("PRECIO_SUGERIDO", txtPrecioSugerido, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("COSTO_NETO", txtCostoNeto, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("IMPUESTO", txtImpuesto, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("PORCENTAJE_IMPUESTO", txtPorcentajeImpuesto, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("TIPO_PRODUCTO", cmbTipoProducto, HorizontalAlignment.Left, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_UNIDAD_MEDIDA", cmbUnidadMedida, HorizontalAlignment.Left, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);


                DataTable dtTipoProducto = new DataTable();
                if ((bool)_ClaseConexion.CargarDatos(ref dtTipoProducto, "CODIGO, NOMBRE", "(SELECT 1 AS CODIGO, 'Producto' as NOMBRE FROM DUAL UNION ALL SELECT 2 AS CODIGO, 'Servicio' as NOMBRE FROM DUAL) TIPO_SERVICIO"))
                {
                    _ClaseConexion.Llenar_ComboBox(cmbTipoProducto, dtTipoProducto, "CODIGO", "NOMBRE", "Seleccione un tipo");
                }

                DataTable dtUnidadMedida = new DataTable();
                _ClaseConexion.AsignarParametroWhere("ESTADO_MEDIDA", 1, Conexion.ModuloGeneral.TipoDeOperadorLogico.AndOperador, Conexion.ModuloGeneral.TipoDeOperadorDeComparacion.Igual, false);
                if ((bool)_ClaseConexion.CargarDatos(ref dtUnidadMedida, "CODIGO_UNIDAD_MEDIDA, NOMBRE_UNIDAD_MEDIDA", "UNIDADES_MEDIDA"))
                {
                    _ClaseConexion.Llenar_ComboBox(cmbUnidadMedida, dtUnidadMedida, "CODIGO_UNIDAD_MEDIDA", "NOMBRE_UNIDAD_MEDIDA", "No aplica");
                }

                InicializarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void LimpiarCampos()
        {
            try
            {
                txtCodigoProducto.Text = "0";
                txtNombreProducto.Text = "";
                txtDescripcionProducto.Text = "";
                txtPrecioSugerido.Text = "";
                txtCostoNeto.Text = "";
                txtImpuesto.Text = "";
                txtPorcentajeImpuesto.Text = "12";
                cmbTipoProducto.SelectedValue = 0;
                cmbUnidadMedida.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al limpiar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AsignarCampos()
        {
            try
            {
                int _Numero = 0;
                double _Cifra = 0;
                _ClaseConexion.CodigoProducto = (int.TryParse(txtCodigoProducto.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.NombreProducto = txtNombreProducto.Text.Trim();
                _ClaseConexion.DescripcionProducto = txtDescripcionProducto.Text.Trim();
                _ClaseConexion.CodigoUnidadMedida = (int.TryParse(cmbUnidadMedida.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.TipoProducto = (int.TryParse(cmbTipoProducto.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.PrecioSugerido = (double.TryParse(txtPrecioSugerido.Text, out _Cifra)) ? _Cifra : 0;
                _ClaseConexion.CostoNeto = (double.TryParse(txtCostoNeto.Text, out _Cifra)) ? _Cifra : 0;
                _ClaseConexion.Impuesto = (double.TryParse(txtImpuesto.Text, out _Cifra)) ? _Cifra : 0;
                _ClaseConexion.PorcentajeImpuesto = (double.TryParse(txtPorcentajeImpuesto.Text, out _Cifra)) ? _Cifra : 0;
                _ClaseConexion.EstadoProducto = 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al limpiar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Agregar()
        {
            bool _Resultado = false;
            try
            {
                AsignarCampos();
                _ClaseConexion.TipoDeOperacion = Conexion.ModuloGeneral.TipoDeOperacion.Agregar;
                if ((bool)_ClaseConexion.OperarProducto())
                {
                    _Resultado = true;
                    MessageBox.Show("Producto agregado satisfactoriamente", "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _Resultado = false;
                    MessageBox.Show(_ClaseConexion.Mensaje, "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _Resultado;
        }

        public override bool Modificar()
        {
            bool _Resultado = false;
            try
            {
                AsignarCampos();
                _ClaseConexion.TipoDeOperacion = Conexion.ModuloGeneral.TipoDeOperacion.Modificar;
                if ((bool)_ClaseConexion.OperarProducto())
                {
                    _Resultado = true;
                    MessageBox.Show("Producto modificado satisfactoriamente", "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _Resultado = false;
                    MessageBox.Show(_ClaseConexion.Mensaje, "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _Resultado;
        }

        public override bool Eliminar()
        {
            bool _Resultado = false;
            try
            {
                AsignarCampos();
                _ClaseConexion.TipoDeOperacion = Conexion.ModuloGeneral.TipoDeOperacion.Eliminar;
                if ((bool)_ClaseConexion.OperarProducto())
                {
                    _Resultado = true;
                    MessageBox.Show("Producto eliminado satisfactoriamente", "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _Resultado = false;
                    MessageBox.Show(_ClaseConexion.Mensaje, "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _Resultado;
        }

        private void txtPorcentajeImpuesto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double _Cifra = 0;
                txtImpuesto.Text = Math.Round((((double.TryParse(txtPrecioSugerido.Text, out _Cifra)) ? _Cifra : 0) * (((double.TryParse(txtPorcentajeImpuesto.Text, out _Cifra)) ? _Cifra : 0) / 100)), 2).ToString(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al calcular impuesto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
