using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteTransacaoServCORE
{
    public static class Comuns
    {
        public static List<EntradaSaida> entradasComuns { get; set; }
        public static List<EntradaSaida> saidasComuns { get; set; }
        public static List<TransactionGroup> grupos { get; set; }

        public static Orch orchBasica { get; set; }
        public static List<Activity> atividades { get; set; }
        public static List<Process> processos { get; set; }
    }
}
