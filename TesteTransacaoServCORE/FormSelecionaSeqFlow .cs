using System;
using System.Windows.Forms;

namespace TesteTransacaoServCORE
{
    public partial class FormSelecionaSeqFlow : Form
    {
        private ComboBox.ObjectCollection items;
        public string seqFlowSelecionado { get; set; }

        public FormSelecionaSeqFlow(ComboBox.ObjectCollection items)
        {
            InitializeComponent();

            this.items = items;

            foreach (Object o in items)
            {
                cbb_SEQ_FLOW.Items.Add(o);
            }

            cbb_SEQ_FLOW.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            seqFlowSelecionado = cbb_SEQ_FLOW.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
