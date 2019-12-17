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
    public partial class frmPaisListado : Conexion.frmPlantillaListado
    {
        public frmPaisListado()
        {
            InitializeComponent();
        }

        private void frmPaisListado_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Listado de paises";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 301;
                ClaseDeConexion = new Negocio.Corporacion(Funciones.AñoDeOperacion, Funciones.Ambiente);
                FormularioInformacion = new frmPaisInformacion();


                AccesosPermitidos = "12345";
                //MostrarBotonEliminar = false;
                MostrarBotonImprimir = false;
                MostrarRegistros = "500";
                // Consultas        
                SelectSQL = "CODIGO_PAIS, NOMBRE_PAIS, CASE ESTADO_PAIS WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS ESTADO";
                From = "PAISES";
                Where = "";
                OrderBy = "CODIGO_PAIS";

                AgregarColumna("Código", "CODIGO_PAIS", 10, true, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Pais", "NOMBRE_PAIS", 80, true, DataGridViewContentAlignment.MiddleLeft, false);
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
