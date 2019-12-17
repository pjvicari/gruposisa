using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Negocio
{
    public class Municipio : Base
    {
        #region "Constructor"
        public Municipio(int AñoDeOperacion, ModuloGeneral.AmbienteDeBaseDeDatos ambienteDeBaseDeDatos)
                : base(ModuloGeneral.GestorDeBaseDeDatos.MySQL, ModuloGeneral.EsquemaDeBaseDeDatos.Operacion, AñoDeOperacion, false, ambienteDeBaseDeDatos)
        {
        }
        #endregion

        #region "Propiedades"

        private ModuloGeneral.TipoDeOperacion _TipoDeOperacion; public ModuloGeneral.TipoDeOperacion TipoDeOperacion { get => _TipoDeOperacion; set => _TipoDeOperacion = value; }

        //Campos de la tabla
        private int _CodigoMunicipio = 0; public int CodigoMunicipio { get => _CodigoMunicipio; set => _CodigoMunicipio = value; }
        private int _CodigoDepartamento = 0; public int CodigoDepartamento { get => _CodigoDepartamento; set => _CodigoDepartamento = value; }
        private int _CodigoPais = 0; public int CodigoPais { get => _CodigoPais; set => _CodigoPais = value; }
        private string _NombreMunicipio = ""; public string NombreMunicipio { get => _NombreMunicipio; set => _NombreMunicipio = value; }
        private int _EstadoMunicipio = 0; public int EstadoMunicipio { get => _EstadoMunicipio; set => _EstadoMunicipio = value; }

        #endregion

        #region "Metodos"

        private bool Validar()
        {
            bool _Resultado = true;
            try
            {

                if (_CodigoDepartamento == 0) { Mensaje = "Debe ingresar un valor en Codigo Departamento."; _Resultado = false; goto salir; }
                if (_CodigoPais == 0) { Mensaje = "Debe ingresar un valor en Codigo Pais."; _Resultado = false; goto salir; }
                if (_TipoDeOperacion == ModuloGeneral.TipoDeOperacion.Agregar)
                {
                    string _Siguiente = "";
                    AsignarParametroWhere("CODIGO_PAIS", _CodigoPais, ModuloGeneral.TipoDeOperadorLogico.AndOperador, ModuloGeneral.TipoDeOperadorDeComparacion.Igual, true);
                    AsignarParametroWhere("CODIGO_DEPARTAMENTO", _CodigoDepartamento, ModuloGeneral.TipoDeOperadorLogico.AndOperador, ModuloGeneral.TipoDeOperadorDeComparacion.Igual, true);
                    if (!CargarDatos(ref _Siguiente, "(COUNT(CODIGO_MUNICIPIO) + 1) AS SIGUIENTE", "MUNICIPIOS"))
                    {
                        goto salir;
                    }
                    _CodigoMunicipio = (int.TryParse(_Siguiente, out _CodigoMunicipio)) ? _CodigoMunicipio : 0;
                }
                if (_CodigoMunicipio == 0) { Mensaje = "Debe ingresar un valor en Codigo Municipio."; _Resultado = false; goto salir; }
                if (_NombreMunicipio == "" || _NombreMunicipio.Length > 150) { Mensaje = "Debe ingresar un valor en Nombre Municipio. No debe exceder los 150 carácteres."; _Resultado = false; goto salir; }
                if (_EstadoMunicipio == 0) { Mensaje = "Debe ingresar un valor en Estado Municipio."; _Resultado = false; goto salir; }

            }
            catch (Exception ex)
            {
                _Resultado = false;
                Mensaje = ex.Message;
            }
        salir:
            return _Resultado;
        }

        public bool OperarMunicipio()
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
                            _Data.AsignarCampo("CODIGO_MUNICIPIO", _CodigoMunicipio, true);
                            _Data.AsignarCampo("CODIGO_DEPARTAMENTO", _CodigoDepartamento, true);
                            _Data.AsignarCampo("CODIGO_PAIS", _CodigoPais, true);
                            _Data.AsignarCampo("NOMBRE_MUNICIPIO", _NombreMunicipio);
                            _Data.AsignarCampo("ESTADO_MUNICIPIO", _EstadoMunicipio);
                            _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "MUNICIPIOS");

                        }
                        break;
                    case ModuloGeneral.TipoDeOperacion.Eliminar:
                        if (_CodigoDepartamento == 0) { Mensaje = "Debe ingresar un valor en Codigo Departamento."; _Resultado = false; goto salir; }
                        if (_CodigoMunicipio == 0) { Mensaje = "Debe ingresar un valor en Codigo Municipio."; _Resultado = false; goto salir; }
                        if (_CodigoPais == 0) { Mensaje = "Debe ingresar un valor en Codigo Pais."; _Resultado = false; goto salir; }
                        _Data.AsignarCampo("CODIGO_MUNICIPIO", _CodigoMunicipio, true);
                        _Data.AsignarCampo("CODIGO_DEPARTAMENTO", _CodigoDepartamento, true);
                        _Data.AsignarCampo("CODIGO_PAIS", _CodigoPais, true);
                        _Data.AsignarCampo("ESTADO_MUNICIPIO", 0);
                        _Resultado = _Data.EjecutarOperacion(ModuloGeneral.TipoDeOperacion.Modificar, "MUNICIPIOS");
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
