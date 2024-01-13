using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        Business.ClientesBusiness validar = new Business.ClientesBusiness();
        Utils.ClienteUtils conversor = new Utils.ClienteUtils();

        [HttpGet("buscar/{idcliente}")]
        public ActionResult<Models.Response.ClienteResponse> get_cliente(int idcliente){

            try{
                Models.TbCliente bruto = validar.ValidargetCliente(idcliente);
                Models.Response.ClienteResponse res = conversor.converToRes(bruto);

                return res;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 404)
                );
            }
        }

        [HttpPost("novo")]
        public Models.Response.ClienteResponse post_newCliente(Models.Request.ClienteRequest req){

            Models.TbCliente bruto = validar.ValidarpostCliente(req);
            Models.Response.ClienteResponse res = conversor.converToRes(bruto);

            return res;
        }
    }
}