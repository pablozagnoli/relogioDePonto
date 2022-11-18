using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using Newtonsoft.Json.Linq;
using RelogioHorasTrabalhadas.Services;

namespace RelogioHorasTrabalhadas
{
    public partial class Form1 : Form
    {

        static readonly HttpClient client = new HttpClient();
        static string token = "";
        static login formLogin = new login();
        static retornoDto retornoDadosUsuario;
        static horasUsuario HorasUsuario = new horasUsuario();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            formLogin.ShowDialog();

            var valorEmail = formLogin.getValorEmail();

            var valorSenha = formLogin.getValorSenhal();

            if (string.IsNullOrEmpty(valorEmail) &&
                string.IsNullOrEmpty(valorSenha))
            {
                MessageBox.Show("PREENCHA USUARIO E SENHA", "PREENCHA USUUARIO E SENHA", MessageBoxButtons.OK);
            }

            token = formLogin.getValorToken();
            retornoDadosUsuario = RequestRhId.DadosUsuarioRhIdRequest(token: token);
            calcularHoras();

            lbBemVindo.Text = lbBemVindo.Text + " " +retornoDadosUsuario.nome;
            atribuirValorDasHoras();
            atribuirValorAosCampos();
        }

        private void atribuirValorDasHoras()
        {
            HorasUsuario.Ano = retornoDadosUsuario.afdt[0].dateTimeStr.Substring(0, 4);
            HorasUsuario.Mes = retornoDadosUsuario.afdt[0].dateTimeStr.Substring(4, 2);
            HorasUsuario.Dia = retornoDadosUsuario.afdt[0].dateTimeStr.Substring(6, 2);
            HorasUsuario.Horas = retornoDadosUsuario.afdt[0].dateTimeStr.Substring(8, 2);
            HorasUsuario.Minutos = retornoDadosUsuario.afdt[0].dateTimeStr.Substring(10, 2);            
        }

        private void atribuirValorAosCampos()
        {
            mskBPrimeiraEntrada.Text = HorasUsuario.Horas + ":" + HorasUsuario.Minutos;
            
            if (mskBPrimeiraSaida.Text == null || mskBPrimeiraSaida.Text == "  :")
            {
                mskBPrimeiraSaida.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            }
        }

        private void calcular_Horas()
        {
            token = formLogin.getValorToken();
            RequestRhId.DadosUsuarioRhIdRequest(token: token);
            calcularHoras();
        }

        private void calcularHoras()
        {

            string inicio_1 = mskBPrimeiraEntrada.Text;
            string inicio_2 = mskBSegundaEntrada.Text;


            string fim_1 = mskBPrimeiraSaida.Text;
            string fim_2 = mskBSegundaSaida.Text;
            string total;

            TimeSpan p1;
            TimeSpan p2;



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
            resultadoTotal.Text = (TimeSpan.Parse(primeiroResultado.Text)).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            calcular_Horas();
        }

        private void primeiroResultado_Click(object sender, EventArgs e)
        {

        }
    }
}