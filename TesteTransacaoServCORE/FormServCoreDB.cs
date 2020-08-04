using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TesteTransacaoServCORE
{
    public partial class FormServCoreDB : Form
    {
        List<Transacao> _transacoes;
        
        public FormServCoreDB(List<Transacao> transacoes)
        {
            InitializeComponent();

            foreach(Transacao t in transacoes)
            {
                t.SELECIONADA = false;

                lsbTransacoes.Items.Add(new StringBuilder(t.ID_TRANSACTION).Append(" - ").Append(t.DESCRIPTION).ToString());
            }

            _transacoes = transacoes;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lsbTransacoes.SelectedItems.Count == 0)
            {
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            else
            {
                foreach (object o in lsbTransacoes.SelectedItems)
                {
                    _transacoes.Find(x => x.ID_TRANSACTION == Regex.Replace(o.ToString().Substring(0, 6).Trim(), "[^0-9]", "")).SELECIONADA = true;
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
