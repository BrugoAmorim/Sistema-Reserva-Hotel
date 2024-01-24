using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Response
{
    public class QuartoDisponivelResponse
    {
        public int idquarto { get; set; }
        public string numero { get; set; }
        public string tipo { get; set; }
        public DateTime disponivelEm { get; set; }
    }
}