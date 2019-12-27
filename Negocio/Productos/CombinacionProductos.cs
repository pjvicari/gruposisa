using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Negocio
{
    public class CombinacionProductos : Base
    {
        #region "Constructor"
        public CombinacionProductos(int AñoDeOperacion, ModuloGeneral.AmbienteDeBaseDeDatos ambienteDeBaseDeDatos)
                : base(ModuloGeneral.GestorDeBaseDeDatos.MySQL, ModuloGeneral.EsquemaDeBaseDeDatos.Operacion, AñoDeOperacion, false, ambienteDeBaseDeDatos)
        {
        }
        #endregion

        #region "Propiedades"

        private ModuloGeneral.TipoDeOperacion _TipoDeOperacion; public ModuloGeneral.TipoDeOperacion TipoDeOperacion { get => _TipoDeOperacion; set => _TipoDeOperacion = value; }

        //Campos de la tabla
        private int _CodigoCombinacionProducto = 0; public int CodigoCombinacionProducto { get => _CodigoCombinacionProducto; set => _CodigoCombinacionProducto = value; }
        private int _CodigoCombinacion = 0; public int CodigoCombinacion { get => _CodigoCombinacion; set => _CodigoCombinacion = value; }
        private int _CodigoProducto = 0; public int CodigoProducto { get => _CodigoProducto; set => _CodigoProducto = value; }

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
                    if (!CargarDatos(ref _Siguiente, "(COUNT(CODIGO_COMBINACION_PRODUCTO) + 1) AS SIGUIENTE", "productos_combinaciones"))
                    {
                        goto salir;
                    }
                    //_CodigoPais = (int.TryParse(_Siguiente, out _CodigoPais)) ? _CodigoPais : 0;
                }
                if (_CodigoCombinacionProducto == 0) { Mensaje = "Debe ingresar un valor en Codigo Combinacion Producto."; _Resultado = false; goto salir; }
                if (_CodigoCombinacion == 0) { Mensaje = "Debe ingresar un valor en Codigo Combinacion."; _Resultado = false; goto salir; }
                if (_CodigoProducto == 0) { Mensaje = "Debe ingresar un valor en Codigo Producto."; _Resultado = false; goto salir; }

            }
            catch (Exception ex)
            {
                _Resultado = false;
                Mensaje = ex.Message;
            }
        salir:
            return _Resultado;
        }

        public bool OperarCombinacionProducto()
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
                            _Data.AsignarCampo("CODIGO_COMBINACION_PRODUCTO", _CodigoCombinacionProducto,true);
                            _Data.AsignarCampo("CODIGO_COMBINACION", _CodigoCombinacion);
                            _Data.AsignarCampo("CODIGO_PRODUCTO", _CodigoProducto);
                            _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "productos_combinaciones");

                        }
                        break;
                    case ModuloGeneral.TipoDeOperacion.Eliminar:
                        if (_CodigoCombinacionProducto == 0) { Mensaje = "Debe ingresar un valor en Codigo Combinacion Producto."; _Resultado = false; goto salir; }
                        _Data.AsignarCampo("CODIGO_COMBINACION_PRODUCTO", _CodigoCombinacionProducto, true);
                        _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "productos_combinaciones");
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
