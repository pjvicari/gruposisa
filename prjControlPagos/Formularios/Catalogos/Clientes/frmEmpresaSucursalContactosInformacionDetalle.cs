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
    public partial class frmEmpresaSucursalContactosInformacionDetalle : Conexion.frmPlantillaInformacionDetalle
    {
        Sucursal _ClaseConexion = new Sucursal(Funciones.AñoDeOperacion, Funciones.Ambiente);

        public frmEmpresaSucursalContactosInformacionDetalle()
        {
            InitializeComponent();
        }

        private void frmEmpresaSucursalContactosInformacionDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Información de sucursal y listado de contactos";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 2029;
                ClaseDeConexion = _ClaseConexion;
                FormularioInformacion = new frmEmpresaSucursalContactoInformacion();

                AccesosPermitidos = "12345";

                // Consultas        
                SelectSQL = "CODIGO_SUCURSAL, NUMERO_SUCURSAL, NOMBRE_SUCURSAL, CODIGO_EMPRESA, DIRECCION_SUCURSAL, TELEFONOS_SUCURSAL, CODIGO_PAIS_SUCURSAL, CODIGO_DEPARTAMENTO_SUCURSAL, CODIGO_MUNICIPIO_SUCURSAL, NUM_EMPLEADOS_SUCURSAL, FECHA_REGISTRO, NIT_FACTURACION, NOMBRE_FACTURACION, E_MAIL_SUCURSAL";
                From = "CRM_SUCURSALES";
                Where = "";
                OrderBy = "CODIGO_SUCURSAL";

                VincularColumna("CODIGO_SUCURSAL", txtCodigoSucursal, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("CODIGO_EMPRESA", txtCodigoEmpresa, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("NUMERO_SUCURSAL", txtNumeroSucursal, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("NOMBRE_SUCURSAL", txtNombreSucursal, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("DIRECCION_SUCURSAL", txtDireccionSucursal, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("TELEFONOS_SUCURSAL", txtTelefonosSucursal, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_PAIS_SUCURSAL", cmbPais, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_DEPARTAMENTO_SUCURSAL", cmbDepartamento, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_MUNICIPIO_SUCURSAL", cmbMunicipio, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("NUM_EMPLEADOS_SUCURSAL", txtNumeroEmpleados, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("E_MAIL_SUCURSAL", txtEmailSucursal, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("NOMBRE_FACTURACION", txtNombreFacturacion, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("NIT_FACTURACION", txtNitFacturacion, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("FECHA_REGISTRO", dtpFechaRegistro, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);

                SelectSQLDetalle = "CCC.CODIGO_CLI_CONTACTO, CSU.CODIGO_SUCURSAL, CCO.CODIGO_CONTACTO, CCO.NOMBRE_CONTACTO, CCO.TELEFONOS_CONTACTO, CASE ESTADO_CONTACTO WHEN 1 THEN 'Activo' WHEN 0 THEN 'Inactivo' END AS ESTADO";
                FromDetalle = "CRM_CONTACTOS CCO INNER JOIN crm_clientes_contacto CCC ON CCO.CODIGO_CONTACTO = CCC.CODIGO_CONTACTO INNER JOIN crm_sucursales CSU ON CCC.TIPO_CLIENTE = CSU.TIPO_CLIENTE AND CCC.CODIGO_CLIENTE = CSU.CODIGO_SUCURSAL";
                OrderByDetalle = "CCC.CODIGO_CLI_CONTACTO";

                AgregarColumna("Código", "CODIGO_CLI_CONTACTO", 0, false, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Código", "CODIGO_SUCURSAL", 0, false, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Código", "CODIGO_CONTACTO", 10, false, DataGridViewContentAlignment.MiddleRight, false);
                AgregarColumna("Contacto", "NOMBRE_CONTACTO", 50, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("Teléfonos", "TELEFONOS_CONTACTO", 40, true, DataGridViewContentAlignment.MiddleLeft, false);


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

        private void txtNombreSucursal_TextChanged(object sender, EventArgs e)
        {
            if (TipoDeOperacion == Conexion.ModuloGeneral.Operacion.Agregar)
            {
                txtNombreFacturacion.Text = txtNombreSucursal.Text;
            }
        }

        private void txtNitFacturacion_TextChanged(object sender, EventArgs e)
        {
            
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
                txtCodigoEmpresa.Text = ObtenerLlavePrimariaDetalle("CODIGO_EMPRESA");
                txtCodigoSucursal.Text = "0";
                txtNitFacturacion.Text = "";
                txtNumeroSucursal.Text = "";
                txtNombreSucursal.Text = "";
                txtDireccionSucursal.Text = "";
                txtTelefonosSucursal.Text = "";
                txtEmailSucursal.Text = "";
                txtDireccionSucursal.Text = "";
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
                _ClaseConexion.CodigoSucursal = (int.TryParse(txtCodigoSucursal.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoEmpresa = (int.TryParse(txtCodigoEmpresa.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.NumEmpleadosSucursal = (int.TryParse(txtNumeroEmpleados.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.NombreSucursal = txtNombreSucursal.Text.Trim();
                _ClaseConexion.NumeroSucursal = (int.TryParse(txtNumeroSucursal.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.EmailSucursal = txtEmailSucursal.Text.Trim();
                _ClaseConexion.TelefonosSucursal = txtTelefonosSucursal.Text.Trim();
                _ClaseConexion.DireccionSucursal = txtDireccionSucursal.Text.Trim();
                _ClaseConexion.CodigoPaisSucursal = (int.TryParse(cmbPais.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoDepartamentoSucursal = (int.TryParse(cmbDepartamento.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoMunicipioSucursal = (int.TryParse(cmbMunicipio.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.NitFacturacion = txtNitFacturacion.Text.Trim();
                _ClaseConexion.NombreFacturacion = txtNombreFacturacion.Text.Trim();
                _ClaseConexion.EstadoSucursal = 1;

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
                if ((bool)_ClaseConexion.OperarSucursal())
                {
                    _Resultado = true;
                    AgregarLlavePrimaria("CODIGO_SUCURSAL", _ClaseConexion.CodigoEmpresa);
                    AgregarLlavePrimariaDetalle("CODIGO_SUCURSAL", _ClaseConexion.CodigoEmpresa);
                    MessageBox.Show("Sucursal agregada satisfactoriamente", "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarSucursal())
                {
                    _Resultado = true;
                    MessageBox.Show("Sucursal modificada satisfactoriamente", "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarSucursal())
                {
                    _Resultado = true;
                    MessageBox.Show("Sucursal eliminada satisfactoriamente", "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
