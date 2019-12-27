using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace ControlPagos.Formularios.Catalogos.Productos
{
    public partial class frmUnidadMedidaInformacion : Conexion.frmPlantillaInformacion
    {
        UnidadesMedida _ClaseConexion = new UnidadesMedida(Funciones.AñoDeOperacion, Funciones.Ambiente);
        public frmUnidadMedidaInformacion()
        {
            InitializeComponent();
        }

        private void frmUnidadMedidaInformacion_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Información de unidad de medida";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 2029;
                ClaseDeConexion = _ClaseConexion;


                // Consultas        
                SelectSQL = "CODIGO_UNIDAD_MEDIDA, NOMBRE_UNIDAD_MEDIDA, ESTADO_MEDIDA";
                From = "unidades_medida";
                Where = "";
                OrderBy = "CODIGO_UNIDAD_MEDIDA";

                VincularColumna("CODIGO_UNIDAD_MEDIDA", txtCodigoUnidadMedida, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("NOMBRE_UNIDAD_MEDIDA", txtUnidadMedida, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);
                

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
                txtCodigoUnidadMedida.Text = "0";
                txtUnidadMedida.Text = "";
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
                _ClaseConexion.CodigoUnidadMedida = (int.TryParse(txtCodigoUnidadMedida.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.NombreUnidadMedida = txtUnidadMedida.Text.Trim();
                _ClaseConexion.EstadoMedida = 1;

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
                if ((bool)_ClaseConexion.OperarUnidadMedida())
                {
                    _Resultado = true;
                    MessageBox.Show("Unidad de medida agregada satisfactoriamente", "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarUnidadMedida())
                {
                    _Resultado = true;
                    MessageBox.Show("Unidad de medida modificada satisfactoriamente", "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarUnidadMedida())
                {
                    _Resultado = true;
                    MessageBox.Show("Unidad de medida eliminada satisfactoriamente", "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
