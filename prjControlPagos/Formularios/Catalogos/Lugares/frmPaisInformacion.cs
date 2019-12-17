using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace ControlPagos.Formularios.Catalogos.Lugares
{
    public partial class frmPaisInformacion : Conexion.frmPlantillaInformacion
    {
        Pais _ClaseConexion = new Pais(Funciones.AñoDeOperacion, Funciones.Ambiente);
        public frmPaisInformacion()
        {
            InitializeComponent();
        }

        private void frmPaisInformacion_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Información de pais";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 2029;
                ClaseDeConexion = _ClaseConexion;


                // Consultas        
                SelectSQL = "CODIGO_PAIS, DESCRIPCION_PAIS, NOMBRE_PAIS";
                From = "PAISES";
                Where = "";
                OrderBy = "CODIGO_PAIS";

                VincularColumna("CODIGO_PAIS", txtCodigoPais, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("NOMBRE_PAIS", txtNombrePais, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                VincularColumna("DESCRIPCION_PAIS", txtDescripcionPais, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                

                //DataTable dtRubrosAuxiliares = new DataTable();
                //if ((bool)_ClaseConexion.CargarDatos(ref dtRubrosAuxiliares, "CODIGO_RUBRO_AUXILIAR, TRIM(NOMBRE_RUBRO_AUXILIAR) AS NOMBRE_RUBRO_AUXILIAR", "RUBROS_AUXILIARES"))
                //{
                //    _ClaseConexion.Llenar_ComboBox(cmbRubroAuxiliar, dtRubrosAuxiliares, "CODIGO_RUBRO_AUXILIAR", "NOMBRE_RUBRO_AUXILIAR");
                //}

                InicializarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void LimpiarCampos()
        {
            try
            {
                txtCodigoPais.Text = "0";
                txtDescripcionPais.Text = "";
                txtNombrePais.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al limpiar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AsignarCampos()
        {
            try
            {
                int _Numero = 0;
                _ClaseConexion.CodigoPais = (int.TryParse(txtCodigoPais.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.NombrePais = txtNombrePais.Text.Trim();
                _ClaseConexion.DescripcionPais = txtDescripcionPais.Text.Trim();
                _ClaseConexion.EstadoPais = 1;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al limpiar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Agregar()
        {
            bool _Resultado = false;
            try
            {
                AsignarCampos();
                _ClaseConexion.TipoDeOperacion = Conexion.ModuloGeneral.TipoDeOperacion.Agregar;
                if ((bool)_ClaseConexion.OperarPais())
                {
                    _Resultado = true;
                    MessageBox.Show("Pais agregado satisfactoriamente", "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _Resultado = false;
                    MessageBox.Show(_ClaseConexion.Mensaje, "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _Resultado;
        }

        public override bool Modificar()
        {
            bool _Resultado = false;
            try
            {
                AsignarCampos();
                _ClaseConexion.TipoDeOperacion = Conexion.ModuloGeneral.TipoDeOperacion.Modificar;
                if ((bool)_ClaseConexion.OperarPais())
                {
                    _Resultado = true;
                    MessageBox.Show("Pais modificado satisfactoriamente", "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _Resultado = false;
                    MessageBox.Show(_ClaseConexion.Mensaje, "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _Resultado;
        }

        public override bool Eliminar()
        {
            bool _Resultado = false;
            try
            {
                AsignarCampos();
                _ClaseConexion.TipoDeOperacion = Conexion.ModuloGeneral.TipoDeOperacion.Eliminar;
                if ((bool)_ClaseConexion.OperarPais())
                {
                    _Resultado = true;
                    MessageBox.Show("Pais eliminado satisfactoriamente", "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _Resultado = false;
                    MessageBox.Show(_ClaseConexion.Mensaje, "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _Resultado;
        }
    }
}
