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
    public partial class FormEditar : Form
    {
        Transacao _novaTransacao;
        List<EntradaSaida> _listaNovaEntradas;
        List<EntradaSaida> _listaNovaSaidas;
        List<TransactionProcess> _listaNovaProcessos;

        public FormEditar(Transacao novaTransacao, bool editarInpuOutput)
        {
            InitializeComponent();

            foreach(TransactionGroup trn in Comuns.grupos)
            {
                cbb_trn_group.Items.Add(trn.DESCRIPTION);
            }

            _novaTransacao = novaTransacao;

            txb_nu_transacao.Text = novaTransacao.ID_TRANSACTION;
            txb_id_if_permissoes.Text = novaTransacao.ID_IF;
            txb_id_if_input_output.Text = novaTransacao.ID_IF_2;
            txb_id_channel.Text = novaTransacao.ID_CHANNEL;
            
            txb_description.Text = novaTransacao.DESCRIPTION;
            txb_shortdescription.Text = novaTransacao.SHORT_DESCRIPTION;

            cbb_trn_group.SelectedItem = Comuns.grupos.Find(x=>x.ID_TRN_GROUP == novaTransacao.ID_TRN_GROUP).DESCRIPTION;

            cbb_category.SelectedItem = novaTransacao.CATEGORY;

            var groupEntradas = novaTransacao.Entradas.GroupBy(x => x.SEQ_FLOW);

            foreach (var group in groupEntradas)
            {
                cbb_seq_flow.Items.Add(group.Key);
            }

            //foreach (TransactionProcess p in novaTransacao.Processos)
            //{
            //    cbb_seq_flow.Items.Add(p.SEQ_FLOW);
            //}

            if(cbb_seq_flow.Items.Count > 0)
                cbb_seq_flow.SelectedIndex = 0;

            if (novaTransacao.NOVA)
            {
                txb_nu_transacao.Enabled = true;
                ckbUpdate.Visible = false;
            }
            else
            {
                txb_nu_transacao.Enabled = false;

                if (editarInpuOutput)
                {
                    txb_id_if_permissoes.Enabled = false;
                    txb_id_if_input_output.Enabled = false;
                    txb_id_channel.Enabled = false;
                    cbb_id_process.Enabled = false;
                    txb_description.Enabled = false;
                    txb_shortdescription.Enabled = false;
                    cbb_seq_flow.Enabled = false;
                    cbb_category.Enabled = false;
                    cbb_trn_group.Enabled = false;
                }
                else
                    ckbUpdate.Visible = false;
            }

            _listaNovaEntradas = new List<EntradaSaida>();
            _listaNovaEntradas = (List<EntradaSaida>)Util.DeepClone(_novaTransacao.Entradas);
            _listaNovaSaidas = new List<EntradaSaida>();
            _listaNovaSaidas = (List<EntradaSaida>)Util.DeepClone(_novaTransacao.Saidas);
            _listaNovaProcessos = new List<TransactionProcess>();
            _listaNovaProcessos = (List<TransactionProcess>)Util.DeepClone(_novaTransacao.Processos);

            foreach (Process p in Comuns.processos)
            {
                cbb_id_process.Items.Add(p.ID_PROCESS);
            }
            
			if(cbb_seq_flow.SelectedIndex != -1)
            	cbb_id_process.SelectedItem = novaTransacao.Entradas[cbb_seq_flow.SelectedIndex].ID_PROCESS;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _novaTransacao.ID_TRANSACTION = txb_nu_transacao.Text;
            _novaTransacao.ID_IF = txb_id_if_permissoes.Text;
            _novaTransacao.ID_IF_2 = txb_id_if_input_output.Text;
            _novaTransacao.ID_CHANNEL = txb_id_channel.Text;
            //_novaTransacao.ID_PROCESS = txb_id_process.Text;
            _novaTransacao.DESCRIPTION = txb_description.Text.Trim();
            _novaTransacao.SHORT_DESCRIPTION = txb_shortdescription.Text.Trim();
            _novaTransacao.CATEGORY = cbb_category.SelectedItem.ToString();
            _novaTransacao.ID_TRN_GROUP = Comuns.grupos.Find(x => x.DESCRIPTION == cbb_trn_group.SelectedItem.ToString()).ID_TRN_GROUP;

            _novaTransacao.Processos = _listaNovaProcessos;
            _novaTransacao.Entradas = _listaNovaEntradas;
            _novaTransacao.Saidas = _listaNovaSaidas;

            if (!ckbUpdate.Checked)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Yes;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            List<EntradaSaida> listaNova = new List<EntradaSaida>();
            List<TransactionProcess> listaNovaProcessos = new List<TransactionProcess>();

            listaNova = (List<EntradaSaida>)Util.DeepClone(_listaNovaEntradas);
            listaNovaProcessos = (List<TransactionProcess>)Util.DeepClone(_listaNovaProcessos);

            FormEntradasSaidas entradas = new FormEntradasSaidas(listaNova, listaNovaProcessos, 0);

            if(entradas.ShowDialog() == DialogResult.OK)
            {
                _listaNovaEntradas = listaNova;
                _listaNovaProcessos = listaNovaProcessos;
            }
        }

        private void btnSaidas_Click(object sender, EventArgs e)
        {
            List<EntradaSaida> listaNova = new List<EntradaSaida>();
            List<TransactionProcess> listaNovaProcessos = new List<TransactionProcess>();

            listaNova = (List<EntradaSaida>)Util.DeepClone(_listaNovaSaidas);
            listaNovaProcessos = (List<TransactionProcess>)Util.DeepClone(_listaNovaProcessos);

            FormEntradasSaidas saidas = new FormEntradasSaidas(listaNova, listaNovaProcessos, 1);

            if (saidas.ShowDialog() == DialogResult.OK)
            {
                _listaNovaSaidas = listaNova;
                _listaNovaProcessos = listaNovaProcessos;
            }
        }

        private void cbb_seq_flow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_seq_flow.SelectedIndex != -1)
            {
                EntradaSaida entradaSelecionada = _novaTransacao.Entradas.Find(x => x.SEQ_FLOW == cbb_seq_flow.SelectedItem.ToString());
                //TransactionProcess p = _novaTransacao.Processos[cbb_seq_flow.SelectedIndex];
                cbb_id_process.SelectedItem = entradaSelecionada.ID_PROCESS;
            }
        }

        private void cbb_id_process_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbb_id_process.SelectedIndex != -1)
            {
                TransactionProcess processSelecionado = _listaNovaProcessos.Find(x => x.SEQ_FLOW == cbb_seq_flow.SelectedItem.ToString());
                if(processSelecionado != null)
                	processSelecionado.ID_PROCESS = cbb_id_process.SelectedItem.ToString();
                //_listaNovaProcessos[_listaNovaProcessos.FindIndex(x => x == processSelecionado)].ID_PROCESS = cbb_id_process.SelectedItem.ToString();
            }
        }
    }
}
