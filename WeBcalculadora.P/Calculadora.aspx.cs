using System;
using System.Web.UI;

namespace WeBcalculadora
{
    public partial class Calculadora : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // ========= MÉTODO AUXILIAR PARA LA PANTALLA =========
        private void AgregarDigito(string d)
        {
            lresultado.Text += d;
        }

        // ========= BOTONES NUMÉRICOS (TECLADO) =========
        protected void b0_Click(object sender, EventArgs e) { AgregarDigito("0"); }
        protected void b1_Click(object sender, EventArgs e) { AgregarDigito("1"); }
        protected void b2_Click(object sender, EventArgs e) { AgregarDigito("2"); }
        protected void b3_Click(object sender, EventArgs e) { AgregarDigito("3"); }
        protected void b4_Click(object sender, EventArgs e) { AgregarDigito("4"); }
        protected void b5_Click(object sender, EventArgs e) { AgregarDigito("5"); }
        protected void b6_Click(object sender, EventArgs e) { AgregarDigito("6"); }
        protected void b7_Click(object sender, EventArgs e) { AgregarDigito("7"); }
        protected void b8_Click(object sender, EventArgs e) { AgregarDigito("8"); }
        protected void b9_Click(object sender, EventArgs e) { AgregarDigito("9"); }

        // ========= BOTÓN CALCULAR (usa CheckBox + RadioButton + Dropdown + ListBox) =========
        protected void bcalcular_Click(object sender, EventArgs e)
        {
            // Usamos ClsCheckbox con los TextBox tvalor1 y tvalor2
            float n1 = float.Parse(tvalor1.Text);
            float n2 = float.Parse(tvalor2.Text);

            // 1) CHECKBOX
            ClsCheckbox objCheck = new ClsCheckbox(n1, n2);
            string resultadoCheck = "";

            if (Csuma.Checked)
                resultadoCheck += $"[CheckBox Suma: {objCheck.sumar()}] ";

            if (Cresta.Checked)
                resultadoCheck += $"[CheckBox Resta: {objCheck.restar()}] ";

            // 2) RADIOBUTTON (usa ClsRadionButton)
            ClsRadionButton objRadio = new ClsRadionButton();
            string resultadoRadio = "";

            if (rsuma.Checked)
                resultadoRadio = $"[RadioButton Suma: {objRadio.sumar(n1, n2)}]";
            else if (rresta.Checked)
                resultadoRadio = $"[RadioButton Resta: {ClsRadionButton.restar(n1, n2)}]";

            // 3) DROPDOWNLIST (usa ClsDropdonwlist)
            ClsDropdonwlist objDrop = new ClsDropdonwlist(Dlista.SelectedValue);
            float resultadoDrop = objDrop.Calcular(n1, n2);

            // 4) LISTBOX (usa ClsList)
            ClsList objList = new ClsList(ListBox1.GetSelectedIndices(), ListBox1.Items);
            string resultadoLista = objList.CalcularTodas(n1, n2);

            lresultado.Text =
                resultadoCheck + " " +
                resultadoRadio + " " +
                $"[DropDown: {resultadoDrop}] " +
                resultadoLista;
        }

        // ========= OPERACIONES BINARIAS (SETEAN ClsOperacion) =========
        protected void bsuma_Click(object sender, EventArgs e)
        {
            ClsOperacion.PrepararOperacionBinaria(OperadorBinario.Suma, lresultado.Text);
            lresultado.Text = string.Empty;
        }

        protected void bresta_Click(object sender, EventArgs e)
        {
            ClsOperacion.PrepararOperacionBinaria(OperadorBinario.Resta, lresultado.Text);
            lresultado.Text = string.Empty;
        }

        protected void bmulti_Click(object sender, EventArgs e)
        {
            ClsOperacion.PrepararOperacionBinaria(OperadorBinario.Multiplicacion, lresultado.Text);
            lresultado.Text = string.Empty;
        }

        protected void bdivi_Click(object sender, EventArgs e)
        {
            ClsOperacion.PrepararOperacionBinaria(OperadorBinario.Division, lresultado.Text);
            lresultado.Text = string.Empty;
        }

        // ========= BOTÓN "=" RESUELVE LA OPERACIÓN BINARIA =========
        protected void bresultado_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lresultado.Text))
            {
                ClsOperacion.SetSegundoValorDesdeTexto(lresultado.Text);
            }

            float resultado;
            if (ClsOperacion.ResolverOperacionBinaria(out resultado))
                lresultado.Text = resultado.ToString();
            else
                lresultado.Text = "Error";
        }

        // ========= OPERACIONES ESPECIALES (UNARIAS) =========
        protected void bpot2_Click(object sender, EventArgs e)
        {
            if (float.TryParse(lresultado.Text, out float x))
                lresultado.Text = ClsOperacion.Potencia2(x).ToString();
            else
                lresultado.Text = "Error";
        }

        protected void bpot3_Click(object sender, EventArgs e)
        {
            if (float.TryParse(lresultado.Text, out float x))
                lresultado.Text = ClsOperacion.Potencia3(x).ToString();
            else
                lresultado.Text = "Error";
        }

        protected void braiz_Click(object sender, EventArgs e)
        {
            if (float.TryParse(lresultado.Text, out float x) && x >= 0)
                lresultado.Text = ClsOperacion.RaizCuadrada(x).ToString();
            else
                lresultado.Text = "Error";
        }

        protected void bfact_Click(object sender, EventArgs e)
        {
            if (int.TryParse(lresultado.Text, out int n) && n >= 0)
                lresultado.Text = ClsOperacion.Factorial(n).ToString();
            else
                lresultado.Text = "Error";
        }

        protected void bfib_Click(object sender, EventArgs e)
        {
            if (int.TryParse(lresultado.Text, out int n) && n >= 0)
                lresultado.Text = ClsOperacion.Fibonacci(n).ToString();
            else
                lresultado.Text = "Error";
        }

        // ========= LIMPIAR =========
        protected void bclear_Click(object sender, EventArgs e)
        {
            lresultado.Text = string.Empty;
            ClsOperacion.Reiniciar();
        }
    }
}
