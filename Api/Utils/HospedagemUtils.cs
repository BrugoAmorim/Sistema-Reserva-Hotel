using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Utils
{
    public class HospedagemUtils
    {
        public Models.Response.ReservaHotelResponse convertToRes(Models.TbClienteHospedagem tb){

            Models.Response.ReservaHotelResponse res = new Models.Response.ReservaHotelResponse(); 
            res.idreserva = tb.IdClienteHospedagem;
            res.idquarto = tb.IdQuarto;
            res.numQuarto = tb.IdQuartoNavigation.NrQuarto;
            res.estadia = tb.DtEstadia;
            res.qtdDias = tb.QtdDias;

            Models.Response.ClienteResponse cliente = new Models.Response.ClienteResponse();
            cliente.idcliente = tb.IdClienteNavigation.IdCliente;
            cliente.nome = tb.IdClienteNavigation.NmCliente;
            cliente.cpf = tb.IdClienteNavigation.DsCpf;
            cliente.celular = tb.IdClienteNavigation.NrCelular;
            cliente.email = tb.IdClienteNavigation.DsEmail;
            cliente.datanascimento = tb.IdClienteNavigation.DtNascimento;
            cliente.nacionalidade = tb.IdClienteNavigation.DsNacionalidade;

            res.cliente = cliente;
            return res;
        } 
    }
}