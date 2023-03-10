using Cadastro.Base;
using Cadastro.Classes;
using Cadastro.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Manutencao
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
            }catch(Exception)
            {
                throw;
            }
            }
    }
}
