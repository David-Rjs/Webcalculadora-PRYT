using System;

namespace WeBcalculadora
{
    // Clase, CONSTRUCTOR, GET/SET y MÉTODOS
    public class ClsCheckbox
    {
        private float num1;
        private float num2;

        // Constructor
        public ClsCheckbox(float n1, float n2)
        {
            num1 = n1;
            num2 = n2;
        }

        // Getters y setters
        public float Num1
        {
            get { return num1; }
            set { num1 = value; }
        }

        public float Num2
        {
            get { return num2; }
            set { num2 = value; }
        }

        // Métodos de operación
        public float sumar()
        {
            return num1 + num2;
        }

        public float restar()
        {
            return num1 - num2;
        }
    }
}
