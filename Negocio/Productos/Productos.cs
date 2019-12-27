using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Negocio
{
    public class Productos : Base
    {
        #region "Constructor"
        public Productos(int AñoDeOperacion, ModuloGeneral.AmbienteDeBaseDeDatos ambienteDeBaseDeDatos)
                : base(ModuloGeneral.GestorDeBaseDeDatos.MySQL, ModuloGeneral.EsquemaDeBaseDeDatos.Operacion, AñoDeOperacion, false, ambienteDeBaseDeDatos)
        {
        }
        #endregion

        #region "Propiedades"

        private ModuloGeneral.TipoDeOperacion _TipoDeOperacion; public ModuloGeneral.TipoDeOperacion TipoDeOperacion { get => _TipoDeOperacion; set => _TipoDeOperacion = value; }

        //Campos de la tabla
        private int _CodigoProducto = 0; public int CodigoProducto { get => _CodigoProducto; set => _CodigoProducto = value; }
        private string _NombreProducto = ""; public string NombreProducto { get => _NombreProducto; set => _NombreProducto = value; }
        private string _DescripcionProducto = ""; public string DescripcionProducto { get => _DescripcionProducto; set => _DescripcionProducto = value; }
        private double _PrecioSugerido = 0; public double PrecioSugerido { get => _PrecioSugerido; set => _PrecioSugerido = value; }
        private double _CostoNeto = 0; public double CostoNeto { get => _CostoNeto; set => _CostoNeto = value; }
        private double _Impuesto = 0; public double Impuesto { get => _Impuesto; set => _Impuesto = value; }
        private double _PorcentajeImpuesto = 0; public double PorcentajeImpuesto { get => _PorcentajeImpuesto; set => _PorcentajeImpuesto = value; }
        private int _TipoProducto = 0; public int TipoProducto { get => _TipoProducto; set => _TipoProducto = value; }
        private int _CodigoUnidadMedida = 0; public int CodigoUnidadMedida { get => _CodigoUnidadMedida; set => _CodigoUnidadMedida = value; }
        private int _EstadoProducto = 1; public int EstadoProducto { get => _EstadoProducto; set => _EstadoProducto = value; }

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
                    if (!CargarDatos(ref _Siguiente, "(COUNT(CODIGO_PRODUCTO) + 1) AS SIGUIENTE", "PRODUCTOS"))
                    {
                        goto salir;
                    }
                    _CodigoProducto = (int.TryParse(_Siguiente, out _CodigoProducto)) ? _CodigoProducto : 0;
                }
                if (_CodigoProducto == 0) { Mensaje = "Debe ingresar un valor en Codigo Producto."; _Resultado = false; goto salir; }
                if (_NombreProducto == "" || _NombreProducto.Length > 250) { Mensaje = "Debe ingresar un valor en Nombre Producto. No debe exceder los 250 carácteres."; _Resultado = false; goto salir; }
                if (_DescripcionProducto == "" || _DescripcionProducto.Length > 500) { Mensaje = "Debe ingresar un valor en Descripcion Producto. No debe exceder los 500 carácteres."; _Resultado = false; goto salir; }
                if (_PrecioSugerido == 0) { Mensaje = "Debe ingresar un valor en Precio Sugerido."; _Resultado = false; goto salir; }
                if (_CostoNeto == 0) { Mensaje = "Debe ingresar un valor en Costo Neto."; _Resultado = false; goto salir; }
                if (_Impuesto == 0) { Mensaje = "Debe ingresar un valor en Impuesto."; _Resultado = false; goto salir; }
                if (_PorcentajeImpuesto == 0) { Mensaje = "Debe ingresar un valor en Porcentaje Impuesto."; _Resultado = false; goto salir; }
                if (_TipoProducto == 0) { Mensaje = "Debe ingresar un valor en Tipo Producto."; _Resultado = false; goto salir; }
                //if (_CodigoUnidadMedida == 0) { Mensaje = "Debe ingresar un valor en Codigo Unidad Medida."; _Resultado = false; goto salir; }
                if (_EstadoProducto == 0) { Mensaje = "Debe ingresar un valor en Estado Producto."; _Resultado = false; goto salir; }

            }
            catch (Exception ex)
            {
                _Resultado = false;
                Mensaje = ex.Message;
            }
        salir:
            return _Resultado;
        }

        public bool OperarProducto()
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
                            _Data.AsignarCampo("CODIGO_PRODUCTO", _CodigoProducto, true);
                            _Data.AsignarCampo("NOMBRE_PRODUCTO", _NombreProducto);
                            _Data.AsignarCampo("DESCRIPCION_PRODUCTO", _DescripcionProducto);
                            _Data.AsignarCampo("PRECIO_SUGERIDO", _PrecioSugerido);
                            _Data.AsignarCampo("COSTO_NETO", _CostoNeto);
                            _Data.AsignarCampo("IMPUESTO", _Impuesto);
                            _Data.AsignarCampo("PORCENTAJE_IMPUESTO", _PorcentajeImpuesto);
                            _Data.AsignarCampo("TIPO_PRODUCTO", _TipoProducto);
                            _Data.AsignarCampo("CODIGO_UNIDAD_MEDIDA", _CodigoUnidadMedida);
                            _Data.AsignarCampo("ESTADO_PRODUCTO", _EstadoProducto);
                            _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "PRODUCTOS");

                        }
                        break;
                    case ModuloGeneral.TipoDeOperacion.Eliminar:
                        if (_CodigoProducto == 0) { Mensaje = "Debe ingresar un valor en Codigo Producto."; _Resultado = false; goto salir; }
                        _Data.AsignarCampo("CODIGO_PRODUCTO", _CodigoProducto, true);
                        _Data.AsignarCampo("ESTADO_PRODUCTO", 0);
                        _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "PRODUCTOS");
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
