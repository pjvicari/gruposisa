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
    public partial class frmMunicipioInformacion : Conexion.frmPlantillaInformacion
    {
        Municipio _ClaseConexion = new Municipio(Funciones.AñoDeOperacion, Funciones.Ambiente);
        public frmMunicipioInformacion()
        {
            InitializeComponent();
        }

        private void frmMunicipioInformacion_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Información de departamento";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 2029;
                ClaseDeConexion = _ClaseConexion;


                // Consultas        
                SelectSQL = "CODIGO_MUNICIPIO, CODIGO_DEPARTAMENTO, NOMBRE_MUNICIPIO, CODIGO_PAIS";
                From = "MUNICIPIOS";
                Where = "";
                OrderBy = "CODIGO_MUNICIPIO";

                VincularColumna("CODIGO_MUNICIPIO", txtCodigoMunicipio, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("CODIGO_PAIS", cmbPais, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("NOMBRE_MUNICIPIO", cmbDepartamento, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("NOMBRE_DEPARTAMENTO", txtNombreMunicipio, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);


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

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cmbPais.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    DataTable dtDepartamentos = new DataTable();
                    _ClaseConexion.AsignarParametroWhere("CODIGO_PAIS", cmbPais.SelectedValue.ToString(), Conexion.ModuloGeneral.TipoDeOperadorLogico.AndOperador, Conexion.ModuloGeneral.TipoDeOperadorDeComparacion.Igual, true);
                    _ClaseConexion.AsignarParametroWhere("ESTADO_DEPARTAMENTO", 1, Conexion.ModuloGeneral.TipoDeOperadorLogico.AndOperador, Conexion.ModuloGeneral.TipoDeOperadorDeComparacion.Igual, true);
                    if ((bool)_ClaseConexion.CargarDatos(ref dtDepartamentos, "CODIGO_DEPARTAMENTO, NOMBRE_DEPARTAMENTO", "DEPARTAMENTOS"))
                    {
                        _ClaseConexion.Llenar_ComboBox(cmbDepartamento, dtDepartamentos, "CODIGO_DEPARTAMENTO", "NOMBRE_DEPARTAMENTO", "Escoja un departamento");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al llenar departamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void LimpiarCampos()
        {
            try
            {
                txtCodigoMunicipio.Text = "0";
                txtNombreMunicipio.Text = "";
                cmbPais.SelectedValue = 1;
                cmbDepartamento.SelectedValue = 0;
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
                _ClaseConexion.CodigoMunicipio = (int.TryParse(txtCodigoMunicipio.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoPais = (int.TryParse(cmbPais.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoDepartamento = (int.TryParse(cmbDepartamento.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.NombreMunicipio = txtNombreMunicipio.Text.Trim();
                _ClaseConexion.EstadoMunicipio = 1;

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
                if ((bool)_ClaseConexion.OperarMunicipio())
                {
                    _Resultado = true;
                    MessageBox.Show("Municipio agregado satisfactoriamente", "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarMunicipio())
                {
                    _Resultado = true;
                    MessageBox.Show("Municipio modificado satisfactoriamente", "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarMunicipio())
                {
                    _Resultado = true;
                    MessageBox.Show("Municipio eliminado satisfactoriamente", "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
