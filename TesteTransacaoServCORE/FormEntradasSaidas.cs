using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TesteTransacaoServCORE
{
    public partial class FormEntradasSaidas : Form
    {
        List<EntradaSaida> _entradas;
        List<TransactionProcess> _processos;
        byte _tipo;
        List<EntradaSaida> _listaSelecionada;


        public FormEntradasSaidas(List<EntradaSaida> entradas, List<TransactionProcess> processos, byte tipo)
        {
            InitializeComponent();

            _entradas = entradas;
            _processos = processos;

            _tipo = tipo;

            if (tipo == 0)
                this.Text = "Entradas";
            else
                this.Text = "Saídas";

            btnAlterar.Visible = false;

            txb_SEQ_FLOW.Enabled = false;
            txb_SEQ_FLOW.Visible = false;

            cbb_ID_PROCESS.Items.Add("NENHUM");

            foreach (Process p in Comuns.processos)
            {
                cbb_ID_PROCESS.Items.Add(p.ID_PROCESS);
            }

            //foreach (TransactionProcess p in seqFlows)
            //{
            //    cbb_SEQ_FLOW.Items.Add(p.SEQ_FLOW);
            //}

            var groupEntradas = entradas.GroupBy(x => x.SEQ_FLOW);

            foreach (var group in groupEntradas)
            {
                cbb_SEQ_FLOW.Items.Add(group.Key);
            }

            if(cbb_SEQ_FLOW.Items.Count > 0)
                cbb_SEQ_FLOW.SelectedIndex = 0;

            CarregaEntradas();
        }

        private void CarregaEntradas()
        {
            ltbEntradas.Items.Clear();

            if (_listaSelecionada != null)
            {
                foreach (EntradaSaida e in _listaSelecionada)
                {
                    ltbEntradas.Items.Add(e.ENV_NAME);
                }

                string processo = string.Empty;

                if (_listaSelecionada.Count > 0)
                    processo = _listaSelecionada[0].ID_PROCESS;

                EntradaSaida seqFlowSelecionado = _entradas.Find(x => x.SEQ_FLOW == cbb_SEQ_FLOW.SelectedItem.ToString());

                if (seqFlowSelecionado.ID_PROCESS != "")
                    cbb_ID_PROCESS.SelectedItem = seqFlowSelecionado.ID_PROCESS;
                else
                    cbb_ID_PROCESS.SelectedIndex = 0;
                //if (processo != "")
                //    cbb_ID_PROCESS.SelectedItem = _processos[cbb_SEQ_FLOW.SelectedIndex].ID_PROCESS;
                //else
                //    cbb_ID_PROCESS.SelectedIndex = 0;

                if (ltbEntradas.Items.Count > 0)
                    ltbEntradas.SelectedIndex = 0;
                else
                {
                    txb_SEQ_FLOW.Text = string.Empty;
                    txb_ENV_NAME.Text = string.Empty;
                    txb_LOGICAL_EVALUATION.Text = string.Empty;
                    txb_DATA_TYPE.Text = string.Empty;
                    txb_ORDER_NUMBER.Text = string.Empty;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ltbEntradas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ltbEntradas.SelectedIndex != -1)
            {
                txb_SEQ_FLOW.Text = _listaSelecionada[ltbEntradas.SelectedIndex].SEQ_FLOW;
                txb_ENV_NAME.Text = _listaSelecionada[ltbEntradas.SelectedIndex].ENV_NAME;
                txb_LOGICAL_EVALUATION.Text = _listaSelecionada[ltbEntradas.SelectedIndex].LOGICAL_EVALUATION;
                txb_DATA_TYPE.Text = _listaSelecionada[ltbEntradas.SelectedIndex].DATA_TYPE;
                txb_ORDER_NUMBER.Text = _listaSelecionada[ltbEntradas.SelectedIndex].ORDER_NUMBER;

                btnCamposJSON.Text = "Editar Eval";
                btnCamposJSON.Visible = true;
                btnCamposJSON.Enabled = true;
                btnCamposJSON.Tag = 0;

                //switch (_listaSelecionada[ltbEntradas.SelectedIndex].ENV_NAME)
                //{
                //    case "JSON_INPUT":
                //        btnCamposJSON.Text = "Campos JSON_INPUT";
                //        btnCamposJSON.Visible = true;
                //        btnCamposJSON.Enabled = true;
                //        btnCamposJSON.Tag = 0;
                //        break;
                //    case "BEFORE_PARSER":
                //        btnCamposJSON.Text = "Eval BEFORE_PARSER";
                //        btnCamposJSON.Visible = true;
                //        btnCamposJSON.Enabled = true;
                //        btnCamposJSON.Tag = 1;
                //        break;
                //    default:
                //        btnCamposJSON.Visible = false;
                //        break;
                //}
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Alterar();
        }

        private void Alterar()
        {
            _listaSelecionada[ltbEntradas.SelectedIndex].SEQ_FLOW = txb_SEQ_FLOW.Text;
            _listaSelecionada[ltbEntradas.SelectedIndex].ENV_NAME = txb_ENV_NAME.Text;
            _listaSelecionada[ltbEntradas.SelectedIndex].LOGICAL_EVALUATION = txb_LOGICAL_EVALUATION.Text;
            _listaSelecionada[ltbEntradas.SelectedIndex].DATA_TYPE = txb_DATA_TYPE.Text;
            _listaSelecionada[ltbEntradas.SelectedIndex].ORDER_NUMBER = txb_ORDER_NUMBER.Text;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            EntradaSaida novo = new EntradaSaida();

            if (cbb_SEQ_FLOW.Items.Count > 0)
                novo.SEQ_FLOW = cbb_SEQ_FLOW.SelectedItem.ToString();
            else
                novo.SEQ_FLOW = "1";

            FormAdicionaEntradaSaida adiciona = new FormAdicionaEntradaSaida(ref novo, _tipo);

            if(adiciona.ShowDialog() == DialogResult.OK)
            {
                _entradas.Add(novo);

                if (cbb_SEQ_FLOW.Items.Count == 0)
                {
                    cbb_SEQ_FLOW.Items.Add(novo.SEQ_FLOW);
                    cbb_SEQ_FLOW.SelectedIndex = 0;
                }

                _listaSelecionada = _entradas.FindAll(x => x.SEQ_FLOW == cbb_SEQ_FLOW.SelectedItem.ToString());
                CarregaEntradas();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Remover campo?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                if (_entradas.Count > 0)
                {
                    _entradas.Remove(_listaSelecionada[ltbEntradas.SelectedIndex]);
                    _listaSelecionada = _entradas.FindAll(x => x.SEQ_FLOW == cbb_SEQ_FLOW.SelectedItem.ToString());
                    CarregaEntradas();
                }
            }
        }

        private void btnCamposJSON_Click(object sender, EventArgs e)
        {
            switch((int)btnCamposJSON.Tag)
            {
                case 0:
                    TrataCamposJSON();
                    break;
                case 1:
                    TrataBEFORE_PARSER();
                    break;   
            }
            
        }

        private void TrataBEFORE_PARSER()
        {
            List<string> campos = new List<string>();

            campos.Add("BEFORE_PARSER");

            string eval = txb_LOGICAL_EVALUATION.Text;

            campos.Add(eval);

            FormEditaEval beforeParser = new FormEditaEval(campos);

            if (beforeParser.ShowDialog() == DialogResult.OK)
            {
                txb_LOGICAL_EVALUATION.Text = campos[1];
            }
        }

        private void TrataCamposJSON()
        {
            List<string> campos = new List<string>();

            campos.Add("JSON_INPUT");

            string eval = txb_LOGICAL_EVALUATION.Text;

            campos.Add(eval);

            FormEditaEval beforeParser = new FormEditaEval(campos);

            if (beforeParser.ShowDialog() == DialogResult.OK)
            {
                txb_LOGICAL_EVALUATION.Text = campos[1];
            }

            //campos = SeparaEntradas(txb_LOGICAL_EVALUATION.Text);

            //if (campos.Count > 0)
            //{
            //    FormEditaEval campoJson = new FormEditaEval(campos);

            //    if (campoJson.ShowDialog() == DialogResult.OK)
            //    {
            //        txb_LOGICAL_EVALUATION.Text = GeraJSON_INPUT(campos);
            //    }
            //}
        }

        private List<string> SeparaEntradas(string entrada)
        {
            string[] partes;

            List<string> campos = new List<string>(); 

            if (entrada.Contains("JSON_INPUT=JSON.stringify(requestBody);"))
            {
                partes = entrada.Split('=');

                foreach (string s in partes)
                {
                    if(s.Contains("transaction.data."))
                    {
                        campos.Add(s.Split(',')[0].Remove(0, 17).Trim());
                    }
                }
            }

            return campos;
        }

        private string GeraJSON_INPUT(List<string> campos)
        {
            string retorno = string.Empty;

            if (campos.Count() > 0)
            {
                StringBuilder sb = new StringBuilder("var requestBody={};");

                foreach (string s in campos)
                {
                    sb.Append("requestBody.").Append(s).Append("=transaction.data.").Append(s).Append(",");
                }

                sb.Append("JSON_INPUT=JSON.stringify(requestBody);");

                retorno = sb.ToString();
            }


            return retorno;
        }

        private void txb_SEQ_FLOW_TextChanged(object sender, EventArgs e)
        {
            if(ltbEntradas.SelectedIndex != -1)
                _listaSelecionada[ltbEntradas.SelectedIndex].SEQ_FLOW = txb_SEQ_FLOW.Text;
        }

        private void txb_ENV_NAME_TextChanged(object sender, EventArgs e)
        {
            if (ltbEntradas.SelectedIndex != -1)
                _listaSelecionada[ltbEntradas.SelectedIndex].ENV_NAME = txb_ENV_NAME.Text;
        }

        private void txb_LOGICAL_EVALUATION_TextChanged(object sender, EventArgs e)
        {
            if (ltbEntradas.SelectedIndex != -1)
                _listaSelecionada[ltbEntradas.SelectedIndex].LOGICAL_EVALUATION = txb_LOGICAL_EVALUATION.Text;
        }

        private void txb_DATA_TYPE_TextChanged(object sender, EventArgs e)
        {
            if (ltbEntradas.SelectedIndex != -1)
                _listaSelecionada[ltbEntradas.SelectedIndex].DATA_TYPE = txb_DATA_TYPE.Text;
        }

        private void txb_ORDER_NUMBER_TextChanged(object sender, EventArgs e)
        {
            if (ltbEntradas.SelectedIndex != -1)
                _listaSelecionada[ltbEntradas.SelectedIndex].ORDER_NUMBER = txb_ORDER_NUMBER.Text;
        }

        private void btnAdicionaSeqFlow_Click(object sender, EventArgs e)
        {
            if (_entradas.Count > 0)
            {
                List<EntradaSaida> novoSeqFlow = new List<EntradaSaida>();

                novoSeqFlow = (List<EntradaSaida>)Util.DeepClone(_entradas);

                var groupEntradas = _entradas.GroupBy(x => x.SEQ_FLOW);

                int seqFlow = int.Parse(groupEntradas.Max(x => x.Key)) + 1;
                //int seqFlow = int.Parse(_seqFlows.Max(x => x.SEQ_FLOW)) + 1;

                foreach (EntradaSaida es in novoSeqFlow.FindAll(x => x.SEQ_FLOW == cbb_SEQ_FLOW.SelectedItem.ToString()))
                {
                    es.SEQ_FLOW = seqFlow.ToString();
                    es.ID_PROCESS = "";
                    _entradas.Add(es);
                }

                //TransactionProcess novoProcess = new TransactionProcess();

                //novoProcess.SEQ_FLOW = seqFlow.ToString();
                //novoProcess.ID_PROCESS = "65";

                //_seqFlows.Add(novoProcess);

                cbb_SEQ_FLOW.Items.Add(seqFlow.ToString());
                cbb_SEQ_FLOW.SelectedItem = seqFlow.ToString();

                CarregaEntradas();
            }
        }

        private void cbb_SEQ_FLOW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_SEQ_FLOW.SelectedIndex != -1)
            {
                _listaSelecionada = _entradas.FindAll(x => x.SEQ_FLOW == cbb_SEQ_FLOW.SelectedItem.ToString());
                CarregaEntradas();
            }
        }

        private void cbb_ID_PROCESS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbb_ID_PROCESS.SelectedIndex != -1)
            {
                EntradaSaida seqFlowSelecionado = _entradas.Find(x => x.SEQ_FLOW == cbb_SEQ_FLOW.SelectedItem.ToString());
                TransactionProcess processSelecionado = _processos.Find(x => x.SEQ_FLOW == seqFlowSelecionado.SEQ_FLOW);

                if (processSelecionado != null)
                {
                    if (cbb_ID_PROCESS.SelectedIndex == 0)
                    {
                        seqFlowSelecionado.ID_PROCESS = "";

                        if (processSelecionado != null)
                            _processos.Remove(processSelecionado);
                    }
                    else
                    {
                        processSelecionado.ID_PROCESS = cbb_ID_PROCESS.SelectedItem.ToString();
                        processSelecionado.SEQ_FLOW= cbb_SEQ_FLOW.SelectedItem.ToString();
                    }
                }
                else
                {
                    if (cbb_ID_PROCESS.SelectedIndex != 0 && seqFlowSelecionado != null)
                    {
                        seqFlowSelecionado.ID_PROCESS = cbb_ID_PROCESS.SelectedItem.ToString();

                        TransactionProcess tprocess = new TransactionProcess();

                        tprocess.ID_PROCESS = cbb_ID_PROCESS.SelectedItem.ToString();
                        tprocess.SEQ_FLOW = cbb_SEQ_FLOW.SelectedItem.ToString();

                        _processos.Add(tprocess);
                    }
                }
                //if (cbb_ID_PROCESS.SelectedIndex == 0)
                //{
                //    if(cbb_SEQ_FLOW.SelectedIndex > 0 && _processos.Count > cbb_SEQ_FLOW.SelectedIndex)
                //    {
                //        _processos.RemoveAt(cbb_SEQ_FLOW.SelectedIndex);

                //        foreach(EntradaSaida es in _listaSelecionada)
                //        {
                //            es.ID_PROCESS = "";
                //        }
                //    }
                //}
                //else
                //{
                //    if (cbb_SEQ_FLOW.SelectedIndex >= _processos.Count)
                //    {
                //        TransactionProcess tprocess = new TransactionProcess();

                //        tprocess.ID_PROCESS = cbb_ID_PROCESS.SelectedItem.ToString();
                //        tprocess.SEQ_FLOW = cbb_SEQ_FLOW.SelectedItem.ToString();

                //        _processos.Add(tprocess);

                //        foreach(EntradaSaida es in _listaSelecionada)
                //        {
                //            es.ID_PROCESS = tprocess.ID_PROCESS;
                //        }
                //    }
                //    else
                //    {
                //        _processos[cbb_SEQ_FLOW.SelectedIndex].ID_PROCESS = cbb_ID_PROCESS.SelectedItem.ToString();
                //    }
                //}
            }
        }

        private void btnRemoveSeqFlow_Click(object sender, EventArgs e)
        {
            if (cbb_SEQ_FLOW.Items.Count > 1)
            {
                EntradaSaida seqFlowSelecionado = _entradas.Find(x => x.SEQ_FLOW == cbb_SEQ_FLOW.SelectedItem.ToString());

                if (seqFlowSelecionado.ID_PROCESS != "")
                {
                    TransactionProcess processSelecionado = _processos.Find(x => x.SEQ_FLOW == seqFlowSelecionado.SEQ_FLOW);
                    _processos.Remove(processSelecionado);
                }

                _entradas.Remove(seqFlowSelecionado);

                cbb_SEQ_FLOW.Items.Remove(seqFlowSelecionado.SEQ_FLOW);
                cbb_SEQ_FLOW.SelectedIndex = cbb_SEQ_FLOW.Items.Count - 1;

                CarregaEntradas();
            }
        }

        private void btnCopiarSeqFlow_Click(object sender, EventArgs e)
        {
            FormSelecionaSeqFlow seqflow = new FormSelecionaSeqFlow(cbb_SEQ_FLOW.Items);

            if (seqflow.ShowDialog() == DialogResult.OK)
            {
                List<EntradaSaida> entradas = _entradas.FindAll(x => x.SEQ_FLOW == cbb_SEQ_FLOW.SelectedItem.ToString());

                foreach(EntradaSaida es in entradas)
                {
                    _entradas.Remove(es);
                }

                List<EntradaSaida> entradasFinais =(List<EntradaSaida>)Util.DeepClone(_entradas.FindAll(x => x.SEQ_FLOW == seqflow.seqFlowSelecionado));

                foreach (EntradaSaida es in entradasFinais)
                {
                    es.SEQ_FLOW = cbb_SEQ_FLOW.SelectedItem.ToString();
                    _entradas.Add(es);
                }

                _listaSelecionada = _entradas.FindAll(x => x.SEQ_FLOW == cbb_SEQ_FLOW.SelectedItem.ToString());

                CarregaEntradas();
            }
        }
    }
}