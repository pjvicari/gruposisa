using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Negocio
{
    public class Corporacion : Base
    {
        #region "Constructor"
        public Corporacion(int AñoDeOperacion, ModuloGeneral.AmbienteDeBaseDeDatos ambienteDeBaseDeDatos)
                : base(ModuloGeneral.GestorDeBaseDeDatos.MySQL, ModuloGeneral.EsquemaDeBaseDeDatos.Operacion, AñoDeOperacion, false, ambienteDeBaseDeDatos)
        {
        }
        #endregion

        #region "Propiedades"

        private ModuloGeneral.TipoDeOperacion _TipoDeOperacion; public ModuloGeneral.TipoDeOperacion TipoDeOperacion { get => _TipoDeOperacion; set => _TipoDeOperacion = value; }

        private int _CodigoCorporacion = 0; public int CodigoCorporacion { get => _CodigoCorporacion; set => _CodigoCorporacion = value; }
        private string _NombreCorporacion = ""; public string NombreCorporacion { get => _NombreCorporacion; set => _NombreCorporacion = value; }
        private string _DireccionCorporacion = ""; public string DireccionCorporacion { get => _DireccionCorporacion; set => _DireccionCorporacion = value; }
        private int _CodigoPaisCorporacion = 0; public int CodigoPaisCorporacion { get => _CodigoPaisCorporacion; set => _CodigoPaisCorporacion = value; }
        private int _CodigoDepartamentoCorporacion = 0; public int CodigoDepartamentoCorporacion { get => _CodigoDepartamentoCorporacion; set => _CodigoDepartamentoCorporacion = value; }
        private int _CodigoMunicipioCorporacion = 0; public int CodigoMunicipioCorporacion { get => _CodigoMunicipioCorporacion; set => _CodigoMunicipioCorporacion = value; }
        private string _CategoriaCorporacion = ""; public string CategoriaCorporacion { get => _CategoriaCorporacion; set => _CategoriaCorporacion = value; }
        private DateTime _FechaRegistro = DateTime.MinValue; public DateTime FechaRegistro { get => _FechaRegistro; set => _FechaRegistro = value; }
        private DateTime _FechaBaja = DateTime.MinValue; public DateTime FechaBaja { get => _FechaBaja; set => _FechaBaja = value; }
        private string _TelefonoCorporacion = ""; public string TelefonoCorporacion { get => _TelefonoCorporacion; set => _TelefonoCorporacion = value; }
        private string _EMailCorporacion = ""; public string EMailCorporacion { get => _EMailCorporacion; set => _EMailCorporacion = value; }
        private int _TipoCliente = 4; public int TipoCliente { get => _TipoCliente; set => _TipoCliente = value; }
        private int _EstadoCorporacion = 1; public int EstadoCorporacion { get => _EstadoCorporacion; set => _EstadoCorporacion = value; }


        //Campos de la tabla
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
                    if (!CargarDatos(ref _Siguiente, "(COUNT(CODIGO_CORPORACION) + 1) AS SIGUIENTE", "CRM_CORPORACIONES"))
                    {
                        goto salir;
                    }
                    _CodigoCorporacion = (int.TryParse(_Siguiente, out _CodigoCorporacion)) ? _CodigoCorporacion : 0;
                }
                if (_CodigoCorporacion == 0) { Mensaje = "Debe ingresar un valor en Codigo Corporacion."; _Resultado = false; goto salir; }
                if (_NombreCorporacion == "" || _NombreCorporacion.Length > 250) { Mensaje = "Debe ingresar un valor en Nombre Corporacion. No debe exceder los 250 carácteres."; _Resultado = false; goto salir; }
                if (_DireccionCorporacion == "" || _DireccionCorporacion.Length > 250) { Mensaje = "Debe ingresar un valor en Direccion Corporacion. No debe exceder los 250 carácteres."; _Resultado = false; goto salir; }
                if (_CodigoPaisCorporacion == 0) { Mensaje = "Debe ingresar un valor en Id Pais Corporacion."; _Resultado = false; goto salir; }
                if (_CodigoDepartamentoCorporacion == 0) { Mensaje = "Debe ingresar un valor en Id Departamento Corporacion."; _Resultado = false; goto salir; }
                if (_CodigoMunicipioCorporacion == 0) { Mensaje = "Debe ingresar un valor en Id Municipio Corporacion."; _Resultado = false; goto salir; }
                //if (_CategoriaCorporacion == "" || _CategoriaCorporacion.Length > 20) { Mensaje = "Debe ingresar un valor en Categoria Corporacion. No debe exceder los 20 carácteres."; _Resultado = false; goto salir; }
                //if (_FechaRegistro == DateTime.MinValue) { Mensaje = "Debe ingresar un valor en Fecha Registro."; _Resultado = false; goto salir; }
                //if (_FechaBaja == DateTime.MinValue) { Mensaje = "Debe ingresar un valor en Fecha Baja."; _Resultado = false; goto salir; }
                if (_TelefonoCorporacion.Length > 64) { Mensaje = "Debe ingresar un valor en Telefono Corporacion. No debe exceder los 64 carácteres."; _Resultado = false; goto salir; }
                if (_EMailCorporacion.Length > 150) { Mensaje = "Debe ingresar un valor en E Mail Corporacion. No debe exceder los 150 carácteres."; _Resultado = false; goto salir; }
                if (_TipoCliente == 0) { Mensaje = "Debe ingresar un valor en Tipo Cliente."; _Resultado = false; goto salir; }
                if (_EstadoCorporacion == 0) { Mensaje = "Debe ingresar un valor en Estado Corporacion."; _Resultado = false; goto salir; }

            }
            catch (Exception ex)
            {
                _Resultado = false;
                Mensaje = ex.Message;
            }
        salir:
            return _Resultado;
        }

        public bool OperarCorporacion()
        {
            bool _Resultado = false;
            try
            {
                switch(_TipoDeOperacion)
                {
                    case ModuloGeneral.TipoDeOperacion.Agregar:
                    case ModuloGeneral.TipoDeOperacion.Modificar:
                        if(Validar())
                        {
                            _Data.AsignarCampo("CODIGO_CORPORACION", _CodigoCorporacion, true);
                            _Data.AsignarCampo("NOMBRE_CORPORACION", _NombreCorporacion);
                            _Data.AsignarCampo("DIRECCION_CORPORACION", _DireccionCorporacion);
                            _Data.AsignarCampo("CODIGO_PAIS_CORPORACION", _CodigoPaisCorporacion);
                            _Data.AsignarCampo("CODIGO_DEPARTAMENTO_CORPORACION", _CodigoDepartamentoCorporacion);
                            _Data.AsignarCampo("CODIGO_MUNICIPIO_CORPORACION", _CodigoMunicipioCorporacion);
                            _Data.AsignarCampo("CATEGORIA_CORPORACION", _CategoriaCorporacion);
                            _Data.AsignarCampo("FECHA_REGISTRO", "now()", false, false, ModuloGeneral.TipoDeOperadorLogico.AndOperador, System.Data.ParameterDirection.Input, true);
                            _Data.AsignarCampo("TELEFONO_CORPORACION", _TelefonoCorporacion);
                            _Data.AsignarCampo("E_MAIL_CORPORACION", _EMailCorporacion);
                            _Data.AsignarCampo("TIPO_CLIENTE", _TipoCliente);
                            _Data.AsignarCampo("ESTADO_CORPORACION", _EstadoCorporacion);
                            _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "CRM_CORPORACIONES");

                        }
                        break;
                    case ModuloGeneral.TipoDeOperacion.Eliminar:
                        if (_CodigoCorporacion == 0) { Mensaje = "Debe ingresar un valor en Codigo Corporacion."; _Resultado = false; goto salir; }
                        _Data.AsignarCampo("CODIGO_CORPORACION", _CodigoCorporacion, true);
                        _Data.AsignarCampo("FECHA_BAJA", "now()", false, false, ModuloGeneral.TipoDeOperadorLogico.AndOperador, System.Data.ParameterDirection.Input, true);
                        _Data.AsignarCampo("ESTADO_CORPORACION", _EstadoCorporacion);
                        _Resultado = _Data.EjecutarOperacion(ModuloGeneral.TipoDeOperacion.Modificar, "CRM_CORPORACIONES");
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
