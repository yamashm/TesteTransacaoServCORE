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
    public partial class FormEditaEval : Form
    {
        List<string> _campos;

        public FormEditaEval(List<string> campos)
        {
            InitializeComponent();

            _campos = campos;

            //if (_campos[0] == "BEFORE_PARSER")
            //{
                txbCampos.Text = campos[1];
            //}
            //else
            //{
            //    StringBuilder sb = new StringBuilder();

            //    foreach (string s in campos)
            //    {
            //        sb.Append(s).Append(",");
            //    }

            //    txbCampos.Text = sb.ToString().Substring(0, sb.ToString().Length - 1);
            //}
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (_campos[0] == "BEFORE_PARSER")
            //{
                _campos[1] = txbCampos.Text;
            //}
            //else
            //{ 
            //    string[] campos = txbCampos.Text.Trim().Split(',');

            //    _campos.Clear();

            //    foreach (string s in campos)
            //    {
            //        _campos.Add(s);
            //    }
            //}

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
