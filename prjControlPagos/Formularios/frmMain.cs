using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlPagos
{    
    public partial class frmMain : Form
    {
        private string _Mensaje  = "";        
        //Negocio.Seguridad _Seguridad = new Negocio.Seguridad(Funciones.AñoDeOperacion, Funciones.Ambiente);

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Desea salir del sistema de " + Funciones.NombreDelSistema + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                // Bitacora de Ingrseo -41-
                // Operar_Bitacora(_Usuario.NumeroEmpleado, _IDAplicacion & "-S", ProductVersion.ToString, "", _AñoDeOperacion, _Ambiente)
            }
            else { 
                e.Cancel = true;
            }               
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void mnuCorporaciones_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.frmCorporacionListado _Corporacion = new Formularios.Catalogos.frmCorporacionListado();
            _Corporacion.MdiParent = this;
            _Corporacion.Show();
        }

        private void mnuPais_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Lugares.frmPaisListado _Paises = new Formularios.Catalogos.Lugares.frmPaisListado();
            _Paises.MdiParent = this;
            _Paises.Show();
        }

        private void mnuDepartamento_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Lugares.frmDepartamentoListado _Departamentos = new Formularios.Catalogos.Lugares.frmDepartamentoListado();
            _Departamentos.MdiParent = this;
            _Departamentos.Show();
        }

        private void municipioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Lugares.frmMunicipioListado _Municipios = new Formularios.Catalogos.Lugares.frmMunicipioListado();
            _Municipios.MdiParent = this;
            _Municipios.Show();
        }

        private void mnuTratamientos_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Clientes.frmTratamientoListado _Tratamientos = new Formularios.Catalogos.Clientes.frmTratamientoListado();
            _Tratamientos.MdiParent = this;
            _Tratamientos.Show();
        }

        private void mnuContactos_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.frmContactoListado _Contacto = new Formularios.Catalogos.frmContactoListado();
            _Contacto.MdiParent = this;
            _Contacto.Show();
        }

        private void mnuEmpresas_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.frmEmpresaListado _Empresa = new Formularios.Catalogos.frmEmpresaListado();
            _Empresa.MdiParent = this;
            _Empresa.Show();
        }

        private void mnuUnidadesMedida_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Productos.frmUnidadMedidaListado _Unidades = new Formularios.Catalogos.Productos.frmUnidadMedidaListado();
            _Unidades.MdiParent = this;
            _Unidades.Show();
        }

        private void mnuProductosDetalle_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Productos.frmProductosListado _Productos = new Formularios.Catalogos.Productos.frmProductosListado();
            _Productos.MdiParent = this;
            _Productos.Show();
        }
    }
}
