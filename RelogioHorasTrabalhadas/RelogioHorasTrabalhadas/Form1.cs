using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using Newtonsoft.Json.Linq;
using RelogioHorasTrabalhadas.Services;
using System.Windows.Forms;

namespace RelogioHorasTrabalhadas
{
    public partial class Form1 : Form
    {

        static readonly HttpClient client = new HttpClient();
        static string token = "";
        static login formLogin = new login();
        static retornoDto retornoDadosUsuario;
        static horasUsuario HorasUsuario = new horasUsuario();
        static int count3horas = 0;

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
            minimiarParaBarraEBandeja();
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
            primeiroResultado.Text = (TimeSpan.Parse(primeiroResultado.Text)).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            calcular_Horas();

            if (TimeSpan.Parse(primeiroResultado.Text) > TimeSpan.Parse("05:30") && TimeSpan.Parse(primeiroResultado.Text) < TimeSpan.Parse("05:32"))
            {
                MessageBox.Show("Faltam 30 minutos para o horario de descanso", "Faltam 30 minutos para o horario de descanso", MessageBoxButtons.OK);
            }

            if (TimeSpan.Parse(primeiroResultado.Text) == TimeSpan.Parse("06:00"))
            {
                MessageBox.Show("Voce atingiu " + primeiroResultado.Text + " horas trabalhdas!!", "Voce atingiu " + primeiroResultado.Text + " horas trabalhdas!!", MessageBoxButtons.OK);
            }

            if (TimeSpan.Parse(primeiroResultado.Text) > TimeSpan.Parse("03:00") && count3horas < 1)
            {
                MessageBox.Show("3 horas de trabalho", "3 horas de trabalho", MessageBoxButtons.OK);
                count3horas ++;
            }
        }

        private void primeiroResultado_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void minimiarParaBarraEBandeja()
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            notifyIcon1.Visible = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
                notifyIcon1.Visible = true;
            }
        }
    }
}