using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Response
{
    public class ClienteResponse
    {
        public int idcliente { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public DateOnly datanascimento { get; set; }
        public string nacionalidade { get; set; }
    }
}