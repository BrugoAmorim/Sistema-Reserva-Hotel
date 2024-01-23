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
    }
}