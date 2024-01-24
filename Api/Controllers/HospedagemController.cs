using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<Models.Response.ReservaHotelResponse> post_Agendarhospedagem(Models.Request.ClienteRegRequest req, int idquarto){

            try{
                Models.TbClienteHospedagem bruto = validar.ValidarpostAgendar(req, idquarto);
                Models.Response.ReservaHotelResponse caixote = conversor.convertToRes(bruto);

                return caixote;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 404)
                );
            }
        }

        [HttpGet("dataDisp/{idquarto}")]
        public Models.Response.QuartoDisponivelResponse get_DataDisponivel(int idquarto){

            Models.DbhospedariaContext ctx = new Models.DbhospedariaContext();
            Models.TbClienteHospedagem getRoom = ctx.TbClienteHospedagems.Include(x => x.IdQuartoNavigation)
                                                                         .Where(x => x.IdQuarto == idquarto)
                                                                         .OrderBy(x => x.DtEstadia)
                                                                         .LastOrDefault();

            int idhosp = getRoom.IdQuartoNavigation.IdHospedagem;

            Models.Response.QuartoDisponivelResponse qt = new Models.Response.QuartoDisponivelResponse();
            qt.idquarto = getRoom.IdQuarto;
            qt.numero = getRoom.IdQuartoNavigation.NrQuarto;
            qt.tipo = ctx.TbHospedagems.First(x => x.IdHospedagem == idhosp).DsTipoHospedagem;
            qt.disponivelEm = getRoom.DtEstadia.AddDays(getRoom.QtdDias + 2);

            return qt;
        }
    }
}