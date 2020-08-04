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
    public partial class FormAdicionaEntradaSaida : Form
    {
        EntradaSaida _novo;

        List<EntradaSaida> _lista;

        public FormAdicionaEntradaSaida(ref EntradaSaida novo, byte tipo)
        {
            InitializeComponent();

            _novo = novo;

            txb_SEQ_FLOW.Enabled = false;
            txb_SEQ_FLOW.Text = novo.SEQ_FLOW;

            CarregaComboComuns(tipo);
        }

        private void CarregaComboComuns(byte tipo)
        {
            _lista = new List<EntradaSaida>();

            if(tipo == 0)
            {
                _lista = Comuns.entradasComuns;
            }
            else
            {
                _lista = Comuns.saidasComuns;
            }

            foreach(EntradaSaida e in _lista)
            {
                e.SEQ_FLOW = _novo.SEQ_FLOW;
                cbbComuns.Items.Add(e.ENV_NAME);
            }

            if (cbbComuns.Items.Count > 0)
                cbbComuns.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _novo.SEQ_FLOW = txb_SEQ_FLOW.Text;
            _novo.ENV_NAME = txb_ENV_NAME.Text;
            _novo.LOGICAL_EVALUATION = txb_LOGICAL_EVALUATION.Text;
            _novo.DATA_TYPE = txb_DATA_TYPE.Text;
            _novo.ORDER_NUMBER = txb_ORDER_NUMBER.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbbComuns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbComuns.SelectedIndex != -1)
            {
                txb_SEQ_FLOW.Text = _lista[cbbComuns.SelectedIndex].SEQ_FLOW;
                txb_ENV_NAME.Text = _lista[cbbComuns.SelectedIndex].ENV_NAME;
                txb_LOGICAL_EVALUATION.Text = _lista[cbbComuns.SelectedIndex].LOGICAL_EVALUATION;
                txb_DATA_TYPE.Text = _lista[cbbComuns.SelectedIndex].DATA_TYPE;
                txb_ORDER_NUMBER.Text = _lista[cbbComuns.SelectedIndex].ORDER_NUMBER;
            }
        }
    }
}
