using System;
using System.Web.UI.WebControls;

namespace WeBcalculadora
{
    public class ClsList
    {
        public int[] IndicesSeleccionados { get; set; }
        public ListItemCollection Items { get; set; }

        public ClsList(int[] indices, ListItemCollection items)
        {
            IndicesSeleccionados = indices;
            Items = items;
        }

        // Devuelve un string con los resultados de todas las operaciones seleccionadas
        public string CalcularTodas(float n1, float n2)
        {
            string texto = "";

            foreach (int i in IndicesSeleccionados)
            {
                string op = Items[i].Text;
                float res = 0;

                switch (op)
                {
                    case "Suma":
                        res = n1 + n2;
                        break;
                    case "Resta":
                        res = n1 - n2;
                        break;
                    case "Multiplicacion":
                        res = n1 * n2;
                        break;
                    case "Division":
                        res = (n2 != 0) ? n1 / n2 : 0;
                        break;
                }

                texto += $"[List {op}: {res}] ";
            }

            return texto;
        }
    }
}
