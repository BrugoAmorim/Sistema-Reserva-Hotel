using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Request
{
    public class ClienteRegRequest
    {
        public string cpfcliente { get; set; }
        public int idquarto { get; set; }
        public int qtdDias { get; set; }
        public DateTime estadia { get; set; }
    }
}