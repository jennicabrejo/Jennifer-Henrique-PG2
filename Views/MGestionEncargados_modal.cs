using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TALLERM.Controllers;
using TALLERM.Models.DB;

namespace TALLERM.View
{
    public partial class MGestionConductores_modal : Form
    {
        private GestionEncargadosController controller;
        private int _id;
        public MGestionConductores_modal(int ID, GestionEncargadosController CONTROL)
        {
            this.controller = CONTROL;
            this._id = ID;
            InitializeComponent();
        }

        private class ComboboxItem
        {
            public string texto_mostrar { get; set; }
            public object valor { get; set; }
        }
        private void LoadCombo()
        {

            IList<ComboboxItem> combo_tipos = new List<ComboboxItem>();

            ComboboxItem item = new ComboboxItem();
            item.texto_mostrar = "Activo";
            item.valor = 1;
            combo_tipos.Add(item);

            ComboboxItem item2 = new ComboboxItem();
            item2.texto_mostrar = "Inactivo";
            item2.valor = 0;
            combo_tipos.Add(item2);

            comboBox1.DataSource = combo_tipos;
            comboBox1.DisplayMember = "texto_mostrar";
            comboBox1.ValueMember = "valor";
        }


        private void MGestionConductores_modal_Load(object sender, EventArgs e)
        {
            LoadCombo();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd - MMM - yyyy";

            if (_id < 0)
            {
                this.Text = "Agregar nuevo registro";
                button2.Text = "AGREGAR";

                textBoxNOMBRES.Text = "";
                textBoxAPELLIDOS.Text = "";
                dateTimePicker1.Value = DateTime.Now; 
                textBoxTEL.Text = "";
                textBoxCORREO.Text = "";

                textBoxNOMBRES.Focus();
                textBoxNOMBRES.Select();
            }
            else
            {
                this.Text = "Actualizar registro";
                button2.Text = "ACTUALIZAR";

                var datos = controller.getData(_id);

                textBoxNOMBRES.Text = datos.NOMBRES_ENCARGADO;
                textBoxAPELLIDOS.Text = datos.APELLIDOS_ENCARGADO;
                dateTimePicker1.Value = datos.FECHA_NACIMIENTO;
                textBoxTEL.Text = datos.TELEFONO;
                textBoxCORREO.Text = datos.CORREO;
                comboBox1.Text = (datos.ESTADO == 1) ? "Activo" : "Inactivo";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxNOMBRES.Text) && !string.IsNullOrEmpty(textBoxAPELLIDOS.Text)
            && !string.IsNullOrEmpty(dateTimePicker1.ToString()) && !string.IsNullOrEmpty(textBoxTEL.Text) 
            && !string.IsNullOrEmpty(textBoxCORREO.Text))
            {
                if (_id < 0)
                {
                    Agregar();
                }
                else
                {
                    Actualizar();
                }
            }
        }

        private void Agregar()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxNOMBRES.Text) && !string.IsNullOrEmpty(textBoxAPELLIDOS.Text)
                && !string.IsNullOrEmpty(dateTimePicker1.ToString()) && !string.IsNullOrEmpty(textBoxTEL.Text)
                && !string.IsNullOrEmpty(textBoxCORREO.Text))
                {
                    ENCARGADOS model = new ENCARGADOS();

                    model.ID_ENCARGADO = 0;
                    model.NOMBRES_ENCARGADO = textBoxNOMBRES.Text;
                    model.APELLIDOS_ENCARGADO = textBoxAPELLIDOS.Text;
                    model.FECHA_NACIMIENTO = dateTimePicker1.Value.Date;
                    model.TELEFONO = textBoxTEL.Text;
                    model.CORREO = textBoxCORREO.Text;
                    model.ESTADO = decimal.Parse(comboBox1.SelectedValue.ToString());

                    if (controller.AddData(model))
                    {
                        MessageBox.Show("Registro ingresado con éxito ✓", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error encontrado al intentar procesar solicitud. ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontró un error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Actualizar()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxNOMBRES.Text) && !string.IsNullOrEmpty(textBoxAPELLIDOS.Text)
                && !string.IsNullOrEmpty(dateTimePicker1.ToString()) && !string.IsNullOrEmpty(textBoxTEL.Text)
                && !string.IsNullOrEmpty(textBoxCORREO.Text))
                {
                    ENCARGADOS model = new ENCARGADOS();

                    model.ID_ENCARGADO = _id;
                    model.NOMBRES_ENCARGADO = textBoxNOMBRES.Text;
                    model.APELLIDOS_ENCARGADO = textBoxAPELLIDOS.Text;
                    model.FECHA_NACIMIENTO = dateTimePicker1.Value.Date;
                    model.TELEFONO = textBoxTEL.Text;
                    model.CORREO = textBoxCORREO.Text;
                    model.ESTADO = decimal.Parse(comboBox1.SelectedValue.ToString());

                    if (controller.UpdateData(model))
                    {
                        MessageBox.Show("Registro actualizado con éxito ✓", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error encontrado al intentar procesar solicitud. ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Uno o varios campos están vacíos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontró un error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
