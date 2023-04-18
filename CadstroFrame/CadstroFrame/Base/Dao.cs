using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CadstroFrame.Classes;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;


namespace CadstroFrame.Base
{
    public class Dao
    {
        //Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
        //@"Data Source = JOYCE\\SQLECOMMERCE; Initial Catalog = bancoecommerce; Integrated Security = True"
        internal MySqlConnection Con { get; set; } = new MySqlConnection(@"Server=3.82.141.205; Port=3306; Database=ECOMMERCE; Uid=admjoyce; Pwd=admin;");

        internal void AbrirConexao()
        {
            try
            {
                if (Con.State == System.Data.ConnectionState.Closed)
                {
                    Con.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void FecharConexao()
        {
            try
            {
                if (Con.State == System.Data.ConnectionState.Open)
                {
                    Con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Cadastro do usuário
        internal void InsertUser(User user)
        {
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string sql;

            try
            {
                sql = "INSERT INTO usuario(nome,telefone,senha,endereco_id) " +
                      "VALUES ('" + user.Name + "', '" + user.Telefone + "', '" + user.Senha + "', " + user.MeuEndereco.Id + ");";
                command = new MySqlCommand(sql, Con);
                adapter.InsertCommand = new MySqlCommand(sql, Con);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Usar para quando o usuário for logar e mostrar informações no perfil
        internal MySqlDataReader PegarUser(int idUser)
        {
            MySqlCommand command = null;
            string sql;
            try
            {
                sql = "SELECT id,nome,telefone,senha,end_id,rua,numero,complemento,cidade,estado,cep" +
                      "FROM endereco " +
                      "INNER JOIN usuario ON endereco.end_id = usuario.endereco" +
                      "WHERE id = " + idUser;
                command = new MySqlCommand(sql, Con);
                return command.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Dispose();
            }
        }
        //Deletar usuário 
        internal void DeletarUser(int idUser)
        {
            MySqlCommand command = null;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string sql = "";
            try
            {
                sql = $"DELETE FROM usuario WHERE id={idUser}";
                command = new MySqlCommand(sql, Con);
                adapter.DeleteCommand = new MySqlCommand(sql, Con);
                adapter.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Dispose();
            }
        }

        //Atualizar informações do usuário
        public void AtualizarUser(int idUser, User user)
        {
            MySqlCommand command = null;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string sql = "";
            sql = "UPDATE usuario SET " +
                "nome = '" + user.Name + "', " + "telefone='" + user.Telefone + "', " + "senha='" + user.Senha + "'" +
                "WHERE id ='" + user.Id + "'";
            command = new MySqlCommand(sql, Con);
            try
            {
                adapter.UpdateCommand = new MySqlCommand(sql, Con);
                adapter.UpdateCommand.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Dispose();
            }

        }

        internal void AtualizaEndereco(User user)
        {
            MySqlCommand command = null;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string sql = "";

            sql = "UPDATE endereco SET rua='" + user.MeuEndereco.Rua + "', " + "numero='" + user.MeuEndereco.Numero + "', "
                + "complemento='" + user.MeuEndereco.Complemento + "', " + "cidade='" + user.MeuEndereco.Cidade + "', "
                + "estado='" + user.MeuEndereco.Estado + "', " + "cep='" + user.MeuEndereco.Cep
                + "WHERE end_id='" + user.IdEndereco + "'";
            command = new MySqlCommand(sql, Con);
            try
            {
                adapter.UpdateCommand = new MySqlCommand();
                adapter.UpdateCommand.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Dispose();
            }


        }



    }
}
