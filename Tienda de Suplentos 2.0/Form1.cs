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
  
    public partial class Formulario1 : Form
    {
        public ListaSuplementos Lista { get; set; } = new ListaSuplementos();

        

        public Formulario1()
        {
            InitializeComponent();
            dgvLista.DataSource = Lista.DT;
        }

        

        private void btCargar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" && txtProducto.Text != "" && txtPrecio.Text != "")
            {
                if (int.TryParse(txtPrecio.Text,out int n))
                {
                    Lista.Agregar(txtCodigo.Text, txtProducto.Text, txtPrecio.Text);
                    lblError.Text = "El dato del Codigo " + txtCodigo.Text + " se cargo correctamente.";
                    txtProducto.Text = "";
                    txtPrecio.Text = "";
                    txtCodigo.Text = "";
                    txtCodigo.Focus();
                }
                else
                {
                    lblError.Text = "El campo -Precio- no es un numero entero.";
                }               
            }
            else
            {
                lblError.Text = "Algunos de los campos se encuentra vacio.";
            }

        }

        private void btMostrar_Click(object sender, EventArgs e)
        {
            if (Lista.Suplementos != null)
            {
                lblError.Text = Lista.Arreglo();
            }
            
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            Suplemento Suplementos = Lista.Buscar(txtBuscar.Text);
           // lblError.Text = Suplementos.Codigo + " - "
           //     + Suplementos.Producto + " - $"
           //     + Convert.ToString(Suplementos.Precio) + "\r\n";
            if (Suplementos.Codigo != "")
            {
                lblError.Text = Suplementos.Codigo + " - "
                + Suplementos.Producto + " - $"
                + Convert.ToString(Suplementos.Precio) + "\r\n";
            }
            else
            {
                lblError.Text = "No existe ese producto o error en el codigo";
            }

        }
    }
}
