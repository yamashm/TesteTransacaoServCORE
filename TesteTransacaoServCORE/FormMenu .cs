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
    public partial class FormMenu : Form
    {
        Menu _entrada;

        public FormMenu(Menu entrada)
        {
            InitializeComponent();

            _entrada = entrada;

            if (entrada.ID_MENU_PARENT == "")
                entrada.ID_MENU_PARENT = "NULL";

            if (entrada.ID_TRANSACTION == "")
                entrada.ID_TRANSACTION = "NULL";

            txb_ID_MENU_PARENT.Text = entrada.ID_MENU_PARENT;
            txb_ID_TRANSACTION.Text = entrada.ID_TRANSACTION;
            txb_DESCRIPTION.Text = entrada.DESCRIPTION;
            txb_ACTION.Text = entrada.ACTION;
            txb_ID_IMG.Text = entrada.ID_IMG;
            txb_LEVEL_MENU.Text = entrada.LEVEL_MENU;
            txb_ORDER_NUMBER.Text = entrada.ORDER_NUMBER;
            txb_DATA.Text = entrada.DATA;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _entrada.ID_MENU_PARENT = txb_ID_MENU_PARENT.Text;
            _entrada.ID_TRANSACTION = txb_ID_TRANSACTION.Text;
            _entrada.DESCRIPTION = txb_DESCRIPTION.Text;
            _entrada.ACTION = txb_ACTION.Text;
            _entrada.ID_IMG = txb_ID_IMG.Text; ;
            _entrada.LEVEL_MENU = txb_LEVEL_MENU.Text;
            _entrada.ORDER_NUMBER = txb_ORDER_NUMBER.Text;
            _entrada.DATA = txb_DATA.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
