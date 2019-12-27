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
    public partial class frmUnidadMedidaListado : Conexion.frmPlantillaListado
    {
        public frmUnidadMedidaListado()
        {
            InitializeComponent();
        }

        private void frmUnidadMedidaListado_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Listado de unidades de medida";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 301;
                ClaseDeConexion = new Negocio.UnidadesMedida(Funciones.AñoDeOperacion, Funciones.Ambiente);
                FormularioInformacion = new frmUnidadMedidaInformacion();


                AccesosPermitidos = "12345";
                //MostrarBotonEliminar = false;
                MostrarBotonImprimir = false;
                MostrarRegistros = "500";
                // Consultas        
                SelectSQL = "CODIGO_UNIDAD_MEDIDA, NOMBRE_UNIDAD_MEDIDA, CASE ESTADO_MEDIDA WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS ESTADO";
                From = "unidades_medida";
                Where = "";
                OrderBy = "CODIGO_UNIDAD_MEDIDA";

                AgregarColumna("Código", "CODIGO_UNIDAD_MEDIDA", 10, true, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Unidad de medida", "NOMBRE_UNIDAD_MEDIDA", 80, true, DataGridViewContentAlignment.MiddleLeft, false);
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
