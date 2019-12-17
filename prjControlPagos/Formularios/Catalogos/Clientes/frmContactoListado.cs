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
    public partial class frmContactoListado : Conexion.frmPlantillaListado
    {
        public frmContactoListado()
        {
            InitializeComponent();
        }

        private void frmContactoListado_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Listado de contactos";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 301;
                ClaseDeConexion = new Negocio.Corporacion(Funciones.AñoDeOperacion, Funciones.Ambiente);
                FormularioInformacionDetalle = new frmContactoAsociacionesInformacionDetalle();


                AccesosPermitidos = "12345";
                //MostrarBotonEliminar = false;
                MostrarBotonImprimir = false;
                MostrarRegistros = "500";
                // Consultas        
                SelectSQL = "CODIGO_CONTACTO, NIT_FACTURACION, NOMBRE_CONTACTO, NOMBRE_FACTURACION, CASE ESTADO_CLIENTE WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS ESTADO";
                From = "CRM_CONTACTOS";
                Where = "";
                OrderBy = "CODIGO_CONTACTO";

                AgregarColumna("Código", "CODIGO_CONTACTO", 10, true, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Nit", "NIT_FACTURACION", 15, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("Nombre", "NOMBRE_CONTACTO", 35, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("Nombre factura", "NOMBRE_FACTURACION", 30, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("Estado", "ESTADO", 10, true, DataGridViewContentAlignment.MiddleLeft, false);


                InicializarFormulario();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
