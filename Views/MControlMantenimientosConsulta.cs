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
using TALLERM.Models.DB;
using TALLERM.Support;
using TALLERM.View;

namespace TALLERM
{
    public partial class MControlMantenimientosConsulta : Form
    {
        ControlMantenimientosController controller = new ControlMantenimientosController();
        ControlRepuestosXMantenimientosController ctrl = new ControlRepuestosXMantenimientosController();
        public MControlMantenimientosConsulta()
        {
            InitializeComponent();
        }

        private class ComboboxItem
        {
            public string texto_mostrar { get; set; }
            public object valor { get; set; }
        }

        //private void LoadComboEncargados()
        //{
        //    comboBox2.DataSource = controller.getDataListComboEncargados();

        //    comboBox2.DisplayMember = "NOMBRES_ENCARGADO";
        //    comboBox2.ValueMember = "ID_ENCARGADO";

        //}

        //private void LoadComboVehiculos()
        //{
        //    comboBox1.DataSource = controller.getDataListComboVehiculos();

        //    comboBox1.DisplayMember = "DATOS_VEHICULO";
        //    comboBox1.ValueMember = "ID_VEHICULO";

        //}


        private void ActualizarDataGridV(DateTime dateini, DateTime datened)
        {
            try
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dataGridView1.DataSource = controller.getDataList(dateini, datened);

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarDataGridV2()
        {
            try
            {
                dataGridView2.AutoResizeColumns();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dataGridView2.DataSource = ctrl.getDataListDiff(decimal.Parse(textBoxID.Text));

                foreach (DataGridViewColumn col in dataGridView2.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "dd - MMM - yyyy";

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd - MMM - yyyy";

            dateTimePicker3.Value = DateTime.Now.AddDays(-30);
            dateTimePicker1.Value = DateTime.Now.AddDays(1);

            ActualizarDataGridV(dateTimePicker3.Value, dateTimePicker1.Value);

            //LoadComboEncargados();
            //LoadComboVehiculos();

            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            //textBoxKMACTUAL.Focus();
            //textBoxKMACTUAL.Select();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
            button5.Text = "GRABAR";

            //ResetValues();
            ActualizarDataGridV();
        }

        //private void ResetValues()
        //{
        //    textBoxID.Text = controller.getNextID().ToString();

        //    textBoxKMACTUAL.TextChanged -= textBox3_TextChanged;
        //    textBoxKMACTUAL.Clear();
        //    textBoxKMACTUAL.TextChanged += textBox3_TextChanged;

        //    textBoxPKM.Clear();
        //    textBoxCOMENTARIOS.Clear();
        //    textBoxFALLAS.Clear();
        //    textBoxSFALLAS.Clear();

        //    textBoxKMACTUAL.Focus();
        //    textBoxKMACTUAL.Select();
        //}

        private void ActualizarDataGridV()
        {
            try
            {
                dataGridView2.AutoResizeColumns();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dataGridView2.DataSource = ctrl.getDataList(decimal.Parse(textBoxID.Text));

                foreach (DataGridViewColumn col in dataGridView2.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error encontrado: " + ex, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private bool Agregar()
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(textBoxKMACTUAL.Text) && !string.IsNullOrEmpty(textBoxPKM.Text)
        //        && !string.IsNullOrEmpty(textBoxCOMENTARIOS.Text) && !string.IsNullOrEmpty(textBoxFALLAS.ToString()) && !string.IsNullOrEmpty(textBoxSFALLAS.ToString()))
        //        {
        //            MANTENIMIENTOS model = new MANTENIMIENTOS();

        //            model.ID_MANTENIMIENTO = controller.getNextID();
        //            model.FECHA_HORA = DateTime.Now;
        //            model.ID_ENCARGADO = (decimal)comboBox2.SelectedValue;
        //            model.ID_VEHICULO = (decimal)comboBox1.SelectedValue;
        //            model.KM_ACTUAL = decimal.Parse(textBoxKMACTUAL.Text);
        //            model.COMENTARIOS = textBoxCOMENTARIOS.Text;
        //            model.PSERVICIO_KM = decimal.Parse(textBoxPKM.Text);
        //            DateTime PServ = DateTime.Parse(dateTimePicker2.Value.ToString());
        //            model.PSERVICIO_TIEMPO = PServ;
        //            model.DESC_FALLA = textBoxFALLAS.Text; 
        //            model.DESC_SOLUCION = textBoxSFALLAS.Text;

        //            return controller.AddData(model);

        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Se encontró un error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //}




        public static bool ConfirmacionCerrar()
        {
            const string message = "¿Está seguro de salir del control de mantenimientos?\n Tome en cuenta que si no guardó el mantenimiento actual se perderán los datos.";
            const string caption = "Confirmación";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
                Principal p = new Principal();
                p.Show();
                this.Hide();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

                textBoxPKM.Text = ((decimal.Parse(textBoxKMACTUAL.Text)) + 3000).ToString();
       
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBoxPKM.Text = ((decimal.Parse(textBoxKMACTUAL.Text)) + 3000).ToString();
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
        }

        void numericUpDown1_TextChanged(object sender, EventArgs e)
        {
            textBoxPKM.Text = ((decimal.Parse(textBoxKMACTUAL.Text)) + 3000).ToString();
        }

        private void textBoxKMACTUAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MRepuestosXMantenimiento_modal m = new MRepuestosXMantenimiento_modal(ctrl, textBoxID.Text);
            m.FormClosed += PFormClosed;
            m.ShowDialog();
        }

        private void PFormClosed(object sender, FormClosedEventArgs e)
        {
            ActualizarDataGridV();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(textBoxKMACTUAL.Text) && !string.IsNullOrEmpty(textBoxPKM.Text)   
            //&& !string.IsNullOrEmpty(textBoxCOMENTARIOS.Text) && !string.IsNullOrEmpty(textBoxFALLAS.ToString()) && !string.IsNullOrEmpty(textBoxSFALLAS.ToString()))
            //{

            //    if (button5.Text.Equals("GRABAR"))
            //    {
            //        if (Agregar())
            //        {
            //            MessageBox.Show("Registro ingresado con éxito ✓", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            //ResetValues();
            //            button1.Enabled = true;
            //            button3.Enabled = true;
            //            button4.Enabled = true;
            //            button5.Text = "ACTUALIZAR";
            //        }
            //        else
            //        {
            //            MessageBox.Show("Error encontrado al intentar procesar solicitud. ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    else
            //    {
            //        if (Actualizar())
            //        {
            //            MessageBox.Show("Registro actualizado con éxito ✓", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Error encontrado al intentar procesar solicitud. ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }

            //}
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

        private void button4_Click(object sender, EventArgs e)
        {
            //if (dataGridView2.RowCount > 0)
            //{
            //    if (dataGridView2.SelectedRows.Count > 0)
            //    {
            //        if (ConfirmacionEliminar() == true)
            //        {
            //            int selected = dataGridView2.CurrentRow.Index;
            //            int pid = int.Parse(dataGridView2.Rows[selected].Cells[0].Value.ToString());
            //            int pcantidad = int.Parse(dataGridView2.Rows[selected].Cells[2].Value.ToString());

            //            decimal getIDRep = ctrl.GetRepID(pid);
            //            ctrl.SumarStock(getIDRep, pcantidad);

            //            if (ctrl.DeleteData(pid))
            //            {
            //                ActualizarDataGridV();
            //                MessageBox.Show("Registro eliminado con éxito ✓", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            else
            //            {
            //                MessageBox.Show("Error encontrado al intentar procesar solicitud. ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }

            //        }
            //    }
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selected = dataGridView1.CurrentRow.Index;
                    int pid = int.Parse(dataGridView1.Rows[selected].Cells[0].Value.ToString());

                    LlenarForm(pid);
                    ActualizarDataGridV2();

                }
            }
        }

        private void buttonBUSCAR_Click(object sender, EventArgs e)
        {
            ActualizarDataGridV(dateTimePicker3.Value, dateTimePicker1.Value);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selected = dataGridView1.CurrentRow.Index;
                    int pid = int.Parse(dataGridView1.Rows[selected].Cells[0].Value.ToString());

                    LlenarForm(pid);

                }
            }
        }

        private void LlenarForm(int _id)
        {
            var result = controller.getData(_id);
            textBoxID.Text = result.ID_MANTENIMIENTO.ToString();
            textBoxFECHA.Text = result.FECHA_HORA.ToString();
            textBoxFECHAPSERVICIO.Text = result.PSERVICIO_TIEMPO.ToString();
            textBoxPKM.Text = result.PSERVICIO_KM.ToString();
            textBoxCOMENTARIOS.Text = result.COMENTARIOS;
            textBoxFALLAS.Text = result.DESC_FALLA;
            textBoxSFALLAS.Text = result.DESC_SOLUCION;
            textBoxKMACTUAL.Text = result.KM_ACTUAL.ToString();
            textBoxENCARGADO.Text = controller.getEncargadoNombre(result.ID_ENCARGADO);
            textBoxVEHICULO.Text = controller.getVehiculoNombre(result.ID_VEHICULO);

            LlenarFormDetalle(result.ID_MANTENIMIENTO);

        }

        private void LlenarFormDetalle(decimal _id)
        {


        }

        private void buttonPRINT_Click(object sender, EventArgs e)
        {

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;

            PrintDocument doc = new PrintDocument();

            doc.PrinterSettings.PrintFileName = "Mantenimiento_1";
            doc.DefaultPageSettings.Landscape = true;

            doc.OriginAtMargins = true;

            Margins margins = new Margins(2, 2, 2, 2);
            doc.DefaultPageSettings.Margins = margins;


            doc.PrintPage += this.Doc_PrintPage;

            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;
            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {

                doc.Print();
            }

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(this.groupBox1.Width, this.groupBox1.Height);
            this.groupBox1.DrawToBitmap(bmp, new Rectangle(0, 0, this.groupBox1.Width, this.groupBox1.Height));
            //e.Graphics.DrawImage((Image)bmp, x, y);
            //e.Graphics.DrawImage((Image)bmp, e.PageBounds);

            e.Graphics.DrawImage((Image)bmp,
                     (e.PageBounds.Width - bmp.Width) / 2,
                     (e.PageBounds.Height - bmp.Height) / 2,
                     bmp.Width,
                     bmp.Height);

        }
    }
}

