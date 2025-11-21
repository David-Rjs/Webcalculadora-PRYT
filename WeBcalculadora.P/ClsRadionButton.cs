using System;

namespace WeBcalculadora
{
    public class ClsRadionButton
    {
        // No necesitamos atributos, pero podríamos guardar la última operación
        public string UltimaOperacion { get; set; }

        public ClsRadionButton()
        {
            UltimaOperacion = "";
        }

        public float sumar(float n1, float n2)
        {
            UltimaOperacion = "Suma";
            return n1 + n2;
        }

        public static float restar(float n1, float n2)
        {
            return n1 - n2;
        }
    }
}
