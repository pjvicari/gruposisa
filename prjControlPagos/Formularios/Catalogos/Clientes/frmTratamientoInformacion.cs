using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace ControlPagos.Formularios.Catalogos.Clientes
{
    public partial class frmTratamientoInformacion : Conexion.frmPlantillaInformacion
    {
        Tratamiento _ClaseConexion = new Tratamiento(Funciones.AñoDeOperacion, Funciones.Ambiente);
        public frmTratamientoInformacion()
        {
            InitializeComponent();
        }

        private void frmTratamientoInformacion_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Información de pais";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 2029;
                ClaseDeConexion = _ClaseConexion;


                // Consultas        
                SelectSQL = "CODIGO_TRATAMIENTO, SIGLAS_TRATAMIENTO, TRATAMIENTO, ESTADO_TRATAMIENTO";
                From = "CRM_TRATAMIENTOS";
                Where = "";
                OrderBy = "CODIGO_TRATAMIENTO";

                VincularColumna("CODIGO_TRATAMIENTO", txtCodigoTratamiento, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("SIGLAS_TRATAMIENTO", txtSiglasTratamiento, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("TRATAMIENTO", txtTratamiento, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);

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
                txtCodigoTratamiento.Text = "0";
                txtSiglasTratamiento.Text = "";
                txtTratamiento.Text = "";
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
                _ClaseConexion.CodigoTratamiento = (int.TryParse(txtCodigoTratamiento.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.SiglasTratamiento = txtSiglasTratamiento.Text.Trim();
                _ClaseConexion.Tratamientos = txtTratamiento.Text.Trim();
                _ClaseConexion.EstadoTratamiento = 1;

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
                if ((bool)_ClaseConexion.OperarTratamiento())
                {
                    _Resultado = true;
                    MessageBox.Show("Tratamiento agregado satisfactoriamente", "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarTratamiento())
                {
                    _Resultado = true;
                    MessageBox.Show("Tratamiento modificado satisfactoriamente", "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarTratamiento())
                {
                    _Resultado = true;
                    MessageBox.Show("Tratamiento eliminado satisfactoriamente", "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
