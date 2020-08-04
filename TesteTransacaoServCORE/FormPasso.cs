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
    public partial class FormPasso : Form
    {
        Orch _entrada;

        public FormPasso(Orch entrada)
        {
            InitializeComponent();

            _entrada = entrada;

            cbb_ID_ACTIVITY.Items.Add("NULL");

            foreach (Activity a in Comuns.atividades)
            {
                cbb_ID_ACTIVITY.Items.Add(a.ID_ACTIVITY);
            }

            cbb_ID_PROCESS_CHILD.Items.Add("NULL");
            foreach (Process p in Comuns.processos)
            {
                cbb_ID_PROCESS_CHILD.Items.Add(p.ID_PROCESS);
            }

            //if (entrada.STEP != "0")
            //{
                txb_STEP.Text = entrada.STEP;
            //    txb_STEP.Enabled = false;
            //}

            if (entrada.ID_ACTIVITY == "")
                cbb_ID_ACTIVITY.SelectedIndex = 0;
            else
                cbb_ID_ACTIVITY.SelectedItem = entrada.ID_ACTIVITY;

            if (entrada.ID_PROCESS_CHILD == "")
                cbb_ID_PROCESS_CHILD.SelectedIndex = 0;
            else
                cbb_ID_PROCESS_CHILD.SelectedItem = entrada.ID_PROCESS_CHILD;

            //txb_CREATE_TRANSACTION.Text = entrada.CREATE_TRANSACTION;
            cbb_CREATE_TRANSACTION.SelectedItem = entrada.CREATE_TRANSACTION;
            txb_PROPAGATION_TRANSACTION.Text = entrada.PROPAGATION_TRANSACTION;
            //txb_FINISH_TRANSACTION.Text = entrada.FINISH_TRANSACTION;
            cbb_FINISH_TRANSACTION.SelectedItem = entrada.FINISH_TRANSACTION;
            txb_NEXT_STEP.Text = entrada.NEXT_STEP;

            if (entrada.ID_ACTIVITY != "")
                txb_ACTIVITY_NAME.Text = Comuns.atividades.Find(x => x.ID_ACTIVITY == entrada.ID_ACTIVITY).NAME;
            else
                txb_ACTIVITY_NAME.Text = "NULL";

            if (entrada.RESULT_EVAL == "")
                txb_RESULT_EVAL.Text = "NULL";
            else
                txb_RESULT_EVAL.Text = entrada.RESULT_EVAL;

            if (entrada.EXCEPTION_EVAL == "")
                txb_EXCEPTION_EVAL.Text = "NULL";
            else
                txb_EXCEPTION_EVAL.Text = entrada.EXCEPTION_EVAL;

            if (entrada.BEFORE_EXECUTE_EVAL == "")
                txb_BEFORE_EXECUTE_EVAL.Text = "NULL";
            else
                txb_BEFORE_EXECUTE_EVAL.Text = entrada.BEFORE_EXECUTE_EVAL;

            txb_CACHE_EVAL.Text = entrada.CACHE_EVAL;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _entrada.STEP_EDITADO = txb_STEP.Text;
            _entrada.ID_ACTIVITY = cbb_ID_ACTIVITY.SelectedItem.ToString();         
            _entrada.ID_PROCESS_CHILD = cbb_ID_PROCESS_CHILD.SelectedItem.ToString();   
            _entrada.CREATE_TRANSACTION = cbb_CREATE_TRANSACTION.SelectedItem.ToString();         
            _entrada.PROPAGATION_TRANSACTION = txb_PROPAGATION_TRANSACTION.Text;     
            _entrada.FINISH_TRANSACTION = cbb_FINISH_TRANSACTION.SelectedItem.ToString();     
            _entrada.NEXT_STEP = txb_NEXT_STEP.Text;                
            _entrada.RESULT_EVAL = txb_RESULT_EVAL.Text;                  
            _entrada.EXCEPTION_EVAL = txb_EXCEPTION_EVAL.Text;              
            _entrada.BEFORE_EXECUTE_EVAL = txb_BEFORE_EXECUTE_EVAL.Text; 
            _entrada.CACHE_EVAL = txb_CACHE_EVAL.Text;                  

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbb_ID_ACTIVITY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_ID_ACTIVITY.SelectedIndex != -1)
            {
                if (cbb_ID_ACTIVITY.SelectedItem.ToString() != "NULL")
                    txb_ACTIVITY_NAME.Text = Comuns.atividades.Find(x => x.ID_ACTIVITY == cbb_ID_ACTIVITY.SelectedItem.ToString()).NAME;
                else
                    txb_ACTIVITY_NAME.Text = "NULL";
            }
        }
    }
}
