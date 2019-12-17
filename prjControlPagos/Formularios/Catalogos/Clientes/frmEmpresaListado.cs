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
    public partial class frmEmpresaListado : Conexion.frmPlantillaListado
    {
        public frmEmpresaListado()
        {
            InitializeComponent();
        }

        private void frmEmpresaListado_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Listado de empresas";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 301;
                ClaseDeConexion = new Negocio.Corporacion(Funciones.AñoDeOperacion, Funciones.Ambiente);
                FormularioInformacionDetalle = new frmEmpresaSucursalesInformacionDetalle();


                AccesosPermitidos = "12345";
                //MostrarBotonEliminar = false;
                MostrarBotonImprimir = false;
                MostrarRegistros = "500";
                // Consultas        
                SelectSQL = "CODIGO_EMPRESA, NIT_EMPRESA, NOMBRE_EMPRESA, NOMBRE_FACTURACION, CASE ESTADO_EMPRESA WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS ESTADO";
                From = "CRM_EMPRESAS";
                Where = "";
                OrderBy = "CODIGO_EMPRESA";

                AgregarColumna("Código", "CODIGO_EMPRESA", 10, true, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Nit", "NIT_EMPRESA", 15, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("Nombre", "NOMBRE_EMPRESA", 35, true, DataGridViewContentAlignment.MiddleLeft, false);
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
