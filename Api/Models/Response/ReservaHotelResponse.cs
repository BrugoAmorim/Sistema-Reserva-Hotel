using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Response
{
    public class ReservaHotelResponse
    {
        public int idreserva { get; set; } 
        public int idquarto { get; set; }
        public string numQuarto { get; set; }
        public DateTime estadia { get; set; }
        public int qtdDias { get; set; }
        public Models.Response.ClienteResponse cliente { get; set; }
    }
}