using System;

namespace WeBcalculadora
{
    public class ClsOperacion
    {
        // ======== GET/SET ESTÁTICOS ========
        public static float valor1 { get; set; }
        public static float valor2 { get; set; }

        // Getter/Setter ESTÁTICO 
        public static float UltimoResultado { get; set; }

        // ======== Banderas estáticas para saber qué operación se va a hacer ========
        public static bool sumar = false;
        public static bool restar = false;
        public static bool multiplicar = false;
        public static bool dividir = false;
        public static bool factorial = false;
        public static bool exponente2 = false;
        public static bool exponente3 = false;
        public static bool raiz = false;
        public static bool fibonacci = false;

        // ======== GET/SET DE INSTANCIA ========
        public long ResultadoTemporal { get; set; }

        // Constructor por defecto
        public ClsOperacion()
        {
        }

        // Constructor con valor inicial
        public ClsOperacion(long resultadoInicial)
        {
            ResultadoTemporal = resultadoInicial;
        }

        // ======== MÉTODOS ESTÁTICOS DE OPERACIONES BINARIAS ========
        public static float metodo_sumar(float v1, float v2)
        {
            float res = v1 + v2;
            UltimoResultado = res;
            return res;
        }

        public static float metodo_restar(float v1, float v2)
        {
            float res = v1 - v2;
            UltimoResultado = res;
            return res;
        }

        public static float metodo_multiplicar(float v1, float v2)
        {
            float res = v1 * v2;
            UltimoResultado = res;
            return res;
        }

        public static float metodo_dividir(float v1, float v2)
        {
            if (v2 == 0)
                throw new DivideByZeroException("No se puede dividir entre cero.");

            float res = v1 / v2;
            UltimoResultado = res;
            return res;
        }

        // ======== MÉTODOS ESTÁTICOS DE OPERACIONES UNARIAS ========

        public static float metodo_potencia2(float v1)
        {
            float res = v1 * v1;
            UltimoResultado = res;
            return res;
        }

        public static float metodo_potencia3(float v1)
        {
            float res = v1 * v1 * v1;
            UltimoResultado = res;
            return res;
        }

        public static float metodo_raiz(float v1)
        {
            if (v1 < 0)
                throw new ArgumentException("No se puede sacar raíz cuadrada de un número negativo.");

            float res = (float)Math.Sqrt(v1);
            UltimoResultado = res;
            return res;
        }

        public static long metodo_factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("El factorial solo está definido para enteros >= 0.");

            long r = 1;
            for (int i = 2; i <= n; i++)
                r *= i;

            return r;
        }

        public static long metodo_fibonacci(int n)
        {
            if (n < 0)
                throw new ArgumentException("Fibonacci solo está definido para enteros >= 0.");

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
    }
}
