using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteTransacaoServCORE
{
    public class InstituicaoFinanceira
    {
        public string ID_IF { get; set; }
        public string SHORT_NAME { get; set; }

        public InstituicaoFinanceira(string ID_CHANNEL, string SHORT_NAME)
        {
            this.ID_IF = ID_CHANNEL;
            this.SHORT_NAME = SHORT_NAME;
        }

        public override string ToString()
        {
            return ID_IF + " " + SHORT_NAME;
        }
    }
}
