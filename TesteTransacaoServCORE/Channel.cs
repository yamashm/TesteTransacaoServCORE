using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteTransacaoServCORE
{
    public class Channel
    {
        public string ID_CHANNEL { get; set; }
        public string DESCRIPTION { get; set; }

        public Channel(string ID_CHANNEL, string DESCRIPTION)
        {
            this.ID_CHANNEL = ID_CHANNEL;
            this.DESCRIPTION = DESCRIPTION;
        }

        public override string ToString()
        {
            return ID_CHANNEL + " " + DESCRIPTION;
        }
    }
}
