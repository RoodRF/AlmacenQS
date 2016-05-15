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
    public partial class frmModUser : Form
    {
        Conexion con = new Conexion();
        ValidaCampos limpiaCampos = new ValidaCampos();
        string nombreUsuario ="";
        string correo="";
        string password="";
        public frmModUser()
        {
            InitializeComponent();
            rbCorreo.CheckedChanged += new EventHandler(rbOpBusqueda_cc);
            rbNombreUs.CheckedChanged += new EventHandler(rbOpBusqueda_cc);
        }
        private void rbOpBusqueda_cc(object sender, EventArgs e) {
            RadioButton rbuton = sender as RadioButton;
            if (rbCorreo.Checked) {
                txtNombreUsuario.Enabled = false;
                txtCorreo.Enabled = true;
                txtNombreUsuario.Text = "";
                txtCorreo.Text = "";
            }
            else if(rbNombreUs.Checked){
                txtNombreUsuario.Enabled = true;
                txtCorreo.Enabled = false;
                txtNombreUsuario.Text = "";
                txtCorreo.Text = "";
            }
            limpiaCampos.LimpiarCampos(gbUpdateUser);
            HabilitarComponentes(false);
        }


        private void frmModUser_Load(object sender, EventArgs e)
        {
            txtNombreUsuario.Enabled = true;
            txtCorreo.Enabled = false;
            HabilitarComponentes(false);
        }
        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            nombreUsuario=txtNombreUsuario.Text.ToString();
            correo=txtCorreo.Text.ToString();
            string parametro="";
            int tipoBusqueda = 1;

            if (txtNombreUsuario.Enabled)
            {
                tipoBusqueda = 1;
                parametro = nombreUsuario;
            }
            else
            {
                if (txtCorreo.Enabled) {
                    tipoBusqueda = 2;
                    parametro = correo;
                }
            }
            if (!((tipoBusqueda == 1 & nombreUsuario=="") | (tipoBusqueda == 2 & correo=="")))
            {
                if (!con.BuscarUsuario(parametro, tipoBusqueda))
                {
                    MessageBox.Show("No se han encontrado resultados", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiaCampos.LimpiarCampos(gbUpdateUser);
                    HabilitarComponentes(false);
                }
                else
                {
                    txtNombreUsuarioA.Text = con.nombreUs;
                    txtCorreoA.Text = con.correoUs;
                    txtPassA.Text = con.passwordUs;
                    gbUpdateUser.Text = "Datos de usuario: " + nombreUsuario;
                    HabilitarComponentes(true);
                }
            }
            else {
                MessageBox.Show("Debe ingresar parametros de busqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HabilitarComponentes(false);
                limpiaCampos.LimpiarCampos(gbUpdateUser);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void HabilitarComponentes(bool habilita) {
            btnActualizar.Enabled = habilita;
            btnEliminar.Enabled = habilita;
            txtConfPassA.Enabled = habilita;
            txtCorreoA.Enabled = habilita;
            txtNombreUsuarioA.Enabled = habilita;
            txtPassA.Enabled = habilita;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string confirmaPass;
            ValidaCampos valida = new ValidaCampos();
            nombreUsuario = txtNombreUsuarioA.Text.ToString();
            correo = txtCorreoA.Text.ToString();
            password = txtPassA.Text.ToString();
            confirmaPass = txtConfPassA.Text.ToString();
            if (!valida.campoVacio(gbUpdateUser))
            {
                if (valida.Passwords(confirmaPass, password))
                {
                    con.ActualizarUsuario(nombreUsuario, correo, password);
                    limpiaCampos.LimpiarCampos(gbUpdateUser);
                    HabilitarComponentes(false);
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            con.EliminarUsuario(con.idUsuario);
        }

       
    }
}
