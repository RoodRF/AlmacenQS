using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AlmacenQS
{
    class Conexion
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader rd;
        public string nombreUs;
        public string correoUs;
        public string passwordUs;
        public int idUsuario;
        
        public Conexion()
        {
            try 
            {
                conn = new SqlConnection("Data Source=ROD-PC\\SERVIDOR_QS; Initial Catalog=AlmacenQS; Integrated Security=false; UID=QS-ROD;PWD=QSI9900 ");
                conn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No hubo conexion" + ex.ToString());
            }
        }
        public void AgregarUsuario(string nombre, string correo, string password, int tipo)
        {
            string mensaje = "Usuario guardado correctamente";

            try
            {
                cmd = new SqlCommand("INSERT INTO USUARIOS(NOMBRE, CORREO, PASS, ID_TIPO) VALUES('" + nombre + "','" + correo + "', dbo.FUNC_ENCRIPT_PASS('" + password + "'),'" + tipo + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar datos: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public bool BuscarUsuario(string parametro, int tipoBusqueda) {
            string mensaje = "No se ha encontrado ningún usuario";
            bool existe = false;
            string parBusqueda="";
            switch (tipoBusqueda) { 
                case 1:
                    parBusqueda = "NOMBRE";
                    break;
                case 2:
                    parBusqueda = "CORREO";
                    break;
            }
            try
            {
                cmd = new SqlCommand("SELECT ID_USUARIO,NOMBRE, [dbo].[FUNC_DECRIPT_PASS](PASS) PASS, CORREO FROM USUARIOS WHERE " + parBusqueda + "='" + parametro + "'", conn);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    nombreUs = rd["NOMBRE"].ToString();
                    correoUs = rd["CORREO"].ToString();
                    passwordUs = rd["PASS"].ToString();
                    idUsuario = Int32.Parse(rd["ID_USUARIO"].ToString());
                    existe = true;
                }
                else
                {
                    existe = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(mensaje + ": " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally {
                rd.Close();
            }
            return existe;
        }
        public void ActualizarUsuario(string nombre, string correo, string password) {
            string mensaje = "El usuario se ha actualizado de manera correcta";

            try
            {
                cmd = new SqlCommand("UPDATE USUARIOS SET NOMBRE='" + nombre + "', CORREO='" + correo + "', PASS=[dbo].[FUNC_ENCRIPT_PASS]('" + password + "') WHERE ID_USUARIO=" + idUsuario + "", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar datos: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        public void EliminarUsuario(int idUsuario)
        {
            string mensaje = "Usuario eliminado de manera correcta";

            try
            {
                cmd = new SqlCommand("DELETE FROM USUARIOS WHERE ID_USUARIO=" + idUsuario + "", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar usuario: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        

    }
}
