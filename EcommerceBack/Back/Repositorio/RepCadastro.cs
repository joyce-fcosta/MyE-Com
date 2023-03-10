using Cadastro.Base;
using Cadastro.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Repositorio
{
    internal class RepCadastro
    {
        Dao dao = null;
        public RepCadastro(Dao dao)
        {
            this.dao = dao;
        }
        public User CarregarUsuario(IDataReader dr)
        {
            try
            {
                return new User()
                {
                    Id = int.Parse(dr["id"].ToString()),
                    Name = Convert.ToString(dr["nome"]),
                    Senha = Convert.ToString(dr["senha"]),
                    Telefone = Convert.ToString(dr["telefone"]),

                    MeuEndereco = new Endereco()
                    {
                        Id = int.Parse(dr["end_id"].ToString()),
                        Rua = Convert.ToString(dr["rua"]),
                        Numero = Convert.ToString(dr["numero"]),
                        Complemento = Convert.ToString(dr["complemento"]),
                        Bairro = Convert.ToString(dr["bairro"]),
                        Cidade = Convert.ToString(dr["cidade"]),
                        Estado = Convert.ToString(dr["estado"]),
                        Cep = Convert.ToString(dr["cep"]),
                    }

                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Criar metodos para acessar a Dao
        public void CadatrarUsuario(User user)
        {
            try
            {
                dao.InsertUser(user);
/*                dao.AbrirConexao();
                dao.FecharConexao();*/
            }catch(Exception)
            {
                throw;
            }
        }        
        
        public void DeletarUsuario(int codigo)
        {
            try
            {
                dao.AbrirConexao();
                dao.DeletarUser(codigo);
                dao.FecharConexao();
            }catch(Exception)
            {
                throw;
            }
        }        
        
        public void AtualizarUsuario(int codigo,User user)
        {
           
            try
            {
                dao.AbrirConexao();
                dao.AtualizarUser(codigo, user);
                dao.FecharConexao();
            }catch(Exception)
            {
                throw;
            }
        }


    }
}
