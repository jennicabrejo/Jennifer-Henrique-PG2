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
using TALLERM.Models;
using TALLERM.View;

namespace TALLERM.Vistas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBoxUSER.Focus();
            textBoxUSER.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (!string.IsNullOrEmpty(textBoxPASS.Text) && !string.IsNullOrEmpty(textBoxUSER.Text))
            {
                VerifyLogin(new LoginController());
            }

        }

        private void VerifyLogin(LoginController control)
        {
            GR result = new GR();
            result = control.LoginUser(textBoxUSER.Text, textBoxPASS.Text);

            if(100 == result.CodeResult)
            {
                Principal prin = new Principal(result.TextResult);
                prin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(result.TextResult,"Alerta",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
