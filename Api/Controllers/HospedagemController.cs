using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HospedagemController : ControllerBase
    {
        Business.ReservarBusiness validar = new Business.ReservarBusiness();
        Utils.HospedagemUtils conversor = new Utils.HospedagemUtils();

        [HttpPost("reservar/{idquarto}")]
        public ActionResult<Models.Response.ReservaHotelResponse> post_Reservarhospedagem(Models.Request.ClientenoRegRequest req, int idquarto){

            try{
                Models.TbClienteHospedagem reserva = validar.ValidarpostReservar(req, idquarto);
                Models.Response.ReservaHotelResponse caixote = conversor.convertToRes(reserva);

                return caixote;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 404)
                );
            }
        }

        [HttpPost("agendar/{idquarto}")]
        public Models.TbClienteHospedagem post_Agendarhospedagem(Models.Request.ClienteRegRequest req, int idquarto){

            Models.DbhospedariaContext ctx = new Models.DbhospedariaContext();

            Models.TbCliente getClt = ctx.TbClientes.FirstOrDefault(x => x.NmCliente == req.nomeCliente.Trim() && x.DsCpf == req.cpfCliente.Trim());            

            if(getClt == null)
                throw new ArgumentException("Os dados deste cliente não foram encontrados");

            Models.TbClienteHospedagem novaReserva = new Models.TbClienteHospedagem();
            novaReserva.DtEstadia = req.estadia;
            novaReserva.IdQuarto = idquarto;
            novaReserva.QtdDias = req.qtdDias;
            novaReserva.IdCliente = getClt.IdCliente;

            ctx.TbClienteHospedagems.Add(novaReserva);
            ctx.SaveChanges();

            return novaReserva;
        }
    }
}