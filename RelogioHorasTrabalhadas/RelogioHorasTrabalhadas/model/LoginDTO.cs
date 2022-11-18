using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelogioHorasTrabalhadas
{
    public class LoginResponseDTO
    {
        public string accessToken { get; set; }
    }

    public class LoginRequestDTO
    {
        public string domain { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }

    public class DadosDiariosDTO
    {
        public retornoDto retorno { get; set; }
    }
    
    public class retornoDto
    {
        public List<afdtt> afdt { get; set; }
        public string dateTime { get; set; }
        public int faltas { get; set; }
        public int horasExtrasMaisBanco { get; set; }
        public int horasFaltaMaisBanco { get; set; }
        public string nome { get; set; }
        public int saldo { get; set; }
        public int totalHorasTrabalhadas { get; set; }

    }

    public class afdtt
    {
        public string _typeEntradaSaida { get; set; }
        public string dateTimeStr { get; set; }
        public string seqEmpregadoJornada { get; set; }
    }

    public class horasUsuario
    {
        public string Ano { get; set; }
        public string Dia { get; set; }
        public string Mes { get; set; }
        public string Anos { get; set; }
        public string Horas { get; set; }
        public string Minutos { get; set; }
    }
}
