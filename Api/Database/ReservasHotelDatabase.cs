using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api.Database
{
    public class ReservasHotelDatabase
    {
        Models.DbhospedariaContext ctx = new Models.DbhospedariaContext();
    
        public Models.TbQuarto get_quarto(int idquarto){

            return ctx.TbQuartos.FirstOrDefault(x => x.IdQuarto == idquarto);
        }

        public Models.TbClienteHospedagem get_ultimaReserva(int idquarto){

            return ctx.TbClienteHospedagems.Where(x => x.IdQuarto == idquarto)
                                           .OrderBy(x => x.DtEstadia)
                                           .LastOrDefault();
        }

        public Models.TbClienteHospedagem get_reserva(int idreserva){

            return ctx.TbClienteHospedagems.Include(x => x.IdQuartoNavigation)
                                           .Include(x => x.IdClienteNavigation)
                                           .First(x => x.IdClienteHospedagem == idreserva);
        }

        public Models.TbClienteHospedagem post_reservar(Models.TbCliente novoClt, DateTime estadia, int qtdDias, int idquarto){
        
            Models.TbClienteHospedagem hospedagem = new Models.TbClienteHospedagem();
            hospedagem.IdQuarto = idquarto;
            hospedagem.IdCliente = novoClt.IdCliente;
            hospedagem.DtEstadia = estadia;
            hospedagem.QtdDias = qtdDias;

            ctx.TbClienteHospedagems.Add(hospedagem);
            ctx.SaveChanges();

            return get_reserva(hospedagem.IdClienteHospedagem);
        }
    }
}