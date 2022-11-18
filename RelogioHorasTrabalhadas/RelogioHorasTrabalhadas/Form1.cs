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
        static retornoDto retornoDadosUsuario = new retornoDto() { afdt = new List<afdtt>() };
        static horasUsuario HorasUsuarioPrimeiraEntrada = new horasUsuario();
        static horasUsuario HorasUsuarioSegundaEntrada = new horasUsuario();
        static horasUsuario HorasUsuarioPrimeiraSaida = new horasUsuario();
        static horasUsuario HorasUsuarioSegundaSaida = new horasUsuario();
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
            retornoDadosUsuario = null;
            retornoDadosUsuario = RequestRhId.DadosUsuarioRhIdRequest(token: token);
            calcularHoras();
            lbBemVindo.Text = lbBemVindo.Text + " " + retornoDadosUsuario.nome;
            atribuirValorDasHoras();
            atribuirValorAosCampos();
            minimiarParaBarraEBandeja();
        }

        private void atribuirValorDasHoras()
        {
            if (retornoDadosUsuario.afdt.Count > 0)
            {
                HorasUsuarioPrimeiraEntrada.Ano = retornoDadosUsuario.afdt[0].dateTimeStr.Substring(0, 4);
                HorasUsuarioPrimeiraEntrada.Mes = retornoDadosUsuario.afdt[0].dateTimeStr.Substring(4, 2);
                HorasUsuarioPrimeiraEntrada.Dia = retornoDadosUsuario.afdt[0].dateTimeStr.Substring(6, 2);
                HorasUsuarioPrimeiraEntrada.Horas = retornoDadosUsuario.afdt[0].dateTimeStr.Substring(8, 2);
                HorasUsuarioPrimeiraEntrada.Minutos = retornoDadosUsuario.afdt[0].dateTimeStr.Substring(10, 2);
            }

            if (retornoDadosUsuario.afdt.Count > 1)
            {
                HorasUsuarioPrimeiraSaida.Ano = retornoDadosUsuario.afdt[1].dateTimeStr.Substring(0, 4);
                HorasUsuarioPrimeiraSaida.Mes = retornoDadosUsuario.afdt[1].dateTimeStr.Substring(4, 2);
                HorasUsuarioPrimeiraSaida.Dia = retornoDadosUsuario.afdt[1].dateTimeStr.Substring(6, 2);
                HorasUsuarioPrimeiraSaida.Horas = retornoDadosUsuario.afdt[1].dateTimeStr.Substring(8, 2);
                HorasUsuarioPrimeiraSaida.Minutos = retornoDadosUsuario.afdt[1].dateTimeStr.Substring(10, 2);
            }

            if (retornoDadosUsuario.afdt.Count > 2)
            {
                HorasUsuarioSegundaEntrada.Ano = retornoDadosUsuario.afdt[2].dateTimeStr.Substring(0, 4);
                HorasUsuarioSegundaEntrada.Mes = retornoDadosUsuario.afdt[2].dateTimeStr.Substring(4, 2);
                HorasUsuarioSegundaEntrada.Dia = retornoDadosUsuario.afdt[2].dateTimeStr.Substring(6, 2);
                HorasUsuarioSegundaEntrada.Horas = retornoDadosUsuario.afdt[2].dateTimeStr.Substring(8, 2);
                HorasUsuarioSegundaEntrada.Minutos = retornoDadosUsuario.afdt[2].dateTimeStr.Substring(10, 2);
            }

            if (retornoDadosUsuario.afdt.Count > 3)
            {
                HorasUsuarioSegundaSaida.Ano = retornoDadosUsuario.afdt[3].dateTimeStr.Substring(0, 4);
                HorasUsuarioSegundaSaida.Mes = retornoDadosUsuario.afdt[3].dateTimeStr.Substring(4, 2);
                HorasUsuarioSegundaSaida.Dia = retornoDadosUsuario.afdt[3].dateTimeStr.Substring(6, 2);
                HorasUsuarioSegundaSaida.Horas = retornoDadosUsuario.afdt[3].dateTimeStr.Substring(8, 2);
                HorasUsuarioSegundaSaida.Minutos = retornoDadosUsuario.afdt[3].dateTimeStr.Substring(10, 2);
            }

        }

        private void atribuirValorAosCampos()
        {
            mskBPrimeiraEntrada.Text = HorasUsuarioPrimeiraEntrada.Horas + ":" + HorasUsuarioPrimeiraEntrada.Minutos;



            if (mskBPrimeiraSaida.Text == null || mskBPrimeiraSaida.Text == "  :")
            {
                if (retornoDadosUsuario.afdt.Count > 1)
                {
                    mskBPrimeiraSaida.Text = HorasUsuarioPrimeiraSaida.Horas + ":" + HorasUsuarioPrimeiraSaida.Minutos;
                }
            }


            if (mskBSegundaEntrada.Text == null || mskBSegundaEntrada.Text == "  :")
            {
                if (retornoDadosUsuario.afdt.Count > 2)
                {
                    mskBSegundaEntrada.Text = HorasUsuarioSegundaEntrada.Horas + ":" + HorasUsuarioSegundaEntrada.Minutos;
                }
            }

            if (mskBSegundaSaida.Text == null || mskBSegundaSaida.Text == "  :")
            {
                if (retornoDadosUsuario.afdt.Count > 3)
                {
                    mskBSegundaSaida.Text = HorasUsuarioSegundaEntrada.Horas + ":" + HorasUsuarioSegundaEntrada.Minutos;
                }
            }
        }

        private void calcular_Horas()
        {
            atribuirValorAosCampos();
            token = formLogin.getValorToken();
            retornoDadosUsuario = null;
            retornoDadosUsuario = RequestRhId.DadosUsuarioRhIdRequest(token: token);
            calcularHoras();
        }

        private void calcularHoras()
        {

            string inicio_1 = mskBPrimeiraEntrada.Text;
            string inicio_2 = mskBSegundaEntrada.Text;
            inicio_1 = inicio_1 == null || inicio_1 == "  :" ? DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() : inicio_1;
            inicio_2 = inicio_2 == null || inicio_2 == "  :" ? DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() : inicio_2;

            string fim_1 = mskBPrimeiraSaida.Text;
            string fim_2 = mskBSegundaSaida.Text;
            fim_1 = fim_1 == null || fim_1 == "  :" ? DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() : fim_1;
            fim_2 = fim_2 == null || fim_2 == "  :" ? DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() : fim_2;
            string total;

            TimeSpan p1;
            TimeSpan p2;



            if (fim_1 != null && fim_1 != "  :"
                && inicio_1 != null && inicio_1 != "  :")
            {
                p1 = TimeSpan.Parse(fim_1).Subtract(TimeSpan.Parse(inicio_1));

                primeiroResultado.Text = p1.ToString();
            }

            if (fim_2 != null && fim_2 != "  :"
                && inicio_2 != null && inicio_2 != "  :")
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
                count3horas++;
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