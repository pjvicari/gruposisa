using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Negocio
{
    public class Combinaciones : Base
    {
        #region "Constructor"
        public Combinaciones(int AñoDeOperacion, ModuloGeneral.AmbienteDeBaseDeDatos ambienteDeBaseDeDatos)
                : base(ModuloGeneral.GestorDeBaseDeDatos.MySQL, ModuloGeneral.EsquemaDeBaseDeDatos.Operacion, AñoDeOperacion, false, ambienteDeBaseDeDatos)
        {
        }
        #endregion

        #region "Propiedades"

        private ModuloGeneral.TipoDeOperacion _TipoDeOperacion; public ModuloGeneral.TipoDeOperacion TipoDeOperacion { get => _TipoDeOperacion; set => _TipoDeOperacion = value; }

        //Campos de la tabla
        private int _CodigoCombinacion = 0; public int CodigoCombinacion { get => _CodigoCombinacion; set => _CodigoCombinacion = value; }
        private string _NombreCombinacion = ""; public string NombreCombinacion { get => _NombreCombinacion; set => _NombreCombinacion = value; }
        private string _DescripcionCombinacion = ""; public string DescripcionCombinacion { get => _DescripcionCombinacion; set => _DescripcionCombinacion = value; }
        private double _PrecioSugerido = 0; public double PrecioSugerido { get => _PrecioSugerido; set => _PrecioSugerido = value; }
        private double _CostoNeto = 0; public double CostoNeto { get => _CostoNeto; set => _CostoNeto = value; }
        private double _Impuesto = 0; public double Impuesto { get => _Impuesto; set => _Impuesto = value; }
        private int _EstadoCombinacion = 1; public int EstadoCombinacion { get => _EstadoCombinacion; set => _EstadoCombinacion = value; }

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
                    if (!CargarDatos(ref _Siguiente, "(COUNT(CODIGO_COMBINACION) + 1) AS SIGUIENTE", "COMBINACIONES"))
                    {
                        goto salir;
                    }
                    _CodigoCombinacion = (int.TryParse(_Siguiente, out _CodigoCombinacion)) ? _CodigoCombinacion : 0;
                }
                if (_CodigoCombinacion == 0) { Mensaje = "Debe ingresar un valor en Codigo Combinacion."; _Resultado = false; goto salir; }
                if (_NombreCombinacion == "" || _NombreCombinacion.Length > 250) { Mensaje = "Debe ingresar un valor en Nombre Combinacion. No debe exceder los 250 carácteres."; _Resultado = false; goto salir; }
                if (_DescripcionCombinacion == "" || _DescripcionCombinacion.Length > 500) { Mensaje = "Debe ingresar un valor en Descripcion Combinacion. No debe exceder los 500 carácteres."; _Resultado = false; goto salir; }
                if (_PrecioSugerido == 0) { Mensaje = "Debe ingresar un valor en Precio Sugerido."; _Resultado = false; goto salir; }
                if (_CostoNeto == 0) { Mensaje = "Debe ingresar un valor en Costo Neto."; _Resultado = false; goto salir; }
                if (_Impuesto == 0) { Mensaje = "Debe ingresar un valor en Impuesto."; _Resultado = false; goto salir; }
                if (_EstadoCombinacion == 0) { Mensaje = "Debe ingresar un valor en Estado Combinacion."; _Resultado = false; goto salir; }

            }
            catch (Exception ex)
            {
                _Resultado = false;
                Mensaje = ex.Message;
            }
        salir:
            return _Resultado;
        }

        public bool OperarCombinacion()
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
                            _Data.AsignarCampo("CODIGO_COMBINACION", _CodigoCombinacion, true);
                            _Data.AsignarCampo("NOMBRE_COMBINACION", _NombreCombinacion);
                            _Data.AsignarCampo("DESCRIPCION_COMBINACION", _DescripcionCombinacion);
                            _Data.AsignarCampo("PRECIO_SUGERIDO", _PrecioSugerido);
                            _Data.AsignarCampo("COSTO_NETO", _CostoNeto);
                            _Data.AsignarCampo("IMPUESTO", _Impuesto);
                            _Data.AsignarCampo("ESTADO_COMBINACION", _EstadoCombinacion);
                            _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "COMBINACIONES");

                        }
                        break;
                    case ModuloGeneral.TipoDeOperacion.Eliminar:
                        if (_CodigoCombinacion == 0) { Mensaje = "Debe ingresar un valor en Codigo Combinacion."; _Resultado = false; goto salir; }
                        _Data.AsignarCampo("CODIGO_COMBINACION", _CodigoCombinacion, true);
                        _Data.AsignarCampo("ESTADO_COMBINACION", 0);
                        _Resultado = _Data.EjecutarOperacion(ModuloGeneral.TipoDeOperacion.Modificar, "COMBINACIONES");
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
