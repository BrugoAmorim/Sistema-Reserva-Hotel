using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Database
{
    public class ClientesDatabase
    {
        Models.DbhospedariaContext ctx = new Models.DbhospedariaContext();

        public Models.TbCliente GetCliente(int id){

            return ctx.TbClientes.FirstOrDefault(x => x.IdCliente == id);
        }
    }
}