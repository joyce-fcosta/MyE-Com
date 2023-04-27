using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CadstroFrame.Classes
{
    public class EnderecoApiBrasil
    {
        public string cep { get; set; }

        public string state { get; set; }

        public string neighborhood { get; set; }

        public string street { get; set; }

        public string service { get; set; }

    }
}
