using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlmacenQS
{
    class ValidaCampos
    {
        
        public bool campoVacio(GroupBox groupBox) {
            int cuentaVacios=0;
            bool vacio=false;
            foreach (object objeto in groupBox.Controls) {
                if (objeto.GetType()==typeof(TextBox))
                    if (((TextBox)objeto).Text == String.Empty) {
                        cuentaVacios+=1;
                    }
            }
            if (cuentaVacios>0)
            {
                vacio = true;
            }
            else
            {
                vacio = false;
            }
            return vacio;
        }
        public bool Passwords(String pass, String confPass)
        {
            bool passEqual = false;
            if (pass == confPass)
            {
                passEqual = true;
            }
            else
            {
                passEqual = false;
            }
            return passEqual;
        }
        public void LimpiarCampos(GroupBox groupBox){
            TextBox textos;
            foreach (object objeto in groupBox.Controls)
            {
                if (objeto.GetType() == typeof(TextBox))
                {
                    textos = (TextBox)objeto;
                    textos.Text = "";
                }
            }
        }

    }
}
