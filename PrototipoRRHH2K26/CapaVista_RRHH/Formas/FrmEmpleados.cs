using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador_RRHH;
using CapaModelo_RRHH.Entidades;
using CapaVista_RRHH.Ayudas;
using CapaVista_RRHH.Reportes;

namespace CapaVista_RRHH.Formas
{
    public partial class FrmEmpleados : Form
    {
        private ModeloEmpleado empleado = new ModeloEmpleado();

        public FrmEmpleados()
        {
            InitializeComponent();
            panIngresoDatos.Enabled = false;
        }
        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            ListaEmpleados();

        }
        private void ListaEmpleados()
        {
            try
            {
                dgvEmpleados.DataSource = empleado.GetAll();

            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = empleado.FindById(txtBuscar.Text);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = empleado.FindById(txtBuscar.Text);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            empleado.IdEmpleado = Convert.ToInt32(txtIdEmpleado.Text);
            empleado.NombresEmpleado = txtNombres.Text;
            empleado.ApellidosEmpleado = txtApellidos.Text;
            empleado.TelefonoEmpleado = txtTelefono.Text;
            empleado.CorreoEmpleado = txtCorreo.Text;
            empleado.PuestoEmpleado = txtPuesto.Text;
            empleado.EstadoEmpleado = chkEstado.Checked;

            bool valido = new Ayudas.ValidacionDatos(empleado).Validar();

            if (valido == true)
            {
                string resultado = empleado.GrabarCambios();

                MessageBox.Show(resultado);

                ListaEmpleados();

                Reinicio();
            }
        }

        private void Reinicio()
        {
            panIngresoDatos.Enabled = false;
            txtIdEmpleado.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtPuesto.Clear();
            chkEstado.Checked = true;
            txtBuscar.Clear();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            panIngresoDatos.Enabled = true;

            empleado.Estado = EstadoEntidad.Added;
            txtIdEmpleado.Clear();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {

                panIngresoDatos.Enabled = true;

                empleado.Estado = EstadoEntidad.Modified;
                empleado.IdEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells[0].Value.ToString());
                txtNombres.Text = dgvEmpleados.CurrentRow.Cells[1].Value.ToString();
                txtApellidos.Text = dgvEmpleados.CurrentRow.Cells[2].Value.ToString();
                txtTelefono.Text = dgvEmpleados.CurrentRow.Cells[3].Value.ToString();
                txtCorreo.Text = dgvEmpleados.CurrentRow.Cells[4].Value.ToString();
                txtPuesto.Text = dgvEmpleados.CurrentRow.Cells[5].Value.ToString();
                chkEstado.Checked = Convert.ToBoolean(dgvEmpleados.CurrentRow.Cells[6].Value.ToString());
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                empleado.Estado = EstadoEntidad.Deleted;

                empleado.IdEmpleado = Convert.ToInt32(
                    dgvEmpleados.CurrentRow.Cells[0].Value);

                string resultado = empleado.GrabarCambios();

                MessageBox.Show(resultado);

                ListaEmpleados();

            }
            else MessageBox.Show("Seleccione una fila");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmEmpleadosReporte reporte = new FrmEmpleadosReporte();
            reporte.ShowDialog();
        }
    } 
}