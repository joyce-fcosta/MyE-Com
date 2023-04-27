using CadstroFrame.Base;
using CadstroFrame.Classes;
using CadstroFrame.Repositorio;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CadstroFrame.Manutencao
{
    public class Cadastro
    {
        public void InserirUser(User user)
        {
            Dao dao = new Dao();
            RepCadastro repositorioCad = new RepCadastro(dao);
            try
            {
                dao.AbrirConexao();
                repositorioCad.CadatrarUsuario(user);
                dao.FecharConexao();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EnderecoApiBrasil> ConsultaPorCep(string cep)
        {

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://brasilapi.com.br/api/cep/v1/{cep}"); 
            var jsonString = await response.Content.ReadAsStringAsync(); 
            EnderecoApiBrasil jsonObject = JsonConvert.DeserializeObject<EnderecoApiBrasil>(jsonString); 

            return jsonObject;
        }

        public void EnderecoInserido(EnderecoApiBrasil endApi, string numero)
        {

        }
    }
}
