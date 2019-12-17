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
    public partial class frmEmpresaSucursalesInformacionDetalle : Conexion.frmPlantillaInformacionDetalle
    {
        Empresa _ClaseConexion = new Empresa(Funciones.AñoDeOperacion, Funciones.Ambiente);

        public frmEmpresaSucursalesInformacionDetalle()
        {
            InitializeComponent();
        }

        private void frmEmpresaSucursalesInformacionDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Información de empresa y listado de sucursales";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 2029;
                ClaseDeConexion = _ClaseConexion;
                FormularioInformacionDetalle = new frmEmpresaSucursalContactosInformacionDetalle();

                AccesosPermitidos = "12345";

                // Consultas        
                SelectSQL = "CODIGO_EMPRESA, NIT_EMPRESA, NOMBRE_EMPRESA, DIRECCION_EMPRESA, CODIGO_PAIS_EMPRESA, CODIGO_DEPARTAMENTO_EMPRESA, CODIGO_MUNICIPIO_EMPRESA, TELEFONO_EMPRESA, E_MAIL_EMPRESA, DIRECCION_INTERNET, NUMERO_EMPLEADOS, FECHA_REGISTRO, NOMBRE_FACTURACION, NIT_FACTURACION";
                From = "CRM_EMPRESAS";
                Where = "";
                OrderBy = "CODIGO_EMPRESA";

                VincularColumna("CODIGO_EMPRESA", txtCodigoEmpresa, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("NIT_EMPRESA", txtNitEmpresa, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("NOMBRE_EMPRESA", txtNombreEmpresa, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("DIRECCION_EMPRESA", txtDirecccionEmpresa, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_PAIS_EMPRESA", cmbPais, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_DEPARTAMENTO_EMPRESA", cmbDepartamento, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_MUNICIPIO_EMPRESA", cmbMunicipio, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("TELEFONO_EMPRESA", txtTelefonoEmpresa, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("E_MAIL_EMPRESA", txtEmailEmpresa, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("DIRECCION_INTERNET", txtDireccionInternet, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("NUMERO_EMPLEADOS", txtNumeroEmpleados, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("NOMBRE_FACTURACION", txtNombreFacturacion, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("NIT_FACTURACION", txtNitFacturacion, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("FECHA_REGISTRO", dtpFechaRegistro, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);

                SelectSQLDetalle = "CODIGO_SUCURSAL, CODIGO_EMPRESA, NUMERO_SUCURSAL, NOMBRE_SUCURSAL, CASE ESTADO_SUCURSAL WHEN 1 THEN 'Activo' WHEN 0 THEN 'Inactivo' END AS ESTADO";
                FromDetalle = "CRM_SUCURSALES";
                OrderByDetalle = "NUMERO_SUCURSAL";

                AgregarColumna("Código", "CODIGO_SUCURSAL", 10, false, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Código emp", "CODIGO_EMPRESA", 0, false, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Número", "NUMERO_SUCURSAL", 10, false, DataGridViewContentAlignment.MiddleRight, false);
                AgregarColumna("Nombre sucursal", "NOMBRE_SUCURSAL", 60, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("Estado", "ESTADO", 20, true, DataGridViewContentAlignment.MiddleLeft, false);


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

        private void txtNitEmpresa_TextChanged(object sender, EventArgs e)
        {
            if(TipoDeOperacion == Conexion.ModuloGeneral.Operacion.Agregar)
            {
                txtNitFacturacion.Text = txtNitEmpresa.Text;
            }
        }

        private void txtNombreEmpresa_TextChanged(object sender, EventArgs e)
        {
            if (TipoDeOperacion == Conexion.ModuloGeneral.Operacion.Agregar)
            {
                txtNombreFacturacion.Text = txtNombreEmpresa.Text;
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
                txtCodigoEmpresa.Text = "0";
                txtNitFacturacion.Text = "";
                txtNitEmpresa.Text = "";
                txtNombreEmpresa.Text = "";
                txtDireccionInternet.Text = "";
                txtTelefonoEmpresa.Text = "";
                txtEmailEmpresa.Text = "";
                txtDireccionInternet.Text = "";
                txtNumeroEmpleados.Text = "";
                txtNombreFacturacion.Text = "";
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
                _ClaseConexion.CodigoEmpresa = (int.TryParse(txtCodigoEmpresa.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.NitEmpresa = txtNitEmpresa.Text.Trim();
                _ClaseConexion.NumeroEmpleados = (int.TryParse(txtNumeroEmpleados.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.NombreEmpresa = txtNombreEmpresa.Text.Trim();
                _ClaseConexion.DireccionInternet = txtDireccionInternet.Text.Trim();
                _ClaseConexion.EMailEmpresa = txtEmailEmpresa.Text.Trim();
                _ClaseConexion.TelefonoEmpresa = txtTelefonoEmpresa.Text.Trim();
                _ClaseConexion.DireccionEmpresa = txtDirecccionEmpresa.Text.Trim();
                _ClaseConexion.CodigoPaisEmpresa = (int.TryParse(cmbPais.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoDepartamentoEmpresa = (int.TryParse(cmbDepartamento.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoMunicipioEmpresa = (int.TryParse(cmbMunicipio.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.NitFacturacion = txtNitFacturacion.Text.Trim();
                _ClaseConexion.NombreFacturacion = txtNombreFacturacion.Text.Trim();
                _ClaseConexion.EstadoEmpresa = 1;

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
                if ((bool)_ClaseConexion.OperarEmpresa())
                {
                    _Resultado = true;
                    AgregarLlavePrimaria("CODIGO_EMPRESA", _ClaseConexion.CodigoEmpresa);
                    AgregarLlavePrimariaDetalle("CODIGO_EMPRESA", _ClaseConexion.CodigoEmpresa);
                    MessageBox.Show("Empresa agregada satisfactoriamente", "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarEmpresa())
                {
                    _Resultado = true;
                    MessageBox.Show("Empresa modificada satisfactoriamente", "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarEmpresa())
                {
                    _Resultado = true;
                    MessageBox.Show("Empresa eliminada satisfactoriamente", "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
