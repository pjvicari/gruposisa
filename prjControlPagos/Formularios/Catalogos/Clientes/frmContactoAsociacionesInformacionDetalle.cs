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
    public partial class frmContactoAsociacionesInformacionDetalle : Conexion.frmPlantillaInformacionDetalle
    {
        Contacto _ClaseConexion = new Contacto(Funciones.AñoDeOperacion, Funciones.Ambiente);
        public frmContactoAsociacionesInformacionDetalle()
        {
            InitializeComponent();
        }

        private void frmContactoAsociacionesInformacionDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Información de contacto y listado de asociaciones";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 2029;
                ClaseDeConexion = _ClaseConexion;
                FormularioInformacion = new frmContactoAsociacionInformacion();

                AccesosPermitidos = "12345";

                // Consultas        
                SelectSQL = "CODIGO_CONTACTO, NIT_FACTURACION, IDENTIFICACION_CONTACTO, CODIGO_TRATAMIENTO, NOMBRE_CONTACTO, CARGO_CONTACTO, E_MAIL_CONTACTO, TELEFONOS_CONTACTO, DIRECCION_CONTACTO, CODIGO_PAIS_CONTACTO, CODIGO_DEPARTAMENTO_CONTACTO, CODIGO_MUNICIPIO_CONTACTO,NOMBRE_FACTURACION,FECHA_REGISTRO";
                From = "CRM_CONTACTOS";
                Where = "";
                OrderBy = "CODIGO_CONTACTO";

                VincularColumna("CODIGO_CONTACTO", txtCodigoContacto, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("NIT_FACTURACION", txtNitFacturacion, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("IDENTIFICACION_CONTACTO", txtIdentificacion, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_TRATAMIENTO", cmbTratamiento, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("NOMBRE_CONTACTO", txtNombreContacto, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CARGO_CONTACTO", txtCargoContacto, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("E_MAIL_CONTACTO", txtEmailContacto, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("TELEFONOS_CONTACTO", txtTelefonosContacto, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("DIRECCION_CONTACTO", txtDireccionContacto, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_PAIS_CONTACTO", cmbPais, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_DEPARTAMENTO_CONTACTO", cmbDepartamento, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("CODIGO_MUNICIPIO_CONTACTO", cmbMunicipio, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("NOMBRE_FACTURACION", txtNombreFacturacion, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("FECHA_REGISTRO", dtpFechaRegistro, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);

                //QuitarLlavesDetalle = true;
                SelectSQLDetalle = "CODIGO_CLI_CONTACTO, CODIGO_CONTACTO, CODIGO_CLIENTE, TIPO_CLIENTE, NOMBRE_TIPO, NOMBRE_CLIENTE";
                FromDetalle = "(SELECT CCC.CODIGO_CLI_CONTACTO, CCO.CODIGO_CONTACTO, CCC.CODIGO_CLIENTE, CCC.TIPO_CLIENTE, CASE CCC.TIPO_CLIENTE WHEN 1 THEN 'CONTACTO' WHEN 2 THEN 'SUCURSAL' WHEN 3 THEN 'EMPRESA' WHEN 4 THEN 'CORPORACION' END AS NOMBRE_TIPO, CASE CCC.TIPO_CLIENTE WHEN 1 THEN CCO.NOMBRE_CONTACTO WHEN 2 THEN CSU.NOMBRE_SUCURSAL WHEN 3 THEN CEM.NOMBRE_EMPRESA WHEN 4 THEN CCR.NOMBRE_CORPORACION END AS NOMBRE_CLIENTE FROM gruposisa.crm_clientes_contacto CCC LEFT OUTER JOIN gruposisa.CRM_CONTACTOS CCO ON CCO.CODIGO_CONTACTO = CCC.CODIGO_CONTACTO LEFT OUTER JOIN gruposisa.crm_sucursales CSU ON CCC.TIPO_CLIENTE = CSU.TIPO_CLIENTE AND CCC.CODIGO_CLIENTE = CSU.CODIGO_SUCURSAL LEFT OUTER JOIN gruposisa.crm_empresas CEM ON CCC.TIPO_CLIENTE = CEM.TIPO_CLIENTE AND CCC.CODIGO_CLIENTE = CEM.CODIGO_EMPRESA LEFT OUTER JOIN gruposisa.crm_corporaciones CCR ON CCC.TIPO_CLIENTE = CSU.TIPO_CLIENTE AND CCC.CODIGO_CLIENTE = CCR.CODIGO_CORPORACION) CLIENTES";
                //WhereDetalle = " AND CODIGO_CONTACTO = " + ObtenerLlavePrimaria("CODIGO_CONTACTO");

                AgregarColumna("Código", "CODIGO_CLI_CONTACTO", 0, false, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Código", "CODIGO_CONTACTO", 0, false, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Código", "CODIGO_CLIENTE", 0, false, DataGridViewContentAlignment.MiddleRight, false);
                AgregarColumna("Código", "TIPO_CLIENTE", 0, false, DataGridViewContentAlignment.MiddleRight, false);
                AgregarColumna("Tipo de cliente", "NOMBRE_TIPO", 30, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("Cliente", "NOMBRE_CLIENTE", 70, true, DataGridViewContentAlignment.MiddleLeft, false);
                

                DataTable dtPaises = new DataTable();
                _ClaseConexion.AsignarParametroWhere("ESTADO_PAIS", 1, Conexion.ModuloGeneral.TipoDeOperadorLogico.AndOperador, Conexion.ModuloGeneral.TipoDeOperadorDeComparacion.Igual, true);
                if ((bool)_ClaseConexion.CargarDatos(ref dtPaises, "CODIGO_PAIS, NOMBRE_PAIS", "PAISES"))
                {
                    _ClaseConexion.Llenar_ComboBox(cmbPais, dtPaises, "CODIGO_PAIS", "NOMBRE_PAIS", "Escoja un pais");
                }

                DataTable dtTratamiento = new DataTable();
                _ClaseConexion.AsignarParametroWhere("ESTADO_TRATAMIENTO", 1, Conexion.ModuloGeneral.TipoDeOperadorLogico.AndOperador, Conexion.ModuloGeneral.TipoDeOperadorDeComparacion.Igual, true);
                if ((bool)_ClaseConexion.CargarDatos(ref dtTratamiento, "CODIGO_TRATAMIENTO, TRATAMIENTO", "CRM_TRATAMIENTOS"))
                {
                    _ClaseConexion.Llenar_ComboBox(cmbTratamiento, dtTratamiento, "CODIGO_TRATAMIENTO", "TRATAMIENTO", "Escoja un tratamiento");
                }
                //string _CodigoGuardado = ObtenerLlavePrimaria("CODIGO_CONTACTO");
                InicializarFormulario();
                //AgregarLlavePrimaria("CODIGO_CONTACTO", _CodigoGuardado);
                //AgregarLlavePrimariaDetalle("CODIGO_CONTACTO", _CodigoGuardado);
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
                txtCodigoContacto.Text = "0";
                txtNitFacturacion.Text = "";
                txtIdentificacion.Text = "";
                cmbTratamiento.SelectedValue = 0;
                txtNombreContacto.Text = "";
                txtCargoContacto.Text = "";
                txtTelefonosContacto.Text = "";
                txtEmailContacto.Text = "";
                txtDireccionContacto.Text = "";
                txtNombreFacturacion.Text = "";
                cmbPais.SelectedValue = 1;
                cmbDepartamento.SelectedValue = 0;
                cmbMunicipio.SelectedValue = 0;
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
                _ClaseConexion.CodigoContacto = (int.TryParse(txtCodigoContacto.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.NitFacturacion = txtNitFacturacion.Text.Trim();
                _ClaseConexion.IdentificacionContacto = txtIdentificacion.Text.Trim();
                _ClaseConexion.CodigoTratamiento = (int.TryParse(cmbTratamiento.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.NombreContacto = txtNombreContacto.Text.Trim();
                _ClaseConexion.CargoContacto = txtCargoContacto.Text.Trim();
                _ClaseConexion.EMailContacto = txtEmailContacto.Text.Trim();
                _ClaseConexion.TelefonosContacto = txtTelefonosContacto.Text.Trim();
                _ClaseConexion.DireccionContacto = txtDireccionContacto.Text.Trim();
                _ClaseConexion.CodigoPaisContacto = (int.TryParse(cmbPais.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoDepartamentoContacto = (int.TryParse(cmbDepartamento.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoMunicipioContacto = (int.TryParse(cmbMunicipio.SelectedValue.ToString(), out _Numero)) ? _Numero : 0;
                _ClaseConexion.NombreFacturacion = txtNombreFacturacion.Text.Trim();
                _ClaseConexion.EstadoContacto = 1;

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
                if ((bool)_ClaseConexion.OperarContacto())
                {
                    _Resultado = true;
                    MessageBox.Show("Contacto agregado satisfactoriamente", "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarContacto())
                {
                    _Resultado = true;
                    MessageBox.Show("Contacto modificado satisfactoriamente", "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarContacto())
                {
                    _Resultado = true;
                    MessageBox.Show("Contacto eliminado satisfactoriamente", "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtNombreContacto_TextChanged(object sender, EventArgs e)
        {
            if(TipoDeOperacion == Conexion.ModuloGeneral.Operacion.Agregar)
            {
                txtNombreFacturacion.Text = txtNombreContacto.Text;
            }
        }
    }
}
