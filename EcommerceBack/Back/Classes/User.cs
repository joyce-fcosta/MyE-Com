namespace Cadastro.Classes
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public Endereco MeuEndereco { get; set; } = new Endereco();

    }
}