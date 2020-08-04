using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteTransacaoServCORE
{
    public class Conexao
    {
        public string server { get; set; }
        public string database { get; set; }
        public string user { get; set; }
        public string password { get; set; }

        public Conexao()
        {
        }

        public override string ToString()
        {
            return server + " - " + database;
        }
    }
}
