using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TesteTransacaoServCORE
{
    public static class Util
    {
        public static string TrataVarcharNULL(string valor)
        {
            if (valor == "")
                valor = "NULL";

            else if (valor != "NULL")
                valor = "'" + valor + "'";

            return valor;
        }

        public static object DeepClone(object obj)
        {
            object objResult = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }
            return objResult;
        }

        public static bool GravaScript(string modo, string tipo, string transacao, string conteudo, string caminho, out string saida)
        {
            bool retorno = false;
            saida = string.Empty;

            StreamWriter sw = null;

            try
            {
                InicializaCaminho(caminho);

                StringBuilder nomearquivointeiro = new StringBuilder();
                nomearquivointeiro.Append(caminho).Append("\\");

                StringBuilder nomearquivo = new StringBuilder();
                nomearquivo.Append(modo).Append(" ").Append(Util.ObtemDataHoraSistema().Year.ToString())
                    .Append(Util.ObtemDataHoraSistema().Month.ToString().PadLeft(2, '0'))
                    .Append(Util.ObtemDataHoraSistema().Day.ToString().PadLeft(2, '0')).Append(" ");
                nomearquivo.Append(Util.ObtemDataHoraSistema().Hour.ToString().PadLeft(2, '0'))
                    .Append(Util.ObtemDataHoraSistema().Minute.ToString().PadLeft(2, '0')).Append(" ")
                    .Append(Util.ObtemDataHoraSistema().Second.ToString().PadLeft(2, '0'))
                    .Append(Util.ObtemDataHoraSistema().Millisecond.ToString().PadLeft(3, '0'));
                nomearquivo.Append(" ").Append(tipo).Append(" ").Append(transacao).Append(".sql");
                nomearquivointeiro.Append(nomearquivo);

                FileInfo filenfo = new FileInfo(nomearquivointeiro.ToString());

                sw = File.AppendText(filenfo.FullName);
                sw.Write(conteudo);

                retorno = true;
            }
            catch (Exception exMsg)
            {
                saida = "\nErro na criação do arquivo de script: " + exMsg;
            }
            finally
            {
                if(sw!= null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }

            return retorno;
        }

        public static bool GravaArquivoServCoreDB(string caminho, string conteudo, out string saida)
        {
            bool retorno = false;
            saida = string.Empty;

            try
            {
                InicializaCaminho(caminho);

                StringBuilder nomearquivointeiro = new StringBuilder();
                nomearquivointeiro.Append(caminho).Append("\\");

                StringBuilder nomearquivo = new StringBuilder();
                nomearquivo.Append("servcore-").Append(Util.ObtemDataHoraSistema().Year.ToString())
                    .Append(Util.ObtemDataHoraSistema().Month.ToString().PadLeft(2, '0'))
                    .Append(Util.ObtemDataHoraSistema().Day.ToString().PadLeft(2, '0')).Append("-V001C001R001-001-dml.sql");

                nomearquivointeiro.Append(nomearquivo);

                FileInfo filenfo = new FileInfo(nomearquivointeiro.ToString());

                if (filenfo.Exists)
                    filenfo.Delete();

                StreamWriter sw = File.AppendText(filenfo.FullName);
                sw.Write(conteudo);

                sw.Flush();
                sw.Close();
                sw.Dispose();

                retorno = true;

            }
            catch (Exception exMsg)
            {
                saida = "\nErro na criação do arquivo servcore-db: " + exMsg;
            }

            return retorno;
        }

        private static void InicializaCaminho(string caminho)
        {
            if (Directory.Exists(caminho))
            {
                return;
            }
            else
            {
                Directory.CreateDirectory(caminho);
                return;
            }
        }

        public static DateTime ObtemDataHoraSistema()
        {
            DateTime retorno;
            try
            {
                TimeZoneInformation tmznfo = new TimeZoneInformation();
                GetTimeZoneInformation(out tmznfo);

                SYSTEMTIME datahorasistema = new SYSTEMTIME();
                GetSystemTime(out datahorasistema);

                DateTime datalocal = new DateTime(datahorasistema.wYear, datahorasistema.wMonth, datahorasistema.wDay, datahorasistema.wHour, datahorasistema.wMinute, datahorasistema.wSecond, datahorasistema.wMilliseconds);

                TimeZoneInfo.ClearCachedData();
                TimeZoneInfo nfo = TimeZoneInfo.Local;

                datalocal = datalocal.AddMinutes(-tmznfo.bias);

                if (!nfo.IsDaylightSavingTime(datalocal))
                    retorno = datalocal;
                else
                    retorno = datalocal.AddMinutes(-tmznfo.daylightBias);
            }
            catch
            {
                retorno = DateTime.Now;
            }

            return retorno;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetTimeZoneInformation(out TimeZoneInformation lpTimeZoneInformation);

        [DllImport("kernel32.dll")]
        static extern void GetSystemTime(out SYSTEMTIME lpSystemTime);

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;

            public short wMonth;

            public short wDayOfWeek;

            public short wDay;

            public short wHour;

            public short wMinute;

            public short wSecond;

            public short wMilliseconds;

        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TimeZoneInformation
        {
            public int bias;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]

            public string standardName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]

            public string daylightName;

            public SYSTEMTIME standardDate;

            public SYSTEMTIME daylightDate;

            public int standardBias;

            public int daylightBias;

        }
    }
}
