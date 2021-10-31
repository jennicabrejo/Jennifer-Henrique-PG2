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
using TALLERM.Support;

namespace TALLERM.View
{
    public partial class MGestionUsuarios_modal : Form
    {
        private GestionUsuariosController controller;
        private int _id;

        public MGestionUsuarios_modal(int ID, GestionUsuariosController CONTROL)
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
        private void LoadComboTiposUsuarios()
        {

            IList<ComboboxItem> combo_tipos = new List<ComboboxItem>();

            ComboboxItem item = new ComboboxItem();
            item.texto_mostrar = "OPERADOR";
            item.valor = "OPERADOR";
            combo_tipos.Add(item);

            ComboboxItem item2 = new ComboboxItem();
            item2.texto_mostrar = "ADMIN";
            item2.valor = "ADMIN";
            combo_tipos.Add(item2);

            comboBox2.DataSource = combo_tipos;
            comboBox2.DisplayMember = "texto_mostrar";
            comboBox2.ValueMember = "valor";
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


        private void MGestionUsuarios_modal_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadComboTiposUsuarios();

            textBoxPASS.UseSystemPasswordChar = true;
            textBoxPASS2.UseSystemPasswordChar = true;

            if (_id < 0)
            {
                this.Text = "Agregar nuevo registro";
                button2.Text = "AGREGAR";

                textBoxNOMBRES.Text = "";
                comboBox2.Text = "";
                textBoxPASS.Text = "";
                textBoxPASS2.Text = "";

                textBoxNOMBRES.Focus();
                textBoxNOMBRES.Select();
            }
            else
            {
                this.Text = "Actualizar registro";
                button2.Text = "ACTUALIZAR";

                var datos = controller.getData(_id);

                textBoxNOMBRES.Text = datos.NOMBRE_USUARIO;
                comboBox2.Text = datos.TIPO_USUARIO;
                textBoxPASS2.Text = Security.Base64Decode(datos.CONTRASENIA);
                textBoxPASS.Text = textBoxPASS2.Text;
                comboBox1.Text = (datos.ESTADO == 1) ? "Activo" : "Inactivo";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxNOMBRES.Text) && !string.IsNullOrEmpty(textBoxPASS2.ToString()))
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
                if (!string.IsNullOrEmpty(textBoxNOMBRES.Text) && !string.IsNullOrEmpty(textBoxPASS2.ToString()))
                {
                    USUARIOS model = new USUARIOS();

                    model.ID_USUARIO = 0;
                    model.NOMBRE_USUARIO = textBoxNOMBRES.Text;
                    model.TIPO_USUARIO = comboBox2.SelectedValue.ToString();
                    model.CONTRASENIA = Security.Base64Encode(textBoxPASS2.Text);
                    model.ESTADO = decimal.Parse(comboBox1.SelectedValue.ToString());

                    if(textBoxPASS.Text.Equals(textBoxPASS2.Text))
                    {

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
                    else
                    {
                        MessageBox.Show("Las contraseñas ingresadas con coinciden.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (!string.IsNullOrEmpty(textBoxNOMBRES.Text) && !string.IsNullOrEmpty(textBoxPASS2.ToString()))
                {
                    USUARIOS model = new USUARIOS();

                    model.ID_USUARIO = _id;
                    model.NOMBRE_USUARIO = textBoxNOMBRES.Text;
                    model.TIPO_USUARIO = comboBox2.SelectedValue.ToString();
                    model.CONTRASENIA = Security.Base64Encode(textBoxPASS2.Text);
                    model.ESTADO = decimal.Parse(comboBox1.SelectedValue.ToString());

                    if (textBoxPASS.Text.Equals(textBoxPASS2.Text))
                    {

                        if (controller.UpdateData(model))
                        {
                            MessageBox.Show("Registro ingresado con éxito ✓", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error encontrado al intentar procesar solicitud. ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas ingresadas con coinciden.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxPASS.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxPASS.UseSystemPasswordChar = true;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxPASS2.UseSystemPasswordChar = false;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxPASS2.UseSystemPasswordChar = true;
        }
    }
}
