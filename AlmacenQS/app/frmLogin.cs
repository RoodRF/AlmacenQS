using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlmacenQS
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
    
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
           
          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
