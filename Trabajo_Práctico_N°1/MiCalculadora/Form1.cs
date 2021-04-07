using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.Text = "Calculadora de Franco Acquisto del curso 2°A";
            this.StartPosition=FormStartPosition.CenterScreen;
            this.FormBorderStyle=FormBorderStyle.FixedSingle;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado=MiCalculadora.FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
            this.lblResultado.Text = resultado.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        /// Limpia todos los textos ingresados en el formulario
        /// </summary>
        private void Limpiar() 
        {
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
        }
        /// <summary>
        /// Realiza el calculo entre dos numeros y el operador ingresado
        /// </summary>
        /// <param name="numero1">El primer numero a ingresar</param>
        /// <param name="numero2">El segundo numero a ingresar</param>
        /// <param name="operador">El operador a ingresar</param>
        /// <returns>El resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador) 
        {
            Entidades.Numero numeroUno = new Entidades.Numero(numero1);
            Entidades.Numero numeroDos = new Entidades.Numero(numero2);
            return Entidades.Calculadora.Operar(numeroUno, numeroDos, operador);
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Entidades.Numero auxNumero = new Entidades.Numero();
            this.lblResultado.Text= auxNumero.DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Entidades.Numero auxNumero = new Entidades.Numero();
            this.lblResultado.Text = auxNumero.BinarioDecimal(this.lblResultado.Text);
        }
    }
}
