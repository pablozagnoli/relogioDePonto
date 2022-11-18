using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace RelogioHorasTrabalhadas.Services
{
    public class RequestRhId
    {
        static readonly HttpClient client = new HttpClient();
        static readonly string urlToken = "https://www.rhid.com.br/v2/login.svc/";
        static readonly string urlDados = "https://www.rhid.com.br/v2/mobile.svc/ponto_diario";

        public static async Task<string> LoginRequest(string email, string senha)
        {
            try
            {
                var loginRequestDTO = new LoginRequestDTO();

                loginRequestDTO.email = email;
                loginRequestDTO.password = senha;
                string jsonloginRequest = JsonConvert.SerializeObject(loginRequestDTO);

                HttpResponseMessage response = client.PostAsync(urlToken, new StringContent(jsonloginRequest, Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<LoginResponseDTO>(responseBody).accessToken;
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show(e.Message, e.Message, MessageBoxButtons.OK);
                return "";
            }
        }

        public static retornoDto DadosUsuarioRhIdRequest(string token)
        {
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, urlDados))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = client.SendAsync(request).Result;

                    response.EnsureSuccessStatusCode();

                    var responseDadosDiarios = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<DadosDiariosDTO>(responseDadosDiarios).retorno;

                }
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show(e.Message, e.Message, MessageBoxButtons.OK);
                return new retornoDto();
            }
        }

    }
}
