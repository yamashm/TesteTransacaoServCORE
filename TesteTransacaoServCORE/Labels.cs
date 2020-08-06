using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TesteTransacaoServCORE
{
    public class Label
    {
        public string ID_IF { get; set; }
        public string ID_LABEL { get; set; }
        public string LOCALE { get; set; }
        public string LABEL { get; set; }

        public string Novo()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Remove())
                .Append("\r\n");

            sb.Append(Insere())
                .Append("\r\n");

            return sb.ToString();
        }

        private string Remove()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("DELETE FROM TB_LABEL WHERE ID_LABEL = '")
                    .Append(ID_LABEL)
                    .Append("';")
                    .Append("\r\n");

            return sb.ToString();
        }

        private string Insere()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO TB_LABEL (ID_IF, ID_LABEL, LOCALE, LABEL) VALUES (")
                  .Append(ID_IF).Append(",'")
               .Append(ID_LABEL).Append("','")
               .Append(LOCALE).Append("','")
               .Append(LABEL).Append("');")
               .Append("\r\n");

            return sb.ToString();
        }

        public string Atualiza()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE TB_LABEL SET ID_IF = ")
                  .Append(ID_IF)
                  .Append(", ")
                  .Append("LOCALE = '")
               .Append(LOCALE)
               .Append("', ")
               .Append("LABEL = '")
               .Append(LABEL)
               .Append("' ")
               .Append("WHERE ID_LABEL = '")
               .Append(ID_LABEL)
               .Append("'; ")
               .Append("\r\n");

            return sb.ToString();
        }

        //public string GeraScript(string caminhoGerar, string ipServidor, string baseDados, string tipoQuery, string tipoOperacao)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.Append("\r\n")
        //        .Append(Novo());

        //    string saida;

        //    string caminhoSaida = Path.Combine(caminhoGerar, ipServidor, baseDados, "scripts");

        //    if (!Util.GravaScript(tipoQuery, tipoOperacao, "Label " + ID_LABEL
        //        , sb.ToString(), caminhoSaida, out saida))
        //    {
        //        return ("Erro ao gravar script: " + saida);
        //    }

        //    return sb.ToString();
        //}
    }
}
