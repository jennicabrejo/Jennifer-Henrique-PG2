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
    public partial class MVistaBitacora_modal : Form
    {
        private VistaBitacoraController controller;
        private int _id;

        public MVistaBitacora_modal(int ID, VistaBitacoraController CONTROL)
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

        private void MControlTiposVehiculos_modal_Load(object sender, EventArgs e)
        {
            var result = controller.getData(this._id);
            textBoxFECHA.Text = result.FECHA_HORA.ToString("dd/MM/yyyy HH:mm:ss");
            textBoxEVENTO.Text = result.NOMBRE_EVENTO;
            textBoxDETALLE.Text = result.DESC_EVENTO;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
