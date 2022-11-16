using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class ListaSuplementos
    {
        public DataTable DT = new DataTable();

        public Suplemento[] Suplementos { get; set; }


        public ListaSuplementos()
        {

            DT.TableName = "Lista de Suplementos";
            DT.Columns.Add("Codigo");
            DT.Columns.Add("Producto");
            DT.Columns.Add("Precio");

            LeerDT_DeArchivo();
        }

        public void LeerDT_DeArchivo()
        {
            if (File.Exists("Lista.xml"))
            {
                DT.Clear();
                DT.ReadXml("Lista.xml");
                
            }

        }



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

            DT.Rows.Add();
            int n = DT.Rows.Count - 1;

            DT.Rows[n]["Codigo"] = suplementos.Codigo;
            DT.Rows[n]["Producto"] = suplementos.Producto;
            DT.Rows[n]["Precio"] = suplementos.Precio.ToString();

            DT.WriteXml("Lista.xml");

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

        public Suplemento Buscar(string cod)
        {
            Suplemento suplemento = new Suplemento();
            //DataRow[] fila = DT.Select("Precio=" + cod.ToString());

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (Convert.ToString(DT.Rows[i]["Codigo"]) == cod)
                {
                    suplemento.Codigo = (string)DT.Rows[i]["Codigo"];
                    suplemento.Producto = (string)DT.Rows[i]["Producto"];
                    suplemento.Precio = Convert.ToInt16(DT.Rows[i]["Precio"]);
                    break;
                }

                if (i == DT.Rows.Count - 1)
                {
                    suplemento.Codigo = "";
                }
            }

           
            return suplemento;
        }

    }
}
