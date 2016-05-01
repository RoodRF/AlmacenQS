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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void altaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

     
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarArt agregarArt = new frmAgregarArt();
            agregarArt.ShowDialog();
        }

     

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulos buscar = new frmArticulos();
            buscar.ShowDialog();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditar editar = new frmEditar();
            editar.ShowDialog();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAltaUsuarios nuevo = new frmAltaUsuarios();
            nuevo.ShowDialog();
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmModUser modUser = new frmModUser();
            modUser.ShowDialog();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
