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
    public partial class frmCorporacionEmpresaInformacionDetalle : Conexion.frmPlantillaInformacionDetalle
    {
        Corporacion _ClaseConexion = new Corporacion(Funciones.AñoDeOperacion, Funciones.Ambiente);
        public frmCorporacionEmpresaInformacionDetalle()
        {
            InitializeComponent();
        }

        private void frmCorporacionInformacionDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Información de corporacion y listado de empresas";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 2029;
                ClaseDeConexion = _ClaseConexion;
                FormularioInformacion = new frmCorporacionEmpresaInformacion();

                AccesosPermitidos = "12345";

                // Consultas        
                SelectSQL = "CODIGO_CORPORACION, NOMBRE_CORPORACION, DIRECCION_CORPORACION, CODIGO_PAIS_CORPORACION, CODIGO_DEPARTAMENTO_CORPORACION, CODIGO_MUNICIPIO_CORPORACION, CATEGORIA_CORPORACION, FECHA_REGISTRO, TELEFONO_CORPORACION, E_MAIL_CORPORACION";
                From = "CRM_CORPORACIONES";
                Where = "";
                OrderBy = "CODIGO_CORPORACION";

                VincularColumna("CODIGO_CORPORACION", txtCodigoCorporacion, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("NOMBRE_CORPORACION", txtNombreCorporacion, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("DIRECCION_CORPORACION", txtDireccionCorporacion, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_PAIS_CORPORACION", cmbPais, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_DEPARTAMENTO_CORPORACION", cmbDepartamento, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_MUNICIPIO_CORPORACION", cmbMunicipio, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CATEGORIA_CORPORACION", txtCategoriaCorporacion, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("FECHA_REGISTRO", dtpFechaRegistro, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("TELEFONO_CORPORACION", txtTelefonosCorporacion, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("E_MAIL_CORPORACION", txtEmailCorporacion, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);


                SelectSQLDetalle = "CODIGO_CORPORACION, CODIGO_EMPRESA, NIT_EMPRESA, NOMBRE_EMPRESA, DIRECCION_EMPRESA";
                FromDetalle = "CRM_EMPRESAS";
                GroupBy = "";

                AgregarColumna("Código", "CODIGO_CORPORACION", 0, false, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Código", "CODIGO_EMPRESA", 10, false, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Nit", "NIT_EMPRESA", 20, true, DataGridViewContentAlignment.MiddleRight, false);
                AgregarColumna("Tipo de cliente", "NOMBRE_EMPRESA", 40, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("Cliente", "DIRECCION_EMPRESA", 30, true, DataGridViewContentAlignment.MiddleLeft, false);


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
                if (cmbPais.SelectedValue.ToString() != "System.Data.DataRowView")
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

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbDepartamento.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    DataTable dtMunicipios = new DataTable();
                    _ClaseConexion.AsignarParametroWhere("CODIGO_PAIS", cmbPais.SelectedValue.ToString(), Conexion.ModuloGeneral.TipoDeOperadorLogico.AndOperador, Conexion.ModuloGeneral.TipoDeOperadorDeComparacion.Igual, true);
                    _ClaseConexion.AsignarParametroWhere("CODIGO_DEPARTAMENTO", cmbDepartamento.SelectedValue.ToString(), Conexion.ModuloGeneral.TipoDeOperadorLogico.AndOperador, Conexion.ModuloGeneral.TipoDeOperadorDeComparacion.Igual, true);
                    _ClaseConexion.AsignarParametroWhere("ESTADO_MUNICIPIO", 1, Conexion.ModuloGeneral.TipoDeOperadorLogico.AndOperador, Conexion.ModuloGeneral.TipoDeOperadorDeComparacion.Igual, true);
                    if ((bool)_ClaseConexion.CargarDatos(ref dtMunicipios, "CODIGO_MUNICIPIO, NOMBRE_MUNICIPIO", "MUNICIPIOS"))
                    {
                        _ClaseConexion.Llenar_ComboBox(cmbMunicipio, dtMunicipios, "CODIGO_MUNICIPIO", "NOMBRE_MUNICIPIO", "Escoja un municipio");
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
                txtCodigoCorporacion.Text = "0";
                txtCategoriaCorporacion.Text = "";
                txtNombreCorporacion.Text = "";
                txtTelefonosCorporacion.Text = "";
                txtEmailCorporacion.Text = "";
                txtDireccionCorporacion.Text = "";
                cmbPais.SelectedValue = 1;
                cmbDepartamento.SelectedValue = 0;
                cmbMunicipio.SelectedValue = 0;
                dtpFechaRegistro.Value = DateTime.Now;
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
                _ClaseConexion.NombreCorporacion = txtNombreCorporacion.Text.Trim();
                _ClaseConexion.CategoriaCorporacion = txtCategoriaCorporacion.Text.Trim();
                _ClaseConexion.EMailCorporacion = txtEmailCorporacion.Text.Trim();
                _ClaseConexion.TelefonoCorporacion = txtTelefonosCorporacion.Text.Trim();
                _ClaseConexion.DireccionCorporacion = txtDireccionCorporacion.Text.Trim();
                _ClaseConexion.CodigoPaisCorporacion = (int.TryParse(cmbPais.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoDepartamentoCorporacion = (int.TryParse(cmbDepartamento.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoMunicipioCorporacion = (int.TryParse(cmbMunicipio.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.EstadoCorporacion = 1;

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
                if ((bool)_ClaseConexion.OperarCorporacion())
                {
                    _Resultado = true;
                    MessageBox.Show("Corporacion agregada satisfactoriamente", "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarCorporacion())
                {
                    _Resultado = true;
                    MessageBox.Show("Corporacion modificada satisfactoriamente", "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarCorporacion())
                {
                    _Resultado = true;
                    MessageBox.Show("Corporacion eliminada satisfactoriamente", "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
