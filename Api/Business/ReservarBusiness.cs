using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Business
{
    public class ReservarBusiness
    {
        Business.ClientesBusiness validarcliente = new Business.ClientesBusiness();
        Database.ReservasHotelDatabase dbReservas = new Database.ReservasHotelDatabase(); 
        Database.ClientesDatabase dbClientes = new Database.ClientesDatabase();

        public Models.TbClienteHospedagem ValidarpostReservar(Models.Request.ClientenoRegRequest req, int idquarto){
                    
            Models.TbQuarto quartoinfo = dbReservas.get_quarto(idquarto);
            Models.TbClienteHospedagem host = dbReservas.get_ultimaReserva(idquarto);

            validarCampos(idquarto, req.qtdDias, req.estadia);

            Models.TbCliente novoClt = validarcliente.ValidarpostCliente(req.dadosCliente);
            Models.TbClienteHospedagem reservaSalva = dbReservas.post_reservar(novoClt, req.estadia, req.qtdDias, idquarto);

            return reservaSalva;
        }

        public Models.TbClienteHospedagem ValidarpostAgendar(Models.Request.ClienteRegRequest req, int idquarto){

            if(string.IsNullOrEmpty(req.nomeCliente))
                throw new ArgumentException("Campo nome do cliente inválido");
                
            if(string.IsNullOrEmpty(req.cpfCliente))
                throw new ArgumentException("Campo cpf do cliente inválido");

            Models.TbCliente infoClt = dbClientes.GetClienteCpf(req.cpfCliente, req.nomeCliente);

            if(infoClt == null)
                throw new ArgumentException("Os dados deste cliente não foram encontrados");

            validarCampos(idquarto, req.qtdDias, req.estadia);

            Models.TbClienteHospedagem bruto = dbReservas.post_agendar(req, idquarto, infoClt.IdCliente);
            return bruto;
        }

        private void validarCampos(int idquarto, int qtdDias, DateTime estadia){

            Models.TbQuarto quartoinfo = dbReservas.get_quarto(idquarto);      
            Models.TbClienteHospedagem host = dbReservas.get_ultimaReserva(idquarto);
            
            if(qtdDias <= 0)
                throw new ArgumentException("Campo quantidade de dias inválido");

            if(idquarto <= 0 || quartoinfo == null)
                throw new ArgumentException("Quarto não encontrado");
      
            if(host != null){
                if(host.DtEstadia.AddDays(host.QtdDias + 2) >= estadia)            
                    throw new ArgumentException("Este quarto não vai estar disponivel nessa data");
            }
        }
    }
}