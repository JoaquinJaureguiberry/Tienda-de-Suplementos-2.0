using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    //public DataTable DT = new DataTable();



    public class Suplemento
    {
        public string Codigo { get; set; }

        public string Producto { get; set; }

        public int Precio { get; set; }

    }

    public class ListaSuplementos
    {
        public Suplemento[] Suplementos { get; set; }

        public void Redimensionar()
        {

            if (Suplementos == null)
            {
                Suplementos = new Suplemento[1];
            }
            else
            {
                Suplemento[] Suplementos2 = new Suplemento[Suplementos.Length + 1];
                for (int i = 0; i < Suplementos.Length; i++)
                {
                    Suplementos2[i] = Suplementos[i];
                }
                Suplementos = Suplementos2;
            }

        }

        public void Agregar(string cod, string prod, string prec)
        {

            Suplemento suplementos = new Suplemento();
            suplementos.Codigo = cod;
            suplementos.Producto = prod;
            suplementos.Precio = Convert.ToInt16(prec);
            Redimensionar();
            Suplementos[Suplementos.Length - 1] = suplementos;

        }

        public string Arreglo()
        {
            string resp = "";

            resp = "Lista:\r\n";
            foreach (Suplemento item in Suplementos)
            {
                resp = resp + item.Codigo + " -- " + item.Producto + " -- $" + item.Precio + "\r\n";
            }

            return resp;
        }
        
    }

}
