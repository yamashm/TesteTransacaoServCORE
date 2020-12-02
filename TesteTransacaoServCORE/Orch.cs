using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteTransacaoServCORE
{
    [Serializable]
    public class Orch
    {
        public int INDEX { get; set; }
        public string ID_PROCESS { get; set; }
        public string STEP { get; set; }
        public string STEP_EDITADO { get; set; }
        public string ID_ACTIVITY { get; set; }
        public string ID_PROCESS_CHILD { get; set; }
        public string CREATE_TRANSACTION { get; set; }
        public string PROPAGATION_TRANSACTION { get; set; }
        public string FINISH_TRANSACTION { get; set; }
        public string NEXT_STEP { get; set; }
        public string RESULT_EVAL { get; set; }
        public string EXCEPTION_EVAL { get; set; }
        public string BEFORE_EXECUTE_EVAL { get; set; }
        public string CACHE_EVAL { get; set; }

        public string Atualiza()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE TB_ORCH SET ID_ACTIVITY = ")
                .Append(Util.TrataVarcharNULL(ID_ACTIVITY))
                .Append(", ")
                .Append("STEP = ")
                .Append(STEP_EDITADO)
                .Append(", ")
                .Append("ID_PROCESS_CHILD = ")
                .Append(Util.TrataVarcharNULL(ID_PROCESS_CHILD))
                .Append(", ")
                .Append("CREATE_TRANSACTION = '")
                .Append(CREATE_TRANSACTION)
                .Append("', ")
                .Append("PROPAGATION_TRANSACTION = ")
                .Append(PROPAGATION_TRANSACTION)
                .Append(", ")
                .Append("FINISH_TRANSACTION = '")
                .Append(FINISH_TRANSACTION)
                .Append("', ")
                .Append("NEXT_STEP = ")
                .Append(NEXT_STEP)
                .Append(", ")
                 .Append("RESULT_EVAL = ")
                .Append(Util.TrataVarcharNULL(RESULT_EVAL))
                .Append(", ")
                 .Append("EXCEPTION_EVAL = ")
                .Append(Util.TrataVarcharNULL(EXCEPTION_EVAL))
                .Append(", ")
                 .Append("BEFORE_EXECUTE_EVAL = ")
                .Append(Util.TrataVarcharNULL(BEFORE_EXECUTE_EVAL))
                .Append(", ")
                 .Append("CACHE_EVAL = '")
                .Append(CACHE_EVAL)
                .Append("' ")
                .Append(" WHERE ID_PROCESS = ")
                .Append(ID_PROCESS)
                .Append(" AND STEP = ")
                .Append(STEP)
                .Append(";")
                .Append("\r\n");

            return sb.ToString();
        }

        public string Nova()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO TB_ORCH (ID_PROCESS ,STEP,ID_ACTIVITY,ID_PROCESS_CHILD,CREATE_TRANSACTION,PROPAGATION_TRANSACTION,FINISH_TRANSACTION,NEXT_STEP,RESULT_EVAL,EXCEPTION_EVAL,BEFORE_EXECUTE_EVAL,CACHE_EVAL) VALUES (")
                  .Append(ID_PROCESS).Append(",")
               .Append(STEP).Append(",")
               .Append(Util.TrataVarcharNULL(ID_ACTIVITY)).Append(",")
               .Append(Util.TrataVarcharNULL(ID_PROCESS_CHILD)).Append(",'")
               .Append(CREATE_TRANSACTION).Append("',")
               .Append(PROPAGATION_TRANSACTION).Append(",'")
               .Append(FINISH_TRANSACTION).Append("',")
               .Append(NEXT_STEP).Append(",")
               .Append(Util.TrataVarcharNULL(RESULT_EVAL)).Append(",")
               .Append(Util.TrataVarcharNULL(EXCEPTION_EVAL)).Append(",")
               .Append(Util.TrataVarcharNULL(BEFORE_EXECUTE_EVAL)).Append(",'")
               .Append(CACHE_EVAL).Append("');")
               .Append("\r\n");

            return sb.ToString();
        }

        public string Remove()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("DELETE FROM TB_ORCH WHERE ID_PROCESS = ")
                    .Append(ID_PROCESS)
                    .Append(" AND STEP = ")
                    .Append(STEP)
                    .Append(";")
                    .Append("\r\n");

            return sb.ToString();
        }

        public string RemoveTodas()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("DELETE FROM TB_ORCH WHERE ID_PROCESS = ")
                    .Append(ID_PROCESS)
                    .Append(";")
                    .Append("\r\n");

            return sb.ToString();
        }
    }

    public class Activity
    {
        public string ID_ACTIVITY { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string STATUS { get; set; }

        public override string ToString()
        {
            return ID_ACTIVITY;
        }
    }

    [Serializable]
    public class Process
    {
        public string ID_PROCESS { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string STATUS { get; set; }
        public string PROCESS_TYPE { get; set; }
        public string CREATE_TRANSACTION { get; set; }
        public string PROPAGATION_TRANSACTION { get; set; }
        public string FINISH_TRANSACTION { get; set; }
        public string FULL_PATH { get; set; }

        public string Novo()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO TB_PROCESS (ID_PROCESS,NAME,DESCRIPTION,STATUS,PROCESS_TYPE,CREATE_TRANSACTION,PROPAGATION_TRANSACTION,FINISH_TRANSACTION,FULL_PATH) VALUES (")
                  .Append(ID_PROCESS).Append(",'")
               .Append(NAME).Append("','")
               .Append(DESCRIPTION).Append("','")
               .Append(STATUS).Append("','")
               .Append(PROCESS_TYPE).Append("','")
               .Append(CREATE_TRANSACTION).Append("',")
               .Append(PROPAGATION_TRANSACTION).Append(",'")
               .Append(FINISH_TRANSACTION).Append("',")
               .Append(Util.TrataVarcharNULL(FULL_PATH)).Append(");")
               .Append("\r\n");

            return sb.ToString();
        }

        public string Remove()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("DELETE FROM TB_PROCESS WHERE ID_PROCESS = ")
                  .Append(ID_PROCESS)
                  .Append(";")
               .Append("\r\n");

            return sb.ToString();
        }
    }
}
