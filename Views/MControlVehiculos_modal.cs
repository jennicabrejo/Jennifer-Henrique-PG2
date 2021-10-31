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
using TALLERM.Models.DB;

namespace TALLERM.View
{
    public partial class MControlVehiculos_modal : Form
    {
        private ControlVehiculosController controller;
        private int _id;

        public MControlVehiculos_modal(int ID, ControlVehiculosController CONTROL)
        {
            this.controller = CONTROL;
            this._id = ID;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLINEA.Text) && !string.IsNullOrEmpty(textBoxPLACA.Text)
            && !string.IsNullOrEmpty(textBoxMARCA.Text) && !string.IsNullOrEmpty(textBoxMODELO.Text)
            && !string.IsNullOrEmpty(dateTimePicker1.ToString()))
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

        private void MControlVehiculos_modal_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadComboTipos();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd - MMM - yyyy";

            if (_id < 0)
            {
                this.Text = "Agregar nuevo registro";
                button2.Text = "AGREGAR";

                textBoxPLACA.Text = "";
                textBoxMARCA.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                textBoxLINEA.Text = "";
                textBoxMODELO.Text = "";

                textBoxPLACA.Focus();
                textBoxPLACA.Select();
            }
            else
            {
                this.Text = "Actualizar registro";
                button2.Text = "ACTUALIZAR";

                var datos = controller.getData(_id);

                textBoxPLACA.Text = datos.PLACA;
                textBoxMARCA.Text = datos.MARCA;
                dateTimePicker1.Value = datos.FECHA_INGRESO;
                textBoxLINEA.Text = datos.LINEA;
                textBoxMODELO.Text = datos.MODELO.ToString();
                comboBox1.Text = (datos.ESTADO == 1) ? "Activo" : "Inactivo";
                var result = controller.getDataCombo(datos.ID_TIPO_VEHICULO);
                comboBox2.Text = result.NOMBRE_TIPO;

            }
        }

        private class ComboboxItem
        {
            public string texto_mostrar { get; set; }
            public object valor { get; set; }
        }

        private void LoadComboTipos()
        {
            comboBox2.DataSource = controller.getDataListCombo();

            comboBox2.DisplayMember = "NOMBRE_TIPO";
            comboBox2.ValueMember = "ID_TIPO_VEHICULO";
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

        private void Agregar()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxLINEA.Text) && !string.IsNullOrEmpty(textBoxPLACA.Text)
                && !string.IsNullOrEmpty(textBoxMARCA.Text) && !string.IsNullOrEmpty(textBoxMODELO.Text)
                && !string.IsNullOrEmpty(dateTimePicker1.ToString()))
                {
                    VEHICULOS model = new VEHICULOS();

                    model.ID_VEHICULO = 0;
                    model.ID_TIPO_VEHICULO = (decimal)comboBox2.SelectedValue;
                    model.PLACA = textBoxPLACA.Text;
                    model.MARCA = textBoxMARCA.Text;
                    model.LINEA = textBoxLINEA.Text;
                    model.MODELO = decimal.Parse(textBoxMODELO.Text);
                    model.FECHA_INGRESO = dateTimePicker1.Value.Date;
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
                if (!string.IsNullOrEmpty(textBoxLINEA.Text) && !string.IsNullOrEmpty(textBoxPLACA.Text)
                && !string.IsNullOrEmpty(textBoxMARCA.Text) && !string.IsNullOrEmpty(textBoxMODELO.Text)
                && !string.IsNullOrEmpty(dateTimePicker1.ToString()))
                {
                    VEHICULOS model = new VEHICULOS();

                    model.ID_VEHICULO = _id;
                    model.ID_TIPO_VEHICULO= (decimal)comboBox2.SelectedValue;
                    model.PLACA = textBoxPLACA.Text;
                    model.FECHA_INGRESO = dateTimePicker1.Value.Date;
                    model.LINEA = textBoxLINEA.Text;
                    model.MODELO = decimal.Parse(textBoxMODELO.Text);
                    model.MARCA = textBoxMARCA.Text;
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
