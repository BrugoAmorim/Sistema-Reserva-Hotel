using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        [HttpGet("buscar/{idcliente}")]
        public Models.Response.ClienteResponse get_cliente(int idcliente){

            Models.DbhospedariaContext ctx = new Models.DbhospedariaContext();
            Utils.ClienteUtils conversor = new Utils.ClienteUtils();

            Models.Response.ClienteResponse caixa = conversor.converToRes(ctx.TbClientes.First(x => x.IdCliente == idcliente));

            return caixa;
        }
    }
}