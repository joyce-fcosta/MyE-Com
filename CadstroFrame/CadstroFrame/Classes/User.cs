namespace CadstroFrame.Classes
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public int IdEndereco { get; set; }
        public Endereco MeuEndereco { get; set; } = new Endereco();
        /* public string Email { get; set; }
         public string DataNascimento { get; set; }
         public string Cpf { get; set; }*/


    }
}