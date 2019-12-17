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
    public partial class frmMunicipioListado : Conexion.frmPlantillaListado
    {
        public frmMunicipioListado()
        {
            InitializeComponent();
        }

        private void frmMunicipioListado_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Listado de municipios";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 301;
                ClaseDeConexion = new Negocio.Corporacion(Funciones.AñoDeOperacion, Funciones.Ambiente);
                FormularioInformacion = new frmMunicipioInformacion();


                AccesosPermitidos = "12345";
                //MostrarBotonEliminar = false;
                MostrarBotonImprimir = false;
                MostrarRegistros = "500";
                // Consultas        
                SelectSQL = "CODIGO_MUNICIPIO, MUN.CODIGO_DEPARTAMENTO,PAI.NOMBRE_PAIS,DEP.NOMBRE_DEPARTAMENTO, NOMBRE_MUNICIPIO, MUN.CODIGO_PAIS, CASE ESTADO_MUNICIPIO WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS ESTADO";
                From = "MUNICIPIOS MUN INNER JOIN DEPARTAMENTOS DEP ON MUN.CODIGO_DEPARTAMENTO = DEP.CODIGO_DEPARTAMENTO INNER JOIN PAISES PAI ON MUN.CODIGO_PAIS = PAI.CODIGO_PAIS";
                Where = "";
                OrderBy = "MUN.CODIGO_PAIS, MUN.CODIGO_DEPARTAMENTO, MUN.CODIGO_MUNICIPIO";

                AgregarColumna("Código", "CODIGO_MUNICIPIO", 10, true, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Depto", "CODIGO_DEPARTAMENTO", 0, true, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Pais", "NOMBRE_PAIS", 27, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("Departamento", "NOMBRE_DEPARTAMENTO", 27, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("Municipio", "NOMBRE_MUNICIPIO", 27, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("CodPais", "CODIGO_PAIS", 0, true, DataGridViewContentAlignment.MiddleLeft, true);
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
