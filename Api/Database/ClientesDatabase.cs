using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Database
{
    public class ClientesDatabase
    {
        Models.DbhospedariaContext ctx = new Models.DbhospedariaContext();
        Utils.ClienteUtils conversor = new Utils.ClienteUtils();
        public Models.TbCliente GetCliente(int id){

            return ctx.TbClientes.FirstOrDefault(x => x.IdCliente == id);
        }

        public Models.TbCliente PostCliente(Models.Request.ClienteRequest req){

            Models.TbCliente tb = conversor.converToTable(req);            
            ctx.TbClientes.Add(tb);
            ctx.SaveChanges();
        
            return tb;
        }

        public Models.TbCliente GetClienteCpf(string cpf, string nome){

            Models.TbCliente getClt = ctx.TbClientes.FirstOrDefault(x => x.NmCliente == nome.Trim() && 
                                                                    x.DsCpf == cpf.Trim());            

            return getClt;
        }
    }
}