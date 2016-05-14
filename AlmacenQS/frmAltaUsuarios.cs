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
    public partial class frmAltaUsuarios : Form
    {


        public frmAltaUsuarios()
        {
            InitializeComponent();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ValidaCampos valida = new ValidaCampos();
            //frmAltaUsuarios usuarios = new frmAltaUsuarios();
            if (!valida.campoVacio(gbUsuariosSistema))
            {
                if (valida.Passwords(txtPass, txtConfirnPass))
                {
                    //usuarios.Close();
                    this.Close();
                    MessageBox.Show("Usuario guardado correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else {
                MessageBox.Show("Debe llenar todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

    }
}
    
    
