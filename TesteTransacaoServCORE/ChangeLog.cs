using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteTransacaoServCORE
{
    public class ChangeLog
    {
        public string SCRIPT_NAME { get; set; }
        public string PACKAGE_VERSION { get; set; }
        public string STATUS { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string TS_CREATED { get; set; }

        public override string ToString()
        {
            return SCRIPT_NAME + "_" + PACKAGE_VERSION + "_" + STATUS;
        }
    }
}
