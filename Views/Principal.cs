using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TALLERM.Vistas;

namespace TALLERM.View
{
    public partial class Principal : Form
    {
        private string TIPO_USUARIO;
        public Principal(string tipo = null)
        {
            TIPO_USUARIO = tipo;
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MGestionConductores m = new MGestionConductores();
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MGestionProveedores m = new MGestionProveedores();
            m.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MCatalogoRepuestos m = new MCatalogoRepuestos();
            m.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MControlVehiculos m = new MControlVehiculos();
            m.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //MReportes_modal m = new MReportes_modal();
            //m.ShowDialog();
            //this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            MGestionUsuarios m = new MGestionUsuarios();
            m.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfirmacionCerrar() == true)
            {
                Application.Exit();
            };
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void configurarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MGestionUsuarios m = new MGestionUsuarios();
            m.Show();
            this.Hide();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("** C O N M M A P **\nCONTROL DE MANTENIMIENTO DE MAQUINARIA PESADA\nUMG 2021\nNombre Usuario Completo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ConfirmacionCerrar()
        {
            const string message = "¿Está seguro de cerrar el aplicativo?";
            const string caption = "Confirmación";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        public static bool ConfirmacionCerrarSesion()
        {
            const string message = "¿Está seguro de cerrar la sesión actual?";
            const string caption = "Confirmación";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            if(TIPO_USUARIO != null)
            {
                if (TIPO_USUARIO.Equals("ADMIN"))
                {
                    bitácoraToolStripMenuItem.Enabled = true;
                    configurarUsuariosToolStripMenuItem.Enabled = true;
                }
                else
                {
                    bitácoraToolStripMenuItem.Enabled = false;
                    configurarUsuariosToolStripMenuItem.Enabled = false;
                }
            }



        }

        private void cerrarSesiónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ConfirmacionCerrarSesion() == true)
            {
                Login m = new Login();
                m.Show();
                this.Close();
            };


        }

        private void bitácoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MVistaBitacora m = new MVistaBitacora();
            m.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form1 m = new Form1();
            m.Show();
            this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            MControlMantenimientosConsulta m = new MControlMantenimientosConsulta();
            m.Show();
            this.Hide();
        }

        private void reporteDeMantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MReportes m = new MReportes(1);
            m.Show();
            this.Hide();
        }

        private void reporteDeEncargadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MReportes m = new MReportes(2);
            m.Show();
            this.Hide();
        }

        private void reporteDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MReportes m = new MReportes(3);
            m.Show();
            this.Hide();
        }

        private void reporteDeVehículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MReportes m = new MReportes(4);
            m.Show();
            this.Hide();
        }

        private void reporteDeRepuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MReportes m = new MReportes(5);
            m.Show();
            this.Hide();
        }
    }
}
