using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Negocio
{
    public class Empresa : Base
    {
        #region "Constructor"
        public Empresa(int AñoDeOperacion, ModuloGeneral.AmbienteDeBaseDeDatos ambienteDeBaseDeDatos)
                : base(ModuloGeneral.GestorDeBaseDeDatos.MySQL, ModuloGeneral.EsquemaDeBaseDeDatos.Operacion, AñoDeOperacion, false, ambienteDeBaseDeDatos)
        {
        }
        #endregion

        #region "Propiedades"

        private ModuloGeneral.TipoDeOperacion _TipoDeOperacion; public ModuloGeneral.TipoDeOperacion TipoDeOperacion { get => _TipoDeOperacion; set => _TipoDeOperacion = value; }

        //Campos de la tabla
        private int _CodigoEmpresa = 0; public int CodigoEmpresa { get => _CodigoEmpresa; set => _CodigoEmpresa = value; }
        private string _NitEmpresa = ""; public string NitEmpresa { get => _NitEmpresa; set => _NitEmpresa = value; }
        private string _NombreEmpresa = ""; public string NombreEmpresa { get => _NombreEmpresa; set => _NombreEmpresa = value; }
        private string _DireccionEmpresa = ""; public string DireccionEmpresa { get => _DireccionEmpresa; set => _DireccionEmpresa = value; }
        private int _CodigoPaisEmpresa = 0; public int CodigoPaisEmpresa { get => _CodigoPaisEmpresa; set => _CodigoPaisEmpresa = value; }
        private int _CodigoDepartamentoEmpresa = 0; public int CodigoDepartamentoEmpresa { get => _CodigoDepartamentoEmpresa; set => _CodigoDepartamentoEmpresa = value; }
        private int _CodigoMunicipioEmpresa = 0; public int CodigoMunicipioEmpresa { get => _CodigoMunicipioEmpresa; set => _CodigoMunicipioEmpresa = value; }
        private string _TelefonoEmpresa = ""; public string TelefonoEmpresa { get => _TelefonoEmpresa; set => _TelefonoEmpresa = value; }
        private string _EMailEmpresa = ""; public string EMailEmpresa { get => _EMailEmpresa; set => _EMailEmpresa = value; }
        private string _DireccionInternet = ""; public string DireccionInternet { get => _DireccionInternet; set => _DireccionInternet = value; }
        private int _NumeroEmpleados = 0; public int NumeroEmpleados { get => _NumeroEmpleados; set => _NumeroEmpleados = value; }
        private int _CodigoCorporacion = 0; public int CodigoCorporacion { get => _CodigoCorporacion; set => _CodigoCorporacion = value; }
        private DateTime _FechaRegistro = DateTime.MinValue; public DateTime FechaRegistro { get => _FechaRegistro; set => _FechaRegistro = value; }
        private string _NombreFacturacion = ""; public string NombreFacturacion { get => _NombreFacturacion; set => _NombreFacturacion = value; }
        private string _NitFacturacion = ""; public string NitFacturacion { get => _NitFacturacion; set => _NitFacturacion = value; }
        private int _TipoCliente = 3; public int TipoCliente { get => _TipoCliente; set => _TipoCliente = value; }
        private int _EstadoEmpresa = 0; public int EstadoEmpresa { get => _EstadoEmpresa; set => _EstadoEmpresa = value; }

        #endregion

        #region "Metodos"

        private bool Validar()
        {
            bool _Resultado = true;
            try
            {

                if (_TipoDeOperacion == ModuloGeneral.TipoDeOperacion.Agregar)
                {
                    string _Siguiente = "";
                    if (!CargarDatos(ref _Siguiente, "(COUNT(CODIGO_EMPRESA) + 1) AS SIGUIENTE", "CRM_EMPRESAS"))
                    {
                        goto salir;
                    }
                    _CodigoEmpresa = (int.TryParse(_Siguiente, out _CodigoEmpresa)) ? _CodigoEmpresa : 0;
                }
                if (_CodigoEmpresa == 0) { Mensaje = "Debe ingresar un valor en Codigo Empresa."; _Resultado = false; goto salir; }
                if (_NitEmpresa == "" || _NitEmpresa.Length > 45) { Mensaje = "Debe ingresar un valor en Nit Empresa. No debe exceder los 45 carácteres."; _Resultado = false; goto salir; }
                if (_NombreEmpresa == "" || _NombreEmpresa.Length > 250) { Mensaje = "Debe ingresar un valor en Nombre Empresa. No debe exceder los 250 carácteres."; _Resultado = false; goto salir; }
                if (_DireccionEmpresa == "" || _DireccionEmpresa.Length > 250) { Mensaje = "Debe ingresar un valor en Direccion Empresa. No debe exceder los 250 carácteres."; _Resultado = false; goto salir; }
                if (_CodigoPaisEmpresa == 0) { Mensaje = "Debe ingresar un valor en Codigo Pais Departamento."; _Resultado = false; goto salir; }
                if (_CodigoDepartamentoEmpresa == 0) { Mensaje = "Debe ingresar un valor en Codigo Departamento Empresa."; _Resultado = false; goto salir; }
                if (_CodigoMunicipioEmpresa == 0) { Mensaje = "Debe ingresar un valor en Codigo Municipio Empresa."; _Resultado = false; goto salir; }
                if (_TelefonoEmpresa.Length > 64) { Mensaje = "Debe ingresar un valor en Telefono Empresa. No debe exceder los 64 carácteres."; _Resultado = false; goto salir; }
                if (_EMailEmpresa.Length > 150) { Mensaje = "Debe ingresar un valor en E Mail Empresa. No debe exceder los 150 carácteres."; _Resultado = false; goto salir; }
                if (_DireccionInternet.Length > 150) { Mensaje = "Debe ingresar un valor en Direccion Internet. No debe exceder los 150 carácteres."; _Resultado = false; goto salir; }
                //if (_NumeroEmpleados == 0) { Mensaje = "Debe ingresar un valor en Numero Empleados."; _Resultado = false; goto salir; }
                //if (_CodigoCorporacion == 0) { Mensaje = "Debe ingresar un valor en Codigo Corporacion."; _Resultado = false; goto salir; }
                //if (_FechaRegistro == DateTime.MinValue) { Mensaje = "Debe ingresar un valor en Fecha Registro."; _Resultado = false; goto salir; }
                if (_NombreFacturacion == "" || _NombreFacturacion.Length > 250) { Mensaje = "Debe ingresar un valor en Nombre Facturacion. No debe exceder los 250 carácteres."; _Resultado = false; goto salir; }
                if (_NitFacturacion == "" || _NitFacturacion.Length > 45) { Mensaje = "Debe ingresar un valor en Nit Facturacion. No debe exceder los 45 carácteres."; _Resultado = false; goto salir; }
                if (_TipoCliente == 0) { Mensaje = "Debe ingresar un valor en Tipo Cliente."; _Resultado = false; goto salir; }
                if (_EstadoEmpresa == 0) { Mensaje = "Debe ingresar un valor en Estado Empresa."; _Resultado = false; goto salir; }

            }
            catch (Exception ex)
            {
                _Resultado = false;
                Mensaje = ex.Message;
            }
        salir:
            return _Resultado;
        }

        public bool OperarEmpresa()
        {
            bool _Resultado = false;
            try
            {
                switch (_TipoDeOperacion)
                {
                    case ModuloGeneral.TipoDeOperacion.Agregar:
                    case ModuloGeneral.TipoDeOperacion.Modificar:
                        if (Validar())
                        {
                            _Data.AsignarCampo("CODIGO_EMPRESA", _CodigoEmpresa, true);
                            _Data.AsignarCampo("NIT_EMPRESA", _NitEmpresa);
                            _Data.AsignarCampo("NOMBRE_EMPRESA", _NombreEmpresa);
                            _Data.AsignarCampo("DIRECCION_EMPRESA", _DireccionEmpresa);
                            _Data.AsignarCampo("CODIGO_PAIS_EMPRESA", _CodigoPaisEmpresa);
                            _Data.AsignarCampo("CODIGO_DEPARTAMENTO_EMPRESA", _CodigoDepartamentoEmpresa);
                            _Data.AsignarCampo("CODIGO_MUNICIPIO_EMPRESA", _CodigoMunicipioEmpresa);
                            _Data.AsignarCampo("TELEFONO_EMPRESA", _TelefonoEmpresa);
                            _Data.AsignarCampo("E_MAIL_EMPRESA", _EMailEmpresa);
                            _Data.AsignarCampo("DIRECCION_INTERNET", _DireccionInternet);
                            _Data.AsignarCampo("NUMERO_EMPLEADOS", _NumeroEmpleados);
                            _Data.AsignarCampo("CODIGO_CORPORACION", _CodigoCorporacion);
                            _Data.AsignarCampo("FECHA_REGISTRO", "now()", false, false, ModuloGeneral.TipoDeOperadorLogico.AndOperador, System.Data.ParameterDirection.Input, true);
                            _Data.AsignarCampo("NOMBRE_FACTURACION", _NombreFacturacion);
                            _Data.AsignarCampo("NIT_FACTURACION", _NitFacturacion);
                            _Data.AsignarCampo("TIPO_CLIENTE", _TipoCliente);
                            _Data.AsignarCampo("ESTADO_EMPRESA", _EstadoEmpresa);
                            _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "CRM_EMPRESAS");

                        }
                        break;
                    case ModuloGeneral.TipoDeOperacion.Eliminar:
                        if (_CodigoEmpresa == 0) { Mensaje = "Debe ingresar un valor en Codigo Empresa."; _Resultado = false; goto salir; }
                        _Data.AsignarCampo("CODIGO_EMPRESA", _CodigoEmpresa, true);
                        _Data.AsignarCampo("FECHA_REGISTRO", "now()", false, false, ModuloGeneral.TipoDeOperadorLogico.AndOperador, System.Data.ParameterDirection.Input, true);
                        _Data.AsignarCampo("ESTADO_EMPRESA", 0);
                        _Resultado = _Data.EjecutarOperacion(ModuloGeneral.TipoDeOperacion.Modificar, "CRM_EMPRESAS");
                        break;
                }
            }
            catch (Exception ex)
            {
                _Resultado = false;
                Mensaje = ex.Message;
            }
        salir:
            return _Resultado;
        }

        public bool OperarRelacionCorporacion()
        {
            bool _Resultado = false;
            try
            {
                if (_CodigoEmpresa == 0) { Mensaje = "Debe ingresar un valor en Codigo Empresa."; _Resultado = false; goto salir; }
                switch (_TipoDeOperacion)
                {
                    case ModuloGeneral.TipoDeOperacion.Agregar:
                    case ModuloGeneral.TipoDeOperacion.Modificar:
                        if (_CodigoCorporacion == 0) { Mensaje = "Debe ingresar un valor en Codigo Corporacion."; _Resultado = false; goto salir; }
                        _Data.AsignarCampo("CODIGO_EMPRESA", _CodigoEmpresa, true);
                        _Data.AsignarCampo("CODIGO_CORPORACION", _CodigoCorporacion);
                        _Data.AsignarCampo("FECHA_REGISTRO", "now()", false, false, ModuloGeneral.TipoDeOperadorLogico.AndOperador, System.Data.ParameterDirection.Input, true);

                        _Resultado = _Data.EjecutarOperacion(ModuloGeneral.TipoDeOperacion.Modificar, "CRM_EMPRESAS");

                        break;
                    case ModuloGeneral.TipoDeOperacion.Eliminar:
                        _Data.AsignarCampo("CODIGO_EMPRESA", _CodigoEmpresa, true);
                        _Data.AsignarCampo("CODIGO_CORPORACION", 0);
                        _Data.AsignarCampo("FECHA_REGISTRO", "now()", false, false, ModuloGeneral.TipoDeOperadorLogico.AndOperador, System.Data.ParameterDirection.Input, true);
                        _Resultado = _Data.EjecutarOperacion(ModuloGeneral.TipoDeOperacion.Modificar, "CRM_EMPRESAS");
                        break;
                }
            }
            catch (Exception ex)
            {
                _Resultado = false;
                Mensaje = ex.Message;
            }
        salir:
            return _Resultado;
        }
        #endregion
    }
}

