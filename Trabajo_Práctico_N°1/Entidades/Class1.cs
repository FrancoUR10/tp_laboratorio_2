using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Recibe un operador validando que sea correcto y lo retorna
        /// </summary>
        /// <param name="operador">El operador a ingresar</param>
        /// <returns>El operador ingresado o '+' si el operador no es valido</returns>
        private static string ValidarOperador(char operador) 
        {
            string operadorValido;
            switch (operador) 
            {
                case '-':
                    operadorValido = operador.ToString();
                    break;
                case '*':
                    operadorValido = operador.ToString();
                    break;
                case '/':
                    operadorValido = operador.ToString();
                    break;
                default:
                    operadorValido = "+";
                    break;
            }
            return operadorValido;
        }
        /// <summary>
        /// Recibe dos numeros y un operador para realizar la operacion correspondiente
        /// </summary>
        /// <param name="num1">El primer numero a calcular</param>
        /// <param name="num2">El segundo numero a calcular</param>
        /// <param name="operador">El operador con el cual realizar el cálculo</param>
        /// <returns>El resultado de la operacion</returns>
        public static double Operar(Numero num1,Numero num2,string operador) 
        {
            double resultado=0;
            char caracter;
            char.TryParse(operador, out caracter);
            switch (Calculadora.ValidarOperador(caracter)) 
            {
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                default:
                    resultado = num1 + num2;
                    break;
            }
            return resultado;
        }
    }
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Inicializa el atributo numero por defecto al valor '0'
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Inicializa el atributo numero al valor ingresado por parametros
        /// </summary>
        /// <param name="numero">El valor a inicializar el atributo numero</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Inicializa el atributo numero al valor ingresado por string si es valido, caso contrario se inicializara en '0'
        /// </summary>
        /// <param name="strNumero">El numero en formato string a validar</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Valida si la cadena de caracteres ingresada es numerica
        /// </summary>
        /// <param name="strNumero">El numero a ingresar en formato string</param>
        /// <returns>El numero ingresado o '0' si el valor ingresado no es numerico</returns>
        private double ValidarNumero(string strNumero) 
        {
            double numero;
            double.TryParse(strNumero, out numero);
            return numero;
        }
        /// <summary>
        /// La propiedad que permite validar si una cadena de caracteres ingresada es numerica
        /// </summary>
        public string SetNumero 
        {
            set 
            {
                this.numero = this.ValidarNumero(value);
            }
        }
        /// <summary>
        /// Valida si una cadena de caracteres ingresada esta compuesta por numeros binarios
        /// </summary>
        /// <param name="binario">El valor en string a validar</param>
        /// <returns>Retorna 'true' si la cadena esta compuesta por unos y ceros, caso contrario retorna 'false'</returns>
        private bool EsBinario(string binario) 
        {
            bool esBinario=false;
            if(binario.Length > 0) 
            {
                esBinario = true;
                for(int i=0; i < binario.Length; i++) 
                {
                    if (binario[i] != '0' && binario[i] != '1') 
                    {
                        esBinario = false;
                        break;
                    }
                }
            }
            return esBinario;
        }
        /// <summary>
        /// Sobrecarga el operador + para realizar la suma de dos objetos de tipo 'Numero'
        /// </summary>
        /// <param name="n1">El primer numero a ingresar</param>
        /// <param name="n2">El segundo numero a ingresar</param>
        /// <returns>El resultado de la suma</returns>
        public static double operator + (Numero n1,Numero n2) 
        {
            return (n1.numero + n2.numero);
        }
        /// <summary>
        /// Sobrecarga el operador - para realizar la resta de dos objetos de tipo 'Numero'
        /// </summary>
        /// <param name="n1">El primer numero a ingresar</param>
        /// <param name="n2">El segundo numero a ingresar</param>
        /// <returns>El resultado de la resta</returns>
        public static double operator - (Numero n1, Numero n2)
        {
            return (n1.numero - n2.numero);
        }
        /// <summary>
        /// Sobrecarga el operador * para realizar la multiplicacion de dos objetos de tipo 'Numero'
        /// </summary>
        /// <param name="n1">El primer numero a ingresar</param>
        /// <param name="n2">El segundo numero a ingresar</param>
        /// <returns>El resultado de la multiplicacion</returns>
        public static double operator * (Numero n1, Numero n2)
        {
            return (n1.numero * n2.numero);
        }
        /// <summary>
        /// Sobrecarga el operador / para realizar la divicion de dos objetos de tipo 'Numero'
        /// </summary>
        /// <param name="n1">El primer numero a ingresar</param>
        /// <param name="n2">El segundo numero a ingresar</param>
        /// <returns>El resultado de la division o el valor minimo de un double si el segundo numero ingresado es igual a '0'</returns>
        public static double operator / (Numero n1, Numero n2)
        {
            double resultado;
            if (n2.numero != 0) 
            {
                resultado= (n1.numero / n2.numero);
            }
            else 
            {
                resultado = double.MinValue;
            }
            return resultado;
        }
        /// <summary>
        /// Realiza la conversion de una cadena de caracteres en binario a decimal
        /// </summary>
        /// <param name="binario">La cadena de caracteres compuesta por un numero binario</param>
        /// <returns>La conversion del numero a decimal en formato string o el mensaje: "Valor inválido" si la conversion no se pudo realizar"</returns>
        public string BinarioDecimal(string binario) 
        {
            int residuo = 0;
            int exponente = 0;
            int resultadoEntero = 0;
            int numeroBinario;
            string resultadoString;
            if (this.EsBinario(binario)) 
            {
                numeroBinario=int.Parse(binario);
                do
                {
                    residuo = numeroBinario % 10;
                    numeroBinario = numeroBinario / 10;
                    resultadoEntero += (int)(residuo * Math.Pow(2, exponente));
                    exponente++;

                } while (numeroBinario != 0);
                resultadoString = resultadoEntero.ToString();
            }
            else 
            {
                resultadoString = "Valor inválido";
            }
            return resultadoString;
        }
        /// <summary>
        /// Realiza una conversion de un numero double decimal a binario
        /// </summary>
        /// <param name="numero">El numero decimal a convertir</param>
        /// <returns>La conversion a binario en formato string o el mensaje: "Valor inválido" si la conversion no se pudo realizar</returns>
        public string DecimalBinario(double numero)
        {
            string binario = "";
            numero = Math.Round(numero);
            int entero = int.Parse(numero.ToString());
            if(entero >= 0) 
            {
                if (entero == 0)
                {
                    binario = "0";
                }
                else
                {
                    while (entero != 0)
                    {
                        binario = entero % 2 + binario;
                        entero = entero / 2;
                    }
                }
            }
            else 
            {
                binario= "Valor inválido";
            }
            return binario;
        }
        /// <summary>
        /// Valida una cadena de caracteres y realiza una conversion de decimal a binario si el valor ingresado es un numero decimal
        /// </summary>
        /// <param name="numero">El numero a validar y convertir en formato string</param>
        /// <returns>La conversion a binario en formato string o el mensaje: "Valor inválido" si la conversion no se pudo realizar</returns>
        public string DecimalBinario(string numero)
        {
            string conversion;
            double numeroDouble;
            if (double.TryParse(numero, out numeroDouble)==true) 
            {
                conversion=this.DecimalBinario(numeroDouble);
            }
            else 
            {
                conversion = this.DecimalBinario(-1);
            }
            return conversion;
        }
    }
}