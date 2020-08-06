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
    public partial class FormLabel : Form
    {
        Label _entrada;

        public FormLabel(Label entrada)
        {
            InitializeComponent();

            _entrada = entrada;

            txb_ID_IF.Text = entrada.ID_IF;
            txb_ID_LABEL.Text = entrada.ID_LABEL;
            txb_LOCALE.Text = entrada.LOCALE;
            txb_LABEL.Text = entrada.LABEL;

            if (entrada.ID_LABEL != null)
                txb_ID_LABEL.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _entrada.ID_IF = txb_ID_IF.Text;
            _entrada.ID_LABEL = txb_ID_LABEL.Text;
            _entrada.LOCALE = txb_LOCALE.Text;
            _entrada.LABEL = txb_LABEL.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
