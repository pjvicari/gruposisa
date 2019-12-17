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
        public string FiltroCliente = "";
        public frmClienteBusqueda()
        {
            InitializeComponent();
        }

        private void frmClienteBusqueda_Load(object sender, EventArgs e)
        {
            try
            {
                NombreDeFormulario = "Listado de clientes";
                SiglasDelSistema = Funciones.SiglasDelSistema;
                NumeroDeFormulario = 301;
                ClaseDeConexion = new Negocio.Corporacion(Funciones.AñoDeOperacion, Funciones.Ambiente);

                MostrarRegistros = "500";
                // Consultas        
                SelectSQL = "CODIGO_CLIENTE, TIPO_CLIENTE, NOMBRE_TIPO, NOMBRE_CLIENTE, ESTADO";
                From = "(SELECT CODIGO_CORPORACION AS CODIGO_CLIENTE, TIPO_CLIENTE, 'CORPORACION' AS NOMBRE_TIPO, NOMBRE_CORPORACION AS NOMBRE_CLIENTE, ESTADO_CORPORACION AS CODIGO_ESTADO, CASE ESTADO_CORPORACION WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS ESTADO FROM gruposisa.crm_corporaciones UNION ALL SELECT CODIGO_EMPRESA AS CODIGO_CLIENTE, TIPO_CLIENTE, 'EMPRESA' AS NOMBRE_TIPO, NOMBRE_EMPRESA AS NOMBRE_CLIENTE, ESTADO_EMPRESA AS CODIGO_ESTADO, CASE ESTADO_EMPRESA WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS ESTADO FROM gruposisa.CRM_EMPRESAS UNION ALL SELECT CODIGO_SUCURSAL AS CODIGO_CLIENTE, TIPO_CLIENTE, 'SUCURSAL' AS NOMBRE_TIPO, NOMBRE_SUCURSAL AS NOMBRE_CLIENTE, ESTADO_SUCURSAL AS CODIGO_ESTADO, CASE ESTADO_SUCURSAL WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS ESTADO FROM gruposisa.CRM_SUCURSALES UNION ALL SELECT CODIGO_CONTACTO AS CODIGO_CLIENTE, TIPO_CLIENTE, 'CONTACTO' AS NOMBRE_TIPO, NOMBRE_CONTACTO AS NOMBRE_CLIENTE, ESTADO_CONTACTO AS CODIGO_ESTADO, CASE ESTADO_CONTACTO WHEN 0 THEN 'Inactivo' WHEN 1 THEN 'Activo' END AS ESTADO FROM gruposisa.CRM_CONTACTOS) CLIENTES";
                Where = " AND CODIGO_ESTADO = 1";
                if(FiltroCliente != "")
                {
                    Where += " AND TIPO_CLIENTE NOT IN (" + FiltroCliente + ")";
                }
                OrderBy = "NOMBRE_TIPO ASC";

                AgregarColumna("Código", "CODIGO_CLIENTE", 15, false, DataGridViewContentAlignment.MiddleLeft, "");
                AgregarColumna("Código", "TIPO_CLIENTE", 0, false, DataGridViewContentAlignment.MiddleLeft, "");
                AgregarColumna("Tipo de cliente", "NOMBRE_TIPO", 20, true, DataGridViewContentAlignment.MiddleLeft, "");
                AgregarColumna("Nombre", "NOMBRE_CLIENTE", 45, true, DataGridViewContentAlignment.MiddleLeft, "");
                AgregarColumna("Estado", "ESTADO", 20, true, DataGridViewContentAlignment.MiddleLeft, "");
                
                InicializarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
