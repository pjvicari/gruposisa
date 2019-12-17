using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Negocio
{
    public class Sucursal : Base
    {
        #region "Constructor"
        public Sucursal(int AñoDeOperacion, ModuloGeneral.AmbienteDeBaseDeDatos ambienteDeBaseDeDatos)
                : base(ModuloGeneral.GestorDeBaseDeDatos.MySQL, ModuloGeneral.EsquemaDeBaseDeDatos.Operacion, AñoDeOperacion, false, ambienteDeBaseDeDatos)
        {
        }
        #endregion

        #region "Propiedades"

        private ModuloGeneral.TipoDeOperacion _TipoDeOperacion; public ModuloGeneral.TipoDeOperacion TipoDeOperacion { get => _TipoDeOperacion; set => _TipoDeOperacion = value; }

        //Campos de la tabla
        private int _CodigoSucursal = 0; public int CodigoSucursal { get => _CodigoSucursal; set => _CodigoSucursal = value; }
        private int _NumeroSucursal = 0; public int NumeroSucursal { get => _NumeroSucursal; set => _NumeroSucursal = value; }
        private string _NombreSucursal = ""; public string NombreSucursal { get => _NombreSucursal; set => _NombreSucursal = value; }
        private int _CodigoEmpresa = 0; public int CodigoEmpresa { get => _CodigoEmpresa; set => _CodigoEmpresa = value; }
        private string _DireccionSucursal = ""; public string DireccionSucursal { get => _DireccionSucursal; set => _DireccionSucursal = value; }
        private string _TelefonosSucursal = ""; public string TelefonosSucursal { get => _TelefonosSucursal; set => _TelefonosSucursal = value; }
        private string _EmailSucursal = ""; public string EmailSucursal { get => _EmailSucursal; set => _EmailSucursal = value; }
        private int _CodigoPaisSucursal = 0; public int CodigoPaisSucursal { get => _CodigoPaisSucursal; set => _CodigoPaisSucursal = value; }
        private int _CodigoDepartamentoSucursal = 0; public int CodigoDepartamentoSucursal { get => _CodigoDepartamentoSucursal; set => _CodigoDepartamentoSucursal = value; }
        private int _CodigoMunicipioSucursal = 0; public int CodigoMunicipioSucursal { get => _CodigoMunicipioSucursal; set => _CodigoMunicipioSucursal = value; }
        private int _NumEmpleadosSucursal = 0; public int NumEmpleadosSucursal { get => _NumEmpleadosSucursal; set => _NumEmpleadosSucursal = value; }
        private DateTime _FechaRegistro = DateTime.MinValue; public DateTime FechaRegistro { get => _FechaRegistro; set => _FechaRegistro = value; }
        private string _NitFacturacion = ""; public string NitFacturacion { get => _NitFacturacion; set => _NitFacturacion = value; }
        private string _NombreFacturacion = ""; public string NombreFacturacion { get => _NombreFacturacion; set => _NombreFacturacion = value; }
        private int _TipoCliente = 2; public int TipoCliente { get => _TipoCliente; set => _TipoCliente = value; }
        private int _EstadoSucursal = 1; public int EstadoSucursal { get => _EstadoSucursal; set => _EstadoSucursal = value; }

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
                    if (!CargarDatos(ref _Siguiente, "(COUNT(CODIGO_SUCURSAL) + 1) AS SIGUIENTE", "CRM_SUCURSALES"))
                    {
                        goto salir;
                    }
                    _CodigoSucursal = (int.TryParse(_Siguiente, out _CodigoSucursal)) ? _CodigoSucursal : 0;
                }
                if (_CodigoSucursal == 0) { Mensaje = "Debe ingresar un valor en Codigo Sucursal."; _Resultado = false; goto salir; }
                if (_NumeroSucursal == 0) { Mensaje = "Debe ingresar un valor en Numero Sucursal."; _Resultado = false; goto salir; }
                if (_NombreSucursal == "" || _NombreSucursal.Length > 250) { Mensaje = "Debe ingresar un valor en Nombre Sucursal. No debe exceder los 250 carácteres."; _Resultado = false; goto salir; }
                if (_CodigoEmpresa == 0) { Mensaje = "Debe ingresar un valor en Codigo Empresa."; _Resultado = false; goto salir; }
                if (_DireccionSucursal == "" || _DireccionSucursal.Length > 250) { Mensaje = "Debe ingresar un valor en Direccion Sucursal. No debe exceder los 250 carácteres."; _Resultado = false; goto salir; }
                if (_TelefonosSucursal.Length > 64) { Mensaje = "Debe ingresar un valor en Telefonos Sucursal. No debe exceder los 64 carácteres."; _Resultado = false; goto salir; }
                if (_EmailSucursal.Length > 150) { Mensaje = "Debe ingresar un valor en Email Sucursal. No debe exceder los 150 carácteres."; _Resultado = false; goto salir; }
                if (_CodigoPaisSucursal == 0) { Mensaje = "Debe ingresar un valor en Codigo Pais Sucursal."; _Resultado = false; goto salir; }
                if (_CodigoDepartamentoSucursal == 0) { Mensaje = "Debe ingresar un valor en Codigo Departamento Sucursal."; _Resultado = false; goto salir; }
                if (_CodigoMunicipioSucursal == 0) { Mensaje = "Debe ingresar un valor en Codigo Municipio Sucursal."; _Resultado = false; goto salir; }
                //if (_NumEmpleadosSucursal == 0) { Mensaje = "Debe ingresar un valor en Num Empleados Sucursal."; _Resultado = false; goto salir; }
                //if (_FechaRegistro == DateTime.MinValue) { Mensaje = "Debe ingresar un valor en Fecha Registro."; _Resultado = false; goto salir; }
                if (_NitFacturacion == "" || _NitFacturacion.Length > 45) { Mensaje = "Debe ingresar un valor en Nit Facturacion. No debe exceder los 45 carácteres."; _Resultado = false; goto salir; }
                if (_NombreFacturacion == "" || _NombreFacturacion.Length > 250) { Mensaje = "Debe ingresar un valor en Nombre Facturacion. No debe exceder los 250 carácteres."; _Resultado = false; goto salir; }
                if (_TipoCliente == 0) { Mensaje = "Debe ingresar un valor en Tipo Cliente."; _Resultado = false; goto salir; }
                if (_EstadoSucursal == 0) { Mensaje = "Debe ingresar un valor en Estado Sucursal."; _Resultado = false; goto salir; }

            }
            catch (Exception ex)
            {
                _Resultado = false;
                Mensaje = ex.Message;
            }
        salir:
            return _Resultado;
        }

        public bool OperarSucursal()
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
                            _Data.AsignarCampo("CODIGO_SUCURSAL", _CodigoSucursal, true);
                            _Data.AsignarCampo("NUMERO_SUCURSAL", _NumeroSucursal);
                            _Data.AsignarCampo("NOMBRE_SUCURSAL", _NombreSucursal);
                            _Data.AsignarCampo("CODIGO_EMPRESA", _CodigoEmpresa);
                            _Data.AsignarCampo("DIRECCION_SUCURSAL", _DireccionSucursal);
                            _Data.AsignarCampo("TELEFONOS_SUCURSAL", _TelefonosSucursal);
                            _Data.AsignarCampo("E_MAIL_SUCURSAL", _EmailSucursal);
                            _Data.AsignarCampo("CODIGO_PAIS_SUCURSAL", _CodigoPaisSucursal);
                            _Data.AsignarCampo("CODIGO_DEPARTAMENTO_SUCURSAL", _CodigoDepartamentoSucursal);
                            _Data.AsignarCampo("CODIGO_MUNICIPIO_SUCURSAL", _CodigoMunicipioSucursal);
                            _Data.AsignarCampo("NUM_EMPLEADOS_SUCURSAL", _NumEmpleadosSucursal);
                            _Data.AsignarCampo("FECHA_REGISTRO", "now()", false, false, ModuloGeneral.TipoDeOperadorLogico.AndOperador, System.Data.ParameterDirection.Input, true);
                            _Data.AsignarCampo("NIT_FACTURACION", _NitFacturacion);
                            _Data.AsignarCampo("NOMBRE_FACTURACION", _NombreFacturacion);
                            _Data.AsignarCampo("TIPO_CLIENTE", _TipoCliente);
                            _Data.AsignarCampo("ESTADO_SUCURSAL", _EstadoSucursal);
                            _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "CRM_SUCURSALES");

                        }
                        break;
                    case ModuloGeneral.TipoDeOperacion.Eliminar:
                        if (_CodigoSucursal == 0) { Mensaje = "Debe ingresar un valor en Codigo Sucursal."; _Resultado = false; goto salir; }
                        _Data.AsignarCampo("CODIGO_SUCURSAL", _CodigoSucursal, true);
                        _Data.AsignarCampo("FECHA_REGISTRO", "now()", false, false, ModuloGeneral.TipoDeOperadorLogico.AndOperador, System.Data.ParameterDirection.Input, true);
                        _Data.AsignarCampo("ESTADO_SUCURSAL", 0);
                        _Resultado = _Data.EjecutarOperacion(ModuloGeneral.TipoDeOperacion.Modificar, "CRM_SUCURSALES");

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
