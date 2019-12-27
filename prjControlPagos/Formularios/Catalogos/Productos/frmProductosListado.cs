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
    public partial class frmProductosListado : Conexion.frmPlantillaListado
    {
        public frmProductosListado()
        {
            InitializeComponent();
        }

        private void frmProductosListado_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Listado de productos";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 301;
                ClaseDeConexion = new Negocio.UnidadesMedida(Funciones.AñoDeOperacion, Funciones.Ambiente);
                FormularioInformacion = new frmProductosInformacion();


                AccesosPermitidos = "12345";
                //MostrarBotonEliminar = false;
                MostrarBotonImprimir = false;
                MostrarRegistros = "500";
                // Consultas        
                SelectSQL = "CODIGO_PRODUCTO, NOMBRE_PRODUCTO, CASE TIPO_PRODUCTO WHEN 1 THEN 'Producto' WHEN 2 THEN 'Servicio' END AS TIPO_PRODUCTO, CASE ESTADO_PRODUCTO WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS ESTADO";
                From = "productos";
                Where = "";
                OrderBy = "CODIGO_PRODUCTO";

                AgregarColumna("Código", "CODIGO_PRODUCTO", 10, true, DataGridViewContentAlignment.MiddleRight, true);
                AgregarColumna("Producto", "NOMBRE_PRODUCTO", 60, true, DataGridViewContentAlignment.MiddleLeft, false);
                AgregarColumna("Tipo", "TIPO_PRODUCTO", 20, true, DataGridViewContentAlignment.MiddleLeft, false);
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
