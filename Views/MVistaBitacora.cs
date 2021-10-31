using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TALLERM.Controllers;
using TALLERM.Support;

namespace TALLERM.View
{
    public partial class MVistaBitacora : Form
    {
        VistaBitacoraController controller = new VistaBitacoraController();
        public MVistaBitacora()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MCatalogoRepuestos_modal m = new MCatalogoRepuestos_modal();
            //m.ShowDialog();
        }

        private void MGestionUsuarios_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            dateTimePicker1.Value = DateTime.Today.AddDays(-30);
            dateTimePicker2.Value = DateTime.Today.AddDays(1);

            ActualizarDataGridV(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(1));
        }

        private void ActualizarDataGridV(DateTime dateini, DateTime datend)
        {
            try
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dataGridView1.DataSource = controller.getDataList(dateini, datend);

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("MVistaBitacora.Form-ActualizarDataGridV", ex.ToString());
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Principal p = new Principal();
            p.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void buttonBUSCAR_Click(object sender, EventArgs e)
        {
            ActualizarDataGridV(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int corr = int.Parse(dataGridView1.Rows[row.Index].Cells[0].Value.ToString());

                        MVistaBitacora_modal fact = new MVistaBitacora_modal(corr, new VistaBitacoraController());
                        fact.ShowDialog();

                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila válida para ver el detalle.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //WarnToBinnacle.SaveToBinnacle("Error encontrado (dataGridView1_CellContentDoubleClick inside ListadoCierres), detalles: " + ex);
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
