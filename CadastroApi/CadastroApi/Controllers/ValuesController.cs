using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CadstroFrame.Manutencao;
using CadstroFrame.Classes;

namespace CadastroApi.Controllers
{
    public class ValuesController : ApiController
    {
        [AcceptVerbs("POST"), Route("api/Cadastro/")]
        [HttpPost]

        //string nome,string senha,string telefone,int IdEndereco
        public HttpResponseMessage InserirCadastro(User user)
        {
            try
            {
                
                Cadastro cadastrar = new Cadastro();
                cadastrar.InserirUser(user);
                return Request.CreateResponse("Usuário inserido com sucesso.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
