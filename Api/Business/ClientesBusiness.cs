using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Business
{
    public class ClientesBusiness
    {
        SpecialFieldsValidation specialValidation = new SpecialFieldsValidation();
        Database.ClientesDatabase dbcliente = new Database.ClientesDatabase();

        public Models.TbCliente ValidargetCliente(int idcliente){

            if(idcliente <= 0)
                throw new ArgumentException("Insira um id válido");

            Models.TbCliente cltvalido = dbcliente.GetCliente(idcliente);

            if(cltvalido == null)
                throw new ArgumentException("Cliente não encontrado");

            return cltvalido;
        }

        public Models.TbCliente ValidarpostCliente(Models.Request.ClienteRequest req){

            if(string.IsNullOrEmpty(req.nome))
                throw new ArgumentException("Campo nome inválido");
                
            if(string.IsNullOrEmpty(req.nacionalidade))
                throw new ArgumentException("Campo nacionalidade inválido");

            if(specialValidation.validaCPF(req.cpf) == false)
                throw new ArgumentException("Campo CPF inválido");
                
            if(specialValidation.ValidaEmail(req.email) == false)
                throw new ArgumentException("Campo email inválido");

            if(specialValidation.ValidaformatoData(req.datanascimento.ToString()) == false)
                throw new ArgumentException("Campo data de nascimento inválido");
                
            if(req.celular.Length < 11 || req.celular.Length > 13)
                throw new ArgumentException("Campo número de telefone inválido");

            Models.TbCliente bruto = dbcliente.PostCliente(req);
            return bruto;
        }
    }
}