using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Negocio
{
    public class Contacto : Base
    {
        #region "Constructor"
        public Contacto(int AñoDeOperacion, ModuloGeneral.AmbienteDeBaseDeDatos ambienteDeBaseDeDatos)
                : base(ModuloGeneral.GestorDeBaseDeDatos.MySQL, ModuloGeneral.EsquemaDeBaseDeDatos.Operacion, AñoDeOperacion, false, ambienteDeBaseDeDatos)
        {
        }
        #endregion

        #region "Propiedades"

        private ModuloGeneral.TipoDeOperacion _TipoDeOperacion; public ModuloGeneral.TipoDeOperacion TipoDeOperacion { get => _TipoDeOperacion; set => _TipoDeOperacion = value; }

        //Campos de la tabla
        private int _CodigoContacto = 0; public int CodigoContacto { get => _CodigoContacto; set => _CodigoContacto = value; }
        private string _NitFacturacion = ""; public string NitFacturacion { get => _NitFacturacion; set => _NitFacturacion = value; }
        private string _IdentificacionContacto = ""; public string IdentificacionContacto { get => _IdentificacionContacto; set => _IdentificacionContacto = value; }
        private int _CodigoTratamiento = 0; public int CodigoTratamiento { get => _CodigoTratamiento; set => _CodigoTratamiento = value; }
        private string _NombreContacto = ""; public string NombreContacto { get => _NombreContacto; set => _NombreContacto = value; }
        private string _CargoContacto = ""; public string CargoContacto { get => _CargoContacto; set => _CargoContacto = value; }
        private string _EMailContacto = ""; public string EMailContacto { get => _EMailContacto; set => _EMailContacto = value; }
        private string _TelefonosContacto = ""; public string TelefonosContacto { get => _TelefonosContacto; set => _TelefonosContacto = value; }
        private string _DireccionContacto = ""; public string DireccionContacto { get => _DireccionContacto; set => _DireccionContacto = value; }
        private int _CodigoPaisContacto = 0; public int CodigoPaisContacto { get => _CodigoPaisContacto; set => _CodigoPaisContacto = value; }
        private int _CodigoDepartamentoContacto = 0; public int CodigoDepartamentoContacto { get => _CodigoDepartamentoContacto; set => _CodigoDepartamentoContacto = value; }
        private int _CodigoMunicipioContacto = 0; public int CodigoMunicipioContacto { get => _CodigoMunicipioContacto; set => _CodigoMunicipioContacto = value; }
        private string _NombreFacturacion = ""; public string NombreFacturacion { get => _NombreFacturacion; set => _NombreFacturacion = value; }
        private DateTime _FechaRegistro = DateTime.MinValue; public DateTime FechaRegistro { get => _FechaRegistro; set => _FechaRegistro = value; }
        private int _TipoCliente = 1; public int TipoCliente { get => _TipoCliente; set => _TipoCliente = value; }
        private int _EstadoCliente = 1; public int EstadoCliente { get => _EstadoCliente; set => _EstadoCliente = value; }
        //Propiedades de relacion con empresa, sucursal o corporacion
        private int _CodigoCliContacto = 0; public int CodigoCliContacto { get => _CodigoCliContacto; set => _CodigoCliContacto = value; }
        private int _TipoClienteContacto = 0; public int TipoClienteContacto { get => _TipoClienteContacto; set => _TipoClienteContacto = value; }
        private int _CodigoCliente = 0; public int CodigoCliente { get => _CodigoCliente; set => _CodigoCliente = value; }

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
                    if (!CargarDatos(ref _Siguiente, "(COUNT(CODIGO_CONTACTO) + 1) AS SIGUIENTE", "CRM_CONTACTOS"))
                    {
                        goto salir;
                    }
                    _CodigoContacto = (int.TryParse(_Siguiente, out _CodigoContacto)) ? _CodigoContacto : 0;
                }
                if (_CodigoContacto == 0) { Mensaje = "Debe ingresar un valor en Codigo Contacto."; _Resultado = false; goto salir; }
                if (_NitFacturacion == "" || _NitFacturacion.Length > 45) { Mensaje = "Debe ingresar un valor en Nit Facturacion. No debe exceder los 45 carácteres."; _Resultado = false; goto salir; }
                if (_IdentificacionContacto.Length > 80) { Mensaje = "Debe ingresar un valor en Identificacion Contacto. No debe exceder los 80 carácteres."; _Resultado = false; goto salir; }
                if (_CodigoTratamiento == 0) { Mensaje = "Debe ingresar un valor en Tratamiento."; _Resultado = false; goto salir; }
                if (_NombreContacto == "" || _NombreContacto.Length > 250) { Mensaje = "Debe ingresar un valor en Nombre Contacto. No debe exceder los 250 carácteres."; _Resultado = false; goto salir; }
                if (_CargoContacto.Length > 250) { Mensaje = "Debe ingresar un valor en Cargo Contacto. No debe exceder los 250 carácteres."; _Resultado = false; goto salir; }
                if (_EMailContacto.Length > 150) { Mensaje = "Debe ingresar un valor en E Mail Contacto. No debe exceder los 150 carácteres."; _Resultado = false; goto salir; }
                if (_TelefonosContacto.Length > 64) { Mensaje = "Debe ingresar un valor en Telefonos Contacto. No debe exceder los 64 carácteres."; _Resultado = false; goto salir; }
                if (_DireccionContacto.Length > 250) { Mensaje = "Debe ingresar un valor en Direccion Contacto. No debe exceder los 250 carácteres."; _Resultado = false; goto salir; }
                if (_CodigoPaisContacto == 0) { Mensaje = "Debe ingresar un valor en Codigo Pais Contacto."; _Resultado = false; goto salir; }
                if (_CodigoDepartamentoContacto == 0) { Mensaje = "Debe ingresar un valor en Codigo Departamento Contacto."; _Resultado = false; goto salir; }
                if (_CodigoMunicipioContacto == 0) { Mensaje = "Debe ingresar un valor en Codigo Municipio Contacto."; _Resultado = false; goto salir; }
                if (_NombreFacturacion == "" || _NombreFacturacion.Length > 250) { Mensaje = "Debe ingresar un valor en Nombre Facturacion. No debe exceder los 250 carácteres."; _Resultado = false; goto salir; }
                //if (_FechaRegistro == DateTime.MinValue) { Mensaje = "Debe ingresar un valor en Fecha Registro."; _Resultado = false; goto salir; }
                if (_TipoCliente == 0) { Mensaje = "Debe ingresar un valor en Tipo Cliente."; _Resultado = false; goto salir; }
                if (_EstadoCliente == 0) { Mensaje = "Debe ingresar un valor en Estado Cliente."; _Resultado = false; goto salir; }

                if (_TipoClienteContacto != 0)
                {
                    if (_TipoDeOperacion == ModuloGeneral.TipoDeOperacion.Agregar)
                    {
                        string _Siguiente = "";
                        if (!CargarDatos(ref _Siguiente, "(COUNT(CODIGO_CLI_CONTACTO) + 1) AS SIGUIENTE", "gruposisa.CRM_CLIENTES_CONTACTO"))
                        {
                            goto salir;
                        }
                        _CodigoCliContacto = (int.TryParse(_Siguiente, out _CodigoCliContacto)) ? _CodigoCliContacto : 0;
                    }
                    if (_CodigoCliContacto == 0) { Mensaje = "Debe ingresar un valor en Codigo Cli Contacto."; _Resultado = false; goto salir; }
                    if (_CodigoCliente == 0) { Mensaje = "Debe ingresar un valor en Codigo Cliente."; _Resultado = false; goto salir; }
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

        public bool OperarContacto()
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
                            _Data.AsignarCampo("CODIGO_CONTACTO", _CodigoContacto, true);
                            _Data.AsignarCampo("NIT_FACTURACION", _NitFacturacion);
                            _Data.AsignarCampo("IDENTIFICACION_CONTACTO", _IdentificacionContacto);
                            _Data.AsignarCampo("CODIGO_TRATAMIENTO", _CodigoTratamiento);
                            _Data.AsignarCampo("NOMBRE_CONTACTO", _NombreContacto);
                            _Data.AsignarCampo("CARGO_CONTACTO", _CargoContacto);
                            _Data.AsignarCampo("E_MAIL_CONTACTO", _EMailContacto);
                            _Data.AsignarCampo("TELEFONOS_CONTACTO", _TelefonosContacto);
                            _Data.AsignarCampo("DIRECCION_CONTACTO", _DireccionContacto);
                            _Data.AsignarCampo("CODIGO_PAIS_CONTACTO", _CodigoPaisContacto);
                            _Data.AsignarCampo("CODIGO_DEPARTAMENTO_CONTACTO", _CodigoDepartamentoContacto);
                            _Data.AsignarCampo("CODIGO_MUNICIPIO_CONTACTO", _CodigoMunicipioContacto);
                            _Data.AsignarCampo("NOMBRE_FACTURACION", _NombreFacturacion);
                            _Data.AsignarCampo("FECHA_REGISTRO", "now()");
                            _Data.AsignarCampo("TIPO_CLIENTE", _TipoCliente);
                            _Data.AsignarCampo("ESTADO_CLIENTE", _EstadoCliente);
                            _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "CRM_CONTACTOS");

                            if (_TipoClienteContacto != 0)
                            {
                                OperarClienteContacto();
                            }
                        }
                        break;
                    case ModuloGeneral.TipoDeOperacion.Eliminar:
                        if (_CodigoContacto == 0) { Mensaje = "Debe ingresar un valor en Codigo Contacto."; _Resultado = false; goto salir; }
                        _Data.AsignarCampo("CODIGO_CONTACTO", _CodigoContacto, true);
                        _Data.AsignarCampo("FECHA_REGISTRO", "now()");
                        _Data.AsignarCampo("ESTADO_CLIENTE", _EstadoCliente);
                        _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "CRM_CONTACTOS");
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

        private bool ValidarClienteContacto()
        {
            bool _Resultado = true;
            try
            {
                if (_TipoDeOperacion == ModuloGeneral.TipoDeOperacion.Agregar)
                {
                    string _Siguiente = "";
                    if (!CargarDatos(ref _Siguiente, "(COUNT(CODIGO_CLI_CONTACTO) + 1) AS SIGUIENTE", "CRM_CLIENTES_CONTACTO"))
                    {
                        goto salir;
                    }
                    _CodigoCliContacto = (int.TryParse(_Siguiente, out _CodigoCliContacto)) ? _CodigoCliContacto : 0;
                }
                if (_CodigoCliContacto == 0) { Mensaje = "Debe ingresar un valor en Codigo Cli Contacto."; _Resultado = false; goto salir; }
                if (_TipoClienteContacto == 0) { Mensaje = "Debe ingresar un valor en Tipo Cliente."; _Resultado = false; goto salir; }
                if (_CodigoContacto == 0) { Mensaje = "Debe ingresar un valor en Codigo Contacto."; _Resultado = false; goto salir; }
                if (_CodigoCliente == 0) { Mensaje = "Debe ingresar un valor en Codigo Cliente."; _Resultado = false; goto salir; }
            }
            catch (Exception ex)
            {
                _Resultado = false;
                Mensaje = ex.Message;
            }
        salir:
            return _Resultado;
        }

        public bool OperarClienteContacto()
        {
            bool _Resultado = false;
            try
            {
                switch (_TipoDeOperacion)
                {
                    case ModuloGeneral.TipoDeOperacion.Agregar:
                    case ModuloGeneral.TipoDeOperacion.Modificar:
                        if (ValidarClienteContacto())
                        {
                            _Data.AsignarCampo("CODIGO_CLI_CONTACTO", _CodigoCliContacto, true);
                            _Data.AsignarCampo("TIPO_CLIENTE", _TipoCliente);
                            _Data.AsignarCampo("CODIGO_CONTACTO", _CodigoContacto);
                            _Data.AsignarCampo("CODIGO_CLIENTE", _CodigoCliente);
                            _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "CRM_CLIENTES_CONTACTO");

                        }
                        break;
                    case ModuloGeneral.TipoDeOperacion.Eliminar:
                        if (_CodigoContacto == 0) { Mensaje = "Debe ingresar un valor en Codigo Contacto."; _Resultado = false; goto salir; }
                        _Data.AsignarCampo("CODIGO_CONTACTO", _CodigoContacto, true);
                        _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "CRM_CLIENTES_CONTACTO");
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
