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

        public Models.TbClienteHospedagem ValidarpostReservar(Models.Request.ClientenoRegRequest req, int idquarto){
                    
            Models.TbQuarto quartoinfo = dbReservas.get_quarto(idquarto);
            Models.TbClienteHospedagem host = dbReservas.get_ultimaReserva(idquarto);

            if(idquarto <= 0 || quartoinfo == null)
                throw new ArgumentException("Quarto não encontrado");

            if(req.qtdDias <= 0)
                throw new ArgumentException("Campo quantidade de dias inválido");

            if(host != null){
                if(host.DtEstadia.AddDays(host.QtdDias + 2) >= req.estadia)            
                    throw new ArgumentException("Este quarto não vai estar disponivel nessa data");
            }

            Models.TbCliente novoClt = validarcliente.ValidarpostCliente(req.dadosCliente);
            Models.TbClienteHospedagem reservaSalva = dbReservas.post_reservar(novoClt, req.estadia, req.qtdDias, idquarto);

            return reservaSalva;
        }
    }
}