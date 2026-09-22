using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaControlador_RRHH;
using System.Windows.Forms;

namespace CapaVista_RRHH.Reportes
{
    public partial class FrmEmpleadosReporte : Form
    {
        private ModeloEmpleado empleado = new ModeloEmpleado();
        public FrmEmpleadosReporte()
        {
            InitializeComponent();
        }

        private void FrmEmpleadosReporte_Load(object sender, EventArgs e)
        {
            ReportDataSource reporDataSource = new ReportDataSource("DataSet1", empleado.GetAll());
            reportViewer1.LocalReport.ReportEmbeddedResource = "CapaVista_RRHH.Reportes.ReporteEmpleados.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reporDataSource);

            this.reportViewer1.RefreshReport();
        }
    }
}
