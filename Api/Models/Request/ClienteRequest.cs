using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Request
{
    public class ClienteRequest
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public DateTime datanascimento { get; set; }
        public string nacionalidade { get; set; }
    }
}