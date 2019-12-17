using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace ControlPagos.Formularios.Catalogos
{
    public partial class frmContactoAsociacionInformacion : Conexion.frmPlantillaInformacion
    {
        Contacto _ClaseConexion = new Contacto(Funciones.AñoDeOperacion, Funciones.Ambiente);

        public frmContactoAsociacionInformacion()
        {
            InitializeComponent();
        }

        private void frmContactoAsociacionInformacion_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Información del cliente relacionado";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 2029;
                ClaseDeConexion = _ClaseConexion;


                // Consultas        
                SelectSQL = "CODIGO_CLI_CONTACTO, CODIGO_CONTACTO, CODIGO_CLIENTE, TIPO_CLIENTE, NOMBRE_TIPO, NOMBRE_CLIENTE";
                From = "(SELECT CCC.CODIGO_CLI_CONTACTO, CCO.CODIGO_CONTACTO, CCC.CODIGO_CLIENTE, CCC.TIPO_CLIENTE, CASE CCC.TIPO_CLIENTE WHEN 1 THEN 'CONTACTO' WHEN 2 THEN 'SUCURSAL' WHEN 3 THEN 'EMPRESA' WHEN 4 THEN 'CORPORACION' END AS NOMBRE_TIPO, CASE CCC.TIPO_CLIENTE WHEN 1 THEN CCO.NOMBRE_CONTACTO WHEN 2 THEN CSU.NOMBRE_SUCURSAL WHEN 3 THEN CEM.NOMBRE_EMPRESA WHEN 4 THEN CCR.NOMBRE_CORPORACION END AS NOMBRE_CLIENTE FROM gruposisa.crm_clientes_contacto CCC LEFT OUTER JOIN gruposisa.CRM_CONTACTOS CCO ON CCO.CODIGO_CONTACTO = CCC.CODIGO_CONTACTO LEFT OUTER JOIN gruposisa.crm_sucursales CSU ON CCC.TIPO_CLIENTE = CSU.TIPO_CLIENTE AND CCC.CODIGO_CLIENTE = CSU.CODIGO_SUCURSAL LEFT OUTER JOIN gruposisa.crm_empresas CEM ON CCC.TIPO_CLIENTE = CEM.TIPO_CLIENTE AND CCC.CODIGO_CLIENTE = CEM.CODIGO_EMPRESA LEFT OUTER JOIN gruposisa.crm_corporaciones CCR ON CCC.TIPO_CLIENTE = CSU.TIPO_CLIENTE AND CCC.CODIGO_CLIENTE = CCR.CODIGO_CORPORACION) CLIENTES";
                Where = "";
                //OrderBy = "CODIGO_TRATAMIENTO";

                VincularColumna("CODIGO_CLI_CONTACTO", txtCodigoClienteContacto, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("CODIGO_CONTACTO", txtCodigoContacto, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("CODIGO_CLIENTE", txtCodigoCliente, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("TIPO_CLIENTE", txtTipoCliente, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("NOMBRE_CLIENTE", txtNombreCliente, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.Ninguna);
                VincularColumna("", btnCliente, HorizontalAlignment.Right, Conexion.ModuloGeneral.TipoDeEdicion.AlModificar);

                InicializarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow Producto;

                Busquedas.frmClienteBusqueda _Busqueda = new Busquedas.frmClienteBusqueda();
                _Busqueda.FiltroCliente = "1";
                _Busqueda.ShowDialog(this);
                Producto = _Busqueda.FilaSeleccionada;
                if (Producto != null)
                {
                    txtCodigoCliente.Text = Producto.Cells["CODIGO_CLIENTE"].Value.ToString();
                    txtTipoCliente.Text = Producto.Cells["TIPO_CLIENTE"].Value.ToString();
                    txtNombreCliente.Text = Producto.Cells["NOMBRE_CLIENTE"].Value.ToString();
                }

                _Busqueda.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al buscar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void LimpiarCampos()
        {
            try
            {
                txtCodigoContacto.Text = ObtenerLlavePrimariaDetalle("CODIGO_CONTACTO");
                txtCodigoClienteContacto.Text = "";
                txtTipoCliente.Text = "";
                txtCodigoCliente.Text = "";
                txtNombreCliente.Text = "";
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
                _ClaseConexion.CodigoContacto = (int.TryParse(txtCodigoContacto.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoCliContacto = (int.TryParse(txtCodigoClienteContacto.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.TipoClienteContacto = (int.TryParse(txtTipoCliente.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.CodigoCliente = (int.TryParse(txtCodigoCliente.Text, out _Numero)) ? _Numero : 0;
                _ClaseConexion.NombreFacturacion = txtNombreCliente.Text.Trim();
                _ClaseConexion.EstadoContacto = 1;

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
                if ((bool)_ClaseConexion.OperarClienteContacto())
                {
                    _Resultado = true;
                    MessageBox.Show("Relación agregada satisfactoriamente", "Atención al agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarClienteContacto())
                {
                    _Resultado = true;
                    MessageBox.Show("Relación modificada satisfactoriamente", "Atención al modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((bool)_ClaseConexion.OperarClienteContacto())
                {
                    _Resultado = true;
                    MessageBox.Show("Relación eliminada satisfactoriamente", "Atención al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
