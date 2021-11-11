
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_4
{
    public partial class Form1 : Form
    {

        ListaPersonas Lista { get; set; } = new ListaPersonas();

        Persona perr { get; set; } = new Persona();

        public Form1()
        {
            InitializeComponent();
            Dt.DataSource = Lista.Data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            perr.apellido = txtApellido.Text;
            perr.nombre =  txtNombre.Text;
            perr.edad = Convert.ToInt32(txtEdad.Text);

            if (!Lista.UpdatePersona(perr))
            {
                txtEdad.Focus();
                txtEdad.SelectAll();
                lblerrror.Text = "Persona no válida";
            }


            perr = new Persona();
            


        }

        private void limpiar()
        {
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtNombre.Text = "";
            txtNombre.Focus();
            lblerrror.Text = "";
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {
            if (Lista.BorrarLinea(perr))
            {
                limpiar();
            }
            else
            {
                lblerrror.Text = "El contenido" + perr.Id + " no se pudo borrar.";

            }

        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            Lista.Borrar(perr);
            perr = new Persona();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }
    }

}


