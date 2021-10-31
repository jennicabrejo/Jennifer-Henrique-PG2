using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TALLERM.Controllers;
using TALLERM.Support;

namespace TALLERM.View
{
    public partial class MReportes : Form
    {
        // The DataGridView Control which will be printed.
        DataGridView MyDataGridView;
        // The PrintDocument to be used for printing.
        PrintDocument MyPrintDocument;
        // The class that will do the printing process.
        DataGridViewPrinter MyDataGridViewPrinter;

        int _type;
        public MReportes(int type)
        {
            this._type = type;
            InitializeComponent();
        }

        private void buttonBUSCAR_Click(object sender, EventArgs e)
        {
            
            ActualizarDWRxMantenimiento(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Principal p = new Principal();
            p.Show();
            this.Hide();
        }

        private bool SetupThePrintingPreview()
        {
            try
            {

                PrintDialog MyPrintDialog = new PrintDialog();
                MyPrintDialog.AllowCurrentPage = false;
                MyPrintDialog.AllowPrintToFile = false;
                MyPrintDialog.AllowSelection = false;
                MyPrintDialog.AllowSomePages = false;
                MyPrintDialog.PrintToFile = false;
                MyPrintDialog.ShowHelp = false;
                MyPrintDialog.ShowNetwork = false;

                MyPrintDocument.DocumentName = "Reporte de Facturas";
                MyPrintDocument.PrinterSettings =
                                    MyPrintDialog.PrinterSettings;
                MyPrintDocument.DefaultPageSettings =
                MyPrintDialog.PrinterSettings.DefaultPageSettings;
                MyPrintDocument.DefaultPageSettings.Margins =
                                 new Margins(5, 5, 40, 40);

                if (_type == 1)
                {
                    MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView,
                    MyPrintDocument, true, true, "REPORTE GENERAL DE MANTENIMIENTOS", "Del " + dateTimePicker1.Value.ToString("dd/MM/yyyy") + " al " + dateTimePicker2.Value.ToString("dd/MM/yyyy"), "", new Font("Tahoma", 16,
                    FontStyle.Bold, GraphicsUnit.Point), new Font("Tahoma", 12,
                    FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
                }
                else if (_type == 2)
                {
                    MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView,
                    MyPrintDocument, true, true, "REPORTE GENERAL DE ENCARGADOS", "", "", new Font("Tahoma", 16,
                    FontStyle.Bold, GraphicsUnit.Point), new Font("Tahoma", 12,
                    FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
                }
                else if (_type == 3)
                {
                    MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView,
                    MyPrintDocument, true, true, "REPORTE GENERAL DE PROVEEDORES", "", "", new Font("Tahoma", 16,
                    FontStyle.Bold, GraphicsUnit.Point), new Font("Tahoma", 12,
                    FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
                }
                else if (_type == 4)
                {
                    MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView,
                    MyPrintDocument, true, true, "REPORTE GENERAL DE VEHICULOS", "", "", new Font("Tahoma", 16,
                    FontStyle.Bold, GraphicsUnit.Point), new Font("Tahoma", 12,
                    FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
                }
                else if (_type == 5)
                {
                    MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView,
                    MyPrintDocument, true, true, "REPORTE GENERAL DE REPUESTOS", "", "", new Font("Tahoma", 16,
                    FontStyle.Bold, GraphicsUnit.Point), new Font("Tahoma", 12,
                    FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
                }


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }



        }

        private void buttonPRINT_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetupThePrintingPreview())
                {
                    PrintPreviewDialog ppd = new PrintPreviewDialog();
                    ((Form)ppd).Text = "Previsualización de impresión";
                    ((ToolStrip)(ppd.Controls[1])).Items.RemoveAt(0);
                    ((ToolStrip)(ppd.Controls[1])).Items.RemoveAt(8);

                    ppd.Document = MyPrintDocument;
                    ppd.WindowState = FormWindowState.Maximized;
                    ppd.StartPosition = FormStartPosition.CenterScreen;
                    ppd.ClientSize = new Size(800, 800);
                    ppd.UseAntiAlias = true;
                    ppd.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool SetupThePrinting()
        {
            try
            {
                PrintDialog MyPrintDialog = new PrintDialog();
                MyPrintDialog.AllowCurrentPage = false;
                MyPrintDialog.AllowPrintToFile = false;
                MyPrintDialog.AllowSelection = false;
                MyPrintDialog.AllowSomePages = false;
                MyPrintDialog.PrintToFile = false;
                MyPrintDialog.ShowHelp = false;
                MyPrintDialog.ShowNetwork = false;

                if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                    return false;

                MyPrintDocument.DocumentName = "Reporte de Facturas";
                MyPrintDocument.PrinterSettings =
                                    MyPrintDialog.PrinterSettings;
                MyPrintDocument.DefaultPageSettings =
                MyPrintDialog.PrinterSettings.DefaultPageSettings;
                MyPrintDocument.DefaultPageSettings.Margins =
                                 new Margins(20, 20, 40, 40);

                if (_type == 1)
                {
                    MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView,
                    MyPrintDocument, true, true, "REPORTE GENERAL DE MANTENIMIENTOS", "Del " + dateTimePicker1.Value.ToString("dd/MM/yyyy") + " al " + dateTimePicker2.Value.ToString("dd/MM/yyyy"), "", new Font("Tahoma", 16,
                    FontStyle.Bold, GraphicsUnit.Point), new Font("Tahoma", 12,
                    FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
                }
                else if (_type == 2)
                {
                    MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView,
                    MyPrintDocument, true, true, "REPORTE GENERAL DE ENCARGADOS", "", "", new Font("Tahoma", 16,
                    FontStyle.Bold, GraphicsUnit.Point), new Font("Tahoma", 12,
                    FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

                }
                else if (_type == 3)
                {
                    MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView,
                    MyPrintDocument, true, true, "REPORTE GENERAL DE PROVEEDORES", "", "", new Font("Tahoma", 16,
                    FontStyle.Bold, GraphicsUnit.Point), new Font("Tahoma", 12,
                    FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
                }
                else if (_type == 4)
                {
                    MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView,
                    MyPrintDocument, true, true, "REPORTE GENERAL DE VEHICULOS", "", "", new Font("Tahoma", 16,
                    FontStyle.Bold, GraphicsUnit.Point), new Font("Tahoma", 12,
                    FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
                }
                else if (_type == 5)
                {
                    MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView,
                    MyPrintDocument, true, true, "REPORTE GENERAL DE REPUESTOS", "", "", new Font("Tahoma", 16,
                    FontStyle.Bold, GraphicsUnit.Point), new Font("Tahoma", 12,
                    FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetupThePrinting())
                    MyPrintDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MReportes_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd - MMM - yyyy";

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd - MMM - yyyy";

            dateTimePicker1.Value = DateTime.Now.AddDays(-30);
            dateTimePicker2.Value = DateTime.Now.AddDays(1);

            MyDataGridView = dataGridView1;
            MyPrintDocument = printDocument1;

            if (_type == 1) //MANTENIMIENTOS
            {
                dataGridView1.Width = 1001;
                dataGridView1.Height = 327;

                this.Width = 1041;
                this.Height = 496;
                buttonBUSCAR.Visible = true;
                textBox1.Visible = true;
                textBox3.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;

                ActualizarDWRxMantenimiento(dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else if (_type == 2) //ENCARGADOS
            {
                dataGridView1.Width = 700;
                dataGridView1.Height = 327;

                this.Width = 740;
                this.Height = 496;
                buttonBUSCAR.Visible = false;
                textBox1.Visible = false;
                textBox3.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

                ActualizarDWRxEncargados();
               
            }
            else if (_type == 3) //PROVEEDORES
            {
                dataGridView1.Width = 800;
                dataGridView1.Height = 327;

                this.Width = 840;
                this.Height = 496;
                buttonBUSCAR.Visible = false;
                textBox1.Visible = false;
                textBox3.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

                ActualizarDWRxProveedores();

            }
            else if (_type == 4) //VEHICULOS
            {
                dataGridView1.Width = 750;
                dataGridView1.Height = 327;

                this.Width = 790;
                this.Height = 496;
                buttonBUSCAR.Visible = false;
                textBox1.Visible = false;
                textBox3.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

                ActualizarDWRxVehiculos();

            }
            else if (_type == 5) //REPUESTOS
            {
                dataGridView1.Width = 600;
                dataGridView1.Height = 327;

                this.Width = 640;
                this.Height = 496;
                buttonBUSCAR.Visible = false;
                textBox1.Visible = false;
                textBox3.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

                ActualizarDWRxRepuestos();

            }

        }
        private void ActualizarDWRxMantenimiento(DateTime dateini, DateTime datend)
        {
            try
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                ControlMantenimientosController controller = new ControlMantenimientosController();
                dataGridView1.DataSource = controller.getDataListREPORTE(dateini, datend);

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarDWRxEncargados()
        {
            try
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                GestionEncargadosController controller = new GestionEncargadosController();
                dataGridView1.DataSource = controller.getDataList();

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarDWRxProveedores()
        {
            try
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                GestionProveedoresController controller = new GestionProveedoresController();
                dataGridView1.DataSource = controller.getDataList();

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarDWRxVehiculos()
        {
            try
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                ControlVehiculosController controller = new ControlVehiculosController();
                dataGridView1.DataSource = controller.getDataList();

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ActualizarDWRxRepuestos()
        {
            try
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                CatalogoRepuestosController controller = new CatalogoRepuestosController();
                dataGridView1.DataSource = controller.getDataList();

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }
    }
}
