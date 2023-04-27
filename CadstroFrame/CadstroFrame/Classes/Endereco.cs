using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadstroFrame.Classes
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public EnderecoApiBrasil enderecoApiBrasil { get; set; } = new EnderecoApiBrasil();

    }
}
