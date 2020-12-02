using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TesteTransacaoServCORE
{
    public partial class Form1 : Form
    {
        string _connectionString = "Server=10.152.39.22;Database=servcore_hml_credsis1;User Id=servcore;Password=Diebold01;";

        List<Conexao> _servidores;

        List<Transacao> _transacoes;

        List<Orch> _orchs;

        //List<Label> _labels;

        List<Channel> _channels;

        List<InstituicaoFinanceira> _ifs;

        string _tipoOperacao; 

        public Form1()
        {
            InitializeComponent();

            gpbTransacoes.Enabled = false;

            ckbEditaInputOutput.Checked = true;

            btnCarregar.Visible = true;

            btnDesconectar.Enabled = false;

            btnExecutar.Enabled = false;

            btnExecutarOrch.Enabled = false;

            CarregaConfiguracoes();

            MontaDadosComuns();

            MontaComboServidores();

        }

        private void CarregaConfiguracoes()
        {
            string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).Substring(6);

            string path = Path.Combine(directory, "config.json");

            if (File.Exists(path))
            {
                dynamic stuff = JsonConvert.DeserializeObject(File.ReadAllText(path));

                txbCaminhoExecutados.Text = stuff.caminhoScriptsExecutados;
                txbCaminhoGerados.Text = stuff.caminhoScriptsGerados;
                txbCaminhoSaidaServcoreDB.Text = stuff.caminhoServcoreDB;
            }
            else
            {
                Config config = new Config();

                config.caminhoScriptsExecutados = Path.Combine(directory, "DB");
                config.caminhoScriptsGerados = Path.Combine(directory, "DB");
                config.caminhoServcoreDB = Path.Combine(directory, "DB");
                string saida;

                Util.GravaArquivoConfig(directory, JsonConvert.SerializeObject(config), out saida);

                txbCaminhoExecutados.Text = config.caminhoScriptsExecutados;
                txbCaminhoGerados.Text = config.caminhoScriptsGerados;
                txbCaminhoSaidaServcoreDB.Text = config.caminhoServcoreDB;
            }

        }

        private void MontaComboServidores()
        {
            string caminho = txbCaminhoGerados.Text;

            if (Directory.Exists(caminho))
            {
                _servidores = new List<Conexao>();

                foreach(string s in Directory.GetDirectories(caminho))
                {
                    foreach (string s2 in Directory.GetDirectories(s))
                    {
                        Conexao con = new Conexao();

                        con.server = new DirectoryInfo(s).Name;

                        con.database = new DirectoryInfo(s2).Name;

                        if (File.Exists(Path.Combine(s2, "db.properties")))
                        {
                            string[] linhas = File.ReadAllLines(Path.Combine(s2, "db.properties"));
                            con.user = linhas[0];
                            con.password = linhas[1];
                        }

                        _servidores.Add(con);
                    }
                }

                foreach (Conexao c in _servidores)
                {
                    cbbServidores.Items.Add(c);
                }

                if (cbbServidores.Items.Count > 0)
                    cbbServidores.SelectedIndex = 0;
            }
            else
            {

            }
        }

        #region Eventos

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            CarregaTransacoes();
        }

        private void ltbTransacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ltbTransacoes.SelectedIndex != -1)
            {
                //btnRemover.Enabled = _transacoes[ltbTransacoes.SelectedIndex].PERMITE_EDICAO;
                //btnEditar.Enabled = _transacoes[ltbTransacoes.SelectedIndex].PERMITE_EDICAO;
                //btnInsert.Enabled = _transacoes[ltbTransacoes.SelectedIndex].PERMITE_EDICAO;

                cbbChannel.SelectedItem = _channels.Find(x => x.ID_CHANNEL == _transacoes[ltbTransacoes.SelectedIndex].ID_CHANNEL);
                cbbIf.SelectedItem = _ifs.Find(x => x.ID_IF == _transacoes[ltbTransacoes.SelectedIndex].ID_IF);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Transacao novaTransacao = new Transacao();

            novaTransacao.ID_CHANNEL = obtemChannelSelecionado();
            novaTransacao.ID_IF = obtemIfSelecionado();

            novaTransacao = _transacoes[ltbTransacoes.SelectedIndex];

            if (!novaTransacao.PERMITE_EDICAO)
            {
                novaTransacao.ID_TRANSACTION = "";
                //novaTransacao.ID_IF = "1";
                novaTransacao.ID_IF_2 = "0";
                //novaTransacao.ID_CHANNEL = "1";
                novaTransacao.ID_CHANNEL_2 = "0";
                novaTransacao.Processos = new List<TransactionProcess>();
                novaTransacao.DESCRIPTION = "";
                novaTransacao.SHORT_DESCRIPTION = "";

                TransactionProcess transactioProcess = new TransactionProcess();

                transactioProcess.SEQ_FLOW = "1";
                transactioProcess.ID_PROCESS = "65";

                novaTransacao.Processos.Add(transactioProcess);

                novaTransacao.Entradas = new List<EntradaSaida>(Comuns.entradasComuns);
                novaTransacao.Saidas = new List<EntradaSaida>(Comuns.saidasComuns);
            }

            novaTransacao.NOVA = true;

            novaTransacao.PERMITE_EDICAO = true;

            FormEditar adicionar = new FormEditar(novaTransacao, false);

            if (adicionar.ShowDialog() == DialogResult.OK)
            {
                _tipoOperacao = "INSERT";
                txbQuery.Tag = new StringBuilder(novaTransacao.ID_TRANSACTION).Append(" - ").Append(novaTransacao.DESCRIPTION).ToString();

                txbQuery.Text = GeraScript(novaTransacao.Nova(ckbIncluiTransaction.Checked, 
                    ckbIncluiProcess.Checked, 
                    ckbEditaInputOutput.Checked, 
                    ckbIncluiMenu.Checked,
                    ckbIncluiPermission.Checked, 
                    ckbIncluiCHNTRN.Checked,
                    ckbIncluiIFTRNCHN.Checked));
                txbQuery.Focus();
                btnExecutar.Enabled = true;
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            _tipoOperacao = "DELETE";

            txbQuery.Tag = "";
            txbQuery.Text = GeraScript(_transacoes[ltbTransacoes.SelectedIndex].Remove(ckbIncluiTransaction.Checked, 
                ckbIncluiProcess.Checked, 
                ckbEditaInputOutput.Checked, 
                ckbIncluiMenu.Checked,
                    ckbIncluiPermission.Checked,
                    ckbIncluiCHNTRN.Checked,
                    ckbIncluiIFTRNCHN.Checked));
            txbQuery.Focus();
            btnExecutar.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Transacao novaTransacao = new Transacao();

            novaTransacao = _transacoes[ltbTransacoes.SelectedIndex];

            novaTransacao.ID_CHANNEL = obtemChannelSelecionado();
            novaTransacao.ID_IF = obtemIfSelecionado();

            if (!novaTransacao.PERMITE_EDICAO)
            {
                novaTransacao.Processos = new List<TransactionProcess>();

                TransactionProcess transactioProcess = new TransactionProcess();

                transactioProcess.SEQ_FLOW = "1";
                transactioProcess.ID_PROCESS = "65";

                novaTransacao.Processos.Add(transactioProcess);

                novaTransacao.Entradas = new List<EntradaSaida>(Comuns.entradasComuns);
                novaTransacao.Saidas = new List<EntradaSaida>(Comuns.saidasComuns);
            }

            novaTransacao.NOVA = false;

            FormEditar editar = new FormEditar(novaTransacao, ckbIncluiTransaction.Checked);

            DialogResult result = editar.ShowDialog();

            if (result == DialogResult.OK)
            {
                _tipoOperacao = "DELETE INSERT";
                txbQuery.Tag = "";

                txbQuery.Text = GeraScript(novaTransacao.Atualiza(ckbIncluiTransaction.Checked, 
                    ckbIncluiProcess.Checked, 
                    ckbEditaInputOutput.Checked,
                    ckbIncluiMenu.Checked,
                    ckbIncluiPermission.Checked,
                    ckbIncluiCHNTRN.Checked,
                    ckbIncluiIFTRNCHN.Checked));
                txbQuery.Focus();
                btnExecutar.Enabled = true;
            }
            else if(result == DialogResult.Yes)
            {
                _tipoOperacao = "UPDATE";
                txbQuery.Tag = "";

                txbQuery.Text = GeraScript(novaTransacao.AtualizaInputOutput());
                txbQuery.Focus();
                btnExecutar.Enabled = true;
            }
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Executar query?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            int indiceAtual = ltbTransacoes.SelectedIndex;

            if (result == DialogResult.OK)
            {
                DataTable dt = ExecutaSQL(txbQuery.Text);

                if (dt != null)
                {
                    string saida;

                    string transacao;

                    if (txbQuery.Tag.ToString() == "")
                        transacao = ltbTransacoes.SelectedItem.ToString();
                    else
                        transacao = txbQuery.Tag.ToString();

                    string caminhoSaida = Path.Combine(txbCaminhoExecutados.Text, txb_Server.Text, txb_Database.Text, "scripts");

                    if (!Util.GravaScript("E", _tipoOperacao, transacao, txbQuery.Text, caminhoSaida, out saida))
                    {
                        MessageBox.Show("Erro ao gravar script: " + saida, "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                    CarregaTransacoes();
                }

                ltbTransacoes.SelectedIndex = indiceAtual;

                btnExecutar.Enabled = false;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            _tipoOperacao = "INSERT";
            txbQuery.Tag = "";

            Transacao novaTransacao = _transacoes[ltbTransacoes.SelectedIndex];
            novaTransacao.ID_CHANNEL = obtemChannelSelecionado();
            novaTransacao.ID_IF = obtemIfSelecionado();

            txbQuery.AppendText(GeraScript(novaTransacao.Nova(ckbIncluiTransaction.Checked,
                ckbIncluiProcess.Checked,
                ckbEditaInputOutput.Checked, 
                ckbIncluiMenu.Checked,
                    ckbIncluiPermission.Checked,
                    ckbIncluiCHNTRN.Checked,
                    ckbIncluiIFTRNCHN.Checked)));
            txbQuery.Focus();
            btnExecutar.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _tipoOperacao = "UPDATE";
            txbQuery.Tag = "";

            Transacao novaTransacao = _transacoes[ltbTransacoes.SelectedIndex];
            novaTransacao.ID_CHANNEL = obtemChannelSelecionado();
            novaTransacao.ID_IF = obtemIfSelecionado();

            txbQuery.AppendText(GeraScript(novaTransacao.AtualizaInputOutput()));
            txbQuery.Focus();
            btnExecutar.Enabled = false;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            _connectionString = "Server=" + txb_Server.Text + ";Database=" + txb_Database.Text + " ;User Id=" + txb_User_Id.Text + ";Password=" + txb_Password.Text + ";";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    gpbTransacoes.Enabled = true;
                    connection.Close();
                    //gpbBasedeDados.Enabled = false;
                    MudaEstadoBaseDados(false);

                    CarregaChannels();
                    CarregaIfs();

                    if (cbbChannel.Items.Count > 0)
                        cbbChannel.SelectedIndex = 0;
                    if (cbbIf.Items.Count > 0)
                        cbbIf.SelectedIndex = 0;

                    CarregaOrch();
                    CarregaGruposTransacao();
                    CarregaLabels();
                    CarregaConfigsIfChannel();
                    CarregaTransacoes();
                    CarregaMenus();
                    CarregaChangeLog();

                    //string caminho = Path.Combine(txbCaminhoGerados.Text, txb_Server.Text, txb_Database.Text, "db.properties");

                    //if (File.Exists(caminho))
                    //    File.Delete(caminho);

                    //FileInfo filenfo = new FileInfo(caminho);

                    //StreamWriter sw = File.AppendText(filenfo.FullName);
                    //sw.WriteLine(txb_User_Id.Text, FileOptions.Asynchronous);
                    //sw.WriteLine(txb_Password.Text, FileOptions.Asynchronous);
                    //sw.Flush();
                    //sw.Close();
                    //sw.Dispose();
                }
                catch (SqlException)
                {
                    gpbTransacoes.Enabled = false;
                    MessageBox.Show("Não foi possível conectar à base de dados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            txbQuery.Text = string.Empty;
            ltbTransacoes.Items.Clear();

            gpbTransacoes.Enabled = false;
            //gpbBasedeDados.Enabled = true;
            MudaEstadoBaseDados(true);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbQuery.Clear();
        }

        private void ltbProcessos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ltbProcessos.SelectedIndex != -1)
            {
                CarregaPassos();
            }
        }

        private void btnEditarOrch_Click(object sender, EventArgs e)
        {
            Orch orch = _orchs.Find(x => x.ID_PROCESS == ltbProcessos.SelectedItem.ToString() && x.STEP == ltbPassos.SelectedItem.ToString());

            FormPasso passo = new FormPasso(orch);

            if (passo.ShowDialog() == DialogResult.OK)
            {
                _tipoOperacao = "UPDATE";

                txbQueryOrch.Text = GeraScriptOrch(orch.Atualiza(), orch.STEP);
                txbQueryOrch.Focus();
                btnExecutarOrch.Enabled = true;
            }
        }

        private void btnAdicionarOrch_Click(object sender, EventArgs e)
        {
            Orch orch = (Orch)Util.DeepClone(Comuns.orchBasica);

            //Orch orchCorrespondente = _orchs.Find(x => x.ID_PROCESS == ltbProcessos.SelectedItem.ToString());

            //if (orchCorrespondente != null)
            //    orch.ID_PROCESS = orchCorrespondente.ID_PROCESS;
            //else
            orch.ID_PROCESS = ltbProcessos.SelectedItem.ToString();

            FormPasso passo = new FormPasso(orch);

            if (passo.ShowDialog() == DialogResult.OK)
            {
                orch.STEP = orch.STEP_EDITADO;

                _tipoOperacao = "INSERT";

                StringBuilder sb = new StringBuilder(orch.Nova());

                List<Orch> orchsProcess = _orchs.FindAll(x => x.ID_PROCESS == ltbProcessos.SelectedItem.ToString());

                if (orchsProcess != null)
                {
                    foreach (Orch o in orchsProcess)
                    {
                        if (int.Parse(o.STEP) >= int.Parse(orch.STEP))
                        {
                            o.STEP_EDITADO = (int.Parse(o.STEP) + 1).ToString();
                            if (int.Parse(o.NEXT_STEP) > 0)
                                o.NEXT_STEP = (int.Parse(o.NEXT_STEP) + 1).ToString();
                            sb.Append(o.Atualiza());

                            o.STEP = o.STEP_EDITADO;
                        }
                    }

                    _orchs.Insert(orchsProcess[0].INDEX + int.Parse(orch.STEP) - 1, orch);
                }
                txbQueryOrch.Text = GeraScriptOrch(sb.ToString(), orch.STEP);
                txbQueryOrch.Focus();
                CarregaPassos();
                btnExecutarOrch.Enabled = true;
            }
        }

        private void btnRemoverOrch_Click(object sender, EventArgs e)
        {
            List<Orch> orchsProcess = _orchs.FindAll(x => x.ID_PROCESS == ltbProcessos.SelectedItem.ToString());

            Orch orch = orchsProcess.Find(x => x.STEP == ltbPassos.SelectedItem.ToString());

            _tipoOperacao = "DELETE";

            StringBuilder sb = new StringBuilder(orch.Remove());

            foreach(Orch o in orchsProcess)
            {
                if(int.Parse(o.STEP) > int.Parse(orch.STEP))
                {
                    o.STEP_EDITADO = (int.Parse(o.STEP) - 1).ToString();
                    if(int.Parse(o.NEXT_STEP) > 0)
                        o.NEXT_STEP = (int.Parse(o.NEXT_STEP) - 1).ToString();
                    sb.Append(o.Atualiza());

                    o.STEP = o.STEP_EDITADO;
                }
            }

            _orchs.Remove(orch);

            txbQueryOrch.Text = GeraScriptOrch(sb.ToString(), orch.STEP);
            txbQueryOrch.Focus();
            CarregaPassos();
            btnExecutarOrch.Enabled = true;
        }

        private void btnExecutarOrch_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Executar query?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            int indiceAtual = ltbProcessos.SelectedIndex;

            if (result == DialogResult.OK)
            {
                DataTable dt = ExecutaSQL(txbQueryOrch.Text);

                if (dt != null)
                {
                    string saida;

                    string caminhoSaida = Path.Combine(txbCaminhoExecutados.Text, txb_Server.Text, txb_Database.Text, "scripts");

                    if (!Util.GravaScript("E", _tipoOperacao, "Processo " + ltbProcessos.SelectedItem.ToString() + " Passo " + ltbPassos.SelectedItem.ToString()
                        , txbQueryOrch.Text, caminhoSaida, out saida))
                    {
                        MessageBox.Show("Erro ao gravar script: " + saida, "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                    CarregaOrch();
                }

                ltbProcessos.SelectedIndex = indiceAtual;

                btnExecutarOrch.Enabled = false;
            }
        }

        private void btnGeraInsertOrch_Click(object sender, EventArgs e)
        {
            Orch orch = _orchs.Find(x => x.ID_PROCESS == ltbProcessos.SelectedItem.ToString() && x.STEP == ltbPassos.SelectedItem.ToString());

            _tipoOperacao = "INSERT";

            txbQueryOrch.AppendText(GeraScriptOrch(orch.Nova(), orch.STEP));
            txbQueryOrch.Focus();

            btnExecutarOrch.Enabled = false;
        }

        private void btnLimparOrch_Click(object sender, EventArgs e)
        {
            txbQueryOrch.Clear();
        }

        private void btnServcoreDB_Click(object sender, EventArgs e)
        {
            FormServCoreDB formServCoreDB = new FormServCoreDB(_transacoes);

            if (formServCoreDB.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                foreach (Transacao t in _transacoes)
                {
                    if(t.SELECIONADA)
                    {
                        _tipoOperacao = "DELETE INSERT";

                        sb.Append(t.Atualiza(ckbIncluiTransaction.Checked,
                            ckbIncluiProcess.Checked, 
                            ckbEditaInputOutput.Checked, 
                            ckbIncluiMenu.Checked,
                    ckbIncluiPermission.Checked,
                    ckbIncluiCHNTRN.Checked,
                    ckbIncluiIFTRNCHN.Checked));
                    }
                }

                GeraServCoreDB(txbCaminhoSaidaServcoreDB.Text, sb.ToString());
            }
            //GeraServCoreDB(txbCaminhoServcoreDB.Text);
        }

        private void btnServcoreDBArquivos_Click(object sender, EventArgs e)
        {
            //GeraServCoreDB(txbCaminhoServcoreDB.Text, "");

            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "(*.SQL)|*.SQL|";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                GeraServCoreDB(ofd.FileNames.ToList());
            }
        }

        private void btnNovoProcesso_Click(object sender, EventArgs e)
        {
            Process process = Comuns.processos.Find(x => x.ID_PROCESS == ltbProcessos.SelectedItem.ToString());

            Process novoProcess = (Process)Util.DeepClone(process);

            FormProcesso processo = new FormProcesso(novoProcess);

            if (processo.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                _tipoOperacao = "INSERT";
                sb.Append(GeraScriptProcess(novoProcess.Novo(), novoProcess.ID_PROCESS));

                foreach (Orch o in _orchs.FindAll(x => x.ID_PROCESS == ltbProcessos.SelectedItem.ToString()))
                {
                    Orch novaOrch = (Orch)Util.DeepClone(o);
                    novaOrch.ID_PROCESS = novoProcess.ID_PROCESS;
                    _orchs.Add(novaOrch);

                    sb.Append(GeraScriptOrch(novaOrch.Nova(), novaOrch.STEP));
                }

                txbQueryOrch.Text = sb.ToString();
                txbQueryOrch.Focus();

                Comuns.processos.Add(novoProcess);

                CarregaListaProcessos();
                //CarregaListaOrch();
                btnExecutarOrch.Enabled = true;
            }
        }

        private void CarregaListaProcessos()
        {
            ltbProcessos.Items.Clear();

            foreach(Process p in Comuns.processos)
            {
                ltbProcessos.Items.Add(p.ID_PROCESS);
            }
        }

        private void btnEditarLabel_Click(object sender, EventArgs e)
        {
            //Label labelSelecionado = _labels.Find(x => x.ID_LABEL == ltbLabels.SelectedItem.ToString());
            Label labelSelecionado = (Label)ltbLabels.SelectedItem;

            if (labelSelecionado != null)
            {
                FormLabel label = new FormLabel(labelSelecionado);

                if (label.ShowDialog() == DialogResult.OK)
                {
                    _tipoOperacao = "UPDATE";
                    txbQueryLabels.Text = GeraScriptLabel(labelSelecionado.Atualiza(), labelSelecionado.ID_LABEL);

                    txbQueryLabels.Focus();

                    //btnExecutarOrch.Enabled = true;
                }
            }
        }

        private void btnAdicionarLabel_Click(object sender, EventArgs e)
        {
            Label labelNovo = (Label)ltbLabels.SelectedItem;

            FormLabel label = new FormLabel(labelNovo);

            if (label.ShowDialog() == DialogResult.OK)
            {
                _tipoOperacao = "DELETE INSERT";
                txbQueryLabels.Text = GeraScriptLabel(labelNovo.Novo(), labelNovo.ID_LABEL);
                txbQueryLabels.Focus();

                //btnExecutarOrch.Enabled = true;
            }
        }

        #endregion

        #region Dados Comuns
        private void MontaDadosComuns()
        {
            Comuns.entradasComuns = new List<EntradaSaida>();
            Comuns.saidasComuns = new List<EntradaSaida>();

            //EntradaSaida entrada1 = new EntradaSaida();

            //entrada1.SEQ_FLOW = "1";
            //entrada1.ENV_NAME = "AUTH_BEARER_TOKEN_ENABLED";
            //entrada1.LOGICAL_EVALUATION = "false";
            //entrada1.DATA_TYPE = "S";
            //entrada1.ORDER_NUMBER = "0";

            //Comuns.entradasComuns.Add(entrada1);

            //EntradaSaida entrada2 = new EntradaSaida();

            //entrada2.SEQ_FLOW = "1";
            //entrada2.ENV_NAME = "AUTH_HEADER";
            //entrada2.LOGICAL_EVALUATION = "token";
            //entrada2.DATA_TYPE = "S";
            //entrada2.ORDER_NUMBER = "0";

            //Comuns.entradasComuns.Add(entrada2);

            EntradaSaida entrada3 = new EntradaSaida();

            entrada3.SEQ_FLOW = "1";
            entrada3.ENV_NAME = "HEADER_KEY_1";
            entrada3.LOGICAL_EVALUATION = "Content-Type";
            entrada3.DATA_TYPE = "S";
            entrada3.ORDER_NUMBER = "0";

            Comuns.entradasComuns.Add(entrada3);

            EntradaSaida entrada4 = new EntradaSaida();

            entrada4.SEQ_FLOW = "1";
            entrada4.ENV_NAME = "HEADER_KEY_2";
            entrada4.LOGICAL_EVALUATION = "Accept";
            entrada4.DATA_TYPE = "S";
            entrada4.ORDER_NUMBER = "0";

            Comuns.entradasComuns.Add(entrada4);

            //EntradaSaida entrada5 = new EntradaSaida();

            //entrada5.SEQ_FLOW = "1";
            //entrada5.ENV_NAME = "HEADER_KEY_3";
            //entrada5.LOGICAL_EVALUATION = "fi";
            //entrada5.DATA_TYPE = "S";
            //entrada5.ORDER_NUMBER = "0";

            //Comuns.entradasComuns.Add(entrada5);

            EntradaSaida entrada6 = new EntradaSaida();

            entrada6.SEQ_FLOW = "1";
            entrada6.ENV_NAME = "HEADER_VALUE_1";
            entrada6.LOGICAL_EVALUATION = "application/json";
            entrada6.DATA_TYPE = "S";
            entrada6.ORDER_NUMBER = "0";

            Comuns.entradasComuns.Add(entrada6);

            EntradaSaida entrada7 = new EntradaSaida();

            entrada7.SEQ_FLOW = "1";
            entrada7.ENV_NAME = "HEADER_VALUE_2";
            entrada7.LOGICAL_EVALUATION = "application/json";
            entrada7.DATA_TYPE = "S";
            entrada7.ORDER_NUMBER = "0";

            Comuns.entradasComuns.Add(entrada7);

            //EntradaSaida entrada8 = new EntradaSaida();

            //entrada8.SEQ_FLOW = "1";
            //entrada8.ENV_NAME = "HEADER_VALUE_3";
            //entrada8.LOGICAL_EVALUATION = "transaction.data.FI.toString()";
            //entrada8.DATA_TYPE = "E";
            //entrada8.ORDER_NUMBER = "0";

            //Comuns.entradasComuns.Add(entrada8);

            EntradaSaida entrada9 = new EntradaSaida();

            entrada9.SEQ_FLOW = "1";
            entrada9.ENV_NAME = "JSON_INPUT";
            entrada9.LOGICAL_EVALUATION = "var requestBody={};requestBody.URLServicos=transaction.terminal.urlService ,requestBody.token=transaction.data.TOKEN ,JSON_INPUT=JSON.stringify(requestBody);";
            entrada9.DATA_TYPE = "E";
            entrada9.ORDER_NUMBER = "0";

            Comuns.entradasComuns.Add(entrada9);

            EntradaSaida entrada10 = new EntradaSaida();

            entrada10.SEQ_FLOW = "1";
            entrada10.ENV_NAME = "METHOD_TYPE";
            entrada10.LOGICAL_EVALUATION = "POST";
            entrada10.DATA_TYPE = "S";
            entrada10.ORDER_NUMBER = "0";

            Comuns.entradasComuns.Add(entrada10);

            EntradaSaida entrada11 = new EntradaSaida();

            entrada11.SEQ_FLOW = "1";
            entrada11.ENV_NAME = "REQUEST_BODY_TYPE";
            entrada11.LOGICAL_EVALUATION = "JSON_OBJECT";
            entrada11.DATA_TYPE = "S";
            entrada11.ORDER_NUMBER = "0";

            Comuns.entradasComuns.Add(entrada11);

            EntradaSaida entrada12 = new EntradaSaida();

            entrada12.SEQ_FLOW = "1";
            entrada12.ENV_NAME = "RESULT_KEY_NAME";
            entrada12.LOGICAL_EVALUATION = "WS_REST_RESULT";
            entrada12.DATA_TYPE = "S";
            entrada12.ORDER_NUMBER = "0";

            Comuns.entradasComuns.Add(entrada12);

            EntradaSaida entrada13 = new EntradaSaida();

            entrada13.SEQ_FLOW = "1";
            entrada13.ENV_NAME = "SERVICE_URL";
            entrada13.LOGICAL_EVALUATION = "/BarramentoSERVCore/ConsultaLancamento";
            entrada13.DATA_TYPE = "S";
            entrada13.ORDER_NUMBER = "0";

            Comuns.entradasComuns.Add(entrada13);

            EntradaSaida entrada14 = new EntradaSaida();

            entrada14.SEQ_FLOW = "1";
            entrada14.ENV_NAME = "TOTAL_HEADER_PARAMS";
            entrada14.LOGICAL_EVALUATION = "2";
            entrada14.DATA_TYPE = "S";
            entrada14.ORDER_NUMBER = "0";

            Comuns.entradasComuns.Add(entrada14);

            EntradaSaida saida1 = new EntradaSaida();

            saida1.SEQ_FLOW = "1";
            saida1.ENV_NAME = "DATA";
            saida1.LOGICAL_EVALUATION = "(output.WS_REST_RESULT ? JSON.parse(output.WS_REST_RESULT.toString()) : {})";
            saida1.DATA_TYPE = "E";
            saida1.ORDER_NUMBER = "0";

            Comuns.saidasComuns.Add(saida1);

            EntradaSaida saida2 = new EntradaSaida();

            saida2.SEQ_FLOW = "1";
            saida2.ENV_NAME = "BEFORE_PARSER";
            saida2.LOGICAL_EVALUATION = "if (output.WS_REST_RESULT) {\r\n\tvar object = JSON.parse(output.WS_REST_RESULT);\r\n\tresponseCode = object.cd_retorno;\r\n\tresponseMessage = object.ds_retorno;\r\n\tif (object.cd_retorno == 0) {\r\n\r\n\t} else {\r\n\r\n\t}\r\n} else {\r\n\tresponseCode = -1;\r\n\tresponseMessage = \"No communication with Service\";\r\n}";
            saida2.DATA_TYPE = "E";
            saida2.ORDER_NUMBER = "0";

            Comuns.saidasComuns.Add(saida2);

            EntradaSaida saida3 = new EntradaSaida();

            saida3.SEQ_FLOW = "1";
            saida3.ENV_NAME = "responseCode";
            saida3.LOGICAL_EVALUATION = "responseCode";
            saida3.DATA_TYPE = "E";
            saida3.ORDER_NUMBER = "0";

            Comuns.saidasComuns.Add(saida3);

            EntradaSaida saida4 = new EntradaSaida();

            saida4.SEQ_FLOW = "1";
            saida4.ENV_NAME = "responseMessage";
            saida4.LOGICAL_EVALUATION = "responseMessage";
            saida4.DATA_TYPE = "E";
            saida4.ORDER_NUMBER = "0";

            Comuns.saidasComuns.Add(saida4);

            EntradaSaida saida5 = new EntradaSaida();

            saida5.SEQ_FLOW = "1";
            saida5.ENV_NAME = "JWT_HOST";
            saida5.LOGICAL_EVALUATION = "transaction.data.JWT_HOST";
            saida5.DATA_TYPE = "E";
            saida5.ORDER_NUMBER = "0";

            Comuns.saidasComuns.Add(saida5);

            EntradaSaida saida6 = new EntradaSaida();

            saida6.SEQ_FLOW = "1";
            saida6.ENV_NAME = "BALANCE";
            saida6.LOGICAL_EVALUATION = "var responseBody={};responseBody.availableBalance=vlSaldoDisponivel,responseBody;";
            saida6.DATA_TYPE = "E";
            saida6.ORDER_NUMBER = "0";

            Comuns.saidasComuns.Add(saida6);

            EntradaSaida saida7 = new EntradaSaida();

            saida7.SEQ_FLOW = "1";
            saida7.ENV_NAME = "NO_RECEIPT";
            saida7.LOGICAL_EVALUATION = "true";
            saida7.DATA_TYPE = "E";
            saida7.ORDER_NUMBER = "0";

            Comuns.saidasComuns.Add(saida7);

            EntradaSaida saida8 = new EntradaSaida();

            saida8.SEQ_FLOW = "1";
            saida8.ENV_NAME = "RECEIPT";
            saida8.LOGICAL_EVALUATION = "txImpressao";
            saida8.DATA_TYPE = "E";
            saida8.ORDER_NUMBER = "0";

            Comuns.saidasComuns.Add(saida8);

            Comuns.orchBasica = new Orch();

            Comuns.orchBasica.ID_PROCESS = "";
            Comuns.orchBasica.STEP = "0";
            Comuns.orchBasica.ID_ACTIVITY = "";
            Comuns.orchBasica.ID_PROCESS_CHILD = "";
            Comuns.orchBasica.CREATE_TRANSACTION = "N";
            Comuns.orchBasica.PROPAGATION_TRANSACTION = "0";
            Comuns.orchBasica.FINISH_TRANSACTION = "N";
            Comuns.orchBasica.NEXT_STEP = "0";
            Comuns.orchBasica.RESULT_EVAL = "";
            Comuns.orchBasica.EXCEPTION_EVAL = "";
            Comuns.orchBasica.BEFORE_EXECUTE_EVAL = "";
            Comuns.orchBasica.CACHE_EVAL = "N";

            Comuns.configBasica = new ConfigIfChannel();
            Comuns.configBasica.KEY_CONFIG = "NOVA_CONFIG";
            Comuns.configBasica.PARAM_TYPE = "S";
            Comuns.configBasica.VALIDATION = "N";
            Comuns.configBasica.RESULT_EVAL = "NULL";
            Comuns.configBasica.ID_IF = "0";
            Comuns.configBasica.ID_CHANNEL = "1";
            Comuns.configBasica.DESCRIPTION = "NULL";
            Comuns.configBasica.ENABLED = "NULL";
            Comuns.configBasica.PARAM_GROUP = "NULL";
            Comuns.configBasica.VALUE = "true";


    }

        #endregion

        #region Cargas
        private void CarregaTransacoes()
        {
            try
            {
                DataTable dt = ExecutaSQL("SELECT * FROM TB_TRANSACTION ");

                _transacoes = new List<Transacao>();

                foreach (DataRow r in dt.Rows)
                {
                    Transacao t = new Transacao();

                    t.Entradas = new List<EntradaSaida>();
                    t.Saidas = new List<EntradaSaida>();

                    t.ID_TRANSACTION = r["ID_TRANSACTION"].ToString();
                    t.DESCRIPTION = r["DESCRIPTION"].ToString();
                    t.STATUS = r["STATUS"].ToString();
                    t.DATE_LAST_UPDATED = r["DATE_LAST_UPDATED"].ToString();
                    t.ID_TRN_GROUP = r["ID_TRN_GROUP"].ToString();
                    t.SHORT_DESCRIPTION = r["SHORT_DESCRIPTION"].ToString();
                    t.CATEGORY = r["CATEGORY"].ToString();
                    //t.ID_IF = obtemChannelSelecionado();
                    t.ID_IF_2 = "0";
                    //t.ID_CHANNEL = obtemIfSelecionado();
                    t.ID_CHANNEL_2 = "0";

                    t.PERMITE_EDICAO = true;

                    //string teste;
                    //if (t.ID_TRANSACTION == "541")
                    //    teste = "";

                    DataTable dt_TB_CHANNEL_TRANSACTION = ExecutaSQL("SELECT * FROM TB_CHANNEL_TRANSACTION WHERE ID_TRANSACTION = " + t.ID_TRANSACTION);

                    if (dt_TB_CHANNEL_TRANSACTION.Rows.Count > 0)
                        t.ID_CHANNEL = dt_TB_CHANNEL_TRANSACTION.Rows[0]["ID_CHANNEL"].ToString();
                    else
                    {
                        t.PERMITE_EDICAO = false;
                        t.ID_CHANNEL = obtemChannelSelecionado();
                    }

                    DataTable dt_TB_IF_CHN_TRN = ExecutaSQL("SELECT * FROM TB_IF_CHN_TRN WHERE ID_TRANSACTION = " + t.ID_TRANSACTION);

                    if (dt_TB_IF_CHN_TRN.Rows.Count > 0)
                        t.ID_IF = dt_TB_IF_CHN_TRN.Rows[0]["ID_IF"].ToString();
                    else
                    {
                        t.PERMITE_EDICAO = false;
                        t.ID_IF = obtemIfSelecionado();
                    }


                    //DataTable dt_TB_TRANSACTION_PROCESS = ExecutaSQL("SELECT * FROM TB_TRANSACTION_PROCESS WHERE ID_TRANSACTION = " + t.ID_TRANSACTION
                    //    + " AND ID_IF = " + t.ID_IF_2 + " AND ID_CHANNEL = " + t.ID_CHANNEL + " ORDER BY SEQ_FLOW");

                    DataTable dt_TB_TRANSACTION_PROCESS = ExecutaSQL("SELECT * FROM TB_TRANSACTION_PROCESS WHERE ID_TRANSACTION = " + t.ID_TRANSACTION
                         + " ORDER BY SEQ_FLOW");

                    t.Processos = new List<TransactionProcess>();

                    if (dt_TB_TRANSACTION_PROCESS.Rows.Count > 0)
                    {
                        foreach (DataRow r_process in dt_TB_TRANSACTION_PROCESS.Rows)
                        {
                            TransactionProcess processo = new TransactionProcess();

                            processo.SEQ_FLOW = r_process["SEQ_FLOW"].ToString();
                            processo.ID_PROCESS = r_process["ID_PROCESS"].ToString();

                            t.Processos.Add(processo);
                        }
                    }
                    //t.ID_PROCESS = dt_TB_TRANSACTION_PROCESS.Rows[0]["ID_PROCESS"].ToString();
                    else
                    {
                        t.PERMITE_EDICAO = false;
                    }

                    DataTable dt_TB_TRANSACTION_INPUT = ExecutaSQL("SELECT * FROM TB_TRANSACTION_INPUT WHERE ID_TRANSACTION = " + t.ID_TRANSACTION);

                    if (dt_TB_TRANSACTION_INPUT.Rows.Count > 0)
                    {
                        //t.ID_IF_2 = dt_TB_TRANSACTION_INPUT.Rows[0]["ID_IF"].ToString();

                        foreach (DataRow r_input in dt_TB_TRANSACTION_INPUT.Rows)
                        {
                            EntradaSaida entrada = new EntradaSaida();

                            entrada.SEQ_FLOW = r_input["SEQ_FLOW"].ToString();
                            entrada.ENV_NAME = r_input["ENV_NAME"].ToString();
                            entrada.LOGICAL_EVALUATION = r_input["LOGICAL_EVALUATION"].ToString();
                            entrada.DATA_TYPE = r_input["DATA_TYPE"].ToString();
                            entrada.ORDER_NUMBER = r_input["ORDER_NUMBER"].ToString();

                            TransactionProcess processo = t.Processos.Find(x => x.SEQ_FLOW == entrada.SEQ_FLOW);

                            if (processo != null)
                                entrada.ID_PROCESS = processo.ID_PROCESS;
                            else
                                entrada.ID_PROCESS = "";

                            if(t.ID_IF_2 == r_input["ID_IF"].ToString() && t.ID_CHANNEL_2 == r_input["ID_CHANNEL"].ToString()) 
                                t.Entradas.Add(entrada);
                        }

                        //var groupEntradas = t.Entradas.GroupBy(x => x.SEQ_FLOW);

                        //t.SeqFlowsInput = new List<string>();

                        //foreach (var group in groupEntradas)
                        //{
                        //    t.SeqFlowsInput.Add(group.Key);
                        //}
                    }

                    DataTable dt_TB_TRANSACTION_OUTPUT = ExecutaSQL("SELECT * FROM TB_TRANSACTION_OUTPUT WHERE ID_TRANSACTION = " + t.ID_TRANSACTION);

                    if (dt_TB_TRANSACTION_OUTPUT.Rows.Count > 0)
                    {
                        foreach (DataRow r_output in dt_TB_TRANSACTION_OUTPUT.Rows)
                        {
                            EntradaSaida saida = new EntradaSaida();

                            saida.SEQ_FLOW = r_output["SEQ_FLOW"].ToString();
                            saida.ENV_NAME = r_output["ENV_NAME"].ToString();
                            saida.LOGICAL_EVALUATION = r_output["LOGICAL_EVALUATION"].ToString();
                            saida.DATA_TYPE = r_output["DATA_TYPE"].ToString();
                            saida.ORDER_NUMBER = r_output["ORDER_NUMBER"].ToString();

                            TransactionProcess processo = t.Processos.Find(x => x.SEQ_FLOW == saida.SEQ_FLOW);

                            if (processo != null)
                                saida.ID_PROCESS = processo.ID_PROCESS;
                            else
                                saida.ID_PROCESS = "";

                            if (t.ID_IF_2 == r_output["ID_IF"].ToString() && t.ID_CHANNEL_2 == r_output["ID_CHANNEL"].ToString())
                                t.Saidas.Add(saida);
                        }

                        //var groupSaidas= t.Saidas.GroupBy(x => x.SEQ_FLOW);

                        //t.SeqFlowsOutput= new List<string>();

                        //foreach (var group in groupSaidas)
                        //{
                        //    t.SeqFlowsOutput.Add(group.Key);
                        //}
                    }

                    DataTable dt_TB_MENU = ExecutaSQL("SELECT * FROM TB_MENU WHERE ID_TRANSACTION = " + t.ID_TRANSACTION);

                    if (dt_TB_MENU.Rows.Count > 0)
                    {
                        t.TB_MENU = new Menu();
                        t.TB_MENU.ID_MENU = dt_TB_MENU.Rows[0]["ID_MENU"].ToString();
                        t.TB_MENU.ID_MENU_PARENT = dt_TB_MENU.Rows[0]["ID_MENU_PARENT"].ToString();
                        t.TB_MENU.DESCRIPTION = dt_TB_MENU.Rows[0]["DESCRIPTION"].ToString();
                        t.TB_MENU.ACTION = dt_TB_MENU.Rows[0]["ACTION"].ToString();
                        t.TB_MENU.ID_IMG = dt_TB_MENU.Rows[0]["ID_IMG"].ToString();
                        t.TB_MENU.LEVEL_MENU = dt_TB_MENU.Rows[0]["LEVEL_MENU"].ToString();
                        t.TB_MENU.ORDER_NUMBER = dt_TB_MENU.Rows[0]["ORDER_NUMBER"].ToString();
                        t.TB_MENU.DATA = dt_TB_MENU.Rows[0]["DATA"].ToString();
                        t.TB_MENU.STATUS = dt_TB_MENU.Rows[0]["STATUS"].ToString();
                    }

                    _transacoes.Add(t);
                }
                ltbTransacoes.Items.Clear();

                foreach (Transacao t in _transacoes)
                {
                    ltbTransacoes.Items.Add(new StringBuilder(t.ID_TRANSACTION).Append(" - ").Append(t.DESCRIPTION).ToString());
                }

                ltbTransacoes.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("Erro ao obter dados da base", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaOrch()
        {
            try
            {
                DataTable dt = ExecutaSQL("SELECT * FROM TB_ORCH ");

                _orchs = new List<Orch>();

                int i = 0;

                foreach (DataRow r in dt.Rows)
                {
                    Orch orch = new Orch();

                    orch.ID_PROCESS = r["ID_PROCESS"].ToString();
                    orch.STEP = r["STEP"].ToString();
                    orch.ID_ACTIVITY = r["ID_ACTIVITY"].ToString();
                    orch.ID_PROCESS_CHILD = r["ID_PROCESS_CHILD"].ToString();
                    orch.CREATE_TRANSACTION = r["CREATE_TRANSACTION"].ToString();
                    orch.PROPAGATION_TRANSACTION = r["PROPAGATION_TRANSACTION"].ToString();
                    orch.FINISH_TRANSACTION = r["FINISH_TRANSACTION"].ToString();
                    orch.NEXT_STEP = r["NEXT_STEP"].ToString();
                    orch.RESULT_EVAL = r["RESULT_EVAL"].ToString();
                    orch.EXCEPTION_EVAL = r["EXCEPTION_EVAL"].ToString();
                    orch.BEFORE_EXECUTE_EVAL = r["BEFORE_EXECUTE_EVAL"].ToString();
                    orch.CACHE_EVAL = r["CACHE_EVAL"].ToString();
                    orch.INDEX = i;

                    _orchs.Add(orch);

                    i++;
                }

                ltbProcessos.Items.Clear();

                //foreach (string s in _orchs.Select(x => x.ID_PROCESS).Distinct())
                //{
                //    ltbProcessos.Items.Add(s);
                //}

                //if (ltbProcessos.Items.Count > 0)
                //    ltbProcessos.SelectedIndex = 0;

                Comuns.atividades = new List<Activity>();

                dt = ExecutaSQL("SELECT * FROM TB_ACTIVITY ");

                foreach (DataRow r in dt.Rows)
                {
                    Activity atividade = new Activity();

                    atividade.ID_ACTIVITY = r["ID_ACTIVITY"].ToString();
                    atividade.NAME = r["NAME"].ToString();
                    atividade.DESCRIPTION = r["DESCRIPTION"].ToString();
                    atividade.STATUS = r["STATUS"].ToString();

                    Comuns.atividades.Add(atividade);
                }

                Comuns.processos = new List<Process>();

                dt = ExecutaSQL("SELECT * FROM TB_PROCESS ");

                foreach (DataRow r in dt.Rows)
                {
                    Process processo = new Process();

                    processo.ID_PROCESS = r["ID_PROCESS"].ToString();
                    processo.NAME = r["NAME"].ToString();
                    processo.DESCRIPTION = r["DESCRIPTION"].ToString();
                    processo.STATUS = r["STATUS"].ToString();
                    processo.PROCESS_TYPE = r["PROCESS_TYPE"].ToString();
                    processo.CREATE_TRANSACTION = r["CREATE_TRANSACTION"].ToString();
                    processo.PROPAGATION_TRANSACTION = r["PROPAGATION_TRANSACTION"].ToString();
                    processo.FINISH_TRANSACTION = r["FINISH_TRANSACTION"].ToString();
                    processo.FULL_PATH = r["FULL_PATH"].ToString();

                    Comuns.processos.Add(processo);

                    ltbProcessos.Items.Add(processo.ID_PROCESS);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao obter dados da base", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //foreach (string s in _orchs.Select(x => x.ID_PROCESS).Distinct())
            //{
            //    ltbProcessos.Items.Add(s);
            //}

            if (ltbProcessos.Items.Count > 0)
                ltbProcessos.SelectedIndex = 0;
        }

        private void CarregaPassos()
        {
            ltbPassos.Items.Clear();

            foreach (Orch o in _orchs.FindAll(x => x.ID_PROCESS == ltbProcessos.SelectedItem.ToString()))
            {
                ltbPassos.Items.Add(o.STEP);
            }

            if (ltbPassos.Items.Count > 0)
                ltbPassos.SelectedIndex = 0;
        }

        private void CarregaGruposTransacao()
        {
            Comuns.grupos = new List<TransactionGroup>();

            try
            {
                DataTable dt = ExecutaSQL("SELECT * FROM TB_TRANSACTION_GROUP ");

                foreach (DataRow r in dt.Rows)
                {
                    TransactionGroup trn = new TransactionGroup();

                    trn.ID_TRN_GROUP = r["ID_TRN_GROUP"].ToString();
                    trn.DESCRIPTION = r["DESCRIPTION"].ToString();

                    Comuns.grupos.Add(trn);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao obter dados da base", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaLabels()
        {
            try
            {
                //_labels = new List<Label>();

                DataTable dt = ExecutaSQL("SELECT * FROM TB_LABEL ");

                ltbLabels.Items.Clear();

                foreach (DataRow r in dt.Rows)
                {
                    Label lbl = new Label();

                    lbl.ID_IF = r["ID_IF"].ToString();
                    lbl.ID_LABEL = r["ID_LABEL"].ToString();
                    lbl.LOCALE = r["LOCALE"].ToString();
                    lbl.LABEL = r["LABEL"].ToString();

                    //_labels.Add(lbl);
                    ltbLabels.Items.Add(lbl);
                }

                //foreach(Label l in _labels)
                //{
                //    ltbLabels.Items.Add(l.ID_LABEL);
                //}
            }
            catch
            {
                MessageBox.Show("Erro ao obter dados da base", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaChannels()
        {
            try
            {
                _channels = new List<Channel>();

                DataTable dt = ExecutaSQL("SELECT * FROM TB_CHANNEL ");

                foreach (DataRow r in dt.Rows)
                {
                    Channel channel = new Channel(r["ID_CHANNEL"].ToString(), r["DESCRIPTION"].ToString());

                    _channels.Add(channel);
                }

                cbbChannel.Items.Clear();

                foreach (Channel c in _channels)
                {
                    cbbChannel.Items.Add(c);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao obter dados da base", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaIfs()
        {
            try
            {
                _ifs = new List<InstituicaoFinanceira>();

                DataTable dt = ExecutaSQL("SELECT * FROM TB_IF ");

                foreach (DataRow r in dt.Rows)
                {
                    InstituicaoFinanceira instituicao = new InstituicaoFinanceira(r["ID_IF"].ToString(), r["SHORT_NAME"].ToString());

                    _ifs.Add(instituicao);
                }

                cbbIf.Items.Clear();

                foreach (InstituicaoFinanceira i in _ifs)
                {
                    cbbIf.Items.Add(i);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao obter dados da base", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaConfigsIfChannel()
        {
            try
            {
                DataTable dt = ExecutaSQL("SELECT * FROM TB_CONFIG_IF_CHANNEL ");

                ltbConfig.Items.Clear();

                foreach (DataRow r in dt.Rows)
                {
                    ConfigIfChannel cic = new ConfigIfChannel();

                    cic.KEY_CONFIG = r["KEY_CONFIG"].ToString();
                    cic.PARAM_TYPE = r["PARAM_TYPE"].ToString();
                    cic.VALIDATION = r["VALIDATION"].ToString();
                    cic.RESULT_EVAL = r["RESULT_EVAL"].ToString();
                    cic.ID_IF = r["ID_IF"].ToString();
                    cic.ID_CHANNEL = r["ID_CHANNEL"].ToString();
                    cic.DESCRIPTION = r["DESCRIPTION"].ToString();
                    cic.ENABLED = r["ENABLED"].ToString();
                    cic.PARAM_GROUP = r["PARAM_GROUP"].ToString();
                    cic.VALUE = r["VALUE"].ToString();

                    ltbConfig.Items.Add(cic);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao obter dados da base", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaMenus()
        {
            try
            {
                DataTable dt = ExecutaSQL("SELECT * FROM TB_MENU ");

                ltbMenu.Items.Clear();

                foreach (DataRow r in dt.Rows)
                {
                    Menu menu = new Menu();

                    menu.ID_MENU = r["ID_MENU"].ToString();
                    menu.ID_MENU_PARENT = r["ID_MENU_PARENT"].ToString();
                    menu.ID_TRANSACTION = r["ID_TRANSACTION"].ToString();
                    menu.DESCRIPTION = r["DESCRIPTION"].ToString();
                    menu.ACTION = r["ACTION"].ToString();
                    menu.ID_IMG = r["ID_IMG"].ToString();
                    menu.LEVEL_MENU = r["LEVEL_MENU"].ToString();
                    menu.ORDER_NUMBER = r["ORDER_NUMBER"].ToString();
                    menu.DATA = r["DATA"].ToString();
                    menu.STATUS = r["STATUS"].ToString();

                    ltbMenu.Items.Add(menu);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao obter dados da base", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaChangeLog()
        {
            try
            {
                DataTable dt = ExecutaSQL("SELECT * FROM tb_database_changelog ");

                ltbChangeLog.Items.Clear();

                foreach (DataRow r in dt.Rows)
                {
                    ChangeLog changelog = new ChangeLog();

                    changelog.SCRIPT_NAME = r["script_name"].ToString();
                    changelog.PACKAGE_VERSION = r["package_version"].ToString();
                    changelog.STATUS = r["status"].ToString();
                    changelog.ORDER_NUMBER = r["order_number"].ToString();
                    changelog.TS_CREATED = r["ts_created"].ToString();

                    ltbChangeLog.Items.Add(changelog);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao obter dados da base", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion 

        #region Scripts

        private void GeraServCoreDB(List<string> fileNames)
        {
            StringBuilder sb = new StringBuilder();

            //sb.Append("BEGIN")
            //    .Append("\r\n");

            foreach (string s in fileNames)
            {
                sb.Append("\r\n");
                sb.Append(File.ReadAllText(s));
                sb.Append("\r\n");
            }

            //sb.Append("END")
            //    .Append("\r\n");

            string saida;

            string caminhoSaida = Path.Combine(txbCaminhoSaidaServcoreDB.Text, txb_Server.Text, txb_Database.Text, "servcore-db");

            if (!Util.GravaArquivoServCoreDB(caminhoSaida, sb.ToString(), out saida))
            {
                MessageBox.Show("Erro ao gravar script servcore-db: " + saida, "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void GeraServCoreDB(string caminhoScripts, string scripts)
        {
            DirectoryInfo d = new DirectoryInfo(caminhoScripts);

            StringBuilder sb = new StringBuilder();

            //sb.Append("BEGIN")
            //    .Append("\r\n");

            if (scripts == "")
            {
                foreach (FileInfo nfo in d.GetFiles())
                {
                    sb.Append("\r\n");
                    sb.Append(File.ReadAllText(nfo.FullName));
                    sb.Append("\r\n");
                }
            }
            else
            {
                sb.Append("\r\n");
                sb.Append(scripts);
                sb.Append("\r\n");
            }

            //sb.Append("END")
            //    .Append("\r\n");

            string saida;

            string caminhoSaida = Path.Combine(txbCaminhoSaidaServcoreDB.Text, txb_Database.Text, "servcore-db");

            if (!Util.GravaArquivoServCoreDB(caminhoSaida, sb.ToString(), out saida))
            {
                MessageBox.Show("Erro ao gravar script servcore-db: " + saida, "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            //else
            //{
            //    try
            //    {
            //        foreach (FileInfo nfo in d.GetFiles())
            //        {

            //            File.Delete(nfo.FullName);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Erro ao apagar script servcore-db: " + ex.Message, "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //    }
            //}
        }

        private string GeraScript(string script)
        {
            if (ckbEditaInputOutput.Checked && txbQuery.Tag.ToString() == "")
                _tipoOperacao = new StringBuilder(_tipoOperacao).Append(" ").Append("IO").ToString();

            string transacao;

            if (txbQuery.Tag.ToString() == "")
                transacao = ltbTransacoes.SelectedItem.ToString();
            else
                transacao = txbQuery.Tag.ToString();

            return GeraScript(script, txbCaminhoGerados.Text,"G", _tipoOperacao, transacao);
        }

        private string GeraScriptOrch(string script, string step)
        {
            return GeraScript(script, txbCaminhoGerados.Text,"G", _tipoOperacao, "Processo " + ltbProcessos.SelectedItem.ToString() + " Passo " + step);
        }

        private string GeraScriptProcess(string script, string id_process)
        {
            return GeraScript(script, txbCaminhoGerados.Text,"G", _tipoOperacao, "Processo " + id_process);
        }

        private string GeraScriptLabel(string script, string id_label)
        {
            return GeraScript(script, txbCaminhoGerados.Text, "G", _tipoOperacao, "Label " + id_label);
        }

        private string GeraScriptMenu(string script, string id_menu)
        {
            return GeraScript(script, txbCaminhoGerados.Text, "G", _tipoOperacao, "Menu " + id_menu);
        }

        private string GeraScriptConfigIfChannel(string script, string key_config)
        {
            return GeraScript(script, txbCaminhoGerados.Text, "G", _tipoOperacao, "Config " + key_config);
        }

        private string GeraScript(string script, string caminho, string modo, string tipoOperacao, string transacao)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\r\n")
                .Append(script);

            string saida;

            string caminhoSaida = Path.Combine(caminho, txb_Server.Text, txb_Database.Text, "scripts");

            if (!Util.GravaScript(modo, tipoOperacao, transacao
                , sb.ToString(), caminhoSaida, out saida))
            {
                return ("Erro ao gravar script: " + saida);
            }

            return sb.ToString();
        }

        #endregion

        #region SQL

        private DataTable ExecutaSQL(string queryString)
        {
            DataTable dt = new DataTable();
            int rows_returned;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    command.CommandText = queryString;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    rows_returned = sda.Fill(dt);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dt = null;
            }

            return dt;
        }

        #endregion

        #region Geral

        private void MudaEstadoBaseDados(bool estado)
        {
            txb_Database.Enabled = estado;
            txb_Server.Enabled = estado;
            txb_User_Id.Enabled = estado;
            txb_Password.Enabled = estado;
            btnConectar.Enabled = estado;

            if (estado)
                btnDesconectar.Enabled = false;
            else
                btnDesconectar.Enabled = true;
        }

        private string obtemChannelSelecionado()
        {
            if (cbbChannel.Items.Count > 0 && cbbChannel.SelectedIndex != -1)
            {
                Channel channel = (Channel)cbbChannel.SelectedItem;
                return channel.ID_CHANNEL;
            }
            else
            {
                return "1";
            }
        }

        private string obtemIfSelecionado()
        {
            if (cbbIf.Items.Count > 0 && cbbIf.SelectedIndex != -1)
            {
                InstituicaoFinanceira instituicao = (InstituicaoFinanceira)cbbIf.SelectedItem;
                return instituicao.ID_IF;
            }
            else
            {
                return "1";
            }
        }

        #endregion

        private void cbbServidores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbServidores.SelectedIndex != -1)
            {
                Conexao c = (Conexao)cbbServidores.SelectedItem;

                txb_Server.Text = c.server;
                txb_Database.Text = c.database;
                txb_User_Id.Text = c.user;
                txb_Password.Text = c.password;
            }
        }

        private void btnListarPassosOrch_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            Process p = Comuns.processos.Find(x => x.ID_PROCESS == ltbProcessos.SelectedItem.ToString());

            sb.Append("PROCESS NAME ").Append(p.NAME).Append("\r\n").Append("\r\n");

            foreach (Orch o in _orchs.FindAll(x => x.ID_PROCESS == ltbProcessos.SelectedItem.ToString()))
            {
                sb.Append("STEP ").Append(o.STEP).Append("\r\n");
                string idActivity = "NULL";
                string nameActivity = "NULL";
                //string idProcessChild = "NULL";

                if (o.ID_ACTIVITY != "")
                {
                    idActivity = o.ID_ACTIVITY;
                    nameActivity = Comuns.atividades.Find(x => x.ID_ACTIVITY == o.ID_ACTIVITY).NAME;
                }

                sb.Append("ID_ACTIVITY ").Append(idActivity).Append("\r\n");
                sb.Append("\tACTIVITY ").Append(nameActivity).Append("\r\n");

                if(o.ID_PROCESS_CHILD != "" && o.ID_PROCESS_CHILD != "NULL")
                {
                    sb.Append("\t\tPROCESS_CHILD ").Append(o.ID_PROCESS_CHILD).Append("\r\n");

                }

                if(o.RESULT_EVAL != "" && o.RESULT_EVAL != "NULL")
                    sb.Append("RESULT_EVAL ").Append(o.RESULT_EVAL).Append("\r\n");

                sb.Append("NEXT STEP ").Append(o.NEXT_STEP).Append("\r\n").Append("\r\n");
            }

            txbQueryOrch.Text = sb.ToString();
        }

        private void btnTecladoGerar_Click(object sender, EventArgs e)
        {
            dynamic stuff = JsonConvert.DeserializeObject(txbTecladoJSON.Text);

            TecladoData tecladoData = new TecladoData();
            tecladoData.PASSWORD = new List<string>();

            tecladoData.KEYBOARD = stuff.reference;

            foreach (char c in txbTecladoSenha.Text)
            {
                tecladoData.PASSWORD.Add(stuff.keys[int.Parse(c.ToString())].id.ToString());
            }

            string data = JsonConvert.SerializeObject(tecladoData);

            txbTecladoDataSenha.Text = data.Substring(1, data.Length - 2);

        }

        private void btnSalvarOrch_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            Process p = Comuns.processos.Find(x => x.ID_PROCESS == ltbProcessos.SelectedItem.ToString());

            //sb.Append(p.Remove());
            sb.Append(p.Novo()); 

            List<Orch> lista = _orchs.FindAll(x => x.ID_PROCESS == ltbProcessos.SelectedItem.ToString());

            if (lista != null)
            {
                sb.Append(lista[0].RemoveTodas());

                foreach (Orch o in lista)
                {
                    sb.Append(o.Nova());
                }

                txbQueryOrch.Text = GeraScriptOrch(sb.ToString(), "TODOS");
            }
        }

        private void btnSalvarConfiguracao_Click(object sender, EventArgs e)
        {
            Config config = new Config();

            config.caminhoScriptsExecutados = txbCaminhoExecutados.Text;
            config.caminhoScriptsGerados = txbCaminhoGerados.Text;
            config.caminhoServcoreDB = txbCaminhoSaidaServcoreDB.Text;

            string directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            string saida;

            Util.GravaArquivoConfig(directory, JsonConvert.SerializeObject(config), out saida);
        }

        private void ltbConfig_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionarConfig_Click(object sender, EventArgs e)
        {
            ConfigIfChannel configNova = (ConfigIfChannel)ltbConfig.SelectedItem;

            FormConfig configifchannel = new FormConfig(configNova);

            if (configifchannel.ShowDialog() == DialogResult.OK)
            {
                _tipoOperacao = "DELETE INSERT";
                txbQueryConfig.Text = GeraScriptConfigIfChannel(configNova.Nova(), configNova.KEY_CONFIG);
                txbQueryConfig.Focus();

                //btnExecutarOrch.Enabled = true;
            }
        }

        private void btnRemoverConfig_Click(object sender, EventArgs e)
        {
            ConfigIfChannel configSelecionada = (ConfigIfChannel)ltbConfig.SelectedItem;

            _tipoOperacao = "DELETE";
            txbQueryConfig.Text = GeraScriptConfigIfChannel(configSelecionada.Remove(), configSelecionada.KEY_CONFIG);
            txbQueryConfig.Focus();
        }

        private void btnEditarConfig_Click(object sender, EventArgs e)
        {
            ConfigIfChannel configSelecionada = (ConfigIfChannel)ltbConfig.SelectedItem;

            FormConfig configifchannel = new FormConfig(configSelecionada);

            if (configifchannel.ShowDialog() == DialogResult.OK)
            {
                _tipoOperacao = "UPDATE";
                txbQueryConfig.Text = GeraScriptConfigIfChannel(configSelecionada.Atualiza(), configSelecionada.KEY_CONFIG);

                txbQueryConfig.Focus();

                //btnExecutarOrch.Enabled = true;
            }

        }

        private void btnThemeQuebra_Click(object sender, EventArgs e)
        {
            string theme = Regex.Replace(txbTheme.Text.Trim(), @"\t|\n|\r", "");
            int tamanho = Convert.ToInt32(txbQuebraStringTamanho.Text);
            string tabela = txbQuebraStringTabela.Text;
            string campo = txbQuebraStringCampo.Text;

            string condicao = txbQuebraStringCondicao.Text;

            List<string> partes = theme.Split(tamanho).ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE ").Append(tabela).Append(" SET ").Append(campo).Append(" = '' WHERE ")
                .Append(condicao).Append(";")
                .Append("\r\n");

            foreach(string s in partes)
            {
                sb.Append("UPDATE ").Append(tabela).Append(" SET ").Append(campo).Append(" = CONCAT(")
                    .Append(campo).Append(",'")
                    .Append(s)
                    .Append("') WHERE ").Append(condicao).Append(";")
                    .Append("\r\n");
            }

            txbThemeParts.Text = sb.ToString();
        }

        private void btnEditarMenu_Click(object sender, EventArgs e)
        {
            Menu menuSelecionado = (Menu)ltbMenu.SelectedItem;

            if (menuSelecionado != null)
            {
                FormMenu menu = new FormMenu(menuSelecionado);

                if (menu.ShowDialog() == DialogResult.OK)
                {
                    _tipoOperacao = "UPDATE";
                    txbQueryMenu.Text = GeraScriptMenu(menuSelecionado.Atualiza(), menuSelecionado.ID_MENU);

                    txbQueryMenu.Focus();
                }
            }
        }

        //static IEnumerable<string> ChunksUpto(string str, int maxChunkSize)
        //{
        //    for (int i = 0; i < str.Length; i += maxChunkSize)
        //        yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
        //}
    }

    public static class Extensions
    {
        public static IEnumerable<string> Split(this string str, int n)
        {
            if (String.IsNullOrEmpty(str) || n < 1)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < str.Length; i += n)
            {
                yield return str.Substring(i, Math.Min(n, str.Length - i));
            }
        }
    }

    //public static class Extensions
    //{
    //    public static IEnumerable<string> Split(this string str, int n)
    //    {
    //        if (String.IsNullOrEmpty(str) || n < 1)
    //        {
    //            throw new ArgumentException();
    //        }

    //        IEnumerable<string> retorno = Enumerable.Range(0, str.Length / n)
    //                        .Select(i => str.Substring(i * n, n));

    //        return retorno;
    //    }
    //}
}
