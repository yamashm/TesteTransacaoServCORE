using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteTransacaoServCORE
{
    public class Transacao
    {
        public string ID_TRANSACTION { get; set; }
        public string DESCRIPTION { get; set; }
        public string STATUS { get; set; }
        public string DATE_LAST_UPDATED { get; set; }
        public string ID_TRN_GROUP { get; set; }
        public string SHORT_DESCRIPTION { get; set; }
        public string CATEGORY { get; set; }
        public string ID_CHANNEL { get; set; }
        public string ID_CHANNEL_2 { get; set; }
        public string ID_IF { get; set; }
        public string ID_IF_2 { get; set; }
        public List<TransactionProcess> Processos { get; set; }
        public List<string> SeqFlowsInput { get; set; }
        public List<string> SeqFlowsOutput { get; set; }
        public List<EntradaSaida> Entradas { get; set; }
        public List<EntradaSaida> Saidas { get; set; }
        public bool PERMITE_EDICAO { get; set; }
        public Menu TB_MENU { get; set; }
        public bool NOVA { get; set; }
        public bool SELECIONADA { get; set; }

        public string Nova(bool incluiTransaction, 
            bool incluiProcess, 
            bool editaInputOutput, 
            bool incluiMenu, 
            bool incluiPermission, 
            bool incluiCHNTRN, 
            bool incluiIFTRNCHN)
        {
            StringBuilder sb = new StringBuilder();

            if (incluiTransaction)// || NOVA)
            {
                sb.Append("INSERT INTO TB_TRANSACTION (ID_TRANSACTION, DESCRIPTION, STATUS, DATE_LAST_UPDATED, ID_TRN_GROUP, SHORT_DESCRIPTION, CATEGORY)VALUES(")
                .Append(ID_TRANSACTION).Append(",")
                .Append("'")
                .Append(DESCRIPTION).Append("',")
                .Append("'A'").Append(",")
                .Append("NULL").Append(",")
                .Append(ID_TRN_GROUP).Append(",")
                .Append(Util.TrataVarcharNULL(SHORT_DESCRIPTION)).Append(",'")
                .Append(CATEGORY).Append("');")
                .Append("\r\n");
            }

            if (incluiCHNTRN)
            {
                sb.Append("INSERT INTO TB_CHANNEL_TRANSACTION (ID_CHANNEL, ID_TRANSACTION, STATUS) VALUES (")
                    .Append(ID_CHANNEL).Append(",")
                   .Append(ID_TRANSACTION).Append(",")
                   .Append("'A'").Append(");")
                   .Append("\r\n");
            }

            if (incluiIFTRNCHN)
            {
                sb.Append("INSERT INTO TB_IF_CHN_TRN (ID_IF, ID_CHANNEL, ID_TRANSACTION, STATUS) VALUES (")
                    .Append(ID_IF).Append(",")
                 .Append(ID_CHANNEL).Append(",")
                 .Append(ID_TRANSACTION).Append(",")
                 .Append("'A'").Append(");")
                 .Append("\r\n");
            }

            if (incluiPermission)
            {
                sb.Append("INSERT INTO TB_TRANSACTION_PERMISSION (ID_IF, ID_CHANNEL, ID_TRANSACTION, ID_LEVEL, TYPE_TRANSACTION, REVERSABLE, LOG_AUDIT, LOG_UNIQUE, LOG_ACCOUNT, RECEIPT, SCHEDULED, QT_FLOW, ID_INTEGRATOR, ID_DATA_FORMAT, AUTH, CYCLE_SERVICE, LOG_AUTH, POSITIVATE, TIMEOUT_SCREEN_MS, LOG_ADM, DATA_COMPRESS) VALUES(")
                .Append(ID_IF).Append(",")
                .Append(ID_CHANNEL).Append(",")
                .Append(ID_TRANSACTION).Append(",")
                .Append("'1'").Append(",")
                .Append("'N'").Append(",")
                .Append("'N'").Append(",")
                .Append("'Y'").Append(",")
                .Append("'N'").Append(",")
                .Append("'N'").Append(",")
                .Append("'N'").Append(",")
                .Append("'N'").Append(",")
                .Append("'1'").Append(",")
                .Append("'2'").Append(",")
                .Append("'2'").Append(",")
                .Append("'N'").Append(",")
                .Append("'N'").Append(",")
                .Append("'N'").Append(",")
                .Append("'0'").Append(",")
                .Append("'0'").Append(",")
                .Append("'N'").Append(",")
                .Append("'N'").Append(");")
                .Append("\r\n");
            }

            if (incluiProcess)
            {
                foreach (TransactionProcess p in Processos)
                {
                    sb.Append("INSERT INTO TB_TRANSACTION_PROCESS (ID_IF, ID_CHANNEL, ID_TRANSACTION, SEQ_FLOW, ID_PROCESS) VALUES(")
                    .Append(ID_IF_2).Append(",")
                    .Append(ID_CHANNEL).Append(",")
                    .Append(ID_TRANSACTION).Append(",")
                    .Append(p.SEQ_FLOW).Append(",")
                    .Append(p.ID_PROCESS).Append(");")
                    .Append("\r\n");
                }
            }

            if (editaInputOutput)
            {

                foreach (EntradaSaida e in Entradas)
                {
                    sb.Append("INSERT INTO TB_TRANSACTION_INPUT (ID_IF, ID_CHANNEL, ID_TRANSACTION, SEQ_FLOW, ENV_NAME, LOGICAL_EVALUATION, DATA_TYPE, ORDER_NUMBER) VALUES(")
                .Append(ID_IF_2).Append(",")
               .Append(ID_CHANNEL_2).Append(",")
               .Append(ID_TRANSACTION).Append(",")
               .Append(e.SEQ_FLOW).Append(",'")
               .Append(e.ENV_NAME).Append("','")
               .Append(e.LOGICAL_EVALUATION).Append("','")
               .Append(e.DATA_TYPE).Append("',")
               .Append(e.ORDER_NUMBER).Append(");")
               .Append("\r\n");
                }

                foreach (EntradaSaida s in Saidas)
                {
                    sb.Append("INSERT INTO TB_TRANSACTION_OUTPUT (ID_IF, ID_CHANNEL, ID_TRANSACTION, SEQ_FLOW, ENV_NAME, LOGICAL_EVALUATION, ORDER_NUMBER, DATA_TYPE) VALUES(")
                   .Append(ID_IF_2).Append(",")
                  .Append(ID_CHANNEL_2).Append(",")
                  .Append(ID_TRANSACTION).Append(",")
                  .Append(s.SEQ_FLOW).Append(",'")
                  .Append(s.ENV_NAME).Append("','")
                  .Append(s.LOGICAL_EVALUATION).Append("',")
                  .Append(s.ORDER_NUMBER).Append(",'")
                  .Append(s.DATA_TYPE).Append("');")
                  .Append("\r\n");
                }
            }

            if (incluiMenu)
            {
                if (TB_MENU != null)
                {
                    // sb.Append("UPDATE TB_MENU SET ID_TRANSACTION = ")
                    //.Append(ID_TRANSACTION)
                    //.Append(" WHERE ID_TRANSACTION = 9999")
                    //.Append("\r\n");

                    sb.Append("INSERT INTO TB_MENU  (ID_MENU, ID_MENU_PARENT, ID_IF, ID_CHANNEL, ID_TRANSACTION, DESCRIPTION , ACTION, ID_IMG , LEVEL_MENU, ORDER_NUMBER, DATA, STATUS) VALUES(")
                   .Append(TB_MENU.ID_MENU).Append(",")
                   .Append(TB_MENU.ID_MENU_PARENT).Append(",")
                   .Append(ID_IF).Append(",")
                   .Append(ID_CHANNEL).Append(",")
                   .Append(ID_TRANSACTION).Append(",'")
                   .Append(TB_MENU.DESCRIPTION).Append("','")
                   .Append(TB_MENU.ACTION).Append("',")
                   .Append(TB_MENU.ID_IMG).Append(",")
                   .Append(TB_MENU.LEVEL_MENU).Append(",")
                   .Append(TB_MENU.ORDER_NUMBER).Append(",'")
                   .Append(TB_MENU.DATA).Append("','")
                   .Append(TB_MENU.STATUS).Append("');")
                   .Append("\r\n");
                }
            }

            return sb.ToString();
        }

        public string Remove(bool incluiTransaction, 
            bool incluiProcess, 
            bool editaInputOutput, 
            bool incluiMenu,
            bool incluiPermission,
            bool incluiCHNTRN,
            bool incluiIFTRNCHN)
        {
            StringBuilder sb = new StringBuilder();

            if (incluiProcess)
            {
                sb.Append("DELETE FROM TB_TRANSACTION_PROCESS WHERE ID_IF = " + ID_IF + " AND ID_CHANNEL = " + ID_CHANNEL + " AND ID_TRANSACTION = ")
                    .Append(ID_TRANSACTION)
                    .Append(";")
                    .Append("\r\n");
            }

            if (TB_MENU != null && incluiMenu)
            {
                // sb.Append("UPDATE TB_MENU SET ID_TRANSACTION = 9999 WHERE ID_TRANSACTION = ")
                //.Append(idTransacao)
                //.Append("\r\n");

                sb.Append("DELETE FROM TB_MENU WHERE ID_TRANSACTION = ")
               .Append(ID_TRANSACTION)
               .Append(";")
               .Append("\r\n");
            }

            if (incluiPermission)
            {
                sb.Append("DELETE FROM TB_TRANSACTION_PERMISSION WHERE ID_IF = " + ID_IF + " AND ID_CHANNEL = " + ID_CHANNEL + " AND ID_TRANSACTION = ")
                    .Append(ID_TRANSACTION)
                    .Append(";")
                    .Append("\r\n");
            }

            if (incluiIFTRNCHN)
            {
                sb.Append("DELETE FROM TB_IF_CHN_TRN WHERE ID_IF = " + ID_IF + " AND ID_CHANNEL = " + ID_CHANNEL + " AND ID_TRANSACTION = ")
                    .Append(ID_TRANSACTION)
                    .Append(";")
                    .Append("\r\n");
            }

            if (incluiCHNTRN)
            {
                sb.Append("DELETE FROM TB_CHANNEL_TRANSACTION WHERE ID_CHANNEL = " + ID_CHANNEL + " AND ID_TRANSACTION = ")
                    .Append(ID_TRANSACTION)
                    .Append(";")
                    .Append("\r\n");
            }

            if (incluiTransaction)
            {
                sb.Append("DELETE FROM TB_TRANSACTION WHERE ID_TRANSACTION = ")
                    .Append(ID_TRANSACTION)
                    .Append(";")
                    .Append("\r\n");
            }
            

            if (editaInputOutput)
            {
                sb.Append("DELETE FROM TB_TRANSACTION_INPUT WHERE ID_IF = " + ID_IF_2 + " AND ID_CHANNEL = " + ID_CHANNEL_2 + " AND ID_TRANSACTION = ")
                    .Append(ID_TRANSACTION)
                    .Append(";")
                    .Append("\r\n");

                sb.Append("DELETE FROM TB_TRANSACTION_OUTPUT WHERE ID_IF = " + ID_IF_2 + " AND ID_CHANNEL = " + ID_CHANNEL_2 + " AND ID_TRANSACTION = ")
                    .Append(ID_TRANSACTION)
                    .Append(";")
                    .Append("\r\n");
            }

            return sb.ToString();
        }

        public string Atualiza(bool incluiTransaction, 
            bool incluiProcess, 
            bool editaInputOutput, 
            bool incluiMenu,
            bool incluiPermission,
            bool incluiCHNTRN,
            bool incluiIFTRNCHN)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Remove(incluiTransaction, 
                incluiProcess, 
                editaInputOutput, 
                incluiMenu,
                incluiPermission,
                incluiCHNTRN,
                incluiIFTRNCHN))
                .Append("\r\n");

            sb.Append(Nova(incluiTransaction, 
                incluiProcess, 
                editaInputOutput, 
                incluiMenu, 
                incluiPermission,
                incluiCHNTRN,
                incluiIFTRNCHN))
                .Append("\r\n");

            return sb.ToString();

            //sb.Append("UPDATE \"TB_TRANSACTION_PROCESS\" SET ID_PROCESS = ")
            //    .Append(novaTransacao.ID_PROCESS)
            //    .Append(" WHERE ID_TRANSACTION = ")
            //    .Append(novaTransacao.ID_TRANSACTION)
            //    .Append("\r\n");

            //sb.Append("UPDATE \"TB_TRANSACTION_PERMISSION\" SET ID_IF = ")
            //    .Append(novaTransacao.ID_IF)
            //    .Append(", ")
            //    .Append("ID_CHANNEL = ")
            //    .Append(novaTransacao.ID_CHANNEL)
            //    .Append(" WHERE ID_TRANSACTION = ")
            //    .Append(novaTransacao.ID_TRANSACTION)
            //    .Append("\r\n");

            //sb.Append("UPDATE \"TB_IF_CHN_TRN\" SET ID_IF = ")
            //    .Append(novaTransacao.ID_IF)
            //    .Append(", ")
            //    .Append("ID_CHANNEL = ")
            //    .Append(novaTransacao.ID_CHANNEL)
            //    .Append(" WHERE ID_TRANSACTION = ")
            //    .Append(novaTransacao.ID_TRANSACTION)
            //    .Append("\r\n");

            //sb.Append("UPDATE \"TB_CHANNEL_TRANSACTION\" SET ID_CHANNEL = ")
            //   .Append(novaTransacao.ID_CHANNEL)
            //   .Append(" WHERE ID_TRANSACTION = ")
            //   .Append(novaTransacao.ID_TRANSACTION)
            //   .Append("\r\n");

            //sb.Append("UPDATE \"TB_TRANSACTION\" SET DESCRIPTION = '")
            //    .Append(novaTransacao.DESCRIPTION)
            //    .Append("', ")
            //    .Append("SHORT_DESCRIPTION = '")
            //    .Append(novaTransacao.SHORT_DESCRIPTION)
            //    .Append("' WHERE ID_TRANSACTION = ")
            //    .Append(novaTransacao.ID_TRANSACTION)
            //    .Append("\r\n");
        }

        public string AtualizaInputOutput()
        {
            StringBuilder sb = new StringBuilder();

            foreach (EntradaSaida e in Entradas)
            {
                sb.Append("UPDATE TB_TRANSACTION_INPUT SET LOGICAL_EVALUATION = '")
            .Append(e.LOGICAL_EVALUATION).Append("'")
            .Append(" WHERE ID_TRANSACTION = ")
           .Append(ID_TRANSACTION).Append(" AND ")
           .Append("SEQ_FLOW = ")
           .Append(e.SEQ_FLOW).Append(" AND ")
           .Append("ENV_NAME = '")
           .Append(e.ENV_NAME).Append("';")
           .Append("\r\n");
            }

            foreach (EntradaSaida s in Saidas)
            {
                sb.Append("UPDATE TB_TRANSACTION_OUTPUT SET LOGICAL_EVALUATION = '")
            .Append(s.LOGICAL_EVALUATION).Append("'")
            .Append(" WHERE ID_TRANSACTION = ")
           .Append(ID_TRANSACTION).Append(" AND ")
           .Append("SEQ_FLOW = ")
           .Append(s.SEQ_FLOW).Append(" AND ")
           .Append("ENV_NAME = '")
           .Append(s.ENV_NAME).Append("';")
           .Append("\r\n");
            }

            return sb.ToString();
        }

    }

    [Serializable]
    public class TransactionProcess
    {
        public string ID_PROCESS { get; set; }
        public string SEQ_FLOW { get; set; }
    }

    [Serializable]
    public class EntradaSaida
    {
        public string SEQ_FLOW { get; set; }
        public string ENV_NAME { get; set; }
        public string LOGICAL_EVALUATION { get; set; }
        public string DATA_TYPE { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string ID_PROCESS { get; set; }
    }

    public class TransactionGroup
    {
        public string ID_TRN_GROUP { get; set; }
        public string DESCRIPTION { get; set; }
    }

    public class Menu
    {
        public string ID_MENU { get; set; }
        public string ID_MENU_PARENT { get; set; }
        public string ID_CHANNEL { get; set; }
        public string DESCRIPTION { get; set; }
        public string ACTION { get; set; }
        public string ID_IMG { get; set; }
        public string LEVEL_MENU { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string DATA { get; set; }
        public string STATUS { get; set; }
    }

}
