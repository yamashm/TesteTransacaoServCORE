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
    public partial class FormConfig : Form
    {
        ConfigIfChannel _entrada;

        public FormConfig(ConfigIfChannel entrada)
        {
            InitializeComponent();

            _entrada = entrada;

            cbb_VALIDATION.Items.Add("Y");
            cbb_VALIDATION.Items.Add("N");

            cbb_VALIDATION.SelectedItem = entrada.VALIDATION;

            txb_KEY_CONFIG.Text = entrada.KEY_CONFIG;
            txb_PARAM_TYPE.Text = entrada.PARAM_TYPE;
            txb_PARAM_GROUP.Text = entrada.PARAM_GROUP;
            txb_DESCRIPTION.Text = entrada.DESCRIPTION;
            txb_ENABLED.Text = entrada.ENABLED;
            txb_ID_CHANNEL.Text = entrada.ID_CHANNEL;
            txb_ID_IF.Text = entrada.ID_IF;
            txb_RESULT_EVAL.Text = entrada.RESULT_EVAL;
            txb_VALUE.Text = entrada.VALUE;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _entrada.KEY_CONFIG = txb_KEY_CONFIG.Text;
            _entrada.PARAM_TYPE = txb_PARAM_TYPE.Text;         
            _entrada.PARAM_GROUP = txb_PARAM_GROUP.Text;
            _entrada.VALIDATION = cbb_VALIDATION.SelectedItem.ToString();
            _entrada.DESCRIPTION = txb_DESCRIPTION.Text;         
            _entrada.ENABLED = txb_ENABLED.Text;     
            _entrada.ID_CHANNEL = txb_ID_CHANNEL.Text;     
            _entrada.ID_IF = txb_ID_IF.Text;                
            _entrada.RESULT_EVAL = txb_RESULT_EVAL.Text;                  
            _entrada.VALUE = txb_VALUE.Text;                              

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
