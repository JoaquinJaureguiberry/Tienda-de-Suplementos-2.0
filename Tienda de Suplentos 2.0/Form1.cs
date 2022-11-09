using BackEnd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda_de_Suplentos_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        public ListaSuplementos Lista { get; set; } = new ListaSuplementos();

        private void btCargar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" && txtProducto.Text != "" && txtPrecio.Text != "")
            {
                Lista.Agregar(txtCodigo.Text, txtProducto.Text, txtPrecio.Text);
                txtProducto.Text = "";
                txtPrecio.Text = "";
                txtCodigo.Text = "";
                txtCodigo.Focus();
            }

        }

        private void btMostrar_Click(object sender, EventArgs e)
        {
            if (Lista.Suplementos != null)
            {
                lblLista.Text = Lista.Arreglo();
            }
            
        }
        
    }
}
