using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api.Database
{
    public class ReservasHotelDatabase
    {
        Utils.HospedagemUtils conversor = new Utils.HospedagemUtils();
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
        
            Models.TbClienteHospedagem hospedagem = conversor.convertCltNoReqToTb(novoClt, idquarto, estadia, qtdDias);
            ctx.TbClienteHospedagems.Add(hospedagem);
            ctx.SaveChanges();

            return get_reserva(hospedagem.IdClienteHospedagem);
        }

        public Models.TbClienteHospedagem post_agendar(Models.Request.ClienteRegRequest req, int idroom, int idcliente){

            Models.TbClienteHospedagem newhost = conversor.convertCltReqToTb(req, idroom, idcliente);
            ctx.TbClienteHospedagems.Add(newhost);
            ctx.SaveChanges();

            return get_reserva(newhost.IdClienteHospedagem);
        }
    }
}