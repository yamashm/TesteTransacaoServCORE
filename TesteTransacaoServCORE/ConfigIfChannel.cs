using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteTransacaoServCORE
{
    [Serializable]
    public class ConfigIfChannel
    {
        public string KEY_CONFIG { get; set; }
        public string PARAM_TYPE { get; set; }
        public string VALIDATION { get; set; }
        public string RESULT_EVAL { get; set; }
        public string ID_IF { get; set; }
        public string ID_CHANNEL { get; set; }
        public string DESCRIPTION { get; set; }
        public string ENABLED { get; set; }
        public string PARAM_GROUP { get; set; }
        public string VALUE { get; set; }

        public string Nova()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Remove())
                .Append("\r\n");

            sb.Append(Insere())
                .Append("\r\n");

            return sb.ToString();
        }

        public string Insere()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO TB_CONFIG_IF_CHANNEL (KEY_CONFIG,PARAM_TYPE,VALIDATION,RESULT_EVAL,ID_IF,ID_CHANNEL,DESCRIPTION,ENABLED,PARAM_GROUP,VALUE)")
            .Append(" VALUES ('")
            .Append(KEY_CONFIG).Append("',")
            .Append(Util.TrataVarcharNULL(PARAM_TYPE)).Append(",'")
            .Append(VALIDATION).Append("',")
            .Append(Util.TrataVarcharNULL(RESULT_EVAL)).Append(",")
            .Append(ID_IF).Append(",")
            .Append(ID_CHANNEL).Append(",")
            .Append(Util.TrataVarcharNULL(DESCRIPTION)).Append(",")
            .Append(Util.TrataVarcharNULL(ENABLED)).Append(",")
            .Append(Util.TrataVarcharNULL(PARAM_GROUP)).Append(",'")
            .Append(VALUE).Append("');")
            .Append("\r\n");

            return sb.ToString();
        }

        public string Remove()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("DELETE TB_CONFIG_IF_CHANNEL WHERE KEY_CONFIG = '")
                .Append(KEY_CONFIG).Append("';")
            .Append("\r\n");

            return sb.ToString();
        }

        public string Atualiza()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE TB_CONFIG_IF_CHANNEL SET PARAM_TYPE = ")
            .Append(Util.TrataVarcharNULL(PARAM_TYPE)).Append(",")
            .Append("VALIDATION = '")
            .Append(VALIDATION).Append("',")
            .Append("RESULT_EVAL = ")
            .Append(Util.TrataVarcharNULL(RESULT_EVAL)).Append(",")
            .Append("ID_IF = ")
            .Append(ID_IF).Append(",")
            .Append("ID_CHANNEL = ")
            .Append(ID_CHANNEL).Append(",")
            .Append("DESCRIPTION = ")
            .Append(Util.TrataVarcharNULL(DESCRIPTION)).Append(",")
            .Append("ENABLED = ")
            .Append(Util.TrataVarcharNULL(ENABLED)).Append(",")
            .Append("PARAM_GROUP = ")
            .Append(Util.TrataVarcharNULL(PARAM_GROUP)).Append(",")
            .Append("VALUE = '")
            .Append(VALUE).Append("' ")
            .Append("WHERE KEY_CONFIG = '")
            .Append(KEY_CONFIG).Append("';")
            .Append("\r\n");

            return sb.ToString();
        }

        public override string ToString()
        {
            return KEY_CONFIG;
        }
    }
}
