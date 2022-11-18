using Newtonsoft.Json;
using RelogioHorasTrabalhadas.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelogioHorasTrabalhadas
{
    public partial class login : Form
    {
        
        static readonly HttpClient client = new HttpClient();
        static readonly string url = "https://www.rhid.com.br/v2/login.svc/";
        static string token;


        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmail.Text) &&
                string.IsNullOrEmpty(tbSenha.Text))
            {
                MessageBox.Show("PREENCHA USUUARIO E SENHA", "PREENCHA USUUARIO E SENHA", MessageBoxButtons.OK);
            }
            else
            {
                token = RequestRhId.LoginRequest(email: tbEmail.Text, senha: tbSenha.Text).Result;
                this.Close();
            }
        }

        public string getValorEmail()
        {
            return tbEmail.Text;
        }

        public string getValorSenhal()
        {
            return tbSenha.Text;
        }

        public string getValorToken()
        {
            return token;
        }
    }
}
