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
        [HttpPost("reservar/{idquarto}")]
        public Models.TbClienteHospedagem post_Reservarhospedagem(Models.Request.ClientenoRegRequest req, int idquarto){

            Models.DbhospedariaContext ctx = new Models.DbhospedariaContext();
            Business.ClientesBusiness validarcliente = new Business.ClientesBusiness();
            
            Models.TbClienteHospedagem hospedagem = new Models.TbClienteHospedagem();
        
            Models.TbQuarto quartoinfo = ctx.TbQuartos.FirstOrDefault(x => x.IdQuarto == idquarto);
            
            Models.TbClienteHospedagem host = ctx.TbClienteHospedagems
                                                 .Where(x => x.IdQuarto == idquarto)
                                                 .OrderBy(x => x.DtEstadia)
                                                 .LastOrDefault();

            if(idquarto <= 0 || quartoinfo == null)
                throw new ArgumentException("Quarto não encontrado");

            if(host != null){
                if(host.DtEstadia.AddDays(host.QtdDias + 2) >= req.estadia)            
                    throw new ArgumentException("Este quarto não vai estar disponivel nessa data");
            }

            Models.TbCliente novoClt = validarcliente.ValidarpostCliente(req.dadosCliente);

            hospedagem.IdQuarto = idquarto;
            hospedagem.IdCliente = novoClt.IdCliente;
            hospedagem.DtEstadia = req.estadia;
            hospedagem.QtdDias = req.qtdDias;

            ctx.TbClienteHospedagems.Add(hospedagem);
            ctx.SaveChanges();

            return hospedagem;
        }

        [HttpPost("agendar/{idcliente}/{idquarto}")]
        public void post_Agendarhospedagem(){


        }
    }
}