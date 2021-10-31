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
    public partial class MCatalogoRepuestos_modal : Form
    {
        private CatalogoRepuestosController controller;
        private int _id;

        public MCatalogoRepuestos_modal(int ID, CatalogoRepuestosController CONTROL)
        {
            this.controller = CONTROL;
            this._id = ID;
            InitializeComponent();
        }

        private void MCatalogoRepuestos_modal_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadComboProveedores();

            if (_id < 0)
            {
                this.Text = "Agregar nuevo registro";
                button2.Text = "AGREGAR";

                textBoxNOMBRE.Text = "";
                textBoxDESC.Text = "";
                numericUpDown1.Value = 0;

                textBoxNOMBRE.Focus();
                textBoxNOMBRE.Select();
            }
            else
            {
                this.Text = "Actualizar registro";
                button2.Text = "ACTUALIZAR";

                var datos = controller.getData(_id);

                textBoxNOMBRE.Text = datos.NOMBRE_REPUESTO;
                textBoxDESC.Text = datos.DESC_REPUESTO;
                numericUpDown1.Value = datos.PRECIO_REPUESTO;
                numericUpDown2.Value = datos.STOCK;
                comboBox1.Text = (datos.ESTADO == 1) ? "Activo" : "Inactivo";
                var result = controller.getDataCombo(datos.ID_PROVEEDOR);
                comboBox2.Text = result.NOMBRE_PROVEEDOR;

            }
        }

        private class ComboboxItem
        {
            public string texto_mostrar { get; set; }
            public object valor { get; set; }
        }

        private void LoadComboProveedores()
        {
            comboBox2.DataSource = controller.getDataListCombo();

            comboBox2.DisplayMember = "NOMBRE_PROVEEDOR";
            comboBox2.ValueMember = "ID_PROVEEDOR";
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
                if (!string.IsNullOrEmpty(textBoxNOMBRE.Text) && !string.IsNullOrEmpty(textBoxDESC.Text)
                && (numericUpDown1.Value != 0))
                {
                    REPUESTOS model = new REPUESTOS();

                    model.ID_REPUESTO = 0;
                    model.ID_PROVEEDOR = (decimal)comboBox2.SelectedValue;
                    model.NOMBRE_REPUESTO = textBoxNOMBRE.Text;
                    model.DESC_REPUESTO = textBoxDESC.Text;
                    model.PRECIO_REPUESTO = numericUpDown1.Value;
                    model.STOCK = numericUpDown2.Value;
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
                if (!string.IsNullOrEmpty(textBoxNOMBRE.Text) && !string.IsNullOrEmpty(textBoxDESC.Text)
                && (numericUpDown1.Value != 0))
                {
                    REPUESTOS model = new REPUESTOS();

                    model.ID_REPUESTO = _id;
                    model.ID_PROVEEDOR = (decimal)comboBox2.SelectedValue;
                    model.NOMBRE_REPUESTO = textBoxNOMBRE.Text;
                    model.DESC_REPUESTO = textBoxDESC.Text;
                    model.STOCK = numericUpDown2.Value;
                    model.PRECIO_REPUESTO = numericUpDown1.Value;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxNOMBRE.Text) && !string.IsNullOrEmpty(textBoxDESC.Text)
            && (numericUpDown1.Value != 0))
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
    }
}
