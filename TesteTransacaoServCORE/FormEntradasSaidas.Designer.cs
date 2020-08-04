namespace TesteTransacaoServCORE
{
    partial class FormEntradasSaidas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCopiarSeqFlow = new System.Windows.Forms.Button();
            this.btnRemoveSeqFlow = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbb_ID_PROCESS = new System.Windows.Forms.ComboBox();
            this.cbb_SEQ_FLOW = new System.Windows.Forms.ComboBox();
            this.btnAdicionaSeqFlow = new System.Windows.Forms.Button();
            this.btnCamposJSON = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_SEQ_FLOW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_ORDER_NUMBER = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_DATA_TYPE = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txb_LOGICAL_EVALUATION = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txb_ENV_NAME = new System.Windows.Forms.TextBox();
            this.ltbEntradas = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCopiarSeqFlow);
            this.groupBox2.Controls.Add(this.btnRemoveSeqFlow);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbb_ID_PROCESS);
            this.groupBox2.Controls.Add(this.cbb_SEQ_FLOW);
            this.groupBox2.Controls.Add(this.btnAdicionaSeqFlow);
            this.groupBox2.Controls.Add(this.btnCamposJSON);
            this.groupBox2.Controls.Add(this.btnRemover);
            this.groupBox2.Controls.Add(this.btnAdicionar);
            this.groupBox2.Controls.Add(this.btnAlterar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txb_SEQ_FLOW);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txb_ORDER_NUMBER);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txb_DATA_TYPE);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txb_LOGICAL_EVALUATION);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txb_ENV_NAME);
            this.groupBox2.Controls.Add(this.ltbEntradas);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1013, 287);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Entradas";
            // 
            // btnCopiarSeqFlow
            // 
            this.btnCopiarSeqFlow.Location = new System.Drawing.Point(521, 250);
            this.btnCopiarSeqFlow.Name = "btnCopiarSeqFlow";
            this.btnCopiarSeqFlow.Size = new System.Drawing.Size(150, 23);
            this.btnCopiarSeqFlow.TabIndex = 38;
            this.btnCopiarSeqFlow.Text = "Copiar Seq Flow";
            this.btnCopiarSeqFlow.UseVisualStyleBackColor = true;
            this.btnCopiarSeqFlow.Click += new System.EventHandler(this.btnCopiarSeqFlow_Click);
            // 
            // btnRemoveSeqFlow
            // 
            this.btnRemoveSeqFlow.Location = new System.Drawing.Point(365, 250);
            this.btnRemoveSeqFlow.Name = "btnRemoveSeqFlow";
            this.btnRemoveSeqFlow.Size = new System.Drawing.Size(150, 23);
            this.btnRemoveSeqFlow.TabIndex = 37;
            this.btnRemoveSeqFlow.Text = "Remove Seq Flow";
            this.btnRemoveSeqFlow.UseVisualStyleBackColor = true;
            this.btnRemoveSeqFlow.Click += new System.EventHandler(this.btnRemoveSeqFlow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "ID_PROCESS";
            // 
            // cbb_ID_PROCESS
            // 
            this.cbb_ID_PROCESS.FormattingEnabled = true;
            this.cbb_ID_PROCESS.Location = new System.Drawing.Point(370, 33);
            this.cbb_ID_PROCESS.Name = "cbb_ID_PROCESS";
            this.cbb_ID_PROCESS.Size = new System.Drawing.Size(121, 21);
            this.cbb_ID_PROCESS.TabIndex = 35;
            this.cbb_ID_PROCESS.SelectedIndexChanged += new System.EventHandler(this.cbb_ID_PROCESS_SelectedIndexChanged);
            // 
            // cbb_SEQ_FLOW
            // 
            this.cbb_SEQ_FLOW.FormattingEnabled = true;
            this.cbb_SEQ_FLOW.Location = new System.Drawing.Point(209, 33);
            this.cbb_SEQ_FLOW.Name = "cbb_SEQ_FLOW";
            this.cbb_SEQ_FLOW.Size = new System.Drawing.Size(121, 21);
            this.cbb_SEQ_FLOW.TabIndex = 34;
            this.cbb_SEQ_FLOW.SelectedIndexChanged += new System.EventHandler(this.cbb_SEQ_FLOW_SelectedIndexChanged);
            // 
            // btnAdicionaSeqFlow
            // 
            this.btnAdicionaSeqFlow.Location = new System.Drawing.Point(209, 250);
            this.btnAdicionaSeqFlow.Name = "btnAdicionaSeqFlow";
            this.btnAdicionaSeqFlow.Size = new System.Drawing.Size(150, 23);
            this.btnAdicionaSeqFlow.TabIndex = 33;
            this.btnAdicionaSeqFlow.Text = "Adiciona Seq Flow";
            this.btnAdicionaSeqFlow.UseVisualStyleBackColor = true;
            this.btnAdicionaSeqFlow.Click += new System.EventHandler(this.btnAdicionaSeqFlow_Click);
            // 
            // btnCamposJSON
            // 
            this.btnCamposJSON.Location = new System.Drawing.Point(779, 141);
            this.btnCamposJSON.Name = "btnCamposJSON";
            this.btnCamposJSON.Size = new System.Drawing.Size(223, 23);
            this.btnCamposJSON.TabIndex = 32;
            this.btnCamposJSON.Text = "Campos JSON_INPUT";
            this.btnCamposJSON.UseVisualStyleBackColor = true;
            this.btnCamposJSON.Click += new System.EventHandler(this.btnCamposJSON_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(117, 250);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 23);
            this.btnRemover.TabIndex = 31;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(8, 250);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 30;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(779, 250);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(223, 23);
            this.btnAlterar.TabIndex = 29;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "SEQ_FLOW";
            // 
            // txb_SEQ_FLOW
            // 
            this.txb_SEQ_FLOW.Location = new System.Drawing.Point(209, 34);
            this.txb_SEQ_FLOW.Name = "txb_SEQ_FLOW";
            this.txb_SEQ_FLOW.Size = new System.Drawing.Size(793, 20);
            this.txb_SEQ_FLOW.TabIndex = 27;
            this.txb_SEQ_FLOW.Text = "1";
            this.txb_SEQ_FLOW.TextChanged += new System.EventHandler(this.txb_SEQ_FLOW_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "ORDER_NUMBER";
            // 
            // txb_ORDER_NUMBER
            // 
            this.txb_ORDER_NUMBER.Location = new System.Drawing.Point(209, 218);
            this.txb_ORDER_NUMBER.Name = "txb_ORDER_NUMBER";
            this.txb_ORDER_NUMBER.Size = new System.Drawing.Size(793, 20);
            this.txb_ORDER_NUMBER.TabIndex = 25;
            this.txb_ORDER_NUMBER.TextChanged += new System.EventHandler(this.txb_ORDER_NUMBER_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "DATA_TYPE";
            // 
            // txb_DATA_TYPE
            // 
            this.txb_DATA_TYPE.Location = new System.Drawing.Point(209, 170);
            this.txb_DATA_TYPE.Name = "txb_DATA_TYPE";
            this.txb_DATA_TYPE.Size = new System.Drawing.Size(793, 20);
            this.txb_DATA_TYPE.TabIndex = 23;
            this.txb_DATA_TYPE.TextChanged += new System.EventHandler(this.txb_DATA_TYPE_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(198, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "LOGICAL_EVALUATION";
            // 
            // txb_LOGICAL_EVALUATION
            // 
            this.txb_LOGICAL_EVALUATION.Location = new System.Drawing.Point(209, 120);
            this.txb_LOGICAL_EVALUATION.Name = "txb_LOGICAL_EVALUATION";
            this.txb_LOGICAL_EVALUATION.Size = new System.Drawing.Size(793, 20);
            this.txb_LOGICAL_EVALUATION.TabIndex = 21;
            this.txb_LOGICAL_EVALUATION.TextChanged += new System.EventHandler(this.txb_LOGICAL_EVALUATION_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(198, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "ENV_NAME";
            // 
            // txb_ENV_NAME
            // 
            this.txb_ENV_NAME.Location = new System.Drawing.Point(209, 76);
            this.txb_ENV_NAME.Name = "txb_ENV_NAME";
            this.txb_ENV_NAME.Size = new System.Drawing.Size(793, 20);
            this.txb_ENV_NAME.TabIndex = 19;
            this.txb_ENV_NAME.TextChanged += new System.EventHandler(this.txb_ENV_NAME_TextChanged);
            // 
            // ltbEntradas
            // 
            this.ltbEntradas.FormattingEnabled = true;
            this.ltbEntradas.Location = new System.Drawing.Point(8, 18);
            this.ltbEntradas.Name = "ltbEntradas";
            this.ltbEntradas.Size = new System.Drawing.Size(184, 225);
            this.ltbEntradas.TabIndex = 18;
            this.ltbEntradas.SelectedIndexChanged += new System.EventHandler(this.ltbEntradas_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(869, 305);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 23;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(950, 305);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormEntradasSaidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 336);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEntradasSaidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entradas";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox ltbEntradas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txb_LOGICAL_EVALUATION;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txb_ENV_NAME;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_ORDER_NUMBER;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_DATA_TYPE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_SEQ_FLOW;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnCamposJSON;
        private System.Windows.Forms.Button btnAdicionaSeqFlow;
        private System.Windows.Forms.ComboBox cbb_SEQ_FLOW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbb_ID_PROCESS;
        private System.Windows.Forms.Button btnRemoveSeqFlow;
        private System.Windows.Forms.Button btnCopiarSeqFlow;
    }
}