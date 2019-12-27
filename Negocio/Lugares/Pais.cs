using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Negocio
{
    public class Pais : Base
    {
        #region "Constructor"
        public Pais(int AñoDeOperacion, ModuloGeneral.AmbienteDeBaseDeDatos ambienteDeBaseDeDatos)
                : base(ModuloGeneral.GestorDeBaseDeDatos.MySQL, ModuloGeneral.EsquemaDeBaseDeDatos.Operacion, AñoDeOperacion, false, ambienteDeBaseDeDatos)
        {
        }
        #endregion

        #region "Propiedades"

        private ModuloGeneral.TipoDeOperacion _TipoDeOperacion; public ModuloGeneral.TipoDeOperacion TipoDeOperacion { get => _TipoDeOperacion; set => _TipoDeOperacion = value; }

        //Campos de la tabla
        private int _CodigoPais = 0; public int CodigoPais { get => _CodigoPais; set => _CodigoPais = value; }
        private string _NombrePais = ""; public string NombrePais { get => _NombrePais; set => _NombrePais = value; }
        private string _DescripcionPais = ""; public string DescripcionPais { get => _DescripcionPais; set => _DescripcionPais = value; }
        private int _EstadoPais = 1; public int EstadoPais { get => _EstadoPais; set => _EstadoPais = value; }

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
                    if (!CargarDatos(ref _Siguiente, "(COUNT(CODIGO_PAIS) + 1) AS SIGUIENTE", "PAISES"))
                    {
                        goto salir;
                    }
                    _CodigoPais = (int.TryParse(_Siguiente, out _CodigoPais)) ? _CodigoPais : 0;
                }
                if (_CodigoPais == 0) { Mensaje = "Debe ingresar un valor en Codigo Pais."; _Resultado = false; goto salir; }
                if (_NombrePais == "" || _NombrePais.Length > 150) { Mensaje = "Debe ingresar un valor en Nombre Pais. No debe exceder los 150 carácteres."; _Resultado = false; goto salir; }
                if (_DescripcionPais.Length > 500) { Mensaje = "Debe ingresar un valor en Descripcion Pais. No debe exceder los 500 carácteres."; _Resultado = false; goto salir; }
                if (_EstadoPais == 0) { Mensaje = "Debe ingresar un valor en Estado Pais."; _Resultado = false; goto salir; }

            }
            catch (Exception ex)
            {
                _Resultado = false;
                Mensaje = ex.Message;
            }
        salir:
            return _Resultado;
        }

        public bool OperarPais()
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
                            _Data.AsignarCampo("CODIGO_PAIS", _CodigoPais, true);
                            _Data.AsignarCampo("NOMBRE_PAIS", _NombrePais);
                            _Data.AsignarCampo("DESCRIPCION_PAIS", _DescripcionPais);
                            _Data.AsignarCampo("ESTADO_PAIS", _EstadoPais);
                            _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "PAISES");

                        }
                        break;
                    case ModuloGeneral.TipoDeOperacion.Eliminar:
                        if (_CodigoPais == 0) { Mensaje = "Debe ingresar un valor en Codigo Pais."; _Resultado = false; goto salir; }
                        _Data.AsignarCampo("CODIGO_PAIS", _CodigoPais, true);
                        _Data.AsignarCampo("ESTADO_PAIS", 0);
                        _Resultado = _Data.EjecutarOperacion(ModuloGeneral.TipoDeOperacion.Modificar, "PAISES");
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
