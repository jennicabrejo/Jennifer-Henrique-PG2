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
    public partial class MGestionProveedores : Form
    {
        GestionProveedoresController controller = new GestionProveedoresController();
        public MGestionProveedores()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MGestionProveedores_modal m = new MGestionProveedores_modal(-1, controller);
            m.FormClosed += PFormClosed;
            m.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Principal p = new Principal();
            p.Show();
            this.Hide();
        }

        private void MGestionProveedores_Load(object sender, EventArgs e)
        {
            ActualizarDataGridV();
        }

        private void PFormClosed(object sender, FormClosedEventArgs e)
        {
            ActualizarDataGridV();
        }

        public static bool ConfirmacionEliminar()
        {
            const string message = "Está seguro de eliminar el registro seleccionado?";
            const string caption = "Confirmación";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }
        private void ActualizarDataGridV()
        {
            try
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dataGridView1.DataSource = controller.getDataList();

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("MGestionProveedores.Form-ActualizarDataGridV", ex.ToString());
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selected = dataGridView1.CurrentRow.Index;
                    int pid = int.Parse(dataGridView1.Rows[selected].Cells[0].Value.ToString());

                    MGestionProveedores_modal ag_elemento = new MGestionProveedores_modal(pid, controller);
                    ag_elemento.FormClosed += PFormClosed;
                    ag_elemento.ShowDialog();

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if (ConfirmacionEliminar() == true)
                    {
                        int selected = dataGridView1.CurrentRow.Index;
                        int pid = int.Parse(dataGridView1.Rows[selected].Cells[0].Value.ToString());

                        if (controller.DeleteData(pid))
                        {
                            ActualizarDataGridV();
                            MessageBox.Show("Registro eliminado con éxito ✓", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error encontrado al intentar procesar solicitud. ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
        }
    }
}
