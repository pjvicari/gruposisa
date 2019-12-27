using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Negocio
{
    public class Tratamiento : Base
    {
        #region "Constructor"
        public Tratamiento(int AñoDeOperacion, ModuloGeneral.AmbienteDeBaseDeDatos ambienteDeBaseDeDatos)
                : base(ModuloGeneral.GestorDeBaseDeDatos.MySQL, ModuloGeneral.EsquemaDeBaseDeDatos.Operacion, AñoDeOperacion, false, ambienteDeBaseDeDatos)
        {
        }
        #endregion

        #region "Propiedades"

        private ModuloGeneral.TipoDeOperacion _TipoDeOperacion; public ModuloGeneral.TipoDeOperacion TipoDeOperacion { get => _TipoDeOperacion; set => _TipoDeOperacion = value; }

        //Campos de la tabla
        private int _CodigoTratamiento = 0; public int CodigoTratamiento { get => _CodigoTratamiento; set => _CodigoTratamiento = value; }
        private string _SiglasTratamiento = ""; public string SiglasTratamiento { get => _SiglasTratamiento; set => _SiglasTratamiento = value; }
        private string _Tratamiento = ""; public string Tratamientos { get => _Tratamiento; set => _Tratamiento = value; }
        private int _EstadoTratamiento = 1; public int EstadoTratamiento { get => _EstadoTratamiento; set => _EstadoTratamiento = value; }

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
                    if (!CargarDatos(ref _Siguiente, "(COUNT(CODIGO_TRATAMIENTO) + 1) AS SIGUIENTE", "CRM_TRATAMIENTOS"))
                    {
                        goto salir;
                    }
                    _CodigoTratamiento = (int.TryParse(_Siguiente, out _CodigoTratamiento)) ? _CodigoTratamiento : 0;
                }
                if (_CodigoTratamiento == 0) { Mensaje = "Debe ingresar un valor en Codigo Tratamiento."; _Resultado = false; goto salir; }
                if (_SiglasTratamiento == "" || _SiglasTratamiento.Length > 45) { Mensaje = "Debe ingresar un valor en Siglas Tratamiento. No debe exceder los 45 carácteres."; _Resultado = false; goto salir; }
                if (_Tratamiento == "" || _Tratamiento.Length > 100) { Mensaje = "Debe ingresar un valor en Tratamiento. No debe exceder los 100 carácteres."; _Resultado = false; goto salir; }
                //if (_EstadoTratamiento == 0) { Mensaje = "Debe ingresar un valor en Estado Tratamiento."; _Resultado = false; goto salir; }

            }
            catch (Exception ex)
            {
                _Resultado = false;
                Mensaje = ex.Message;
            }
        salir:
            return _Resultado;
        }

        public bool OperarTratamiento()
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
                            _Data.AsignarCampo("CODIGO_TRATAMIENTO", _CodigoTratamiento, true);
                            _Data.AsignarCampo("SIGLAS_TRATAMIENTO", _SiglasTratamiento);
                            _Data.AsignarCampo("TRATAMIENTO", _Tratamiento);
                            _Data.AsignarCampo("ESTADO_TRATAMIENTO", _EstadoTratamiento);
                            _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "CRM_TRATAMIENTOS");
                        }
                        break;
                    case ModuloGeneral.TipoDeOperacion.Eliminar:
                        if (_CodigoTratamiento == 0) { Mensaje = "Debe ingresar un valor en Codigo Tratamiento."; _Resultado = false; goto salir; }
                        _Data.AsignarCampo("CODIGO_TRATAMIENTO", _CodigoTratamiento, true);
                        _Data.AsignarCampo("ESTADO_TRATAMIENTO", 0);
                        _Resultado = _Data.EjecutarOperacion(ModuloGeneral.TipoDeOperacion.Modificar, "CRM_TRATAMIENTOS");
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
