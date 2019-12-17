using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace ControlPagos.Formularios.Catalogos
{
    public partial class frmCorporacionEmpresaInformacion : Conexion.frmPlantillaInformacion
    {
        Empresa _ClaseConexion = new Empresa(Funciones.AñoDeOperacion, Funciones.Ambiente);
        public frmCorporacionEmpresaInformacion()
        {
            InitializeComponent();
        }

        private void frmCorporacionEmpresaInformacion_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Información de la empresa";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 2029;
                ClaseDeConexion = _ClaseConexion;


                // Consultas        
                SelectSQL = "CODIGO_CORPORACION, CODIGO_EMPRESA, NOMBRE_EMPRESA";
                From = "CRM_EMPRESAS";
                Where = "";
                //OrderBy = "CODIGO_TRATAMIENTO";

                VincularColumna("CODIGO_CORPORACION", txtCodigoCorporacion, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("CODIGO_EMPRESA", txtCodigoEmpresa, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("NOMBRE_EMPRESA", txtNombreEmpresa, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("", btnEmpresa, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);

                InicializarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow Producto;

                Busquedas.frmClienteBusqueda _Busqueda = new Busquedas.frmClienteBusqueda();
                _Busqueda.FiltroCliente = "1,2,4";
                _Busqueda.ShowDialog(this);
                Producto = _Busqueda.FilaSeleccionada;
                if (Producto != null)
                {
                    txtCodigoEmpresa.Text = Producto.Cells["CODIGO_CLIENTE"].Value.ToString();
                    txtNombreEmpresa.Text = Producto.Cells["NOMBRE_CLIENTE"].Value.ToString();
                }

                _Busqueda.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al buscar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void LimpiarCampos()
        {
            try
            {
                txtCodigoCorporacion.Text = ObtenerLlavePrimariaDetalle("CODIGO_CORPORACION");
                txtCodigoEmpresa.Text = "";
                txtNombreEmpresa.Text = "";
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
                _ClaseConexion.CodigoCorporacion = (int.TryParse(txtCodigoCorporacion.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoEmpresa = (int.TryParse(txtCodigoEmpresa.Text, out _Numero)) ? _Numero : 0;

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
                if ((bool)_ClaseConexion.OperarRelacionCorporacion())
                {
                    _Resultado = true;
                    MessageBox.Show("Relación agregada satisfactoriamente", "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarRelacionCorporacion())
                {
                    _Resultado = true;
                    MessageBox.Show("Relación modificada satisfactoriamente", "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarRelacionCorporacion())
                {
                    _Resultado = true;
                    MessageBox.Show("Relación eliminada satisfactoriamente", "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
