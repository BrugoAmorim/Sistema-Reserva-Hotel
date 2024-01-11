using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Business
{
    public class ClientesBusiness
    {
        Database.ClientesDatabase dbcliente = new Database.ClientesDatabase();

        public Models.TbCliente ValidargetCliente(int idcliente){

            if(idcliente <= 0)
                throw new ArgumentException("Insira um id válido");

            Models.TbCliente cltvalido = dbcliente.GetCliente(idcliente);

            if(cltvalido == null)
                throw new ArgumentException("Cliente não encontrado");

            return cltvalido;
        }
    }
}