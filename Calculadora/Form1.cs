using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        string expressao = "";


        private void numero_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            expressao += btn.Text;
            txbTela.Text = expressao;
        }


        private void acoes_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string operador = btn.Text;

            if (string.IsNullOrEmpty(expressao))
            {
                return;
            }

           
            char ultimoChar = expressao[expressao.Length - 1];

          
            if ("+-*/".Contains(ultimoChar))
            {
                expressao = expressao.Remove(expressao.Length - 1);
            }

            expressao += operador;
            txbTela.Text = expressao;

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            expressao = expressao.Substring(0, expressao.Length - 1);
            txbTela.Text = expressao;
            
                
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {

            char ultimoChar = expressao[expressao.Length - 1];
            if ("+-*/".Contains(ultimoChar))
            {
                MessageBox.Show("Termina de digitar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            
           


            if (expressao.Contains("/0"))
            {
                MessageBox.Show("Dividir por zero pra quê?", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expressao = "";
                txbTela.Text = "";
            }
           
            else
            {
                var resultado = new DataTable().Compute(expressao, null);
                txbTela.Text = resultado.ToString();
                expressao = resultado.ToString();
            }
            
        }
    }
}
