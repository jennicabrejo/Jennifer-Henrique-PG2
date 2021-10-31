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
    public partial class MRepuestosXMantenimiento_modal : Form
    {
        private ControlRepuestosXMantenimientosController controller;
        private decimal _ID;
        public MRepuestosXMantenimiento_modal(ControlRepuestosXMantenimientosController CONTROL, string ID)
        {
            this._ID = decimal.Parse(ID);
            this.controller = CONTROL;
            InitializeComponent();
        }

        private class ComboboxItem
        {
            public string texto_mostrar { get; set; }
            public object valor { get; set; }
        }



        private void Agregar()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxCANTIDAD.Text))
                {
                    decimal id_rep_sel = decimal.Parse(comboBox1.SelectedValue.ToString());
                    decimal id_rep = decimal.Parse(textBoxCANTIDAD.Text);
                    var data = controller.ValidarStock(id_rep_sel);

                    if (data >= id_rep)
                    {
                        REPUESTOS_X_MANTENIMIENTOS model = new REPUESTOS_X_MANTENIMIENTOS();

                        model.ID_REP_X_MANTE = 0;
                        model.ID_MANTENIMIENTO = _ID;
                        model.ID_REPUESTO = decimal.Parse(comboBox1.SelectedValue.ToString());
                        model.CANTIDAD = decimal.Parse(textBoxCANTIDAD.Text);
                        model.FECHA_HORA = DateTime.Now;

                        if (controller.AddData(model))
                        {
                            if (controller.RestarStock(model.ID_REPUESTO, model.CANTIDAD))
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
                            MessageBox.Show("Error encontrado al intentar procesar solicitud. ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay stock suficiente para la cantidad seleccionada,\nel producto tiene disponibles "+ data + " unidades. ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontró un error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //private void Actualizar()
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(textBoxCANTIDAD.Text))
        //        {
        //            REPUESTOS_X_MANTENIMIENTOS model = new REPUESTOS_X_MANTENIMIENTOS();

        //            model.ID_MANTENIMIENTO = _ID;
        //            model.ID_REPUESTO = decimal.Parse(comboBox1.SelectedValue.ToString());
        //            model.CANTIDAD = decimal.Parse(textBoxCANTIDAD.Text);
        //            model.FECHA_HORA = DateTime.Now;

        //            if (controller.UpdateData(model))
        //            {
        //                MessageBox.Show("Registro actualizado con éxito ✓", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                this.Close();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Error encontrado al intentar procesar solicitud. ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Uno o varios campos están vacíos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Se encontró un error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void LoadComboRepuestos()
        {
            comboBox1.DataSource = controller.getDataListCombo();

            comboBox1.DisplayMember = "NOMBRE";
            comboBox1.ValueMember = "ID";
        }

        private void MControlTiposVehiculos_modal_Load(object sender, EventArgs e)
        {
            LoadComboRepuestos();

      
            this.Text = "Agregar nuevo registro";
            button2.Text = "AGREGAR";

            textBoxCANTIDAD.Text = "";

            textBoxCANTIDAD.Focus();
            textBoxCANTIDAD.Select();
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxCANTIDAD.Text))
            {
                Agregar();
                //if (_id < 0)
                //{
                //    Agregar();
                //}
                //else
                //{
                //    Actualizar();
                //}
            }
        }

        private void textBoxCANTIDAD_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCANTIDAD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }
    }
}
