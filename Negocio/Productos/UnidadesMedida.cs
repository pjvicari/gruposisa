using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Negocio
{
    public class UnidadesMedida : Base
    {
        #region "Constructor"
        public UnidadesMedida(int AñoDeOperacion, ModuloGeneral.AmbienteDeBaseDeDatos ambienteDeBaseDeDatos)
                : base(ModuloGeneral.GestorDeBaseDeDatos.MySQL, ModuloGeneral.EsquemaDeBaseDeDatos.Operacion, AñoDeOperacion, false, ambienteDeBaseDeDatos)
        {
        }
        #endregion

        #region "Propiedades"

        private ModuloGeneral.TipoDeOperacion _TipoDeOperacion; public ModuloGeneral.TipoDeOperacion TipoDeOperacion { get => _TipoDeOperacion; set => _TipoDeOperacion = value; }

        //Campos de la tabla
        private int _CodigoUnidadMedida = 0; public int CodigoUnidadMedida { get => _CodigoUnidadMedida; set => _CodigoUnidadMedida = value; }
        private string _NombreUnidadMedida = ""; public string NombreUnidadMedida { get => _NombreUnidadMedida; set => _NombreUnidadMedida = value; }
        private int _EstadoMedida = 1; public int EstadoMedida { get => _EstadoMedida; set => _EstadoMedida = value; }

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
                    if (!CargarDatos(ref _Siguiente, "(COUNT(CODIGO_UNIDAD_MEDIDA) + 1) AS SIGUIENTE", "UNIDADES_MEDIDA"))
                    {
                        goto salir;
                    }
                    _CodigoUnidadMedida = (int.TryParse(_Siguiente, out _CodigoUnidadMedida)) ? _CodigoUnidadMedida : 0;
                }
                if (_CodigoUnidadMedida == 0) { Mensaje = "Debe ingresar un valor en Codigo Unidad Medida."; _Resultado = false; goto salir; }
                if (_NombreUnidadMedida == "" || _NombreUnidadMedida.Length > 100) { Mensaje = "Debe ingresar un valor en Nombre Unidad Medida. No debe exceder los 100 carácteres."; _Resultado = false; goto salir; }
                if (_EstadoMedida == 0) { Mensaje = "Debe ingresar un valor en Estado Medida."; _Resultado = false; goto salir; }

            }
            catch (Exception ex)
            {
                _Resultado = false;
                Mensaje = ex.Message;
            }
        salir:
            return _Resultado;
        }

        public bool OperarUnidadMedida()
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
                            _Data.AsignarCampo("CODIGO_UNIDAD_MEDIDA", _CodigoUnidadMedida, true);
                            _Data.AsignarCampo("NOMBRE_UNIDAD_MEDIDA", _NombreUnidadMedida);
                            _Data.AsignarCampo("ESTADO_MEDIDA", _EstadoMedida);
                            _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "UNIDADES_MEDIDA");
                        }
                        break;
                    case ModuloGeneral.TipoDeOperacion.Eliminar:
                        if (_CodigoUnidadMedida == 0) { Mensaje = "Debe ingresar un valor en Codigo Unidad Medida."; _Resultado = false; goto salir; }
                        _Data.AsignarCampo("CODIGO_UNIDAD_MEDIDA", _CodigoUnidadMedida, true);
                        _Data.AsignarCampo("ESTADO_MEDIDA", 0);
                        _Resultado = _Data.EjecutarOperacion(ModuloGeneral.TipoDeOperacion.Modificar, "UNIDADES_MEDIDA");
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
