using System.Reflection.Metadata;

namespace RelogioHorasTrabalhadas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calcularHoras()
        {

            string inicio_1 = mskBPrimeiraEntrada.Text;
            string inicio_2 = mskBSegundaEntrada.Text;
            string inicio_3 = maskedTextBox9.Text;
            string inicio_4 = maskedTextBox13.Text;
            string inicio_5 = maskedTextBox14.Text;
            string inicio_6 = maskedTextBox7.Text;
            string inicio_7 = maskedTextBox11.Text;
            string inicio_8 = maskedTextBox15.Text;

            string fim_1 = mskBPrimeiraSaida.Text;
            string fim_2 = mskBSegundaSaida.Text;
            string fim_3 = maskedTextBox10.Text;
            string fim_4 = maskedTextBox14.Text;
            string fim_5 = maskedTextBox14.Text;
            string fim_6 = maskedTextBox8.Text;
            string fim_7 = maskedTextBox12.Text;
            string fim_8 = maskedTextBox16.Text;
            string total;

            TimeSpan p1;
            TimeSpan p2;
            TimeSpan p3;
            TimeSpan p4;
            TimeSpan p5;
            TimeSpan p6;
            TimeSpan p7;
            TimeSpan p8;


            if (fim_1 != null && fim_1 != "  :")
            {
                p1 = TimeSpan.Parse(fim_1).Subtract(TimeSpan.Parse(inicio_1));

                primeiroResultado.Text = p1.ToString();
            }

            if (fim_2 != null && fim_2 != "  :")
            {
                p2 = TimeSpan.Parse(fim_2).Subtract(TimeSpan.Parse(inicio_2));

                primeiroResultado.Text = (TimeSpan.Parse(primeiroResultado.Text) + p2).ToString();
            }



            if (fim_3 != null && fim_3 != "  :")
            {
                p3 = TimeSpan.Parse(fim_3).Subtract(TimeSpan.Parse(inicio_3));

                segundoResultado.Text = p3.ToString();
            }

            if ((fim_4 != null) && (fim_4 != "  :"))
            {
                p4 = TimeSpan.Parse(fim_4).Subtract(TimeSpan.Parse(inicio_4));

                segundoResultado.Text = (TimeSpan.Parse(segundoResultado.Text) + p4).ToString();
            }



            if (fim_5 != null && fim_5 != "  :")
            {
                p5 = TimeSpan.Parse(fim_5).Subtract(TimeSpan.Parse(inicio_5));

                terceiroResultado.Text = p5.ToString();
            }

            if (fim_6 != null && fim_6 != "  :")
            {
                p6 = TimeSpan.Parse(fim_6).Subtract(TimeSpan.Parse(inicio_6));

                terceiroResultado.Text = (TimeSpan.Parse(terceiroResultado.Text) + p6).ToString();
            }



            if (fim_7 != null && fim_7 != "  :")
            {
                p7 = TimeSpan.Parse(fim_7).Subtract(TimeSpan.Parse(inicio_7));

                quartoResultado.Text = p7.ToString();
            }

            if (fim_8 != null && fim_8 != "  :")
            {
                p8 = TimeSpan.Parse(fim_8).Subtract(TimeSpan.Parse(inicio_8));

                quartoResultado.Text = (TimeSpan.Parse(quartoResultado.Text) + p8).ToString();
            }


            resultadoTotal.Text = (TimeSpan.Parse(primeiroResultado.Text) + TimeSpan.Parse(segundoResultado.Text) + TimeSpan.Parse(terceiroResultado.Text) + TimeSpan.Parse(quartoResultado.Text)).ToString();
        }

        private void calcular_Click(object sender, EventArgs e)
        {
            calcularHoras();
        }
    }
}