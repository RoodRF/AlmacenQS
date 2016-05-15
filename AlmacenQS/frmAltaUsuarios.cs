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

        Conexion con = new Conexion();
        public frmAltaUsuarios()
        {
            InitializeComponent();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ValidaCampos valida = new ValidaCampos();
            //frmAltaUsuarios usuarios = new frmAltaUsuarios();
            string nombre;
            string correo;
            string pass;
            string confPass;
            int tipo = 1;
            nombre = txtNombre.Text.ToString();
            correo = txtCorreo.Text.ToString();
            pass = txtPass.Text.ToString();
            confPass = txtConfirnPass.Text.ToString();
            if (rbAdministrador.Checked)
            {
                tipo = 1;
            }
            else {
                if (rbNormal.Checked) {
                    tipo = 2;
                }
            }
            if (!valida.campoVacio(gbUsuariosSistema))
            {
                if (valida.Passwords(pass, confPass))
                {
                    //usuarios.Close();
                    this.Close();
                    con.AgregarUsuario(nombre,correo,pass,tipo);
                    //MessageBox.Show("Usuario guardado correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
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

     

      

    }
}
    
    
