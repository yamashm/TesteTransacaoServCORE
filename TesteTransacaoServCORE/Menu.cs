using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteTransacaoServCORE
{
    public class Menu
    {
        public string ID_MENU { get; set; }
        public string ID_MENU_PARENT { get; set; }
        public string ID_CHANNEL { get; set; }
        public string ID_TRANSACTION { get; set; }
        public string DESCRIPTION { get; set; }
        public string ACTION { get; set; }
        public string ID_IMG { get; set; }
        public string LEVEL_MENU { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string DATA { get; set; }
        public string STATUS { get; set; }

        public override string ToString()
        {
            return new StringBuilder(ID_MENU).Append(": ").Append(DESCRIPTION).Append("(").Append(ID_TRANSACTION).Append(")").ToString();
        }

        public string Atualiza()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE TB_MENU SET ID_MENU_PARENT = ")
                  .Append(ID_MENU_PARENT)
                  .Append(", ")
                  .Append("ID_TRANSACTION = ")
               .Append(ID_TRANSACTION)
               .Append(", ")
               .Append("DESCRIPTION = '")
               .Append(DESCRIPTION)
               .Append("', ")
               .Append("ACTION = ")
               .Append(Util.TrataVarcharNULL(ACTION))
               .Append(", ")
               .Append("ID_IMG = ")
               .Append(ID_IMG)
               .Append(", ")
               .Append("LEVEL_MENU = ")
               .Append(LEVEL_MENU)
               .Append(", ")
               .Append("ORDER_NUMBER = ")
               .Append(ORDER_NUMBER)
               .Append(", ")
               .Append("DATA = ")
               .Append(Util.TrataVarcharNULL(DATA))
               .Append(" ")
               .Append("WHERE ID_MENU = '")
               .Append(ID_MENU)
               .Append("'; ")
               .Append("\r\n");

            return sb.ToString();
        }
    }
}
