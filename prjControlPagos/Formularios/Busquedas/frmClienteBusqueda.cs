using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace ControlPagos.Formularios.Busquedas
{
    public partial class frmClienteBusqueda : Conexion.frmPlantillaFiltrar
    {
        public frmClienteBusqueda()
        {
            InitializeComponent();
        }

        private void frmClienteBusqueda_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Listado de tratamientos";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 301;
                ClaseDeConexion = new Negocio.Corporacion(Funciones.AñoDeOperacion, Funciones.Ambiente);

                MostrarRegistros = "500";
                // Consultas        
                SelectSQL = "CODIGO_TRATAMIENTO, SIGLAS_TRATAMIENTO, TRATAMIENTO, CASE ESTADO_TRATAMIENTO WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS ESTADO";
                From = "CRM_TRATAMIENTOS";
                Where = "";
                OrderBy = "CODIGO_TRATAMIENTO";

                AgregarColumna("Código", "CODIGO_CONTACTO", 15, false, DataGridViewContentAlignment.MiddleLeft, "");
                AgregarColumna("Nombres y Apellidos", "NOMBRE_CONTACTO", 50, true, DataGridViewContentAlignment.MiddleLeft, "");
                AgregarColumna("Cargo", "CARGO_CONTACTO", 35, true, DataGridViewContentAlignment.MiddleLeft, "");


                InicializarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
