using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Request
{
    public class ClientenoRegRequest
    {
        public DateTime estadia { get; set; }
        public int qtdDias { get; set; }
        public Models.Request.ClienteRequest dadosCliente { get; set; }
    }
}