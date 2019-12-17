using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace ControlPagos.Formularios.Catalogos.Clientes
{
    public partial class frmTratamientoListado : Conexion.frmPlantillaListado
    {
        public frmTratamientoListado()
        {
            InitializeComponent();
        }

        private void frmTratamientoListado_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Listado de tratamientos";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 301;
                ClaseDeConexion = new Negocio.Corporacion(Funciones.AñoDeOperacion, Funciones.Ambiente);
                FormularioInformacion = new frmTratamientoInformacion();


                AccesosPermitidos = "12345";
                //MostrarBotonEliminar = false;
                MostrarBotonImprimir = false;
                MostrarRegistros = "500";
                // Consultas        
                SelectSQL = "CODIGO_TRATAMIENTO, SIGLAS_TRATAMIENTO, TRATAMIENTO, CASE ESTADO_TRATAMIENTO WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS ESTADO";
                From = "CRM_TRATAMIENTOS";
                Where = "";
                OrderBy = "CODIGO_TRATAMIENTO";

                AgregarColumna("Código", "CODIGO_TRATAMIENTO", 10, true, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Siglas", "SIGLAS_TRATAMIENTO", 15, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("Tratamiento", "TRATAMIENTO", 65, true, DataGridViewContentAlignment.MiddleLeft, false);
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
