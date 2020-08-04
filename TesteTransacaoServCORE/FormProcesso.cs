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
    public partial class FormProcesso : Form
    {
        Process _entrada;

        public FormProcesso(Process entrada)
        {
            InitializeComponent();

            _entrada = entrada;

            txb_ID_PROCESS.Text = entrada.ID_PROCESS;
            txb_NAME.Text = entrada.NAME;
            txb_DESCRIPTION.Text = entrada.DESCRIPTION;

            cbb_STATUS.SelectedItem = entrada.STATUS;
            cbb_PROCESS_TYPE.SelectedItem = entrada.PROCESS_TYPE;
            cbb_CREATE_TRANSACTION.SelectedItem = entrada.CREATE_TRANSACTION;
            txb_PROPAGATION_TRANSACTION.Text = entrada.PROPAGATION_TRANSACTION;
            cbb_FINISH_TRANSACTION.SelectedItem = entrada.FINISH_TRANSACTION;

            txb_FULL_PATH.Text = entrada.FULL_PATH;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _entrada.ID_PROCESS = txb_ID_PROCESS.Text;
            _entrada.NAME = txb_NAME.Text;
            _entrada.DESCRIPTION = txb_DESCRIPTION.Text;
            _entrada.CREATE_TRANSACTION = cbb_CREATE_TRANSACTION.SelectedItem.ToString();
            _entrada.PROPAGATION_TRANSACTION = txb_PROPAGATION_TRANSACTION.Text;
            _entrada.FINISH_TRANSACTION = cbb_FINISH_TRANSACTION.SelectedItem.ToString();
            _entrada.FULL_PATH = txb_FULL_PATH.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
