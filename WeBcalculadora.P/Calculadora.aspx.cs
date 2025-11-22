using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeBcalculadora
{
    public partial class Calculadora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // ====== AUXILIAR PARA ESCRIBIR DÍGITOS EN LA PANTALLA ======
        private void AgregarDigito(string d)
        {
            lresultado.Text += d;
        }

        // ====== TECLADO NUMÉRICO ======
        protected void b1_Click(object sender, EventArgs e) { AgregarDigito("1"); }
        protected void b2_Click(object sender, EventArgs e) { AgregarDigito("2"); }
        protected void b3_Click(object sender, EventArgs e) { AgregarDigito("3"); }

        protected void Button4_Click(object sender, EventArgs e) { AgregarDigito("4"); }
        protected void Button5_Click(object sender, EventArgs e) { AgregarDigito("5"); }
        protected void Button6_Click(object sender, EventArgs e) { AgregarDigito("6"); }

        protected void b7_Click(object sender, EventArgs e) { AgregarDigito("7"); }
        protected void b8_Click(object sender, EventArgs e) { AgregarDigito("8"); }
        protected void b9_Click(object sender, EventArgs e) { AgregarDigito("9"); }
        protected void b0_Click(object sender, EventArgs e) { AgregarDigito("0"); }

        // ====== MÉTODOS PRIVADOS PARA POO CON CONTROLES ======

        private void checkBox()
        {
            // Usamos la clase ClsCheckbox con Num1 y Num2
            float n1 = float.Parse(tvalor1.Text);
            float n2 = float.Parse(tvalor2.Text);

            ClsCheckbox operacion = new ClsCheckbox(n1, n2);

            if (Csuma.Checked)
                lresultado.Text += $" [CheckBox Suma: {operacion.sumar()}]";

            if (Cresta.Checked)
                lresultado.Text += $" [CheckBox Resta: {operacion.restar()}]";
        }

        private void RadioButton()
        {
            float num1 = float.Parse(tvalor1.Text);
            float num2 = float.Parse(tvalor2.Text);

            ClsRadionButton operacion = new ClsRadionButton();

            if (rsuma.Checked)
                lresultado.Text += $" [RadioButton Suma: {operacion.sumar(num1, num2)}]";
            else if (rresta.Checked)
                lresultado.Text += $" [RadioButton Resta: {ClsRadionButton.restar(num1, num2)}]";
        }

        private void DropDown()
        {
            float n1 = float.Parse(tvalor1.Text);
            float n2 = float.Parse(tvalor2.Text);

            ClsDropdonwlist obj = new ClsDropdonwlist(Dlista.SelectedValue);
            float res = obj.Calcular(n1, n2);

            lresultado.Text += $" [DropDown {Dlista.SelectedValue}: {res}]";
        }

        private void List()
        {
            float n1 = float.Parse(tvalor1.Text);
            float n2 = float.Parse(tvalor2.Text);

            ClsList obj = new ClsList(ListBox1.GetSelectedIndices(), ListBox1.Items);
            string texto = obj.CalcularTodas(n1, n2);

            lresultado.Text += " " + texto;
        }

        // ====== BOTÓN CALCULAR (usa todas las clases POO de controles) ======
        protected void bcalcular_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (!float.TryParse(tvalor1.Text, out _) || !float.TryParse(tvalor2.Text, out _))
            {
                lresultado.Text = "Error: ingrese números válidos en Numero 1 y Numero 2.";
                return;
            }

            lresultado.Text = string.Empty;

            checkBox();
            RadioButton();
            DropDown();
            List();
        }

        // ====== OPERACIONES BINARIAS (+, -, *, /) con ClsOperacion ======
        protected void bsuma_Click(object sender, EventArgs e)
        {
            PrepararOperacionBinaria(OperacionBinaria.Suma);
        }

        protected void bresta_Click(object sender, EventArgs e)
        {
            PrepararOperacionBinaria(OperacionBinaria.Resta);
        }

        protected void bmulti_Click(object sender, EventArgs e)
        {
            PrepararOperacionBinaria(OperacionBinaria.Multiplicacion);
        }

        protected void bdivi_Click(object sender, EventArgs e)
        {
            PrepararOperacionBinaria(OperacionBinaria.Division);
        }

        private void PrepararOperacionBinaria(OperacionBinaria tipo)
        {
            if (!float.TryParse(lresultado.Text, out float v1))
            {
                lresultado.Text = "Error";
                return;
            }

            // Seteamos los valores estáticos en ClsOperacion y las banderas
            ClsOperacion.valor1 = v1;
            ClsOperacion.valor2 = 0;

            ClsOperacion.sumar = (tipo == OperacionBinaria.Suma);
            ClsOperacion.restar = (tipo == OperacionBinaria.Resta);
            ClsOperacion.multiplicar = (tipo == OperacionBinaria.Multiplicacion);
            ClsOperacion.dividir = (tipo == OperacionBinaria.Division);

            // Desactivamos banderas de operaciones unarias
            ClsOperacion.factorial = false;
            ClsOperacion.exponente2 = false;
            ClsOperacion.exponente3 = false;
            ClsOperacion.raiz = false;
            ClsOperacion.fibonacci = false;

            lresultado.Text = string.Empty;
        }

        // ====== BOTÓN "=" → resolver operación actual en ClsOperacion ======
        protected void bresultado_Click(object sender, EventArgs e)
        {
            // Si es operación binaria, tomamos segundo valor
            if (ClsOperacion.sumar || ClsOperacion.restar || ClsOperacion.multiplicar || ClsOperacion.dividir)
            {
                if (!float.TryParse(lresultado.Text, out float v2))
                {
                    lresultado.Text = "Error";
                    return;
                }

                ClsOperacion.valor2 = v2;
            }
            else
            {
                // Operaciones unarias ya tienen valor1 y no requieren valor2
                if (!float.TryParse(lresultado.Text, out float v1))
                {
                    lresultado.Text = "Error";
                    return;
                }
                ClsOperacion.valor1 = v1;
            }

            try
            {
                float resultado = 0;

                if (ClsOperacion.sumar)
                    resultado = ClsOperacion.metodo_sumar(ClsOperacion.valor1, ClsOperacion.valor2);
                else if (ClsOperacion.restar)
                    resultado = ClsOperacion.metodo_restar(ClsOperacion.valor1, ClsOperacion.valor2);
                else if (ClsOperacion.multiplicar)
                    resultado = ClsOperacion.metodo_multiplicar(ClsOperacion.valor1, ClsOperacion.valor2);
                else if (ClsOperacion.dividir)
                    resultado = ClsOperacion.metodo_dividir(ClsOperacion.valor1, ClsOperacion.valor2);
                else if (ClsOperacion.exponente2)
                    resultado = ClsOperacion.metodo_potencia2(ClsOperacion.valor1);
                else if (ClsOperacion.exponente3)
                    resultado = ClsOperacion.metodo_potencia3(ClsOperacion.valor1);
                else if (ClsOperacion.raiz)
                    resultado = ClsOperacion.metodo_raiz(ClsOperacion.valor1);
                else if (ClsOperacion.factorial)
                {
                    // ejemplo de getter/setter de instancia
                    var op = new ClsOperacion();
                    op.ResultadoTemporal = ClsOperacion.metodo_factorial((int)ClsOperacion.valor1);
                    lresultado.Text = op.ResultadoTemporal.ToString();
                    return;
                }
                else if (ClsOperacion.fibonacci)
                {
                    var op = new ClsOperacion();
                    op.ResultadoTemporal = ClsOperacion.metodo_fibonacci((int)ClsOperacion.valor1);
                    lresultado.Text = op.ResultadoTemporal.ToString();
                    return;
                }
                else
                {
                    lresultado.Text = "Sin operación";
                    return;
                }

                lresultado.Text = resultado.ToString();
            }
            catch (Exception ex)
            {
                lresultado.Text = "Error";
            }
        }

        // ====== LIMPIAR PANTALLA ======
        protected void bclear_Click(object sender, EventArgs e)
        {
            lresultado.Text = string.Empty;
            ClsOperacion.valor1 = 0;
            ClsOperacion.valor2 = 0;
            ClsOperacion.sumar = false;
            ClsOperacion.restar = false;
            ClsOperacion.multiplicar = false;
            ClsOperacion.dividir = false;
            ClsOperacion.factorial = false;
            ClsOperacion.exponente2 = false;
            ClsOperacion.exponente3 = false;
            ClsOperacion.raiz = false;
            ClsOperacion.fibonacci = false;
        }

        // ====== BOTONES DE OPERACIONES UNARIAS (activan banderas) ======
        protected void bpot2_Click(object sender, EventArgs e)
        {
            ClsOperacion.sumar = ClsOperacion.restar = ClsOperacion.multiplicar = ClsOperacion.dividir = false;
            ClsOperacion.factorial = ClsOperacion.exponente3 = ClsOperacion.raiz = ClsOperacion.fibonacci = false;
            ClsOperacion.exponente2 = true;
        }

        protected void bpot3_Click(object sender, EventArgs e)
        {
            ClsOperacion.sumar = ClsOperacion.restar = ClsOperacion.multiplicar = ClsOperacion.dividir = false;
            ClsOperacion.factorial = ClsOperacion.exponente2 = ClsOperacion.raiz = ClsOperacion.fibonacci = false;
            ClsOperacion.exponente3 = true;
        }

        protected void braiz_Click(object sender, EventArgs e)
        {
            ClsOperacion.sumar = ClsOperacion.restar = ClsOperacion.multiplicar = ClsOperacion.dividir = false;
            ClsOperacion.factorial = ClsOperacion.exponente2 = ClsOperacion.exponente3 = ClsOperacion.fibonacci = false;
            ClsOperacion.raiz = true;
        }

        protected void bfact_Click(object sender, EventArgs e)
        {
            ClsOperacion.sumar = ClsOperacion.restar = ClsOperacion.multiplicar = ClsOperacion.dividir = false;
            ClsOperacion.exponente2 = ClsOperacion.exponente3 = ClsOperacion.raiz = ClsOperacion.fibonacci = false;
            ClsOperacion.factorial = true;
        }

        protected void bfib_Click(object sender, EventArgs e)
        {
            ClsOperacion.sumar = ClsOperacion.restar = ClsOperacion.multiplicar = ClsOperacion.dividir = false;
            ClsOperacion.exponente2 = ClsOperacion.exponente3 = ClsOperacion.raiz = ClsOperacion.factorial = false;
            ClsOperacion.fibonacci = true;
        }
    }

    // Enum para operaciones binarias (solo para claridad interna)
    public enum OperacionBinaria
    {
        Suma,
        Resta,
        Multiplicacion,
        Division
    }
}
