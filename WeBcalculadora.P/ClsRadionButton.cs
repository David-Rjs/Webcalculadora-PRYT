using System;

namespace WeBcalculadora
{
    public class ClsRadionButton
    {
        // Propiedad de instancia, por si se quiere guardar la última operación
        public string UltimaOperacion { get; set; }

        public ClsRadionButton()
        {
            UltimaOperacion = "";
        }

        // Método de instancia
        public float sumar(float n1, float n2)
        {
            UltimaOperacion = "Suma";
            return n1 + n2;
        }

        // Método estático
        public static float restar(float n1, float n2)
        {
            return n1 - n2;
        }
    }
}

