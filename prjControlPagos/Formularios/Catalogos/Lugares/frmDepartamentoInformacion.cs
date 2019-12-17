using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace ControlPagos.Formularios.Catalogos.Lugares
{
    public partial class frmDepartamentoInformacion : Conexion.frmPlantillaInformacion
    {
        Departamento _ClaseConexion = new Departamento(Funciones.AñoDeOperacion, Funciones.Ambiente);
        public frmDepartamentoInformacion()
        {
            InitializeComponent();
        }

        private void frmDepartamentoInformacion_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Información de departamento";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 2029;
                ClaseDeConexion = _ClaseConexion;


                // Consultas        
                SelectSQL = "CODIGO_DEPARTAMENTO, CODIGO_PAIS, NOMBRE_DEPARTAMENTO";
                From = "DEPARTAMENTOS";
                Where = "";
                OrderBy = "CODIGO_DEPARTAMENTO";

                VincularColumna("CODIGO_DEPARTAMENTO", txtCodigoDepartamento, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("NOMBRE_DEPARTAMENTO", txtNombreDepartamento, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_PAIS", cmbPais, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);


                DataTable dtPaises = new DataTable();
                _ClaseConexion.AsignarParametroWhere("ESTADO_PAIS", 1, Conexion.ModuloGeneral.TipoDeOperadorLogico.AndOperador, Conexion.ModuloGeneral.TipoDeOperadorDeComparacion.Igual, true);
                if ((bool)_ClaseConexion.CargarDatos(ref dtPaises, "CODIGO_PAIS, NOMBRE_PAIS", "PAISES"))
                {
                    _ClaseConexion.Llenar_ComboBox(cmbPais, dtPaises, "CODIGO_PAIS", "NOMBRE_PAIS", "Escoja un pais");
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
                txtCodigoDepartamento.Text = "0";
                txtNombreDepartamento.Text = "";
                cmbPais.SelectedValue = 1;
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
                _ClaseConexion.CodigoDepartamento = (int.TryParse(txtCodigoDepartamento.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoPais = (int.TryParse(cmbPais.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.NombreDepartamento = txtNombreDepartamento.Text.Trim();
                _ClaseConexion.EstadoDepartamento = 1;

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
                if ((bool)_ClaseConexion.OperarDepartamento())
                {
                    _Resultado = true;
                    MessageBox.Show("Departamento agregado satisfactoriamente", "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarDepartamento())
                {
                    _Resultado = true;
                    MessageBox.Show("Departamento modificado satisfactoriamente", "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarDepartamento())
                {
                    _Resultado = true;
                    MessageBox.Show("Departamento eliminado satisfactoriamente", "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
