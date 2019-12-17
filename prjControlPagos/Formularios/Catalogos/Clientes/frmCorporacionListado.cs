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
    public partial class frmCorporacionListado : Conexion.frmPlantillaListado
    {
        public frmCorporacionListado()
        {
            InitializeComponent();
        }

        private void frmCorporacion_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Listado de corporaciones";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 301;
                ClaseDeConexion = new Negocio.Corporacion(Funciones.AñoDeOperacion, Funciones.Ambiente);
                FormularioInformacionDetalle = new Catalogos.frmCorporacionEmpresaInformacionDetalle();


                AccesosPermitidos = "12345";
                //MostrarBotonEliminar = false;
                MostrarBotonImprimir = false;
                MostrarRegistros = "500";
                // Consultas        
                SelectSQL = "CODIGO_CORPORACION, NOMBRE_CORPORACION, CASE ESTADO_CORPORACION WHEN 1 THEN 'Activo' WHEN 0 THEN 'Inactivo' END AS ESTADO";
                From = "CRM_CORPORACIONES";
                Where = "";
                OrderBy = "NOMBRE_CORPORACION";

                AgregarColumna("Código", "CODIGO_CORPORACION", 15, true, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Nombre corporación", "NOMBRE_CORPORACION", 65, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("Estado", "ESTADO", 20, true, DataGridViewContentAlignment.MiddleLeft, false);


                InicializarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
