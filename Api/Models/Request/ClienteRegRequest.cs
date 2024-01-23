using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Request
{
    public class ClienteRegRequest
    {
        public string nomeCliente { get; set; }
        public string cpfCliente { get; set; }
        public int qtdDias { get; set; }
        public DateTime estadia { get; set; }
    }
}