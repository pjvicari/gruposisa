using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Negocio
{
    public class Departamento : Base
    {
        #region "Constructor"
        public Departamento(int AñoDeOperacion, ModuloGeneral.AmbienteDeBaseDeDatos ambienteDeBaseDeDatos)
                : base(ModuloGeneral.GestorDeBaseDeDatos.MySQL, ModuloGeneral.EsquemaDeBaseDeDatos.Operacion, AñoDeOperacion, false, ambienteDeBaseDeDatos)
        {
        }
        #endregion

        #region "Propiedades"

        private ModuloGeneral.TipoDeOperacion _TipoDeOperacion; public ModuloGeneral.TipoDeOperacion TipoDeOperacion { get => _TipoDeOperacion; set => _TipoDeOperacion = value; }

        //Campos de la tabla
        private int _CodigoDepartamento = 0; public int CodigoDepartamento { get => _CodigoDepartamento; set => _CodigoDepartamento = value; }
        private string _NombreDepartamento = ""; public string NombreDepartamento { get => _NombreDepartamento; set => _NombreDepartamento = value; }
        private int _CodigoPais = 0; public int CodigoPais { get => _CodigoPais; set => _CodigoPais = value; }
        private int _EstadoDepartamento = 1; public int EstadoDepartamento { get => _EstadoDepartamento; set => _EstadoDepartamento = value; }

        #endregion

        #region "Metodos"

        private bool Validar()
        {
            bool _Resultado = true;
            try
            {

                if (_CodigoPais == 0) { Mensaje = "Debe ingresar un valor en Codigo Pais."; _Resultado = false; goto salir; }
                if (_TipoDeOperacion == ModuloGeneral.TipoDeOperacion.Agregar)
                {
                    string _Siguiente = "";
                    AsignarParametroWhere("CODIGO_PAIS", _CodigoPais, ModuloGeneral.TipoDeOperadorLogico.AndOperador, ModuloGeneral.TipoDeOperadorDeComparacion.Igual,false);
                    if (!CargarDatos(ref _Siguiente, "(COUNT(CODIGO_DEPARTAMENTO) + 1) AS SIGUIENTE", "DEPARTAMENTOS"))
                    {
                        goto salir;
                    }
                    _CodigoDepartamento = (int.TryParse(_Siguiente, out _CodigoDepartamento)) ? _CodigoDepartamento : 0;
                }
                if (_CodigoDepartamento == 0) { Mensaje = "Debe ingresar un valor en Codigo Departamento."; _Resultado = false; goto salir; }
                if (_NombreDepartamento == "" || _NombreDepartamento.Length > 150) { Mensaje = "Debe ingresar un valor en Nombre Departamento. No debe exceder los 150 carácteres."; _Resultado = false; goto salir; }
                if (_EstadoDepartamento == 0) { Mensaje = "Debe ingresar un valor en Estado Departamento."; _Resultado = false; goto salir; }

            }
            catch (Exception ex)
            {
                _Resultado = false;
                Mensaje = ex.Message;
            }
        salir:
            return _Resultado;
        }

        public bool OperarDepartamento()
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
                            _Data.AsignarCampo("CODIGO_DEPARTAMENTO", _CodigoDepartamento, true);
                            _Data.AsignarCampo("NOMBRE_DEPARTAMENTO", _NombreDepartamento);
                            _Data.AsignarCampo("CODIGO_PAIS", _CodigoPais, true);
                            _Data.AsignarCampo("ESTADO_DEPARTAMENTO", _EstadoDepartamento);
                            _Resultado = _Data.EjecutarOperacion(_TipoDeOperacion, "DEPARTAMENTOS");

                        }
                        break;
                    case ModuloGeneral.TipoDeOperacion.Eliminar:
                        if (_CodigoDepartamento == 0) { Mensaje = "Debe ingresar un valor en Codigo Departamento."; _Resultado = false; goto salir; }
                        if (_CodigoPais == 0) { Mensaje = "Debe ingresar un valor en Codigo Pais."; _Resultado = false; goto salir; }
                        _Data.AsignarCampo("CODIGO_DEPARTAMENTO", _CodigoDepartamento, true);
                        _Data.AsignarCampo("CODIGO_PAIS", _CodigoPais, true);
                        _Data.AsignarCampo("ESTADO_DEPARTAMENTO", 0);
                        _Resultado = _Data.EjecutarOperacion(ModuloGeneral.TipoDeOperacion.Modificar, "DEPARTAMENTOS");
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
