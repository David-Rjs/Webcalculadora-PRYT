using System;

namespace WeBcalculadora
{
    public enum OperadorBinario
    {
        Ninguno,
        Suma,
        Resta,
        Multiplicacion,
        Division
    }

    public class ClsOperacion
    {
        // ======= PROPIEDADES ESTÁTICAS (estado de la operación) =======
        public static float Valor1 { get; set; }
        public static float Valor2 { get; set; }
        public static OperadorBinario OperadorActual { get; set; } = OperadorBinario.Ninguno;

        // ======= PREPARAR OPERACIÓN BINARIA =======
        public static void PrepararOperacionBinaria(OperadorBinario op, string textoValor1)
        {
            if (float.TryParse(textoValor1, out float v1))
            {
                Valor1 = v1;
                OperadorActual = op;
            }
            else
            {
                OperadorActual = OperadorBinario.Ninguno;
            }
        }

        public static void SetSegundoValorDesdeTexto(string textoValor2)
        {
            float.TryParse(textoValor2, out float v2);
            Valor2 = v2;
        }

        public static bool ResolverOperacionBinaria(out float resultado)
        {
            resultado = 0;

            switch (OperadorActual)
            {
                case OperadorBinario.Suma:
                    resultado = Valor1 + Valor2;
                    break;
                case OperadorBinario.Resta:
                    resultado = Valor1 - Valor2;
                    break;
                case OperadorBinario.Multiplicacion:
                    resultado = Valor1 * Valor2;
                    break;
                case OperadorBinario.Division:
                    if (Valor2 == 0) return false;
                    resultado = Valor1 / Valor2;
                    break;
                default:
                    return false;
            }

            return true;
        }

        // ======= OPERACIONES UNARIAS =======
        public static float Potencia2(float x) => x * x;

        public static float Potencia3(float x) => x * x * x;

        public static float RaizCuadrada(float x) => (float)Math.Sqrt(x);

        public static long Factorial(int n)
        {
            long r = 1;
            for (int i = 2; i <= n; i++)
                r *= i;
            return r;
        }

        // Fibonacci clásico: devuelve el término n
        public static long Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            long a = 0;
            long b = 1;
            for (int i = 2; i <= n; i++)
            {
                long t = a + b;
                a = b;
                b = t;
            }
            return b;
        }

        public static void Reiniciar()
        {
            Valor1 = 0;
            Valor2 = 0;
            OperadorActual = OperadorBinario.Ninguno;
        }
    }
}
