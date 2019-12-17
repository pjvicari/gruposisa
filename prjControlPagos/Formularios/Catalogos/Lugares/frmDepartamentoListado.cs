using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Conexion;

namespace ControlPagos.Formularios.Catalogos.Lugares
{
    public partial class frmDepartamentoListado : Conexion.frmPlantillaListado
    {
        public frmDepartamentoListado()
        {
            InitializeComponent();
        }

        private void frmDepartamentoListado_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Listado de departamentos";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 301;
                ClaseDeConexion = new Negocio.Corporacion(Funciones.AñoDeOperacion, Funciones.Ambiente);
                FormularioInformacion = new frmDepartamentoInformacion();


                AccesosPermitidos = "12345";
                //MostrarBotonEliminar = false;
                MostrarBotonImprimir = false;
                MostrarRegistros = "500";
                // Consultas        
                SelectSQL = "CODIGO_DEPARTAMENTO, DEP.CODIGO_PAIS, PAI.NOMBRE_PAIS, NOMBRE_DEPARTAMENTO, CASE ESTADO_DEPARTAMENTO WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS ESTADO";
                From = "DEPARTAMENTOS DEP INNER JOIN PAISES PAI ON DEP.CODIGO_PAIS = PAI.CODIGO_PAIS";
                Where = "";
                OrderBy = "DEP.CODIGO_PAIS, CODIGO_DEPARTAMENTO";

                AgregarColumna("Código", "CODIGO_DEPARTAMENTO", 10, true, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Pais", "CODIGO_PAIS", 0, true, DataGridViewContentAlignment.MiddleLeft, true);
                AgregarColumna("Pais", "NOMBRE_PAIS", 40, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("Departamento", "NOMBRE_DEPARTAMENTO", 40, true, DataGridViewContentAlignment.MiddleLeft, false);
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
