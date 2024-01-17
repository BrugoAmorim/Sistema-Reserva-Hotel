using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Utils
{
    public class ClienteUtils
    {
        public Models.Response.ClienteResponse converToRes(Models.TbCliente tb){

            Models.Response.ClienteResponse clt = new Models.Response.ClienteResponse();
            clt.idcliente = tb.IdCliente;
            clt.nome = tb.NmCliente;
            clt.cpf = tb.DsCpf;
            clt.celular = tb.NrCelular;
            clt.email = tb.DsEmail;
            clt.datanascimento = tb.DtNascimento;
            clt.nacionalidade = tb.DsNacionalidade;
        
            return clt;
        }

        public Models.TbCliente converToTable(Models.Request.ClienteRequest req){

            Models.TbCliente modelTb = new Models.TbCliente();
            modelTb.NmCliente = req.nome.Trim();
            modelTb.DsCpf = req.cpf;
            modelTb.NrCelular = req.celular;
            modelTb.DsEmail = req.email;
            modelTb.DtNascimento = req.datanascimento;
            modelTb.DsNacionalidade = req.nacionalidade;

            return modelTb;
        }
    }
}