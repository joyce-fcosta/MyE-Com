using CadstroFrame.Base;
using CadstroFrame.Classes;
using CadstroFrame.Repositorio;
using System;


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
    }
}
